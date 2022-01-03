using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oop_scientificCalculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private double entryValue, anotherEntry;
        private string multiOperator;

        private void clearEntry_Click(object sender, EventArgs e)
        {
            entry.Text = "0";
        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            entryValue = anotherEntry = 0;
            entry.Text = "0"; equation.Text = ""; 
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            entry.Text = entry.Text.Remove(entry.Text.Length - 1);
            if (entry.Text == "") entry.Text = "0";
        }

        private void numbers_Click(object sender, EventArgs e)
        {
            if (entry.Text == "3.1415926535897931" ||
                entry.Text == "2.7182818284590451" ||
                entry.Text == "0") entry.Text = "";
            entry.Text += (sender as Button).Text;
        }

        private void constants_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Name == "pi")
                entry.Text = "3.1415926535897931";
            else if ((sender as Button).Name == "euler")
                entry.Text = "2.7182818284590451";
        }

        private void signToggle_Click(object sender, EventArgs e)
        {
            if (entry.Text != "0")
            {
                if (entry.Text[0] != '-')
                    entry.Text = '-' + entry.Text;
                else entry.Text = entry.Text[1..];
            }
        }

        private void decimalPoint_Click(object sender, EventArgs e)
        {
            if (!entry.Text.Contains(".")) entry.Text += ".";
        }

        private double factorial_equation(double num)
        {
            double result = 1;
            for (double i = 1; i <= num; i++)
                result *= i;
            return result;
        }

        private void single_operator(object sender, EventArgs e)
        {
            entryValue = Double.Parse(entry.Text);

            switch ((sender as Button).Name)
            {
                // for arithmethic equations
                case "logarithm":
                    entry.Text = Math.Log10(entryValue).ToString();
                    break;
                case "naturalLogarithm":
                    entry.Text = Math.Log(entryValue).ToString();
                    break;

                // for algrebraic equations
                case "squareRoot":
                    entry.Text = Math.Sqrt(entryValue).ToString();
                    break;
                case "squared":
                    entry.Text = Math.Pow(entryValue, 2).ToString();
                    break;
                case "twoRaisedTo":
                    entry.Text = Math.Pow(2, entryValue).ToString();
                    break;
                case "inverse":
                    entry.Text = (1 / entryValue).ToString();
                    break;
                case "absolute":
                    if (entry.Text[0] == '-') entry.Text = entry.Text[1..];
                    break;

                // for statistical equations
                case "factorial":
                    entry.Text = factorial_equation(entryValue).ToString();
                    break;
                case "exponential":
                    entry.Text = string.Format("{0:0.##E+00}", entryValue);
                    break;

                // for trigonometric equations
                case "sine":
                    entry.Text = Math.Sin(Math.PI * entryValue / 180).ToString();
                    break;
                case "cosine":
                    entry.Text = Math.Cos(Math.PI * entryValue / 180).ToString();
                    break;
                case "tangent":
                    entry.Text = Math.Tan(Math.PI * entryValue / 180).ToString();
                    break;

                default: break;
            }
        }

        private void multiple_operators(object sender, EventArgs e)
        {
            entryValue = Double.Parse(entry.Text);
            multiOperator = (sender as Button).Name;
        }

        private void equals_Click(object sender, EventArgs e)
        {
            anotherEntry = Double.Parse(entry.Text);

            switch (multiOperator)
            {
                // for arithmethic equations
                case "add":
                    entry.Text = (entryValue + anotherEntry).ToString();
                    break;
                case "subtract":
                    entry.Text = (entryValue - anotherEntry).ToString();
                    break;
                case "multiply":
                    entry.Text = (entryValue * anotherEntry).ToString();
                    break;
                case "divide":
                    entry.Text = (entryValue / anotherEntry).ToString();
                    break;
                case "modulus":
                    // to-do

                    break;

                // for algrebraic equations
                case "root":
                    // to-do

                    break;
                case "exponent":
                    // to-do

                    break;

                default: break;
            }
        }
    }
}
