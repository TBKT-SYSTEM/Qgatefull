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
    public partial class qgateconfirm : Form
    {
        QGate_system.API.API api = new QGate_system.API.API();
        QGate_system.API.Session appState = QGate_system.API.Session.Instance;

        public static qgateconfirm Instance;

        private object _data;
        public object Data
        {
            get { return _data; }
            set
            {
                _data = value;
            }
        }

        private string _pathApi;
        public string PathApi
        {
            get { return _pathApi; }
            set
            {
                _pathApi = value;
            }
        }

        public qgateconfirm()
        {
            InitializeComponent();
        }

        private async void pbConfirm_Click(object sender, EventArgs e)
        {

            var jsonData = JsonConvert.SerializeObject(Data);
            var result = await api.CurPostRequestAsync(PathApi, jsonData);
            dynamic dataReponse = JsonConvert.DeserializeObject(result);

            this.Close();

            string pathPic = dataReponse.mat_path;

            qgateAlert formAlret = new qgateAlert();
            formAlret.PathPicRequert = api.LoadPicture(pathPic); ;
            formAlret.MessageRequert = dataReponse.message;

            formAlret.ShowDialog();
        }

        private void pbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
