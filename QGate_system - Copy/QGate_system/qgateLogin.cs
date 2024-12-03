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
        operationData operationData = operationData.Instance;

        qgateSettingPosition formSetting = new qgateSettingPosition();
        qgateSelectMenu formSelectMenu = new qgateSelectMenu();
        QGate_system.API.API api = new QGate_system.API.API();
        qgateAlert formAlret = new qgateAlert();


        qgateScanTag scanTag = new qgateScanTag();


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

                                // insert worker 
                                DateTime dateTime = DateTime.Now;
                                string Datecur;
                                string Datetomor;
                                string Datetimecur;

                                if (dateTime.Hour < 8)
                                {
                                    DateTime previousDay = dateTime.AddDays(-1).Date;

                                    Datecur = previousDay.ToString("yyyy-MM-dd");
                                    Datetomor = dateTime.ToString("yyyy-MM-dd");
                                    Datetimecur = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                                }
                                else
                                {
                                    DateTime previousDay = dateTime.AddDays(+1).Date;

                                    Datecur = dateTime.ToString("yyyy-MM-dd");
                                    Datetomor = previousDay.ToString("yyyy-MM-dd");
                                    Datetimecur = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                                }

                                var dataWorkShoft = new
                                {
                                    Timecurr = Datetimecur,
                                    Datecurr = Datecur,
                                    Datetomor = Datetomor
                                };
                                //MessageBox.Show(data.ToString());

                                var dataJsonWorkShoft = JsonConvert.SerializeObject(dataWorkShoft);
                                dynamic responseDataWorkShoft = await api.CurPostRequestAsync("Operation/get_WorkShoftTime/", dataJsonWorkShoft);

                                if (responseDataWorkShoft.Status == "1")
                                {
                                    var datainsertworker = new
                                    {
                                        Station_Id = LocationData.IdStation,
                                        Date = DateTime.Now.ToString("yyyy-MM-dd"),
                                        Work_shift = responseDataWorkShoft.mws_shift,
                                        Lot = scanTag.genLot(DateTime.Now),
                                        login_user = Session.Userlogin
                                    };

                                    var datainsertworkerJson = JsonConvert.SerializeObject(datainsertworker);
                                    dynamic responsedatainsertworker = await api.CurPostRequestAsync("OperationIns/insert_staff_work/", datainsertworkerJson);

                                    if (responsedatainsertworker.Status == 1)
                                    {
                                        operationData.isdt_id = responsedatainsertworker.isdt_id;
                                        var datainsertworkerDetail = new
                                        {
                                            isdt_id = responsedatainsertworker.isdt_id,
                                            Worker = Session.Userlogin
                                        };

                                        var datainsertworkerrDetailJson = JsonConvert.SerializeObject(datainsertworkerDetail);
                                        dynamic responsedatainsertworkerrDetail = await api.CurPostRequestAsync("OperationIns/insert_staff_work_detail/", datainsertworkerrDetailJson);

                                        if (responsedatainsertworkerrDetail.Status == 0)
                                        {
                                            MessageBox.Show("Error System!!! : insert worker Detail");
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("Error System!!! : insert worker");
                                    }



                                }
                                else
                                {
                                    MessageBox.Show("Error system!!! : Work Shit");
                                }


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

                //Console.WriteLine(macAddress);
                //Console.WriteLine("Login/chk_macAddress/" + dataSetting);


                if (dataSetting.result == 1)
                {
                    LocationData.IdStation = dataSetting.mcd_id;
                    LocationData.Phase = dataSetting.mpa_name;
                    LocationData.Zone = dataSetting.mza_name;
                    LocationData.Station = dataSetting.msa_station;
                    LocationData.Delay = dataSetting.delay;
                }
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
                
            }
        }


    }
}


