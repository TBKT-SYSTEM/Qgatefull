using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.NetworkInformation;

namespace QGate_system
{
    public partial class qgateSettingPosition : Form
    {
        qgateMenuAdmin formMenuAdmin = new qgateMenuAdmin();
        QGate_system.API.API api = new QGate_system.API.API();
        qgateAlert formAlret = new qgateAlert();
        Session Session = Session.Instance;

        public string macAddress;

        public string CBphaseId;
        public string CBzoneId;
        public string CBstationId;

        bool setZone = false;
        int zoneId;
        bool setStation = false;
        int stationId;

        //public static qgateSettingPosition Instance;

        public qgateSettingPosition()
        {
            InitializeComponent();
            macAddress = api.GetMacAddress();
        }

        private async void setStation_Load(object sender, EventArgs e)
        {
            //Console.WriteLine("macaddress modifity : "+macAddress);
            dynamic result = await api.CurGetRequestAsync("MenuAdmin/get_Phase/");
            //dynamic data = JsonConvert.DeserializeObject(result);

            PhaseItem item_please = new PhaseItem(Convert.ToInt32(0), "Choose Phase");
            cbSelectPhase.Items.Add(item_please);
            cbSelectPhase.SelectedIndex = 0;

            foreach (var Phase in result.Phase)
            {
                PhaseItem item = new PhaseItem(Convert.ToInt32(Phase.mpa_id), Phase.mpa_name.ToString());
                cbSelectPhase.Items.Add(item);
            }

            ////////  original settings
            var dataMADD = new
            {
                macAddress = macAddress
            };

            var jsonDataMADD = JsonConvert.SerializeObject(dataMADD);
            dynamic dataSetting = await api.CurPostRequestAsync("MenuAdmin/get_Setting/", jsonDataMADD);
            //dynamic dataSetting = JsonConvert.DeserializeObject(resultSetting);

            if (dataSetting.Setting.Count > 0)
            {
                setZone = true;
                zoneId = dataSetting.Setting[0].mza_id;

                setStation = true;
                stationId = dataSetting.Setting[0].msa_id;

                PhaseItem itemToSelect = null;
                foreach (PhaseItem item in cbSelectPhase.Items)
                {
                    if (item.mpa_id == Convert.ToInt32(dataSetting.Setting[0].mpa_id))
                    {
                        itemToSelect = item;
                        break;
                    }
                }
                cbSelectPhase.SelectedItem = itemToSelect;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private async void cbPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSelectStation.SelectedIndex = -1;
            cbSelectStation.Items.Clear();

            cbSelectZone.SelectedIndex = -1;
            cbSelectZone.Items.Clear();
            
            int Index_Phase = cbSelectPhase.SelectedIndex;
            if (Index_Phase != 0)
            {
                dynamic result = await api.CurGetRequestAsync("MenuAdmin/get_Zone/");
                //dynamic data = JsonConvert.DeserializeObject(result);

                ZoneItem item_please = new ZoneItem(Convert.ToInt32(0), "Choose Zone");
                cbSelectZone.Items.Add(item_please);
                cbSelectZone.SelectedIndex = 0;

                foreach (var Zone in result.Zone)
                {
                    ZoneItem item = new ZoneItem(Convert.ToInt32(Zone.mza_id), Zone.mza_name.ToString());
                    cbSelectZone.Items.Add(item);
                }

                if (setZone)
                {
                    setZone = false;
                    ZoneItem itemToSelect = null;
                    foreach (ZoneItem item in cbSelectZone.Items)
                    {
                        if (item.mza_id == zoneId)
                        {
                            itemToSelect = item;
                            break;
                        }
                    }
                    cbSelectZone.SelectedItem = itemToSelect;
                }
            }
        }
        private async void cbZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSelectStation.SelectedIndex = -1;
            cbSelectStation.Items.Clear();

            int? Index_Zone = cbSelectZone.SelectedIndex;

            if (Index_Zone > 0)
            {

                dynamic result = await api.CurGetRequestAsync("MenuAdmin/get_Station/");
                //dynamic data = JsonConvert.DeserializeObject(result);

                StationItem item_please = new StationItem(Convert.ToInt32(0), "Choose Station");
                cbSelectStation.Items.Add(item_please);
                cbSelectStation.SelectedIndex = 0;

                foreach (var Zone in result.Station)
                {
                    StationItem item = new StationItem(Convert.ToInt32(Zone.msa_id), Zone.msa_station.ToString());
                    cbSelectStation.Items.Add(item);
                }
                if (setStation)
                {
                    setStation = false;
                    StationItem itemToSelect = null;
                    foreach (StationItem item in cbSelectStation.Items)
                    {
                        if (item.msa_id == stationId)
                        {
                            itemToSelect = item;
                            break;
                        }
                    }
                    cbSelectStation.SelectedItem = itemToSelect;
                }
            }
        }

