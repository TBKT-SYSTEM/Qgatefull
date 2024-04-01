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
    public partial class qgateReprintDefect : Form
    {
        LocationData LocationData = LocationData.Instance;
        Session Session = Session.Instance;
        QGate_system.API.API api = new QGate_system.API.API();

        public qgateReprintDefect()
        {
            InitializeComponent();
        }

        private async void qgateReprintDefect_Load(object sender, EventArgs e)
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
                // set combobox Date
                cbDate.Items.Add("Choose Date");
                cbDate.SelectedIndex = 0;
                for (int i = 0; i < 3; i++)
                {
                    DateTime currentDate = DateTime.Now.AddDays(-i);
                    string formattedDate = currentDate.ToString("yyyy-MM-dd");
                    cbDate.Items.Add(formattedDate);
                }


                // set combobox Part No
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


                // set combobox Lotno
                cbLotNo.Items.Add("Choose LotNo");
                cbLotNo.SelectedIndex = 0;
                for (int i = 0; i < 3; i++)
                {
                    cbLotNo.Items.Add(scanTag.genLot(DateTime.Now.AddDays(-i)));
                }


                // set combobox Date
                cbTypeDefect.Items.Add("Choose TypeDefect");
                cbTypeDefect.SelectedIndex = 0;
                cbTypeDefect.Items.Add("NC");
                cbTypeDefect.Items.Add("NG");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }

        }

        private void cbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDataTagDefect();
        }

        private void cbPartNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDataTagDefect();
            //MessageBox.Show("ข้อความที่เลือก cbPartNo : " + cbPartNo.SelectedItem);
        }

        private void cbLotNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDataTagDefect();
            //MessageBox.Show("ข้อความที่เลือก cbLotNo : " + cbLotNo.SelectedItem); 
        }

        private void cbTypeDefect_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDataTagDefect();
        }


        private void pbScanPrint_Click(object sender, EventArgs e)
        {
            qgateReprintDefectScanPrint formReprintDefectScanprint = new qgateReprintDefectScanPrint();
            formReprintDefectScanprint.Show();

            this.Hide();
        }

        private void pbBackReprintToMenu_Click(object sender, EventArgs e)
        {
            qgateMenuReprintTag formMenuReprint = new qgateMenuReprintTag();
            formMenuReprint.Show();

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
            string IdTagDefect = null;

            foreach (ListViewItem selectedItem in selectedItems)
            {
                IdTagDefect = selectedItem.SubItems[0].Text;
            }


            if (IdTagDefect != null)
            {
                MessageBox.Show("id" + IdTagDefect);

                reprintTagDefect(IdTagDefect);
            }
            else
            {
                MessageBox.Show("กรุณาดลือก Tag ที่จะ Reprint ก่อน");
            }
        }

        private async void getDataTagDefect()
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

                string selectedtypeDefect = cbLotNo.SelectedItem.ToString();
                Console.WriteLine("ข้อความที่เลือก typeDefect : " + selectedtypeDefect);


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
                if (selectedtypeDefect.Contains("Choose"))
                {
                    selectedtypeDefect = "null";
                }

                var dataGetReprintDefect = new
                {
                    Date = selectedDate,
                    PartNo = selectedPartNo,
                    LotNo = selectedLotNo,
                    TypeDefect = selectedtypeDefect
                };

                //Console.WriteLine(dataGetReprintDefect);

                var dataGetReprintDefectjson = JsonConvert.SerializeObject(dataGetReprintDefect);
                dynamic responsedataGetReprintDefect = await api.CurPostRequestAsync("ReprintDefect/get_DataListviewReprintDefect/", dataGetReprintDefectjson);

                //Console.WriteLine(responsedataGetReprintDefect);
                if (responsedataGetReprintDefect.Status == 1)
                {
                    Console.WriteLine("responsedataGetReprintDefect : " + responsedataGetReprintDefect.data);

                    foreach (var data in responsedataGetReprintDefect.data)
                    {
                        string subStrLotAndBox = data.SubPartNoAndLotNo.ToString();
                        Console.WriteLine(subStrLotAndBox.Length);
                        string[] datadetail = { data.Id, subStrLotAndBox.Substring(45), subStrLotAndBox.Substring(27, 4), subStrLotAndBox.Substring(35, 3) };
                        ListViewItem items = new ListViewItem(datadetail);
                        lvDetail.Items.Add(items);
                    }

                }
                else
                {
                    
                    Console.WriteLine("Error System : Get Data Reprint Defect(listview)");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }

        }

        private async void reprintTagDefect(string IdTagDefect)
        {
            try
            {
                var dataGetReprintDefect = new
                {
                    IdTagDefect = IdTagDefect
                };

                var dataGetReprintDefectson = JsonConvert.SerializeObject(dataGetReprintDefect);
                dynamic responsedataGetReprintDefect = await api.CurPostRequestAsync("ReprintDefect/get_DataReprintDefect/", dataGetReprintDefectson);

                Console.WriteLine("responsedataGetReprintDefect : " + responsedataGetReprintDefect);

                if (responsedataGetReprintDefect.Status == 1)
                {
                    MessageBox.Show("Getdata ok");

                    string tagDefect = null;
                    string qrDefectDetail = null;
                    string typeDefect = null;
                    string box = null;
                    string location = null;
                    string qty = null;
                    string partNo = null;
                    string partNoName = null;
                    string model = null;
                    string line = null;
                    string workshift = null;
                    string date = null;
                    string Phase = null;


                    foreach (var item in responsedataGetReprintDefect.data)
                    {
                        tagDefect = item.SubPartNoAndLotNo;
                        qrDefectDetail = item.iptd_defect_qr;
                        date = item.checkDate;
                    }

                    typeDefect = (tagDefect.Substring(2, 2).Trim() == "1") ? "NG" : "NC";
                    box = tagDefect.Substring(35, 3).Trim();
                    qty = tagDefect.Substring(38, 5).Trim();
                    partNo = tagDefect.Substring(45).Trim();
                    line = tagDefect.Substring(5, 6).Trim();
                    Phase = (tagDefect.Substring(5, 2).Trim() == "K1") ? "Phase 10" : "Phase 8";


                    string parameter = $"?partNumber={tagDefect.Substring(19, 25).Trim()}";
                    dynamic resultLOCATION = await api.CurGetRequestAsync("http://192.168.161.77/apiSystem/exp/getItemMaster", parameter);

                    if (resultLOCATION != null)
                    {
                        foreach (var itemLOCATION in resultLOCATION)
                        {
                            location = itemLOCATION.LOCATION;
                        }

                        var dataGetModelAndpartName = new
                        {
                            partNo = tagDefect.Substring(45).Trim(),
                            line_cd = tagDefect.Substring(5, 6).Trim()
                        };

                        var dataGetModelAndpartNameJson = JsonConvert.SerializeObject(dataGetModelAndpartName);
                        dynamic responseDataGetModelAndpartNameJson = await api.CurPostRequestAsync("Operation/get_model_partNo/", dataGetModelAndpartNameJson);

                        if (responseDataGetModelAndpartNameJson.Status == 1)
                        {
                            partNoName = responseDataGetModelAndpartNameJson.PartName;
                            workshift = responseDataGetModelAndpartNameJson.shift;
                            model = responseDataGetModelAndpartNameJson.MODEL;


                            PrintTagDefect TagDefect = new PrintTagDefect();
                            TagDefect.printTagDefect(tagDefect, qrDefectDetail, typeDefect, box, location, qty, partNo, partNoName, model, line, workshift, DateTime.Parse(date),Phase);
                        }
                        else
                        {
                            MessageBox.Show("Error System!!! : Get model");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error System!!! : Get location");
                    }
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
