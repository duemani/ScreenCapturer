using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenCapturer
{
    public partial class Form3 : Form
    {
        public int topleftpoint_x;
        public int topleftpoint_y;
        public int bottomrightpoint_x;
        public int bottomrightpoint_y;
        public List<Rectangle> listofrectangles;
        Form1 baseform;
        public bool mousehasbeenpressed;

        public Form3(Form1 passedform)
        {
            InitializeComponent();
            globalEventProvider1.MouseDown += new MouseEventHandler(globalEventProvider1_MouseDown);
            globalEventProvider1.MouseUp += new MouseEventHandler(globalEventProvider1_MouseUp);
           
            listofrectangles = new List<Rectangle>();
            baseform = passedform;
            mousehasbeenpressed = false;
        }

        
        void globalEventProvider1_MouseUp(object sender, MouseEventArgs e)
        {
            mousehasbeenpressed = false;
            bottomrightpoint_x = e.X;
            bottomrightpoint_y = e.Y;
            Rectangle newrect = new Rectangle(topleftpoint_x, topleftpoint_y, bottomrightpoint_x - topleftpoint_x, bottomrightpoint_y - topleftpoint_y);
            if ((newrect.Width > 10) && (newrect.Height > 10))
            {
                listofrectangles.Add(newrect);
            }

            System.Drawing.Graphics formGraphics = this.CreateGraphics();

            System.Drawing.Pen mypen = new System.Drawing.Pen(System.Drawing.Color.Red);
            formGraphics.DrawRectangle(mypen, newrect);

            mypen.Dispose();
            formGraphics.Dispose();
            baseform.BringToFront();
        }

        void globalEventProvider1_MouseDown(object sender, MouseEventArgs e)
        {
           /* if (((e.X > baseform.Location.X) && (e.X < baseform.Location.X + baseform.Width)))
            {
                if (((e.Y > baseform.Location.Y) && (e.Y < baseform.Location.Y + baseform.Height)))
                {
                    
                }
            }
            else
            {*/
                topleftpoint_x = e.X;
                topleftpoint_y = e.Y;
                mousehasbeenpressed = true;
            //}
        }

        


    }
}
