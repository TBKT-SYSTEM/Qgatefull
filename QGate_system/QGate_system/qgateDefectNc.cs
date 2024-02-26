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
    public partial class qgateDefectNc : Form
    {
        QGate_system.API.API api = new QGate_system.API.API();

        Session Session = Session.Instance;
        LocationData LocationData = LocationData.Instance;
        operationData operationData = operationData.Instance;

        qgateOperationManual qgateOPManual = qgateOperationManual.instance;
        qgateOperation qgateOPDMC = qgateOperation.instance;

        public qgateDefectNc()
        {
            InitializeComponent();

        }

        public int CountProduct { get; set; }
        public int CountBoxDefect { get; set; }
        public int CountDefect { get; set; }
        public string Namedefect { get; set; }

        public string qrcodeDMC { get; set; }

        public async void qgateDefectNc_Load(object sender, EventArgs e)
        {
            if (operationData != null)
            {
                if (!string.IsNullOrEmpty(operationData.countDMCDefectNCId))
                {
                    Console.WriteLine(operationData.countDMCDefectNCId);
                }
                else
                {
                    MessageBox.Show("countDMCDefectNCId is null or empty.");
                }
            }
            else
            {
                MessageBox.Show("operationData is null.");
            }
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

        private void pbBackToOperation_Click(object sender, EventArgs e)
        {
            this.Close();
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
                await chk_operation_NC(codeDefact);

            }
            else
            {
                MessageBox.Show("กรุณาเลือก Defact ก่อน");
            }
        }

        private async Task chk_operation_NC(string DefectCode)
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

                //MessageBox.Show("CountID" + operationData.countDefectNCId);
                if (!string.IsNullOrEmpty(operationData.countDefectNCId)) //operationData.countDefectNCId != null || operationData.countDefectNCId != ""
                {
                    //MessageBox.Show("กำลังจะทามมมม");

                    var dataSelCount = new
                    {
                        DefectCountID = operationData.countDefectNCId
                    };

                    //Console.WriteLine("dataSelCount : " + dataSelCount);

                    var dataSelCountJson = JsonConvert.SerializeObject(dataSelCount);
                    dynamic responseDataSelCount = await api.CurPostRequestAsync("Operation/get_DataDefectCountByID", dataSelCountJson);

                    var dataInsCountOP = new
                    {
                        DefectCountID = operationData.countDefectNCId,
                        Count = responseDataSelCount.idc_count + 1,
                        login_user = Session.Userlogin
                    };

                    var dataInsCountOPJson = JsonConvert.SerializeObject(dataInsCountOP);
                    dynamic responseData = await api.CurPostRequestAsync("OperationUpdate/update_Defect_CountByID", dataInsCountOPJson);

                    
                    if (responseData.Status == 1)
                    {
                        string operationId = operationData.OperationCount.Pop();
                        var dataInsCountDetail = new
                        {
                            DefectCode = DefectCode,
                            OperationId = operationId,
                            CountId = responseDataSelCount.idc_id,
                            TypeDefect = 0,
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

                            qgateOPManual.tb1.Text = CountProduct.ToString();
                            qgateOPManual.setTextCountProduct.Text = CountProduct.ToString();
                            qgateOPManual.setTextCountNc.Text = CountDefect.ToString();

                            qgateOPManual.Text_chang();

                            this.Hide();
                        }
                        else
                        {
                            operationData.OperationCount.Push(operationId);
                            MessageBox.Show("Error System : Save Defect Nc Detail");
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
                        TypeDefect = 0,
                        login_user = Session.Userlogin
                    };

                    var dataInsCountOPJson = JsonConvert.SerializeObject(dataInsCountOP);
                    dynamic responseData = await api.CurPostRequestAsync("OperationIns/insert_Defect_count", dataInsCountOPJson);

                    //Console.WriteLine(responseData.ToString());

                    if (responseData.Status == 1)
                    {
                        //MessageBox.Show(responseData.CountId.ToString());
                        //operationData.countNcId = responseData.CountId;
                        operationData.countDefectNCId = responseData.CountId;

                        //Console.WriteLine(operationData.countNgId);
                        string operationId = operationData.OperationCount.Pop();
                        var dataInsCountDetail = new
                        {
                            DefectCode = DefectCode,
                            OperationId = operationId,
                            CountId = operationData.countDefectNCId,
                            TypeDefect = 0,
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

                            qgateOPManual.tb1.Text = CountProduct.ToString();
                            qgateOPManual.setTextCountProduct.Text = CountProduct.ToString();
                            qgateOPManual.setTextCountNc.Text = CountDefect.ToString();

                            qgateOPManual.Text_chang();

                            this.Hide();
                        }
                        else
                        {
                            operationData.OperationCount.Push(operationId);
                            MessageBox.Show("Error System : Save Defect Nc Detail");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error system : insert count defect Failes");
                    }


                    /*var dataSelCount = new
                    {
                        StationId = LocationData.IdStation,
                        TypeDefect = 0,
                        Datecurr = Datecur,
                        Datetomor = Datetomor
                    };

                    //Console.WriteLine("dataSelCount : " + dataSelCount);

                    var dataSelCountJson = JsonConvert.SerializeObject(dataSelCount);
                    dynamic responseDataSelCount = await api.CurPostRequestAsync("Operation/get_DataDefectCount", dataSelCountJson);
                    //responseDataSelCount.Status -> 0 = ไม่มีข้อมูล count
                    //responseDataSelCount.Status -> 1 = มีข้อมูล count

                    //Console.WriteLine("DefectCount : " + responseDataSelCount);

                    //MessageBox.Show("DefectCount : " + responseDataSelCount.ToString());


                    if (responseDataSelCount.Status == 0)
                    {
                        //MessageBox.Show("insert count");
                        var dataInsCountOP = new
                        {
                            StationId = LocationData.IdStation,
                            Count = CountDefect + 1,
                            TypeDefect = 0,
                            login_user = Session.Userlogin
                        };

                        var dataInsCountOPJson = JsonConvert.SerializeObject(dataInsCountOP);
                        dynamic responseData = await api.CurPostRequestAsync("OperationIns/insert_Defect_count", dataInsCountOPJson);

                        //Console.WriteLine(responseData.ToString());

                        if (responseData.Status == 1)
                        {
                            //MessageBox.Show(responseData.CountId.ToString());
                            operationData.countNcId = responseData.CountId;
                            operationData.countDefectNCId = responseData.CountId;

                            //Console.WriteLine(operationData.countNgId);

                            var dataInsCountDetail = new
                            {
                                DefectCode = DefectCode,
                                OperationId = operationData.OperationCount.Pop(),
                                CountId = operationData.countNcId,
                                TypeDefect = 0,
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

                                qgateOPManual.tb1.Text = CountProduct.ToString();
                                qgateOPManual.setTextCountProduct.Text = CountProduct.ToString();
                                qgateOPManual.setTextCountNc.Text = CountDefect.ToString();

                                qgateOPManual.Text_chang();

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Error System : Save Defect Nc Detail");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error system : insert count defect Failes");
                        }
                    }
                    else if (responseDataSelCount.Status == 1)
                    {
                        //MessageBox.Show("insert detail and update count");

                        var dataInsCountOP = new
                        {
                            StationId = LocationData.IdStation,
                            Count = responseDataSelCount.idc_count + 1,
                            TypeDefect = 0,
                            Datecurr = Datecur,
                            Datetomor = Datetomor,
                            login_user = Session.Userlogin
                        };

                        var dataInsCountOPJson = JsonConvert.SerializeObject(dataInsCountOP);
                        dynamic responseData = await api.CurPostRequestAsync("OperationUpdate/update_Defect_Count", dataInsCountOPJson);

                        //MessageBox.Show("response update count" + responseData.ToString());


                        if (responseData.Status == 1)
                        {

                            var dataInsCountDetail = new
                            {
                                DefectCode = DefectCode,
                                OperationId = operationData.OperationCount.Pop(),
                                CountId = responseDataSelCount.idc_id,
                                TypeDefect = 0,
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

                                qgateOPManual.tb1.Text = CountProduct.ToString();
                                qgateOPManual.setTextCountProduct.Text = CountProduct.ToString();
                                qgateOPManual.setTextCountNc.Text = CountDefect.ToString();

                                qgateOPManual.Counter = CountProduct;
                                qgateOPManual.CounterNc = CountDefect;

                                qgateOPManual.Text_chang();

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Error System : Save Defect Nc Detail");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error System : Update count");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error System!!! : Get Defect Nc ");
                    }*/
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

                //MessageBox.Show(DefectCode);
                //MessageBox.Show("CountID" + operationData.countDefectNCId);
                if (!string.IsNullOrEmpty(operationData.countDMCDefectNCId)) //operationData.countDefectNCId != null || operationData.countDefectNCId != ""
                {
                    //MessageBox.Show("กำลังจะทามมมม");

                    var dataSelCount = new
                    {
                        DefectCountID = operationData.countDMCDefectNCId
                    };

                    Console.WriteLine("dataSelCount : " + dataSelCount);

                    var dataSelCountJson = JsonConvert.SerializeObject(dataSelCount);
                    dynamic responseDataSelCount = await api.CurPostRequestAsync("Operation/get_DataDefectCountByID", dataSelCountJson);


                    var dataInsCountOP = new
                    {
                        DefectCountID = operationData.countDMCDefectNCId,
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
                            TypeDefect = 0,
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
                            qgateOPDMC.setTextCountNc.Text = CountDefect.ToString();
                            qgateOPDMC.setTextCountNcSerial.Text = tbPartNo.Text;

                            qgateOPDMC.Counter = CountProduct;
                            qgateOPDMC.CounterNc = CountDefect;

                            qgateOPDMC.Text_chang();

                            this.Hide();
                        }
                        else
                        {
                            operationData.OperationCountDMC.Push(operationId);
                            MessageBox.Show("Error System : Save Defect Nc Detail");
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
                        TypeDefect = 0,
                        login_user = Session.Userlogin
                    };

                    var dataInsCountOPJson = JsonConvert.SerializeObject(dataInsCountOP);
                    dynamic responseData = await api.CurPostRequestAsync("OperationIns/insert_Defect_count", dataInsCountOPJson);

                    //Console.WriteLine(responseData.ToString());

                    string operationId = operationData.OperationCountDMC.Pop();
                    if (responseData.Status == 1)
                    {
                        //MessageBox.Show(responseData.CountId.ToString());
                        //operationData.countNcId = responseData.CountId;
                        operationData.countDMCDefectNCId = responseData.CountId;

                        //Console.WriteLine(operationData.countNgId);

                        var dataInsCountDetail = new
                        {
                            DefectCode = DefectCode,
                            OperationId = operationId,
                            CountId = operationData.countDMCDefectNCId,
                            TypeDefect = 0,
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
                            qgateOPDMC.setTextCountNc.Text = CountDefect.ToString();
                            qgateOPDMC.setTextCountNcSerial.Text = tbPartNo.Text;

                            qgateOPDMC.Counter = CountProduct;
                            qgateOPDMC.CounterNc = CountDefect;

                            qgateOPDMC.Text_chang();

                            this.Hide();
                        }
                        else
                        {
                            operationData.OperationCountDMC.Push(operationId);
                            MessageBox.Show("Error System : Save Defect Nc Detail");
                        }
                    }


                    /*var dataSelCount = new
                    {
                        StationId = LocationData.IdStation,
                        TypeDefect = 0,
                        Datecurr = Datecur,
                        Datetomor = Datetomor
                    };

                    //Console.WriteLine("dataSelCount : " + dataSelCount);

                    var dataSelCountJson = JsonConvert.SerializeObject(dataSelCount);
                    dynamic responseDataSelCount = await api.CurPostRequestAsync("Operation/get_DataDefectCount", dataSelCountJson);

                    //Console.WriteLine("dataSelCount : " + responseDataSelCount);

                    if (responseDataSelCount.Status == 0)
                    {
                        var dataInsCountOP = new
                        {
                            StationId = LocationData.IdStation,
                            Count = CountDefect + 1,
                            TypeDefect = 0,
                            login_user = Session.Userlogin
                        };

                        var dataInsCountOPJson = JsonConvert.SerializeObject(dataInsCountOP);
                        dynamic responseData = await api.CurPostRequestAsync("OperationIns/insert_Defect_count", dataInsCountOPJson);

                        //Console.WriteLine(responseData.ToString());

                        string operationId = operationData.OperationCountDMC.Pop();
                        if (responseData.Status == 1)
                        {
                            //MessageBox.Show(responseData.CountId.ToString());
                            operationData.countNcId = responseData.CountId;
                            operationData.countDefectNCId = responseData.CountId;

                            //Console.WriteLine(operationData.countNgId);

                            var dataInsCountDetail = new
                            {
                                DefectCode = DefectCode,
                                OperationId = operationId,
                                CountId = operationData.countNcId,
                                TypeDefect = 0,
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
                                qgateOPDMC.setTextCountNc.Text = CountDefect.ToString();
                                qgateOPDMC.setTextCountNcSerial.Text = tbPartNo.Text;

                                qgateOPDMC.Counter = CountProduct;
                                qgateOPDMC.CounterNc = CountDefect;

                                qgateOPDMC.Text_chang();

                                this.Hide();
                            }
                            else
                            {
                                operationData.OperationCountDMC.Push(operationId);
                                MessageBox.Show("Error System : Save Defect Nc Detail");
                            }
                        }
                    }
                    else if (responseDataSelCount.Status == 1)
                    {
                        //MessageBox.Show("insert detail and update count");

                        var dataInsCountOP = new
                        {
                            StationId = LocationData.IdStation,
                            Count = responseDataSelCount.idc_count + 1,
                            TypeDefect = 0,
                            Datecurr = Datecur,
                            Datetomor = Datetomor,
                            login_user = Session.Userlogin
                        };

                        var dataInsCountOPJson = JsonConvert.SerializeObject(dataInsCountOP);
                        dynamic responseData = await api.CurPostRequestAsync("OperationUpdate/update_Defect_Count", dataInsCountOPJson);

                        // MessageBox.Show("response update count" + responseData.ToString());

                        string operationId = operationData.OperationCountDMC.Pop();
                        if (responseData.Status == 1)
                        {
                            var dataInsCountDetail = new
                            {
                                DefectCode = DefectCode,
                                OperationId = operationId,
                                CountId = responseDataSelCount.idc_id,
                                TypeDefect = 0,
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
                                qgateOPDMC.setTextCountNc.Text = CountDefect.ToString();
                                qgateOPDMC.setTextCountNcSerial.Text = tbPartNo.Text;

                                qgateOPDMC.Counter = CountProduct;
                                qgateOPDMC.CounterNc = CountDefect;

                                qgateOPDMC.Text_chang();

                                this.Hide();
                            }
                            else
                            {
                                operationData.OperationCountDMC.Push(operationId);
                                MessageBox.Show("Error System : Save Defect Nc Detail");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error System : Update count");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error System!!! : Get Defect Nc ");
                    }*/
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            qgateOPManual.tb1.Text = textBox1.Text;
            //qgateOperationManual.instance.tb1.Text = "123";
            //qgateOperationManual.instance.test();
        }
    }

}
