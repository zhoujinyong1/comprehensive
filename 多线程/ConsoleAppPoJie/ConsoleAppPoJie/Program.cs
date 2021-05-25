using System;
using System.Threading;

namespace ConsoleAppPoJie
{
    class Program
    {
        static void Main(string[] args)
        {
            Program P = new Program();
            Thread thread = new Thread(new ParameterizedThreadStart(P.Run));  //创建第一个线程
            thread.Name = "1";
            thread.Start();
            for(int i = 0; i < 10; i++)  //循环之后的线程
            {
            thread = new Thread(new ParameterizedThreadStart(P.Run));
            thread.Name = i.ToString();
            thread.Start();
            }
        }
        public void Run(object m)  //线程执行的方法
        {
            for (int i = 0; i < 100; i++)
            {
               string s1 = (string)i.ToString().PadLeft(1, '0');
                Console.WriteLine(s1);
                Thread.Sleep(200);
            }
        }
    }
}
