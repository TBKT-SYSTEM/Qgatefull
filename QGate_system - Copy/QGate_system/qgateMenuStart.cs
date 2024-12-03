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
    public partial class qgateMenuStart: Form
    {
        QGate_system.API.API api = new QGate_system.API.API();
        operationData operationData = operationData.Instance;
        qgateAlert formAlret = new qgateAlert();


        public Boolean Status_DMC;
        public Boolean Status_NonDMC;
        public string macAddress;

        public qgateMenuStart()
        {
            InitializeComponent();
            macAddress = api.GetMacAddress();
        }

        private void lbBackToMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void lbDMC_Click(object sender, EventArgs e)
        {
            if (Status_DMC)
            {
                operationData.typeStation = "DMC";
                qgateScanTag formScanTag = new qgateScanTag();
                formScanTag.Show();

                this.Hide();
            }
            else
            {
                dynamic dataPartpic = await api.CurGetRequestAsync("MstPathPic/get_PathPic_Error/");

                string pathPic = dataPartpic.Path;

                formAlret.MessageRequert = "This DMC is disabled.";
                formAlret.PathPicRequert = api.LoadPicture(pathPic);

                formAlret.ShowDialog();
            }
        }

        private async void lbNonDMC_Click(object sender, EventArgs e)
        {
            if (Status_NonDMC)
            {
                operationData.typeStation = "Manual";
                qgateScanTag formScanTag = new qgateScanTag();
                formScanTag.Show();

                this.Hide();
            }
            else
            {
                dynamic dataPartpic = await api.CurGetRequestAsync("MstPathPic/get_PathPic_Error/");

                string pathPic = dataPartpic.Path;

                formAlret.MessageRequert = "This Non DMC is disabled.";
                formAlret.PathPicRequert = api.LoadPicture(pathPic);

                formAlret.ShowDialog();
            }
        }

        private async void qgateMenuStart_Load(object sender, EventArgs e)
        {
            dynamic dataPartNO = await api.CurGetRequestAsync("Operation/type_station/");

            foreach (var row in dataPartNO.type_station)
            {
                Status_DMC = (row.mct_name == "DMC" && row.mct_status == 1) ? true : Status_DMC;
                Status_NonDMC = (row.mct_name == "Manual" && row.mct_status == 1) ? true : Status_NonDMC;

            }
            //Console.WriteLine(dataPartNO);
        }
    }
}
