using System;
using System.IO;
using System.Windows.Forms;

namespace FTP
{
    public partial class Form1 : Form
    {
        public FtpHelper ftpHelper;
        public Form1()
        {
            ftpHelper = new FtpHelper(IniFileHelper.Instance.GetIniString("FTP", "IP"),
                IniFileHelper.Instance.GetIniString("FTP", "UserName"),
                IniFileHelper.Instance.GetIniString("FTP", "PassWord"));
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = IniFileHelper.Instance.GetIniString("FTP", "IP");
            textBox4.Text = IniFileHelper.Instance.GetIniString("FTP", "Port");
            textBox2.Text = IniFileHelper.Instance.GetIniString("FTP", "UserName");
            textBox3.Text = IniFileHelper.Instance.GetIniString("FTP", "PassWord");
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //连接
            //FtpHelper ftpHelper = new FtpHelper("192.168.74.1", "", "");
            //上传
            // FileInfo fileInfo = new FileInfo("E:\\1.txt");
            // ftpHelper.Upload(fileInfo, "2.txt");
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.Filter = "所有文件|*.*";//若打开指定类型的文件只需修改Filter，如打开txt文件，改为*.txt即可
            pOpenFileDialog.Multiselect = false;
            pOpenFileDialog.Title = "上传文件";
            if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = pOpenFileDialog.FileName;
                string name = pOpenFileDialog.SafeFileName;
                // MessageBox.Show(path+"-----"+name);
                FileInfo fileInfo = new FileInfo(path);
                ftpHelper.Upload(fileInfo, name);
            }
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //连接
           // FtpHelper ftpHelper = new FtpHelper("192.168.74.1", "", "");
            //下载
            ftpHelper.Download("截图工具.zip", "E:\\截图工具.zip");
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            IniFileHelper.Instance.WriteIniString("FTP", "IP", textBox1.Text);
            IniFileHelper.Instance.WriteIniString("FTP", "Port", textBox4.Text);
            IniFileHelper.Instance.WriteIniString("FTP", "UserName", textBox2.Text);
            IniFileHelper.Instance.WriteIniString("FTP", "PassWord", textBox3.Text);
            MessageBox.Show("保存成功");
        }
    }
}
