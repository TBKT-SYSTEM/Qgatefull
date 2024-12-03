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
    public partial class qgateMenuAdmin : Form
    {
        QGate_system.API.API api = new QGate_system.API.API();
        Session Session = Session.Instance;

        public qgateMenuAdmin()
        {
            InitializeComponent();
        }
        private void qgateMenuAdmin_Load(object sender, EventArgs e)
        {
            this.plusMenuAdmin();
        }
        
        private async void plusMenuAdmin()
        {
            dynamic dataReponse = await api.CurGetRequestAsync("MenuAdmin/get_MenuAdmin/");
            //dynamic dataReponse = JsonConvert.DeserializeObject(reponseResult);

            adminMenu[] userCtrl = new adminMenu[dataReponse.data.Count];
            for (int i = 0 ; i < userCtrl.Length ; i++)
            {
                userCtrl[i] = new adminMenu();
                userCtrl[i].Path = dataReponse["data"][i]["sma_path"];
                userCtrl[i].PicterName = dataReponse["data"][i]["sma_path"] + dataReponse["data"][i]["sma_pic"];
                userCtrl[i].FormName = dataReponse["data"][i]["sma_routing"];

                userCtrl[i].addAction();
                flpAdminMenu.Controls.Add(userCtrl[i]);
            }
        }

        private async void lbLogout_Click(object sender, EventArgs e)
        {
            var data = new
            {
                logLogin_id = Session.LogloginAdmin
            };

            var jsonData = JsonConvert.SerializeObject(data);
            var resultReponse = await api.CurPostRequestAsync("MenuAdmin/logout_Admin/", jsonData);

            qgateLoginAdmin formLoginMenu = new qgateLoginAdmin();
            formLoginMenu.Show();

            this.Hide();
        }
    }
}