using EquationSolver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _9_day
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Series series = new Series();
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label4.Visible = false;
                textBox3.Visible = false;
                label5.Text = "ax+b=0";
                label5.Visible = true;
            }
            else
            {
                label4.Visible = true;
                textBox3.Visible = true;
                label5.Text = "ax^2+bx+c=0";
                label5.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a, b, c;
            if (double.TryParse(textBox1.Text, out a) && double.TryParse(textBox2.Text, out b))
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    // Линейное уравнение
                    Linear linearEquation = new Linear(a, b);
                    series.AddSolution(linearEquation);
                    MessageBox.Show("Linear equation has already been added");
                    listBox1.Items.Add(linearEquation.PrintRoots());
                    listBox1.Items.Add(linearEquation.CalculateRoots());
                }
                else
                {
                    // Проверяем, введено ли значение для c
                    if (double.TryParse(textBox3.Text, out c))
                    {
                        // Квадратное уравнение
                        Square squareEquation = new Square(a, b, c);
                        series.AddSolution(squareEquation);
                        MessageBox.Show("Square equation has already been added");
                        listBox1.Items.Add(squareEquation.PrintRoots());
                        listBox1.Items.Add(squareEquation.CalculateRoots());
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid value for c.");
                    }
                    // Отображение уравнений в ListBox
                    
                }
            }
            else
            {
                MessageBox.Show("Please enter valid values for a and b.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                series.SaveToFile(saveFileDialog.FileName);
                MessageBox.Show("Equations saved to file.");
            }
        }
    }
}