        private async void lbConfirm_Click(object sender, EventArgs e)
        {
            
            PhaseItem selectedPhaseItem = (PhaseItem)cbSelectPhase.SelectedItem;
            ZoneItem selectedZoneItem = (ZoneItem)cbSelectZone.SelectedItem;
            StationItem selectedStationItem = (StationItem)cbSelectStation.SelectedItem;

            dynamic pathPicWraing = await api.CurGetRequestAsync("MstPathPic/get_PathPic_Warning/");
            //dynamic pathPicWraing = JsonConvert.DeserializeObject(result);
            string pathPic_Warning = pathPicWraing.Path;
            

            if (selectedPhaseItem.mpa_id == 0)
            {
                formAlret.MessageRequert = "Please Select Phase";
                formAlret.PathPicRequert = api.LoadPicture(pathPic_Warning);
                formAlret.ShowDialog();

            }
            else if (selectedZoneItem.mza_id == 0)
            {
                formAlret.MessageRequert = "Please Select Zone";
                formAlret.PathPicRequert = api.LoadPicture(pathPic_Warning);
                formAlret.ShowDialog();

            }
            else if (selectedStationItem.msa_id == 0)
            {
                formAlret.MessageRequert = "Please Select Station";
                formAlret.PathPicRequert = api.LoadPicture(pathPic_Warning);
                formAlret.ShowDialog();
            }
            else
            {
                var data = new
                {
                    data = new
                    {
                        phaseId = selectedPhaseItem.mpa_id.ToString(),
                        zoneId = selectedZoneItem.mza_id.ToString(),
                        stationId = selectedStationItem.msa_id.ToString(),
                        macAddress = macAddress
                    },
                    person = Session.CurrentAdmin
                };

                qgateconfirm formconfirm = new qgateconfirm();
                formconfirm.Data = data;
                formconfirm.PathApi = "MenuAdmin/set_Setting/";

                formconfirm.ShowDialog();
            }
        }
    }

    // class สำหรับจัดข้อมูล Phase เพื่อเอาไปใส่ combobox <--
    public class PhaseItem
    {
        public int mpa_id { get; set; }
        public string mpa_name { get; set; }
        public PhaseItem(int id, string name)
        {
            mpa_id = id;
            mpa_name = name;
        }
        public override string ToString()
        {
            return $"{mpa_name}";
        }
    }
    public class ZoneItem
    {
        public int mza_id { get; set; }
        public string mza_name { get; set; }
        public ZoneItem(int id, string name)
        {
            mza_id = id;
            mza_name = name;
        }
        public override string ToString()
        {
            return $"{mza_name}";
        }
    }

    public class StationItem
    {
        public int msa_id { get; set; }
        public string msa_station { get; set; }
        public StationItem(int id, string name)
        {
            msa_id = id;
            msa_station = name;
        }
        public override string ToString()
        {
            return $"{msa_station}";
        }
    }



}
