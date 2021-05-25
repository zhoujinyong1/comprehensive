using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppPoJiePassword
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(this.Run0));  //创建第一个线程
            thread.Name = "1";
            thread.Start();
        //    for (int i = 0; i < 2; i++)  //循环之后的线程
        //   {
            //    thread = new Thread(new ParameterizedThreadStart(this.Run1));
            //    thread.Name = "2";
            //    thread.Start();
            //thread = new Thread(new ParameterizedThreadStart(this.Run2));
            //thread.Name = "3";
            //thread.Start();
            //thread = new Thread(new ParameterizedThreadStart(this.Run3));
            //thread.Name = "4";
            //thread.Start();
            //thread = new Thread(new ParameterizedThreadStart(this.Run4));
            //thread.Name = "5";
            //thread.Start();
            //    }

        }
        string s1 = null;
        public void Run0(object m)
        {
            for (int i1 = 0; i1 < 200000; i1++)
            {
                Application.DoEvents();
                //补足二位，若不足二位电脑会自动在前面补0
                s1 = (string)i1.ToString().PadLeft(1, '0');
                //启动进程
                System.Diagnostics.Process p1 = new System.Diagnostics.Process();
                //设置进程执行文件
                p1.StartInfo.FileName = @"C:\Users\admin\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\WinRAR";
                string FileName = @"E:\PPT.rar";
                string path = @"E:\";
                //设置进程执行文件的参数
                p1.StartInfo.Arguments = "x -p" + s1 + FileName +""+path;
                p1.Start();
                //判断执行结果
                Console.WriteLine("错误密码" + s1);
            }
        }

        public void Run1(object m)
        {
            for (int i2 = 200000; i2 < 400000; i2++)
            {
                Application.DoEvents();
                //补足二位，若不足二位电脑会自动在前面补0
                s1 = (string)i2.ToString().PadLeft(1, '0');
                //启动进程
                System.Diagnostics.Process p2 = new System.Diagnostics.Process();
                //设置进程执行文件
                p2.StartInfo.FileName = @"C:\Users\admin\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\WinRAR";
                //设置进程执行文件的参数
                p2.StartInfo.Arguments = "x -p" + s1 + @"C:\Users\admin\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\最新版本里有哪些新功能.rar";
                p2.Start();
                //延时，以便进程执行文件能够完成执行
                //  System.Threading.Thread.Sleep(2000);
                //判断执行结果
                Console.WriteLine("错误密码" + s1);
            }
        }

        public void Run2(object m)
        {
            for (int i3 = 400000; i3 < 600000; i3++)
            {
                Application.DoEvents();
                //补足二位，若不足二位电脑会自动在前面补0
                s1 = (string)i3.ToString().PadLeft(3, '0');
                //启动进程
                System.Diagnostics.Process p3 = new System.Diagnostics.Process();
                //设置进程执行文件
                p3.StartInfo.FileName = @"C:\Users\admin\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\WinRAR";
                //设置进程执行文件的参数
                p3.StartInfo.Arguments = "x -p" + s1 + @"C:\Users\admin\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\最新版本里有哪些新功能.rar";
                p3.Start();
                //延时，以便进程执行文件能够完成执行
                //  System.Threading.Thread.Sleep(2000);
                //判断执行结果
                Console.WriteLine("错误密码" + s1);
            }
        }

        public void Run3(object m)
        {
            for (int i3 = 600000; i3 < 800000; i3++)
            {
                Application.DoEvents();
                //补足二位，若不足二位电脑会自动在前面补0
                s1 = (string)i3.ToString().PadLeft(3, '0');
                //启动进程
                System.Diagnostics.Process p3 = new System.Diagnostics.Process();
                //设置进程执行文件
                p3.StartInfo.FileName = @"C:\Users\admin\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\WinRAR";
                //设置进程执行文件的参数
                p3.StartInfo.Arguments = "x -p" + s1 + @"C:\Users\admin\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\最新版本里有哪些新功能.rar";
                p3.Start();
                //延时，以便进程执行文件能够完成执行
                //  System.Threading.Thread.Sleep(2000);
                //判断执行结果
                Console.WriteLine("错误密码" + s1);
            }
        }

        public void Run4(object m)
        {
            for (int i3 = 800000; i3 < 1000000; i3++)
            {
                Application.DoEvents();
                //补足二位，若不足二位电脑会自动在前面补0
                s1 = (string)i3.ToString().PadLeft(3, '0');
                //启动进程
                System.Diagnostics.Process p3 = new System.Diagnostics.Process();
                //设置进程执行文件
                p3.StartInfo.FileName = @"C:\Users\admin\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\WinRAR";
                //设置进程执行文件的参数
                p3.StartInfo.Arguments = "x -p" + s1 + @"C:\Users\admin\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\最新版本里有哪些新功能.rar";
                p3.Start();
                //延时，以便进程执行文件能够完成执行
                //  System.Threading.Thread.Sleep(2000);
                //判断执行结果
                Console.WriteLine("错误密码" + s1);
            }
        }
        public class PermutationAndCombination<T>
        {
            /// <summary>
            /// 交换两个变量
            /// </summary>
            /// <param name="a">变量1</param>
            /// <param name="b">变量2</param>
            public static void Swap(ref T a, ref T b)
            {
                T temp = a;
                a = b;
                b = temp;
            }
            /// <summary>
            /// 递归算法求数组的组合(私有成员)
            /// </summary>
            /// <param name="list">返回的范型</param>
            /// <param name="t">所求数组</param>
            /// <param name="n">辅助变量</param>
            /// <param name="m">辅助变量</param>
            /// <param name="b">辅助数组</param>
            /// <param name="M">辅助变量M</param>
            private static void GetCombination(ref List<T[]> list, T[] t, int n, int m, int[] b, int M)
            {
                for (int i = n; i >= m; i--)
                {
                    b[m - 1] = i - 1;
                    if (m > 1)
                    {
                        GetCombination(ref list, t, i - 1, m - 1, b, M);
                    }
                    else
                    {
                        if (list == null)
                        {
                            list = new List<T[]>();
                        }
                        T[] temp = new T[M];
                        for (int j = 0; j < b.Length; j++)
                        {
                            temp[j] = t[b[j]];
                        }
                        list.Add(temp);
                    }
                }
            }
            /// <summary>
            /// 递归算法求排列(私有成员)
            /// </summary>
            /// <param name="list">返回的列表</param>
            /// <param name="t">所求数组</param>
            /// <param name="startIndex">起始标号</param>
            /// <param name="endIndex">结束标号</param>
            private static void GetPermutation(ref List<T[]> list, T[] t, int startIndex, int endIndex)
            {
                if (startIndex == endIndex)
                {
                    if (list == null)
                    {
                        list = new List<T[]>();
                    }
                    T[] temp = new T[t.Length];
                    t.CopyTo(temp, 0);
                    list.Add(temp);
                }
                else
                {
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        Swap(ref t[startIndex], ref t[i]);
                        GetPermutation(ref list, t, startIndex + 1, endIndex);
                        Swap(ref t[startIndex], ref t[i]);
                    }
                }
            }
            /// <summary>
            /// 求从起始标号到结束标号的排列，其余元素不变
            /// </summary>
            /// <param name="t">所求数组</param>
            /// <param name="startIndex">起始标号</param>
            /// <param name="endIndex">结束标号</param>
            /// <returns>从起始标号到结束标号排列的范型</returns>
            public static List<T[]> GetPermutation(T[] t, int startIndex, int endIndex)
            {
                if (startIndex < 0 || endIndex > t.Length - 1)
                {
                    return null;
                }
                List<T[]> list = new List<T[]>();
                GetPermutation(ref list, t, startIndex, endIndex);
                return list;
            }
            /// <summary>
            /// 返回数组所有元素的全排列
            /// </summary>
            /// <param name="t">所求数组</param>
            /// <returns>全排列的范型</returns>
            public static List<T[]> GetPermutation(T[] t)
            {
                return GetPermutation(t, 0, t.Length - 1);
            }
            /// <summary>
            /// 求数组中n个元素的排列
            /// </summary>
            /// <param name="t">所求数组</param>
            /// <param name="n">元素个数</param>
            /// <returns>数组中n个元素的排列</returns>
            public static List<T[]> GetPermutation(T[] t, int n)
            {
                if (n > t.Length)
                {
                    return null;
                }
                List<T[]> list = new List<T[]>();
                List<T[]> c = GetCombination(t, n);
                for (int i = 0; i < c.Count; i++)
                {
                    List<T[]> l = new List<T[]>();
                    GetPermutation(ref l, c[i], 0, n - 1);
                    list.AddRange(l);
                }
                return list;
            }
            /// <summary>
            /// 求数组中n个元素的组合
            /// </summary>
            /// <param name="t">所求数组</param>
            /// <param name="n">元素个数</param>
            /// <returns>数组中n个元素的组合的范型</returns>
            public static List<T[]> GetCombination(T[] t, int n)
            {
                if (t.Length < n)
                {
                    return null;
                }
                int[] temp = new int[n];
                List<T[]> list = new List<T[]>();
                GetCombination(ref list, t, t.Length, n, temp, n);
                return list;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //排列组合 生成密码
            StringBuilder sb = new StringBuilder();
            var strContent = System.IO.File.ReadAllText("02 pwd.txt");
            List<string> list = Regex.Split(strContent, "\r\n").ToList();//一个sheet包含的所有行，行与行之间用回车分隔

            //这里的1234，就是组合的个数
            new List<int> { 1, 2, 3, 4 }.ForEach(num =>
            {
                List<string[]> ListCombination = PermutationAndCombination<string>.GetPermutation(list.ToArray(), num); //求全部的3-3组合
                foreach (var arr in ListCombination)
                {
                    string pwd = "";//排列组合后的密码
                    foreach (var item in arr)
                    {
                        pwd += item;
                    }
                    sb.Append(pwd + "\r\n");
                }
                Console.WriteLine($"num:{num}  count:{ListCombination.Count}");
            });

            System.IO.File.WriteAllText("222.txt", sb.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
         //   webBrowser1.Url=new Uri("http://www.uimaker.com/uimakerdown/logindesign/");        
          //  webBrowser1.ObjectForScripting = this;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           // webBrowser1.Url = new Uri("http://www.uimaker.com/uimakerdown/logindesign/");
           try
            {
                //webBrowser1.Document.GetElementById("tbYHM").SetAttribute("value", "用户名");
                //webBrowser1.Document.GetElementById("tbPSW").SetAttribute("value", "密码");
                //HtmlElement ClickBtn = webBrowser1.Document.GetElementById("imgDL");
                //ClickBtn.InvokeMember("Click");//对网页按钮自动点击鼠标左键 
            }
            catch(Exception)
            {

            }
            
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
           // IHTMLWindow2 win = (IHTMLWindow2)webBrowser1.Document.Window.DomWindow; 
           // string s = @"function confirm() {"; s += @"return true;"; s += @"}"; 
          //  s += @"function alert(){}"; 
           // win.execScript(s, "javascript"); 
           // webBrowser1.ObjectForScripting = this;
        }
    }
}
