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
    public partial class qgateReprintQgateScanPrint : Form
    {
        QGate_system.API.API api = new QGate_system.API.API();

        Session Session = Session.Instance;
        LocationData LocationData = LocationData.Instance;
        operationData operationData = operationData.Instance;
        

        public qgateReprintQgateScanPrint()
        {
            InitializeComponent();
        }

        private void qgateReprintQgateScanPrint_Load(object sender, EventArgs e)
        {
            lbZone.Text = LocationData.Zone;
            lbStation.Text = LocationData.Station;


        }

        private void pbBackReprintToMenu_Click(object sender, EventArgs e)
        {
            qgateMenuReprintTag formMenuReprintTag = new qgateMenuReprintTag();
            formMenuReprintTag.Show();

            this.Hide();
        }

        private async void bScanTag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string tag = tbScanTag.Text;
                if (tag.Length == 103)
                {
                    /*operationData.tagfa = tag;
                    operationData.partnotagfa = tag.Substring(19, 25).Trim();
                    operationData.partcodemaster = tag.Substring(0, 2).Trim();
                    operationData.partline = tag.Substring(2, 6).Trim();
                    operationData.partplantdate = tag.Substring(8, 8).Trim();
                    operationData.partseqplan = tag.Substring(16, 3).Trim();
                    operationData.partactualdate1 = tag.Substring(44, 8).Trim();
                    operationData.partsnp = tag.Substring(52, 6).Trim();
                    operationData.partlotno = tag.Substring(58, 4).Trim();
                    operationData.partactualdate2 = tag.Substring(87, 8).Trim();
                    operationData.partseqactual = tag.Substring(95, 3).Trim();
                    operationData.partplant = tag.Substring(98, 2).Trim();
                    operationData.partbox = tag.Substring(100, 3).Trim();*/





                    var datagetPartno = new
                    {
                        macAddress = api.GetMacAddress()
                    };

                    var jsonDataGetPartNo = JsonConvert.SerializeObject(datagetPartno);
                    dynamic reponesDataGetPartNo = await api.CurPostRequestAsync("Login/chk_macAddress/", jsonDataGetPartNo);






                    // ตรงนี้ => เช็คก่อนด้วยว่า Station นี้สามารถ Scan PartNo อะไรได้บ้าง เเล้วถ้า Scan partNo ที่ไม่มีใน มาสเตอร์(mst) จะไม่สามารถ reprint ที่ Station นี้ได้
                    //scanTag(tag);
                }
                tbScanTag.Clear();
            }
            
        }

        private async void scanTag(string tag)
        {
            try
            {

                var data = new
                {
                    partNo = tag.Substring(19, 25).Trim(),
                    line_cd = tag.Substring(2, 6).Trim()
                };

                var dataJson = JsonConvert.SerializeObject(data);
                dynamic responseData = await api.CurPostRequestAsync("Operation/get_model_partNo/", dataJson);

                lbModel.Text = responseData.MODEL;
                lbPartNo.Text = tag.Substring(19, 25).Trim();
                lbBoxNo.Text = tag.Substring(100, 3).Trim();
                lbLotNo.Text = tag.Substring(58, 4).Trim();
                lbQty.Text = tag.Substring(52, 6).Trim();




                var datatag = new
                {
                    TagQgate = tag
                };

                var datadatatagjson = JsonConvert.SerializeObject(datatag);
                dynamic represponsedatadatatag = await api.CurPostRequestAsync("ReprintQgate/get_DataScanReprint/", datadatatagjson);

                if (represponsedatadatatag.Status == 0)
                {
                    // ต่อตรงนี้นะ 
                    
                }
                else
                {
                    MessageBox.Show("Error System");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void pbListPrint_Click(object sender, EventArgs e)
        {
            qgateReprintQgate formReprintQgate = new qgateReprintQgate();
            formReprintQgate.Show();

            this.Hide();
        }

        private void pbClear_Click(object sender, EventArgs e)
        {
            tbScanTag.Clear();
            lbPartNo.Text = "";
            lbBoxNo.Text = "";
            lbModel.Text = "";
            lbLotNo.Text = "";
            lbQty.Text = "";
            lbShift.Text = "";
            lbCheckDate.Text = ""; 
        }

        private void pbPrint_Click(object sender, EventArgs e)
        {
            try
            {
                /*string partno = null;
                string boxno = null;
                string model = null;
                string lotno = null;
                string qty = null;
                string shift = null;*/

                string partno, boxno, model, lotno, qty, shift;

                partno = lbPartNo.Text;
                boxno = lbBoxNo.Text;
                model = lbModel.Text;
                lotno = lbLotNo.Text;
                qty = lbQty.Text;
                shift = lbShift.Text;














            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
