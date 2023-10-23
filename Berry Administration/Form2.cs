using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Berry_Administration
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void timerMostrar_Tick_1(object sender, EventArgs e)
        {
            if (panel3.Width >= 184)
            {
                timerMostrar.Stop();
            }
            else
            {
                panel3.Width = panel3.Width + 5;
            }
        }

        private void timerOcultar_Tick_1(object sender, EventArgs e)
        {
            if (panel3.Width <= 40)
            {
                timerOcultar.Stop();
            }
            else
            {
                panel3.Width = panel3.Width - 5;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (panel3.Width >= 184)
            {
                timerOcultar.Start();
            }
            else if (panel3.Width <= 40)
            {
                timerMostrar.Start();
            }
        }

        
        
    }
}
