using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01.My.Demo
{
    class Database
    {
        string url = Application.StartupPath + "\\database\\DatabaseBook.mdb";  //数据库路径
        string password = ""; //密码

        public OleDbConnection conn = new OleDbConnection();

        /// <summary>
        /// 是否连接数据库，连接成功则返回True
        /// </summary>
        public bool open()
        {
            //连接数据库
            conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + url +
                 ";Jet OLEDB:Database Password=" + password + ";"
                );
            try
            {
                conn.Open();
                return conn.State == System.Data.ConnectionState.Open; //判断是否打开
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
         
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void close()
        {
            try
            {
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("没打开数据库连接");
            }
        }

        /// <summary>
        /// 执行添加、删除、更新语句，判断是否成功
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool useInsertDeleteSQL(string sql)
        {
            try
            {
                open();
                OleDbCommand cmd = new OleDbCommand();
                cmd = new OleDbCommand(sql, conn);
                if (cmd.ExecuteNonQuery() > 0)  //判断是否执行
                {
                    cmd.Parameters.Clear();
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// 执行查找语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public void useSelectSQL(string sql,ref OleDbDataAdapter inst)
        {
            open();
            inst = new OleDbDataAdapter(sql, conn);
        }

        /// <summary>
        /// 执行查询，返回结果
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="str"></param>
        public void useSelectSQL1(string sql,ref string str)
        {
            try
            {
                open();
                OleDbCommand cmd = new OleDbCommand();
                cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader =cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    reader.Read();
                    str = reader.GetValue(0).ToString();
                }
                else
                {
                    MessageBox.Show("查询不到此ID的书");
                }
                
                close();
            }
            catch (Exception)
            {
            }
        }

    }
}
