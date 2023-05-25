using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace complexNums
{
    public partial class Form1 : Form
    {
        ComplexNumbers c;
        public Form1()
        {
            InitializeComponent();
            c = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "") textBox1.Text = "0";
            if (textBox2.Text == "") textBox2.Text = "0";
            var Re = Convert.ToDouble(textBox1.Text);
            var Im = Convert.ToDouble(textBox2.Text);
            c = new ComplexNumbers(Re, Im);
            ComplexNumbers.Precision = (double)numericUpDown1.Value;
            string str = c.CalcSin().toString(-(int)numericUpDown1.Value);
            label3.Visible = true;
            if (label7.Text != "") label7.Text = "";
            label7.Text = str;     
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
