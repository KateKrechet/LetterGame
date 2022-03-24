using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LetterGame
{
    public partial class Form1 : Form
    {
        Random random;
        string s = "йцукенгшщзхъфывапролджэячсмитьбю";
        string engl = "qwertyuiopasdfghjklzxcvbnm";
        int seconds = 0;
        int score = 0;//при правильном нажатии на кнопку увеличивается счет
        public Form1()
        {
            InitializeComponent();
            random = new Random();
        }

        private void timer1_Tick(object sender, EventArgs e)//каждые 500 мс выводить букву русского алфавита
        {
            //таймер повторяет какое-то действие, деленное на промежуток времени
            //char s = (char)random.Next(128, 160);//русские символы;через кодировку не получилось
            if (checkBox1.Checked ==true && checkBox2.Checked == false)
                listBox1.Items.Add(s[random.Next(s.Length)]);//выводим в ListBox
            else
            {
                if (checkBox2.Checked ==true && checkBox1.Checked == false)
                    listBox1.Items.Add(engl[random.Next(engl.Length)]);
            }
            seconds += 1;
            label1.Text = "Время: " + (seconds / 2).ToString();//делим на 2, потому что таймер срабатывает каждые 500 мс(каждые полсекунды)
            if (listBox1.Items.Count >= 50)
                GameOver();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;//запуск таймера
            textBox1.Focus();//убирает уже введенные буквы
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
        void GameOver()
        {

            timer1.Enabled = false;
            MessageBox.Show("Игра закончена\nВаш счет равен" + score.ToString());
            score = 0;
            seconds = 0;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (timer1.Enabled = true && textBox1.Text.Length > 0)
            {
                if (textBox1.Text == listBox1.Items[0].ToString())
                {
                    score++;
                    listBox1.Items.RemoveAt(0);
                    label2.Text = "Счет: " + score.ToString();
                }
                else
                {
                    GameOver();
                }
                textBox1.Text = "";
            }
        }
    }
}
