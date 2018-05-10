using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Core;
using Powerpoint = Microsoft.Office.Interop.PowerPoint;

namespace ScreenCapturer
{
    

    class pptfile
    { 
        private string directorypathway;
        Powerpoint.Application newapp;
        Powerpoint.Presentation newpres;
        Powerpoint.Slides newslides;
        Powerpoint.Slide newslide;
        Powerpoint.CustomLayout newcustomlayout;

        public pptfile(string pathway)
        {
            newapp = new Powerpoint.Application();
            newpres = newapp.Presentations.Add(MsoTriState.msoTrue);
            newslides = newpres.Slides;
            directorypathway = pathway;
            newcustomlayout = newpres.SlideMaster.CustomLayouts[7];
            
            createslides();
        }

        private void createslides()
        {
            Powerpoint.Slides newslides = newpres.Slides;
            string filename;

            Bitmap tempimage = new Bitmap(directorypathway + "\\1.jpg");

            float outputwidth;
            float outputheight;

            float ratio = tempimage.Width*1f / tempimage.Height*1f;
            if (newpres.PageSetup.SlideHeight * ratio > newpres.PageSetup.SlideWidth)
            {
                outputwidth = newpres.PageSetup.SlideWidth - 10;
                outputheight = outputwidth / ratio;
            }

            else
            {
                outputheight = newpres.PageSetup.SlideHeight - 10;
                outputwidth = outputheight * ratio;
                
            }
          

            for (int i = System.IO.Directory.GetFiles(directorypathway).Length; i >= 1; i--)
            {
                filename = directorypathway + "\\" + i.ToString() + ".jpg";
                newslide = newslides.AddSlide(1, newcustomlayout);
                newslide.Background.Fill.Background();
                newslide.FollowMasterBackground = MsoTriState.msoFalse;
                newslide.Background.Fill.ForeColor.RGB = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);             
                newslide.Shapes.AddPicture(filename, MsoTriState.msoFalse, MsoTriState.msoTrue, newpres.PageSetup.SlideWidth * .5f - outputwidth * .5f, newpres.PageSetup.SlideHeight * .5f - outputheight * .5f, outputwidth, outputheight);
            }
            string nametosave = directorypathway + "\\images";
            newpres.SaveAs(nametosave, Powerpoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoFalse);
          //  newpres.Close();
          //  newapp.Quit();
        }
    }

}
