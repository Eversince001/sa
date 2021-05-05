using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Системный_анализ
{
    public partial class Menu : Form
    {


        private data DATA = new data();

        public Menu()
        {
            DATA.Load();
            InitializeComponent(); 
        }

        private void AnalystInterfaceButton_Click(object sender, EventArgs e)
        {
            Form Analyst = new AnalystInterface(this, ref DATA);
            this.Hide();

            Analyst.Show();

        }

        private void ExpertInterfaceButton_Click(object sender, EventArgs e)
        {
            Form login = new login(this, ref DATA);
            login.ShowDialog();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {

            DATA.Save();
            Environment.Exit(0);
        }
    }
}
