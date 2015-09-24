using CircleForm.CustomControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircleForm.AnimatedShape
{
    public class CircleShape : IAnimatedShape
    {
        private IAnimatedControl _control = null;
        private int _currentRadius = 50;
        private int _previousRadius = 40;
        private Brush currentBrush = null;
        private bool _isShrinking = false;

        public CircleShape(IAnimatedControl control)
        {
            _control = control;
            _currentRadius = _control.InitSize;
            //Workaround to set length to 1 if it's set to 0
            if (_currentRadius == 0)
                _currentRadius = 1;
            _isShrinking = !_control.IsGrowFirst;
        }

        public void HandleTickEvent(object sender, EventArgs e)
        {
            //Everytime the timer ticks, change the length of the square
            if (_isShrinking)
                _currentRadius -= _control.StepSize;
            else
                _currentRadius += _control.StepSize;

            //If the length reaches min value, change the direction
            if (_currentRadius <= _control.MinSize)
            {
                if (_control.AutoChangeDirection)
                {
                    _isShrinking = false;
                    _currentRadius += _control.StepSize;
                }
                else
                {
                    //No auto change direction, once it reaches the min value, reset it to the max value
                    _currentRadius = _control.MaxSize;
                }
            }
            else if (_currentRadius >= _control.MaxSize)
            {
                if (_control.AutoChangeDirection)
                    _isShrinking = true;
                else
                    //No auto change direction, once it reaches the max value, reset it to the min value
                    _currentRadius = _control.MinSize;
            }

            //Force the control to redraw
            _control.Invalidate();
        }

        public void HandlePaintEvent(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Point topLeft = new Point()
            {
                X = (_control.GetClientRectangleWidth() - _currentRadius) / 2,
                Y = (_control.GetClientRectangleHeight() - _currentRadius) / 2
            };

            Point bottomRight = new Point()
            {
                X = (_control.GetClientRectangleWidth() + _currentRadius) / 2,
                Y = (_control.GetClientRectangleHeight() + _currentRadius) / 2
            };

            //Only update brush if previousRadius != currentRadius. When control is resized, keep the current brush if tick event hasn't happened yet
            if (_previousRadius != _currentRadius)
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
                    path.AddEllipse(topLeft.X, topLeft.Y, _currentRadius, _currentRadius);

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

            g.DrawEllipse(drawingPen, topLeft.X, topLeft.Y, _currentRadius, _currentRadius);
            g.FillEllipse(currentBrush, topLeft.X, topLeft.Y, _currentRadius, _currentRadius);
            //Free memory
            drawingPen.Dispose();

            //Update previousRadius
            _previousRadius = _currentRadius;
        }

        public void HandleResizeEvent(object sender, EventArgs e)
        {
            _control.Invalidate();
        }
    }
}