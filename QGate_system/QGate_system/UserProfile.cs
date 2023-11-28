using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace QGate_system
{
    public partial class UserProfile : UserControl
    {
        public UserProfile()
        {
            InitializeComponent();
        }

        private string _pathPic;
        public string PathPic
        {
            get { return _pathPic; }
            set { 
                _pathPic = value;
                _ = SetImageLocationAsync(_pathPic);
            }
        }

        private string _empCode;
        public string EmpCode
        {
            get { return _empCode; }
            set { 
                _empCode = value;
                lbEmpCode.Text = _empCode;
            }
        }

        private string _nameUser;
        public string NameUser
        {
            get { return _nameUser; }
            set { 
                _nameUser = value;
                lbNameUser.Text = _nameUser;


            }
        }




        public async Task SetImageLocationAsync(string path)
        {
            bool doesImageExist = await ImageExistsAsync(path);

            if (doesImageExist)
            {
                pbImgUser.ImageLocation = path;
            }
            else
            {
                pbImgUser.ImageLocation = "http://192.168.161.77/qgate_pic/user.png";
            }
        }

        private async Task<bool> ImageExistsAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    return response.IsSuccessStatusCode;
                }
                catch (HttpRequestException)
                {
                    return false;
                }
            }
        }

    }
}
