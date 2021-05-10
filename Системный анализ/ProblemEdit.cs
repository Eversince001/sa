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
    public partial class ProblemEdit : Form
    {
        private AnalystInterface back;
        private ContextMenuStrip setWay = new ContextMenuStrip();
        private ToolStripMenuItem Pare = new ToolStripMenuItem("Метод парных сравнений");
        private DataGridView Data = new DataGridView();
        private DataGridView archive = new DataGridView();
        private DataGridViewCellEventArgs e;
        private List<double> V = new List<double>();
        private List<double> Lj = new List<double>();
        private List<double> S = new List<double>();
        private List<double> v = new List<double>();
        private List<List<double>> F = new List<List<double>>();
        private data DATA = new data();
        private bool arch = false, DataCurrentExpertsChange = true, load = true;
        DataGridViewCellMouseEventArgs tmp;


        public ProblemEdit(AnalystInterface back, ref DataGridView Data, DataGridViewCellEventArgs e, ref data DATA, bool arch, ref DataGridView archive)
        {

            if (arch)
            {
                this.DATA = DATA;
                InitializeComponent();
                this.arch = arch;
                tabControl1.Enabled = false;
                ProblemTextBox.ReadOnly = true;
                this.archive = archive;
                this.e = e;
                this.back = back;
            }
            else
            {

                this.Data = Data;
                this.e = e;
                this.DATA = DATA;
                this.back = back;
                this.archive = archive;


                InitializeComponent();


                Pare.Click += new EventHandler(ChangeMethod);

                DataSolutions.CellValueChanged += Data_CellValueChanged;
                DataCurrentExperts.CellValueChanged += DataCurrentExperts_CellValueChanged;
                DataSolutions.CellMouseClick += DataSolutions_CellMouseClick;
                DataExperts.CellMouseClick += DataExperts_CellMouseClick;
                dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
                DataCurrentExperts.CellMouseClick += DataCurrentExperts_CellMouseClick;
                textBox1.TextChanged += textBox1_TextChanged;
            }

        }

        private void ProblemEdit_Load(object sender, EventArgs e)
        {
            if (!arch)
            {
                if (Data.Rows[this.e.RowIndex].Cells[4].Value != null)
                    ProblemTextBox.Text = Data.Rows[this.e.RowIndex].Cells[4].Value.ToString();
                else
                    ProblemTextBox.Text = "";

                tabControl2.Visible = false;
                BackEditorButton.Visible = false;
                AResultsView.Visible = false;
                PersResultsView.Visible = false;
                button1.Visible = false;
                ProblemSolvedButton.Visible = false;
                RedoProblemButton.Visible = false;
                textBox1.Text = DATA.S.ToString();

                if (Data.Rows[this.e.RowIndex].Cells[2].Value != "Редактируется" && Data.Rows[this.e.RowIndex].Cells[2].Value != "Готово к оцениванию")
                {
                    label2.Visible = false;
                    textBox1.Visible = false;
                }
                else
                {
                    label2.Visible = true;
                    textBox1.Visible = true;
                }

                if (Data.Rows[this.e.RowIndex].Cells[2].Value != "Эксперты закончили оценку")
                {
                    ProblemSolvedButton.Enabled = false;
                    RedoProblemButton.Enabled = false;
                }
                else
                {
                    ProblemSolvedButton.Enabled = true;
                    RedoProblemButton.Enabled = true;
                }

                //список альтернатив выбранной проблемы
                {
                    DataSolutions.Columns.Add("num", "№");
                    DataSolutions.Columns.Add("name", "Альтернатива");
                    DataSolutions.Columns.Add("show", "");
                    DataSolutions.Columns.Add("del", "");
                    DataSolutions.Columns[0].ReadOnly = true;
                    DataSolutions.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    DataSolutions.Columns[1].Width = 953;
                    DataSolutions.Columns[2].Width = 22;
                    DataSolutions.Columns[3].Width = 22;
                    DataSolutions.Columns[2].ReadOnly = true;
                    DataSolutions.Columns[3].ReadOnly = true;
                }

                //список экспертов
                {
                    DataExperts.Columns.Add("name", "Имя");
                    DataExperts.Columns.Add("area", "Область деятельности");
                    DataExperts.Columns.Add("experience", "Опыт работы");
                    DataExperts.Columns.Add("problems", "Участвует");
                    DataExperts.Columns.Add("add", "");
                    DataExperts.Columns.Add("del", "");

                    DataExperts.Columns[4].Width = 22;
                    DataExperts.Columns[5].Width = 22;
                    DataExperts.Columns[4].ReadOnly = true;
                    DataExperts.Columns[3].ReadOnly = true;
                    DataExperts.Columns[2].ReadOnly = true;
                    DataExperts.Columns[1].ReadOnly = true;
                    DataExperts.Columns[0].ReadOnly = true;
                    DataExperts.Columns[5].ReadOnly = true;
                    DataExperts.Columns[0].Width = 310;
                    DataExperts.Columns[1].Width = 400;
                    DataExperts.Columns[2].Width = 180;
                }

                //список экспертов решаюших проблему
                {
                    dataGridView1.Columns.Add("name", "Имя");
                    dataGridView1.Columns.Add("status", "Статус готовности");
                    dataGridView1.Columns.Add("", "");
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Columns[2].ReadOnly = true;
                    dataGridView1.Columns[0].Width = 600;
                    dataGridView1.Columns[1].Width = 240;
                    dataGridView1.Columns[2].Width = 200;

                }

                //результаты
                {
                    ResultsView.Columns.Add("num", "№");
                    ResultsView.Columns.Add("rank", "Ранг");
                    ResultsView.Columns.Add("alter", "Альтернатива");
                    ResultsView.Columns.Add("weight", "Вес");
                    ResultsView.Columns[0].ReadOnly = true;
                    ResultsView.Columns[1].ReadOnly = true;
                    ResultsView.Columns[2].ReadOnly = true;
                    ResultsView.Columns[3].ReadOnly = true;
                    ResultsView.Columns[0].Width = 40;
                    ResultsView.Columns[1].Width = 40;
                    ResultsView.Columns[2].Width = 780;
                    ResultsView.Columns[3].Width = 158;
                }

                //Индивидульные результаты
                {
                    PersResultsView.Columns.Add("num", "№");
                    PersResultsView.Columns.Add("alter", "Альтернатива");
                    PersResultsView.Columns.Add("weight", "Вес");
                    PersResultsView.Columns.Add("rank", "Ранг");
                    PersResultsView.Columns[0].ReadOnly = true;
                    PersResultsView.Columns[1].ReadOnly = true;
                    PersResultsView.Columns[2].ReadOnly = true;
                    PersResultsView.Columns[3].ReadOnly = true;
                    PersResultsView.Columns[0].Width = 40;
                    PersResultsView.Columns[1].Width = 780;
                    PersResultsView.Columns[2].Width = 158;
                    PersResultsView.Columns[3].Width = 40;
                }

                if (Data.Rows[this.e.RowIndex].Cells[2].Value.ToString() == "Отправлено на оценку" || Data.Rows[this.e.RowIndex].Cells[2].Value.ToString() == "Эксперты закончили оценку" || Data.Rows[this.e.RowIndex].Cells[2].Value.ToString() == "Проблема решена")
                {
                    DataSolutions.Enabled = false;
                    DataExperts.Enabled = false;
                    ProblemTextBox.Enabled = false;
                }

                for (int i = 0; i < DATA.solutions[this.e.RowIndex].Count; i++)
                {
                    DataSolutions.Rows.Add();
                    DataSolutions.Rows[i].Cells[1].Value = DATA.solutions[this.e.RowIndex][i];
                    DataSolutions.Rows[i].Cells[0].Value = i + 1;
                    DataSolutions.Rows[i].Cells[3].Style.BackColor = Color.Red;
                    DataSolutions.Columns[2].ReadOnly = true;
                    DataSolutions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    DataSolutions.Columns[2].Width = 22;
                    DataSolutions.Columns[3].Width = 22;
                    DataSolutions.Rows[i].Cells[2].Value = " ...";
                    DataSolutions.Rows[i].Cells[3].Value = " X";
                    DataSolutions.Columns[1].Width = 953;
                }

                for (int i = 0; i < DATA.experts.Count; i++)
                {
                    DataExperts.Rows.Add();
                    DataExperts.Rows[i].Cells[0].Value = DATA.experts[i][0];
                    DataExperts.Rows[i].Cells[1].Value = DATA.experts[i][1];
                    DataExperts.Rows[i].Cells[2].Value = DATA.experts[i][2];

                    DataExperts.Rows[i].Cells[4].Value = " V";
                    DataExperts.Rows[i].Cells[5].Value = " X";
                    DataExperts.Rows[i].Cells[4].Style.BackColor = Color.Green;
                    DataExperts.Rows[i].Cells[5].Style.BackColor = Color.Red;

                    if (DATA.experts[i][4].Contains(Data.Rows[this.e.RowIndex].Cells[1].Value.ToString()))
                        DataExperts.Rows[i].Cells[3].Value = "Да";
                    else
                        DataExperts.Rows[i].Cells[3].Value = "Нет";

                }

                //список задействованых экспертов
                {
                    DataCurrentExperts.Columns.Add("name", "Имя");
                    DataCurrentExperts.Columns.Add("area", "Область деятельности");
                    DataCurrentExperts.Columns.Add("experience", "Опыт работы");
                    DataCurrentExperts.Columns.Add("grade", "Оценка компетентности");
                    DataCurrentExperts.Columns.Add("solving way", "Метод решения");
                    DataCurrentExperts.Columns.Add("del", "");

                    DataCurrentExperts.Columns[0].ReadOnly = true;
                    DataCurrentExperts.Columns[0].Width = 310;
                    DataCurrentExperts.Columns[1].Width = 200;
                    DataCurrentExperts.Columns[1].ReadOnly = true;
                    DataCurrentExperts.Columns[2].ReadOnly = true;
                    DataCurrentExperts.Columns[4].ReadOnly = true;
                    DataCurrentExperts.Columns[2].Width = 180;
                    DataCurrentExperts.Columns[4].Width = 222;
                    DataCurrentExperts.Columns[5].Width = 22;
                    DataCurrentExperts.Columns[5].ReadOnly = true;
                }


                for (int i = 0; i < DATA.experts.Count; i++)
                {
                    if (DATA.experts[i][4].Contains(Data.Rows[this.e.RowIndex].Cells[1].Value.ToString()))
                    {
                        DataCurrentExperts.Rows.Add();
                        DataCurrentExperts.Rows[DataCurrentExperts.Rows.Count - 2].Cells[0].Value = DATA.experts[i][0];
                        DataCurrentExperts.Rows[DataCurrentExperts.Rows.Count - 2].Cells[1].Value = DATA.experts[i][1];
                        DataCurrentExperts.Rows[DataCurrentExperts.Rows.Count - 2].Cells[2].Value = DATA.experts[i][2];
                        DataCurrentExperts.Rows[DataCurrentExperts.Rows.Count - 2].Cells[3].Value = DATA.experts[i][5];
                        DataCurrentExperts.Rows[DataCurrentExperts.Rows.Count - 2].Cells[5].Value = " X";
                        DataCurrentExperts.Rows[DataCurrentExperts.Rows.Count - 2].Cells[5].Style.BackColor = Color.Red;

                        setWay.Items.AddRange(new[] { Pare });
                        DataCurrentExperts.Rows[DataCurrentExperts.Rows.Count - 2].Cells[4].ContextMenuStrip = setWay;
                        if (DATA.experts[i][6] == "")
                            DataCurrentExperts.Rows[DataCurrentExperts.Rows.Count - 2].Cells[4].Value = "";
                        else
                        {
                            DataCurrentExperts.Rows[DataCurrentExperts.Rows.Count - 2].Cells[4].Value = DATA.experts[i][6];
                        }
                    }

                }


                int Rows = -1;
                bool started = false;

                if (Data.Rows[this.e.RowIndex].Cells[2].Value.ToString() != "Готово к оцениванию")
                {
                    //for (int i = 0; i < DATA.experts.Count; i++)
                    //{

                    //    if (DATA.ready.Count > 0)
                    //    {
                    //        if (DATA.ready[i][this.e.RowIndex] == true)
                    //        {
                    //            Rows++;
                    //            dataGridView1.Rows.Add();
                    //            dataGridView1.Rows[Rows].Cells[0].Value = DATA.experts[i][0];
                    //            dataGridView1.Rows[Rows].Cells[1].Value = "Закончил оценивание";
                    //            dataGridView1.Rows[Rows].Cells[2].Value = "Посмотреть результат";
                    //            continue;
                    //        }
                    //    }

                    //    if (Data.Rows[this.e.RowIndex].Cells[2].Value == "Готово к оцениванию")
                    //    {

                    //        Rows++;
                    //        dataGridView1.Rows.Add();
                    //        dataGridView1.Rows[Rows].Cells[0].Value = DATA.experts[i][0];

                    //        for (int j = 0; j < DATA.solutions[this.e.RowIndex].Count; j++)
                    //        {
                    //            for (int k = 0; k < DATA.solutions[this.e.RowIndex].Count; k++)
                    //            {
                    //                if (k == j)
                    //                    continue;

                    //                if (DATA.Matrix[i][this.e.RowIndex][0][j][k] != "")
                    //                {
                    //                    started = true;
                    //                }
                    //            }
                    //        }

                    //        if (started)
                    //        {
                    //            dataGridView1.Rows[Rows].Cells[1].Value = "Приступил к оцениванию";
                    //        }
                    //        else
                    //        {
                    //            dataGridView1.Rows[Rows].Cells[1].Value = "Не приступал к оцениванию";
                    //        }

                    //        dataGridView1.Rows[Rows].Cells[2].Value = "Посмотреть результат";
                    //    }
                    //    started = false;
                    //}
                }

                ResultsView.Rows.Add();
                ResultsView.Rows[0].Cells[2].Value = "Исходный список альтернатив";
                ResultsView.Rows[0].Cells[0].Style.BackColor = Color.Aquamarine;
                ResultsView.Rows[0].Cells[1].Style.BackColor = Color.Aquamarine;
                ResultsView.Rows[0].Cells[2].Style.BackColor = Color.Aquamarine;
                ResultsView.Rows[0].Cells[3].Style.BackColor = Color.Aquamarine;

                for (int i = 0; i < DATA.solutions[this.e.RowIndex].Count; i++)
                {
                    ResultsView.Rows.Add();
                    ResultsView.Rows[i + 1].Cells[0].Value = (i + 1).ToString();
                    ResultsView.Rows[i + 1].Cells[2].Value = DATA.solutions[this.e.RowIndex][i];
                }



                if (Data.Rows[this.e.RowIndex].Cells[2].Value.ToString() == "Эксперты закончили оценку" || Data.Rows[this.e.RowIndex].Cells[2].Value.ToString() == "Проблема решена")
                {
                    tabControl1.Visible = false;
                    ProblemTextBox.Enabled = false;
                    AddExpertButton.Visible = false;
                    V.Clear();

                    if (!arch)
                    {
                        ProblemSolvedButton.Visible = true;
                        RedoProblemButton.Visible = true;
                        tabControl2.Visible = true;

                        bool done = false, done2 = false, done3 = false;

                        ResultsView.Rows.Add();
                        ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[2].Value = "Метод парных сравнений";
                        ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[0].Style.BackColor = Color.Aquamarine;
                        ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[1].Style.BackColor = Color.Aquamarine;
                        ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[2].Style.BackColor = Color.Aquamarine;
                        ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[3].Style.BackColor = Color.Aquamarine;
                        PareCoef1();
                        V.Clear();

                        if (!done)
                        {
                            v.Clear();
                            ResultsView.Rows.Add();
                            ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[2].Value = "Метод взвешенных экспертных оценок";
                            ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[0].Style.BackColor = Color.Aquamarine;
                            ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[1].Style.BackColor = Color.Aquamarine;
                            ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[2].Style.BackColor = Color.Aquamarine;
                            ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[3].Style.BackColor = Color.Aquamarine;
                            ExpertRev();
                            done = !done;
                            V.Clear();
                        }
                        if (!done2)
                        {
                            v.Clear();
                            ResultsView.Rows.Add();
                            ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[2].Value = "Метод предпочтения";
                            ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[0].Style.BackColor = Color.Aquamarine;
                            ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[1].Style.BackColor = Color.Aquamarine;
                            ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[2].Style.BackColor = Color.Aquamarine;
                            ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[3].Style.BackColor = Color.Aquamarine;
                            PreferenceMethod();
                            done2 = !done2;
                        }

                        if (!done3)
                        {
                            v.Clear();
                            S.Clear();
                            ResultsView.Rows.Add();
                            ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[2].Value = "Метод ранга";
                            ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[0].Style.BackColor = Color.Aquamarine;
                            ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[1].Style.BackColor = Color.Aquamarine;
                            ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[2].Style.BackColor = Color.Aquamarine;
                            ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[3].Style.BackColor = Color.Aquamarine;
                            RankMethod();
                            S.Clear();
                            done3 = !done3;
                        }
                        v.Clear();
                        ResultsView.Rows.Add();
                        ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[2].Value = "Метод полного попарного сопоставления";
                        ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[0].Style.BackColor = Color.Aquamarine;
                        ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[1].Style.BackColor = Color.Aquamarine;
                        ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[2].Style.BackColor = Color.Aquamarine;
                        ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[3].Style.BackColor = Color.Aquamarine;
                        FullPareMethod();
                    }
                    else
                    {
                        for (int k = 0; k < DATA.experts.Count; k++)
                        {
                            switch (DATA.experts[k][6])
                            {
                                case "Метод парных сравнений":
                                    PareCoef2();
                                    break;

                                case "Метод взвешенных экспертных оценок":

                                    break;

                            }
                        }
                    }


                }

                load = false;
            }
            else
            {

                label2.Visible = false;
                textBox1.Visible = false;

                if (archive.Rows[this.e.RowIndex].Cells[3].Value != null)
                    ProblemTextBox.Text = archive.Rows[this.e.RowIndex].Cells[3].Value.ToString();
                else
                    ProblemTextBox.Text = "";

                AResultsView.Visible = false;
                tabControl2.Visible = false;
                BackEditorButton.Visible = false;
                button1.Visible = false;
                ProblemSolvedButton.Visible = false;
                RedoProblemButton.Visible = false;

                ResultsArchButton.Visible = true;

                {

                    //результаты архив
                    {
                        AResultsView.Columns.Add("num", "№");
                        AResultsView.Columns.Add("num", "Ранг");
                        AResultsView.Columns.Add("alter", "Альтернатива");
                        AResultsView.Columns.Add("weight", "Вес");
                        AResultsView.Columns[3].ReadOnly = true;
                        AResultsView.Columns[0].ReadOnly = true;
                        AResultsView.Columns[1].ReadOnly = true;
                        AResultsView.Columns[2].ReadOnly = true;
                        AResultsView.Columns[0].Width = 40;
                        AResultsView.Columns[1].Width = 40;
                        AResultsView.Columns[2].Width = 780;
                        AResultsView.Columns[3].Width = 158;
                    }

                    //список альтернатив выбранной проблемы
                    {
                        DataSolutions.Columns.Add("num", "№");
                        DataSolutions.Columns.Add("name", "Альтернатива");
                        DataSolutions.Columns.Add("show", "");
                        DataSolutions.Columns.Add("del", "");
                        DataSolutions.Columns[0].ReadOnly = true;
                        DataSolutions.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        DataSolutions.Columns[1].Width = 953;
                        DataSolutions.Columns[2].Width = 22;
                        DataSolutions.Columns[3].Width = 22;
                        DataSolutions.Columns[2].ReadOnly = true;
                        DataSolutions.Columns[3].ReadOnly = true;
                    }

                    for (int i = 0; i < DATA.solutionsA[this.e.RowIndex].Count; i++)
                    {
                        DataSolutions.Rows.Add();
                        DataSolutions.Rows[i].Cells[1].Value = DATA.solutionsA[this.e.RowIndex][i];
                        DataSolutions.Rows[i].Cells[0].Value = i + 1;
                        DataSolutions.Rows[i].Cells[3].Style.BackColor = Color.Red;
                        DataSolutions.Columns[2].ReadOnly = true;
                        DataSolutions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        DataSolutions.Columns[2].Width = 22;
                        DataSolutions.Columns[3].Width = 22;
                        DataSolutions.Rows[i].Cells[2].Value = " ...";
                        DataSolutions.Rows[i].Cells[3].Value = " X";
                        DataSolutions.Columns[1].Width = 953;
                    }
                }


                PareCoef3();
               
            }


        }
        private void FullPareMethod()
        {
            for (int i = 0; i < DATA.experts.Count; i++)
            {
                if (DATA.ready[i][this.e.RowIndex])
                {
                    F.Add(new List<double>());
                    for (int j = 0; j < DATA.MatrixX[i][this.e.RowIndex].Count; j++)
                    {
                        F[F.Count - 1].Add(0);
                        for (int k = 0; k < DATA.MatrixX[i][this.e.RowIndex].Count; k++)
                        {
                            if (j == k)
                                continue;
                            F[F.Count - 1][j] += DATA.MatrixX[i][this.e.RowIndex][j][k];

                        }
                    }
                }
            }

            int N = DATA.solutions[this.e.RowIndex].Count * (DATA.solutions[this.e.RowIndex].Count - 1);

            for (int i = 0; i < F.Count; i++)
            {
                for (int j = 0; j < F[i].Count; j++)
                {
                    F[i][j] /= N;
                }
            }

            for (int j = 0; j < DATA.solutions[this.e.RowIndex].Count; j++)
            {
                v.Add(0);
                for (int i = 0; i < F.Count; i++)
                {
                    v[j] += F[i][j];

                }
            }


            List<string> a = new List<string>();

            for (int j = 0; j < DATA.solutions[this.e.RowIndex].Count; j++)
            {
                a.Add(DATA.solutions[this.e.RowIndex][j]);
            }


            int index = -1; double max = -1;

            for (int i = 0; i < v.Count; i++)
            {
                for (int j = 0; j < v.Count; j++)
                {
                    if (v[j] > max)
                    {
                        index = j;
                        max = v[j];
                    }
                }
                max = -1;
                ResultsView.Rows.Add();
                ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[0].Value = (index + 1).ToString();
                ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[2].Value = a[index];
                ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[3].Value = v[index].ToString();
                v[index] = -1;

                if (i == 0)
                {
                    ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[1].Value = 1.ToString();
                }
                else
                {
                    if (Convert.ToDouble(ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[3].Value.ToString()) == Convert.ToDouble(ResultsView.Rows[ResultsView.Rows.Count - 3].Cells[3].Value.ToString()))
                    {
                        ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[1].Value = ResultsView.Rows[ResultsView.Rows.Count - 3].Cells[1].Value;
                    }
                    else
                    {
                        ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[1].Value = (Convert.ToInt32(ResultsView.Rows[ResultsView.Rows.Count - 3].Cells[1].Value.ToString()) + 1).ToString();
                    }
                }

            }

        }

        private void RankMethod()
        {

            List<List<double>> Rj = new List<List<double>>(); 

            for (int i = 0; i < DATA.exp[this.e.RowIndex].Count; i++)
            {
                S.Add(0);
                Rj.Add(new List<double>());
                for (int j = 0; j < DATA.solutions[this.e.RowIndex].Count; j++)
                {
                    S[i] += Convert.ToDouble(DATA.Research[this.e.RowIndex][3][i][j]);

                    Rj[i].Add(Convert.ToDouble(DATA.Research[this.e.RowIndex][3][i][j]));
                }
            }

            for (int j = 0; j < DATA.solutions[this.e.RowIndex].Count; j++)
            {
                v.Add(0);
                for (int i = 0; i < DATA.exp[this.e.RowIndex].Count; i++)
                {
                    v[j] += Rj[i][j] / S[i];

                }
            }

            List<string> a = new List<string>();

            for (int j = 0; j < DATA.solutions[this.e.RowIndex].Count; j++)
            {
                a.Add(DATA.solutions[this.e.RowIndex][j]);
            }


            int index = -1; double max = -1;

            for (int i = 0; i < v.Count; i++)
            {
                for (int j = 0; j < v.Count; j++)
                {
                    if (v[j] > max)
                    {
                        index = j;
                        max = v[j];
                    }
                }
                max = -1;
                ResultsView.Rows.Add();
                ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[0].Value = (index + 1).ToString();
                ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[2].Value = a[index];
                ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[3].Value = v[index].ToString();
                v[index] = -1;

                if (i == 0)
                {
                    ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[1].Value = 1.ToString();
                }
                else
                {
                    if (Convert.ToDouble(ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[3].Value.ToString()) == Convert.ToDouble(ResultsView.Rows[ResultsView.Rows.Count - 3].Cells[3].Value.ToString()))
                    {
                        ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[1].Value = ResultsView.Rows[ResultsView.Rows.Count - 3].Cells[1].Value;
                    }
                    else
                    {
                        ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[1].Value = (Convert.ToInt32(ResultsView.Rows[ResultsView.Rows.Count - 3].Cells[1].Value.ToString()) + 1).ToString();
                    }
                }

            }


        }

        private void PreferenceMethod()
        {
            double L = 0;
            for (int j = 0; j < DATA.solutions[this.e.RowIndex].Count; j++)
            {
                Lj.Add(0);
                for (int i = 0; i < DATA.exp[this.e.RowIndex].Count; i++)
                {
                    Lj[j] += Convert.ToDouble(DATA.Research[this.e.RowIndex][2][i][j].ToString());
                }

                L += Lj[j];
            }

            for (int i = 0; i < Lj.Count; i++)
            {
                v.Add(Lj[i]/L);
            }

            List<string> a = new List<string>();


            for (int j = 0; j < DATA.solutions[this.e.RowIndex].Count; j++)
            {
                a.Add(DATA.solutions[this.e.RowIndex][j]);
            }


            int index = -1; double max = -1;

            for (int i = 0; i < v.Count; i++)
            {
                for (int j = 0; j < v.Count; j++)
                {
                    if (v[j] > max)
                    {
                        index = j;
                        max = v[j];
                    }
                }
                max = -1;
                ResultsView.Rows.Add();
                ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[0].Value = (index + 1).ToString();
                ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[2].Value = a[index];
                ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[3].Value = v[index].ToString();
                v[index] = -1;

                if (i == 0)
                {
                    ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[1].Value = 1.ToString();
                }
                else
                {
                    if (Convert.ToDouble(ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[3].Value.ToString()) == Convert.ToDouble(ResultsView.Rows[ResultsView.Rows.Count - 3].Cells[3].Value.ToString()))
                    {
                        ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[1].Value = ResultsView.Rows[ResultsView.Rows.Count - 3].Cells[1].Value;
                    }
                    else
                    {
                        ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[1].Value = (Convert.ToInt32(ResultsView.Rows[ResultsView.Rows.Count - 3].Cells[1].Value.ToString()) + 1).ToString();
                    }
                }

            }

        }

        private void ExpertRev()
        {
            double r = 0;
            for (int i = 0; i < DATA.experts.Count; i++)
                if (DATA.ready[i][this.e.RowIndex])
                    r += Convert.ToDouble(DATA.experts[i][5]);

            for (int i = 0; i < DATA.experts.Count; i++)
                if (DATA.ready[i][this.e.RowIndex])
                    S.Add(Convert.ToDouble(DATA.experts[i][5]) / r);

            for (int j = 0; j < DATA.solutions[this.e.RowIndex].Count; j++)
            {
                v.Add(0);
                for (int i = 0; i < DATA.exp[this.e.RowIndex].Count; i++)
                {
                    v[j] += Convert.ToDouble(DATA.Research[this.e.RowIndex][1][i][j]) * S[i];

                }
            }

            List<string> a = new List<string>();


            for (int j = 0; j < DATA.solutions[this.e.RowIndex].Count; j++)
            {
                a.Add(DATA.solutions[this.e.RowIndex][j]);
            }


            int index = -1; double max = -1;

            for (int i = 0; i < v.Count; i++)
            {
                for (int j = 0; j < v.Count; j++)
                {
                    if (v[j] > max)
                    {
                        index = j;
                        max = v[j];
                    }
                }
                max = -1;
                ResultsView.Rows.Add();
                ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[0].Value = (index + 1).ToString();
                ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[2].Value = a[index];
                ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[3].Value = v[index].ToString();
                v[index] = -1;

                if (i == 0)
                {
                    ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[1].Value = 1.ToString();
                }
                else
                {
                    if (Convert.ToDouble(ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[3].Value.ToString()) == Convert.ToDouble(ResultsView.Rows[ResultsView.Rows.Count - 3].Cells[3].Value.ToString()))
                    {
                        ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[1].Value = ResultsView.Rows[ResultsView.Rows.Count - 3].Cells[1].Value;
                    }
                    else
                    {
                        ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[1].Value = (Convert.ToInt32(ResultsView.Rows[ResultsView.Rows.Count - 3].Cells[1].Value.ToString()) + 1).ToString();
                    }
                }

            }

        }

        private void PareCoef1()
        {
            if (DATA.Research[this.e.RowIndex][0].Count != 0)
            {
                int R = ((DATA.solutions[this.e.RowIndex].Count * DATA.solutions[this.e.RowIndex].Count) - DATA.solutions[this.e.RowIndex].Count) / 2;
                int index = -1; double max = -1;

                for (int i = 0; i < DATA.Research[this.e.RowIndex][0].Count; i++)
                {
                    V.Add(0);
                    for (int j = 0; j < DATA.Research[this.e.RowIndex][0].Count; j++)
                    {
                        if (j == i)
                            continue;

                        V[i] += Convert.ToDouble(DATA.Research[this.e.RowIndex][0][i][j]) / R;
                    }

                }

                List<string> a = new List<string>();


                for (int j = 0; j < DATA.solutions[this.e.RowIndex].Count; j++)
                {
                    a.Add(DATA.solutions[this.e.RowIndex][j]);
                }


                for (int i = 0; i < V.Count; i++)
                {
                    for (int j = 0; j < V.Count; j++)
                    {
                        if (V[j] > max)
                        {
                            index = j;
                            max = V[j];
                        }
                    }
                    max = -1;
                    ResultsView.Rows.Add();
                    ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[0].Value = (index + 1).ToString();
                    ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[2].Value = a[index];
                    ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[3].Value = V[index].ToString();
                    V[index] = -1;

                    if (i == 0)
                    {
                        ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[1].Value = 1.ToString();
                    }
                    else
                    {
                        if (Convert.ToDouble(ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[3].Value.ToString()) == Convert.ToDouble(ResultsView.Rows[ResultsView.Rows.Count - 3].Cells[3].Value.ToString()))
                        {
                            ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[1].Value = ResultsView.Rows[ResultsView.Rows.Count - 3].Cells[1].Value;
                        }
                        else
                        {
                            ResultsView.Rows[ResultsView.Rows.Count - 2].Cells[1].Value = (Convert.ToInt32(ResultsView.Rows[ResultsView.Rows.Count - 3].Cells[1].Value.ToString()) + 1).ToString();
                        }
                    }

                }
            }
        }

        private void PareCoef2()
        {
            for (int i = 0; i < DATA.ResearchA[this.e.RowIndex].Count; i++)
            {
                ResultsView.Rows.Add();
                for (int j = 0; j < 4; j++)
                {
                    if (DATA.ResearchA[this.e.RowIndex][i][0] == "")
                    {
                        ResultsView.Rows[i].Cells[1].Value = DATA.ResearchA[this.e.RowIndex][i][1];
                        ResultsView.Rows[i].Cells[0].Style.BackColor = Color.Aquamarine;
                        ResultsView.Rows[i].Cells[1].Style.BackColor = Color.Aquamarine;
                        ResultsView.Rows[i].Cells[2].Style.BackColor = Color.Aquamarine;
                        break;
                    }
                    else
                    {
                        ResultsView.Rows[i].Cells[0].Value = DATA.ResearchA[this.e.RowIndex][i][0];
                        ResultsView.Rows[i].Cells[1].Value = DATA.ResearchA[this.e.RowIndex][i][1];
                        ResultsView.Rows[i].Cells[2].Value = DATA.ResearchA[this.e.RowIndex][i][2];
                        ResultsView.Rows[i].Cells[3].Value = DATA.ResearchA[this.e.RowIndex][i][3];
                    }
                }
            }
        }

        private void PareCoef3()
        {
            //AResultsView.BringToFront();
            for (int i = 0; i < DATA.ResearchA[this.e.RowIndex].Count; i++)
            {
                AResultsView.Rows.Add();
                for (int j = 0; j < 4; j++)
                {
                    if (DATA.ResearchA[this.e.RowIndex][i][0] == "")
                    {
                        AResultsView.Rows[i].Cells[2].Value = DATA.ResearchA[this.e.RowIndex][i][2];
                        AResultsView.Rows[i].Cells[0].Style.BackColor = Color.Aquamarine;
                        AResultsView.Rows[i].Cells[1].Style.BackColor = Color.Aquamarine;
                        AResultsView.Rows[i].Cells[2].Style.BackColor = Color.Aquamarine;
                        AResultsView.Rows[i].Cells[3].Style.BackColor = Color.Aquamarine;
                        break;
                    }
                    else
                    {
                        AResultsView.Rows[i].Cells[0].Value = DATA.ResearchA[this.e.RowIndex][i][0];
                        AResultsView.Rows[i].Cells[1].Value = DATA.ResearchA[this.e.RowIndex][i][1];
                        AResultsView.Rows[i].Cells[2].Value = DATA.ResearchA[this.e.RowIndex][i][2];
                        AResultsView.Rows[i].Cells[3].Value = DATA.ResearchA[this.e.RowIndex][i][3];
                    }
                }
            }

        }

        private bool textchange = false;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!textchange)
            {
                bool flag = true;
                if (textBox1.Text == "")
                    return;
                if (!Char.IsNumber(sender.ToString()[sender.ToString().Length - 1]) || textBox1.Text == "0")
                {
                    flag = false;
                    MessageBox.Show("Некорректные данные в поле шкалы");
                }

                if (!flag)
                {
                    textchange = true;
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                }
            }

            textchange = false;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            int flag = 0; bool flag2 = false; 
            if (!arch)
            {
                Data.Rows[this.e.RowIndex].Cells[4].Value = ProblemTextBox.Text;
                DATA.Formulations[this.e.RowIndex] = ProblemTextBox.Text;
                DATA.solutions[this.e.RowIndex].Clear();
                DATA.S = Convert.ToDouble(textBox1.Text);


                for (int i = 0; i < DataSolutions.Rows.Count - 1; i++)
                {
                    if (DataSolutions.Rows[i].Cells[1].Value == null)
                        continue;

                    DATA.solutions[this.e.RowIndex].Add(DataSolutions.Rows[i].Cells[1].Value.ToString());
                }

                if (DATA.solutions[this.e.RowIndex].Count > 1)
                {
                    for (int i = 0; i < DATA.experts.Count; i++)
                    {
                        if (flag == DataCurrentExperts.Rows.Count - 1 && flag2)
                            break;
                        if (Data.Rows[this.e.RowIndex].Cells[2].Value.ToString() == "Отправлено на оценку" || Data.Rows[this.e.RowIndex].Cells[2].Value.ToString() == "Эксперты закончили оценку")
                            break;

                        for (int k = 0; k < DataCurrentExperts.Rows.Count - 1; k++)
                        {
                            if (flag == DataCurrentExperts.Rows.Count - 1 && flag2)
                                break;
                            if (DataCurrentExperts.Rows[k].Cells[3].Value != null && DataCurrentExperts.Rows[k].Cells[0].Value == DATA.experts[i][0])
                            {
                                flag++;

                                if (!flag2)
                                {
                                    if (DATA.experts[i][6] == "Метод парных сравнений")
                                        flag2 = true;
                                }

                            }

                        }
                    }
                }

                if (Data.Rows[this.e.RowIndex].Cells[2].Value.ToString() != "Отправлено на оценку" && Data.Rows[this.e.RowIndex].Cells[2].Value.ToString() != "Эксперты закончили оценку")

                if (flag == DataCurrentExperts.Rows.Count - 1 && flag2 && textBox1.Text != "")
                {
                    Data.Rows[this.e.RowIndex].Cells[2].Value = "Готово к оцениванию";
                    DATA.Problems[this.e.RowIndex][1] = "Готово к оцениванию";
                }
                else
                {
                    Data.Rows[this.e.RowIndex].Cells[2].Value = "Редактируется";
                    DATA.Problems[this.e.RowIndex][1] = "Редактируется";
                }

                for (int i = 0; i < DataCurrentExperts.Rows.Count - 1; i++)
                {
                    if (DataCurrentExperts.Rows[i].Cells[3].Value == null || DataCurrentExperts.Rows[i].Cells[3].Value == "")
                        continue;

                    for (int j = 0; j < DATA.experts.Count; j++)
                        if (DataCurrentExperts.Rows[i].Cells[0].Value.ToString() == DATA.experts[j][0].ToString()) { DATA.experts[j][5] = DataCurrentExperts.Rows[i].Cells[3].Value.ToString(); DATA.experts[j][6] = DataCurrentExperts.Rows[i].Cells[4].Value.ToString(); break; }
                }

            }

            else
            {
                ResultsArchButton.Visible = false;
            }

            this.Close();
            back.Show();
        }

        private void ChangeMethod(object sender, EventArgs e)
        {
            DataCurrentExpertsChange = false;
            switch (sender.ToString())
            {
                case "Метод парных сравнений":

                    int alrd = -1;

                    for (int j = 0; j < DATA.experts.Count; j++)
                    {
                        if (DATA.experts[j][6] == "Метод парных сравнений")
                            alrd = j;
                           

                    }

                    for (int j = 0; j < DATA.experts.Count; j++)
                    {
                        if (DATA.experts[j][0] == DataCurrentExperts.Rows[tmp.RowIndex].Cells[0].Value)
                        {
                            if (alrd != -1)
                            {
                                for (int i = 0; i < DataCurrentExperts.Rows.Count; i++)
                                {
                                    if (DataCurrentExperts.Rows[i].Cells[4].Value == "Метод парных сравнений")
                                    {
                                        DataCurrentExperts.Rows[i].Cells[4].Value = "";
                                        for (int k = 0; k < DATA.experts.Count; k++)
                                        {
                                            DATA.experts[k][6] = "";
                                        }
                                    }
                                }
                            }
                            DataCurrentExperts.Rows[tmp.RowIndex].Cells[4].Value = "Метод парных сравнений";
                            DATA.experts[j][6] = "Метод парных сравнений";
                            break;
                        }
                    }
                    tmp = null;
                    break;


            }
            DataCurrentExpertsChange = true;


    }

        private void DataSolutions_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
 
            if (e.ColumnIndex == 3 && e.RowIndex != -1)
                if (DataSolutions.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    DataSolutions.Rows.Remove(DataSolutions.Rows[e.RowIndex]);
                    for (int i = 0; i < DataSolutions.Rows.Count - 1; i++)
                        DataSolutions.Rows[i].Cells[0].Value = (i + 1);

                }

            if (e.ColumnIndex == 2 && e.RowIndex != -1)
                if (DataSolutions.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    Form editor = new editformulation(ref DATA.solutions, ref DataSolutions, e, this.e);
                    editor.ShowDialog();
                }

        }

        private void DataExperts_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.ColumnIndex == 4 && e.RowIndex != -1)
            {

                DataCurrentExpertsChange = false;
                if (DataExperts.Rows[e.RowIndex].Cells[4].Value != null)
                {
                    if (DATA.experts[e.RowIndex][4].Contains(Data.Rows[this.e.RowIndex].Cells[1].Value.ToString()))
                        return;


                    DATA.experts[e.RowIndex][4] += Data.Rows[this.e.RowIndex].Cells[1].Value.ToString() + "  ";
                    DataExperts.Rows[e.RowIndex].Cells[3].Value = "Да";

                    DataCurrentExperts.Rows.Add();
                    DataCurrentExperts.Rows[DataCurrentExperts.Rows.Count - 2].Cells[0].Value = DATA.experts[e.RowIndex][0];
                    DataCurrentExperts.Rows[DataCurrentExperts.Rows.Count - 2].Cells[1].Value = DATA.experts[e.RowIndex][1];
                    DataCurrentExperts.Rows[DataCurrentExperts.Rows.Count - 2].Cells[2].Value = DATA.experts[e.RowIndex][2];
                    DataCurrentExperts.Rows[DataCurrentExperts.Rows.Count - 2].Cells[5].Value = " X";
                    DataCurrentExperts.Rows[DataCurrentExperts.Rows.Count - 2].Cells[5].Style.BackColor = Color.Red;

                    setWay.Items.AddRange(new[] { Pare });
                    DataCurrentExperts.Rows[DataCurrentExperts.Rows.Count - 2].Cells[4].ContextMenuStrip = setWay;
                    DataCurrentExperts.Rows[DataCurrentExperts.Rows.Count - 2].Cells[4].Value = "";
                    DATA.Problems[this.e.RowIndex][2] = (Convert.ToInt32(DATA.Problems[this.e.RowIndex][2]) + 1).ToString();


                }

                DataCurrentExpertsChange = true;
            }

            if (e.ColumnIndex == 5 && e.RowIndex != -1)
            {
                if (DataExperts.Rows[e.RowIndex].Cells[5].Value != null)
                {
                    if (!DATA.experts[e.RowIndex][4].Contains(Data.Rows[this.e.RowIndex].Cells[1].Value.ToString()))
                        return;

                    for (int i = 0; i < DataCurrentExperts.Rows.Count; i++)
                    {
                        if (DataCurrentExperts.Rows[i].Cells[0].Value == DataExperts.Rows[e.RowIndex].Cells[0].Value)
                        {
                            DataCurrentExperts.Rows.Remove(DataCurrentExperts.Rows[i]);
                            DATA.Problems[this.e.RowIndex][2] = (Convert.ToInt32(DATA.Problems[this.e.RowIndex][2]) - 1).ToString();
                        }
                    }

                    var substr = Data.Rows[this.e.RowIndex].Cells[1].Value.ToString() + "  ";
                    DATA.experts[e.RowIndex][4] = DATA.experts[e.RowIndex][4].Replace(substr, "");
                    DataExperts.Rows[e.RowIndex].Cells[3].Value = "Нет";
                }
            }

        }

        private void DataCurrentExperts_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex != -1)
            {
                if  (DataCurrentExperts.Rows[e.RowIndex].Cells[5].Value != null)
                {
                    for (int i = 0; i < DataExperts.Rows.Count; i++)
                    {
                        if (DataExperts.Rows[i].Cells[0].Value == DataCurrentExperts.Rows[e.RowIndex].Cells[0].Value)
                        {
                            var substr = Data.Rows[this.e.RowIndex].Cells[1].Value.ToString() + "  ";
                            DATA.experts[i][4] = DATA.experts[e.RowIndex][4].Replace(substr, "");
                            DataExperts.Rows[i].Cells[3].Value = "Нет";
                        }
                    }

                    DataCurrentExperts.Rows.Remove(DataCurrentExperts.Rows[e.RowIndex]);
                }
            }


            if (e.ColumnIndex == 4 && e.RowIndex != -1)
            {
                if (DataCurrentExperts.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    DataCurrentExperts.Rows[e.RowIndex].Cells[4].ContextMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y);
                    tmp = e;
                }
            }

        }

        private void Data_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataSolutions.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
            DataSolutions.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.Red;
            DataSolutions.Columns[2].ReadOnly = true;
            DataSolutions.Columns[3].ReadOnly = true;
            DataSolutions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DataSolutions.Rows[e.RowIndex].Cells[3].Value = " X";
            DataSolutions.Rows[e.RowIndex].Cells[2].Value = " ...";
        }

        private bool isNumber(String str)
        {
            try
            {
                double v = Double.Parse(str);
                return true;
            }
            catch (Exception e)
            {
            }
            return false;
        }

        private void DataCurrentExperts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!load)
            {
                if (DataCurrentExpertsChange)
                {
                    if (DataCurrentExperts.Rows[e.RowIndex].Cells[3].Value != null)
                    {
                        DataCurrentExperts.Rows[e.RowIndex].Cells[3].Value = DataCurrentExperts.Rows[e.RowIndex].Cells[3].Value.ToString().Replace(".", ",");

                        if (DataCurrentExperts.Rows[e.RowIndex].Cells[4].Value != null && DataCurrentExperts.Rows[e.RowIndex].Cells[4].Value != "" && DataCurrentExperts.Rows[e.RowIndex].Cells[4].Value != "Метод парных сравнений")
                        {

                            if (!isNumber(DataCurrentExperts.Rows[e.RowIndex].Cells[3].Value.ToString()))
                            {
                                DataCurrentExperts.Rows[e.RowIndex].Cells[3].Value = "";
                                MessageBox.Show("Некорректные данные в поле компетентности");
                                return;
                            }

                            if (Convert.ToDouble(DataCurrentExperts.Rows[e.RowIndex].Cells[3].Value) > 12 || Convert.ToDouble(DataCurrentExperts.Rows[e.RowIndex].Cells[3].Value) < 1)
                            {
                                DataCurrentExperts.Rows[e.RowIndex].Cells[3].Value = "";
                                MessageBox.Show("Некорректные данные в поле компетентности");
                                return;
                            }

                        }
                    }
                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            try
            {
            if (e.ColumnIndex == 2 && e.RowIndex != -1 && dataGridView1.Rows[e.RowIndex].Cells[2].Value != null && dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() == "Закончил оценивание")
            {
                button1.Visible = true;
                BackEditorButton.Visible = false;
                tabControl2.Enabled = false;
                ProblemSolvedButton.Visible = false;
                RedoProblemButton.Visible = false;
                int ID = 0;
                V.Clear();
                PersResultsView.Rows.Clear();
                for (int i = 0; i < DATA.experts.Count; i++)
                {
                    if (DATA.experts[i][0] == dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString())
                    {
                        ID = i;
                        break;
                    }
                }

                PersResultsView.Visible = true;
                dataGridView1.Visible = false;

                {
                    PersResultsView.Rows.Add();

                    PersResultsView.Rows[0].Cells[1].Value = "Метод парных сравнений";
                    PersResultsView.Rows[0].Cells[0].Style.BackColor = Color.Aquamarine;
                    PersResultsView.Rows[0].Cells[1].Style.BackColor = Color.Aquamarine;
                    PersResultsView.Rows[0].Cells[2].Style.BackColor = Color.Aquamarine;

                    int R = ((DATA.solutions[this.e.RowIndex].Count * DATA.solutions[this.e.RowIndex].Count) - DATA.solutions[this.e.RowIndex].Count) / 2;

                    int index1 = -1; double max1 = -1;


                    for (int i = 0; i < DATA.solutions[this.e.RowIndex].Count; i++)
                    {
                        V.Add(0);
                        for (int j = 0; j < DATA.solutions[this.e.RowIndex].Count; j++)
                        {
                            if (j == i)
                                continue;

                            V[i] += Convert.ToDouble(DATA.Matrix[ID][this.e.RowIndex][0][i][j]) / R;
                        }

                    }

                    List<string> c = new List<string>();


                    for (int j = 0; j < DATA.solutions[this.e.RowIndex].Count; j++)
                    {
                        c.Add(DATA.solutions[this.e.RowIndex][j]);
                    }


                    for (int i = 0; i < V.Count; i++)
                    {
                        for (int j = 0; j < V.Count; j++)
                        {
                            if (V[j] > max1)
                            {
                                index1 = j;
                                max1 = V[j];
                            }
                        }
                        max1 = -1;
                        PersResultsView.Rows.Add();
                        PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[0].Value = (index1 + 1).ToString();
                        PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[1].Value = c[index1];
                        PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[2].Value = V[index1].ToString();
                        V[index1] = -1;
                    }
                    V.Clear();


                    PersResultsView.Rows.Add();
                    PersResultsView.Rows[0].Cells[1].Value = "Метод взвешенных экспертных оценок";
                    PersResultsView.Rows[0].Cells[0].Style.BackColor = Color.Aquamarine;
                    PersResultsView.Rows[0].Cells[1].Style.BackColor = Color.Aquamarine;
                    PersResultsView.Rows[0].Cells[2].Style.BackColor = Color.Aquamarine;
                    v.Clear();
                    double r = 0;
                    for (int i = 0; i < DATA.experts.Count; i++)
                        if (DATA.experts[i][6] == "Метод взвешенных экспертных оценок")
                        {
                            r += Convert.ToDouble(DATA.experts[i][5]);
                        }

                    for (int i = 0; i < DATA.experts.Count; i++)
                        if (DATA.experts[i][6] == "Метод взвешенных экспертных оценок")
                        {
                            S.Add(Convert.ToDouble(DATA.experts[i][5]) / r);
                        }

                    int temp = 0;

                    for (int j = 0; j < DATA.solutions[this.e.RowIndex].Count; j++)
                    {
                        v.Add(0);
                        for (int i = 0; i < DATA.exp.Count; i++)
                        {
                            v[j] += Convert.ToDouble(DATA.Research[this.e.RowIndex][1][i][j]) * S[i];

                        }
                    }

                    List<string> b = new List<string>();


                    for (int j = 0; j < DATA.solutions[this.e.RowIndex].Count; j++)
                    {
                        b.Add(DATA.solutions[this.e.RowIndex][j]);
                    }


                    int indexx = -1; double maxx = -1;

                    for (int i = 0; i < v.Count; i++)
                    {
                        for (int j = 0; j < v.Count; j++)
                        {
                            if (v[j] > maxx)
                            {
                                indexx = j;
                                maxx = v[j];
                            }
                        }
                        maxx = -1;
                        PersResultsView.Rows.Add();
                        PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[0].Value = (indexx + 1).ToString();
                        PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[1].Value = b[indexx];
                        PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[2].Value = v[indexx].ToString();
                        v[indexx] = -1;

                        if (i == 0)
                        {
                            PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[3].Value = 1.ToString();
                        }
                        else
                        {
                            if (Convert.ToDouble(PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[2].Value.ToString()) == Convert.ToDouble(PersResultsView.Rows[PersResultsView.Rows.Count - 3].Cells[2].Value.ToString()))
                            {
                                PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[3].Value = PersResultsView.Rows[PersResultsView.Rows.Count - 3].Cells[3].Value;
                            }
                            else
                            {
                                PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[3].Value = (Convert.ToInt32(PersResultsView.Rows[PersResultsView.Rows.Count - 3].Cells[3].Value.ToString()) + 1).ToString();
                            }
                        }

                    }



                    PersResultsView.Rows.Add();
                    PersResultsView.Rows[0].Cells[1].Value = "Метод предпочтения";
                    PersResultsView.Rows[0].Cells[0].Style.BackColor = Color.Aquamarine;
                    PersResultsView.Rows[0].Cells[1].Style.BackColor = Color.Aquamarine;
                    PersResultsView.Rows[0].Cells[2].Style.BackColor = Color.Aquamarine;
                    v.Clear();

                    double L = 0;
                    for (int j = 0; j < DATA.solutions[this.e.RowIndex].Count; j++)
                    {
                        Lj.Add(0);
                        for (int i = 0; i < DATA.exp[this.e.RowIndex].Count; i++)
                        {
                            Lj[j] += Convert.ToInt32(DATA.Research[this.e.RowIndex][2][i][j]);
                        }

                        L += Lj[j];
                    }

                    for (int i = 0; i < Lj.Count; i++)
                    {
                        v.Add(Lj[i] / L);
                    }

                    List<string> a = new List<string>();


                    for (int j = 0; j < DATA.solutions[this.e.RowIndex].Count; j++)
                    {
                        a.Add(DATA.solutions[this.e.RowIndex][j]);
                    }


                    int index = -1; double max = -1;

                    for (int i = 0; i < v.Count; i++)
                    {
                        for (int j = 0; j < v.Count; j++)
                        {
                            if (v[j] > max)
                            {
                                index = j;
                                max = v[j];
                            }
                        }
                        max = -1;
                        PersResultsView.Rows.Add();
                        PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[0].Value = (index + 1).ToString();
                        PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[1].Value = a[index];
                        PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[2].Value = v[index].ToString();
                        v[index] = -1;

                        if (i == 0)
                        {
                            PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[3].Value = 1.ToString();
                        }
                        else
                        {
                            if (Convert.ToDouble(PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[2].Value.ToString()) == Convert.ToDouble(PersResultsView.Rows[PersResultsView.Rows.Count - 3].Cells[2].Value.ToString()))
                            {
                                PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[3].Value = PersResultsView.Rows[PersResultsView.Rows.Count - 3].Cells[3].Value;
                            }
                            else
                            {
                                PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[3].Value = (Convert.ToInt32(PersResultsView.Rows[PersResultsView.Rows.Count - 3].Cells[3].Value.ToString()) + 1).ToString();
                            }
                        }

                    }




                    PersResultsView.Rows.Add();
                    PersResultsView.Rows[0].Cells[1].Value = "Метод предпочтения";
                    PersResultsView.Rows[0].Cells[0].Style.BackColor = Color.Aquamarine;
                    PersResultsView.Rows[0].Cells[1].Style.BackColor = Color.Aquamarine;
                    PersResultsView.Rows[0].Cells[2].Style.BackColor = Color.Aquamarine;
                    v.Clear();
                    S.Clear();

                    List<List<double>> Rj = new List<List<double>>();

                    for (int i = 0; i < DATA.exp[this.e.RowIndex].Count; i++)
                    {
                        S.Add(0);
                        Rj.Add(new List<double>());
                        for (int j = 0; j < DATA.solutions[this.e.RowIndex].Count; j++)
                        {
                            S[i] += Convert.ToDouble(DATA.Research[this.e.RowIndex][3][i][j]);

                            Rj[i].Add(Convert.ToDouble(DATA.Research[this.e.RowIndex][3][i][j]));
                        }
                    }

                    for (int j = 0; j < DATA.solutions[this.e.RowIndex].Count; j++)
                    {
                        v.Add(0);
                        for (int i = 0; i < DATA.exp[this.e.RowIndex].Count; i++)
                        {
                            v[j] += Rj[i][j] / S[i];

                        }
                    }

                    List<string> A = new List<string>();

                    for (int j = 0; j < DATA.solutions[this.e.RowIndex].Count; j++)
                    {
                        A.Add(DATA.solutions[this.e.RowIndex][j]);
                    }


                    int Index = -1; double Max = -1;

                    for (int i = 0; i < v.Count; i++)
                    {
                        for (int j = 0; j < v.Count; j++)
                        {
                            if (v[j] > Max)
                            {
                                Index = j;
                               Max = v[j];
                            }
                        }
                        Max = -1;
                        PersResultsView.Rows.Add();
                        PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[0].Value = (Index + 1).ToString();
                        PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[1].Value = A[Index];
                        PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[2].Value = v[Index].ToString();
                        v[Index] = -1;

                        if (i == 0)
                        {
                            PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[3].Value = 1.ToString();
                        }
                        else
                        {
                            if (Convert.ToDouble(PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[2].Value.ToString()) == Convert.ToDouble(PersResultsView.Rows[PersResultsView.Rows.Count - 3].Cells[2].Value.ToString()))
                            {
                                PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[3].Value = PersResultsView.Rows[PersResultsView.Rows.Count - 3].Cells[3].Value;
                            }
                            else
                            {
                                PersResultsView.Rows[PersResultsView.Rows.Count - 2].Cells[3].Value = (Convert.ToInt32(PersResultsView.Rows[PersResultsView.Rows.Count - 3].Cells[3].Value.ToString()) + 1).ToString();
                            }
                        }

                    }
                }

            }
            }
            catch
            {
                MessageBox.Show("ОЙ что-то пошло не так!");
            }
          
        }

        private void BackEditorButton_Click(object sender, EventArgs e)
        {
            this.Text = "Редактор проблемы";
            tabControl1.Visible = true;
            BackButton.Visible = true;
            AddExpertButton.Visible = true;
            ProblemTextBox.Enabled = true;
            if (!arch) ProblemTextBox.ReadOnly = true;
            ProblemSolvedButton.Visible = false;
            RedoProblemButton.Visible = false;
            tabControl2.Visible = false;
            AResultsView.Visible = false;
            BackEditorButton.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProblemSolvedButton.Visible = true;
            button1.Visible = false;
            PersResultsView.Visible = false;
            dataGridView1.Visible = true;
            RedoProblemButton.Visible = true;
            BackEditorButton.Visible = true;
            tabControl2.Enabled = true;
        }

        private void ProblemSolvedButton_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите пометить проблему как решенную? Проблема будет занесена в ахив", "Подтверждение действия", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Data.Rows[this.e.RowIndex].Cells[2].Value == "Эксперты закончили оценку")
                {
                    Data.Rows[this.e.RowIndex].Cells[2].Value = "Проблема решена";
                    DATA.Problems[this.e.RowIndex][1] = "Проблема решена";
                    ProblemSolvedButton.Enabled = false;
                    RedoProblemButton.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Дождитесь, пока все экперты закончат оценку");
                }


                if (Data.Rows[this.e.RowIndex].Cells[1].Value != null)
                {


                    archive.Rows.Add();
                    archive.Rows[archive.Rows.Count - 2].Cells[0].Value = archive.Rows.Count - 1;
                    archive.Rows[archive.Rows.Count - 2].Cells[1].Value = DATA.Problems[this.e.RowIndex][0];
                    archive.Rows[archive.Rows.Count - 2].Cells[2].Value = " X";
                    archive.Rows[archive.Rows.Count - 2].Cells[2].Style.BackColor = Color.Red;
                    archive.Rows[archive.Rows.Count - 2].Cells[3].Value = DATA.Formulations[this.e.RowIndex];

                    DATA.solutionsA.Add(new List<string>());

                    for (int i = 0; i < DATA.solutions[this.e.RowIndex].Count; i++)
                    {
                        DATA.solutionsA[archive.Rows.Count - 2].Add(DATA.solutions[this.e.RowIndex][i]);
                    }

                    DATA.ProblemsA.Add(DATA.Problems[this.e.RowIndex][0]);

                    DATA.FormulationsA.Add(DATA.Formulations[this.e.RowIndex]);

                    DATA.ResearchA.Add(new List<List<string>>());

                    for (int i = 0; i < ResultsView.Rows.Count - 1; i++) 
                    {
                        DATA.ResearchA[DATA.ResearchA.Count - 1].Add(new List<string>());

                        for (int j = 0; j < 4; j++)
                        {
                            if (ResultsView.Rows[i].Cells[j].Value != null) DATA.ResearchA[DATA.ResearchA.Count - 1][i].Add(ResultsView.Rows[i].Cells[j].Value.ToString());
                            else DATA.ResearchA[DATA.ResearchA.Count - 1][i].Add("");

                        }
                    }

                    DATA.solutions.RemoveAt(this.e.RowIndex);

                    var substr = Data.Rows[this.e.RowIndex].Cells[1].Value.ToString() + " ";

                    Data.Rows.Remove(Data.Rows[this.e.RowIndex]);

                    DATA.Problems.RemoveAt(this.e.RowIndex);

                    DATA.Research.RemoveAt(this.e.RowIndex);

                    DATA.Formulations.RemoveAt(this.e.RowIndex);

                    DATA.exp.RemoveAt(this.e.RowIndex);

                    back.count--;

                    for (int i = 0; i < DATA.experts.Count; i++)
                    {
                        if (DATA.experts[i][4].Contains(substr))
                        {
                            DATA.Matrix[i].RemoveAt(this.e.RowIndex);
                            DATA.MatrixX[i].RemoveAt(this.e.RowIndex);
                            DATA.experts[i][4] = DATA.experts[i][4].Replace(substr, "");
                        }
                    }


                    DATA.ready.RemoveAt(this.e.RowIndex);

                    back.load_status = false;
                    for (int i = 0; i < Data.Rows.Count - 1; i++)
                        Data.Rows[i].Cells[0].Value = (i + 1);
                    back.load_status = true;

                }

                MessageBox.Show("Решенная проблема была занесена в архив");

                Close();
                back.Show();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void RedoProblemButton_Click(object sender, EventArgs e)
        {
            if (Data.Rows[this.e.RowIndex].Cells[2].Value == "Эксперты закончили оценку")
            {
                Data.Rows[this.e.RowIndex].Cells[2].Value = "Редактируется";
                DATA.Problems[this.e.RowIndex][1] = "Редактируется";
                ProblemSolvedButton.Enabled = false;
                RedoProblemButton.Enabled = false;
                ProblemTextBox.Enabled = true;
                tabControl1.Enabled = true;
                DataSolutions.Enabled = true;
                DataExperts.Enabled = true;

                for (int i = 0; i < DATA.ready[this.e.RowIndex].Count; i++)
                    DATA.ready[this.e.RowIndex][i] = false;

                DATA.Research[this.e.RowIndex].Clear();

                for (int i = 0; i < DATA.exp[this.e.RowIndex].Count; i++)
                    DATA.exp[this.e.RowIndex].Clear();

            }
            else
            {
                MessageBox.Show("Дождитесь, пока все экперты закончат оценку");
            }

        }

        private void AddExpertButton_Click(object sender, EventArgs e)
        {
            DataExperts.Visible = true;
            BackButton.Visible = false;
            EditorBackButton.Visible = true;
            ProblemTextBox.Enabled = false;
            AddExpertButton.Visible = false;
            DataCurrentExperts.Visible = false;
        }

        private void EditorBackButton_Click(object sender, EventArgs e)
        {
            EditorBackButton.Visible = false;
            DataExperts.Visible = false;
            BackButton.Visible = true;
            ProblemTextBox.Enabled = true;
            AddExpertButton.Visible = true;
            DataCurrentExperts.Visible = true;
        }

        private void ResultsView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ResultsArchButton_Click(object sender, EventArgs e)
        {
            AResultsView.Visible = true;
            AltrListButton.Visible = true;
            ResultsArchButton.Visible = false;
        }

        private void AltrListButton_Click(object sender, EventArgs e)
        {
            AResultsView.Visible = false;
            AltrListButton.Visible = false;
            ResultsArchButton.Visible = true;
        }
    }
}
