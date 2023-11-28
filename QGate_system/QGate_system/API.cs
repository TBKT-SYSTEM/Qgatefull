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
        public static string baseUrl = "http://192.168.161.77:8999/";
        public async Task<string> CurPostRequestAsync(string endpoint, string jsonData)
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
                        return responseContent;
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
         
        public async Task<string> CurGetRequestAsync(string method)
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
                        return responseContent;
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

    public class Session
    {
        private static Session instance;

        //Login Admin
        public string CurrentAdmin { get; set; }
        public int LogloginAdmin { get; set; }


        //Login
        public string PermisLogin { get; set; }
        public int Loglogin { get; set; }

        private Session() { }
        public static Session Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Session();
                }
                return instance;
            }
        }
    }

}



