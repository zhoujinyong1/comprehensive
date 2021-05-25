using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppLog
{
    class Class1
    {
    }
    //让Form2调用Form1的控件
    class OutLog 
    {
        //委托事件
        public delegate void delegate_LogOut(string Conten);
        /// <summary>
        /// 事件
        /// </summary>
        public static event delegate_LogOut LogOut;

        /// <summary>
        /// 触发
        /// </summary>
        /// <param name="Conten"></param>
        public static void Log(string Conten)
        {
            LogOut(Conten);
        }
    }

}
