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
    public partial class MenuItem : UserControl
    {
        public MenuItem()
        {
            InitializeComponent();
        }

        private string _pathPic;
        public string PathPic
        {
            get { return _pathPic; }
            set {
                _pathPic = value;
                pbMenu.ImageLocation = PathPic;
                
            }
        }

        private string _formName;
        public string FormName
        {
            get { return _formName; }
            set { _formName = value; }
        }

        public void addAction()
        {
            pbMenu.Click += new EventHandler(this.menuClick);
        }

        public void menuClick(object sender, EventArgs e)
        {
            try
            {
                qgateMenuAdmin FormMenuAdmin = new qgateMenuAdmin();
                FormMenuAdmin.Close();

                Form frm = this.createDynamicallyForm(FormName);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Menu is not available for use : " + ex);
            }
        }

        public Form createDynamicallyForm(string formName)
        {
            string currentNamespace = this.GetType().Namespace;
            Type formType = Type.GetType($"{currentNamespace}.{formName}");

            // Create an instance of the form
            Form form = (Form)Activator.CreateInstance(formType);

            return formType == null ? null : form;
        }

        private void MenuItem_Load(object sender, EventArgs e)
        {

        }


    }
}
