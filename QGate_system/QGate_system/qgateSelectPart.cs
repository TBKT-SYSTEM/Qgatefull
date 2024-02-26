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
    public partial class qgateSelectPart : Form
    {
        LocationData LocationData = LocationData.Instance;
        Session Session = Session.Instance;
        QGate_system.API.API api = new QGate_system.API.API();

        public qgateSelectPart()
        {
            InitializeComponent();
        }

        private void qgateSelectPart_Load(object sender, EventArgs e)
        { 
            string jsonData = LocationData.selectPartNo.ToString();
            //Console.WriteLine(jsonData);
            List <PartNOItem> data1 = JsonConvert.DeserializeObject<List<PartNOItem>>(jsonData);
            foreach (PartNOItem item in data1)
            {
                cbSelectPart.Items.Add(new PartNOItem(item.msp_id, item.msp_part_no));
                //Console.WriteLine($"Part No ID : {item.msp_id} , Part No : {item.msp_part_no}");
            }

            lbZone.Text = LocationData.Zone;
            lbStation.Text = LocationData.Station;


            // selected partno
            PartNOItem selectedItem = cbSelectPart.Items.Cast<PartNOItem>().FirstOrDefault(item => item.msp_id == LocationData.PartNoID);
            if (selectedItem != null)
            {
                cbSelectPart.SelectedItem = selectedItem;
            }



            /*try
            {
                var data = new
                {
                    StationId = LocationData.IdStation,
                };

                var dataJson = JsonConvert.SerializeObject(data);
                dynamic responseData = await api.CurPostRequestAsync("OperationUpdate/update_partNo_station/", dataJson);

                if (responseData.Status == 1)
                {
                    cbSelectPart.SelectedItem = responseData;
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }*/

        }

        private void lb_CancelPart_Click(object sender, EventArgs e)
        {
            qgateScanTag formScanTag = new qgateScanTag();
            formScanTag.Show();

            this.Hide();
        }

        private async void lb_Confirm_Click(object sender, EventArgs e)
        {
            PartNOItem select = (PartNOItem)cbSelectPart.SelectedItem;
            Console.WriteLine("Part no :" + select.msp_id);
            //this.Hide();

            var data = new
            {
                StationId = LocationData.IdStation,
                NewPartNo = select.msp_part_no,
                login_user = Session.Userlogin

            };

            var dataJson = JsonConvert.SerializeObject(data);
            dynamic responseData = await api.CurPostRequestAsync("OperationUpdate/update_partNo_station/", dataJson);
            /**/

            if (responseData.Status == 1)
            {
                //await Task.Delay(2000);
                qgateScanTag ScanTag = new qgateScanTag();
                ScanTag.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Error System : Fail Save PartNo");
            }


            //MessageBox.Show(responseData.ToString());

        }

        private void cbTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PartNOItem select = (PartNOItem)cbSelectPart.SelectedItem;
                Console.WriteLine("chang combobox :" + select.msp_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }

    //add value combobox
    public class PartNOItem
    {
        public int msp_id { get; set; }
        public string msp_part_no { get; set; }
        public PartNOItem(int id, string name)
        {
            msp_id = id;
            msp_part_no = name;
        }
        public override string ToString()
        {
            return $"{msp_part_no}";
        }
    }


    /* */

     //get value combobox
   /**/


    /* set value combobox
    string jsonData = myModel.DataPartNo.ToString();
    List<PartNOItem> data1 = JsonConvert.DeserializeObject<List<PartNOItem>>(jsonData);
    foreach (PartNOItem item in data1)
    {
        cbTest.Items.Add(new PartNOItem(item.mcd_id, item.mcd_select_part));
    }
    ///////////

    string jsonData = myModel.DataPartNo.ToString();
    List<PartNOItem> data1 = JsonConvert.DeserializeObject<List<PartNOItem>>(jsonData);
    cbTest.Items.AddRange(data1.Select(item => new PartNOItem(item.mcd_id, item.mcd_select_part)).ToArray());*/


}
