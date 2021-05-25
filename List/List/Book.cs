using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Book
    {
        private int id;
        private string name;
        private string author;
        private int num;
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Author { get => author; set => author = value; }
        public int Num { get => num; set => num = value; }
        public Book(int Id,string Name,string Author,int Num)
        {
            this.id = Id;
            this.name = Name;
            this.author = Author;
            this.num = Num;
        }

       
    }
}
