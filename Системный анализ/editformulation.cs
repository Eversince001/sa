using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Системный_анализ
{
    public partial class editformulation : Form
    {
        private List<List<string>> solutions = new List<List<string>>();
        private DataGridView DataSolutions = new DataGridView();
        private DataGridViewCellMouseEventArgs e;
        private DataGridViewCellEventArgs E;

        public editformulation(ref List<List<string>> solutions, ref DataGridView DataSolutions, DataGridViewCellMouseEventArgs e, DataGridViewCellEventArgs E)
        {
            this.solutions = solutions;
            this.DataSolutions = DataSolutions;
            this.e = e;
            this.E = E;
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editformulation_Load(object sender, EventArgs e)
        {
            FormulationTextBox.Text = DataSolutions.Rows[this.e.RowIndex].Cells[1].Value.ToString();
        }

        private void SaveformulationButton_Click(object sender, EventArgs e)
        {
            DataSolutions.Rows[this.e.RowIndex].Cells[1].Value = FormulationTextBox.Text;
            this.Close();
        }
    }
}
