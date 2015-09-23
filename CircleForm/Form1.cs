using CircleForm.Mediator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircleForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Enable double buffered
            this.DoubleBuffered = true;

            //Init mediator
            IAnimatedMediator circleMediator = new CircleMediator(animatedControl1);
            IAnimatedMediator squareMediator = new SquareMediator(animatedControl2);

            //Delegate event handlers to mediators
            animatedControl1.ControlPaint += circleMediator.HandlePaintEvent;
            animatedControl1.ControlResize += circleMediator.HandleResizeEvent;
            animatedControl1.ControlTick += circleMediator.HandleTickEvent;

            animatedControl2.ControlPaint += squareMediator.HandlePaintEvent;
            animatedControl2.ControlResize += squareMediator.HandleResizeEvent;
            animatedControl2.ControlTick += squareMediator.HandleTickEvent;
        }
    }
}