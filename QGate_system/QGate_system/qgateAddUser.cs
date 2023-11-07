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
    public partial class qgateAddUser : Form
    {
        QGate_system.API.API api = new QGate_system.API.API();

        public qgateAddUser()
        {
            InitializeComponent();
        }

        private async void pbUser_Click(object sender, EventArgs e)
        {
            Console.WriteLine(tbAddUser.Text);

            var data = new
            {
                EmpCode = tbAddUser.Text
            };
            var jsonDataPermis = JsonConvert.SerializeObject(data);
            var resultResponse = await api.CurPostRequestAsync("Login/menuPremis/", jsonDataPermis);
            dynamic dataMenubypermis = JsonConvert.DeserializeObject(resultResponse);

            Console.WriteLine("get data user : "+dataMenubypermis);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
