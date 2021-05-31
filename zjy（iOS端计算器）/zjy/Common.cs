using System;
using Smobiler.Core.Web;

namespace zjy
{
    public class Common
    {
        private static double f = 0.0;
        private static string shuzi = "";
        private static string result = "";
        public static double dou = 0.0;
        public static string Result
        {
            get { return result; }
            set { result = value; }
        }

        public static string Shuzi
        {
            get { return shuzi; }
            set { shuzi = value; }
        }

        public static double F
        {
            get { return f; }
            set { f = value; }
        }



    }
}