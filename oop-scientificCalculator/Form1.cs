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

        private double entryValue; private bool operatorClick;
        private double leftEntry = double.NaN, rightEntry = double.NaN;
        private string previousOperator = null, currentOperator = null;

        private void clearEntry_Click(object sender, EventArgs e)
        {
            entry.Text = "0";
        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            entry.Text = "0"; equation.Text = ""; entryValue = 0;
            leftEntry = rightEntry = double.NaN; operatorClick = false;
            previousOperator = currentOperator = null;
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
                entry.Text == "0" || operatorClick) { entry.Text = ""; }
            entry.Text += (sender as Button).Text; operatorClick = false;
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

        private bool multiple_Complete()
        {
            return leftEntry != double.NaN && rightEntry != double.NaN &&
                previousOperator != null && currentOperator != null;
        }

        private void multiple_operators(object sender, EventArgs e)
        {
            string mainOperator = (sender as Button).Name;
            string buttonText = (sender as Button).Text;
            string entryText = entry.Text;

            if (!operatorClick)
            {
                if (mainOperator == "root") {
                    char[] superscript = {
                        '⁰', '¹', '²', '³', '⁴', '⁵', '⁶', '⁷', '⁸', '⁹'
                    }; buttonText = "√"; entryText = "";
                    foreach (char c in entry.Text)
                        entryText += superscript[c - '0'];
                } else if (mainOperator == "exponent") { buttonText = "^"; }

                entryValue = Double.Parse(entry.Text);
                if (currentOperator == null)
                {
                    rightEntry = entryValue;
                    currentOperator = mainOperator;
                }
                else
                {
                    leftEntry = rightEntry; rightEntry = entryValue;
                    previousOperator = currentOperator;
                    currentOperator = mainOperator;
                }

                if (multiple_Complete())
                {
                    switch (previousOperator)
                    {
                        // for arithmethic equations
                        case "add":
                            entry.Text = (leftEntry + rightEntry).ToString();
                            break;
                        case "subtract":
                            entry.Text = (leftEntry - rightEntry).ToString();
                            break;
                        case "multiply":
                            entry.Text = (leftEntry * rightEntry).ToString();
                            break;
                        case "divide":
                            entry.Text = (leftEntry / rightEntry).ToString();
                            break;
                        case "modulus":
                            entry.Text = (leftEntry % rightEntry).ToString();
                            break;

                        // for algrebraic equations
                        case "root":
                            entry.Text = Math.Pow(rightEntry, 1 / leftEntry).ToString();
                            break;
                        case "exponent":
                            entry.Text = Math.Pow(leftEntry, rightEntry).ToString();
                            break;

                        default: break;
                    }

                    // re-initialize variables
                    leftEntry = double.Parse(entry.Text);
                    previousOperator = currentOperator; currentOperator = null;
                } equation.Text += $"{entryText} {buttonText} ";  // print equation
            }
            else if (previousOperator == "equals" && operatorClick)
            {
                previousOperator = mainOperator;
                equation.Text = $"{leftEntry} {buttonText} ";   // print equation
            }

            // track when user had clicked an operator
            operatorClick = true;
        }
    }
}
