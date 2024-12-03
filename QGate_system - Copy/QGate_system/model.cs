using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace QGate_system
{
    class model
    {
        private static model instance;
        private model() { }
        public static model Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new model();
                }
                return instance;
            }
        }

        public static bool ContainsThaiCharacters(string input)
        {
            // ใช้ Regular Expression เพื่อตรวจสอบว่ามีอักขระที่เป็นภาษาไทยอยู่ในข้อความหรือไม่
            Regex thaiPattern = new Regex(@"[\u0E00-\u0E7F]+");
            return thaiPattern.IsMatch(input);
        }
    }

    class LocationData
    {
        private static LocationData instance;
        private LocationData() { }
        public static LocationData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LocationData();
                }
                return instance;
            }
        }

        private string _IdStation;
        private string _Phase;
        private string _Zone;
        private string _Station;
        private string _TypeStation;
        private string _PartNo;
        private object _selectPartNo;
        private int _delay;
        private int _PartNoID;

        public string Phase
        {
            get { return _Phase; }
            set
            {
                _Phase = value;
            }
        }

        public string Zone
        {
            get { return _Zone; }
            set
            {
                _Zone = value;
            }
        }

        public string Station
        {
            get { return _Station; }
            set
            {
                _Station = value;
            }
        }

        public string TypeStation
        {
            get { return _TypeStation; }
            set
            {
                _TypeStation = value;
            }
        }
        public string PartNo
        {
            get { return _PartNo; }
            set
            {
                _PartNo = value;
            }
        }

        public int PartNoID
        {
            get { return _PartNoID; }
            set
            {
                _PartNoID = value;
            }
        }

        public object selectPartNo
        {
            get { return _selectPartNo; }
            set
            {
                _selectPartNo = value;
            }
        }

        public string IdStation
        {
            get { return _IdStation; }
            set
            {
                _IdStation = value;
            }
        }

        public int Delay
        {
            get { return _delay; }
            set
            {
                _delay = value;
            }
        }


    }


    public class Session
    {
        private static Session instance;

        //Login Admin
        public string CurrentAdmin { get; set; }
        public int LogloginAdmin { get; set; }

        //Login
        public string PermisLogin { get; set; }
        public int Loglogin { get; set; }
        public string Userlogin { get; set; }

        private Session() { }
        public static Session Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Session();
                }
                return instance;
            }
        }
    }


}
