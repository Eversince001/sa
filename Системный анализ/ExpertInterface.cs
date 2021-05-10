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
    public partial class ExpertInterface : Form
    {
        private Menu back;
        private data DATA = new data();
        private login close;
        private int ProblemID, ID, Page = 1, Zx = 0, Zy = 1, zX = 0, zY = 1, Page4 = 1, iD;
        private int end = 0, Method = 0, temp, End = 0;
        private bool load = true; string tempp = "Количество нераспределенных значений - ";
        private List<bool> Meth = new List<bool>();

        public ExpertInterface(Menu back, login close,  int ProblemID, int ID, ref data DATA)
        {
            this.back = back;
            this.close = close;
            this.ProblemID = ProblemID;
            this.ID = ID;
            this.DATA = DATA;
            InitializeComponent();

            textBoxFirst.Click += new EventHandler(setFirst);
            textBoxSecond.Click += new EventHandler(setSecond);
            LabelBoth.Click += new EventHandler(setBoth);
            labelmeth.Click += new EventHandler(setS);
            dataGridView.CellValueChanged += dataGridView_CellValueChanged;

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

        private bool isNumeric(String str)
        {
            try
            {
                int v = int.Parse(str);
                return true;
            }
            catch (Exception e)
            {
            }
            return false;
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (!load)
            {
                load = true;
                if (Method == 1)
                {
                    if (dataGridView.Rows[e.RowIndex].Cells[2].Value != null)
                    {
                        dataGridView.Rows[e.RowIndex].Cells[2].Value = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString().Replace(".", ",");

                        if (!isNumber(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString()))
                        {
                            dataGridView.Rows[e.RowIndex].Cells[2].Value = "";
                            MessageBox.Show("Некорректные данные в поле значения");
                            load = false;
                            return;
                        }

                        if (Convert.ToDouble(dataGridView.Rows[e.RowIndex].Cells[2].Value) > 1 || Convert.ToDouble(dataGridView.Rows[e.RowIndex].Cells[2].Value) < 0)
                        {
                            dataGridView.Rows[e.RowIndex].Cells[2].Value = "";
                            MessageBox.Show("Некорректные данные в поле значения");
                            load = false;
                            return;
                        }

                        DATA.Research[ProblemID][Method][ID][e.RowIndex] = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                    }

                    bool flag = true;

                    double a = 0;
                    for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                    {
                        if (dataGridView.Rows[i].Cells[2].Value == null || dataGridView.Rows[i].Cells[2].Value == "")
                            continue;
                        a += Convert.ToDouble(dataGridView.Rows[i].Cells[2].Value.ToString());
                    }

                    if (a > 1)
                    {
                        flag = false;
                        MessageBox.Show("Сумма значений должна быть равна 1");
                    }

                    if (a <= 0)
                    {
                        flag = false;
                        MessageBox.Show("Сумма значений должна быть равна 1");
                    }

                    if (flag)
                    {
                        for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                        {
                            if (dataGridView.Rows[i].Cells[2].Value == null)
                            {
                                flag = false;
                                break;
                            }

                        }
                    }

                    if (flag)
                        if (a < 1)
                        {
                            flag = false;
                            MessageBox.Show("Сумма значений должна быть равна 1");
                        }

                    if (a <= 1) labelmeth.Text = tempp + (1 - a).ToString();
                    else labelmeth.Text = "Сумма значений превышает 1";


                    if (flag)
                    {
                        Meth[1] = true;
                    }
                    else
                    {
                        Meth[1] = false;
                    }
                }

                if (Method == 2)
                {

                    for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                    {
                        dataGridView.Rows[i].Cells[2].Style.BackColor = Color.White;
                    }

                    if (dataGridView.Rows[e.RowIndex].Cells[2].Value != null)
                    {
                        if (!isNumeric(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString()))
                        {
                            dataGridView.Rows[e.RowIndex].Cells[2].Value = "";
                            MessageBox.Show("Некорректные данные в поле значения");
                            load = false;
                            return;
                        }

                        if (Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[2].Value) < 1 || Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[2].Value) > DATA.solutions[ProblemID].Count)
                        {
                            dataGridView.Rows[e.RowIndex].Cells[2].Value = "";
                            MessageBox.Show("Некорректные данные в поле значения");
                            load = false;
                            return;
                        }

                        for (int i = 0; i < dataGridView.Rows.Count; i++)
                        {
                            if (i == e.RowIndex)
                                continue;

                            if (dataGridView.Rows[i].Cells[2].Value != null)
                            {
                                if (dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString() != dataGridView.Rows[i].Cells[2].Value.ToString())
                                    continue;
                                else
                                {
                                    dataGridView.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.Red;
                                    dataGridView.Rows[i].Cells[2].Style.BackColor = Color.Red;
                                    MessageBox.Show("Такое значние предпочтения уже занято");
                                    load = false;
                                    return;
                                }
                            }
                        }

                        DATA.Research[ProblemID][Method][ID][e.RowIndex] = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();

                        bool flag = true;

                        for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                        {
                            if (dataGridView.Rows[i].Cells[2].Value == null || dataGridView.Rows[i].Cells[2].Value == "" || dataGridView.Rows[i].Cells[2].Style.BackColor == Color.Red)
                            {
                                flag = false;
                                break;
                            }

                        }

                        if (flag)
                        {
                            Meth[2] = true;
                        }
                        else
                        {
                            Meth[2] = false;
                        }

                    }

                }

                if (Method == 3)
                {
                    if (dataGridView.Rows[e.RowIndex].Cells[2].Value != null)
                    {
                        if (!isNumeric(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString()))
                        {
                            dataGridView.Rows[e.RowIndex].Cells[2].Value = "";
                            MessageBox.Show("Некорректные данные в поле значения");
                            load = false;
                            return;
                        }


                        if (Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[2].Value) < 1 || Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[2].Value) > 10)
                        {
                            dataGridView.Rows[e.RowIndex].Cells[2].Value = "";
                            MessageBox.Show("Некорректные данные в поле значения");
                            load = false;
                            return;
                        }

                        DATA.Research[ProblemID][Method][ID][e.RowIndex] = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();

                        bool flag = true;

                        for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                        {
                            if (dataGridView.Rows[i].Cells[2].Value == null || dataGridView.Rows[i].Cells[2].Value == "")
                            {
                                flag = false;
                                break;
                            }

                        }

                        if (flag)
                        {
                            Meth[3] = true;
                        }
                        else
                        {
                            Meth[3] = false;
                        }
                    }
                }

                bool rdy = true;

                for (int i = 0; i < Meth.Count; i++)
                {
                    if (Meth[i] == false)
                    {
                        rdy = false;
                        break;
                    }
                }

                if (rdy)
                {
                    EndButton.Enabled = true;
                }

                else
                {
                    EndButton.Enabled = false;
                }

                load = false;
            }

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            close.Close();
            this.Close();
            back.Show();
            return;
        }

        private void ExpertInterface_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            { 
                Meth.Add(false);
            }

            iD = ID;

            switch (DATA.experts[ID][6])
            {
                case "Метод парных сравнений":
                    Method = 0;
                    LabelBoth.Visible = true;
                    WhatToDoLabel.Visible = true;
                    NextButton.Visible = true;
                    SelectPage.Visible = true;
                    label2.Visible = true;
                    ListLabel.Visible = true;
                    PageTextBox.Visible = true;
                    PreviousButton.Visible = true;
                    temp = ID;
                    break;

                case "":
                    {
                        Method = 1;
                        {
                            for (int i = 0; i < DATA.experts.Count; i++)
                                if (DATA.exp[ProblemID].Contains(DATA.experts[ID][i])) break;
                                else DATA.exp[ProblemID].Add(DATA.experts[ID][0]);

                            temp = ID;

                            for (int i = 0; i < DATA.experts.Count; i++)
                            {
                                if (ID == temp)
                                    for (int j = 0; j < DATA.exp.Count; j++)
                                    {
                                        if (DATA.exp[ProblemID][j] == DATA.experts[ID][i])
                                        {
                                            ID = j;
                                            break;
                                        }
                                    }
                                else
                                {
                                    break;
                                }

                            }

                            Meth[0] = true;
                            labelmeth.Visible = true;
                            labelmeth.Text = tempp + 1.ToString();

                            //ID = DATA.exp[ProblemID].Count - 1;
                            WhatToDoLabel.Text = "Заполните поля значений для каждой альтернативы числом от 0 до 1, сумма всех значений должна составлять единицу";
                            dataGridView.Columns.Add("Номер", "№");
                            dataGridView.Columns.Add("Альтернативы", "Альтернативы");
                            dataGridView.Columns.Add("Значение", "Значение");
                            dataGridView.Columns[0].Width = 40;
                            dataGridView.Columns[1].Width = 957;
                            dataGridView.Columns[2].Width = 66;
                            dataGridView.Columns[0].ReadOnly = true;
                            dataGridView.Columns[1].ReadOnly = true;

                            if (DATA.Research[ProblemID][Method].Count == ID)
                            {
                                DATA.Research[ProblemID][Method].Add(new List<string>());
                                for (int i = 0; i < DATA.solutions[ProblemID].Count; i++)
                                    DATA.Research[ProblemID][Method][DATA.Research[ProblemID][Method].Count - 1].Add("0");
                            }

                            for (int i = 0; i < DATA.solutions[ProblemID].Count; i++)
                            {
                                dataGridView.Rows.Add();
                                dataGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
                                dataGridView.Rows[i].Cells[1].Value = DATA.solutions[ProblemID][i];
                                if (DATA.Research[ProblemID][Method][0][i] != "0")
                                    dataGridView.Rows[i].Cells[2].Value = DATA.Research[ProblemID][Method][ID][i];
                            }

                        }

                        dataGridView.Visible = true;
                        break;
                    }
            }

            textBoxFirst.Text = DATA.solutions[ProblemID][Zx];
            textBoxSecond.Text = DATA.solutions[ProblemID][Zy];
            ProblemFormulation.Text = DATA.Formulations[ProblemID];
            ListLabel.Text = Page.ToString() + "/" + (((DATA.solutions[ProblemID].Count * DATA.solutions[ProblemID].Count) - DATA.solutions[ProblemID].Count) / 2).ToString();
            EndButton.Enabled = false;
            PreviousButton.Enabled = false;
            PrevButton.Enabled = false;

            if (Zy == DATA.solutions[ProblemID].Count - 1)
            {
                NextButton.Enabled = false;
            }


            if (Method == 0)
            {
                if (DATA.Matrix[ID][ProblemID][0][Zx][Zy] == "0,5")
                {
                    textBoxFirst.BackColor = Color.Aquamarine;
                    textBoxSecond.BackColor = Color.Aquamarine;
                }

                if (DATA.Matrix[ID][ProblemID][0][Zx][Zy] == "1")
                {
                    textBoxFirst.BackColor = Color.Aquamarine;
                    textBoxSecond.BackColor = Color.White;
                }

                if (DATA.Matrix[ID][ProblemID][0][Zx][Zy] == "0")
                {
                    textBoxFirst.BackColor = Color.White;
                    textBoxSecond.BackColor = Color.Aquamarine;
                }




                for (int i = 0; i < DATA.solutions[ProblemID].Count - 1; i++)
                    for (int j = i + 1; j < DATA.solutions[ProblemID].Count; j++)
                    {
                        if (DATA.Matrix[ID][ProblemID][0][i][j] != "")
                        {
                            end++;
                        }
                    }

                if (end == ((DATA.solutions[ProblemID].Count * DATA.solutions[ProblemID].Count) - DATA.solutions[ProblemID].Count) / 2) EndButton.Enabled = true;

            }

            load = false;  
        }

        private void NextButt_Click(object sender, EventArgs e)
        {
            if (Method == 4)
            {
                PrevButton.Enabled = true;

                textBoxFirst.BackColor = Color.White;
                textBoxSecond.BackColor = Color.White;
                labelmeth.BackColor = Color.White;

                if (zY == DATA.solutions[ProblemID].Count - 1)
                {
                    zX++;
                    zY = zX + 1;

                    textBoxFirst.Text = DATA.solutions[ProblemID][zX];
                    textBoxSecond.Text = DATA.solutions[ProblemID][zY];

                    if (zX == DATA.solutions[ProblemID].Count - 2)
                    {
                        NextButt.Enabled = false;
                    }

                }
                else
                {
                    zY++;
                    textBoxSecond.Text = DATA.solutions[ProblemID][zY];

                }

                if (DATA.MatrixX[ID][ProblemID][zX][zY] != 0 && DATA.MatrixX[ID][ProblemID][zX][zY] != 1)
                {
                    labelmeth.BackColor = Color.Aquamarine;
                    numericUpDown1.Value = Convert.ToInt32(Convert.ToDouble(DATA.MatrixX[ID][ProblemID][zX][zY]) * DATA.S);
                }

                if (DATA.MatrixX[ID][ProblemID][zX][zY] == 1)
                {
                    textBoxFirst.BackColor = Color.Aquamarine;
                    textBoxSecond.BackColor = Color.White;
                    labelmeth.BackColor = Color.White;
                }

                if (DATA.MatrixX[ID][ProblemID][zX][zY] == 0 && DATA.MatrixX[ID][ProblemID][zY][zX] == 1)
                {
                    textBoxFirst.BackColor = Color.White;
                    textBoxSecond.BackColor = Color.Aquamarine;
                    labelmeth.BackColor = Color.White;
                }

                Page4++;
                ListLabel.Text = Page4.ToString() + "/" + (((DATA.solutions[ProblemID].Count * DATA.solutions[ProblemID].Count) - DATA.solutions[ProblemID].Count) / 2).ToString();
            }
        }

        private void PrevButton_Click(object sender, EventArgs e)
        {
            if (Method == 4)
            {
                textBoxFirst.BackColor = Color.White;
                textBoxSecond.BackColor = Color.White;
                labelmeth.BackColor = Color.White;
                NextButt.Enabled = true;
                BackButton.Visible = true;


                if (zX == DATA.solutions[ProblemID].Count - 2)
                {
                    zX--;
                    NextButt.Enabled = true;

                    textBoxFirst.Text = DATA.solutions[ProblemID][zX];

                }

                else
                {
                    zY--;
                    if (zX == zY)
                    {
                        zX--;
                        zY = DATA.solutions[ProblemID].Count - 1;
                    }

                    textBoxFirst.Text = DATA.solutions[ProblemID][zX];
                    textBoxSecond.Text = DATA.solutions[ProblemID][zY];

                    if (zY == 1)
                    {
                        PrevButton.Enabled = false;
                    }

                }


                if (DATA.MatrixX[ID][ProblemID][zX][zY] != 0 && DATA.MatrixX[ID][ProblemID][zX][zY] != 1)
                {
                    labelmeth.BackColor = Color.Aquamarine;
                    numericUpDown1.Value = Convert.ToInt32(Convert.ToDouble(DATA.MatrixX[ID][ProblemID][zX][zY]) * DATA.S);
                }

                if (DATA.MatrixX[ID][ProblemID][zX][zY] == 1)
                {
                    textBoxFirst.BackColor = Color.Aquamarine;
                    textBoxSecond.BackColor = Color.White;
                    labelmeth.BackColor = Color.White;
                }

                if (DATA.MatrixX[ID][ProblemID][zX][zY] == 0 && DATA.MatrixX[ID][ProblemID][zY][zX] == 1)
                {
                    textBoxFirst.BackColor = Color.White;
                    textBoxSecond.BackColor = Color.Aquamarine;
                    labelmeth.BackColor = Color.White;
                }

                Page4--;
                ListLabel.Text = Page4.ToString() + "/" + (((DATA.solutions[ProblemID].Count * DATA.solutions[ProblemID].Count) - DATA.solutions[ProblemID].Count) / 2).ToString();
            }

        }

        private void setFirst(object sender, EventArgs e)
        {
            if (Method == 0)
            {
                if (textBoxFirst.BackColor == Color.Aquamarine && textBoxSecond.BackColor != Color.Aquamarine)
                {
                    return;
                }
                else
                {

                    if (textBoxSecond.BackColor == Color.Green)
                    {
                        end--;
                    }

                    DATA.Matrix[ID][ProblemID][0][Zx][Zy] = "1";
                    DATA.Matrix[ID][ProblemID][0][Zy][Zx] = "0";

                    textBoxFirst.BackColor = Color.Aquamarine;
                    textBoxSecond.BackColor = Color.White;

                    end++;

                    if (end == ((DATA.solutions[ProblemID].Count * DATA.solutions[ProblemID].Count) - DATA.solutions[ProblemID].Count) / 2) Meth[0] = true;
                }

            }

            if (Method == 4)
            {
                if (textBoxFirst.BackColor == Color.Aquamarine && textBoxSecond.BackColor != Color.Aquamarine)
                {
                    return;
                }
                else
                {

                    if (textBoxSecond.BackColor == Color.Aquamarine || labelmeth.BackColor == Color.Aquamarine)
                    {
                        End--;
                    }

                    DATA.MatrixX[ID][ProblemID][zX][zY] = 1;
                    DATA.MatrixX[ID][ProblemID][zY][zX] = 0;

                    textBoxFirst.BackColor = Color.Aquamarine;
                    textBoxSecond.BackColor = Color.White;

                    End++;

                    if (End == ((DATA.solutions[ProblemID].Count * DATA.solutions[ProblemID].Count) - DATA.solutions[ProblemID].Count) / 2) Meth[4] = true;
                }

                labelmeth.BackColor = Color.White;
            }

            bool rdy = true;

            for (int i = 0; i < Meth.Count; i++)
            {
                if (Meth[i] == false)
                {
                    rdy = false;
                    break;
                }
            }

            if (rdy)
            {
                EndButton.Enabled = true;
            }

            else
            {
                EndButton.Enabled = false;
            }
        }

        private void NextMethod_Click(object sender, EventArgs e)
        {
            load = true;
            PrevMethod.Enabled = true;
            Method++;
            switch (Method)
            {
                case 1:
                    {
                        {


                            LabelBoth.Visible = false;
                            WhatToDoLabel.Text = "Заполните поля значений для каждой альтернативы числом от 0 до 1, сумма всех значений должна составлять единицу";
                            NextButton.Visible = false;
                            SelectPage.Visible = false;
                            label2.Visible = false;
                            ListLabel.Visible = false;
                            PageTextBox.Visible = false;
                            PreviousButton.Visible = false;

                            for (int i = 0; i < DATA.experts.Count; i++)
                                if (DATA.exp[ProblemID].Contains(DATA.experts[ID][i])) break;
                                else DATA.exp[ProblemID].Add(DATA.experts[ID][0]);

                            temp = ID;

                            for (int i = 0; i < DATA.experts.Count; i++)
                            {
                                if (ID == temp)
                                    for (int j = 0; j < DATA.exp.Count; j++)
                                    {
                                        if (DATA.exp[ProblemID][j] == DATA.experts[ID][i])
                                        {
                                            ID = j;
                                            break;
                                        }
                                    }
                                else
                                {
                                    break;
                                }

                            }

                            dataGridView.Rows.Clear();
                            dataGridView.Columns.Clear();
                            labelmeth.Visible = true;
                            labelmeth.Text = tempp + 1.ToString();
                            //ID = DATA.exp[ProblemID].Count - 1;

                            dataGridView.Columns.Add("Номер", "№");
                            dataGridView.Columns.Add("Альтернативы", "Альтернативы");
                            dataGridView.Columns.Add("Значение", "Значение");
                            dataGridView.Columns[0].Width = 40;
                            dataGridView.Columns[1].Width = 957;
                            dataGridView.Columns[2].Width = 66;
                            dataGridView.Columns[0].ReadOnly = true;
                            dataGridView.Columns[1].ReadOnly = true;

                            if (DATA.Research[ProblemID][Method].Count == ID)
                            {
                                DATA.Research[ProblemID][Method].Add(new List<string>());
                                for (int i = 0; i < DATA.solutions[ProblemID].Count; i++)
                                    DATA.Research[ProblemID][Method][DATA.Research[ProblemID][Method].Count - 1].Add("0");
                            }

                            for (int i = 0; i < DATA.solutions[ProblemID].Count; i++)
                            {
                                dataGridView.Rows.Add();
                                dataGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
                                dataGridView.Rows[i].Cells[1].Value = DATA.solutions[ProblemID][i];
                                if (DATA.Research[ProblemID][Method][0][i] != "0")
                                    dataGridView.Rows[i].Cells[2].Value = DATA.Research[ProblemID][Method][ID][i];
                            }

                        }

                        dataGridView.Visible = true;
                        break;

                    }
                case 3:
                    {
                        LabelBoth.Visible = false;
                        NextButton.Visible = false;
                        SelectPage.Visible = false;
                        label2.Visible = false;
                        ListLabel.Visible = false;
                        PageTextBox.Visible = false;
                        PreviousButton.Visible = false;

                        for (int i = 0; i < DATA.experts.Count; i++)
                            if (DATA.exp[ProblemID].Contains(DATA.experts[ID][i])) break;
                            else DATA.exp[ProblemID].Add(DATA.experts[ID][0]);

                        temp = ID;

                        for (int i = 0; i < DATA.experts.Count; i++)
                        {
                            if (ID == temp)
                                for (int j = 0; j < DATA.exp.Count; j++)
                                {
                                    if (DATA.exp[ProblemID][j] == DATA.experts[ID][i])
                                    {
                                        ID = j;
                                        break;
                                    }
                                }
                            else
                            {
                                break;
                            }

                        }

                        dataGridView.Rows.Clear();
                        dataGridView.Columns.Clear();

                        //ID = DATA.exp[ProblemID].Count - 1;
                        WhatToDoLabel.Text = "Заполните поля значений для каждой альтернативы, пользуясь пользуясь 10-бальной шкалой, причем чем выше оценка, тем приоритетней альтернатива";
                        dataGridView.Columns.Add("Номер", "№");
                        dataGridView.Columns.Add("Альтернативы", "Альтернативы");
                        dataGridView.Columns.Add("Значение", "Значение");
                        dataGridView.Columns[0].Width = 40;
                        dataGridView.Columns[1].Width = 957;
                        dataGridView.Columns[2].Width = 66;
                        dataGridView.Columns[0].ReadOnly = true;
                        dataGridView.Columns[1].ReadOnly = true;


                        if (DATA.Research[ProblemID][Method].Count == ID)
                        {
                            DATA.Research[ProblemID][Method].Add(new List<string>());
                            for (int i = 0; i < DATA.solutions[ProblemID].Count; i++)
                                DATA.Research[ProblemID][Method][DATA.Research[ProblemID][Method].Count - 1].Add("0");
                        }

                        for (int i = 0; i < DATA.solutions[ProblemID].Count; i++)
                        {
                            dataGridView.Rows.Add();
                            dataGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
                            dataGridView.Rows[i].Cells[1].Value = DATA.solutions[ProblemID][i];
                            if (DATA.Research[ProblemID][Method][0][i] != "0")
                                dataGridView.Rows[i].Cells[2].Value = DATA.Research[ProblemID][Method][ID][i];
                        }

                        dataGridView.Visible = true;
                        break;
                    }

                case 2:
                    {

                        for (int i = 0; i < DATA.experts.Count; i++)
                            if (DATA.exp[ProblemID].Contains(DATA.experts[ID][i])) break;
                            else DATA.exp[ProblemID].Add(DATA.experts[ID][0]);

                        temp = ID;

                        for (int i = 0; i < DATA.experts.Count; i++)
                        {
                            if (ID == temp)
                                for (int j = 0; j < DATA.exp.Count; j++)
                                {
                                    if (DATA.exp[ProblemID][j] == DATA.experts[ID][i])
                                    {
                                        ID = j;
                                        break;
                                    }
                                }
                            else
                            {
                                break;
                            }

                        }

                        labelmeth.Visible = false;
                        dataGridView.Rows.Clear();
                        dataGridView.Columns.Clear();
                        WhatToDoLabel.Text = "Заполните поля значений для каждой альтернативы, пользуясь числами натуарльного ряда. Наиболее важной альтернативе присваивается значение 1, менее важной - 2 и так далее";
                        //ID = DATA.exp[ProblemID].Count - 1;

                        dataGridView.Columns.Add("Номер", "№");
                        dataGridView.Columns.Add("Альтернативы", "Альтернативы");
                        dataGridView.Columns.Add("Значение", "Значение");
                        dataGridView.Columns[0].Width = 40;
                        dataGridView.Columns[1].Width = 957;
                        dataGridView.Columns[2].Width = 66;
                        dataGridView.Columns[0].ReadOnly = true;
                        dataGridView.Columns[1].ReadOnly = true;


                        if (DATA.Research[ProblemID][Method].Count == ID)
                        {
                            DATA.Research[ProblemID][Method].Add(new List<string>());
                            for (int i = 0; i < DATA.solutions[ProblemID].Count; i++)
                                DATA.Research[ProblemID][Method][DATA.Research[ProblemID][Method].Count - 1].Add("0");
                        }

                        for (int i = 0; i < DATA.solutions[ProblemID].Count; i++)
                        {
                            dataGridView.Rows.Add();
                            dataGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
                            dataGridView.Rows[i].Cells[1].Value = DATA.solutions[ProblemID][i];
                            if (DATA.Research[ProblemID][Method][0][i] != "0")
                                dataGridView.Rows[i].Cells[2].Value = DATA.Research[ProblemID][Method][ID][i];
                        }

                        dataGridView.Visible = true;
                        break;
                    }

                case 4:
                    {
                        NextButt.Visible = true;
                        SelectPage.Visible = true;
                        label2.Visible = true;
                        ListLabel.Visible = true;
                        numericUpDown1.Visible = true;
                        labelmeth.Visible = true;
                        PageTextBox.Visible = true;
                        PrevButton.Visible = true;
                        ListLabel.Text = Page4.ToString() + "/" + (((DATA.solutions[ProblemID].Count * DATA.solutions[ProblemID].Count) - DATA.solutions[ProblemID].Count) / 2).ToString();
                        temp = ID;
                        WhatToDoLabel.Text = "Сравните два варианта решения проблемы. Если вы считаете более приемлимым первый или второй вариант, то кликните по нему левой кнопкой мыши, если вы считаете что первая альтернатива в n случаях из " + DATA.S.ToString() + " лучше второй выберите жто число и кликните левой кнопкой мыши по 'Альтернатива 1 предпочтительней альтернативы 2'.";

                        textBoxFirst.BackColor = Color.White;
                        textBoxSecond.BackColor = Color.White;
                        labelmeth.BackColor = Color.White;



                        textBoxFirst.Text = DATA.solutions[ProblemID][zX];
                        textBoxSecond.Text = DATA.solutions[ProblemID][zY];

                        ID = iD;

                        if (DATA.MatrixX[ID][ProblemID][zX][zY] != 0 && DATA.MatrixX[ID][ProblemID][zX][zY] != 1)
                        {
                            labelmeth.BackColor = Color.Aquamarine;
                            numericUpDown1.Value = Convert.ToInt32(DATA.MatrixX[ID][ProblemID][zX][zY] * DATA.S);
                        }

                        if (DATA.Research[ProblemID][4][zX][zY] == "1")
                        {
                            textBoxFirst.BackColor = Color.Aquamarine;
                            textBoxSecond.BackColor = Color.White;
                            labelmeth.BackColor = Color.White;
                        }

                        if (DATA.MatrixX[ID][ProblemID][zX][zY] == 0 && DATA.MatrixX[ID][ProblemID][zY][zX] == 1)
                        {
                            textBoxFirst.BackColor = Color.White;
                            textBoxSecond.BackColor = Color.Aquamarine;
                            labelmeth.BackColor = Color.White;
                        }

                        numericUpDown1.Maximum = Convert.ToInt32(DATA.S) - 1;
                        numericUpDown1.Minimum = 1;

                        labelmeth.Text = "Альтернатива 1 предпочтительней альтернативы 2 в ";

                        dataGridView.Visible = false;


                        break;
                    }
            }

            if (Method == 4)
            {
                NextMethod.Enabled = false;
            }

            load = false;
        }

        private void PrevMethod_Click(object sender, EventArgs e)
        {
            load = true;
            NextMethod.Enabled = true;
            Method--;
            switch (Method)
            {
                case 0:

                    dataGridView.Visible = false;
                    LabelBoth.Visible = true;
                    WhatToDoLabel.Text = "Сравните два варианта решения проблемы. Если вы считаете более приемлимым первый или второй вариант, то кликните по нему левой кнопкой мыши, если оба варианта равнозначны, то кликните по 'Варианты равнознычны'.";
                    NextButton.Visible = true;
                    SelectPage.Visible = true;
                    label2.Visible = true;
                    ListLabel.Visible = true;
                    PageTextBox.Visible = true;
                    PreviousButton.Visible = true;
                    labelmeth.Visible = false;
                    ListLabel.Text = Page.ToString() + "/" + (((DATA.solutions[ProblemID].Count * DATA.solutions[ProblemID].Count) - DATA.solutions[ProblemID].Count) / 2).ToString();
                    temp = ID;


                    textBoxFirst.Text = DATA.solutions[ProblemID][Zx];
                    textBoxSecond.Text = DATA.solutions[ProblemID][Zy];

                    textBoxFirst.BackColor = Color.White;
                    textBoxSecond.BackColor = Color.White;

                    if (DATA.Matrix[ID][ProblemID][0][Zx][Zy] == "0,5")
                    {
                        textBoxFirst.BackColor = Color.Aquamarine;
                        textBoxSecond.BackColor = Color.Aquamarine;
                    }

                    if (DATA.Matrix[ID][ProblemID][0][Zx][Zy] == "1")
                    {
                        textBoxFirst.BackColor = Color.Aquamarine;
                        textBoxSecond.BackColor = Color.White;
                    }

                    if (DATA.Matrix[ID][ProblemID][0][Zx][Zy] == "0")
                    {
                        textBoxFirst.BackColor = Color.White;
                        textBoxSecond.BackColor = Color.Aquamarine;
                    }

                    break;

                case 1:
                    {
                        {

                            LabelBoth.Visible = false;
                            NextButton.Visible = false;
                            SelectPage.Visible = false;
                            label2.Visible = false;
                            ListLabel.Visible = false;
                            PageTextBox.Visible = false;
                            PreviousButton.Visible = false;
                            WhatToDoLabel.Text = "Заполните поля значений для каждой альтернативы числом от 0 до 1, сумма всех значений должна составлять единицу";

                            for (int i = 0; i < DATA.experts.Count; i++)
                                if (DATA.exp[ProblemID].Contains(DATA.experts[ID][i])) break;
                                else DATA.exp[ProblemID].Add(DATA.experts[ID][0]);

                            temp = ID;

                            for (int i = 0; i < DATA.experts.Count; i++)
                            {
                                if (ID == temp)
                                    for (int j = 0; j < DATA.exp.Count; j++)
                                    {
                                        if (DATA.exp[ProblemID][j] == DATA.experts[ID][i])
                                        {
                                            ID = j;
                                            break;
                                        }
                                    }
                                else
                                {
                                    break;
                                }

                            }

                            dataGridView.Rows.Clear();
                            dataGridView.Columns.Clear();
                            labelmeth.Visible = true;
                            labelmeth.Text = tempp + 1.ToString();
                            //ID = DATA.exp[ProblemID].Count - 1;

                            dataGridView.Columns.Add("Номер", "№");
                            dataGridView.Columns.Add("Альтернативы", "Альтернативы");
                            dataGridView.Columns.Add("Значение", "Значение");
                            dataGridView.Columns[0].Width = 40;
                            dataGridView.Columns[1].Width = 957;
                            dataGridView.Columns[2].Width = 66;
                            dataGridView.Columns[0].ReadOnly = true;
                            dataGridView.Columns[1].ReadOnly = true;

                            if (DATA.Research[ProblemID][Method].Count == ID)
                            {
                                DATA.Research[ProblemID][Method].Add(new List<string>());
                                for (int i = 0; i < DATA.solutions[ProblemID].Count; i++)
                                    DATA.Research[ProblemID][Method][DATA.Research[ProblemID][Method].Count - 1].Add("0");
                            }

                            for (int i = 0; i < DATA.solutions[ProblemID].Count; i++)
                            {
                                dataGridView.Rows.Add();
                                dataGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
                                dataGridView.Rows[i].Cells[1].Value = DATA.solutions[ProblemID][i];
                                if (DATA.Research[ProblemID][Method][0][i] != "0")
                                    dataGridView.Rows[i].Cells[2].Value = DATA.Research[ProblemID][Method][ID][i];
                            }

                        }

                        dataGridView.Visible = true;
                        break;
                    }

                case 3:
                    {

                        LabelBoth.Visible = false;
                        NextButton.Visible = false;
                        SelectPage.Visible = false;
                        label2.Visible = false;
                        ListLabel.Visible = false;
                        PageTextBox.Visible = false;
                        PreviousButton.Visible = false;
                        NextButt.Visible = false;
                        PrevButton.Visible = false;

                        numericUpDown1.Visible = false;
                        labelmeth.Visible = false;

                        for (int i = 0; i < DATA.experts.Count; i++)
                            if (DATA.exp[ProblemID].Contains(DATA.experts[ID][i])) break;
                            else DATA.exp[ProblemID].Add(DATA.experts[ID][0]);

                        temp = ID;

                        for (int i = 0; i < DATA.experts.Count; i++)
                        {
                            if (ID == temp)
                                for (int j = 0; j < DATA.exp.Count; j++)
                                {
                                    if (DATA.exp[ProblemID][j] == DATA.experts[ID][i])
                                    {
                                        ID = j;
                                        break;
                                    }
                                }
                            else
                            {
                                break;
                            }

                        }

                        dataGridView.Rows.Clear();
                        dataGridView.Columns.Clear();

                        //ID = DATA.exp[ProblemID].Count - 1;
                        WhatToDoLabel.Text = "Заполните поля значений для каждой альтернативы, пользуясь пользуясь 10-бальной шкалой, причем чем выше оценка, тем приоритетней альтернатива";
                        dataGridView.Columns.Add("Номер", "№");
                        dataGridView.Columns.Add("Альтернативы", "Альтернативы");
                        dataGridView.Columns.Add("Значение", "Значение");
                        dataGridView.Columns[0].Width = 40;
                        dataGridView.Columns[1].Width = 957;
                        dataGridView.Columns[2].Width = 66;
                        dataGridView.Columns[0].ReadOnly = true;
                        dataGridView.Columns[1].ReadOnly = true;


                        if (DATA.Research[ProblemID][Method].Count == ID)
                        {
                            DATA.Research[ProblemID][Method].Add(new List<string>());
                            for (int i = 0; i < DATA.solutions[ProblemID].Count; i++)
                                DATA.Research[ProblemID][Method][DATA.Research[ProblemID][Method].Count - 1].Add("0");
                        }

                        for (int i = 0; i < DATA.solutions[ProblemID].Count; i++)
                        {
                            dataGridView.Rows.Add();
                            dataGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
                            dataGridView.Rows[i].Cells[1].Value = DATA.solutions[ProblemID][i];
                            if (DATA.Research[ProblemID][Method][0][i] != "0")
                                dataGridView.Rows[i].Cells[2].Value = DATA.Research[ProblemID][Method][ID][i];
                        }

                        dataGridView.Visible = true;
                        break;
                    }

                case 2:
                    {
                        for (int i = 0; i < DATA.experts.Count; i++)
                            if (DATA.exp[ProblemID].Contains(DATA.experts[ID][i])) break;
                            else DATA.exp[ProblemID].Add(DATA.experts[ID][0]);

                        temp = ID;

                        for (int i = 0; i < DATA.experts.Count; i++)
                        {
                            if (ID == temp)
                                for (int j = 0; j < DATA.exp.Count; j++)
                                {
                                    if (DATA.exp[ProblemID][j] == DATA.experts[ID][i])
                                    {
                                        ID = j;
                                        break;
                                    }
                                }
                            else
                            {
                                break;
                            }

                        }
                        WhatToDoLabel.Text = "Заполните поля значений для каждой альтернативы, пользуясь числами натуарльного ряда. Наиболее важной альтернативе присваивается значение 1, менее важной - 2 и так далее";
                        labelmeth.Visible = false;
                        dataGridView.Rows.Clear();
                        dataGridView.Columns.Clear();

                        //ID = DATA.exp[ProblemID].Count - 1;

                        dataGridView.Columns.Add("Номер", "№");
                        dataGridView.Columns.Add("Альтернативы", "Альтернативы");
                        dataGridView.Columns.Add("Значение", "Значение");
                        dataGridView.Columns[0].Width = 40;
                        dataGridView.Columns[1].Width = 957;
                        dataGridView.Columns[2].Width = 66;
                        dataGridView.Columns[0].ReadOnly = true;
                        dataGridView.Columns[1].ReadOnly = true;


                        if (DATA.Research[ProblemID][Method].Count == ID)
                        {
                            DATA.Research[ProblemID][Method].Add(new List<string>());
                            for (int i = 0; i < DATA.solutions[ProblemID].Count; i++)
                                DATA.Research[ProblemID][Method][DATA.Research[ProblemID][Method].Count - 1].Add("0");
                        }

                        for (int i = 0; i < DATA.solutions[ProblemID].Count; i++)
                        {
                            dataGridView.Rows.Add();
                            dataGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
                            dataGridView.Rows[i].Cells[1].Value = DATA.solutions[ProblemID][i];
                            if (DATA.Research[ProblemID][Method][0][i] != "0")
                                dataGridView.Rows[i].Cells[2].Value = DATA.Research[ProblemID][Method][ID][i];
                        }

                        dataGridView.Visible = true;
                        break;
                    }
            }

            if (Method == 1 && DATA.experts[ID][6] != "Метод парных сравнений")
            {
                PrevMethod.Enabled = false;
                load = false;
                return;
            }

            if (Method == 0)
            {
                PrevMethod.Enabled = false;
                load = false;
                return;
            }
        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите закончить оценку? Внесение изменений после завершения будет невозможным", "Подтверждение действия", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                temp = iD;
                for (int i = 0; i < DATA.Problems.Count; i++)
                {
                    if (DATA.experts[temp][4].Contains(DATA.Problems[i][0]))
                    {
                        DATA.ready[temp][ProblemID] = true;
                        var substr = DATA.Problems[i][0];
                        DATA.experts[temp][4] = DATA.experts[temp][4].Replace(substr, "");
                        break;
                    }
                }


                switch (DATA.experts[temp][6])
                {
                    case "Метод парных сравнений":
                        for (int j = 0; j < DATA.Matrix[ID][ProblemID][0].Count; j++)
                            for (int k = 0; k < DATA.Matrix[ID][ProblemID][0].Count; k++)
                            {
                                if (k == j)
                                    continue;
                                DATA.Research[ProblemID][0][j][k] = (Convert.ToDouble(DATA.Research[ProblemID][0][j][k]) + Convert.ToDouble(DATA.Matrix[ID][ProblemID][0][j][k])).ToString();
                            }
                        break;  
                }

                for (int i = 0; i < DATA.Problems.Count; i++)
                {
                    if (DATA.experts[temp][4].Contains(DATA.Problems[i][0]))
                    {
                        MessageBox.Show("У вас есть доступные проблемы для оценки, вы можете зайти под своим логином и продолжить оценивание.");
                        break;
                    }
                }

                this.Close();
                back.Show();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void SelectPage_Click(object sender, EventArgs e)
        {
            foreach (char c in PageTextBox.Text)
            {
                if (char.IsDigit(c))
                {
                    continue;
                }
                else
                {
                    return;
                }
            }

            if (Convert.ToInt32(PageTextBox.Text) > ((DATA.solutions[ProblemID].Count * DATA.solutions[ProblemID].Count) - DATA.solutions[ProblemID].Count) / 2)
            {
                return;
            }

            if (Convert.ToInt32(PageTextBox.Text) < 1)
            {
                return;
            }

            int a = Convert.ToInt32(PageTextBox.Text);

            Page = 1; Zx = 0; Zy = 1;

            textBoxFirst.Text = DATA.solutions[ProblemID][Zx];
            textBoxSecond.Text = DATA.solutions[ProblemID][Zy];
            ListLabel.Text = Page.ToString() + "/" + (((DATA.solutions[ProblemID].Count * DATA.solutions[ProblemID].Count) - DATA.solutions[ProblemID].Count) / 2).ToString();
            PreviousButton.Enabled = false;
            NextButton.Enabled = true;


            while (Page != a)
            {

                PreviousButton.Enabled = true;

                textBoxFirst.BackColor = Color.White;
                textBoxSecond.BackColor = Color.White;

                if (Zy == DATA.solutions[ProblemID].Count - 1)
                {
                    Zx++;
                    Zy = Zx + 1;

                    textBoxFirst.Text = DATA.solutions[ProblemID][Zx];
                    textBoxSecond.Text = DATA.solutions[ProblemID][Zy];

                    if (Zx == DATA.solutions[ProblemID].Count - 2)
                    {
                        NextButton.Enabled = false;
                    }

                }
                else
                {
                    Zy++;
                    textBoxSecond.Text = DATA.solutions[ProblemID][Zy];

                }

                if (DATA.Matrix[ID][ProblemID][0][Zx][Zy] == "0,5")
                {
                    textBoxFirst.BackColor = Color.Aquamarine;
                    textBoxSecond.BackColor = Color.Aquamarine;
                }

                if (DATA.Matrix[ID][ProblemID][0][Zx][Zy] == "1")
                {
                    textBoxFirst.BackColor = Color.Aquamarine;
                    textBoxSecond.BackColor = Color.White;
                }

                if (DATA.Matrix[ID][ProblemID][0][Zx][Zy] == "0")
                {
                    textBoxFirst.BackColor = Color.White;
                    textBoxSecond.BackColor = Color.Aquamarine;
                }

                Page++;
                ListLabel.Text = Page.ToString() + "/" + (((DATA.solutions[ProblemID].Count * DATA.solutions[ProblemID].Count) - DATA.solutions[ProblemID].Count) / 2).ToString();
            }

            if (DATA.Matrix[ID][ProblemID][0][Zx][Zy] == "0,5")
            {
                textBoxFirst.BackColor = Color.Aquamarine;
                textBoxSecond.BackColor = Color.Aquamarine;
            }

            if (DATA.Matrix[ID][ProblemID][0][Zx][Zy] == "1")
            {
                textBoxFirst.BackColor = Color.Aquamarine;
                textBoxSecond.BackColor = Color.White;
            }

            if (DATA.Matrix[ID][ProblemID][0][Zx][Zy] == "0")
            {
                textBoxFirst.BackColor = Color.White;
                textBoxSecond.BackColor = Color.Aquamarine;
            }

        }

        private void setSecond(object sender, EventArgs e)
        {
            if (Method == 0)
            {
                if (textBoxFirst.BackColor != Color.Aquamarine && textBoxSecond.BackColor == Color.Aquamarine)
                {
                    return;
                }
                else
                {
                    if (textBoxSecond.BackColor == Color.Aquamarine || labelmeth.BackColor == Color.Aquamarine)
                    {
                        end--;
                    }
                    DATA.Matrix[ID][ProblemID][0][Zx][Zy] = "0";
                    DATA.Matrix[ID][ProblemID][0][Zy][Zx] = "1";

                    textBoxFirst.BackColor = Color.White;
                    textBoxSecond.BackColor = Color.Aquamarine;

                    end++;

                    if (end == ((DATA.solutions[ProblemID].Count * DATA.solutions[ProblemID].Count) - DATA.solutions[ProblemID].Count) / 2) Meth[0] = true;
                }
            }

            if (Method == 4)
            {
                if (textBoxFirst.BackColor != Color.Aquamarine && textBoxSecond.BackColor == Color.Aquamarine)
                {
                    return;
                }
                else
                {
                    if (textBoxFirst.BackColor == Color.Aquamarine)
                    {
                        End--;
                    }
                    DATA.MatrixX[ID][ProblemID][zX][zY] = 0;
                    DATA.MatrixX[ID][ProblemID][zY][zX] = 1;

                    textBoxFirst.BackColor = Color.White;
                    textBoxSecond.BackColor = Color.Aquamarine;

                    End++;

                    if (End == ((DATA.solutions[ProblemID].Count * DATA.solutions[ProblemID].Count) - DATA.solutions[ProblemID].Count) / 2) Meth[4] = true;
                }

                labelmeth.BackColor = Color.White;
            }

            bool rdy = true;

            for (int i = 0; i < Meth.Count; i++)
            {
                if (Meth[i] == false)
                {
                    rdy = false;
                    break;
                }
            }

            if (rdy)
            {
                EndButton.Enabled = true;
            }

            else
            {
                EndButton.Enabled = false;
            }
        }

        private void setBoth(object sender, EventArgs e)
        {
            if (textBoxFirst.BackColor == Color.Aquamarine && textBoxSecond.BackColor == Color.Aquamarine)
            {
                return;
            }
            else
            {
                if (textBoxFirst.BackColor == Color.Aquamarine || textBoxSecond.BackColor == Color.Aquamarine)
                {
                    end--;
                }
                DATA.Matrix[ID][ProblemID][0][Zx][Zy] = "0,5";
                DATA.Matrix[ID][ProblemID][0][Zy][Zx] = "0,5";

                textBoxFirst.BackColor = Color.Aquamarine;
                textBoxSecond.BackColor = Color.Aquamarine;

                end++;

                if (end == ((DATA.solutions[ProblemID].Count * DATA.solutions[ProblemID].Count) - DATA.solutions[ProblemID].Count) / 2) Meth[0] = true;
            }

            bool rdy = true;

            for (int i = 0; i < Meth.Count; i++)
            {
                if (Meth[i] == false)
                {
                    rdy = false;
                    break;
                }
            }

            if (rdy)
            {
                EndButton.Enabled = true;
            }

            else
            {
                EndButton.Enabled = false;
            }
        }

        private void setS(object sender, EventArgs e)
        {
            if (Method == 4)
            {
                if (textBoxFirst.BackColor == Color.Aquamarine || textBoxSecond.BackColor == Color.Aquamarine)
                {
                    End--;
                }

                DATA.MatrixX[ID][ProblemID][zX][zY] = Convert.ToDouble(numericUpDown1.Value) / DATA.S;
                DATA.MatrixX[ID][ProblemID][zY][zX] = (DATA.S - Convert.ToDouble(numericUpDown1.Value)) / DATA.S;

                labelmeth.BackColor = Color.Aquamarine;

                textBoxFirst.BackColor = Color.White;
                textBoxSecond.BackColor = Color.White;

                End++;

                if (End == ((DATA.solutions[ProblemID].Count * DATA.solutions[ProblemID].Count) - DATA.solutions[ProblemID].Count) / 2) Meth[4] = true;

                bool rdy = true;

                for (int i = 0; i < Meth.Count; i++)
                {
                    if (Meth[i] == false)
                    {
                        rdy = false;
                        break;
                    }
                }

                if (rdy)
                {
                    EndButton.Enabled = true;
                }

                else
                {
                    EndButton.Enabled = false;
                }
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (Method == 0)
            {
                PreviousButton.Enabled = true;

                textBoxFirst.BackColor = Color.White;
                textBoxSecond.BackColor = Color.White;

                if (Zy == DATA.solutions[ProblemID].Count - 1)
                {
                    Zx++;
                    Zy = Zx + 1;

                    textBoxFirst.Text = DATA.solutions[ProblemID][Zx];
                    textBoxSecond.Text = DATA.solutions[ProblemID][Zy];

                    if (Zx == DATA.solutions[ProblemID].Count - 2)
                    {
                        NextButton.Enabled = false;
                    }

                }
                else
                {
                    Zy++;
                    textBoxSecond.Text = DATA.solutions[ProblemID][Zy];

                }


                if (DATA.Matrix[ID][ProblemID][0][Zx][Zy] == "0,5")
                {
                    textBoxFirst.BackColor = Color.Aquamarine;
                    textBoxSecond.BackColor = Color.Aquamarine;
                }

                if (DATA.Matrix[ID][ProblemID][0][Zx][Zy] == "1")
                {
                    textBoxFirst.BackColor = Color.Aquamarine;
                    textBoxSecond.BackColor = Color.White;
                }

                if (DATA.Matrix[ID][ProblemID][0][Zx][Zy] == "0")
                {
                    textBoxFirst.BackColor = Color.White;
                    textBoxSecond.BackColor = Color.Aquamarine;
                }

                Page++;
                ListLabel.Text = Page.ToString() + "/" + (((DATA.solutions[ProblemID].Count * DATA.solutions[ProblemID].Count) - DATA.solutions[ProblemID].Count) / 2).ToString();
            }
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {

            if (Method == 0)
            {
                textBoxFirst.BackColor = Color.White;
                textBoxSecond.BackColor = Color.White;
                NextButton.Enabled = true;
                BackButton.Visible = true;


                if (Zx == DATA.solutions[ProblemID].Count - 2)
                {
                    Zx--;
                    NextButton.Enabled = true;

                    textBoxFirst.Text = DATA.solutions[ProblemID][Zx];

                }

                else
                {
                    Zy--;
                    if (Zx == Zy)
                    {
                        Zx--;
                        Zy = DATA.solutions[ProblemID].Count - 1;
                    }

                    textBoxFirst.Text = DATA.solutions[ProblemID][Zx];
                    textBoxSecond.Text = DATA.solutions[ProblemID][Zy];

                    if (Zy == 1)
                    {
                        PreviousButton.Enabled = false;
                    }

                }

                if (DATA.Matrix[ID][ProblemID][0][Zx][Zy] == "0,5")
                {
                    textBoxFirst.BackColor = Color.Aquamarine;
                    textBoxSecond.BackColor = Color.Aquamarine;
                }

                if (DATA.Matrix[ID][ProblemID][0][Zx][Zy] == "1")
                {
                    textBoxFirst.BackColor = Color.Aquamarine;
                    textBoxSecond.BackColor = Color.White;
                }

                if (DATA.Matrix[ID][ProblemID][0][Zx][Zy] == "0")
                {
                    textBoxFirst.BackColor = Color.White;
                    textBoxSecond.BackColor = Color.Aquamarine;
                }

                Page--;
                ListLabel.Text = Page.ToString() + "/" + (((DATA.solutions[ProblemID].Count * DATA.solutions[ProblemID].Count) - DATA.solutions[ProblemID].Count) / 2).ToString();
            }

        }
    }
}
