using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace QGate_system
{
    public partial class qgateAddUser : Form
    {
        QGate_system.API.API api = new QGate_system.API.API();
        qgateAlert formAlret = new qgateAlert();
        memberData memberData = new memberData();

        public qgateAddUser()
        {
            InitializeComponent();
        }

        private async void pbAddUser_Click(object sender, EventArgs e)
        {
            var data = new
            {
                EmpCode = tbAddUser.Text
            };

            var jsonDataPermis = JsonConvert.SerializeObject(data);
            dynamic resultResponse = await api.CurPostRequestAsync("Login/chk_login/", jsonDataPermis);
            

            if (resultResponse != null)
            {
                //dynamic dataUserResponse = JsonConvert.DeserializeObject(resultResponse);

                if (resultResponse.mad_alias == "success-login")
                {
                    var dataUserLogin = new
                    {
                        PathPic = "http://192.168.161.207/tbkk_shopfloor/asset/img_emp/" + resultResponse.emp_code + ".jpg",
                        EmpCode = resultResponse.emp_code,
                        NameUser = resultResponse.emp_name
                    };
                    string emp_code = resultResponse.emp_code;

                    if (memberData.chk_RepeatMember(emp_code))
                    {
                        dynamic result = await api.CurGetRequestAsync("Login/get_PathPic/");
                        dynamic pathPicWraing = JsonConvert.DeserializeObject(result);
                        string pathPic_Warning = pathPicWraing.Path;

                        formAlret.MessageRequert = "You've scanned your employees.";
                        formAlret.PathPicRequert = api.LoadPicture(pathPic_Warning);
                        formAlret.ShowDialog();
                    }
                    else
                    {
                        var memberArr = new string[2] { resultResponse.emp_code, resultResponse.emp_name };

                        memberData.memberList.Add(memberArr);
                        memberData.populateItems();
                    }
                    
                    tbAddUser.Clear();
                    this.Hide();
                }
                else if (resultResponse.result == 0)
                {
                    MessageBox.Show("The system has a problem");
                }
                else
                {
                    string pathPic = resultResponse.mat_path;

                    formAlret.MessageRequert = resultResponse.message;
                    formAlret.PathPicRequert = api.LoadPicture(pathPic);
                    formAlret.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Empty or invalid response");
            }
            tbAddUser.Clear();
        }

        private void pbCancelAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}


