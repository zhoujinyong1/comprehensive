using Grpc.Core;
using Shell32;
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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"E:/1/新建文件夹/";  //歌曲读取地址
            DirectoryInfo root = new DirectoryInfo(path);
            foreach(FileInfo f in root.GetFiles())
            {
                string name = f.Name;
               // MessageBox.Show(name);
                string file = "E:/1/新建文件夹/" + name;
                ShellClass sh = new ShellClass();
                Folder dir = sh.NameSpace(Path.GetDirectoryName(file));
                FolderItem item = dir.ParseName(Path.GetFileName(file));
                string str = dir.GetDetailsOf(item, 0);
                string a = str.Replace(" (V0)", string.Empty);  //去除字符串的（V0）
                //  MessageBox.Show(a);
                string destFileName = @"E:/1/" + a;  //歌曲存放地址
                if (File.Exists(file))
                {
                    File.Move(file, destFileName); //移动
                }
            }
           
        }
    }
}
