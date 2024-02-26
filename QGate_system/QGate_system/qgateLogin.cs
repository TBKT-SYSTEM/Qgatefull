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
using Newtonsoft.Json.Linq;

namespace QGate_system
{
    public partial class qgateLogin : Form
    {
        Session Session = Session.Instance;
        model Model = model.Instance;
        LocationData LocationData =  LocationData.Instance;

        qgateSettingPosition formSetting = new qgateSettingPosition();
        qgateSelectMenu formSelectMenu = new qgateSelectMenu();
        QGate_system.API.API api = new QGate_system.API.API();
        qgateAlert formAlret = new qgateAlert();


        operationData operationData = operationData.Instance;



        dynamic dataSetting;
        //dynamic dataPartNo;

        public string macAddress;

        public qgateLogin()
        {
            InitializeComponent();
            macAddress = api.GetMacAddress();
        }

        private void lbexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbConfig_Click(object sender, EventArgs e)
        {
            qgateLoginAdmin formLoginAdmin = new qgateLoginAdmin();
            formLoginAdmin.Show();
            
            this.Hide();
        }
        private async void tbLoginUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (dataSetting.mad_alias == "success")
                    {
                        string EmpCode = tbLoginUser.Text;
                        var dataEmpCode = new
                        {
                            EmpCode = EmpCode
                        };

                        var jsonDataEmpCode = JsonConvert.SerializeObject(dataEmpCode);
                        dynamic dataChkLogin = await api.CurPostRequestAsync("Login/chk_login/", jsonDataEmpCode);

                        // chk login
                        if (dataChkLogin != null )
                        //if (dataChkLogin.status == 1) 
                        {
                            //dynamic dataChkLogin = JsonConvert.DeserializeObject(resultResponseChkLogin);

                            if (dataChkLogin.mad_alias == "success-login")
                            {
                                // set session
                                Session.PermisLogin = dataChkLogin.data;
                                Session.Loglogin = dataChkLogin.log_Login;
                                Session.Userlogin = dataChkLogin.emp_code;

                                var dataUserLogin = new
                                {
                                    PathPic = "http://192.168.161.207/tbkk_shopfloor/asset/img_emp/"+ dataChkLogin.emp_code +".jpg",
                                    EmpCode = dataChkLogin.emp_code,
                                    NameUser = dataChkLogin.emp_name
                                };

                                formSelectMenu.UserLogin = dataUserLogin;
                                formSelectMenu.Show();

                                this.Hide();
                            }
                            else if (dataChkLogin.result == 0)
                            {
                                MessageBox.Show("The system has a problem");
                            }
                            else
                            {
                                string pathPic = dataChkLogin.mat_path;

                                formAlret.MessageRequert = dataChkLogin.message;
                                formAlret.PathPicRequert = api.LoadPicture(pathPic);

                                formAlret.ShowDialog();
                                tbLoginUser.Clear();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Empty or invalid response");
                        }
                    }
                    else if (dataSetting.result == 0)
                    {
                        MessageBox.Show("The system has a problem");
                    }
                    else
                    {
                        string pathPic = dataSetting.mat_path;

                        formAlret.MessageRequert = dataSetting.message;
                        formAlret.PathPicRequert = api.LoadPicture(pathPic);

                        formAlret.ShowDialog();
                        tbLoginUser.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void qgateLogin_Load(object sender, EventArgs e)
        {
            try
            {
                var data = new
                {
                    macAddress = macAddress
                };

                var jsonData = JsonConvert.SerializeObject(data);
                dataSetting = await api.CurPostRequestAsync("Login/chk_macAddress/", jsonData);

                LocationData.IdStation = dataSetting.mcd_id;
                LocationData.Phase = dataSetting.mpa_name;
                LocationData.Zone = dataSetting.mza_name;
                LocationData.Station = dataSetting.msa_station;
                LocationData.Delay = dataSetting.delay;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }


    }
}


