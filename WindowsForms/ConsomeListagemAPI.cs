using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.Helper;

namespace WindowsForms
{
    public partial class ConsomeListagemAPI : Form
    {
        public ConsomeListagemAPI()
        {
            InitializeComponent();
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var response = await RestHelper.GetAll();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44342/");
            HttpResponseMessage response = client.GetAsync("api/users").Result;
            var emp = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            dataGridView1.DataSource = emp;
        }
    }
}
