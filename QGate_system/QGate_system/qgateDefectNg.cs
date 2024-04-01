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
    public partial class qgateDefectNg : Form
    {
        QGate_system.API.API api = new QGate_system.API.API();

        Session Session = Session.Instance;
        LocationData LocationData = LocationData.Instance;
        operationData operationData = operationData.Instance;

        qgateOperationManual qgateOPManual = qgateOperationManual.instance;
        qgateOperation qgateOPDMC = qgateOperation.instance;
        qgateScanTag scanTag = new qgateScanTag();

        public qgateDefectNg()
        {
            InitializeComponent();
        }

        public int CountProduct { get; set; }
        public int CountBoxDefect { get; set; }
        public int CountDefect { get; set; }
        public string Namedefect { get; set; }
        public string qrcodeDMC { get; set; }


        public async void qgateDefectNg_Load(object sender, EventArgs e)
        {
            /*if (operationData != null)
            {
                if (!string.IsNullOrEmpty(operationData.countDefectNGId))
                {
                    Console.WriteLine(operationData.countDefectNGId);
                }
                else
                {
                    MessageBox.Show("countDefectNCId is null or empty.");
                }
            }
            else
            {
                MessageBox.Show("operationData is null.");
            }*/
            lbZone.Text = LocationData.Zone;
            lbStation.Text = LocationData.Station;
            lbNamedefect.Text = Namedefect;

            if (operationData.typeStation == "Manual")
            {
                tbPartNo.Hide();
                CbNumProduct.Text = (CountBoxDefect > 9) ? "0" + CountBoxDefect.ToString() : "00" + CountBoxDefect.ToString();
                //CbNumProduct.Text = (CountBox > 9)? "0" + CountBox.ToString() : "00" + CountBox.ToString();
                //Console.WriteLine(OperationManual.BoxNc);
                //MessageBox.Show(Count.ToString());
            }
            else if (operationData.typeStation == "DMC")
            {
                CbNumProduct.Hide();
                tbPartNo.Text = qrcodeDMC;
                tbPartNo.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("type staction ไม่ตรง");
            }

            await getdefect();
        }

        private async Task getdefect()
        {
            var data = new
            {
                StationID = LocationData.IdStation
            };

            var dataJson = JsonConvert.SerializeObject(data);
            dynamic responseData = await api.CurPostRequestAsync("Operation/get_DefectDetail", dataJson);

            if (responseData != null)
            {
                foreach (var Defect in responseData.Defect)
                {
                    string[] Defectdetail = { Defect.md_defect_code, Defect.md_defect_en_name };
                    ListViewItem items = new ListViewItem(Defectdetail);
                    lvDefect.Items.Add(items);

                }
            }
        }

        private void pbBackToOperation_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void pbConfirm_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = lvDefect.SelectedItems;
            string codeDefact = null;

            foreach (ListViewItem selectedItem in selectedItems)
            {
                codeDefact = selectedItem.SubItems[0].Text;
            }
            
            if (codeDefact != null)
            {
                //MessageBox.Show(codeDefact);

                //await confirmDefectNG();

                await chk_operation_NG(codeDefact);

            }
            else
            {
                MessageBox.Show("กรุณาเลือก Defact ก่อน");
            }
        }

        private async Task chk_operation_NG(string DefectCode)
        {
            if (operationData.typeStation == "Manual")
            {
                await NonDMC(DefectCode);
            }
            else if (operationData.typeStation == "DMC")
            {
                await DMC(DefectCode);
            }
            else
            {
                MessageBox.Show("กรุณาเช็ค Station");
            }

        }

        private async Task NonDMC(string DefectCode)
        {
            DateTime dateTime = DateTime.Now;
            string Datecur;
            string Datetomor;

            try
            {
                if (dateTime.Hour < 8)
                {
                    DateTime previousDay = dateTime.AddDays(-1).Date;

                    Datecur = previousDay.ToString("yyyy-MM-dd");
                    Datetomor = dateTime.ToString("yyyy-MM-dd");
                }
                else
                {
                    DateTime previousDay = dateTime.AddDays(+1).Date;

                    Datecur = dateTime.ToString("yyyy-MM-dd");
                    Datetomor = previousDay.ToString("yyyy-MM-dd");
                }

                //MessageBox.Show("CountID" + operationData.countDefectNGId);
                if (!string.IsNullOrEmpty(operationData.countDefectNGId)) //operationData.countDefectNGId != null || operationData.countDefectNGId != ""
                {
                    //MessageBox.Show("กำลังจะทามมมม");

                    var dataSelCount = new
                    {
                        DefectCountID = operationData.countDefectNGId
                    };
                    Console.WriteLine("dataSelCount : " + dataSelCount);

                    //Console.WriteLine("dataSelCount : " + dataSelCount);

                    var dataSelCountJson = JsonConvert.SerializeObject(dataSelCount);
                    dynamic responseDataSelCount = await api.CurPostRequestAsync("Operation/get_DataDefectCountByID", dataSelCountJson);
                    Console.WriteLine("responseDataSelCount : " + responseDataSelCount);


                    var dataInsCountOP = new
                    {
                        DefectCountID = operationData.countDefectNGId,
                        Count = responseDataSelCount.idc_count + 1,
                        login_user = Session.Userlogin
                    };

                    Console.WriteLine("dataInsCountOP : " + dataInsCountOP);

                    var dataInsCountOPJson = JsonConvert.SerializeObject(dataInsCountOP);
                    dynamic responseData = await api.CurPostRequestAsync("OperationUpdate/update_Defect_CountByID", dataInsCountOPJson);
                    Console.WriteLine("update_Defect_CountByID : " + responseData);

                    string operationId = operationData.OperationCount.Pop();
                    if (responseData.Status == 1)
                    {
                        var dataInsCountDetail = new
                        {
                            DefectCode = DefectCode,
                            OperationId = operationId,
                            CountId = responseDataSelCount.idc_id,
                            TypeDefect = 1,
                            login_user = Session.Userlogin
                        };
                        //Console.WriteLine(dataInsCountDetail);

                        var dataInsCountDetailJson = JsonConvert.SerializeObject(dataInsCountDetail);
                        dynamic responseCountDetail = await api.CurPostRequestAsync("OperationIns/insert_Defect_count_detail", dataInsCountDetailJson);

                        //Console.WriteLine(responseCountDetail);
                        //Console.WriteLine("Response Insert detail :" + responseCountDetail.ToString());

                        if (responseCountDetail.Status == 1)
                        {
                            CountProduct--;
                            CountDefect++;

                            //MessageBox.Show(CountProduct.ToString());
                            //MessageBox.Show(CountDefect.ToString());

                            //qgateOPManual.tb1.Text = CountProduct.ToString();
                            qgateOPManual.setTextCountProduct.Text = CountProduct.ToString();
                            qgateOPManual.setTextCountNg.Text = CountDefect.ToString();
                            qgateOPManual.Text_chang();

                            this.Hide();
                        }
                        else
                        {
                            operationData.OperationCount.Push(operationId);
                            MessageBox.Show("Error System : Save Defect Ng Detail");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error System : Update count");
                    }
                }
                else
                {
                    var dataInsCountOP = new
                    {
                        StationId = LocationData.IdStation,
                        Count = CountDefect + 1,
                        TypeDefect = 1,
                        login_user = Session.Userlogin
                    };

                    var dataInsCountOPJson = JsonConvert.SerializeObject(dataInsCountOP);
                    dynamic responseData = await api.CurPostRequestAsync("OperationIns/insert_Defect_count", dataInsCountOPJson);

                    //Console.WriteLine(responseData);

                    if (responseData.Status == 1)
                    {
                        operationData.countDefectNGId = responseData.CountId;
                        //operationData.countNgId = responseData.CountId;

                        //Console.WriteLine(operationData.countNgId);
                        string operationId = operationData.OperationCount.Pop();
                        var dataInsCountDetail = new
                        {
                            DefectCode = DefectCode,
                            OperationId = operationId,
                            CountId = operationData.countDefectNGId,
                            TypeDefect = 1,
                            login_user = Session.Userlogin
                        };

                        var dataInsCountDetailJson = JsonConvert.SerializeObject(dataInsCountDetail);
                        dynamic responseCountDetail = await api.CurPostRequestAsync("OperationIns/insert_Defect_count_detail", dataInsCountDetailJson);

                        //Console.WriteLine(responseCountDetail);

                        //Console.WriteLine("Response Insert detail :" + responseCountDetail.ToString());

                        if (responseCountDetail.Status == 1)
                        {
                            CountProduct--;
                            CountDefect++;

                            //MessageBox.Show(CountProduct.ToString());
                            //MessageBox.Show(CountDefect.ToString());

                            //qgateOPManual.tb1.Text = CountProduct.ToString();
                            qgateOPManual.setTextCountProduct.Text = CountProduct.ToString();
                            qgateOPManual.setTextCountNg.Text = CountDefect.ToString();
                            qgateOPManual.Text_chang();

                            this.Hide();
                        }
                        else
                        {
                            operationData.OperationCount.Push(operationId);
                            MessageBox.Show("Error System : Save Defect Ng Detail");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error system : insert count defect Failes");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private async Task DMC(string DefectCode)
        {
            DateTime dateTime = DateTime.Now;
            string Datecur;
            string Datetomor;

            try
            {
                if (dateTime.Hour < 8)
                {
                    DateTime previousDay = dateTime.AddDays(-1).Date;

                    Datecur = previousDay.ToString("yyyy-MM-dd");
                    Datetomor = dateTime.ToString("yyyy-MM-dd");
                }
                else
                {
                    DateTime previousDay = dateTime.AddDays(+1).Date;

                    Datecur = dateTime.ToString("yyyy-MM-dd");
                    Datetomor = previousDay.ToString("yyyy-MM-dd");
                }

                //MessageBox.Show("CountID" + operationData.countDMCDefectNGId);
                if (!string.IsNullOrEmpty(operationData.countDMCDefectNGId)) //operationData.countDefectNGId != null || operationData.countDefectNGId != ""
                {

                    //MessageBox.Show("กำลังจะทามมมม");

                    var dataSelCount = new
                    {
                        DefectCountID = operationData.countDMCDefectNGId
                    };

                    //Console.WriteLine("dataSelCount : " + dataSelCount);

                    var dataSelCountJson = JsonConvert.SerializeObject(dataSelCount);
                    dynamic responseDataSelCount = await api.CurPostRequestAsync("Operation/get_DataDefectCountByID", dataSelCountJson);

                    var dataInsCountOP = new
                    {
                        DefectCountID = operationData.countDMCDefectNGId,
                        Count = responseDataSelCount.idc_count + 1,
                        login_user = Session.Userlogin
                    };

                    var dataInsCountOPJson = JsonConvert.SerializeObject(dataInsCountOP);
                    dynamic responseData = await api.CurPostRequestAsync("OperationUpdate/update_Defect_CountByID", dataInsCountOPJson);

                    string operationId = operationData.OperationCountDMC.Pop();
                    if (responseData.Status == 1)
                    {
                        var dataInsCountDetail = new
                        {
                            DefectCode = DefectCode,
                            OperationId = operationId,
                            CountId = responseDataSelCount.idc_id,
                            TypeDefect = 1,
                            login_user = Session.Userlogin
                        };
                        //Console.WriteLine(dataInsCountDetail);

                        var dataInsCountDetailJson = JsonConvert.SerializeObject(dataInsCountDetail);
                        dynamic responseCountDetail = await api.CurPostRequestAsync("OperationIns/insert_Defect_count_detail", dataInsCountDetailJson);

                        //Console.WriteLine(responseCountDetail);

                        //Console.WriteLine("Response Insert detail :" + responseCountDetail.ToString());

                        if (responseCountDetail.Status == 1)
                        {
                            qgateOPDMC.qrCodelist.RemoveAt(CountProduct - 1);

                            CountProduct--;
                            CountDefect++;

                            //MessageBox.Show(CountProduct.ToString());
                            //MessageBox.Show(CountDefect.ToString());

                            qgateOPDMC.setTextCountProduct.Text = CountProduct.ToString();
                            qgateOPDMC.setTextCountNg.Text = CountDefect.ToString();
                            qgateOPDMC.setTextCountNgSerial.Text = tbPartNo.Text;

                            qgateOPDMC.Counter = CountProduct;
                            qgateOPDMC.CounterNg = CountDefect;

                            qgateOPDMC.Text_chang();

                            this.Hide();
                        }
                        else
                        {
                            operationData.OperationCountDMC.Push(operationId);
                            MessageBox.Show("Error System : Save Defect Ng Detail");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error System : Update count");
                    }
                }
                else
                {
                    var dataGetLogchkboxDefect = new
                    {
                        lotno_curr = scanTag.genLot(DateTime.Now),
                        partNo = operationData.partnotagfa,
                        typedefect = 1
                    };

                    //Console.WriteLine(dataGetLogchkboxDefect);

                    var dataGetLogchkboxDefectJson = JsonConvert.SerializeObject(dataGetLogchkboxDefect);
                    dynamic responsedataGetLogchkboxDefect = await api.CurPostRequestAsync("Operation/get_boxDefect/", dataGetLogchkboxDefectJson);
                    //Console.WriteLine("responsedataGetLogchkboxDefect" + responsedataGetLogchkboxDefect);

                    string box;
                    string boxNoString;
                    if (responsedataGetLogchkboxDefect.Status == 1)
                    {
                        boxNoString = responsedataGetLogchkboxDefect.lcbnd_box_no.ToString();
                        box = (int.Parse(boxNoString) + 1 > 9) ? "0" + (int.Parse(boxNoString) + 1).ToString() : "00" + (int.Parse(boxNoString) + 1).ToString();
                        var dataInsLogchkboxDefect = new
                        {
                            lotNo = scanTag.genLot(DateTime.Now),
                            partNo = operationData.partnotagfa,
                            boxDefect = box,
                            typeDefect = 1,
                            login_user = Session.Userlogin
                        };
                        //Console.WriteLine(dataGetLogchkboxDefect);


                        var dataInsLogchkboxDefectJson = JsonConvert.SerializeObject(dataInsLogchkboxDefect);
                        dynamic responseInsLogchkboxDefectJson = await api.CurPostRequestAsync("OperationIns/insert_log_chk_BoxNo_Defect/", dataInsLogchkboxDefectJson);
                        //Console.WriteLine("responseInsLogchkboxDefectJson" + responseInsLogchkboxDefectJson);
                        if (responseInsLogchkboxDefectJson.Status != 1)
                        {
                            MessageBox.Show("Error system!!! : insert log chk box defect");
                        }


                    }
                    else
                    {
                        box = "001";
                        var dataInsLogchkboxDefect = new
                        {
                            lotNo = scanTag.genLot(DateTime.Now),
                            partNo = operationData.partnotagfa,
                            boxDefect = box,
                            typeDefect = 1,
                            login_user = Session.Userlogin
                        };

                        var dataInsLogchkboxDefectJson = JsonConvert.SerializeObject(dataInsLogchkboxDefect);
                        dynamic responseInsLogchkboxDefectJson = await api.CurPostRequestAsync("OperationIns/insert_log_chk_BoxNo_Defect/", dataInsLogchkboxDefectJson);
                        //Console.WriteLine("responseInsLogchkboxDefectJson" + responseInsLogchkboxDefectJson);
                        if (responseInsLogchkboxDefectJson.Status != 1)
                        {
                            MessageBox.Show("Error system!!! : insert log chk box defect");
                        }
                    }

                    ////////////


                    var dataInsCountOP = new
                    {
                        StationId = LocationData.IdStation,
                        Count = CountDefect + 1,
                        TypeDefect = 1,
                        login_user = Session.Userlogin
                    };

                    var dataInsCountOPJson = JsonConvert.SerializeObject(dataInsCountOP);
                    dynamic responseData = await api.CurPostRequestAsync("OperationIns/insert_Defect_count", dataInsCountOPJson);

                    //Console.WriteLine(responseData);

                    if (responseData.Status == 1)
                    {
                        operationData.countDMCDefectNGId = responseData.CountId;
                        //operationData.countNgId = responseData.CountId;

                        //Console.WriteLine(operationData.countNgId);
                        string operationId = operationData.OperationCountDMC.Pop();
                        var dataInsCountDetail = new
                        {
                            DefectCode = DefectCode,
                            OperationId = operationId,
                            CountId = operationData.countDMCDefectNGId,
                            TypeDefect = 1,
                            login_user = Session.Userlogin
                        };

                        var dataInsCountDetailJson = JsonConvert.SerializeObject(dataInsCountDetail);
                        dynamic responseCountDetail = await api.CurPostRequestAsync("OperationIns/insert_Defect_count_detail", dataInsCountDetailJson);

                        if (responseCountDetail.Status == 1)
                        {
                            qgateOPDMC.qrCodelist.RemoveAt(CountProduct - 1);

                            CountProduct--;
                            CountDefect++;

                            //MessageBox.Show(CountProduct.ToString());
                            //MessageBox.Show(CountDefect.ToString());

                            qgateOPDMC.setTextCountProduct.Text = CountProduct.ToString();
                            qgateOPDMC.setTextCountNg.Text = CountDefect.ToString();
                            qgateOPDMC.setTextlbBoxNoNg.Text = box;
                            qgateOPDMC.setTextCountNgSerial.Text = tbPartNo.Text;

                            qgateOPDMC.Counter = CountProduct;
                            qgateOPDMC.CounterNg = CountDefect;

                            qgateOPDMC.Text_chang();

                            this.Hide();
                        }
                        else
                        {
                            operationData.OperationCountDMC.Push(operationId);
                            MessageBox.Show("Error System : Save Defect Ng Detail");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error system : insert count defect Failes");
                    }

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
