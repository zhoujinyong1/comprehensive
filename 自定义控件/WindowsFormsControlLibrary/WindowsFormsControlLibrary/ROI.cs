using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary
{
    public partial class ROI: UserControl
    {
        List<Coordinate> list =new List<Coordinate>();
        public int num = 0;
        bool isdown = false;
        int px;
        int py;
        int px2;
        int py2;

        public ROI()
        {
            InitializeComponent();
        }

        #region   自定义属性
        /// <summary>
        /// 形状选取的值
        /// </summary>
        private string graphicalnum = "1";
        [Description("修改此值，选择绘制图形"), Category("自定义属性")]
        public string Graphicalnum 
        { 
            get
            {
                return graphicalnum;
            }
            set
            {
                graphicalnum = value;
            }
        }


        /// <summary>
        /// 0:直线、1:矩形、2:椭圆、3:扇形、4:圆弧、5:多边形
        /// </summary>
        private string graphical = "";
        [Description("绘制图形"), Category("自定义属性")]
        public string Graphical
        {
            get
            {
                switch (graphicalnum)
                {
                    case "0": return "直线";
                    case "1": return "矩形";
                    case "2": return "椭圆";
                    case "3": return "扇形";
                    case "4": return "圆弧";
                    case "5": return "多边形";
                }
                return "直线";
            }
            set
            {
                graphical = value;
            }
        }


        /// <summary>
        /// 线条粗细
        /// </summary>
        private string lineThickness  = "3";
        [Description("线条粗细"), Category("自定义属性")]
        public string LineThickness
        {
            get
            {
                return lineThickness;
            }
            set
            {
                lineThickness = value;
            }
        }


        /// <summary>
        /// 线条颜色
        /// </summary>
        private Color lineColor = Color.Red;
        [Description("线条颜色"), Category("自定义属性")]
        public Color LineColor
        {
            get
            {
                return lineColor;
            }
            set
            {
                lineColor = value;
            }
        }

        /// <summary>
        /// 图片
        /// </summary>
        private Image img;
        [Description("图片"), Category("自定义属性")]
        public Image Img
        {
            get
            {
                return img;
            }
            set
            {
                img = value;
            }
        }
        #endregion

        #region   自定义事件
        private void UserControl1_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                isdown = true;
                px = e.X;
                py = e.Y;
            }
            else
            {
                Application.Exit();
            }

        }

        private void UserControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isdown)
            {
                
            }
        }

        private void UserControl1_MouseUp(object sender, MouseEventArgs e)
        {
            isdown = false;
            Coordinate coordinate = new Coordinate(int.Parse(graphicalnum), e.X, e.Y);

            px2 = e.X;
            py2 = e.Y;
            //绘制图形
            Graphics graphics = this.CreateGraphics();
            Pen pen = new Pen(lineColor, float.Parse(lineThickness));

            if (this.graphicalnum.Equals("0")) //直线
            {
                Application.Idle += new EventHandler(set);
                graphics.DrawLine(pen, float.Parse(px.ToString()), float.Parse(py.ToString()), float.Parse((px2).ToString()), float.Parse((py2).ToString()));
            }
            else if (this.graphicalnum.Equals("1"))  //矩形
            {
                Application.Idle += new EventHandler(set);
                graphics.DrawRectangle(pen, float.Parse(px.ToString()), float.Parse(py.ToString()), float.Parse((px2 - px).ToString()), float.Parse((py2 - py).ToString()));
            }
            else if (this.graphicalnum.Equals("2")) //椭圆
            {
                Application.Idle += new EventHandler(set);
                graphics.DrawEllipse(pen, float.Parse(px.ToString()), float.Parse(py.ToString()), float.Parse((px2 - px).ToString()), float.Parse((py2 - py).ToString()));
            }
            else if (this.graphicalnum.Equals("3")) //扇形
            {
            }
            else if (this.graphicalnum.Equals("4")) //圆弧
            {

            }
            else if (this.graphicalnum.Equals("5")) //多边形
            {

            }
        }
        #endregion

        private void ROI_Load(object sender, EventArgs e)
        {
            Application.Idle += new EventHandler(set);     
        }

        private void set(object sender, EventArgs e)
        {
            BackgroundImage = img;
        }
    }
}
