using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QGate_system
{
    public partial class UserProfile : UserControl
    {
        public UserProfile()
        {
            InitializeComponent();
        }

        private string _pathPic;
        public string PathPic
        {
            get { return _pathPic; }
            set { 
                _pathPic = value;
                pbImgUser.ImageLocation = _pathPic;
            }
        }

        private string _empCode;
        public string EmpCode
        {
            get { return _empCode; }
            set { 
                _empCode = value;
                lbEmpCode.Text = _empCode;
            }
        }

        private string _nameUser;
        public string NameUser
        {
            get { return _nameUser; }
            set { 
                _nameUser = value;
                lbNameUser.Text = _nameUser;


            }
        }

        private void lbEmpCode_Click(object sender, EventArgs e)
        {

        }

        private void lbNameUser_Click(object sender, EventArgs e)
        {

        }

        private void pbImgUser_Click(object sender, EventArgs e)
        {

        }
    }
}
