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
    public partial class adminMenu : UserControl
    {
        public adminMenu()
        {
            InitializeComponent();
        }

        private string _path;
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        
        private string _picterName;
        public string PicterName
        {
            get { return _picterName; }
            set { 
                _picterName = value; 
                pbMenuAdmin.ImageLocation = PicterName;
                pbMenuAdmin.BackgroundImageLayout = ImageLayout.Stretch;
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
            pbMenuAdmin.Click += new EventHandler(this.menuClick);
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
                MessageBox.Show("Menu is not available for use"+ ex);
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

        
    }
}
