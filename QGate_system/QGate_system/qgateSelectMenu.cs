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
    public partial class qgateSelectMenu : Form
    {
        QGate_system.API.Session Session = QGate_system.API.Session.Instance;
        QGate_system.API.API api = new QGate_system.API.API();
        model myModel = model.Instance;

        private string _settingZone;
        public string SettingZone
        {
            get { return _settingZone; }
            set
            {
                _settingZone = value;
            }
        }

        private string _settingStation;
        public string SettingStation
        {
            get { return _settingStation; }
            set
            {
                _settingStation = value;
            }
        }

        public qgateSelectMenu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            qgateLogin formLogin = new qgateLogin();
            formLogin.Show();

            this.Hide();
        }

        private async void qgateSelectMenu_Load(object sender, EventArgs e)
        {
            lbZone.Text = SettingZone;
            lbStation.Text = SettingStation;

            var data = new
            {
                Permis = Session.PermisLogin
            };

            var jsonDataPermis = JsonConvert.SerializeObject(data);
            var resultResponse = await api.CurPostRequestAsync("Login/menuPremis/", jsonDataPermis);
            dynamic dataMenubypermis = JsonConvert.DeserializeObject(resultResponse);

            MenuItem[] userCtrl = new MenuItem[dataMenubypermis.Menu.Count];

            for (int i = 0 ; i < userCtrl.Length ; i++)
            {
                userCtrl[i] = new MenuItem();
                userCtrl[i].PathPic = dataMenubypermis.Menu[i].sm_path+dataMenubypermis.Menu[i].sm_pic;
                userCtrl[i].FormName = dataMenubypermis.Menu[i].sm_routing;

                userCtrl[i].addAction();
                flpMenu.Controls.Add(userCtrl[i]);
            }
        }

        private void pbAddUser_Click(object sender, EventArgs e)
        {
            qgateAddUser formAddUser = new qgateAddUser();

            formAddUser.ShowDialog();
        }



    }





    /* add value combobox
    public class PartNOItem
    {
        public int mcd_id { get; set; }
        public string mcd_select_part { get; set; }
        public PartNOItem(int id, string name)
        {
            mcd_id = id;
            mcd_select_part = name;
        }
        public override string ToString()
        {
            return $"{mcd_select_part}";
        }
    }
    */

        /* get value combobox
       private void cbTest_SelectedIndexChanged(object sender, EventArgs e)
       {
           PartNOItem select = (PartNOItem)cbTest.SelectedItem;
           Console.WriteLine("chang combobox :"+ select.mcd_id);
       }*/

     
    /* set value combobox
    string jsonData = myModel.DataPartNo.ToString();
    List<PartNOItem> data1 = JsonConvert.DeserializeObject<List<PartNOItem>>(jsonData);
    foreach (PartNOItem item in data1)
    {
        cbTest.Items.Add(new PartNOItem(item.mcd_id, item.mcd_select_part));
    }
    ///////////

    string jsonData = myModel.DataPartNo.ToString();
    List<PartNOItem> data1 = JsonConvert.DeserializeObject<List<PartNOItem>>(jsonData);
    cbTest.Items.AddRange(data1.Select(item => new PartNOItem(item.mcd_id, item.mcd_select_part)).ToArray());*/


}
