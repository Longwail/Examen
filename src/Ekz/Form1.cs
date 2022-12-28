using System;
using System.Windows.Forms;

namespace Ekz
{
    public partial class Form1 : Form
    {
        bool flag = false;
        bool select;
        double x, y;
        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void f1()
        {
            if (Double.TryParse(textBox1.Text, out x) && Double.TryParse(textBox2.Text, out y))
            {
                if (x<Math.PI && ((y<Math.Sin(x) && Math.Sin(x)< 0.5)||((y<0.5 && y>0)&&Math.Sin(x)>0.5)))
                {
                    MessageBox.Show("Находится внутри функций");
                    toolStripStatusLabel1.Text = "Находится внутри функций";
                }
                else if (y == 0.5 || x == .0)
                {
                    MessageBox.Show("Находится на границе");
                    toolStripStatusLabel1.Text = "Находится на границе";
                }
                else
                {
                    MessageBox.Show("Находится вне функций");
                    toolStripStatusLabel1.Text = "Находится вне функций";
                }
            }
            else
            {
                MessageBox.Show("Точки должны определяться вещественным числом");
            }
        }
        void f2()
        {
            if (Double.TryParse(textBox1.Text, out x) && Double.TryParse(textBox2.Text, out y))
            {
                if (x > 0 && y > 0 && y< -1*x+6 && y> -2*x+4)
                {
                    MessageBox.Show("Находится внутри функций");
                    toolStripStatusLabel1.Text = "Находится внутри функций";
                }
                else if (y + x == 6 || (x>=2 && x<=6) && (y == 0) || (y >= 4 && y <= 6))
                {
                    MessageBox.Show("Находится на границе");
                    toolStripStatusLabel1.Text = "Находится на границе";
                }
                else
                {
                    MessageBox.Show("Находится вне функций");
                    toolStripStatusLabel1.Text = "Находится вне функций";
                }
            }
            else
            {
                MessageBox.Show("Точки должны определяться вещественным числом");
            }
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.AllowWebBrowserDrop = false;
            openFileDialog1.Filter = "TextFiles(*.html)|*.html|AllFiles(*.*)|*.*";
            openFileDialog1.ShowDialog();
            if(!flag)
            {
                this.Height += 100;
                flag = true;                
            }
            string[] repSplit = openFileDialog1.FileName.Split('\\');
            string curFile = repSplit[repSplit.Length - 1];
            if (curFile == "1.html")
            {
                webBrowser1.Navigate(openFileDialog1.FileName);
                select = true;
            }
            else if (curFile == "2.html")
            {
                webBrowser1.Navigate(openFileDialog1.FileName);
                select = false;
            }
            else
            {
                MessageBox.Show($"Нет решения для {curFile}. Попробуйте выбрать файлы 1.html и 2.html");
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программу разработал:\nСтудент группы ПКсп-120\nПахоменко Владислав Васильевич");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (select)
            {
                f1();
            }
            else
            {
                f2();
            }
        }
    }
}