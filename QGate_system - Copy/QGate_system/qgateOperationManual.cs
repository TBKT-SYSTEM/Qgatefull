using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace QGate_system
{
    public partial class qgateOperationManual : Form
    {
        /**/QGate_system.API.API api = new QGate_system.API.API();

        Session Session = Session.Instance;
        LocationData LocationData = LocationData.Instance;
        operationData operationData = operationData.Instance;
        //QGate_system.API.API api = new QGate_system.API.API();

        // ประกาศ instance ของ form qgateOperationManual
        public static qgateOperationManual instance;
        public TextBox setTextCountProduct;
        public TextBox setTextCountNc;
        public TextBox setTextCountNg;
        public TextBox tb1;

        public Label setTextlbBoxNoNc;
        public Label setTextlbBoxNoNg;

        private int counter = 0;
        private int counterNc = 0;
        private int counterNg = 0;
        private int BoxNc = 0;
        private int BoxNg = 0;

        private int Ms = 0;
        private int s = 0;

        private int chkTime = 0;
        private int countPlus = 1;
        private int countDel = -1;
        private string productrank = "A";
        private string idnamedigit = "";
        private string dmcid = "";
        //private string IDTagfa;
        
        public qgateOperationManual()
        {
            InitializeComponent();
            timer1.Start();

            instance = this;
            setTextCountProduct = tbCounter;
            setTextCountNc = tbCounterNc;
            setTextCountNg = tbCounterNg;
            setTextlbBoxNoNc = lbBoxNoNc;
            setTextlbBoxNoNg = lbBoxNoNg;

            counter = int.Parse(setTextCountProduct.Text);
            counterNc = int.Parse(setTextCountNc.Text);
            counterNg = int.Parse(setTextCountNg.Text);
        }

        public int Counter
        {
            get { return counter; }
            set
            {
                counter = value;
            }
        }

        public int CounterNc
        {
            get { return counterNc; }
            set
            {
                counterNc = value;
            }
        }

        public int CounterNg
        {
            get { return counterNg; }
            set
            {
                counterNg = value;
            }
        }

        private async void qgateOperationManual_Load(object sender, EventArgs e)
        {
           
            pbFinish.Hide();
            pbEnd.Hide();

            pbNc.Enabled = false;
            pbNg.Enabled = false;

            var data = new
            {
                partNo = LocationData.PartNo,
                line_cd = operationData.partline
            };

            var dataJson = JsonConvert.SerializeObject(data);
            dynamic responseData = await api.CurPostRequestAsync("Operation/get_model_partNo/", dataJson);

            operationData.model = responseData.MODEL;
            operationData.partNoName = responseData.PartName;

            //// input information windown form
            lbZone.Text = LocationData.Zone;
            lbStation.Text = LocationData.Station;
            lbPartNo.Text = (LocationData.PartNo.Length <= 15) ? LocationData.PartNo : LocationData.PartNo.Substring(0, 15) + "....";
            //lbPartNoName.Text = "test";
            lbPartNoName.Text = (operationData.partNoName.Length <= 15) ? operationData.partNoName  : operationData.partNoName.Substring(0, 15) + "....";
            lbProductDate.Text = operationData.partactualdate1;
            lbModel.Text = operationData.model;
            lbLotNo.Text = operationData.lotcur;
            lbSnp.Text = operationData.partsnp;
            lbBoxNo.Text = (operationData.boxNo > 9) ? "0" + operationData.boxNo : "00" + operationData.boxNo;

            tbCounter.ReadOnly = true;
            tbCounterNg.ReadOnly = true;
            tbCounterNc.ReadOnly = true;
            
            pbBackToScan.Enabled = false;
            lbReduce.Enabled = false;

            await getNumAndBoxDefect();
        }

        private void pbBackToScan_Click(object sender, EventArgs e)
        {
            qgateScanTag FormScanTag = new qgateScanTag();
            FormScanTag.Show();
            this.Hide();
        }

        private async void lb_plus_Click(object sender, EventArgs e)
        {
            lbIncrease.Enabled = false;
            lbReduce.Enabled = false;
            pbNc.Enabled = false;
            pbNg.Enabled = false;

            // deley by station
            //await Task.Delay(LocationData.Delay * 1000);

            //lbIncrease.Enabled = true;
            //lbReduce.Enabled = true;
            //pbNc.Enabled = true;
            //pbNg.Enabled = true;

            chkTime = (chkTime == 0) ? s : s - chkTime;
            await countProductplus();

            if (int.Parse(tbCounter.Text) == int.Parse(operationData.partsnp))
            {
                lbIncrease.Enabled = false;
                lbReduce.Enabled = true;
                pbFinish.Show();
            }
            else if (int.Parse(tbCounter.Text) > 0)
            {
                lbIncrease.Enabled = true;
                lbReduce.Enabled = true;
                pbEnd.Show();
            }
            else
            {
                MessageBox.Show("error system : btn plus");
            }

        }

        private async void lb_delete_Click(object sender, EventArgs e)
        {

            lbIncrease.Enabled = false;
            lbReduce.Enabled = false;
            pbNc.Enabled = false;
            pbNg.Enabled = false;

            // deley by station
            //await Task.Delay(LocationData.Delay * 1000);

            //lbIncrease.Enabled = true;
            //lbReduce.Enabled = true;
            //pbNc.Enabled = true;
            //pbNg.Enabled = true;

            chkTime = (chkTime == 0) ? s : s - chkTime;
            await countProductdelete();

            if (int.Parse(tbCounter.Text) <= 0)
            {
                lbIncrease.Enabled = true;
                lbReduce.Enabled = false;
                pbFinish.Hide();
                pbEnd.Hide();
            }
            else if (int.Parse(tbCounter.Text) > 0)
            {
                lbIncrease.Enabled = true;
                lbReduce.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error system!!!");
            }
        }

        private void tbCounter_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("ok chang tbcount fun");
            //MessageBox.Show("Counter : " + counter);

            /*if (int.Parse(tbCounterNc.Text) >= int.Parse(operationData.partsnp))
            {
                int boxNoNc = int.Parse(lbBoxNoNc.Text) + 1;
                tbCounterNc.Text = "0";
                lbBoxNoNc.Text = (boxNoNc > 9) ? "0" + boxNoNc.ToString() : "00" + boxNoNc.ToString();
            }

            if (int.Parse(tbCounterNg.Text) >= int.Parse(operationData.partsnp))
            {
                int boxNoNg = int.Parse(lbBoxNoNg.Text) + 1;
                tbCounterNg.Text = "0";
                lbBoxNoNg.Text = (boxNoNg > 9) ? "0" + boxNoNg.ToString() : "00" + boxNoNg.ToString();
            }*/

            if (int.Parse(tbCounter.Text) == int.Parse(operationData.partsnp))
            {
                pbFinish.Show();
                pbEnd.Show();
                lbIncrease.Enabled = false;
                lbReduce.Enabled = true;
                pbNc.Enabled = true;
                pbNg.Enabled = true;
                //MessageBox.Show("count = snp");
            }
            else if (int.Parse(tbCounter.Text) > 0 ) 
            {
                pbFinish.Hide();
                pbEnd.Show();
                pbNc.Enabled = true;
                pbNg.Enabled = true;
                lbIncrease.Enabled = true;
                lbReduce.Enabled = true;
            }
            else if (int.Parse(tbCounter.Text) == 0)
            {
                pbFinish.Hide();
                pbEnd.Hide();
                lbIncrease.Enabled = true;
                lbReduce.Enabled = false;
                pbNc.Enabled = false;
                pbNg.Enabled = false;
            }
            else
            {
                pbNc.Enabled = false;
                pbNg.Enabled = false;
                pbFinish.Hide();
                pbEnd.Hide();
                lbIncrease.Enabled = false;
                lbReduce.Enabled = false;

            }


            if (int.Parse(tbCounterNc.Text) >= 1 || int.Parse(lbBoxNoNc.Text) > 1)
            {
                pbEnd.Show();
            }

            if (int.Parse(tbCounterNg.Text) >= 1 || int.Parse(lbBoxNoNg.Text) > 1)
            {
                pbEnd.Show();
            }

        }

        private async void pbFinish_Click(object sender, EventArgs e)
        {
            if (int.Parse(tbCounter.Text) == int.Parse(operationData.partsnp))
            {
                await finish();

                qgateScanTag formScanTag = new qgateScanTag();
                formScanTag.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Error system!!! : ไม่ครบ SNP ");
            }
        }

        private async void pbEnd_Click(object sender, EventArgs e)
        {
            if (int.Parse(tbCounter.Text) > 0)
            {
                await finish();
            }
            
            if (int.Parse(tbCounterNc.Text) > 0 || int.Parse(tbCounterNg.Text) > 0)
            {
                await end();
            }
            
            this.Hide();
            operationData.countDefectNGId = "";
            operationData.countDefectNCId = "";
        }

        private void pbNc_Click(object sender, EventArgs e)
        {
            if (int.Parse(tbCounter.Text) > 0)
            {
                //counterNc++;
                qgateDefectNc formDefectNc = new qgateDefectNc();
                formDefectNc.Namedefect = "BOX NO : ";
                formDefectNc.CountBoxDefect =int.Parse(lbBoxNoNc.Text);

                formDefectNc.CountProduct = int.Parse(tbCounter.Text);
                formDefectNc.CountDefect = int.Parse(tbCounterNc.Text);

                formDefectNc.Show();
            }
        }

        private void pbNg_Click(object sender, EventArgs e)
        {
            if (int.Parse(tbCounter.Text) > 0)
            {
                //counterNg++;
                qgateDefectNg formDefectNg = new qgateDefectNg();
                formDefectNg.Namedefect = "BOX NO : ";
                formDefectNg.CountBoxDefect = int.Parse(lbBoxNoNg.Text);

                formDefectNg.CountProduct = int.Parse(tbCounter.Text);
                formDefectNg.CountDefect = int.Parse(tbCounterNg.Text);

                formDefectNg.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Ms += 1;
            if (Ms >= 10)
            {
                s += 1;
                Ms = 0;
            }
        }

        public async Task getNumAndBoxDefect()
        {
            Console.WriteLine(string.IsNullOrEmpty(operationData.countDefectNCId));
            Console.WriteLine(string.IsNullOrEmpty(operationData.countDefectNGId));


            var data = new
            {
                CountDefectNCId = (string.IsNullOrEmpty(operationData.countDefectNCId)) ? "null" : operationData.countDefectNCId,
                CountDefectNGId = (string.IsNullOrEmpty(operationData.countDefectNGId)) ? "null" : operationData.countDefectNGId
            };
            //Console.WriteLine(data);
            var dataJson = JsonConvert.SerializeObject(data);
            dynamic responseData = await api.CurPostRequestAsync("Operation/get_DefectNum/", dataJson);
            //Console.WriteLine(responseData);

            if (responseData.Status == 1)
            {
                foreach (var item in responseData.data)
                {
                    if (item.idc_type == 0 && item.summary > 0)
                    {
                        tbCounterNc.Text = item.summary;
                        lbBoxNoNc.Text = item.idc_box;
                    }
                    else if (item.idc_type == 0 && item.summary == 0)
                    {
                        //MessageBox.Show("Error System!! : get count defect(NC)");
                    }
                    else if (item.idc_type == 1 && item.summary > 0)
                    {
                        tbCounterNg.Text = item.summary;
                        lbBoxNoNg.Text = item.idc_box;
                    }
                    else if (item.idc_type == 1 && item.summary == 0)
                    {
                        //MessageBox.Show("Error System!! : get count defect(NG)");
                    }

                }
            }
            else
            {
                MessageBox.Show("Error System!! : get count defect(NC,NG)");
            }

            /*if (string.IsNullOrEmpty(operationData.countDefectNCId) && string.IsNullOrEmpty(operationData.countDefectNGId))
            {
                //MessageBox.Show("Type Defect Null");
                //(กรณี partNo เดิม) New get box ถ้าเป็น 

                counterNg = 0;
                BoxNg = 1;
                counterNc = 0;
                BoxNc = 1;

                tbCounterNg.Text = "0";
                lbBoxNoNg.Text = "001";
                tbCounterNc.Text = "0";
                lbBoxNoNc.Text = "001";
            }
            else
            {
                // MessageBox.Show("Type Defect Not Null");
                var data = new
                {
                    CountDefectNCId = operationData.countDefectNCId,
                    CountDefectNGId = operationData.countDefectNGId
                };

                var dataJson = JsonConvert.SerializeObject(data);
                dynamic responseData = await api.CurPostRequestAsync("Operation/get_DefectNum/", dataJson);


                if (responseData.Status == 1)
                {
                    foreach (var item in responseData.data)
                    {
                        if (item.idc_type == 0 && item.summary > 0)
                        {
                            int summaryValue = (int)item.summary;
                            int snp = int.Parse(operationData.partsnp);

                            counterNc = summaryValue % snp;
                            BoxNc = (summaryValue / snp) + 1;

                            tbCounterNc.Text = counterNc.ToString();
                            lbBoxNoNc.Text = (BoxNc > 9) ? "0" + BoxNc.ToString() : "00" + BoxNc.ToString();
                        }
                        else if (item.idc_type == 1 && item.summary > 0)
                        {
                            int summaryValue = (int)item.summary;
                            int snp = int.Parse(operationData.partsnp);

                            counterNg = summaryValue % snp;
                            BoxNg = (summaryValue / snp) + 1;

                            tbCounterNg.Text = counterNg.ToString();
                            lbBoxNoNg.Text = (BoxNg > 9) ? "0" + BoxNg.ToString() : "00" + BoxNg.ToString();
                        }
                        else if (item.idc_type == 0 && item.summary == 0)
                        {
                            counterNc = 0;
                            BoxNc = 1;

                            tbCounterNc.Text = "0";
                            lbBoxNoNc.Text = "001";
                        }
                        else if (item.idc_type == 1 && item.summary == 0)
                        {
                            counterNg = 0;
                            BoxNg = 1;

                            tbCounterNg.Text = "0";
                            lbBoxNoNg.Text = "001";
                        }
                    }
                }
                else
                {
                    counterNg = 0;
                    BoxNg = 1;
                    counterNc = 0;
                    BoxNc = 1;

                    tbCounterNg.Text = "0";
                    lbBoxNoNg.Text = "001";
                    tbCounterNc.Text = "0";
                    lbBoxNoNc.Text = "001";
                }
            }*/

        }

        private async Task countProductplus()
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                string Datecur;
                string Datetomor;
                string Datetimecur;
                
                if (dateTime.Hour < 8)
                {
                    DateTime previousDay = dateTime.AddDays(-1).Date;

                    Datecur = previousDay.ToString("yyyy-MM-dd");
                    Datetomor = dateTime.ToString("yyyy-MM-dd");
                    Datetimecur = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    DateTime previousDay = dateTime.AddDays(+1).Date;

                    Datecur = dateTime.ToString("yyyy-MM-dd");
                    Datetomor = previousDay.ToString("yyyy-MM-dd");
                    Datetimecur = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                }

                var data = new
                {
                    Timecurr = Datetimecur,
                    Datecurr = Datecur,
                    Datetomor = Datetomor
                };
                //MessageBox.Show(data.ToString());

                var dataJson = JsonConvert.SerializeObject(data);
                dynamic responseData = await api.CurPostRequestAsync("Operation/get_WorkShoftTime/", dataJson);

                if (responseData.Status == "1")
                {
                    var dataTagFA = new
                    {
                        Tagfa = operationData.tagfa
                    };
                    var dataJsonTagFA = JsonConvert.SerializeObject(dataTagFA);
                    dynamic responseDataTagFA = await api.CurPostRequestAsync("Operation/get_ID_Tag_FA/", dataJsonTagFA);

                    // = responseDataTagFA.ifts_id;

                    var dataCount = new
                    {
                        tagfaid = responseDataTagFA.ifts_id,
                        stationid = LocationData.IdStation,
                        partdigit = idnamedigit,
                        workshift = responseData.mws_shift,
                        productcount = int.Parse(tbCounter.Text),
                        productrank = productrank,
                        productcheckcount = countPlus,
                        productDMC = dmcid,
                        counttime = chkTime,
                        login_user = Session.Userlogin,
                        isdt_id = operationData.isdt_id
                    };

                    //MessageBox.Show(dataCount.ToString());
                    //Console.WriteLine(dataCount);

                    var dataCountFA = JsonConvert.SerializeObject(dataCount);
                    dynamic responsedataCountFA = await api.CurPostRequestAsync("OperationIns/insert_countPlus", dataCountFA);

                    //Console.WriteLine(responsedataCountFA);

                    if (responsedataCountFA.Status == 1)
                    {
                        operationData.OperationCount.Push(responsedataCountFA.OperationId.ToString());

                        counter = int.Parse(tbCounter.Text);
                        counter++;
                        tbCounter.Text = counter.ToString();

                        // deley by station
                        await Task.Delay(LocationData.Delay * 1000);
                    }
                    else
                    {
                        MessageBox.Show("error system!!! : insert plus");
                    }
                }
                else
                {
                    MessageBox.Show("Error system!!! : Work Shit");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private async Task countProductdelete()
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                string Datecur;
                string Datetomor;
                string Datetimecur;

                if (dateTime.Hour < 8)
                {
                    DateTime previousDay = dateTime.AddDays(-1).Date;

                    Datecur = previousDay.ToString("yyyy-MM-dd");
                    Datetomor = dateTime.ToString("yyyy-MM-dd");
                    Datetimecur = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    DateTime previousDay = dateTime.AddDays(+1).Date;

                    Datecur = dateTime.ToString("yyyy-MM-dd");
                    Datetomor = previousDay.ToString("yyyy-MM-dd");
                    Datetimecur = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                }

                var data = new
                {
                    Timecurr = Datetimecur,
                    Datecurr = Datecur,
                    Datetomor = Datetomor
                };

                var dataJson = JsonConvert.SerializeObject(data);
                dynamic responseData = await api.CurPostRequestAsync("Operation/get_WorkShoftTime/", dataJson);

                if (responseData.Status == "1")
                {
                    var dataTagFA = new
                    {
                        Tagfa = operationData.tagfa
                    };
                    var dataJsonTagFA = JsonConvert.SerializeObject(dataTagFA);
                    dynamic responseDataTagFA = await api.CurPostRequestAsync("Operation/get_ID_Tag_FA/", dataJsonTagFA);

                    //IDTagfa = responseDataTagFA.ifts_id;

                    var dataCount = new
                    {
                        tagfaid = responseDataTagFA.ifts_id,
                        stationid = LocationData.IdStation,
                        partdigit = idnamedigit,
                        workshift = responseData.mws_shift,
                        productcount = int.Parse(tbCounter.Text),
                        productrank = productrank,
                        productcheckcount = countDel,
                        productDMC = dmcid,
                        counttime = chkTime,
                        login_user = Session.Userlogin,
                        isdt_id = operationData.isdt_id
                    };
                    Console.WriteLine("dataCount : " + dataCount);

                    var dataCountFA = JsonConvert.SerializeObject(dataCount);
                    dynamic responsedataCountFA = await api.CurPostRequestAsync("OperationIns/insert_countDel", dataCountFA);

                    if (responsedataCountFA.Status == 1)
                    {
                        
                        operationData.OperationCount.Pop();

                        counter = int.Parse(tbCounter.Text);
                        counter--;
                        tbCounter.Text = counter.ToString();

                        // deley by station
                        await Task.Delay(LocationData.Delay * 1000);
                    }
                    else
                    {
                        MessageBox.Show("error system");
                    }
                }
                else
                {
                    MessageBox.Show("Error system!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Text_chang()
        {
            //MessageBox.Show("ok chang textbox defect ");

            EventArgs emptyEventArgs = new EventArgs();
            tbCounter_TextChanged(this, emptyEventArgs);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public async Task finish()
        {
            var dataQRProductToGenQr = new
            {
                tagFaId = operationData.tagfaid,
            };

            var dataQRProductToGenQrJson = JsonConvert.SerializeObject(dataQRProductToGenQr);
            dynamic responseDataQRProductToGenQr = await api.CurPostRequestAsync("Operation/get_QRProductToGenQr/", dataQRProductToGenQrJson);

            //Console.WriteLine(responseDataQRProductToGenQr.ToString());

            if (responseDataQRProductToGenQr.Status == 1)
            {
                int numProduct = responseDataQRProductToGenQr.data.Count;
                /*foreach (var item in responseDataQRProductToGenQr.data)
                {
                    numProduct = item.
                }*/
                //MessageBox.Show("NUM : " + numProduct);


                string idproduct = "IODC_ID ";
                foreach (var item in responseDataQRProductToGenQr.data)
                {
                    idproduct += item.iodc_id + " ";
                }

                await GenQRCodeQgate(idproduct);
            }
            else
            {
                MessageBox.Show("Error No data detail");
            }
        }

        public async Task GenQRCodeQgate(string QrProduct)
        {
            Console.WriteLine("fun genqrcode");
            qgateScanTag qgateScanTag = new qgateScanTag();

            //MessageBox.Show(operationData.partnotagfa.Length.ToString());


            string spacePartNo = operationData.partnotagfa;
            for (int i = 0; spacePartNo.Count() < 25; i++)
            {
                spacePartNo += " ";
            }

            //MessageBox.Show(spacePartNo.Count().ToString());

            string spaceSNP = "";
            for (int i = 0; spaceSNP.Count() + operationData.partsnp.Count() < 6; i++)
            {
                spaceSNP += " ";
            }

            //MessageBox.Show(spacePartNo.Count().ToString());


            string tagQgate = String.Concat(operationData.partcodemaster, operationData.partline, operationData.partplantdate, operationData.partseqplan, spacePartNo, DateTime.Now.ToString("yyyyMMdd"), spaceSNP, tbCounter.Text, qgateScanTag.genLot(DateTime.Now),
                                        "                         ", DateTime.Now.ToString("yyyyMMdd"), operationData.partseqplan, operationData.partplant, lbBoxNo.Text);

            //Console.WriteLine(tagQgate);
            //Console.WriteLine(tagQgate.Count().ToString());

            var datachkQRQgate = new
            {
                tagQgate = tagQgate
            };

            var datachkQRQgateJson = JsonConvert.SerializeObject(datachkQRQgate);
            dynamic responsechkQRQgate = await api.CurPostRequestAsync("Operation/get_chkQrcodeQgate/", datachkQRQgateJson);

            if (responsechkQRQgate.Row == 0)
            {
                var dataINSQRQgate = new
                {
                    tagFAId = operationData.tagfaid,
                    tagQgate = tagQgate,
                    box = lbBoxNo.Text,
                    login_user = Session.Userlogin
                };

                var dataINSQRQgateJson = JsonConvert.SerializeObject(dataINSQRQgate);
                dynamic responseINSQRQgate = await api.CurPostRequestAsync("OperationIns/insert_TagQgateComplete/", dataINSQRQgateJson);

                //Console.WriteLine("result insert : " + responseINSQRQgate.ToString());

                if (responseINSQRQgate.Status == 1)
                {
                    //operationData.partnotagfa = "SB03S400004-B";
                    //string parameter = $"?partNumber={operationData.partnotagfa}";
                    //dynamic resultLOCATION = await api.CurGetRequestAsync("http://192.168.161.77/apiSystem/exp/getItemMaster", parameter);

                    //Console.WriteLine("get location : " + resultLOCATION);

                    string location = "test";
                    /*foreach (var itemLOCATION in resultLOCATION)
                    {
                        location = itemLOCATION.LOCATION;
                    }*/
                    Console.WriteLine("print tag");

                    PrintTag printTag = new PrintTag();
                    printTag.printTagQgate(" ", operationData.partnotagfa, operationData.partNoName, operationData.model, " ", lbBoxNo.Text, DateTime.Now, tagQgate, QrProduct, location, tbCounter.Text, operationData.partlotno, operationData.partworkshift, operationData.partline, LocationData.Phase);
                }
                else
                {
                    MessageBox.Show("Error System!!! : Insert QrCode Tag Qgate ");
                }
            }
            else
            {
                MessageBox.Show("Error System!!! : QrCode Tag Qgate นี้มีอยุ่เเล้ว");
            }

        }

        public async Task end()
        {
            //object[] CountDefect = new object[5];
            qgateScanTag scanTag = new qgateScanTag();

            //try
            //{
            DateTime dateTime = DateTime.Now;
            string Datecur;
            string Datetomor;
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

            var dataGetCountDefect = new
            {
                countDefectNCId = operationData.countDefectNCId,
                countDefectNGId = operationData.countDefectNGId
            };

            var dataGetCountDefectJson = JsonConvert.SerializeObject(dataGetCountDefect);
            dynamic responseDataGetCountDefect = await api.CurPostRequestAsync("Operation/get_printCountDefect/", dataGetCountDefectJson);

            //Console.WriteLine("response : " + responseDataGetCountDefect.ToString());

            var dateGetWi = new
            {
                qrTagFa = operationData.tagfa
            };
            var dateGetWiJson = JsonConvert.SerializeObject(dateGetWi);
            dynamic responseGetWi = await api.CurPostRequestAsync("Operation/get_wi/", dateGetWiJson);


            if (responseDataGetCountDefect.Status == 1)
            {
                foreach (var item in responseDataGetCountDefect.data)
                {
                    if (item.idc_type == 0)
                    {
                        //Console.WriteLine("NC defect");

                        var dateGetDefect = new
                        {
                            countID = operationData.countDefectNCId
                        };
                        var dateGetDefectJson = JsonConvert.SerializeObject(dateGetDefect);
                        dynamic responseGetDefect = await api.CurPostRequestAsync("Operation/get_printCountDefectTotal/", dateGetDefectJson);
                        // NC

                        //Console.WriteLine("responseGetWi : " + item);
                        if (responseGetWi.Status == 1)
                        {
                            string qrcodeDefect;
                            double loopPrintTagDefect = (double)item.idc_count / int.Parse(operationData.partsnp);

                            //var data = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(responseGetDefect);

                            string spacedefectQty = "";
                            for (int i = 1; spacedefectQty.Count() + operationData.partsnp.Count() <= 5; i++)
                            {
                                spacedefectQty += "0";
                            }

                            int startIndex = 0;
                            int endIndex = 0;
                            string qrDefectDetail = "";
                            int count = 0;
                            for (int i = 1; (int)Math.Ceiling(loopPrintTagDefect) >= i; i++)
                            {
                                Console.WriteLine("print NC");
                                qrcodeDefect = String.Concat("DF ", 2, " ", operationData.partline, " ", responseGetWi.wi, " ", scanTag.genLot(DateTime.Now),
                                                              " ", (i > 9) ? "0" + i : "00" + i, " ", spacedefectQty + operationData.partsnp, " ", operationData.partnotagfa);
                                //Console.WriteLine(qrcodeDefect);

                                startIndex = i * int.Parse(operationData.partsnp) - int.Parse(operationData.partsnp); //( i == 1)? 0 : i *  -snp
                                endIndex = startIndex + int.Parse(operationData.partsnp) - 1;

                                //Console.WriteLine($"starindex: {startIndex}");
                                //Console.WriteLine($"endindex: {endIndex}");

                                string json = responseGetDefect.data.ToString();
                                var data = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);

                                var countsByMdCode = data
                                    .Skip(startIndex) // ข้าม index ตามที่กำหนด
                                    .Take(endIndex - startIndex + 1) // เลือกข้อมูลตาม index ที่กำหนด
                                    .GroupBy(items => items["md_code"].ToString()) // กลุ่มข้อมูลตามค่าของ md_code
                                    .Select(group => new { MdCode = group.Key, Count = group.Count() }); // นับจำนวนรายการแยกตามค่าของ md_code พร้อมกับ index

                                // แสดงผลลัพธ์
                                foreach (var countByMdCode in countsByMdCode)
                                {
                                    qrDefectDetail += $"{ countByMdCode.MdCode} = {countByMdCode.Count}";
                                    if (qrDefectDetail != null)
                                    {
                                        qrDefectDetail += " | ";
                                    }
                                }

                                if (qrDefectDetail != null || qrDefectDetail == "")
                                {
                                    qrDefectDetail = qrDefectDetail.Substring(0, qrDefectDetail.Length - 3);
                                }
                                //Console.WriteLine(qrDefectDetail);

                                //operationData.partnotagfa = "SB03S400004-B";
                                /**/
                                string parameter = $"?partNumber={operationData.partnotagfa}";
                                dynamic resultLOCATION = await api.CurGetRequestAsync("http://192.168.161.77/apiSystem/exp/getItemMaster", parameter);
                                string location = null;
                                foreach (var itemLOCATION in resultLOCATION)
                                {
                                    location = itemLOCATION.LOCATION;
                                }

                                var dateInsDefect = new
                                {
                                    countID = operationData.countDMCDefectNGId,
                                    CodeDefect = qrcodeDefect,
                                    box = (i > 9) ? "0" + i : "00" + i,
                                    DefectQrDetail = qrDefectDetail,
                                    login_user = Session.Userlogin
                                };

                                var dateInsDefectJson = JsonConvert.SerializeObject(dateInsDefect);
                                dynamic responseInsDefect = await api.CurPostRequestAsync("OperationIns/insert_TagDefect/", dateInsDefectJson);

                                if (responseInsDefect.Status == 1)
                                {
                                    //string location = null;

                                    PrintTagDefect TagDefect = new PrintTagDefect();
                                    TagDefect.printTagDefect(qrcodeDefect, qrDefectDetail, "NC", (i > 9) ? "0" + i : "00" + i, location, (loopPrintTagDefect*i).ToString(),
                                                            operationData.partnotagfa, operationData.partNoName, operationData.model, operationData.partline, operationData.partworkshift, DateTime.Now, LocationData.Phase);/**/

                                    qrDefectDetail = "";
                                }
                                else
                                {
                                    MessageBox.Show("Error system !!! : insert tag defect unsuccessful");
                                }
                            }
                        }

                    }
                    else
                    {
                        //Console.WriteLine("NG defect");
                        var dateGetDefect = new
                        {
                            countID = operationData.countDefectNGId
                        };
                        var dateGetDefectJson = JsonConvert.SerializeObject(dateGetDefect);
                        dynamic responseGetDefect = await api.CurPostRequestAsync("Operation/get_printCountDefectTotal/", dateGetDefectJson);
                        //NC

                        //Console.WriteLine("responseGetWi : " + item);
                        if (responseGetWi.Status == 1)
                        {
                            string qrcodeDefect;
                            double loopPrintTagDefect = (double)item.idc_count / int.Parse(operationData.partsnp);

                            //var data = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(responseGetDefect);

                            string spacedefectQty = "";
                            for (int i = 1; spacedefectQty.Count() + operationData.partsnp.Count() <= 5; i++)
                            {
                                spacedefectQty += "0";
                            }


                            int startIndex = 0;
                            int endIndex = 0;
                            string qrDefectDetail = "";
                            int count = 0;
                            for (int i = 1; (int)Math.Ceiling(loopPrintTagDefect) >= i; i++)
                            {
                                Console.WriteLine("print NG");
                                qrcodeDefect = String.Concat("DF ", 1, " ", operationData.partline, " ", responseGetWi.wi, " ", scanTag.genLot(DateTime.Now),
                                                              " ", (i > 9) ? "0" + i : "00" + i, " ", spacedefectQty + operationData.partsnp, " ", operationData.partnotagfa);
                                //Console.WriteLine(qrcodeDefect);

                                startIndex = i * int.Parse(operationData.partsnp) - int.Parse(operationData.partsnp); //( i == 1)? 0 : i *  -snp
                                endIndex = startIndex + int.Parse(operationData.partsnp) - 1;

                                //Console.WriteLine($"starindex: {startIndex}");
                                //Console.WriteLine($"endindex: {endIndex}");

                                string json = responseGetDefect.data.ToString();
                                var data = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);

                                var countsByMdCode = data
                                    .Skip(startIndex) // ข้าม index ตามที่กำหนด
                                    .Take(endIndex - startIndex + 1) // เลือกข้อมูลตาม index ที่กำหนด
                                    .GroupBy(items => items["md_code"].ToString()) // กลุ่มข้อมูลตามค่าของ md_code
                                    .Select(group => new { MdCode = group.Key, Count = group.Count() }); // นับจำนวนรายการแยกตามค่าของ md_code พร้อมกับ index

                                // แสดงผลลัพธ์
                                foreach (var countByMdCode in countsByMdCode)
                                {
                                    qrDefectDetail += $"{ countByMdCode.MdCode} = {countByMdCode.Count}";
                                    if (qrDefectDetail != null)
                                    {
                                        qrDefectDetail += " | ";
                                    }
                                }

                                if (qrDefectDetail != null || qrDefectDetail == "")
                                {
                                    qrDefectDetail = qrDefectDetail.Substring(0, qrDefectDetail.Length - 3);
                                }
                                //Console.WriteLine(qrDefectDetail);

                                //operationData.partnotagfa = "SB03S400004-B";
                                /**/
                                string parameter = $"?partNumber={operationData.partnotagfa}";
                                dynamic resultLOCATION = await api.CurGetRequestAsync("http://192.168.161.77/apiSystem/exp/getItemMaster", parameter);
                                string location = null;
                                foreach (var itemLOCATION in resultLOCATION)
                                {
                                    location = itemLOCATION.LOCATION;
                                }

                                var dateInsDefect = new
                                {
                                    countID = operationData.countDMCDefectNGId,
                                    CodeDefect = qrcodeDefect,
                                    box = (i > 9) ? "0" + i : "00" + i,
                                    DefectQrDetail = qrDefectDetail,
                                    login_user = Session.Userlogin
                                };

                                var dateInsDefectJson = JsonConvert.SerializeObject(dateInsDefect);
                                dynamic responseInsDefect = await api.CurPostRequestAsync("OperationIns/insert_TagDefect/", dateInsDefectJson);

                                if (responseInsDefect.Status == 1)
                                {
                                    PrintTagDefect TagDefect = new PrintTagDefect();
                                    TagDefect.printTagDefect(qrcodeDefect, qrDefectDetail, "NG", (i > 9) ? "0" + i : "00" + i, location, (loopPrintTagDefect * i).ToString(),
                                                            operationData.partnotagfa, operationData.partNoName, operationData.model, operationData.partline, operationData.partworkshift, DateTime.Now, LocationData.Phase);/**/

                                    qrDefectDetail = "";
                                }
                                else
                                {
                                    MessageBox.Show("Error system !!! : insert tag defect unsuccessful");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Error System : Get wi ( Print Defect Error )");
            }
        }

    }
}

// get defect อันเก่า
/*DateTime dateTime = DateTime.Now;
            string Datecur;
            string Datetomor;
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

            var data = new
            {
                StationId = LocationData.IdStation,
                LotCurr = operationData.lotcur,
                PartNo = operationData.partnotagfa,
                Datecurr = Datecur,
                Datetomor = Datetomor,

            };

            var dataJson = JsonConvert.SerializeObject(data);
            dynamic responseData = await api.CurPostRequestAsync("Operation/get_DefectNum/", dataJson);


            if (responseData.Status == 1)
            {
                foreach (var item in responseData.data)
                {
                    if (item.idd_type == 0 && item.summary > 0)
                    {
                        int summaryValue = (int)item.summary.Value;
                        int snp = int.Parse(operationData.partsnp);

                        //Console.WriteLine("summaryValue : " + summaryValue);
                        //Console.WriteLine("snp : " + snp);

                        counterNc = summaryValue % snp;
                        BoxNc = (summaryValue / snp) + 1;

                        //Console.WriteLine("counterNc : " + counterNc);
                        //Console.WriteLine("BoxNc : " + BoxNc);

                        tbCounterNc.Text = counterNc.ToString();
                        lbBoxNoNc.Text = (BoxNc > 9) ? "0" + BoxNc.ToString() : "00" + BoxNc.ToString();

                    }
                    else if (item.idd_type == 1 && item.summary > 0)
                    {
                        int summaryValue = (int)item.summary.Value;
                        int snp = int.Parse(operationData.partsnp);

                        //Console.WriteLine("summaryValue : " + summaryValue);
                        //Console.WriteLine("snp : " + snp);

                        counterNg = summaryValue % snp;
                        BoxNg = (summaryValue / snp) + 1;

                        //Console.WriteLine("counterNg : " + counterNg);
                        //Console.WriteLine("BoxNg : " + BoxNg);

                        tbCounterNg.Text = counterNg.ToString();
                        lbBoxNoNg.Text = (BoxNg > 9) ? "0" + BoxNg.ToString() : "00" + BoxNg.ToString();

                    }
                    else if (item.idd_type == 0 && item.summary == 0)
                    {
                        counterNc = 0;
                        BoxNc = 1;

                        tbCounterNc.Text = "0";
                        lbBoxNoNc.Text = "001";
                    }
                    else if (item.idd_type == 1 && item.summary == 0)
                    {
                        counterNg = 0;
                        BoxNg = 1;

                        tbCounterNg.Text = "0";
                        lbBoxNoNg.Text = "001";
                    }
                }
            }
            else
            {
                counterNg = 0;
                BoxNg = 1;
                counterNc = 0;
                BoxNc = 1;

                tbCounterNg.Text = "0";
                lbBoxNoNg.Text = "001";
                tbCounterNc.Text = "0";
                lbBoxNoNc.Text = "001";
            }*/