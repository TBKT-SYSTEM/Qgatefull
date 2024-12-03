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
    public partial class qgateMenuReprintTag : Form
    {
        public qgateMenuReprintTag()
        {
            InitializeComponent();
        }

        private void lbBackToMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lbQgate_Click(object sender, EventArgs e)
        {
            qgateReprintQgate formReprintTag = new qgateReprintQgate();
            formReprintTag.Show();

            this.Hide();
        }

        private void lbDefect_Click(object sender, EventArgs e)
        {
            qgateReprintDefect formReprintDefect = new qgateReprintDefect();
            formReprintDefect.Show();

            this.Hide();
        }


    }
}
