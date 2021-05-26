using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace FTP
{
    public class FtpHelper
    {
        // 默认常量定义
        private static readonly string rootPath = "/";
        private static readonly int defaultReadWriteTimeout = 300000;
        private static readonly int defaultFtpPort = 21;

        #region 设置初始化参数
        private string host = string.Empty;
        public string Host
        {
            get
            {
                return this.host ?? string.Empty;
            }
        }

        private string username = string.Empty;
        public string Username
        {
            get
            {
                return this.username;
            }
        }

        private string password = string.Empty;
        public string Password
        {
            get
            {
                return this.password;
            }
        }

        IWebProxy proxy = null;
        public IWebProxy Proxy
        {
            get
            {
                return this.proxy;
            }
            set
            {
                this.proxy = value;
            }
        }

        private int port = defaultFtpPort;
        public int Port
        {
            get
            {
                return port;
            }
            set
            {
                this.port = value;
            }
        }

        private bool enableSsl = false;
        public bool EnableSsl
        {
            get
            {
                return enableSsl;
            }
        }

        private bool usePassive = true;
        public bool UsePassive
        {
            get
            {
                return usePassive;
            }
            set
            {
                this.usePassive = value;
            }
        }

        private bool useBinary = true;
        public bool UserBinary
        {
            get
            {
                return useBinary;
            }
            set
            {
                this.useBinary = value;
            }
        }

        private string remotePath = rootPath;
        public string RemotePath
        {
            get
            {
                return remotePath;
            }
            set
            {
                string result = rootPath;
                if (!string.IsNullOrEmpty(value) && value != rootPath)
                {
                    result = Path.Combine(Path.Combine(rootPath, value.TrimStart('/').TrimEnd('/')), "/"); // 进行路径的拼接
                }
                this.remotePath = result;
            }
        }

        private int readWriteTimeout = defaultReadWriteTimeout;
        public int ReadWriteTimeout
        {
            get
            {
                return readWriteTimeout;
            }
            set
            {
                this.readWriteTimeout = value;
            }
        }
        #endregion

        #region 构造函数

        public FtpHelper(string host, string username, string password)
            : this(host, username, password, defaultFtpPort, null, false, true, true, defaultReadWriteTimeout)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="host">主机名</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="port">端口号 默认21</param>
        /// <param name="proxy">代理 默认没有</param>
        /// <param name="enableSsl">是否使用ssl 默认不用</param>
        /// <param name="useBinary">使用二进制</param>
        /// <param name="usePassive">获取或设置客户端应用程序的数据传输过程的行为</param>
        /// <param name="readWriteTimeout">读写超时时间 默认5min</param>
        public FtpHelper(string host, string username, string password, int port, IWebProxy proxy, bool enableSsl, bool useBinary, bool usePassive, int readWriteTimeout)
        {
            this.host = host.ToLower().StartsWith("ftp://") ? host : "ftp://" + host;
            this.username = username;
            this.password = password;
            this.port = port;
            this.proxy = proxy;
            this.enableSsl = enableSsl;
            this.useBinary = useBinary;
            this.usePassive = usePassive;
            this.readWriteTimeout = readWriteTimeout;
        }
        #endregion

        /// <summary>
        /// 拼接URL
        /// </summary>
        /// <param name="host">主机名</param>
        /// <param name="remotePath">地址</param>
        /// <param name="fileName">文件名</param>
        /// <returns>返回完整的URL</returns>
        private string UrlCombine(string host, string remotePath, string fileName)
        {
            string result = new Uri(new Uri(new Uri(host.TrimEnd('/')), remotePath), fileName).ToString(); ;
            return result;
        }

        /// <summary>
        /// 创建连接
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="method">方法</param>
        /// <returns>返回 request对象</returns>
        private FtpWebRequest CreateConnection(string url, string method)
        {
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
            request.Credentials = new NetworkCredential(this.username, this.password);
            request.Proxy = this.proxy;
            request.KeepAlive = false;
            request.UseBinary = useBinary;
            request.UsePassive = usePassive;
            request.EnableSsl = enableSsl;
            request.Method = method;
            Console.WriteLine(request);
            return request;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="localFile">本地文件(要上传的文件路径)</param>
        /// <param name="remoteFileName">上传文件名（上传到ftp里的文件名）</param>
        /// <returns>上传成功返回 true</returns>
        public bool Upload(FileInfo localFile, string remoteFileName)
        {
            bool result = false;
            if (localFile.Exists)
            {
                try
                {
                    string url = UrlCombine(Host, RemotePath, remoteFileName);
                    FtpWebRequest request = CreateConnection(url, WebRequestMethods.Ftp.UploadFile);

                    using (Stream rs = request.GetRequestStream())
                    using (FileStream fs = localFile.OpenRead())
                    {
                        byte[] buffer = new byte[1024 * 4];
                        int count = fs.Read(buffer, 0, buffer.Length);
                        while (count > 0)
                        {
                            rs.Write(buffer, 0, count);
                            count = fs.Read(buffer, 0, buffer.Length);
                        }
                        fs.Close();
                        result = true;
                    }
                    MessageBox.Show("上传成功");
                }
                catch (WebException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return result;
            }
            // 处理本地文件不存在的情况
            return false;
        }



        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="serverName">服务器文件名称（ftp里的文件名）</param>
        /// <param name="localName">需要保存在本地的文件名称（下载到文件的路径）</param>
        /// <returns>下载成功返回 true</returns>
        public bool Download(string serverName, string localName)
        {
            bool result = false;
            using (FileStream fs = new FileStream(localName, FileMode.OpenOrCreate))
            {
                try
                {
                    string url = UrlCombine(Host, RemotePath, serverName);
                    Console.WriteLine(url);

                    FtpWebRequest request = CreateConnection(url, WebRequestMethods.Ftp.DownloadFile);
                    request.ContentOffset = fs.Length;
                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    {
                        fs.Position = fs.Length;
                        byte[] buffer = new byte[1024 * 4];
                        int count = response.GetResponseStream().Read(buffer, 0, buffer.Length);
                        while (count > 0)
                        {
                            fs.Write(buffer, 0, count);
                            count = response.GetResponseStream().Read(buffer, 0, buffer.Length);
                        }
                        response.GetResponseStream().Close();
                    }
                    result = true;
                    MessageBox.Show("下载成功");
                }
                catch (WebException ex)
                {
                    // 处理ftp连接中的异常
                    MessageBox.Show(ex.Message);
                }
            }
            return result;
        }

    }

}
