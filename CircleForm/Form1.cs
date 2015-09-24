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
            animatedControl1.SetMediator(circleMediator);
            animatedControl2.SetMediator(squareMediator);

            //Auto resize control
            AutoResizeAnimatedControls();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            AutoResizeAnimatedControls();
        }

        private void AutoResizeAnimatedControls()
        {
            //Size of two animated controls must always be = 1/2 of this control's client rectangle width
            int newWidth = this.ClientRectangle.Width / 2;
            animatedControl1.Width = newWidth;
            animatedControl1.Height = this.ClientRectangle.Height;
            animatedControl1.Location = new Point(0, 0);

            animatedControl2.Width = newWidth;
            animatedControl2.Height = this.ClientRectangle.Height;
            animatedControl2.Location = new Point(newWidth, 0);
        }
    }
}