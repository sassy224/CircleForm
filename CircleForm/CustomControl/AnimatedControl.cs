using CircleForm.AnimatedShape;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircleForm.CustomControl
{
    public partial class AnimatedControl : UserControl, IAnimatedControl
    {
        public AnimatedControl()
        {
            InitializeComponent();
        }

        public event PaintEventHandler ControlPaint;

        public event EventHandler ControlResize;

        public event EventHandler ControlTick;

        public void TickInterval(int intervalInMillisecs)
        {
            tmTick.Interval = intervalInMillisecs;
        }

        private void AnimatedControl_Load(object sender, EventArgs e)
        {
        }

        private void AnimatedControl_Resize(object sender, EventArgs e)
        {
            if (ControlResize != null)
            {
                ControlResize(sender, e);
            }
        }

        private void tmTick_Tick(object sender, EventArgs e)
        {
            if (ControlTick != null)
            {
                ControlTick(sender, e);
            }
        }

        private void AnimatedControl_Paint(object sender, PaintEventArgs e)
        {
            if (ControlPaint != null)
            {
                ControlPaint(sender, e);
            }
        }

        public int GetClientRectangleHeight()
        {
            return this.ClientRectangle.Height;
        }

        public int GetClientRectangleWidth()
        {
            return this.ClientRectangle.Width;
        }

        private IAnimatedShape _mediator;

        public void SetCustomShape(IAnimatedShape mediator)
        {
            _mediator = mediator;
            this.ControlPaint += _mediator.HandlePaintEvent;
            this.ControlResize += _mediator.HandleResizeEvent;
            this.ControlTick += _mediator.HandleTickEvent;
        }

        public void StartAnimation()
        {
            tmTick.Start();
        }

        private Enums.AnimatedShapes _shape;

        [Description("The shape that will be animated. Choose custom if you want to provide your own shape")]
        public Enums.AnimatedShapes Shape
        {
            get
            {
                return _shape;
            }
            set
            {
                _shape = value;
                if (_shape == Enums.AnimatedShapes.Circle)
                {
                    this.SetCustomShape(new CircleShape(this));
                }
                else if (_shape == Enums.AnimatedShapes.Square)
                {
                    this.SetCustomShape(new SquareShape(this));
                }
            }
        }

        private int _initSize = 10;

        [Description("The inital width/height of the shape. They are always of the same size")]
        [Category("Behavior")]
        public int InitSize
        {
            get
            {
                return _initSize;
            }
            set
            {
                _initSize = value;
            }
        }

        private int _stepSize = 10;

        [Description("The grow/shrink speed of the shape")]
        [Category("Behavior")]
        public int StepSize
        {
            get
            {
                return _stepSize;
            }
            set
            {
                _stepSize = value;
            }
        }

        private bool _autoChangeDirection = false;

        [Description("Determine whether the shape should auto change direction when reach boundaries")]
        [Category("Behavior")]
        public bool AutoChangeDirection
        {
            get
            {
                return _autoChangeDirection;
            }
            set
            {
                _autoChangeDirection = value;
            }
        }

        private bool _isGrowFirst = false;

        [Description("Determine whether the shape should grow or shrink first")]
        [Category("Behavior")]
        public bool IsGrowFirst
        {
            get
            {
                return _isGrowFirst;
            }
            set
            {
                _isGrowFirst = value;
            }
        }

        private int _maxSize = 100;

        [Description("The maximum size of the shape")]
        [Category("Behavior")]
        public int MaxSize
        {
            get
            {
                return _maxSize;
            }
            set
            {
                _maxSize = value;
            }
        }

        private int _minSize = 0;

        [Description("The minimum size of the shape")]
        [Category("Behavior")]
        public int MinSize
        {
            get
            {
                return _minSize;
            }
            set
            {
                _minSize = value;
            }
        }

        [Description("The interval in milliseconds between frames")]
        [Category("Behavior")]
        int IAnimatedControl.TickInterval
        {
            get
            {
                return tmTick.Interval;
            }
            set
            {
                tmTick.Interval = value;
            }
        }
    }
}