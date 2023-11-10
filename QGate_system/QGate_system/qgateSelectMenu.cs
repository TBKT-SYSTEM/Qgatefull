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


        public static qgateSelectMenu instance;
        public FlowLayoutPanel flpUserInstance;



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
            instance = this;
            flpUserInstance = flpUser;

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

            Console.WriteLine(datauser);


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


            Console.WriteLine(datauser);

            var memberArr = new string[2] { datauser.EmpCode, datauser.NameUser };
            memberData.memberList.Add(memberArr);

            memberData memberDatas = new memberData();
            memberDatas.populateItems();

            /*
                        UserProfile[] userProfile = new UserProfile[1];

                        for (int i = 0; i < userProfile.Length; i++)
                        {
                            userProfile[i] = new UserProfile();
                            userProfile[i].PathPic = datauser.PathPic;
                            userProfile[i].EmpCode = datauser.EmpCode;
                            userProfile[i].NameUser = datauser.NameUser;

                            flpUser.Controls.Add(userProfile[i]);
                        }

                        UserProfile listItems = new UserProfile();

                        string url = $"http://192.168.161.207/tbkk_shopfloor/asset/img_emp/K0070.jpg";

                        listItems = new UserProfile();
                        listItems.PathPicRequert = api.LoadPicture(url);
                        listItems.PathPic = url;
                        listItems.EmpCode = "sttstst56";
                        listItems.NameUser = "namemmmmmm";

                        memberData memberData = new memberData();

                        memberData.populateItems();*/


            /**/
            //dynamic test = JsonConvert.DeserializeObject(UserLogin);
            //object userData = _userLogin;
            //string test = userData.PathPic;
            //Console.WriteLine("test :" + UserLogin.PathPic);


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
       
        private void pbScrollUp_Click(object sender, EventArgs e)
        {

            int change = flpUser.VerticalScroll.Value - flpUser.VerticalScroll.SmallChange * 30;
            flpUser.AutoScrollPosition = new Point(0, change);
        }

        private void pbScrollDown_Click(object sender, EventArgs e)
        {
             
            int change = flpUser.VerticalScroll.Value + flpUser.VerticalScroll.SmallChange * 30;
            flpUser.AutoScrollPosition = new Point(0, change);
        }

        private void pbLogout_Click(object sender, EventArgs e)
        {
            qgateLogin formLogin = new qgateLogin();
            formLogin.Show();

            this.Hide();
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