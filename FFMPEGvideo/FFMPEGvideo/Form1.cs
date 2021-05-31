using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFMPEGvideo
{
	public partial class Form1 : Form
	{
		public FFMEPG fFMEPG = new FFMEPG();
		public TimeSpan startTime;
		public TimeSpan intervalTime;
		public string videoPath;
		public string videoName;
		public string videoName_name;
		public string videoName_suffix;
		public static string Path;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			textBox1.Text = IniFileHelper.Instance.GetIniString("Video", "Time");
			textBox2.Text = IniFileHelper.Instance.GetIniString("Video", "Path");
		}


		/// <summary>
		/// 剪辑
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{ 
			OpenFileDialog pOpenFileDialog = new OpenFileDialog();
			pOpenFileDialog.Filter = "所有文件|*.*";//若打开指定类型的文件只需修改Filter，如打开txt文件，改为*.txt即可
			pOpenFileDialog.Multiselect = false;
			pOpenFileDialog.Title = "上传文件";
			if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
			{
				videoPath = pOpenFileDialog.FileName;//视频路径	
				videoName = System.IO.Path.GetFileName(pOpenFileDialog.FileName);  //文件名:112.mp4
				videoName_name = System.IO.Path.GetFileNameWithoutExtension(pOpenFileDialog.FileName);  //112
				videoName_suffix = System.IO.Path.GetExtension(pOpenFileDialog.FileName);  //.mp4
			}
            fFMEPG.Info(videoPath);
            string[] time = FFMEPG.duration.Split(':');
            //单位为秒
            int allTime = int.Parse(time[0]) * 3600 + int.Parse(time[1]) * 60 + int.Parse(time[2]);
            int timeInterval = 60 * int.Parse(IniFileHelper.Instance.GetIniString("Video", "Time")); //时间间隔
            int num = allTime / timeInterval;
            for (int i = 0; i <= num; i++)
            {
                startTime = new TimeSpan(0, i, 0);
                intervalTime = new TimeSpan(0, int.Parse(IniFileHelper.Instance.GetIniString("Video", "Time")), 0);  //间隔为1分钟																												 // string[] lioutPath = videoPath.Split('.');
				string outPath = textBox2.Text + videoName_name + "_" + i.ToString() + "." + videoName_suffix;  //输出路径
				//pathCheck(outPath);
				fFMEPG.Cut(videoPath, outPath, startTime, intervalTime);//分割
            }
        }

		/// <summary>
		/// 合并
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click(object sender, EventArgs e)
		{
			Path = textBox2.Text;

			OpenFileDialog pOpenFileDialog = new OpenFileDialog();
			pOpenFileDialog.Filter = "所有文件|*.*";//若打开指定类型的文件只需修改Filter，如打开txt文件，改为*.txt即可
			pOpenFileDialog.Multiselect = true;
			pOpenFileDialog.Title = "上传文件";
			if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
			{
				string[] flies = pOpenFileDialog.FileNames;//视频路径
				fFMEPG.ConcatMp4(flies);	
			}
		}

		/// <summary>
		/// 保存
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button3_Click(object sender, EventArgs e)
		{
			IniFileHelper.Instance.WriteIniString("Video", "Time", textBox1.Text);
			IniFileHelper.Instance.WriteIniString("Video", "Path", textBox2.Text);
			MessageBox.Show("保存成功");
		}
	}
}
