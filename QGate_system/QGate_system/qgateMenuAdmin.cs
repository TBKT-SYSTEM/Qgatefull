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
            var reponseResult = await api.CurGetRequestAsync("MenuAdmin/get_MenuAdmin/");
            dynamic dataReponse = JsonConvert.DeserializeObject(reponseResult);

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

        private void lbLogout_Click(object sender, EventArgs e)
        {
            qgateLoginAdmin formLoginMenu = new qgateLoginAdmin();
            formLoginMenu.Show();

            this.Hide();
        }
    }
}