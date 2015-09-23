using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircleForm.Mediator
{
    public interface IAnimatedMediator
    {
        /// <summary>
        /// Interface method to handle tick event of animated control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HandleTickEvent(object sender, EventArgs e);

        /// <summary>
        /// Interface method to handle paint event of animated control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HandlePaintEvent(object sender, PaintEventArgs e);

        /// <summary>
        /// Interface method to handle resize event of animated control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HandleResizeEvent(object sender, EventArgs e);
    }
}