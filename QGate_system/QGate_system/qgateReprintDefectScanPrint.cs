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
    public partial class qgateReprintDefectScanPrint : Form
    {
        QGate_system.API.API api = new QGate_system.API.API();

        Session Session = Session.Instance;
        LocationData LocationData = LocationData.Instance;
        operationData operationData = operationData.Instance;


        string tagDefectIdGlobal = null;
        string tagDefectGlobal = null;
        string partNoName = null;

        public qgateReprintDefectScanPrint()
        {
            InitializeComponent();
        }

        private void qgateReprintDefectScanPrint_Load(object sender, EventArgs e)
        {
            lbZone.Text = LocationData.Zone;
            lbStation.Text = LocationData.Station;


        }

        private async void tbScanTag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //MessageBox.Show("ok");
                    lbPartNo.Text = "-";
                    lbBoxNo.Text = "-";
                    lbModel.Text = "-";
                    lbLotNo.Text = "-";
                    lbQty.Text = "-";
                    lbShift.Text = "-";
                    lbCheckDate.Text = "-";

                    string tagDefect = tbScanTag.Text;
                    if (tagDefect.Length > 45 )
                    {
                        Console.WriteLine(tagDefect);

                        Console.WriteLine(tagDefect.Length);
                        Console.WriteLine(tagDefect.Substring(45)); //partno ไม่กำหนด digit เพราะว่า digit ไม่จำกัด

                        var datagetPartno = new
                        {
                            macAddress = api.GetMacAddress()
                        };

                        var jsonDataGetPartNo = JsonConvert.SerializeObject(datagetPartno);
                        dynamic reponesDataGetPartNo = await api.CurPostRequestAsync("Operation/get_part/", jsonDataGetPartNo);

                        Console.WriteLine("reponesDataGetPartNo" + reponesDataGetPartNo);
                        Console.WriteLine("PartNO : " + tagDefect.Substring(45).Trim());

                        if (reponesDataGetPartNo.status == 1)
                        {
                            // เสร็จ  ตรงนี้ => เช็คก่อนด้วยว่า Station นี้สามารถ Scan PartNo อะไรได้บ้าง เเล้วถ้า Scan partNo ที่ไม่มีใน มาสเตอร์(mst) จะไม่สามารถ reprint ที่ Station นี้ได้
                            bool statusMacthPartNo = false;
                            foreach (var item in reponesDataGetPartNo.selectPartNo)
                            {
                                if (tagDefect.Substring(45).Trim() == item.msp_part_no.ToString())
                                {
                                    Console.WriteLine("ok partno ตรง");
                                    scanTag(tagDefect);
                                    statusMacthPartNo = true;
                                    break;
                                }
                                else
                                {
                                    statusMacthPartNo = false;
                                }
                            }

                            if (statusMacthPartNo == false)
                            {
                                MessageBox.Show("กรุณาสแกน partno ให้ตรงกับ station");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error System!!! : NoData PartNo in DB");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error System!! : digit ไม่ครบ");
                    }

                }
                catch (Exception ex)
                {
                    //tagQgateGlobal = null;
                    //tagQgateIdGlobal = null;
                    Console.WriteLine(ex.Message);
                    MessageBox.Show(ex.Message);
                }
                tbScanTag.Clear();
            }
        }

        private async void scanTag(string tagDefect)
        {
            try
            {
                var datagetTagDefect = new
                {
                    tagDefect = tagDefect,
                    partNo = tagDefect.Substring(45)
                };

                var jsonDatagetTagDefect = JsonConvert.SerializeObject(datagetTagDefect);
                dynamic reponesDatagetTagDefect = await api.CurPostRequestAsync("ReprintDefect/get_DataScanReprintDefect/", jsonDatagetTagDefect);

                Console.WriteLine("reponesDatagetTagDefect : " + reponesDatagetTagDefect);

                if (reponesDatagetTagDefect.Status == 1)
                {
                    tagDefectIdGlobal = reponesDatagetTagDefect.tagDefectId;
                    tagDefectGlobal = tagDefect;

                    var dataGetModelAndpartName = new
                    {
                        partNo = tagDefect.Substring(45).Trim(),
                        line_cd = tagDefect.Substring(5, 6).Trim()
                    };
                    Console.WriteLine("dataGetModelAndpartName" + dataGetModelAndpartName);

                    var dataGetModelAndpartNameJson = JsonConvert.SerializeObject(dataGetModelAndpartName);
                    dynamic responseDataGetModelAndpartNameJson = await api.CurPostRequestAsync("Operation/get_model_partNo/", dataGetModelAndpartNameJson);
                    Console.WriteLine("responseDataGetModelAndpartNameJson" + responseDataGetModelAndpartNameJson);

                    string qty = tagDefect.Substring(39, 5);
                    while (qty.StartsWith("0"))
                    {
                        qty = qty.Substring(1);
                    }

                    lbPartNo.Text = tagDefect.Substring(45).Trim();
                    lbBoxNo.Text = tagDefect.Substring(35, 3).Trim();
                    lbLotNo.Text = tagDefect.Substring(27, 4).Trim();
                    lbQty.Text = qty;
                    lbModel.Text = responseDataGetModelAndpartNameJson.MODEL;
                    lbShift.Text = reponesDatagetTagDefect.shift;
                    lbCheckDate.Text = reponesDatagetTagDefect.checkDate;

                    partNoName = responseDataGetModelAndpartNameJson.PartName;
                    
                }
                else
                {
                    MessageBox.Show("TagDefect นี้ไม่เคยผลิตนะจ๊ะ!!");
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
            qgateReprintDefect formReprintDefect = new qgateReprintDefect();
            formReprintDefect.Show();

            this.Hide();
        }

        private void pbScanPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void pbBackReprintToMenu_Click(object sender, EventArgs e)
        {
            qgateMenuReprintTag formMenuReprintTag = new qgateMenuReprintTag();
            formMenuReprintTag.Show();

            this.Hide();
        }

        private void pbClear_Click(object sender, EventArgs e)
        {
            tbScanTag.Clear();
            lbPartNo.Text = "-";
            lbBoxNo.Text = "-";
            lbModel.Text = "-";
            lbLotNo.Text = "-";
            lbQty.Text = "-";
            lbShift.Text = "-";
            lbCheckDate.Text = "-";
        }

        private async void pbPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var dataGetReprintDefect = new
                {
                    IdTagDefect = tagDefectGlobal
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
                    string Phase = (tagDefectGlobal.Substring(5, 2).Trim() == "K1") ? "Phase 10" : "Phase 8";

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
