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

        private double entryValue; private string operatorUsed;

        private void clearEntry_Click(object sender, EventArgs e)
        {
            entry.Text = "0";
        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            entry.Text = "0"; equation.Text = ""; entryValue = 0;
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

        private void arithmethicEq(object sender, EventArgs e)
        {
            entryValue = Double.Parse(entry.Text); 
            operatorUsed = (sender as Button).Name;
        }

        private void equals_Click(object sender, EventArgs e)
        {
            switch (operatorUsed)
            {
                // for arithmethic equations
                case "add":
                    entry.Text = (entryValue + Double.Parse(entry.Text)).ToString();
                    break;
                case "subtract":
                    entry.Text = (entryValue - Double.Parse(entry.Text)).ToString();
                    break;
                case "multiply":
                    entry.Text = (entryValue * Double.Parse(entry.Text)).ToString();
                    break;
                case "divide":
                    entry.Text = (entryValue / Double.Parse(entry.Text)).ToString();
                    break;
                // case "modulus":

                // case "logarithm":

                // case "naturalLogarithm":


                // for algrebraic equations

                // case "root":

                // case "exponent":

                // case "squareRoot":

                // case "square":

                // case "twoRaisedto":

                // case "inverse":


                // for statistical equations

                // case "factorial":

                // case "exponential":

                // case "absolute":


                // for trigonometric equations

                // case "sine":

                // case "cosine":

                // case "tangent":


                default: break;
            }
        }
    }
}
