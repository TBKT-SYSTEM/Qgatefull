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
    public partial class qgateScanTag : Form
    {
        QGate_system.API.API api = new QGate_system.API.API();
        qgateAlert formAlret = new qgateAlert();

        Session Session = Session.Instance;
        LocationData LocationData = LocationData.Instance;
        operationData operationData = operationData.Instance;

        public string macAddress;
        string codemaster;

        public qgateScanTag()
        {
            InitializeComponent();

            macAddress = api.GetMacAddress();
        }
        private void lb_pbBackToMenuStart_Click(object sender, EventArgs e)
        {
            if (LocationData.TypeStation == "Both")
            {
                qgateMenuStart formMenuStart = new qgateMenuStart();

                formMenuStart.Show();
                this.Hide();
            }
            else
            {
                this.Hide();
            }
        }

        private async void qgateScanTag_Load(object sender, EventArgs e)
        {
            /*var dataaa = new
            {
                StationID = LocationData.IdStation
            };
            Console.WriteLine(dataaa);*/

            try
            {
                lbZone.Text = LocationData.Zone;
                lbStation.Text = LocationData.Station;

                nextForm_TypeStation();

                var data = new 
                {
                    macAddress = macAddress
                };

                var jsonData = JsonConvert.SerializeObject(data);
                dynamic dataPartNO = await api.CurPostRequestAsync("Operation/get_part/", jsonData);
                Console.WriteLine("dataPartNO " + dataPartNO);

                if (dataPartNO["status"] == 1)
                {
                    //LocationData.TypeStation = dataPartNO.type;
                    LocationData.PartNo = (dataPartNO.partNo == null || dataPartNO.partNo == "") ? null : dataPartNO.partNo;
                    LocationData.PartNoID = (dataPartNO.partNoID == null) ? 0 : dataPartNO.partNoID;
                    LocationData.selectPartNo = dataPartNO.selectPartNo;
                    LocationData.TypeStation = dataPartNO.type;

                    //operationData.typeStation = dataPartNO.type;

                    if (dataPartNO.partNoID == null)
                    {
                        Console.WriteLine("dataPartNO.partNoID1 " + dataPartNO.partNoID);
                    }
                    else
                    {
                        Console.WriteLine("dataPartNO.partNoID2 " + dataPartNO.partNoID);
                    }
                    
                }
                else if (dataPartNO["status"] == 0)
                {
                    string pathPic = dataPartNO.mat_path;

                    formAlret.MessageRequert = dataPartNO.message;
                    formAlret.PathPicRequert = api.LoadPicture(pathPic);

                    formAlret.ShowDialog();
                    this.Hide();
                }
                else if (dataPartNO["status"] == 10)
                {
                    MessageBox.Show("The system has a problem.");
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }/**/

        }

        private void tbScanTag_KeyDown(object sender, KeyEventArgs e)
        {
            DateTime currentDateTime = DateTime.Now;
            string date = genLot(currentDateTime);

            //Console.WriteLine("Lot" + date);


            if (e.KeyCode == Keys.Enter)
            {
                string tag = tbScanTag.Text;
                if (tag.Length == 103)
                {
                    if (LocationData.PartNo == null)
                    {
                        MessageBox.Show("กรุณาเลือก part NO. ก่อน");
                    }
                    else
                    {
                        operationData.tagfa = tag;
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
                        operationData.partbox = tag.Substring(100, 3).Trim();

                        scanTag();
                    }
                }
                else
                {
                    MessageBox.Show("QR โค้ดผิด กรุณาสแกนใหม่");
                }
                tbScanTag.Clear();
            }
        }


        private async void scanTag()
        {
            var data = new
            {
                Tagfa = operationData.tagfa
            };

            var jsonDataPermis = JsonConvert.SerializeObject(data);
            dynamic dataMenubypermis = await api.CurPostRequestAsync("Operation/chk_Tag_fa/", jsonDataPermis);

            if (dataMenubypermis.Row == 0)
            {

                //Console.WriteLine(LocationData.PartNo.Trim());
                //Console.WriteLine(operationData.partnotagfa.Trim());
                if (LocationData.PartNo.Trim() == operationData.partnotagfa.Trim())
                {
                    codemaster = await get_Code_master();
                    //operationData.partcodemaster = codemaster;

                    await getboxandlot();
                    var data_Insert_tag_fa = new
                    {
                        tagfa = operationData.tagfa,
                        partcodemaster = codemaster,
                        partline = operationData.partline,
                        partnotagfa = operationData.partnotagfa,
                        partplantdate = operationData.partplantdate,
                        partseqplan = operationData.partseqplan,
                        partactualdate1 = operationData.partactualdate1,
                        partasnp = operationData.partsnp,
                        partlotno = operationData.partlotno,
                        partactualdate2 = operationData.partactualdate2,
                        partseqactual = operationData.partseqactual,
                        partplant = operationData.partplant,
                        partbox = operationData.partbox,
                        lot_cur = operationData.lotcur,
                        login_user = Session.Userlogin
                    };


                    var data_Insert_json = JsonConvert.SerializeObject(data_Insert_tag_fa);
                    dynamic data_result_Insert = await api.CurPostRequestAsync("OperationIns/insert_tag_fa/", data_Insert_json);
                    //MessageBox.Show("test01 :"+data_result_Insert.ToString());
                    //Console.WriteLine(data_result_Insert);

                    if (data_result_Insert.Status == 1)
                    {
                        operationData.tagfaid = data_result_Insert.tagfaid;
                        qgateOperation formOperation = new qgateOperation();
                        qgateOperationManual formOperationNondmc = new qgateOperationManual();
                        //Console.WriteLine("operationData.typeStation : " + operationData.typeStation);
                        //Console.WriteLine("LocationData.TypeStatio : " + LocationData.TypeStation);

                        if (LocationData.TypeStation == "Both") 
                        {
                            if (operationData.typeStation == "DMC")
                            {
                                formOperation.Show();
                                this.Hide();
                            }
                            else if (operationData.typeStation == "Manual")
                            {
                                formOperationNondmc.Show();
                                this.Hide();
                            }
                            else if (operationData.typeStation == "Both")
                            {
                                MessageBox.Show("Station type Both");
                            }
                            else
                            {
                                MessageBox.Show("No type station");
                            }
                        }
                        else
                        {
                            if (LocationData.TypeStation == "DMC")
                            {
                                formOperation.Show();
                                this.Hide();
                            }
                            else if (LocationData.TypeStation == "Manual")
                            {
                                formOperationNondmc.Show();
                                this.Hide();
                            }
                            else if (LocationData.TypeStation == "Both")
                            {
                                MessageBox.Show("Station type Both");
                            }
                            else
                            {
                                MessageBox.Show("No type station");
                            }
                        }

                        
                    }
                    else
                    {
                        MessageBox.Show("การสแกนไม่สำเร็จ");
                    }
                }
                else
                {
                    MessageBox.Show("part No ไม่ตรง");
                }
            }
            else if (dataMenubypermis.Row == 1)
            {
                //MessageBox.Show("row >= 1");
                MessageBox.Show("Tag นี้ scan ไปเเล้ว");
            }
            else
            {
                MessageBox.Show("Error System");
            }
        }

        private void nextForm_TypeStation()
        {
            /*if (operationData.typeStation == null)
            {
                operationData.typeStation = LocationData.TypeStation;
                //MessageBox.Show(operationData.typeStation);
            }*/
        }

        private async Task<string> get_Code_master()
        {
            var data = new
            {
                Line = operationData.partline
            };

            var jsonDataPermis = JsonConvert.SerializeObject(data);
            dynamic dataMenubypermis = await api.CurPostRequestAsync("Operation/chk_code_master/", jsonDataPermis);

            return dataMenubypermis.mfcm_id.ToString();
        }

        public async Task getboxandlot()
        {
            DateTime currentDateTime = DateTime.Now;

            var BoxNoAndLot1 = new
            {
                lotno_curr = genLot(currentDateTime), 
                partno = operationData.partnotagfa
            }; 

            var BoxNoAndLotJson1 = JsonConvert.SerializeObject(BoxNoAndLot1);
            dynamic dataBoxNoAndLot1 = await api.CurPostRequestAsync("Operation/GET_BoxNoQgate/", BoxNoAndLotJson1);
            //Console.WriteLine(dataBoxNoAndLot1);

            if (dataBoxNoAndLot1.Status == 1)
            {
                operationData.boxNo = dataBoxNoAndLot1.lcbn_box_no;
                operationData.lotcur = dataBoxNoAndLot1.lcbn_lot_no;
            }
            else if (dataBoxNoAndLot1.Status == 10)
            {
                MessageBox.Show("Error System!!! : get box (log chk box)");
            }
            else
            {
                operationData.boxNo = 0;
                operationData.lotcur = genLot(currentDateTime);
            }
            operationData.boxNo += 1;

            var dataINSLogchkboxQgate = new
            {
                partNo = operationData.partnotagfa,
                lotNo = genLot(DateTime.Now),
                box = operationData.boxNo,
                login_user = Session.Userlogin
            };

            var dataINSLogchkboxQgateJson = JsonConvert.SerializeObject(dataINSLogchkboxQgate);
            dynamic responsedataINSLogchkboxQgate = await api.CurPostRequestAsync("OperationIns/insert_log_chk_BoxNo_Qgate/", dataINSLogchkboxQgateJson);
            //Console.WriteLine(responsedataINSLogchkboxQgate);

            if (responsedataINSLogchkboxQgate.Status == 0 || responsedataINSLogchkboxQgate.Status == 10)
            {
                MessageBox.Show("Error System!!! : isnert log chk box");
            } 

        }

        public string genLot(DateTime lotDate)
        {
            char[] years = { 'J', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I' };
            char[] months = { 'L', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K' };

            int day = lotDate.Day;
            int month = lotDate.Month;
            int year = lotDate.Year % 100;

            //string formattedTime = lotDate.ToString("HH:mm:ss");
            //string Lot1;

            if (lotDate.Hour < 8 ||(lotDate.Hour <= 7 && lotDate.Minute <= 59 && lotDate.Second <= 59))
            {
                DateTime previousDay = lotDate.AddDays(-1).Date;

                string DayValue = previousDay.Day < 10 ? $"0{previousDay.Day}" : $"{previousDay.Day}";
                int MonthValue = previousDay.Month;
                int YearValue = previousDay.Year % 100;

                string Lot = $"{years[YearValue % 10]}{months[MonthValue % 12]}{DayValue}";
                //MessageBox.Show($"{Lot}-{formattedTime}");
                //Console.WriteLine($"{Lot}-{formattedTime}");
                return $"{Lot}";
            }
            else
            {
                string DayValue = day < 10 ? $"0{day}" : $"{day}";
                int MonthValue = month;
                int YearValue = year % 100;

                string Lot = $"{years[YearValue % 10]}{months[MonthValue % 12]}{DayValue}";
                //MessageBox.Show($"{Lot}-{formattedTime}");
                //Console.WriteLine($"{Lot}-{formattedTime}");
                return $"{Lot}";
            }

        }

        private void pbSelectModel_Click(object sender, EventArgs e)
        {
            qgateSelectPart formSelectPart = new qgateSelectPart();
            formSelectPart.Show();

            this.Hide();
        }

    }
}
