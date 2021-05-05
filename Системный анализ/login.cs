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
    public partial class login : Form
    {
        private data DATA = new data();
        private Menu back;


        public login(Menu back, ref data DATA)
        {
            this.back = back;
            this.DATA = DATA;
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            bool isAuth = false;
            bool AnyTasks = false;
            int ID = -1;
            int ProblemID = -1;

            if (LoginTextBox.Text == "")
            {
                MessageBox.Show("Введит ваше имя");
                return;
            }

            for (int i = 0; i < DATA.experts.Count; i++)
            {
                if (DATA.experts[i][0] == LoginTextBox.Text)
                {
                    isAuth = true;
                    ID = i;
                    break;
                }
            }

            if (!isAuth)
            {
                MessageBox.Show("Вас нет в базе экспертов");
                return;
            }


            for (int i = 0; i < DATA.Problems.Count; i++)
            {
                if (DATA.experts[ID][4].Contains(DATA.Problems[i][0]) && DATA.Problems[i][1] == "Отправлено на оценку")
                {
                    AnyTasks = true;
                    ProblemID = i;
                    break;
                }
            }

            if (!AnyTasks)
            {
                MessageBox.Show("Нет проблем готовых к решению, попробуйте позже");
                return;
            }


            if (AnyTasks && isAuth)
            {
                Form ExpertInterface = new ExpertInterface(back, this, ProblemID, ID, ref DATA);
                ExpertInterface.Show();
                this.Hide();
                back.Hide();

            }

        }
    }
}
