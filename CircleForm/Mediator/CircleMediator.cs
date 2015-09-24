using CircleForm.CustomControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircleForm.Mediator
{
    public class CircleMediator : IAnimatedMediator
    {
        private const int INIT_RADIUS = 50;
        private const int STEP = 20;
        private IAnimatedControl _control = null;
        private int currentRadius = 50;
        private int previousRadius = 40;
        private Brush currentBrush = null;
        private bool isShrinking = false;

        public CircleMediator(IAnimatedControl control)
        {
            _control = control;
            _control.SetTickInterval(100);
        }

        public void HandleTickEvent(object sender, EventArgs e)
        {
            //Everytime the timer ticks, change the radius of the circle
            if (isShrinking)
                currentRadius -= STEP;
            else
                currentRadius += STEP;

            //If the radius is >= any side of the control, change direction
            if (currentRadius >= _control.GetClientRectangleWidth() || currentRadius >= _control.GetClientRectangleHeight())
                isShrinking = true;
            else if (currentRadius <= INIT_RADIUS)
                isShrinking = false;

            //Force the control to redraw
            _control.Invalidate();
        }

        public void HandlePaintEvent(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Point topLeft = new Point()
            {
                X = (_control.GetClientRectangleWidth() - currentRadius) / 2,
                Y = (_control.GetClientRectangleHeight() - currentRadius) / 2
            };

            Point bottomRight = new Point()
            {
                X = (_control.GetClientRectangleWidth() + currentRadius) / 2,
                Y = (_control.GetClientRectangleHeight() + currentRadius) / 2
            };

            //Only update brush if previousRadius != currentRadius. When control is resized, keep the current brush if tick event hasn't happened yet
            if (previousRadius != currentRadius)
            {
                if (currentBrush == null)
                    currentBrush = new HatchBrush(HatchStyle.Percent90, Color.Red);
                else if (currentBrush is HatchBrush)
                {
                    currentBrush.Dispose();
                    currentBrush = new LinearGradientBrush(topLeft, bottomRight, Color.Green, Color.GreenYellow);
                }
                else if (currentBrush is LinearGradientBrush)
                {
                    // Create the path (which determines the shape of the gradient).
                    GraphicsPath path = new GraphicsPath();
                    path.AddEllipse(topLeft.X, topLeft.Y, currentRadius, currentRadius);

                    currentBrush.Dispose();
                    currentBrush = new PathGradientBrush(path);
                    ((PathGradientBrush)currentBrush).WrapMode = WrapMode.Tile;
                    ((PathGradientBrush)currentBrush).SurroundColors = new Color[] { Color.White };
                    ((PathGradientBrush)currentBrush).CenterColor = Color.Blue;

                    path.Dispose();
                }
                else
                {
                    currentBrush.Dispose();
                    currentBrush = new HatchBrush(HatchStyle.Percent90, Color.Red);
                }
            }

            Pen drawingPen = new Pen(Color.Black, 2);

            g.DrawEllipse(drawingPen, topLeft.X, topLeft.Y, currentRadius, currentRadius);
            g.FillEllipse(currentBrush, topLeft.X, topLeft.Y, currentRadius, currentRadius);
            //Free memory
            drawingPen.Dispose();

            //Update previousRadius
            previousRadius = currentRadius;
        }

        public void HandleResizeEvent(object sender, EventArgs e)
        {
            _control.Invalidate();
        }
    }
}