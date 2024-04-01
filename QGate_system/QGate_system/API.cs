using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Net.NetworkInformation;

namespace QGate_system.API
{
    public class API
    {
        public static string baseUrl = "http://192.168.161.77:1000/";
        //public static string baseUrl = "http://172.21.64.41:1000/";
        //public static string baseUrl = "http://192.168.1.184:1000/";
        //public static string baseUrl = "http://192.168.99.159:1000/";
        public async Task<object> CurPostRequestAsync(string endpoint, string jsonData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = baseUrl + endpoint;

                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        //return responseContent;
                        dynamic responseData = JsonConvert.DeserializeObject(responseContent);
                        return responseData;
                    }
                    else
                    {
                        throw new Exception("HTTP request failed with status code: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
         
        public async Task<object> CurGetRequestAsync(string method)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = baseUrl + method;
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        dynamic responseData = JsonConvert.DeserializeObject(responseContent);
                        return responseData;
                    }
                    else
                    {
                        return "NO DATA";
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return $"Request Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public async Task<object> CurGetRequestAsync(string url, object data)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //HttpResponseMessage response = await client.GetAsync(url+ data);
                    Uri uri = new Uri(url + data);
                    HttpResponseMessage response = await client.GetAsync(uri);


                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        dynamic responseData = JsonConvert.DeserializeObject(responseContent);
                        // Do something with additionalData here if needed
                        return responseData;
                    }
                    else
                    {
                        return "NO DATA";
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return $"Request Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public Bitmap LoadPicture(string url)
        {
            try
            {
                System.Net.WebRequest request = System.Net.WebRequest.Create(url);
                System.Net.WebResponse response = request.GetResponse();

                System.IO.Stream responseStream = response.GetResponseStream();
                Bitmap bitmap2 = new Bitmap(responseStream);

                return bitmap2;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string GetMacAddress()
        {
            string macAddress = string.Empty;
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                if (networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    macAddress = networkInterface.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return macAddress;
        }

        

    }

    

}



