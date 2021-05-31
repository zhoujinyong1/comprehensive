using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01.My.Demo
{
    public partial class Form1 : Form
    {
        string sql;
        public Form1()
        {
            InitializeComponent();
        } 


        //书架
        List<List<string>> i=new List<List<string>>();
        //书
        List<Book> l = new List<Book>();
        Book book;

        /// <summary>
        /// 确定上架
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" & textBox4.Text != "" & textBox5.Text != "" & textBox6.Text != ""  & textBox7.Text != "")
            {
                try
                {
                    Database database = new Database();
                    sql = string.Format("insert into Book(Bookname, Author, Num, Allnum, Content) values('{0}','{1}','{2}','{3}','{4}')"
                        , textBox3.Text, textBox4.Text, int.Parse(textBox5.Text), int.Parse(textBox6.Text), textBox7.Text
                        );
                    if (database.useInsertDeleteSQL(sql))
                    {
                        MessageBox.Show("添加成功");
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("添加失败");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("当前在架册数、馆藏册数只能是数字");
                }

            }
            else
            {
                MessageBox.Show("输入值为空");
            }
        }
        /// <summary>
        /// 取消上架
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        /// <summary>
        /// 确定下架
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text =="")
            {
                MessageBox.Show("请输入要下架的书号");
            }
            else
            {
                Database database = new Database();
                sql = string.Format("delete from Book where ID = {0}", int.Parse(textBox2.Text));
                if (database.useInsertDeleteSQL(sql))
                {
                    MessageBox.Show("下架成功");
                }
                else
                {
                    MessageBox.Show("下架失败");
                }
            }
        }

        /// <summary>
        /// 下架书本查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                dataGridView1.Visible = true;
                sql = "select * from Book";
                Database database = new Database();
                OleDbDataAdapter inst = new OleDbDataAdapter();
                database.useSelectSQL(sql, ref inst);
                DataTable dt = new DataTable();
                inst.Fill(dt);
                dataGridView2.DataSource = dt.DefaultView;
                database.close();
            }
            else
            {
                dataGridView1.Visible = true;
                sql = string.Format("select * from Book where ID = {0}", int.Parse(textBox2.Text.ToString()));
                Database database = new Database();
                OleDbDataAdapter inst = new OleDbDataAdapter();
                database.useSelectSQL(sql, ref inst);
                DataTable dt = new DataTable();
                inst.Fill(dt);
                dataGridView2.DataSource = dt.DefaultView;
                database.close();
            }
        }

        /// <summary>
        /// 查找图书-查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                dataGridView1.Visible = true;
                sql = "select * from Book";
                Database database = new Database();
                OleDbDataAdapter inst = new OleDbDataAdapter();
                database.useSelectSQL(sql,ref inst);
                DataTable dt = new DataTable();
                inst.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
                database.close();
            }
            else
            {
                dataGridView1.Visible = true;
                sql = string.Format( "select * from Book where ID = {0}",int.Parse(textBox8.Text.ToString()));
                Database database = new Database();
                OleDbDataAdapter inst = new OleDbDataAdapter();
                database.useSelectSQL(sql, ref inst);
                DataTable dt = new DataTable();
                inst.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
                database.close();
            }
        }

        /// <summary>
        /// 图书归还-查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                dataGridView1.Visible = true;
                sql = "select * from Book";
                Database database = new Database();
                OleDbDataAdapter inst = new OleDbDataAdapter();
                database.useSelectSQL(sql, ref inst);
                DataTable dt = new DataTable();
                inst.Fill(dt);
                dataGridView4.DataSource = dt.DefaultView;
                database.close();
            }
            else
            {
                dataGridView1.Visible = true;
                sql = string.Format("select * from Book where ID = {0}", int.Parse(textBox9.Text.ToString()));
                Database database = new Database();
                OleDbDataAdapter inst = new OleDbDataAdapter();
                database.useSelectSQL(sql, ref inst);
                DataTable dt = new DataTable();
                inst.Fill(dt);
                dataGridView4.DataSource = dt.DefaultView;
                database.close();
            }
        }

        /// <summary>
        /// 图书归还-确认归还
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                MessageBox.Show("请输入要归还的书号");
            }
            else
            {
                Database database = new Database();
                string str = "";
                sql = string.Format("select Allnum from Book where ID ={0}", textBox9.Text);
                database.useSelectSQL1(sql, ref str);
                if (str != "")
                {
                    sql = string.Format("update Book set Allnum ={0} where ID ={1}", int.Parse(str) + 1, int.Parse(textBox9.Text));
                    if (database.useInsertDeleteSQL(sql))
                    {
                        MessageBox.Show("归还成功");
                    }
                    else
                    {
                        MessageBox.Show("归还失败");
                    }
                }
            }
        }

        /// <summary>
        /// 图书出借-查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                dataGridView1.Visible = true;
                sql = "select * from Book";
                Database database = new Database();
                OleDbDataAdapter inst = new OleDbDataAdapter();
                database.useSelectSQL(sql, ref inst);
                DataTable dt = new DataTable();
                inst.Fill(dt);
                dataGridView3.DataSource = dt.DefaultView;
                database.close();
            }
            else
            {
                dataGridView1.Visible = true;
                sql = string.Format("select * from Book where ID = {0}", int.Parse(textBox10.Text.ToString()));
                Database database = new Database();
                OleDbDataAdapter inst = new OleDbDataAdapter();
                database.useSelectSQL(sql, ref inst);
                DataTable dt = new DataTable();
                inst.Fill(dt);
                dataGridView3.DataSource = dt.DefaultView;
                database.close();
            }

        }

        /// <summary>
        /// 确认出借
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            if(textBox10.Text =="")
            {
                MessageBox.Show("请输入要出借的书号");
            }
            else
            {
                Database database = new Database();
                string str = "";
                sql = string.Format("select Num from Book where ID ={0}", textBox10.Text);
                database.useSelectSQL1(sql, ref str);
                if(str != "")
                {
                    sql = string.Format("update Book set Num ={0} where ID ={1}", int.Parse(str) - 1, int.Parse(textBox10.Text));
                    if (database.useInsertDeleteSQL(sql))
                    {
                        MessageBox.Show("出借成功");
                    }
                    else
                    {
                        MessageBox.Show("出借失败");
                    }
                }
            }  
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            // sql = "insert into Book(Bookname, Author, Num, Allnum, Content) values('向上生长','九边','12','12','励志')";
            // sql = "select Bookname, Author, Num, Allnum, Content from Book";
            // sql = "update Book set Num =10, Allnum=10 where ID =2";
            //  sql = "delete from Book where ID =2";
            if (database.useInsertDeleteSQL(sql))
            {
                MessageBox.Show("添加成功");
            }
            else
            {
                MessageBox.Show("添加失败");
            }

        }
    }
}
