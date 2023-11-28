using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QGate_system
{
    public partial class qgateLoginAdmin : Form
    {
        QGate_system.API.Session Session = QGate_system.API.Session.Instance;
        QGate_system.API.API api = new QGate_system.API.API();
        qgateAlert formAlret = new qgateAlert();

        public qgateLoginAdmin()
        {
            InitializeComponent();
        }
        private  void pbBackToLogin_Click(object sender, EventArgs e)
        {
            qgateLogin formLogin = new qgateLogin();
            formLogin.Show();

            this.Hide();
        }

        private async void tbLoginAdmin_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                model myModel = model.Instance;
                

                string EmpCode = tbLoginAdmin.Text;
                try
                {
                    var data = new
                    {
                        EmpCode = EmpCode
                    };

                    var jsonData = JsonConvert.SerializeObject(data);
                    var resultReponse = await api.CurPostRequestAsync("MenuAdmin/chk_loginAdmin/", jsonData);


                   if (!string.IsNullOrEmpty(resultReponse))
                   {
                        dynamic dataReponse = JsonConvert.DeserializeObject(resultReponse);

                        if (dataReponse.mad_alias == "success-login")
                        {

                            Session.LogloginAdmin = dataReponse.log_Login;
                            //MessageBox.Show(dataReponse.log_Login.ToString());

                            Session.CurrentAdmin  = EmpCode;
                            qgateMenuAdmin formMenuAdmin = new qgateMenuAdmin();
                            formMenuAdmin.Show();

                            this.Hide();
                        }
                        else if (dataReponse.result == 0)
                        {
                            MessageBox.Show("The system has a problem");
                        }
                        else
                        {
                            string pathPic = dataReponse.mat_path;

                            formAlret.MessageRequert = dataReponse.message;
                            formAlret.PathPicRequert = api.LoadPicture(pathPic);

                            formAlret.ShowDialog();
                        }
                   }
                   else
                   {
                        MessageBox.Show("Empty or invalid response");
                   }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                tbLoginAdmin.Clear();
            }
            else { }
        }

    }
}