using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool TrueFalse { get; set; }
        private double Result { get; set; }
        private double Resultcopy { get; set; }
        private double X { get; set; }
        private string Symbol { get; set; }
        int count_command, count_add, count_negative,count_multi,count_divide,count_minus=0;
        

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (TrueFalse)
            {
                lbl_result.Text = null;
            }
            if(sender is Button btn)
            {
                if (lbl_result.Text == "0") lbl_result.Text = btn.Text;
                else lbl_result.Text += btn.Text;
            }
            if (TrueFalse) X =Convert.ToDouble(lbl_result.Text);
            TrueFalse = false;
            
        }

        private void btn_comma_Click(object sender, EventArgs e)
        {
            if (count_command == 0)
            {
              lbl_result.Text += ".";
              ++count_command;
            }
        }

        private void btn_removeall_Click(object sender, EventArgs e)
        {
            lbl_result.Text = null;
            count_command = 0;
            count_negative = 0;
        }

        private void btn_deleteone_Click(object sender, EventArgs e)
        {
            lbl_result.Text= lbl_result.Text.Remove(lbl_result.Text.Length-1, 1);

            if (lbl_result.Text[lbl_result.Text.Length - 1] == '.')
            {
                lbl_result.Text = lbl_result.Text.Remove(lbl_result.Text.Length - 1, 1);
                count_command = 0;
            }
            if (lbl_result.Text[lbl_result.Text.Length - 1] == '-')
            {
                lbl_result.Text = lbl_result.Text.Remove(lbl_result.Text.Length - 1, 1);
                count_negative = 0;
            }
        }

        private void btn_negative_Click(object sender, EventArgs e)
        {
            if (count_negative == 0)
            {
              lbl_result.Text = lbl_result.Text.Insert(0, "-");
              ++count_negative;
            }
            else if (count_negative == 1)
            {
                lbl_result.Text = lbl_result.Text.Remove(0, 1);
                count_negative = 0;
            }
        }

        private void btn_divide_Click(object sender, EventArgs e)
        {
            Resultcopy = Convert.ToDouble(lbl_result.Text);
            Symbol = "/";
            TrueFalse = true;
            count_command = 0;
            count_negative = 0;
            count_divide = 0;
        }

        private void btn_multi_Click(object sender, EventArgs e)
        {
            Resultcopy = Convert.ToDouble(lbl_result.Text);
            Symbol = "x";
            TrueFalse = true;
            count_command = 0;
            count_negative = 0;
            count_multi = 0;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            
            Resultcopy = Convert.ToDouble(lbl_result.Text);
            Symbol = "+";
            TrueFalse = true;
            count_command = 0;
            count_negative = 0;
            count_add = 0;
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            Resultcopy = Convert.ToDouble(lbl_result.Text);
            Symbol = "-";
            TrueFalse = true;
            count_command = 0;
            count_negative = 0;
            count_minus = 0;
        }

        private void btn_result_Click(object sender, EventArgs e)
        {
            ++count_add;
            ++count_minus;
            ++count_multi;
            ++count_divide;

            Result = Convert.ToDouble(lbl_result.Text);

            if (Symbol=="+")
            {
                if (count_add == 1)
                {
                   lbl_result.Text = (Resultcopy + Result).ToString();
                }
                else if (count_add != 1)
                {
                    lbl_result.Text = (X + Result).ToString();
                }

            }
            else if (Symbol == "-")
            {
                if (count_minus == 1)
                {
                    lbl_result.Text = (Resultcopy - Result).ToString();
                }
                else if (count_minus != 1)
                {
                     lbl_result.Text = (Result - X).ToString();
                }

            }
            else if (Symbol == "x")
            {
                if (count_multi == 1)
                {
                    lbl_result.Text = (Resultcopy * Result).ToString();
                }
                else if (count_multi != 1)
                {
                    lbl_result.Text = (Result * X).ToString();
                }

            }
            else if (Symbol == "/")
            {
                if (count_divide == 1)
                {
                    if (Result == 0)
                    {
                        MessageBox.Show("Error");
                    }
                    else lbl_result.Text = (Resultcopy / Result).ToString();
                }
                else if (count_divide != 1)
                {
                    if (X == 0)
                    {
                        MessageBox.Show("Error");
                    }
                    else lbl_result.Text = (Result / X).ToString();
                }
            }

        }

        
    }
}
