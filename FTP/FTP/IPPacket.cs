using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTP
{
    /// <summary>
    /// IP数据包
    /// </summary>
    public class IPPacket
    {
        private string protocol;//协议
        private string sourceIP;//源地IP
        private int sourcePort;//源地Port
        private string targetIP;//目标IP
        private int targetPort;//目标Port
        //private string version;//IP版本号
        //private uint totalLength;//数据包总长度
        //private uint messageLength;//数据包中消息长度
        //private uint headerLength;//数据包中头长度
        private byte[] receiveBuffer = null;//数据包中数据字节流
        //private byte[] headerBuffer = null;//数据包头部数据字节流
        //private byte[] messageBuffer = null;//数据包消息数据字节流
        private DateTime recTime = DateTime.Now;//捕获时间

        /// <summary>
        /// 协议
        /// </summary>
        public string Protocol
        {
            get { return protocol; }
            set { protocol = value; }
        }

        /// <summary>
        /// 源IP
        /// </summary>
        public string SourceIP
        {
            get { return sourceIP; }
            set { sourceIP = value; }
        }

        /// <summary>
        /// 源Port
        /// </summary>
        public int SourcePort
        {
            get { return sourcePort; }
            set { sourcePort = value; }
        }

        /// <summary>
        /// 目标IP
        /// </summary>
        public string TargetIP
        {
            get { return targetIP; }
            set { targetIP = value; }
        }

        /// <summary>
        /// 目标Port
        /// </summary>
        public int TargetPort
        {
            get { return targetPort; }
            set { targetPort = value; }
        }

        ///// <summary>
        ///// IP版本号
        ///// </summary>
        //public string Version
        //{
        //    get { return version; }
        //    set { version = value; }
        //}
        ///// <summary>
        ///// 数据包总长度
        ///// </summary>
        //public uint TotalLength
        //{
        //    get { return totalLength; }
        //    set { totalLength = value; }
        //}
        ///// <summary>
        ///// 数据包中消息长度
        ///// </summary>
        //public uint MessageLength
        //{
        //    get { return messageLength; }
        //    set { messageLength = value; }
        //}
        ///// <summary>
        ///// 数据包中头长度
        ///// </summary>
        //public uint HeaderLength
        //{
        //    get { return headerLength; }
        //    set { headerLength = value; }
        //}
        /// <summary>
        /// 数据包中数据字节流
        /// </summary>
        public byte[] ReceiveBuffer
        {
            get { return receiveBuffer; }
            set { receiveBuffer = value; }
        }
        ///// <summary>
        ///// 数据包头部数据字节流
        ///// </summary>
        //public byte[] HeaderBuffer
        //{
        //    get { return headerBuffer; }
        //    set { headerBuffer = value; }
        //}
        ///// <summary>
        ///// 数据包消息数据字节流
        ///// </summary>
        //public byte[] MessageBuffer
        //{
        //    get { return messageBuffer; }
        //    set { messageBuffer = value; }
        //}
        /// <summary>
        /// 捕获时间
        /// </summary>
        public DateTime RecTime
        {
            get { return recTime; }
            set { recTime = value; }
        }
    }
}
