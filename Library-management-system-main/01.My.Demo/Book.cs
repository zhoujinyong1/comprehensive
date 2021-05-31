using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.My.Demo
{
    class Book
    {
        #region 书本号、书名、作者、当前在架册数、馆藏册数、书本简介
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        private string a;

        public string A
        {
            get { return a; }
            set { a = value; }
        }
        private string b;

        public string B
        {
            get { return b; }
            set { b = value; }
        }
        private string c;

        public string C
        {
            get { return c; }
            set { c = value; }
        }
        #endregion

        public Book(string Id, string Name, string Author, string A, string B, string C)
        {
            this.id = Id;
            this.name = Name;
            this.author = Author;
            this.a = A;
            this.b = B;
            this.c = C;
        }


    }
}
