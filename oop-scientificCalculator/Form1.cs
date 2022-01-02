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

        private void clearEntry_Click(object sender, EventArgs e)
        {
            entry.Text = "0";
        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            entry.Text = "0"; equation.Text = "";
        }

        private void numberEntry(object sender, EventArgs e)
        {
            if (entry.Text != "0")
                entry.Text += (sender as Button).Text;
            else entry.Text = (sender as Button).Text;
        }

        private void zero_Click(object sender, EventArgs e)
        {
            if (entry.Text != "0") entry.Text += "0";
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
    }
}
