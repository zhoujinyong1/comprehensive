﻿using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace FTP
{
    public class IniFileHelper
    {
        // ini配置文件路径
        string strIniFilePath;

        // 返回0表示失败，非0为成功  
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        // 返回取得字符串缓冲区的长度  
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern long GetPrivateProfileString(string section, string key, string strDefault, StringBuilder retVal, int size, string filePath);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]    //引入API（读取配置文件 .dll）
        private static extern int GetPrivateProfileInt(string section, string key, int nDefault, string filePath);   //声明方法

        private static IniFileHelper m_this;

        public static IniFileHelper Instance
        {
            get
            {
                return m_this ?? (m_this = new IniFileHelper());
            }
        }

        /// <summary>  
        /// 无参构造函数  
        /// </summary>  
        /// <returns></returns>  
        public IniFileHelper()
        {
            //文件路径
            this.strIniFilePath = Directory.GetCurrentDirectory() + @"\Config\config.ini";
        }

        /// <summary>  
        /// 有参构造函数  
        /// </summary>  
        /// <param name="strIniFilePath">ini配置文件路径</param>  
        /// <returns></returns>  
        public IniFileHelper(string strIniFilePath)
        {
            if (strIniFilePath != null)
            {
                this.strIniFilePath = strIniFilePath;
            }
        }

        /// <summary>  
        /// 获取ini配置文件中的字符串  
        /// </summary>  
        /// <param name="section">节名</param>  
        /// <param name="key">键名</param>  
        /// <returns>结果</returns>  
        public string GetIniString(string section, string key)
        {
            var temp = new StringBuilder(1024);
            long liRet = GetPrivateProfileString(section, key, "", temp, 1024, strIniFilePath);
            if (liRet >= 1)
            { return temp.ToString(); }
            else
            { return ""; }
        }

        /// <summary>  
        /// 获取ini配置文件中的整型值  
        /// </summary>  
        /// <param name="section">节名</param>  
        /// <param name="key">键名</param>  
        /// <param name="nDefault">默认值</param>  
        /// <returns></returns>  
        public int GetIniInt(string section, string key, int nDefault)
        {
            return GetPrivateProfileInt(section, key, nDefault, strIniFilePath);
        }

        /// <summary>  
        /// 往ini配置文件写入字符串  
        /// </summary>  
        /// <param name="section">节名</param>  
        /// <param name="key">键名</param>  
        /// <param name="val">要写入的字符串</param>  
        /// <returns>成功true,失败false</returns>  
        public bool WriteIniString(string section, string key, string val)
        {
            long liRet = WritePrivateProfileString(section, key, val, strIniFilePath);
            return (liRet != 0);
        }

        /// <summary>  
        /// 往ini配置文件写入整型数据  
        /// </summary>  
        /// <param name="section">节名</param>  
        /// <param name="key">键名</param>  
        /// <param name="val">要写入的数据</param>  
        /// <returns>成功true,失败false</returns>  
        public bool WriteIniInt(string section, string key, int val)
        {
            return WriteIniString(section, key, val.ToString());
        }
    }
}
