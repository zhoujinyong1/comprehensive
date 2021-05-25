using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private static System.Timers.Timer timer;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            Application.Idle += new EventHandler(Label3);
        }

        private void Label1(object sender, EventArgs e)
        {
            label1.Text = string.Format("{0}/{1}/{2}--{3}:{4}:{5}", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("dd"),
                  DateTime.Now.ToString("HH"), DateTime.Now.ToString("mm"), DateTime.Now.ToString("ss")
                );
        }
        private void Label2(object sender, EventArgs e)
        {
            label2.Text = string.Format("{0}/{1}/{2}--{3}:{4}:{5}", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("dd"),
                  DateTime.Now.ToString("HH"), DateTime.Now.ToString("mm"), DateTime.Now.ToString("ss")
                );
        }

        private void Label3(object sender, EventArgs e)
        {
            label4.Text = string.Format("{0}/{1}/{2}--{3}:{4}:{5}", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("dd"),
                  DateTime.Now.ToString("HH"), DateTime.Now.ToString("mm"), DateTime.Now.ToString("ss")
                );
        }
    }
}
