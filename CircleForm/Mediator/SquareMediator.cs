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
    public class SquareMediator : IAnimatedMediator
    {
        private const int MIN_LENGTH = 50;
        private const int STEP = 20;
        private IAnimatedControl _control = null;
        private int currentLength = 50;
        private int previousLength = 40;
        private Brush currentBrush = null;
        private bool isShrinking = true;

        public SquareMediator(IAnimatedControl control)
        {
            _control = control;
            _control.SetTickInterval(100);
            currentLength = Math.Min(_control.GetClientRectangleWidth(), _control.GetClientRectangleHeight());
        }

        public void HandleTickEvent(object sender, EventArgs e)
        {
            //Everytime the timer ticks, change the length of the square
            if (isShrinking)
                currentLength -= STEP;
            else
                currentLength += STEP;

            //If the length reaches min value, change the direction
            if (currentLength <= MIN_LENGTH)
                isShrinking = false;
            else if (currentLength >= _control.GetClientRectangleWidth() || currentLength >= _control.GetClientRectangleHeight())
                isShrinking = true;

            //Force the control to redraw
            _control.Invalidate();
        }

        public void HandlePaintEvent(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Point topLeft = new Point()
            {
                X = (_control.GetClientRectangleWidth() - currentLength) / 2,
                Y = (_control.GetClientRectangleHeight() - currentLength) / 2
            };

            Point bottomRight = new Point()
            {
                X = (_control.GetClientRectangleWidth() + currentLength) / 2,
                Y = (_control.GetClientRectangleHeight() + currentLength) / 2
            };

            //Only update brush if previousLength != currentLength. When control is resized, keep the current brush if tick event hasn't happened yet
            if (previousLength != currentLength)
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
                    path.AddRectangle(new Rectangle(topLeft.X, bottomRight.Y, currentLength, currentLength));

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

            g.DrawRectangle(drawingPen, topLeft.X, topLeft.Y, currentLength, currentLength);
            g.FillRectangle(currentBrush, topLeft.X, topLeft.Y, currentLength, currentLength);
            //Free memory
            drawingPen.Dispose();

            //Update previousLength
            previousLength = currentLength;
        }

        public void HandleResizeEvent(object sender, EventArgs e)
        {
            _control.Invalidate();
        }
    }
}