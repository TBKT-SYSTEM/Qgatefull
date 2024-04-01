using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QGate_system
{
    public partial class qgateOperation : Form
    {
        public static qgateOperation instance;
        public TextBox setTextCountProduct;
        public TextBox setTextCountNc;
        public Label setTextCountNcSerial;
        public TextBox setTextCountNg;
        public Label setTextCountNgSerial;
        public Label setTextlbBoxNoNg;
        public Label setTextlbBoxNoNc;

        QGate_system.API.API api = new QGate_system.API.API();

        Session Session = Session.Instance;
        LocationData LocationData = LocationData.Instance;
        operationData operationData = operationData.Instance;

        qgateScanTag scanTag = new qgateScanTag();


        /*string[] getsubstringname = new string[6];
        int[] getpartsubstart = new int[6];
        int[] getpartsubend = new int[6];
        int[] getpartsubnum = new int[6];*/

        private string PartNoSub;
        private string PartDateSub;
        private string PartLotSub;
        private string PartShiftSub;
        private string PartLineSub;
        private string PartSerialNoSub;

        private int counter = 0;
        private int counterNc = 0;
        private int counterNg = 0;
        private int BoxNc = 0;
        private int BoxNg = 0;

        private int Ms = 0;
        private int s = 0;

        private string productrank = "A";
        private int chkTime = 0;
        private int countPlus = 1;
        private int countDel = -1;

        public List<string> qrCodelist = new List<string>();

        public qgateOperation()
        {
            InitializeComponent();
            timer1.Start();

            instance = this;

            setTextCountProduct = tbCounter;
            setTextCountNc = tbCounterNc;
            setTextCountNg = tbCounterNg;

            counter = int.Parse(setTextCountProduct.Text);
            counterNc = int.Parse(setTextCountNc.Text);
            counterNg = int.Parse(setTextCountNg.Text);

            setTextCountNcSerial = lbSerialNoNc;
            setTextCountNgSerial = lbSerialNoNg;
            setTextlbBoxNoNc = lbBoxNoNc;
            setTextlbBoxNoNg = lbBoxNoNg;
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

        private async void qgateOperation_Load(object sender, EventArgs e)
        {

            lbNc.Enabled = false;
            lbNg.Enabled = false;

            pbFinish.Hide();
            pbEnd.Hide();


            /*tbCounterNg.Text = "0";
            lbBoxNoNg.Text = "001";
            tbCounterNc.Text = "0";
            lbBoxNoNc.Text = "001";*/


            var data = new
            {
                partNo = LocationData.PartNo,
                line_cd = operationData.partline
            };

            var dataJson = JsonConvert.SerializeObject(data);
            dynamic responseData = await api.CurPostRequestAsync("Operation/get_model_partNo/", dataJson);

            operationData.model = responseData.MODEL;
            operationData.partNoName = responseData.PartName;

            //// input information
            lbZone.Text = LocationData.Zone;
            lbStation.Text = LocationData.Station;
            lbPartNo.Text = (LocationData.PartNo.Length <= 15) ? LocationData.PartNo : LocationData.PartNo.Substring(0, 15) + "....";
            //lbPartNoName.Text = "test";
            lbPartNoName.Text = (operationData.partNoName.Length <= 15) ? operationData.partNoName : operationData.partNoName.Substring(0, 15) + "....";
            lbProductDate.Text = operationData.partactualdate1;
            lbModel.Text = operationData.model;
            lbLotNo.Text = operationData.lotcur;
            lbSnp.Text = operationData.partsnp;
            lbBoxNo.Text = operationData.boxNo.ToString();
            lbBoxNo.Text = (operationData.boxNo > 9) ? "0" + operationData.boxNo : "00" + operationData.boxNo;

            //await getNumAndBoxDefect();
        }

        private async void ScanQrSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string qrProduct = tbQrSerial.Text;
                chkTime = (chkTime == 0) ? s : s - chkTime;

                //MessageBox.Show(qrProduct);

                tbQrSerial.Hide();
                pbFinish.Enabled = false;
                pbEnd.Enabled = false;
                lbNc.Enabled = false;
                lbNg.Enabled = false;

                await subStringQrProduct(qrProduct);
                await Task.Delay(LocationData.Delay * 1000);

                if (counter == int.Parse(operationData.partsnp))
                {
                    tbQrSerial.Hide();
                    pbFinish.Enabled = true;
                    pbFinish.Show();
                    pbEnd.Enabled = true;
                    pbEnd.Show();
                }
                else if (counter < int.Parse(operationData.partsnp) && counter > 0)
                {
                    tbQrSerial.Show();
                    pbEnd.Enabled = true;
                    pbEnd.Show();
                    tbQrSerial.Focus();
                }
                else
                {
                    tbQrSerial.Show();
                    tbQrSerial.Focus();
                }
            }
        }

        private async Task subStringQrProduct(string qrcodeDMC)
        {
            try
            {/**/
                //MessageBox.Show(qrcodeDMC);
                if (qrcodeDMC != null)
                {
                    var data = new
                    {
                        partNo = LocationData.PartNo,
                    };

                    var dataJson = JsonConvert.SerializeObject(data);
                    dynamic responseData = await api.CurPostRequestAsync("Operation/get_DMCSubsting/", dataJson);

                    if (responseData.Status == 1)
                    {
                        //VBint i = 0;

                        Console.WriteLine("responseData " + responseData);
                        if (qrcodeDMC.Length >= int.Parse(responseData.mdtd_end.ToString()))
                        {
                            PartNoSub = qrcodeDMC.Substring(int.Parse(responseData.mdtd_start.ToString()), int.Parse(responseData.mdtd_end.ToString()));
                            await checkcodedmc(PartNoSub, qrcodeDMC);
                        }
                        else
                        {
                            MessageBox.Show("Scan ไม่ถูก");
                        }



                        /*foreach (var item in responseData.DMCSubsting)
                        {
                            getsubstringname[i] = item.mdd_name;
                            getpartsubstart[i] = item.mdtd_start;
                            getpartsubend[i] = item.mdtd_end;
                            getpartsubnum[i] = item.mdtd_num_substring;
                            i++;
                        }

                        if (qrcodeDMC.Length == getpartsubend[5])
                        {
                            PartNoSub = qrcodeDMC.Substring(getpartsubstart[0], getpartsubnum[0]);
                            PartDateSub = qrcodeDMC.Substring(getpartsubend[0], getpartsubnum[1]);
                            PartLotSub = qrcodeDMC.Substring(getpartsubend[1], getpartsubnum[2]);
                            PartShiftSub = qrcodeDMC.Substring(getpartsubend[2], getpartsubnum[3]);
                            PartLineSub = qrcodeDMC.Substring(getpartsubend[3], getpartsubnum[4]);
                            PartSerialNoSub = qrcodeDMC.Substring(getpartsubend[4], getpartsubnum[5]);

                            await checkcodedmc(PartNoSub, qrcodeDMC);
                        }
                        else
                        {
                            // เพื่อให้ chang textbox ทำงาน
                            tbCounter.Text = tbCounter.Text;
                            tbQrSerial.Clear();
                            MessageBox.Show("Error system : DMC ไม่ตรง ( digit DMC more / less )");
                        }*/
                    }
                    else
                    {
                        tbCounter.Text = tbCounter.Text;
                        tbQrSerial.Clear();
                        MessageBox.Show("Error system : No DMC ( ไม่มีข้อมูล DMC นี้ )");
                    }

                }
                else
                {
                    tbQrSerial.Clear();
                    MessageBox.Show("Error system : Scan correctly!! ()");
                }
                    
            }
            catch (Exception ex)
            {
                tbCounter.Text = tbCounter.Text;
                tbQrSerial.Clear();
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }/**/
        }

        private async Task checkcodedmc(string PartNo, string qrcodeDMC)
        {
            var data = new
            {
                partNo = LocationData.PartNo,
            };

            var dataJson = JsonConvert.SerializeObject(data);
            dynamic responseData = await api.CurPostRequestAsync("Operation/get_DMCbyPartNo/", dataJson);
            //Console.WriteLine(responseData);

            //เช็คว่า part no นี้มีรหัส dmc อะไร 

            //Console.WriteLine(responseData.mpn_dmc_check);

            if (responseData.Status == 1)
            {
                //Console.WriteLine("ok Chk DMC ");

                if (responseData.mpn_dmc_check == PartNo)
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

                        var dataWorkShoft = new
                        {
                            Timecurr = Datetimecur,
                            Datecurr = Datecur,
                            Datetomor = Datetomor
                        };
                        //MessageBox.Show(data.ToString());

                        var dataJsonWorkShoft = JsonConvert.SerializeObject(dataWorkShoft);
                        dynamic responseDataWorkShoft = await api.CurPostRequestAsync("Operation/get_WorkShoftTime/", dataJsonWorkShoft);

                        if (responseDataWorkShoft.Status == "1")
                        {
                            operationData.partworkshift = responseDataWorkShoft.mws_shift;
                            var datapartNoName = new
                            {
                                partNo = operationData.partnotagfa,
                            };
                            //MessageBox.Show(data.ToString());

                            var dataJsonpartNoName = JsonConvert.SerializeObject(datapartNoName);
                            dynamic responseDatapartNoName = await api.CurPostRequestAsync("Operation/get_TypeDMC/", dataJsonpartNoName);

                            if (responseDatapartNoName.Status == 0)
                            {
                                MessageBox.Show("Error System!!! : get type DMC");
                            }
                            Console.WriteLine(responseDatapartNoName); //responseDatapartNoName.mdt_id

                            var dataTagFA = new
                            {
                                Tagfa = operationData.tagfa
                            };
                            var dataJsonTagFA = JsonConvert.SerializeObject(dataTagFA);
                            dynamic responseDataTagFA = await api.CurPostRequestAsync("Operation/get_ID_Tag_FA/", dataJsonTagFA);
                            if (responseDataTagFA.Status == 0)
                            {
                                MessageBox.Show("Error System!!! : get id tag fa");
                            }

                            //Console.WriteLine(responseDataTagFA); //responseDataTagFA.ifts_id

                            var dataQrCodeDMC = new
                            {
                                QrCodeDMC = qrcodeDMC
                            };
                            var dataJsonQrCodeDMC = JsonConvert.SerializeObject(dataQrCodeDMC);
                            dynamic responseDataQrCodeDMC = await api.CurPostRequestAsync("Operation/get_QrCodeDMC/", dataJsonQrCodeDMC);
                            //MessageBox.Show(responseDataQrCodeDMC.ToString());

                            if (responseDataQrCodeDMC.Row == 0)
                            {
                                counter++;
                                tbCounter.Text = counter.ToString();

                                var dataInsqrcodeDMC = new
                                {
                                    tagfaid = responseDataTagFA.ifts_id,
                                    stationid = LocationData.IdStation,
                                    partdigit = responseDatapartNoName.mdt_id,
                                    workshift = responseDataWorkShoft.mws_shift,
                                    productcount = counter,
                                    productrank = productrank,
                                    productcheckcount = countPlus,
                                    productDMC = qrcodeDMC,
                                    counttime = chkTime,
                                    login_user = Session.Userlogin,
                                    isdt_id = operationData.isdt_id
                                };

                                var dataJsonInsqrcodeDMC = JsonConvert.SerializeObject(dataInsqrcodeDMC);
                                dynamic responseDataInsqrcodeDMC = await api.CurPostRequestAsync("OperationIns/insert_QrCodeDMC/", dataJsonInsqrcodeDMC);

                                //MessageBox.Show(responseDataInsqrcodeDMC.ToString());
                                Console.WriteLine(responseDataInsqrcodeDMC.ToString());

                                if (responseDataInsqrcodeDMC.Status == 1)
                                {
                                    //Console.WriteLine(responseDataInsqrcodeDMC.OperationId);

                                    //qrCodeDMC.Push(qrcodeDMC);
                                    qrCodelist.Add(qrcodeDMC);
                                    operationData.OperationCountDMC.Push(responseDataInsqrcodeDMC.OperationId.ToString());
                                }
                                else
                                {
                                    counter--;
                                    tbCounter.Text = counter.ToString();
                                    // เพื่อให้ chang textbox ทำงาน
                                    tbCounter.Text = tbCounter.Text;
                                    tbQrSerial.Clear();
                                    MessageBox.Show("error system : insert QrCodeDMC ");
                                }

                            }
                            else
                            {
                                tbCounter.Text = tbCounter.Text;
                                tbQrSerial.Clear();
                                MessageBox.Show("สแกนซ้ำนะจ๊ะ");
                            }
                        }
                        else
                        {
                            tbCounter.Text = tbCounter.Text;
                            tbQrSerial.Clear();
                            MessageBox.Show("Error system!!! : Work Shit");
                        }
                    }
                    catch (Exception ex)
                    {
                        tbCounter.Text = tbCounter.Text;
                        tbQrSerial.Clear();
                        Console.WriteLine(ex.Message);
                        MessageBox.Show(ex.Message);
                    }
                }/**/
                else
                {
                    tbCounter.Text = tbCounter.Text;
                    tbQrSerial.Clear();
                    MessageBox.Show("Error system!!! : PartNo not match Code DMC");
                }
            }
            else
            {
                tbCounter.Text = tbCounter.Text;
                tbQrSerial.Clear();
                Console.WriteLine("Error System : PartNo No DMC");
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

        private void lbNg_Click(object sender, EventArgs e)
        {

            qgateDefectNg formDefectNg = new qgateDefectNg();

            formDefectNg.Namedefect = "DMC CODE : ";
            formDefectNg.qrcodeDMC = qrCodelist[counter - 1];
            formDefectNg.CountBoxDefect = BoxNg;

            formDefectNg.CountProduct = int.Parse(tbCounter.Text);
            formDefectNg.CountDefect = int.Parse(tbCounterNg.Text);

            formDefectNg.Show();
        }

        private void lbNc_Click(object sender, EventArgs e)
        {
            //foreach (string item in qrCodelist)
            //{
            //    Console.WriteLine("data array :" + item);
            //}
            //Console.WriteLine("data array"+qrCodelist[counter-1].ToString());
            //MessageBox.Show(counter.ToString());
            //MessageBox.Show("count" + counter.ToString());
            //MessageBox.Show(qrCodelist[counter].ToString());

            qgateDefectNc formDefectNc = new qgateDefectNc();

            formDefectNc.Namedefect = "DMC CODE : ";
            //formDefectNc.qrcodeDMC = qrCodeDMC;
            formDefectNc.qrcodeDMC = qrCodelist[counter - 1];
            formDefectNc.CountBoxDefect = BoxNc;

            formDefectNc.CountProduct = int.Parse(tbCounter.Text);
            formDefectNc.CountDefect = int.Parse(tbCounterNc.Text);

            formDefectNc.Show();
        }

        private async void tbCounter_TextChanged(object sender, EventArgs e)
        {
            tbQrSerial.Clear();
            await Task.Delay(LocationData.Delay * 1000);

            /*if (int.Parse(tbCounterNc.Text) == int.Parse(operationData.partsnp))//counterNc 
            {
                int boxNoNc = int.Parse(lbBoxNoNc.Text) + 1;
                tbCounterNc.Text = "0";
                lbBoxNoNc.Text = (boxNoNc > 9) ? "0" + boxNoNc.ToString() : "00" + boxNoNc.ToString();
            }

            if (int.Parse(tbCounterNg.Text) == int.Parse(operationData.partsnp))//counterNg
            {
                int boxNoNg = int.Parse(lbBoxNoNg.Text) + 1;
                tbCounterNg.Text = "0";
                lbBoxNoNg.Text = (boxNoNg > 9) ? "0" + boxNoNg.ToString() : "00" + boxNoNg.ToString();
            }*/

            if (int.Parse(tbCounter.Text) < 0)
            {
                pbFinish.Hide();
                pbEnd.Hide();
                tbQrSerial.Show();
                tbQrSerial.Focus();
            }
            else if (int.Parse(tbCounter.Text) == int.Parse(operationData.partsnp))
            {
                pbFinish.Show();
                pbEnd.Show();
                tbQrSerial.Hide();
            }
            else
            {
                pbFinish.Hide();
                pbEnd.Show();
                tbQrSerial.Show();
                tbQrSerial.Focus();
            }


            if (int.Parse(tbCounter.Text) > 0)
            {
                lbNc.Enabled = true;
                lbNg.Enabled = true;
            }
            else
            {
                lbNc.Enabled = false;
                lbNg.Enabled = false;
            }
        }
        
        public void Text_chang()
        {
            EventArgs emptyEventArgs = new EventArgs();
            tbCounter_TextChanged(this, emptyEventArgs);

        }

        public async Task getNumAndBoxDefect()
        {
            try
            {
                Console.WriteLine("DMCDefectNCId" + string.IsNullOrEmpty(operationData.countDMCDefectNCId));
                Console.WriteLine("DMCDefectNGId" + string.IsNullOrEmpty(operationData.countDMCDefectNGId));
                if (string.IsNullOrEmpty(operationData.countDMCDefectNCId) && string.IsNullOrEmpty(operationData.countDMCDefectNGId))
                {
                    //MessageBox.Show("Type Defect Null");

                    var dataGetLogchkboxDefect = new
                    {
                        lotno_curr = scanTag.genLot(DateTime.Now),
                        partNo = operationData.partnotagfa
                    };
                    //Console.WriteLine(dataGetLogchkboxDefect);

                    var dataGetLogchkboxDefectJson = JsonConvert.SerializeObject(dataGetLogchkboxDefect);
                    dynamic responsedataGetLogchkboxDefect = await api.CurPostRequestAsync("Operation/get_boxDefect/", dataGetLogchkboxDefectJson);
                    //Console.WriteLine("responsedataGetLogchkboxDefect : " + responsedataGetLogchkboxDefect);

                    if (responsedataGetLogchkboxDefect.Status == 1) 
                    {
                        //Console.WriteLine("responsedataGetLogchkboxDefect : " + responsedataGetLogchkboxDefect.data);
                        string box;
                        string boxNoString;
                        foreach (var item in responsedataGetLogchkboxDefect.data)
                        {
                            boxNoString = item.lcbnd_box_no.ToString();
                            box = (int.Parse(boxNoString) + 1 > 9) ? "0" + (int.Parse(boxNoString) + 1).ToString() : "00" + (int.Parse(boxNoString) + 1).ToString();
                            if (item.lcbnd_type == 1)
                            {
                                lbBoxNoNg.Text = box;
                            }
                            else if (item.lcbnd_type == 0)
                            {
                                lbBoxNoNc.Text = box;
                            }
                            else
                            {
                                MessageBox.Show("Error System!!! : data type db (log chk box defect)");
                            }

                            var dataInsLogchkboxDefect = new
                            {
                                lotNo = scanTag.genLot(DateTime.Now),
                                partNo = operationData.partnotagfa,
                                boxDefect = box,
                                typeDefect = item.lcbnd_type, 
                                login_user = Session.Userlogin
                            };
                            //Console.WriteLine(dataGetLogchkboxDefect);

                            var dataInsLogchkboxDefectJson = JsonConvert.SerializeObject(dataInsLogchkboxDefect);
                            dynamic responseInsLogchkboxDefectJson = await api.CurPostRequestAsync("OperationIns/insert_log_chk_BoxNo_Defect/", dataInsLogchkboxDefectJson);

                            if (responseInsLogchkboxDefectJson.Status != 1)
                            {
                                MessageBox.Show("Error system!!! : insert log chk box defect");
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


                        for (int i = 0; i <= 1; i++ )
                        {
                            var dataInsLogchkboxDefect = new
                            {
                                lotNo = scanTag.genLot(DateTime.Now),
                                partNo = operationData.partnotagfa,
                                boxDefect = "1",
                                typeDefect = i,
                                login_user = Session.Userlogin
                            };
                            //Console.WriteLine(dataGetLogchkboxDefect);

                            var dataInsLogchkboxDefectJson = JsonConvert.SerializeObject(dataInsLogchkboxDefect);
                            dynamic responseInsLogchkboxDefectJson = await api.CurPostRequestAsync("OperationIns/insert_log_chk_BoxNo_Defect/", dataInsLogchkboxDefectJson);

                            if (responseInsLogchkboxDefectJson.Status != 1)
                            {
                                MessageBox.Show("Error system!!! : insert log chk box defect");
                            }
                        }
                        


                    }
                }
                else
                {
                    //MessageBox.Show("Type Defect Not Null");
                    var data = new
                    {
                        CountDefectNCId = (string.IsNullOrEmpty(operationData.countDMCDefectNCId))? "null" : operationData.countDMCDefectNCId,
                        CountDefectNGId = (string.IsNullOrEmpty(operationData.countDMCDefectNGId))? "null" : operationData.countDMCDefectNGId
                    };

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
                                lbBoxNoNc.Text = item.Box;
                            }
                            else if (item.idc_type == 0 && item.summary == 0)
                            {
                                tbCounterNc.Text = item.summary;
                                lbBoxNoNc.Text = item.Box;
                            }
                            else if (item.idc_type == 1 && item.summary > 0)
                            {
                                tbCounterNg.Text = item.summary;
                                lbBoxNoNg.Text = item.Box;
                            }
                            else if (item.idc_type == 1 && item.summary == 0)
                            {
                                tbCounterNg.Text = item.summary;
                                lbBoxNoNg.Text = item.Box;
                            }



                            /*foreach (var item in responseData.data)
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
                            }*/
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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
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

        private void pbBackToScan_Click(object sender, EventArgs e)
        {
            /*string spacePartNo = operationData.partnotagfa;
            for (int i = 0; spacePartNo.Count() < 25; i++)
            {
                spacePartNo += " ";
            }

            string spaceSNP = "";
            for (int i = 0; spaceSNP.Count() + int.Parse(operationData.partsnp) < 6; i++)
            {
                spacePartNo += " ";
            }

            MessageBox.Show(spacePartNo.Count().ToString());

            string test = String.Concat(operationData.partcodemaster, operationData.partline, operationData.partplantdate, operationData.partseqplan, spacePartNo, DateTime.Now.ToString("yyyyMMdd"), spaceSNP, operationData.partsnp, operationData.lotcur );

            MessageBox.Show(test);*/



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

        // print tag
        public async Task GenQRCodeQgate(string QrProduct)
        {
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
                Console.WriteLine("dataINSQRQgate" + dataINSQRQgate);

                var dataINSQRQgateJson = JsonConvert.SerializeObject(dataINSQRQgate);
                dynamic responseINSQRQgate = await api.CurPostRequestAsync("OperationIns/insert_TagQgateComplete/", dataINSQRQgateJson);

                //Console.WriteLine("result insert : " + responseINSQRQgate.ToString());

                if (responseINSQRQgate.Status == 1)
                {
                    //operationData.partnotagfa = "SB03S400004-B";
                    /**/
                    string parameter = $"?partNumber={operationData.partnotagfa}";
                    dynamic resultLOCATION = await api.CurGetRequestAsync("http://192.168.161.77/apiSystem/exp/getItemMaster", parameter);

                    if (resultLOCATION == null)
                    {
                        MessageBox.Show("Error System!!! : get location");
                    }

                    //Console.WriteLine("get location : " + resultLOCATION);

                    string location = null;
                    foreach (var itemLOCATION in resultLOCATION)
                    {
                        location = itemLOCATION.LOCATION;
                    }


                    //string location = null;

                    PrintTag printTag = new PrintTag();
                    printTag.printTagQgate(" ", operationData.partnotagfa, operationData.partNoName, operationData.model, " ", lbBoxNo.Text, DateTime.Now, tagQgate, QrProduct, location, tbCounter.Text, operationData.partlotno, operationData.partworkshift, operationData.partline, (operationData.partline.Substring(0,2) == "K1") ? "10" : "8");

                    

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

        // print tag 
        private async void pbEnd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("end");
            if(int.Parse(tbCounter.Text) > 0)
            {
                await finish();
            }

            if ( int.Parse(tbCounterNc.Text) > 0 || int.Parse(tbCounterNg.Text) > 0)
            {
                await end();
            }

            this.Hide();
            operationData.countDMCDefectNGId = "";
            operationData.countDMCDefectNCId = "";

            List<Form> formsToClose = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                formsToClose.Add(form);
            }
            foreach (Form form in formsToClose)
            {
                form.Hide();
            }
            
            qgateSelectMenu SelectMenu = new qgateSelectMenu();
            EventArgs emptyEventArgs = new EventArgs();
            SelectMenu.pbLogout_Click(this, emptyEventArgs);

            //qgateLogin login = new qgateLogin();
            //login.Show();
        }

        public async Task end()
        {
            try
            {
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
                    CountDefectNCId = (string.IsNullOrEmpty(operationData.countDMCDefectNCId)) ? "null" : operationData.countDMCDefectNCId,
                    CountDefectNGId = (string.IsNullOrEmpty(operationData.countDMCDefectNGId)) ? "null" : operationData.countDMCDefectNGId
                };

                Console.WriteLine("dataGetCountDefect : " + dataGetCountDefect);

                var dataGetCountDefectJson = JsonConvert.SerializeObject(dataGetCountDefect);
                dynamic responseDataGetCountDefect = await api.CurPostRequestAsync("Operation/get_printCountDefect/", dataGetCountDefectJson);

                //Console.WriteLine("responseDataGetCountDefect : " + responseDataGetCountDefect.ToString());

                var dateGetWi = new
                {
                    qrTagFa = operationData.tagfa
                };
                //Console.WriteLine(dateGetWi);
                var dateGetWiJson = JsonConvert.SerializeObject(dateGetWi);
                dynamic responseGetWi = await api.CurPostRequestAsync("Operation/get_wi/", dateGetWiJson);

                //Console.WriteLine(responseGetWi);

                if (responseDataGetCountDefect.Status == 1)
                {
                    foreach (var item in responseDataGetCountDefect.data)
                    {
                        if (item.idc_type == 0)
                        {
                            Console.WriteLine("NC defect");

                            ////#### ตรงนี้ต่อ ####

                            var dateGetDefect = new
                            {
                                countID = operationData.countDMCDefectNCId
                            };
                            var dateGetDefectJson = JsonConvert.SerializeObject(dateGetDefect);
                            dynamic responseGetDefect = await api.CurPostRequestAsync("Operation/get_printCountDefectTotal/", dateGetDefectJson);

                            if (responseGetDefect.Status ==  1)
                            {
                                string qrDefectDetail = "";
                                string location = "";
                                string qrcodeDefect = "";
                                string spacedefectQty = "";
                                string spaceWi = "";
                                int CountTotalDefect = int.Parse(responseGetDefect.total.ToString());
                                foreach (var itemGetdefect in responseGetDefect.data)
                                {
                                    qrDefectDetail += $"{ itemGetdefect.md_code} = {itemGetdefect.sum}";
                                    if (qrDefectDetail != null)
                                    {
                                        qrDefectDetail += " | ";
                                    }
                                }
                                if (qrDefectDetail != null || qrDefectDetail == "")
                                {
                                    qrDefectDetail = qrDefectDetail.Substring(0, qrDefectDetail.Length - 3);
                                }

                                string parameter = $"?partNumber={operationData.partnotagfa}";
                                dynamic resultLOCATION = await api.CurGetRequestAsync("http://192.168.161.77/apiSystem/exp/getItemMaster", parameter);

                                //dynamic resultLOCATION = null;

                                if (resultLOCATION == null)
                                {
                                    for (int i = 0; i > 10; i++)
                                    {
                                        location += " ";
                                    }
                                }
                                else
                                {
                                    foreach (var itemLOCATION in resultLOCATION)
                                    {
                                        location = itemLOCATION.LOCATION;
                                    }
                                }

                                if (responseGetWi.Status == 0)
                                {
                                    for(int i = 0; spaceWi.Count() < 10; i++)
                                    {
                                        spaceWi += " ";
                                    }
                                }
                                else
                                {
                                    spaceWi = responseGetWi.wi;
                                }


                                for (int i = 1; CountTotalDefect.ToString().Count() + spacedefectQty.Count() < 5; i++)
                                {
                                    spacedefectQty += "0";
                                }

                                qrcodeDefect = String.Concat("DF ", 2, " ", operationData.partline, " ", spaceWi, " ", operationData.partseqactual, " ", scanTag.genLot(DateTime.Now),
                                                                  " ", (operationData.partline.Substring(2, 2) == "K1") ? "51" : "52" , " ", lbBoxNoNc.Text, " ", spacedefectQty + CountTotalDefect, " ", operationData.partnotagfa);

                                //MessageBox.Show(qrcodeDefect);

                                var dateInsDefect = new
                                {
                                    countID = operationData.countDMCDefectNCId,
                                    CodeDefect = qrcodeDefect,
                                    box = lbBoxNoNc.Text,
                                    DefectQrDetail = qrDefectDetail,
                                    login_user = Session.Userlogin
                                };
                                
                                var dateInsDefectJson = JsonConvert.SerializeObject(dateInsDefect);
                                dynamic responseInsDefect = await api.CurPostRequestAsync("OperationIns/insert_TagDefect/", dateInsDefectJson);
                                
                                Console.WriteLine("responseInsDefect " + responseInsDefect);
                                
                                if (responseInsDefect.Status == 1 )
                                {
                                    var dateUpdLogchkBoxsDefect = new
                                    {
                                        lotno_curr = scanTag.genLot(DateTime.Now),
                                        partNo = operationData.partnotagfa,
                                        TypeDefect = 0,
                                        login_user = Session.Userlogin
                                    };

                                    var dateUpdLogchkBoxsDefectJson = JsonConvert.SerializeObject(dateUpdLogchkBoxsDefect);
                                    dynamic responsedateUpdLogchkBoxsDefect = await api.CurPostRequestAsync("OperationUpdate/update_log_chk_BoxNo_Defect_complete/", dateUpdLogchkBoxsDefectJson);

                                    if (responsedateUpdLogchkBoxsDefect.Status != 1)
                                    {
                                        MessageBox.Show("Error system : update log chk box defect (complete)");
                                    }

                                    PrintTagDefect TagDefect = new PrintTagDefect();
                                    TagDefect.printTagDefect(qrcodeDefect, qrDefectDetail, "NC", lbBoxNoNc.Text, location, CountTotalDefect.ToString(),
                                                            operationData.partnotagfa, operationData.partNoName, operationData.model, operationData.partline, operationData.partworkshift, DateTime.Now, (operationData.partline.Substring(0, 2) == "K1") ? "10" : "8");
                                    
                                    qrDefectDetail = "";
                                }
                                else
                                {
                                    MessageBox.Show("Error System!!! : insert data  ");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error System!!! : get print Count defect ");
                            }



                            /*var dateGetDefect = new
                            {
                                countID = operationData.countDMCDefectNCId
                            };
                            var dateGetDefectJson = JsonConvert.SerializeObject(dateGetDefect);
                            dynamic responseGetDefect = await api.CurPostRequestAsync("Operation/get_printCountDefectTotal/", dateGetDefectJson);


                            Console.WriteLine("responseGetDefect : " + responseGetDefect);



                            //NC

                            //Console.WriteLine("responseGetWi : " + item);
                            if (responseGetWi.Status == 1)
                            {
                                int CountDefect = item.idc_count;
                                int QTY;
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
                                //int count = 0;
                                for (int i = 1; (int)Math.Ceiling(loopPrintTagDefect) >= i; i++)
                                {
                                    Console.WriteLine("print NC");
                                    qrcodeDefect = String.Concat("DF ", 2, " ", operationData.partline, " ", responseGetWi.wi, " ", operationData.partseqactual, " ", scanTag.genLot(DateTime.Now),
                                                                  " ", LocationData.Phase, " ", (i > 9) ? "0" + i : "00" + i, " ", spacedefectQty + operationData.partsnp, " ", operationData.partnotagfa);
                                    //Console.WriteLine(qrcodeDefect);
                                    if (CountDefect / int.Parse(operationData.partsnp) < 1)
                                    {
                                        QTY = CountDefect;
                                        CountDefect = 0;
                                    }
                                    else
                                    {
                                        QTY = int.Parse(operationData.partsnp);
                                        CountDefect = CountDefect - int.Parse(operationData.partsnp);
                                    }


                                    startIndex = i * int.Parse(operationData.partsnp) - int.Parse(operationData.partsnp); //( i == 1)? 0 : i *  -snp
                                    endIndex = startIndex + int.Parse(operationData.partsnp) - 1;


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
                                
                                    string parameter = $"?partNumber={operationData.partnotagfa}";
                                    dynamic resultLOCATION = await api.CurGetRequestAsync("http://192.168.161.77/apiSystem/exp/getItemMaster", parameter);
                                    string location = null;
                                    foreach (var itemLOCATION in resultLOCATION)
                                    {
                                        location = itemLOCATION.LOCATION;
                                    }

                                    var dateInsDefect = new
                                    {
                                        countID = operationData.countDMCDefectNCId,
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
                                        TagDefect.printTagDefect(qrcodeDefect, qrDefectDetail, "NC", (i > 9) ? "0" + i : "00" + i, location, QTY.ToString(),
                                                                operationData.partnotagfa, operationData.partNoName, operationData.model, operationData.partline, operationData.partworkshift, DateTime.Now, LocationData.Phase);                   
                                
                                        qrDefectDetail = "";
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error system !!! : insert tag defect unsuccessful");
                                    }

                                }
                            }*/
                        }
                        else
                        {
                            ////#### ตรงนี้ต่อ ####
                            //Console.WriteLine("NG defect");


                            var dateGetDefect = new
                            {
                                countID = operationData.countDMCDefectNGId
                            };
                            //Console.WriteLine("dateGetDefect" + dateGetDefect);
                            var dateGetDefectJson = JsonConvert.SerializeObject(dateGetDefect);
                            dynamic responseGetDefect = await api.CurPostRequestAsync("Operation/get_printCountDefectTotal/", dateGetDefectJson);
                            //Console.WriteLine("responseGetDefect" + responseGetDefect);
                            if (responseGetDefect.Status == 1)
                            {
                                string qrDefectDetail = "";
                                string location = "";
                                string qrcodeDefect = "";
                                string spacedefectQty = "";
                                string spaceWi = "";
                                int CountTotalDefect = int.Parse(responseGetDefect.total.ToString());
                                foreach (var itemGetdefect in responseGetDefect.data)
                                {
                                    qrDefectDetail += $"{ itemGetdefect.md_code} = {itemGetdefect.sum}";
                                    if (qrDefectDetail != null)
                                    {
                                        qrDefectDetail += " | ";
                                    }
                                }
                                if (qrDefectDetail != null || qrDefectDetail == "")
                                {
                                    qrDefectDetail = qrDefectDetail.Substring(0, qrDefectDetail.Length - 3);
                                }

                                string parameter = $"?partNumber={operationData.partnotagfa}";
                                dynamic resultLOCATION = await api.CurGetRequestAsync("http://192.168.161.77/apiSystem/exp/getItemMaster", parameter);
                                //dynamic resultLOCATION = null;
                                Console.WriteLine("resultLOCATION" + resultLOCATION);

                                if (resultLOCATION == null)
                                {
                                    for (int i = 0; i > 10; i++)
                                    {
                                        location += " ";
                                    }
                                }
                                else
                                {
                                    foreach (var itemLOCATION in resultLOCATION)
                                    {
                                        location = itemLOCATION.LOCATION;
                                    }
                                }

                                if (responseGetWi.Status == 0)
                                {
                                    for (int i = 0; spaceWi.Count() < 10; i++)
                                    {
                                        spaceWi += " ";
                                    }
                                }
                                else
                                {
                                    spaceWi = responseGetWi.wi;
                                }


                                for (int i = 1; CountTotalDefect.ToString().Count() + spacedefectQty.Count() < 5; i++)
                                {
                                    spacedefectQty += "0";
                                }

                                qrcodeDefect = String.Concat("DF ", 1, " ", operationData.partline, " ", spaceWi, " ", operationData.partseqactual, " ", scanTag.genLot(DateTime.Now),
                                                                  " ", (operationData.partline.Substring(2, 2) == "K1") ? "51" : "52", " ", lbBoxNoNc.Text, " ", spacedefectQty + CountTotalDefect, " ", operationData.partnotagfa);

                                //MessageBox.Show(qrcodeDefect);

                                var dateInsDefect = new
                                {
                                    countID = operationData.countDMCDefectNCId,
                                    CodeDefect = qrcodeDefect,
                                    box = lbBoxNoNc.Text,
                                    DefectQrDetail = qrDefectDetail,
                                    login_user = Session.Userlogin
                                };

                                var dateInsDefectJson = JsonConvert.SerializeObject(dateInsDefect);
                                dynamic responseInsDefect = await api.CurPostRequestAsync("OperationIns/insert_TagDefect/", dateInsDefectJson);

                                Console.WriteLine("responseInsDefect " + responseInsDefect);

                                if (responseInsDefect.Status == 1)
                                {
                                    var dateUpdLogchkBoxsDefect = new
                                    {
                                        lotno_curr = scanTag.genLot(DateTime.Now),
                                        partNo = operationData.partnotagfa,
                                        TypeDefect = 1,
                                        login_user = Session.Userlogin
                                    };

                                    var dateUpdLogchkBoxsDefectJson = JsonConvert.SerializeObject(dateUpdLogchkBoxsDefect);
                                    dynamic responsedateUpdLogchkBoxsDefect = await api.CurPostRequestAsync("OperationUpdate/update_log_chk_BoxNo_Defect_complete/", dateUpdLogchkBoxsDefectJson);

                                    if (responsedateUpdLogchkBoxsDefect.Status != 1)
                                    {
                                        MessageBox.Show("Error system : update log chk box defect (complete)");
                                    }


                                    PrintTagDefect TagDefect = new PrintTagDefect();
                                    TagDefect.printTagDefect(qrcodeDefect, qrDefectDetail, "NG", lbBoxNoNc.Text, location, CountTotalDefect.ToString(),
                                                            operationData.partnotagfa, operationData.partNoName, operationData.model, operationData.partline, operationData.partworkshift, DateTime.Now, (operationData.partline.Substring(0, 2) == "K1") ? "10" : "8");

                                    qrDefectDetail = "";
                                }
                                else
                                {
                                    MessageBox.Show("Error System!!! : insert data  ");
                                }


                            }
                            else
                            {
                                MessageBox.Show("Error System!!! : get print Count defect ");
                            }


                        /*
                        var dateGetDefect = new
                        {
                            countID = operationData.countDMCDefectNGId
                        };
                        var dateGetDefectJson = JsonConvert.SerializeObject(dateGetDefect);
                        dynamic responseGetDefect = await api.CurPostRequestAsync("Operation/get_printCountDefectTotal/", dateGetDefectJson);

                        //NG
                        Console.WriteLine("responseGetDefect : " + responseGetDefect);


                        if (responseGetWi.Status == 1)
                        {
                            int CountDefect = item.idc_count;
                            int QTY;
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
                            //int count = 0;
                            for (int i = 1; (int)Math.Ceiling(loopPrintTagDefect) >= i; i++)
                            {
                                Console.WriteLine("print NG");
                                qrcodeDefect = String.Concat("DF ", 1, " ", operationData.partline, " ", responseGetWi.wi, " ", scanTag.genLot(DateTime.Now),
                                                              " ", (i > 9) ? "0" + i : "00" + i, " ", spacedefectQty + operationData.partsnp, " ", operationData.partnotagfa);

                                if (CountDefect / int.Parse(operationData.partsnp) < 1)
                                {
                                    QTY = CountDefect;
                                    CountDefect = 0;
                                }
                                else
                                {
                                    QTY = int.Parse(operationData.partsnp);
                                    CountDefect = CountDefect - int.Parse(operationData.partsnp);
                                }

                                startIndex = i * int.Parse(operationData.partsnp) - int.Parse(operationData.partsnp); //( i == 1)? 0 : i *  -snp
                                endIndex = startIndex + int.Parse(operationData.partsnp) - 1;


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
                                    //MessageBox.Show("qty : " + QTY.ToString());
                                    //MessageBox.Show(countsByMdCode.ToString());
                                    //MessageBox.Show((item.idc_count - (i * int.Parse(operationData.partsnp))).ToString());

                                    PrintTagDefect TagDefect = new PrintTagDefect();
                                    TagDefect.printTagDefect(qrcodeDefect, qrDefectDetail, "NG", (i > 9) ? "0" + i : "00" + i, location, QTY.ToString(),
                                                            operationData.partnotagfa, operationData.partNoName, operationData.model, operationData.partline, operationData.partworkshift, DateTime.Now, LocationData.Phase);

                                    qrDefectDetail = "";
                                }
                                else
                                {
                                    MessageBox.Show("Error system !!! : insert tag defect unsuccessful");
                                }
                            }
                        }*/
                    }



                        /// insert log chk box defect
                        /*
                        var dataINSLogchkboxQgate = new
                        {
                            partNo = operationData.partnotagfa,
                            lotNo = scanTag.genLot(DateTime.Now),
                            boxDefect = box,
                            typeDefect = item.lcbnd_type,
                            login_user = Session.Userlogin
                        };

                        var dataINSLogchkboxQgateJson = JsonConvert.SerializeObject(dataINSLogchkboxQgate);
                        dynamic responsedataINSLogchkboxQgateJson = await api.CurPostRequestAsync("OperationIns/insert_log_chk_BoxNo_DefectK/", dataINSLogchkboxQgateJson);

                        Console.WriteLine(responsedataINSLogchkboxQgateJson);
                        if (responsedataINSLogchkboxQgateJson.Status != 1)
                        {
                            MessageBox.Show("Error System!!! : Insert data log chk box defect");
                        }*/
                    }
                }
                else
                {
                    Console.WriteLine("responseDataGetCountDefect " + responseDataGetCountDefect);
                    MessageBox.Show("Error System : Get wi ( Print Defect Error )");
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