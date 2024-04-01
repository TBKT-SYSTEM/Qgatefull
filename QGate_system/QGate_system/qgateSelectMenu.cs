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
        QGate_system.API.API api = new QGate_system.API.API();
        Session Session = Session.Instance;
        LocationData LocationData = LocationData.Instance;


        public static qgateSelectMenu instance;
        public FlowLayoutPanel flpUserInstance;

        public qgateSelectMenu()
        {
            InitializeComponent();
            instance = this;
            flpUserInstance = flpUser;

            this.flpScrollUp.Click += new System.EventHandler(this.flpScrollUp_Click);
            this.flpScrollDown.Click += new System.EventHandler(this.flpScrollDown_Click);
        }

        private object _userLogin;
        public object UserLogin
        {
            get { return _userLogin; }
            set
            {
                _userLogin = value;
            }
        }

        public async void AddUserControlToFlowLayoutPanel(object userControl)
        {
            string userLoginJson = JsonConvert.SerializeObject(userControl); // แปลง UserLogin เป็น string
            dynamic datauser = JsonConvert.DeserializeObject(userLoginJson);

            UserProfile[] userProfile = new UserProfile[1];

            for (int i = 0; i < userProfile.Length; i++)
            {
                userProfile[i] = new UserProfile();
                userProfile[i].PathPic = datauser.PathPic;
                userProfile[i].EmpCode = datauser.EmpCode;
                userProfile[i].NameUser = datauser.NameUser;

                flpUser.Controls.Add(userProfile[i]);
            }

            await Task.Delay(6);
            flpUser.Refresh();
        }

        private async void qgateSelectMenu_Load(object sender, EventArgs e)
        {

            lbZone.Text = LocationData.Zone;
            lbStation.Text = LocationData.Station;

            var data = new
            {
                Permis = Session.PermisLogin,
                MacAddress = api.GetMacAddress()
            };

            var jsonDataPermis = JsonConvert.SerializeObject(data);
            dynamic dataMenubypermis = await api.CurPostRequestAsync("Login/menuPremis/", jsonDataPermis);

            Console.WriteLine("dataMenubypermis : " + dataMenubypermis);

            MenuItem[] userCtrl = new MenuItem[dataMenubypermis.Menu.Count];

            for (int i = 0; i < userCtrl.Length; i++)
            {
                userCtrl[i] = new MenuItem();
                userCtrl[i].PathPic = dataMenubypermis.Menu[i].sm_path + dataMenubypermis.Menu[i].sm_pic;
                userCtrl[i].FormName = dataMenubypermis.Menu[i].sm_routing;

                userCtrl[i].addAction();
                flpMenu.Controls.Add(userCtrl[i]);
            }

            string userLoginJson = JsonConvert.SerializeObject(UserLogin); // แปลง UserLogin เป็น string
            dynamic datauser = JsonConvert.DeserializeObject(userLoginJson);

            var memberArr = new string[2] { datauser.EmpCode, datauser.NameUser };
            memberData.memberList.Add(memberArr);

            memberData memberDatas = new memberData();
            memberDatas.populateItems();

        }

        private void pbAddUser_Click(object sender, EventArgs e)
        {
            qgateAddUser formAddUser = new qgateAddUser();
            formAddUser.ShowDialog();
        }

        private void pbMinusUser_Click(object sender, EventArgs e)
        {
            if (memberData.removeLastMember())
            {                                     
                memberData memberDatas = new memberData();
                memberDatas.populateItems();
            }
        }

        public async void pbLogout_Click(object sender, EventArgs e)
        {
            memberData.memberList.Clear();

            var dataEmpCode = new
            {
                logLogin_id = Session.Loglogin
            };

            var jsonData = JsonConvert.SerializeObject(dataEmpCode);
            var resultResponse = await api.CurPostRequestAsync("Login/logout/", jsonData);

            qgateLogin formLogin = new qgateLogin();
            formLogin.Show();

            this.Hide();
        }

        private void flpScrollUp_Click(object sender, EventArgs e)
        {
            int change = flpUser.VerticalScroll.Value - flpUser.VerticalScroll.SmallChange * 30;
            flpUser.AutoScrollPosition = new Point(0, change);
        }

        private void flpScrollDown_Click(object sender, EventArgs e)
        {
            int change = flpUser.VerticalScroll.Value + flpUser.VerticalScroll.SmallChange * 30;
            flpUser.AutoScrollPosition = new Point(0, change);
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