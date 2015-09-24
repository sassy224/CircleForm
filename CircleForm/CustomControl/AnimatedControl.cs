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

        public void SetTickInterval(int intervalInMillisecs)
        {
            tmTick.Interval = intervalInMillisecs;
        }

        private void AnimatedControl_Load(object sender, EventArgs e)
        {
            tmTick.Start();
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

        public void SetMediator(Mediator.IAnimatedMediator mediator)
        {
            this.ControlPaint += mediator.HandlePaintEvent;
            this.ControlResize += mediator.HandleResizeEvent;
            this.ControlTick += mediator.HandleTickEvent;
        }
    }
}