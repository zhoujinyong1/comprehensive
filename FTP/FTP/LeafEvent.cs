using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTP
{
    public class LeafEvent
    {
        /// <summary>
        /// 数据接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        public delegate void DataReceivedHandler(object sender, byte[] data);

        /// <summary>
        /// 发送数据事件
        /// </summary>
        /// <param name="data"></param>
        public delegate bool DataSendHandler(byte[] data);

        /// <summary>
        /// 捕获到IP数据包
        /// 作者：Maximus Ye
        /// 添加时间：2013年9月16日
        /// </summary>
        /// <param name="packet"></param>
        public delegate void PacketReceived(IPPacket packet);
    }
}
