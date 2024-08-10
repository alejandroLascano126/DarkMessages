using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design.Serialization;

namespace DarkMessages.DesktopApp
{
    public class CreateGroupButton : Button
    {
        private int borderSize = 0;
        private int borderRadius = 25;
        private Color borderColor = Color.Blue;

        //private string title;
        //private string description;

        //public string Title
        //{
        //    get { return title; }
        //    set { title = value; Invalidate(); }
        //}

        //public string Description
        //{
        //    get { return description; }
        //    set { description = value; Invalidate(); }
        //}

        public CreateGroupButton() 
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150,50);
            this.BackColor = SystemColors.GradientActiveCaption;
            this.ForeColor = Color.White;
        }


        private GraphicsPath GetFigurePath(RectangleF rect, float radius) 
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height-radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent) 
        {
            
            

            base.OnPaint(pevent);

            //Graphics g = pevent.Graphics;

            //TextRenderer.DrawText(
            //    g,title,new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular),new Point(5, 5),ForeColor,TextFormatFlags.Left);

            //TextRenderer.DrawText(
            //    g,description,new Font(FontFamily.GenericSansSerif, 7, FontStyle.Regular),new Point(5, 25),ForeColor, TextFormatFlags.RightToLeft);


            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1,1,this.Width-0.8F,this.Height-1);

            if (borderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - 1F))
                using (Pen penSurface = new Pen(this.Parent!.BackColor, 2))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    this.Region = new Region(pathSurface);
                    pevent.Graphics.DrawPath(penSurface, pathSurface);
                    if (borderSize >= 1) 
                    {
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else 
            {
                Region = new Region(rectSurface);
                if(borderSize >= 1) 
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize)) 
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);

                    }
                }
            
            }
        }

        protected override void OnHandleCreated(EventArgs e) 
        {
            base.OnHandleCreated(e);
            Parent!.BackColorChanged += Parent_BackColorChanged;
        
        }

        private void Parent_BackColorChanged(object? sender, EventArgs e)
        {
            if(this.DesignMode)
                this.Invalidate();
        }
    }
}
