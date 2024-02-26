using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace QGate_system
{
    class memberData
    {
        QGate_system.API.API api = new QGate_system.API.API();

        //public static qgateSelectMenu instance;
        public static List<string[]> memberList = new List<string[]>();

        public memberData()
        {
            // กำหนดค่าให้ instance ในคอนสตรักเตอร์
            //instance = new qgateSelectMenu();
        }

        public static bool chk_RepeatMember(string memberID)
        {
            var i = 0;
            foreach (var item in memberList)
            {
                if (item[0].ToUpper() == memberID.ToUpper()) i++;
            }

            return i > 0 ? true : false;
        }

        public static bool removeLastMember()
        {
            int lastIndex = memberList.Count - 1;

            if (lastIndex >= 0)
            {
                memberList.RemoveAt(lastIndex);
                return true; // หากลบสำเร็จให้คืนค่า true
            }

            return false; // หาก memberList ว่างเปล่าให้คืนค่า false
        }

        public void populateItems()
        {
            qgateSelectMenu.instance.flpUserInstance.Controls.Clear();
            
            //Console.WriteLine(memberList);
            //Console.WriteLine("member add , count :"+ memberList.Count);

            UserProfile[] listItems = new UserProfile[memberList.Count];

            for (int i = 0; i < listItems.Length; i++)
            {
                string url = $"http://192.168.161.207/tbkk_shopfloor/asset/img_emp/{memberList[i][0]}.jpg";
                
                listItems[i] = new UserProfile();
                //listItems[i].PathPicRequert = api.LoadPicture(url);
                listItems[i].PathPic = url;
                listItems[i].EmpCode = memberList[i][0];
                listItems[i].NameUser = memberList[i][1];

                qgateSelectMenu.instance.flpUserInstance.Controls.Add(listItems[i]);

            }
        }
    }




}
