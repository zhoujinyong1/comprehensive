using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsControlLibrary
{
    class Coordinate
    {
        private int id;
        private int x;   
        private int y;
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Id { get => id; set => id = value; }

        /// <summary>
        /// 坐标
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public Coordinate(int id,int X,int Y)
        {
            this.id = Id;
            this.x = X;
            this.y = Y;
        }
    }
}
