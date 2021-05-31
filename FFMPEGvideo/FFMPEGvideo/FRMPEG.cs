using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFMPEGvideo
{
    public class FFMEPG
    {
        /// <summary>
        /// 视频时长
        /// </summary>
        public static string duration;
        /// <summary>
        /// 获取视频时长
        /// </summary>
        /// <param name="path"></param>
        public void Info(string path)
        {
            try
            {
                using (System.Diagnostics.Process pro = new System.Diagnostics.Process())
                {
                    pro.StartInfo.UseShellExecute = false;
                    // pro.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    pro.StartInfo.ErrorDialog = false;
                    pro.StartInfo.CreateNoWindow = true;
                    pro.StartInfo.RedirectStandardError = true;
                    pro.StartInfo.FileName = "ffmpeg.exe";
                    pro.StartInfo.Arguments = " -i " + path;
                    pro.Start();
                    // pro.WaitForExit();
                    System.IO.StreamReader errorreader = pro.StandardError;
                    pro.WaitForExit(1000);
                    string result = errorreader.ReadToEnd();
                    if (!string.IsNullOrEmpty(result))
                    {
                        result = result.Substring(result.IndexOf("Duration: ") + ("Duration: ").Length, ("00:00:00").Length);
                        duration = result;
                    }
                }
            }
            catch (Exception)
            {
                
            }
           
        }
        //视频切割
        public string Cut(string OriginFile/*视频源文件*/, string DstFile/*生成的文件*/, TimeSpan startTime/*开始时间*/, TimeSpan intervalTime/*时间间隔*/)
        {
            try
            {
                string strCmd = "-ss 00:00:00 -i " + OriginFile + " -ss " +
                 startTime.ToString() + " -t " + intervalTime.ToString() + " -vcodec copy " + DstFile + " -y ";

                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = "ffmpeg.exe";//要执行的程序名称  
                p.StartInfo.Arguments = " " + strCmd;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = false;//可能接受来自调用程序的输入信息  
                p.StartInfo.RedirectStandardOutput = false;//由调用程序获取输出信息   
                p.StartInfo.RedirectStandardError = false;//重定向标准错误输出
                p.StartInfo.CreateNoWindow = false;//不显示程序窗口   
                p.Start();//启动程序   
                p.WaitForExit();//等待程序执行完退出进程

                if (System.IO.File.Exists(DstFile))
                {
                    return DstFile;
                }
                return "";
            }
            catch (Exception)
            {
                return "";
            }
            
        }

        public List<string> ALLts = new List<string>();
        /// <summary>
        /// 合成视频
        /// </summary>
        /// <param name="inFile">输入视频的地址</param>
        /// <param name="outFile">输出视频的地址</param>
        public void ConcatMp4(string[] inFile)
        {
            var directoryPath = AppDomain.CurrentDomain.BaseDirectory;//程序的根目录
            for (int i = 0; i < inFile.Length ; i++)
            {
                string ts = i.ToString() + ".ts";
                ALLts.Add(Path.Combine(directoryPath, ts));
                //生成ts文件
                string command = $" -i {inFile[i]} -vcodec copy -acodec copy -vbsf h264_mp4toannexb  {Path.Combine(directoryPath, ts)} -y" ;
                Execute(command);            
            }
            //合并临时文件并输出新的视频
            string outputFile = (Form1.Path + Guid.NewGuid().ToString() + ".mp4").Replace("/", "\\");
            string allts = "\"";
            for (int j = 0; j < ALLts.Count; j++)
            {
                if (j == ALLts.Count - 1)
                {
                    allts = allts + ALLts[j] +"\"";
                }
                else
                {
                    allts = allts + ALLts[j] + "|";
                }
            }
            string megreCommand = $"-i concat:{allts} -acodec copy -vcodec copy -absf aac_adtstoasc {outputFile} -y";
            //合并放到后面执行是因为 ts文件转换需要时间，如果三行命令一起执行的话可能会导致ts文件还未转换完毕就开始合并ts文件，这会导致报找不到ts文件的错
            // Execute(megreCommand);
            Execute(megreCommand);
            //删除生成的ts文件
            Task.Run(() =>
            {
                for (int m = 0; m < ALLts.Count; m++)
                {
                    if (File.Exists(ALLts[m])) File.Delete(ALLts[m]);
                }
            });
            MessageBox.Show("合并成功，路径为："+outputFile);

        }
        public static void Execute(string command)
        {

            Process p = new Process();//建立外部调用线程
            p.StartInfo.FileName = "ffmpeg.exe";
            p.StartInfo.Arguments = command;//程序参数，字符串形式输入
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = false;//可能接受来自调用程序的输入信息  
            p.StartInfo.RedirectStandardOutput = false;//由调用程序获取输出信息   
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = false;//不显示程序窗口 
            p.Start();//启动线程
            p.ErrorDataReceived += new DataReceivedEventHandler(Output);
          //  p.OutputDataReceived += new DataReceivedEventHandler(Output);
            p.BeginErrorReadLine();//开始异步读取
            p.WaitForExit();//阻塞等待进程结束
            p.Close();//关闭进程
            p.Dispose();         
        }
         /// <summary>
        /// 输出消息
        /// </summary>
        /// <param name="sendProcess"></param>
        /// <param name="output"></param>
        public static void Output(object sendProcess, DataReceivedEventArgs output)
        {
            if (!string.IsNullOrEmpty(output.Data))
            {
                WriteLog.AddLog(output.Data);
            }
        }
    }
}
