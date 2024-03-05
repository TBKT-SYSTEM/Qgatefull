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

        string tagQgateGlobal = null;
        string tagQgateIdGlobal = null;
        string partNoName = null;

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

        private async void tbScanTag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lbPartNo.Text = "-";
                lbBoxNo.Text = "-";
                lbModel.Text = "-";
                lbLotNo.Text = "-";
                lbQty.Text = "-";
                lbShift.Text = "-";
                lbCheckDate.Text = "-";

                string tag = tbScanTag.Text;
                if (tag.Length == 103)
                {
                    try
                    {
                        var datagetPartno = new
                        {
                            macAddress = api.GetMacAddress()
                        };

                        var jsonDataGetPartNo = JsonConvert.SerializeObject(datagetPartno);
                        dynamic reponesDataGetPartNo = await api.CurPostRequestAsync("Operation/get_part/", jsonDataGetPartNo);

                        //Console.WriteLine(reponesDataGetPartNo);

                        if (reponesDataGetPartNo.status == 1)
                        {
                            // เสร็จ  ตรงนี้ => เช็คก่อนด้วยว่า Station นี้สามารถ Scan PartNo อะไรได้บ้าง เเล้วถ้า Scan partNo ที่ไม่มีใน มาสเตอร์(mst) จะไม่สามารถ reprint ที่ Station นี้ได้
                            bool statusMacthPartNo = false;
                            foreach (var item in reponesDataGetPartNo.selectPartNo)
                            {
                                if (tag.Substring(19, 25).Trim() == item.msp_part_no.ToString())
                                {
                                    Console.WriteLine("ok partno ตรง");
                                    scanTag(tag);
                                    statusMacthPartNo = true;
                                    break;
                                }
                                else
                                {
                                    statusMacthPartNo = false;
                                    tagQgateGlobal = null;
                                    tagQgateIdGlobal = null;
                                }
                            }

                            if (statusMacthPartNo == false)
                            {
                                MessageBox.Show("กรุณาสแกน partno ให้ตรงกับ station");
                                tagQgateGlobal = null;
                                tagQgateIdGlobal = null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error System!!! : NoData PartNo in DB");
                            tagQgateGlobal = null;
                            tagQgateIdGlobal = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        MessageBox.Show(ex.Message);
                        tagQgateGlobal = null;
                        tagQgateIdGlobal = null;
                    }

                }
                else
                {
                    MessageBox.Show("ไม่ครบ digit");
                    tagQgateGlobal = null;
                    tagQgateIdGlobal = null;
                }
                tbScanTag.Clear();
            }
        }

        private async void scanTag(string tagQgate)
        {
            PrintTag printTag = new PrintTag();

            try
            {
                var datatag = new
                {
                    TagQgate = tagQgate
                };

                var datadatatagjson = JsonConvert.SerializeObject(datatag);
                dynamic represponsedatadatatag = await api.CurPostRequestAsync("ReprintQgate/get_DataScanReprint/", datadatatagjson);
                //Console.WriteLine(represponsedatadatatag);

                if (represponsedatadatatag.Status == 1)
                {
                    tagQgateIdGlobal = represponsedatadatatag.ifts_id;
                    tagQgateGlobal = tagQgate;

                    var data = new
                    {
                        partNo = tagQgate.Substring(19, 25).Trim(),
                        line_cd = tagQgate.Substring(2, 6).Trim()
                    };

                    var dataJson = JsonConvert.SerializeObject(data);
                    dynamic responseData = await api.CurPostRequestAsync("Operation/get_model_partNo/", dataJson);
                    
                    lbPartNo.Text = tagQgate.Substring(19, 25).Trim();
                    lbBoxNo.Text = tagQgate.Substring(100, 3).Trim();
                    lbLotNo.Text = tagQgate.Substring(58, 4).Trim();
                    lbModel.Text = responseData.MODEL;
                    lbQty.Text = represponsedatadatatag.qty;
                    lbShift.Text = represponsedatadatatag.shift;
                    lbCheckDate.Text = represponsedatadatatag.checkDate;

                    partNoName = responseData.PartName;




                }
                else
                {
                    tagQgateGlobal = null;
                    tagQgateIdGlobal = null;
                    MessageBox.Show("tag นี้ ไม่เคยผลิตนะจ๊ะๆๆๆ");
                }
            }
            catch (Exception ex)
            {
                tagQgateGlobal = null;
                tagQgateIdGlobal = null;
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
            //MessageBox.Show("okkkk");
            try
            {
                if(tagQgateGlobal != null)
                {
                    string partno, boxno, model, lotno, qty, shift;

                    partno = lbPartNo.Text;
                    boxno = lbBoxNo.Text;
                    model = lbModel.Text;
                    lotno = lbLotNo.Text;
                    qty = lbQty.Text;
                    shift = lbShift.Text;

                    Console.WriteLine(String.Concat(partno, boxno, model, lotno, qty, shift));


                    // ต่อตรงนี้นะ 
                    MessageBox.Show("ok print ได้");
                    MessageBox.Show(tagQgateGlobal);


                    ///ส่งที่ต้องเรียกเพาราะไม่มีใน QrTag
                    /// -partNoName เสร็จ /
                    

                    var dataQRProductToGenQr = new
                    {
                        tagFaId = tagQgateIdGlobal
                    };

                    var dataQRProductToGenQrJson = JsonConvert.SerializeObject(dataQRProductToGenQr);
                    dynamic responseDataQRProductToGenQr = await api.CurPostRequestAsync("Operation/get_QRProductToGenQr/", dataQRProductToGenQrJson);

                    string idproduct = "IODC_ID ";
                    foreach (var item in responseDataQRProductToGenQr.data)
                    {
                        idproduct += item.iodc_id + " ";
                    }
                    /// , QrProduct(รวมจำนวน detail) , location ,
                    
                    string parameter = $"?partNumber={operationData.partnotagfa}";
                    dynamic resultLOCATION = await api.CurGetRequestAsync("http://192.168.161.77/apiSystem/exp/getItemMaster", parameter);

                    //Console.WriteLine("get location : " + resultLOCATION);

                    string location = null;
                    foreach (var itemLOCATION in resultLOCATION)
                    {
                        location = itemLOCATION.LOCATION;
                    }

                    /// Phase จาก line k1 => Phase10 ,k2 => Phase8
                    string Phase = null;
                    // ใช้ K1 K2 ใน line เช็ค
                    if (tagQgateGlobal.Substring(2,2).Trim() == "K1")
                    {
                        Phase = "Phase 10";
                    }
                    else
                    {
                        Phase = "Phase 8";
                    }


                    var dataInsAndUpdTagQgate = new
                    {
                        IdtagQgate = tagQgateIdGlobal,
                        login_user = Session.Userlogin
                    };

                    var dataInsAndUpdTagQgateJson = JsonConvert.SerializeObject(dataInsAndUpdTagQgate);
                    dynamic responseDataInsTagQgateJson = await api.CurPostRequestAsync("ReprintUpdate/update_CountPrintTagQgate/", dataInsAndUpdTagQgateJson);

                    if (responseDataInsTagQgateJson.Status == 1)
                    {
                        dynamic responseDataUpdTagQgateJson = await api.CurPostRequestAsync("ReprintIns/insert_Log_TagQgate/", dataInsAndUpdTagQgateJson);
                        if (responseDataUpdTagQgateJson.Status == 1)
                        {
                            PrintTag printTag = new PrintTag();
                            printTag.printTagQgate(" ", tagQgateGlobal.Substring(19, 25).Trim(), partNoName, lbModel.Text, " ", lbBoxNo.Text, tagQgateGlobal, idproduct, location, lbQty.Text, tagQgateGlobal.Substring(58, 4).Trim(), lbShift.Text, tagQgateGlobal.Substring(2, 6).Trim(), Phase);


                        }
                        else
                        {
                            MessageBox.Show("Error System : Update count print Qgate");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error System : Insert Log reprint Qgate");
                    }

                }
                else
                {
                    MessageBox.Show("สแกน TagQgate ให้สำเร็จก่อนนะจ๊ะๆๆ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void pbScanPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
