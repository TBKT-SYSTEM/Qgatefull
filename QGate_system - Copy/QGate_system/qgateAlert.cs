using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace QGate_system
{
    public partial class qgateAlert : Form
    {
        QGate_system.API.API api = new QGate_system.API.API();

        private string _messageRequert;
        public string MessageRequert
        {
            get { return _messageRequert; }
            set
            {
                _messageRequert = value;
            }
        }

        private string _valueRequert;
        public string ValueRequert
        {
            get{ return _valueRequert; }
            set
            {
                _valueRequert = value;
            }
        }

        private Bitmap _pathPicRequert;
        public Bitmap PathPicRequert
        {
            get { return _pathPicRequert; }
            set
            {
                _pathPicRequert = value;
                this.BackgroundImage = PathPicRequert;
            }
        }

        public qgateAlert()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void qgateAlert_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            lbmessage.Text = MessageRequert;
            lbmessage.TextAlign = ContentAlignment.MiddleCenter;
        }

        

    }
}


