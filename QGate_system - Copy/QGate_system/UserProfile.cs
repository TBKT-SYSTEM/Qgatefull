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
        qgateSelectMenu formSelectMenu = qgateSelectMenu.instance;

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

                if (EmpCode == formSelectMenu.userSelected)
                {
                    this.BackColor = SystemColors.GradientActiveCaption;
                }

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
                //pbImgUser.ImageLocation = "https://intranet.tbkk.co.th/employee/img/TBKK/"+ _empCode+".jpg";
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

        private void pbImgUser_Click(object sender, EventArgs e)
        {
            if (formSelectMenu.userSelected == EmpCode)
            {
                formSelectMenu.userSelected = null;

                qgateSelectMenu.instance.flpUserInstance.Controls.Clear();
                UserProfile[] listItems = new UserProfile[memberData.memberList.Count];

                for (int i = 0; i < listItems.Length; i++)
                {
                    string url = $"http://192.168.161.207/tbkk_shopfloor/asset/img_emp/{memberData.memberList[i][0]}.jpg";

                    listItems[i] = new UserProfile();
                    listItems[i].PathPic = url;
                    listItems[i].EmpCode = memberData.memberList[i][0];
                    listItems[i].NameUser = memberData.memberList[i][1];

                    qgateSelectMenu.instance.flpUserInstance.Controls.Add(listItems[i]);
                }
            }
            else
            {
                formSelectMenu.userSelected = EmpCode;

                qgateSelectMenu.instance.flpUserInstance.Controls.Clear();
                UserProfile[] listItems = new UserProfile[memberData.memberList.Count];

                for (int i = 0; i < listItems.Length; i++)
                {
                    string url = $"http://192.168.161.207/tbkk_shopfloor/asset/img_emp/{memberData.memberList[i][0]}.jpg";

                    listItems[i] = new UserProfile();
                    listItems[i].PathPic = url;
                    listItems[i].EmpCode = memberData.memberList[i][0];
                    listItems[i].NameUser = memberData.memberList[i][1];

                    qgateSelectMenu.instance.flpUserInstance.Controls.Add(listItems[i]);
                }
            }


            


            //MessageBox.Show(EmpCode);

        }
        



    }
}
