using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace List
{
    public partial class Form1 : Form
    {

        List<Book> books = new List<Book>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Book book = new Book(0,"向上生长","九边",3);
            books.Add(book);
            Book book1 = new Book(1, "白夜行", "东野圭吾", 5);
            books.Add(book1);
            Book book2 = new Book(2, "查拉图斯特拉如是说", "尼采", 8);
            books.Add(book2);
            Book book3 = new Book(3, "追风筝的人", "卡勒德·胡赛尼", 6);
            books.Add(book3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i=0;i<books.Count;i++)
            { 
                listBox1.Items.Add(books[i].Id +"---"+ books[i].Name + "---"+ books[i].Author + "---"+ books[i].Num);
            }
            
        }
    }
}
