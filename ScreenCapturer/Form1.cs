using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gma.UserActivityMonitor;
using System.Runtime.InteropServices;


namespace ScreenCapturer
{
    public partial class Form1 : Form
    {
        public int topleftpoint_x;
        public int topleftpoint_y;
        public int bottomrightpoint_x;
        public int bottomrightpoint_y;
        public int imagenumber;
        public int acquirebuttonpressed;
        public string path;
        Form3 thirdform;
        List <Rectangle> listofrectangles;
       
    
        public Form1()
        {
            InitializeComponent();
            this.acquire_Button.Text = "Select Areas";
            this.label1.Visible = false;
            acquirebuttonpressed = 0;
           
            listofrectangles = new List<Rectangle>();
            path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\screencaptureoutput";
            System.IO.Directory.CreateDirectory(path);

            imagenumber = System.IO.Directory.GetFiles(path).Length;
 //           imageList1.Images.Clear();
//            this.linkLabel1.Visible = false;
            this.Show();
        }

        private void acquire_Button_Click(object sender, EventArgs e)
        {
            if (acquirebuttonpressed == 0)
            {
                //this.Activate();
                thirdform = new Form3(this);
                this.generateppt_Button.Visible = false;
     
                
                acquirebuttonpressed = 1;
                this.acquire_Button.Text = "Take images";

                thirdform.Show();
               // thirdform.FormBorderStyle = FormBorderStyle.None;
               // thirdform.TopMost = true;
                thirdform.WindowState = FormWindowState.Maximized;
                thirdform.Opacity = 0.2;
            }

            else if (acquirebuttonpressed == 1)
            {
                this.BringToFront();
                this.acquire_Button.Text = "Done";
                acquirebuttonpressed = 2;
                thirdform.Opacity = 0.0;
                this.label1.Visible = true;
                this.label1.Text = "press s to snap";
                globalEventProvider1.KeyDown += globalEventProvider1_KeyDown;
            }

            else if (acquirebuttonpressed == 2)
            {
                this.BringToFront();
                globalEventProvider1.KeyDown -= globalEventProvider1_KeyDown;

                imagenumber = System.IO.Directory.GetFiles(path).Length;

                this.acquire_Button.Text = "Select areas";
                this.generateppt_Button.Visible = true;
                acquirebuttonpressed = 0;
                this.label1.Visible = false;
            }
        }
      

        void globalEventProvider1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 83) 
            {
            imagenumber = imagenumber + 1;
            Image img = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics bg = Graphics.FromImage(img);
            bg.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

            Bitmap cropimg = combineimages(img, thirdform.listofrectangles);
            img.Dispose();

            cropimg.Save(path + "\\" + imagenumber.ToString() + ".jpg");
            //imageList1.Images.Add(cropimg);
            this.label1.Visible = true;
            this.label1.Text = imagenumber.ToString();
            this.Show();
           
            }
        }

       
        private Bitmap combineimages(Image originalimage, List<Rectangle> listofrectangles)
        {
            Bitmap tempimg;
            Bitmap combinedimage_1;
            Graphics j;
            Graphics h;
            Bitmap combinedimage = new Bitmap(originalimage, thirdform.listofrectangles[0].Width, thirdform.listofrectangles[0].Height);
            Graphics g = Graphics.FromImage(combinedimage);
            g.DrawImage(originalimage, -thirdform.listofrectangles[0].X, -thirdform.listofrectangles[0].Y);
            for (int i = 1; i < listofrectangles.Count; i++)
            {
                tempimg = new Bitmap(originalimage, thirdform.listofrectangles[i].Width, thirdform.listofrectangles[i].Height);
                h = Graphics.FromImage(tempimg);
                h.DrawImage(originalimage, -thirdform.listofrectangles[i].X, -thirdform.listofrectangles[i].Y);
               
                int width = combinedimage.Width + tempimg.Width;
                int height = Math.Max(combinedimage.Height, tempimg.Height);
                combinedimage_1 = new Bitmap(width, height);
                j = Graphics.FromImage(combinedimage_1);
                j.Clear(Color.Black);
                j.DrawImage(combinedimage, new Point(0, 0));
                j.DrawImage(tempimg, new Point(combinedimage.Width, 0));
               
                combinedimage = combinedimage_1;
                //tempimg.Dispose();
                //combinedimage_1.Dispose();
                //
               
            }
            return combinedimage;
            g.Dispose();
            h.Dispose();
            j.Dispose();
            combinedimage_1.Dispose();
            tempimg.Dispose();
        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Created by GDR");
        }

        private void generateppt_Button_Click(object sender, EventArgs e)
        {
            pptfile mypptfile = new pptfile(path);
            imagenumber = 0;
        }
      
    }
}
