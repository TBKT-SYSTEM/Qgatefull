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
    public partial class qgateReprintQgate : Form
    {
        LocationData LocationData = LocationData.Instance;
        Session Session = Session.Instance;
        QGate_system.API.API api = new QGate_system.API.API();



        public qgateReprintQgate()
        {
            InitializeComponent();
        }

        private async void qgateReprintQgate_Load(object sender, EventArgs e)
        {
            lbZone.Text = LocationData.Zone;
            lbStation.Text = LocationData.Station;

            await setComboBox();



        }

        

        private async Task setComboBox()
        {
            qgateScanTag ScanTag = new qgateScanTag();
            try
            {
                var datagetdate = new
                {
                    StationId = LocationData.IdStation
                };

                var datagetdateJson = JsonConvert.SerializeObject(datagetdate);
                dynamic responseDataGetDate = await api.CurPostRequestAsync("ReprintQgate/getDate/", datagetdateJson);

                PhaseItem item_date = new PhaseItem(Convert.ToInt32(0), "Choose Date");
                cbDate.Items.Add(item_date);
                cbDate.SelectedIndex = 0;

                foreach (var item in responseDataGetDate.data)
                {
                    Console.WriteLine(item);
                    cbDate.Items.Add(item);

                    // add item ComboBox PartNo
                    cbLotNo.Items.Add(ScanTag.genLot(item));



                }

                var dataGetPartNo = new
                {
                    macAddress = api.GetMacAddress()
                };

                var dataGetPartNojson = JsonConvert.SerializeObject(dataGetPartNo);
                dynamic responsdataGetPartNo = await api.CurPostRequestAsync("Operation/get_part/", dataGetPartNojson);
                string jsonData = responsdataGetPartNo.selectPartNo.ToString();
                List<PartNOItem> data = JsonConvert.DeserializeObject<List<PartNOItem>>(jsonData);

                PhaseItem item_partNo = new PhaseItem(Convert.ToInt32(0), "Choose PartNo");
                cbPartNo.Items.Add(item_partNo);
                cbPartNo.SelectedIndex = 0;

                foreach (PartNOItem item in data)
                {
                    cbPartNo.Items.Add(new PartNOItem(item.msp_id, item.msp_part_no));
                }

               

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }


        }

        private void pbBackReprintToMenu_Click(object sender, EventArgs e)
        {
            qgateMenuReprintTag formMenuReprint = new qgateMenuReprintTag();
            formMenuReprint.Show();

            this.Hide();
        }

        private void pbScanPrint_Click(object sender, EventArgs e)
        {
            qgateReprintQgateScanPrint formReprintQgateScanprint = new qgateReprintQgateScanPrint();
            formReprintQgateScanprint.Show();

            this.Hide();
        }

        private void pbClear_Click(object sender, EventArgs e)
        {

        }

        private void pbPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
