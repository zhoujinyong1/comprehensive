using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppLog
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            Form1 form1 = new Form1();
            form1.Show();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OutLog.Log("10000");
        }
    }
}
