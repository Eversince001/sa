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
    public partial class AnalystInterface : Form
    {
        private Menu back;
        private ToolStripMenuItem Ready = new ToolStripMenuItem("Отправить на оценку");
        private ContextMenuStrip tmp = new ContextMenuStrip();
        private DataGridViewCellMouseEventArgs temp;


        private data DATA = new data();

        private bool status = false;
        public bool load_status = false;
        public int count;
        private int k = 0, tmpo = 0;


        public AnalystInterface(Menu back, ref data DATA)
        {
            this.back = back;

            this.DATA = DATA;

            InitializeComponent();

            Data.CellValueChanged += Data_CellValueChanged;
            dataGridView.CellValueChanged += dataGridView_CellValueChanged;
            dataGridView.CellMouseClick += dataGridView_CellMouseClick;
            Data.CellMouseClick += Data_CellMouseClick;
            Data.CellDoubleClick += Data_CellDoubleClick;
            archive.CellDoubleClick += archive_CellDoubleClick;
            archive.CellMouseClick += archive_CellMouseClick;
            Ready.Click += new EventHandler(ChangeStatusReady);

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            back.Show();
        }

        private void AnalystInterface_Load(object sender, EventArgs e)
        {
            archive.Visible = false;
            BackArchiveButton.Visible = false;

            //список проблем
            {
                Data.Columns.Add("num", "№");
                Data.Columns.Add("name", "Название");
                Data.Columns.Add("status", "Статус");
                Data.Columns.Add("delete", "");
                Data.Columns.Add("formulation", "");
                Data.Columns[0].ReadOnly = true;
                Data.Columns[2].ReadOnly = true;
                Data.Columns[4].ReadOnly = true;
                Data.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                Data.Columns[1].Width = 813;
                Data.Columns[2].Width += 100;
                Data.Columns[3].Width = 22;
                Data.Columns[3].ReadOnly = true;
                Data.Columns[4].Visible = false;
            }

            //архив
            {
                archive.Columns.Add("num", "№");
                archive.Columns.Add("name", "Название");
                archive.Columns.Add("delete", "");
                archive.Columns.Add("formulation", "");
                archive.Columns[0].ReadOnly = true;
                archive.Columns[1].ReadOnly = true;
                archive.Columns[2].ReadOnly = true;
                archive.Columns[3].Visible = false;
                archive.Columns[0].Width = 43;
                archive.Columns[1].Width = 1012;
                archive.Columns[2].Width = 22;
            }

            //список экспретов
            {
                dataGridView.Columns.Add("name", "Имя");
                dataGridView.Columns.Add("area", "Область деятельности");
                dataGridView.Columns.Add("experience", "Опыт работы");
                dataGridView.Columns.Add("rating", "Рейтинг в своей области");
                dataGridView.Columns.Add("problems", "");
                dataGridView.Columns.Add("del", "");
                dataGridView.Columns.Add("grade", "Оценка компетентности");
                dataGridView.Columns.Add("solving way", "способ решения");


                dataGridView.Columns[5].Width = 22;
                dataGridView.Columns[6].Visible = false;
                dataGridView.Columns[7].Visible = false;
                dataGridView.Columns[5].ReadOnly = true;
                dataGridView.Columns[4].ReadOnly = true;
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[0].Width = 266;
                dataGridView.Columns[1].Width = 390;
                dataGridView.Columns[2].Width = 200;
                dataGridView.Columns[3].Width = 200;
            }

            //список решенных проблем
            {
                dataGridViewResults.Columns.Add("name", "Имя эксперта");
                dataGridViewResults.Columns.Add("problem", "Решенная проблема");
                dataGridViewResults.Columns.Add("method", "");

                dataGridViewResults.Columns[0].ReadOnly = true;
                dataGridViewResults.Columns[1].ReadOnly = true;
                dataGridViewResults.Columns[2].ReadOnly = true;
                dataGridViewResults.Columns[0].Width = 278;
                dataGridViewResults.Columns[1].Width = 600;
                dataGridViewResults.Columns[2].Width = 200;
            }

            if (DATA.Problems.Count == 0) count = 1;
            else count = DATA.Problems.Count + 1;

           //загрузка списка проблем в таблицу
            for (int i = 0; i < DATA.Problems.Count; i++)
            {
                Data.Rows.Add();
                Data.Rows[i].Cells[0].Value = i + 1;
                Data.Rows[i].Cells[1].Value = DATA.Problems[i][0];
                Data.Rows[i].Cells[2].Value = DATA.Problems[i][1];
                Data.Rows[i].Cells[3].Value = " X";
                Data.Rows[i].Cells[3].Style.BackColor = Color.Red;
                Data.Rows[i].Cells[4].Value = DATA.Formulations[i];
                tmp.Items.AddRange(new[] { Ready });
                Data.Rows[i].Cells[2].ContextMenuStrip = tmp;
            }

            //загрузка списка экспертов
            for (int i = 0; i < DATA.experts.Count; i++)
            {
                dataGridView.Rows.Add();
                dataGridView.Rows[i].Cells[0].Value = DATA.experts[i][0];
                dataGridView.Rows[i].Cells[1].Value = DATA.experts[i][1];
                dataGridView.Rows[i].Cells[2].Value = DATA.experts[i][2];
                dataGridView.Rows[i].Cells[3].Value = DATA.experts[i][3];
                dataGridView.Rows[i].Cells[4].Value = DATA.experts[i][4];
                dataGridView.Rows[i].Cells[5].Value = " X";
                dataGridView.Rows[i].Cells[5].Style.BackColor = Color.Red;
            }


            //загрузка архива
            for (int i = 0; i < DATA.ProblemsA.Count; i++)
            {
                archive.Rows.Add();
                archive.Rows[i].Cells[0].Value = i + 1;
                archive.Rows[i].Cells[1].Value = DATA.ProblemsA[i];
                archive.Rows[i].Cells[2].Value = " X";
                archive.Rows[i].Cells[2].Style.BackColor = Color.Red;
                archive.Rows[i].Cells[3].Value = DATA.FormulationsA[i];
            }

            bool done = false;
            int cnt = 0;

            for (int i = 0; i < DATA.Problems.Count; i++)
            {
                if (DATA.experts.Count > 0)
                {
                    for (int j = 0; j < DATA.experts.Count; j++)
                    {

                        if (DATA.ready[j][i] == true) cnt++;

                    }
                }
                else
                {
                    done = false;
                }

                if (cnt == Convert.ToInt32(DATA.Problems[i][2]) && cnt != 0)
                    done = true;

                if (done) { Data.Rows[i].Cells[2].Value = "Эксперты закончили оценку"; DATA.Problems[i][1] = "Эксперты закончили оценку"; }
                cnt = 0;
                done = false;
         
            }


            load_status = true;

        }

        private void Data_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (load_status)
            {
                var a = 1;
                if (Data.Rows.Count == 2)
                    a = 2;
                for (int i = 0; i < Data.Rows.Count - a; i++)
                {
                    if (i == e.RowIndex)
                        continue;

                    if (Data.Rows[i].Cells[1].Value.ToString() == Data.Rows[e.RowIndex].Cells[1].Value.ToString())
                    {
                        Data.Rows.Remove(Data.Rows[e.RowIndex]);
                        MessageBox.Show("Проблема с таким название уже существует!");
                        return;
                    }
                }

                Data.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
                tmp.Items.AddRange(new[] { Ready });
                Data.Rows[e.RowIndex].Cells[2].ContextMenuStrip = tmp;
                Data.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.Red;
                Data.Rows[e.RowIndex].Cells[3].Value = " X";
              

                if (count < Data.Rows.Count)
                {

                    List<string> sol = new List<string>();
                    DATA.solutions.Add(sol);
                    DATA.Problems.Add(new List<string>());
                    DATA.Problems[e.RowIndex].Add(Data.Rows[e.RowIndex].Cells[1].Value.ToString());
                    DATA.Problems[e.RowIndex].Add("");
                    DATA.Problems[e.RowIndex].Add("0");
                    DATA.Formulations.Add("");

                    DATA.exp.Add(new List<string>());

                    // DATA.Results.Add(new List<List<string>>());
                    DATA.Research.Add(new List<List<List<string>>>());


                    for (int i = 0; i < DATA.experts.Count; i++)
                    {
                        if (DATA.Matrix[i].Count < DATA.Problems.Count)
                        {
                            DATA.Matrix[i].Add(new List<List<List<string>>>());
                            DATA.MatrixX[i].Add(new List<List<double>>());
                            DATA.ready[i].Add(false);
                        }
                    }

                    count++;
                }

                if (!status)
                {
                    if (Data.Rows[e.RowIndex].Cells[2].Value != "Готово к оцениванию" && Data.Rows[e.RowIndex].Cells[2].Value != "Эксперты закончили оценку" && Data.Rows[e.RowIndex].Cells[2].Value != "Готово к оцениванию" && Data.Rows[e.RowIndex].Cells[2].Value != "Проблема решена")
                    {
                        Data.Rows[e.RowIndex].Cells[2].Value = "Редактируется";
                        DATA.Problems[e.RowIndex][1] = ("Редактируется");
                    }
                }

            }

        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView.Rows[e.RowIndex].Cells[5].Style.BackColor = Color.Red;
            dataGridView.Rows[e.RowIndex].Cells[5].Value = " X";

        }

        private void Data_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != -1)
                if (Data.Rows[e.RowIndex].Cells[1].Value != null)
                     Data.Rows[e.RowIndex].Cells[2].ContextMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y);

            if (e.ColumnIndex == 3 && e.RowIndex != -1)
                if (Data.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    DATA.solutions.RemoveAt(e.RowIndex);

                    var substr = Data.Rows[e.RowIndex].Cells[1].Value.ToString() + " ";

                    Data.Rows.Remove(Data.Rows[e.RowIndex]);

                    DATA.Problems.RemoveAt(e.RowIndex);

                    DATA.Formulations.RemoveAt(e.RowIndex);

                    DATA.Research.RemoveAt(e.RowIndex);

                    count--;

                    for (int i = 0; i < DATA.experts.Count; i++)
                    {
                        if (DATA.experts[i][4].Contains(substr))
                        {
                            DATA.Matrix[i].RemoveAt(e.RowIndex);
                            DATA.experts[i][4] = DATA.experts[i][4].Replace(substr, "");
                        }
                    }

                    if (DATA.ready.Count != 0) DATA.ready[0].RemoveAt(e.RowIndex);

                    load_status = false;
                    for (int i = 0; i < Data.Rows.Count - 1; i++)
                        Data.Rows[i].Cells[0].Value = (i + 1);
                    load_status = true;
                    
                }

            temp = e;
        }

        private void archive_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != -1)
                if (archive.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    DATA.solutionsA.RemoveAt(e.RowIndex);

                    archive.Rows.Remove(archive.Rows[e.RowIndex]);

                    DATA.ProblemsA.RemoveAt(e.RowIndex);

                    DATA.FormulationsA.RemoveAt(e.RowIndex);

                    for (int i = 0; i < archive.Rows.Count - 1; i++)
                        archive.Rows[i].Cells[0].Value = (i + 1);

                }
        }

        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.ColumnIndex == 5 && e.RowIndex != -1 && dataGridView.Rows[e.RowIndex].Cells[5].Value != null)
            {


                switch (DATA.experts[e.RowIndex][6])
                {
                    case "Метод парных сравнений":
                        for (int i = 0; i < DATA.ready[e.RowIndex].Count; i++)
                        {
                            if (DATA.ready[e.RowIndex][i] == true)
                            {
                                for (int j = 0; j < DATA.Matrix[e.RowIndex][i][0].Count; j++)
                                    for (int k = 0; k < DATA.Matrix[e.RowIndex][i][0].Count; k++)
                                    {
                                        if (j == k)
                                            continue;
                                        DATA.Research[i][0][j][k] = (Convert.ToDouble(DATA.Research[i][0][j][k]) - Convert.ToDouble(DATA.Matrix[e.RowIndex][i][0][j][k])).ToString();
                                    }
                            }
                        }
                        break;

                    case "Метод взвешенных экспертных оценок":

                        break;

                }


                DATA.Matrix.RemoveAt(e.RowIndex);
                DATA.ready.RemoveAt(e.RowIndex);
                tmpo--;
                dataGridView.Rows.Remove(dataGridView.Rows[e.RowIndex]);
            }
        }

        private void Data_CellDoubleClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 1)
            {
                if (Data.Rows[e.RowIndex].Cells[2].Value != "Отправлено на оценку")
                {
                    if (Data.Rows[e.RowIndex].Cells[1].Value != null)
                    {
                        Form edit = new ProblemEdit(this, ref Data, e, ref DATA, false, ref archive);
                        this.Hide();
                        edit.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Вы не сможете изменить параметры проблемы, так как она оценивается экспертами");
                    if (Data.Rows[e.RowIndex].Cells[1].Value != null)
                    {
                        Form edit = new ProblemEdit(this, ref Data, e, ref DATA, false, ref archive);
                        this.Hide();
                        edit.Show();
                    }
                }
            }
        }

        private void archive_CellDoubleClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 1)
            {
                if (archive.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    Form edit = new ProblemEdit(this, ref Data, e, ref DATA, true, ref archive);
                    this.Hide();
                    edit.Show();
                }
            }
        }

        private void ChangeStatusReady(object sender, EventArgs e)
        {
            if (DATA.Problems[temp.RowIndex][1] != "Проблема решена")
            {
                if (DATA.Problems[temp.RowIndex][1] != "Отправлено на оценку")
                {

                    DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите отправить проблему на оценку? Внесение изменнений будет невозможно", "Подтверждение действия", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        bool rdy = false;
                        for (int m = 0; m < DATA.experts.Count; m++)
                        {
                            if (DATA.experts[m][4].Contains(DATA.Problems[temp.RowIndex][0]))
                                rdy = true;
                        }
                        if (rdy)
                        {
                            if (DATA.solutions[temp.RowIndex].Count > 1)
                            {
                                for (int m = 0; m < DATA.experts.Count; m++)
                                {
                                    if (DATA.experts[m][4].Contains(DATA.Problems[temp.RowIndex][0]))
                                    {
                                        if (DATA.Matrix[m][temp.RowIndex].Count < DATA.solutions[temp.RowIndex].Count)
                                        {
                                            DATA.Matrix[m][temp.RowIndex].Clear();

                                            DATA.Matrix[m][temp.RowIndex].Add(new List<List<string>>());

                                            for (int j = 0; j < DATA.solutions[temp.RowIndex].Count; j++)
                                            {
                                                var a = new List<string>();
                                                var d = new List<double>();

                                                for (int k = 0; k < DATA.solutions[temp.RowIndex].Count; k++)
                                                {
                                                    a.Add("");
                                                    d.Add(0);
                                                }

                                                DATA.Matrix[m][temp.RowIndex][0].Add(a);
                                                DATA.MatrixX[m][temp.RowIndex].Add(d);
                                            }
                                        }

                                    }
                                }
                                status = !status;
                                Data.Rows[temp.RowIndex].Cells[2].Value = "Отправлено на оценку";
                                DATA.Problems[temp.RowIndex][1] = "Отправлено на оценку";
                                status = !status;

                                for (int i = 0; i < 5; i++) DATA.Research[temp.RowIndex].Add(new List<List<string>>());
                               

                                for (int i = 0; i < DATA.solutions[temp.RowIndex].Count; i++)
                                {
                                    var a = new List<string>();

                                    for (int k = 0; k < DATA.solutions[temp.RowIndex].Count; k++)
                                    {
                                        a.Add("0");
                                    }

                                    DATA.Research[temp.RowIndex][0].Add(a);
                                    DATA.Research[temp.RowIndex][4].Add(a);
                                }

                                for (int i = 0; i < DATA.solutions[temp.RowIndex].Count; i++)
                                    for (int k = 0; k < DATA.solutions[temp.RowIndex].Count; k++)
                                    {
                                        if (i == k)
                                        {
                                            DATA.Research[temp.RowIndex][0][i][k] = "-1";
                                            DATA.Research[temp.RowIndex][4][i][k] = "-1";
                                        }
                                    }
                            }
                            else
                                MessageBox.Show("Добавьте больше альтернатив для решения проблемы");
                        }
                        else
                            MessageBox.Show("Нет экспертов задействованных в оценке проблемы!");


                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void ExpertList_Click(object sender, EventArgs e)
        {
            tmpo = DATA.experts.Count;
            Data.Visible = false;
            SaveButton.Visible = false;
            BackButton.Visible = false;
            dataGridView.Visible = true;
            ArchiveButton.Visible = false;
            ExpertList.Visible = false;
            ExpertListBack.Visible = true;
        }

        private void BackFromResultsshow_Click(object sender, EventArgs e)
        {
            BackFromResultsshow.Visible = false;
            Data.Visible = true;
            BackButton.Visible = true;
            dataGridViewResults.Visible = false;
            ExpertList.Visible = true;
        }

        private void ArchiveButton_Click(object sender, EventArgs e)
        {
            SaveButton.Visible = false;
            Data.Visible = false;
            archive.Visible = true;
            BackButton.Visible = false;
            ArchiveButton.Visible = false;
            ExpertList.Visible = false;
            BackArchiveButton.Visible = true;
        }

        private void BackArchiveButton_Click(object sender, EventArgs e)
        {
            Data.Visible = true;
            SaveButton.Visible = true;
            archive.Visible = false;
            BackButton.Visible = true;
            ArchiveButton.Visible = true;
            ExpertList.Visible = true;
            BackArchiveButton.Visible = false;
        }

        private void ExpertListBack_Click(object sender, EventArgs e)
        {


            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (dataGridView.Rows[i].Cells[j].Value == null)
                    {
                        MessageBox.Show("Заполните поля: Имя, Область деятельности, Опыт работы");
                        return;
                    }

                }


            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView.Rows.Count - 1; j++)
                {
                    if (i == j)
                        continue;
                    if (dataGridView.Rows[i].Cells[0].Value.ToString() == dataGridView.Rows[j].Cells[0].Value.ToString())
                    {
                        dataGridView.Rows.Remove(dataGridView.Rows[dataGridView.Rows.Count - 2]);
                        MessageBox.Show("У экспертов должны быть разные имена!");
                        return;
                    }
                }
            }


            ArchiveButton.Visible = true;
            Data.Visible = true;
            BackButton.Visible = true;
            dataGridView.Visible = false;
            ExpertList.Visible = true;
            ExpertListBack.Visible = false;
            SaveButton.Visible = true;

            DATA.experts.Clear();


            int k = 0;
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                DATA.experts.Add(new List<string>());
                for (int j = 0; j < 8; j++)
                {
                    if (dataGridView.Rows[i].Cells[j].Value == " X")
                        continue;
                    if (dataGridView.Rows[i].Cells[j].Value != null)
                    {
                        DATA.experts[k].Add(dataGridView.Rows[i].Cells[j].Value.ToString());
                        
                    }
                    else
                    {
                        DATA.experts[k].Add("");
                    }
                }

                k++;
            }


            if (tmpo < DATA.experts.Count)
            {

                for (int i = tmpo; i < DATA.experts.Count; i++)
                {

                    DATA.ready.Add(new List<bool>());

                    DATA.Matrix.Add(new List<List<List<List<string>>>>());
                    DATA.MatrixX.Add(new List<List<List<double>>>());

                    for (int j = 0; j < DATA.Problems.Count; j++)
                    {

                        DATA.Matrix[i].Add(new List<List<List<string>>>());
                        DATA.MatrixX[i].Add(new List<List<double>>());
                        DATA.ready[i].Add(false);
                    }
                }

            }


        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            DATA.Save();

            MessageBox.Show("Данные сохранены в файл");
        }
    }
}
