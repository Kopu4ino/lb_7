using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lb_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(textBox1.Text); ;
                int m = Convert.ToInt32(textBox2.Text);

                if (n < 0 || m < 0)
                    MessageBox.Show("Не корректные данные");
                else
                {

                    dataGridView1.RowCount = n;
                    dataGridView1.ColumnCount = m;

                    Random rand = new Random();

                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            dataGridView1[j, i].Value = (rand.Next(40) - 20).ToString();
                        }
                    }
                }
            }
            catch (OverflowException)
            {
                MessageBox.Show("Слишком большое число");

            }
            catch (Exception)
            {

                MessageBox.Show("Не корректные данные");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != dataGridView1.ColumnCount)
            {
                MessageBox.Show("Используйте квадратную матрицу");
            }
            else if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Создайте массив");
            }
            else
            {
                int n = dataGridView1.RowCount, m = dataGridView1.ColumnCount;

                int[,] Temp = new int[dataGridView1.RowCount, dataGridView1.ColumnCount];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Temp[i, j] = Convert.ToInt32(dataGridView1[j, i].Value);
                    }
                }

                //Сортировка 

                int temp1 = 0, temp2 = 0;

                for (int k = 1; k < n; k++)
                {
                    for (int j = 0; j < n - 1; j++)
                    {

                        for (int i = 0; i < n; i++)
                        {
                            if (Temp[i, j] > 0)
                            {
                                temp1++;
                            }
                            if (Temp[i, j + 1] > 0)
                            {
                                temp2++;
                            }
                        }
                        if (temp1 > temp2)
                        {
                            for (int i = 0; i < n; i++)
                            {
                                (Temp[i, j], Temp[i, j + 1]) = (Temp[i, j + 1], Temp[i, j]);
                            }
                        }
                        temp1 = 0;
                        temp2 = 0;
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        dataGridView1[j, i].Value = Temp[i, j].ToString();
                    }
                }
            }

            
        }
    }
}
