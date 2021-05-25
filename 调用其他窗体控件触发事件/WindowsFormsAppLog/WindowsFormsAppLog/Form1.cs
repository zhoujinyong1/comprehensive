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
    public partial class Form1 : Form
    {
        public Form1()
        {
            //不断触发事件
            OutLog.LogOut += new OutLog.delegate_LogOut(Log);
            InitializeComponent();
        }
        private void Log(string Conten)
        {
            try
            {
                if (richTextBox1.Lines.Length > 5000)  //文本行超过5000清除
                {
                    richTextBox1.Clear();
                }
                if (Conten.Length > 150)  //输入的文本长度超过150
                {
                    Conten = Conten.Remove(150, Conten.Length - 150); //删除150-末尾
                    Conten += "...";
                }
                richTextBox1.AppendText("\n");  //追加换行
                richTextBox1.SelectionColor = Color.Blue;  //文本颜色
                richTextBox1.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss>>") + Conten);
                richTextBox1.ScrollToCaret();//实时更新位置
            }
            catch(Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Idle += new EventHandler(r);
        }
        private void r(object sender, EventArgs e)
        {
            Random random = new Random();
            double a= random.NextDouble();
            int b = random.Next(1, 900000);
            double i = a + double.Parse(b.ToString());
            Log(i.ToString());

        }
    }
}
