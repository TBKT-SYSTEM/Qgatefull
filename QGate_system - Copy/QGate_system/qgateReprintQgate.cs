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


            //ปิดการตรวจสอบเหตุการณ์ SelectedIndexChanged (มีการ SelectedIndex ทำให้ ฟังชั่นทำงาน เลยต้องปิด)
            cbDate.SelectedIndexChanged -= cbDate_SelectedIndexChanged;
            cbPartNo.SelectedIndexChanged -= cbPartNo_SelectedIndexChanged;
            cbLotNo.SelectedIndexChanged -= cbLotNo_SelectedIndexChanged;


            await setComboBox();


            // เปิดการตรวจสอบเหตุการณ์ SelectedIndexChanged 
            cbDate.SelectedIndexChanged += cbDate_SelectedIndexChanged;
            cbPartNo.SelectedIndexChanged += cbPartNo_SelectedIndexChanged;
            cbLotNo.SelectedIndexChanged += cbLotNo_SelectedIndexChanged;

        }

        private async Task setComboBox()
        {
            qgateScanTag scanTag = new qgateScanTag();
            try
            {
                cbDate.Items.Add("Choose Date");
                cbDate.SelectedIndex = 0;
                for (int i = 0; i < 3; i++)
                {
                    DateTime currentDate = DateTime.Now.AddDays(-i);
                    string formattedDate = currentDate.ToString("yyyy-MM-dd");
                    cbDate.Items.Add(formattedDate);
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

                // กำหนด MINDate เป็นวันที่ปัจจุบันลบด้วย 3 วัน
                //dateTimePicker1.MinDate = DateTime.Now.AddDays(-2);
                // กำหนด MAXDate เป็นวันที่ปัจจุบัน
                //dateTimePicker1.MaxDate = DateTime.Now;
                
                
                cbLotNo.Items.Add("Choose LotNo");
                cbLotNo.SelectedIndex = 0;
                for (int i = 0; i < 3; i++)
                {
                    cbLotNo.Items.Add(scanTag.genLot(DateTime.Now.AddDays(-i)));
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
            //ปิดการตรวจสอบเหตุการณ์ SelectedIndexChanged (มีการ SelectedIndex ทำให้ ฟังชั่นทำงาน เลยต้องปิด)
            cbDate.SelectedIndexChanged -= cbDate_SelectedIndexChanged;
            cbPartNo.SelectedIndexChanged -= cbPartNo_SelectedIndexChanged;
            cbLotNo.SelectedIndexChanged -= cbLotNo_SelectedIndexChanged;

            cbDate.SelectedIndex = 0;
            cbPartNo.SelectedIndex = 0;
            cbLotNo.SelectedIndex = 0; 

            lvDetail.Items.Clear();

            // เปิดการตรวจสอบเหตุการณ์ SelectedIndexChanged 
            cbDate.SelectedIndexChanged += cbDate_SelectedIndexChanged;
            cbPartNo.SelectedIndexChanged += cbPartNo_SelectedIndexChanged;
            cbLotNo.SelectedIndexChanged += cbLotNo_SelectedIndexChanged;
        }

        private void pbPrint_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = lvDetail.SelectedItems;
            string IdTagQgate = null;

            foreach (ListViewItem selectedItem in selectedItems)
            {
                IdTagQgate = selectedItem.SubItems[0].Text;
            }


            if (IdTagQgate != null)
            {
                MessageBox.Show("id" + IdTagQgate);

                reprintTagQgate(IdTagQgate);
            }
            else
            {
                MessageBox.Show("กรุณาดลือก Tag ที่จะ Reprint ก่อน");
            }
            

        }

        private void cbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDataQgate();
        }

        private void cbPartNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDataQgate();
            //MessageBox.Show("ข้อความที่เลือก cbPartNo : " + cbPartNo.SelectedItem);
        }

        private void cbLotNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDataQgate();
            //MessageBox.Show("ข้อความที่เลือก cbLotNo : " + cbLotNo.SelectedItem); 
        }

        private async void getDataQgate()
        {
            try
            {
                lvDetail.Items.Clear();
                string selectedDate = cbDate.SelectedItem.ToString();
                Console.WriteLine("ข้อความที่เลือก cbDate : " + selectedDate);

                string selectedPartNo = cbPartNo.SelectedItem.ToString();
                Console.WriteLine("ข้อความที่เลือก cbPartNo : " + selectedPartNo);

                string selectedLotNo = cbLotNo.SelectedItem.ToString();
                Console.WriteLine("ข้อความที่เลือก cbLotNo : " + selectedLotNo);


                if (selectedDate.Contains("Choose"))
                {
                    selectedDate = "null";
                }
                if (selectedPartNo.Contains("Choose"))
                {
                    selectedPartNo = "null";
                }
                if (selectedLotNo.Contains("Choose"))
                {
                    selectedLotNo = "null";
                }

                var dataGetReprintQgate = new
                {
                    Date = selectedDate,
                    PartNo = selectedPartNo,
                    LotNo = selectedLotNo
                };

                //Console.WriteLine(dataGetReprintQgate);

                var dataGetReprintQgatejson = JsonConvert.SerializeObject(dataGetReprintQgate);
                dynamic responsedataGetReprintQgate = await api.CurPostRequestAsync("ReprintQgate/get_DataListviewReprintQgate/", dataGetReprintQgatejson);

                Console.WriteLine(responsedataGetReprintQgate);
                if (responsedataGetReprintQgate.Status == 1)
                {
                    Console.WriteLine("responsedataGetReprintQgate : " + responsedataGetReprintQgate.data);

                    foreach (var data in responsedataGetReprintQgate.data)
                    {
                        string subStrLotAndBox = data.SubPartNoAndLotNo.ToString();
                        Console.WriteLine(subStrLotAndBox.Length);
                        string[] datadetail = { data.Id, subStrLotAndBox.Substring(19, 25).Trim(), subStrLotAndBox.Substring(58, 4).Trim(), subStrLotAndBox.Substring(100, 3).Trim() };
                        ListViewItem items = new ListViewItem(datadetail);
                        lvDetail.Items.Add(items);
                    }
                }
                else
                {
                    Console.WriteLine(responsedataGetReprintQgate);
                    Console.WriteLine("Error System : Get Data Reprint Qgate(listview)");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private async void reprintTagQgate(string IdTagQgate) 
        {
            try
            {
                var dataGetReprintQgate = new
                {
                    IdTagQgate = IdTagQgate
                };

                var dataGetReprintQgatejson = JsonConvert.SerializeObject(dataGetReprintQgate);
                dynamic responsedataGetReprintQgate = await api.CurPostRequestAsync("ReprintQgate/get_DataReprintQgate/", dataGetReprintQgatejson);


                Console.WriteLine("responsedataGetReprintQgate : " + responsedataGetReprintQgate);

                if (responsedataGetReprintQgate.Status == 1)
                {
                    //MessageBox.Show("Getdata ok");

                    string tagQgate = null;
                    string partNo = null;
                    string partNoName = null;
                    string model = null;
                    string boxNo = null;
                    string qrProduct = null;
                    string location = null;
                    string qty = null;
                    string lotNo = null;
                    string shift = null;
                    string line = null;
                    string phase = null;
                    string checkDate = null;


                    foreach (var item in responsedataGetReprintQgate.data)
                    {
                        tagQgate = item.iotc_tag_qgate;
                        qrProduct = item.iotc_qgate_qr;
                    }

                    line = tagQgate.Substring(2, 6).Trim();
                    phase = (tagQgate.Substring(2, 2).Trim() == "K1") ? "10" : "8";
                    lotNo = tagQgate.Substring(58, 4).Trim();
                    partNo = tagQgate.Substring(19, 25);
                    boxNo = tagQgate.Substring(100, 3).Trim();
                    qty = tagQgate.Substring(52, 6).Trim();

                    //Console.WriteLine("tagQgate" + tagQgate);

                    var data = new
                    {
                        partNo = tagQgate.Substring(19, 25).Trim(),
                        line_cd = tagQgate.Substring(2, 6).Trim()
                    };
                    var dataJson = JsonConvert.SerializeObject(data);
                    dynamic responseData = await api.CurPostRequestAsync("Operation/get_model_partNo/", dataJson);

                    if (responseData.Status == 1)
                    {
                        partNoName = responseData.PartName;
                        model = responseData.MODEL;
                    }

                    string parameter = $"?partNumber={tagQgate.Substring(19, 25).Trim()}";
                    dynamic resultLOCATION = await api.CurGetRequestAsync("http://192.168.161.77/apiSystem/exp/getItemMaster", parameter);

                    foreach (var itemLOCATION in resultLOCATION)
                    {
                        location = itemLOCATION.LOCATION;
                    }

                    var datatag = new
                    {
                        TagQgate = tagQgate
                    };

                    var datadatatagjson = JsonConvert.SerializeObject(datatag);
                    dynamic represponsedatadatatag = await api.CurPostRequestAsync("ReprintQgate/get_DataScanReprint/", datadatatagjson);

                    Console.WriteLine("represponsedatadatatag" + represponsedatadatatag);

                    if (represponsedatadatatag.Status == 1)
                    {
                        shift = represponsedatadatatag.shift;
                        checkDate = represponsedatadatatag.checkDate;
                    }

                    PrintTag printTag = new PrintTag();
                    printTag.printTagQgate(" ", partNo, partNoName, model, " ", boxNo, DateTime.Parse(checkDate), tagQgate, qrProduct, location, qty, lotNo, shift, line, phase);
                    
                }
                else
                {
                    MessageBox.Show("Error System : Getdata Reprint");
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
