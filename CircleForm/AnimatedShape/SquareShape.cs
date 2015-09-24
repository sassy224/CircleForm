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
    public class SquareShape : IAnimatedShape
    {
        private IAnimatedControl _control = null;
        private int _currentLength = 50;
        private int _previousLength = 0;
        private Brush _currentBrush = null;
        private bool _isShrinking = true;

        public SquareShape(IAnimatedControl control)
        {
            _control = control;
            _currentLength = _control.InitSize;
            //Workaround to set length to 1 if it's set to 0
            if (_currentLength == 0)
                _currentLength = 1;
            _isShrinking = !_control.IsGrowFirst;
        }

        public void HandleTickEvent(object sender, EventArgs e)
        {
            //Everytime the timer ticks, change the length of the square
            if (_isShrinking)
                _currentLength -= _control.StepSize;
            else
                _currentLength += _control.StepSize;

            //If the length reaches min value, change the direction
            if (_currentLength <= _control.MinSize)
            {
                if (_control.AutoChangeDirection)
                {
                    _isShrinking = false;
                    _currentLength += _control.StepSize;
                }
                else
                {
                    //No auto change direction, once it reaches the min value, reset it to the max value
                    _currentLength = _control.MaxSize;
                }
            }
            else if (_currentLength >= _control.MaxSize)
            {
                if (_control.AutoChangeDirection)
                    _isShrinking = true;
                else
                    //No auto change direction, once it reaches the max value, reset it to the min value
                    _currentLength = _control.MinSize;
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
                X = (_control.GetClientRectangleWidth() - _currentLength) / 2,
                Y = (_control.GetClientRectangleHeight() - _currentLength) / 2
            };

            Point bottomRight = new Point()
            {
                X = (_control.GetClientRectangleWidth() + _currentLength) / 2,
                Y = (_control.GetClientRectangleHeight() + _currentLength) / 2
            };

            //Only update brush if previousLength != currentLength. When control is resized, keep the current brush if tick event hasn't happened yet
            if (_previousLength != _currentLength)
            {
                if (_currentBrush == null)
                    _currentBrush = new HatchBrush(HatchStyle.Percent90, Color.Red);
                else if (_currentBrush is HatchBrush)
                {
                    _currentBrush.Dispose();
                    _currentBrush = new LinearGradientBrush(topLeft, bottomRight, Color.Green, Color.GreenYellow);
                }
                else if (_currentBrush is LinearGradientBrush)
                {
                    // Create the path (which determines the shape of the gradient).
                    GraphicsPath path = new GraphicsPath();
                    path.AddRectangle(new Rectangle(topLeft.X, bottomRight.Y, _currentLength, _currentLength));

                    _currentBrush.Dispose();
                    _currentBrush = new PathGradientBrush(path);
                    ((PathGradientBrush)_currentBrush).WrapMode = WrapMode.Tile;
                    ((PathGradientBrush)_currentBrush).SurroundColors = new Color[] { Color.White };
                    ((PathGradientBrush)_currentBrush).CenterColor = Color.Blue;

                    path.Dispose();
                }
                else
                {
                    _currentBrush.Dispose();
                    _currentBrush = new HatchBrush(HatchStyle.Percent90, Color.Red);
                }
            }

            Pen drawingPen = new Pen(Color.Black, 2);

            g.DrawRectangle(drawingPen, topLeft.X, topLeft.Y, _currentLength, _currentLength);
            g.FillRectangle(_currentBrush, topLeft.X, topLeft.Y, _currentLength, _currentLength);
            //Free memory
            drawingPen.Dispose();

            //Update previousLength
            _previousLength = _currentLength;
        }

        public void HandleResizeEvent(object sender, EventArgs e)
        {
            _control.Invalidate();
        }
    }
}