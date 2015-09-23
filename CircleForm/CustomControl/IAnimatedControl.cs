using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircleForm.CustomControl
{
    public interface IAnimatedControl
    {
        //Event fires when control needs to be painted
        event PaintEventHandler ControlPaint;
        //Event fires when control is resized
        event EventHandler ControlResize;
        //Event fires when the timer of control ticks
        event EventHandler ControlTick;

        /// <summary>
        /// Interface method to set tick interval for timer control
        /// </summary>
        /// <param name="intervalInMillisecs">Interval in milliseconds</param>
        void SetTickInterval(int intervalInMillisecs);

        /// <summary>
        /// Interface method to force the control to update. This will be implemented by Form class's implementation
        /// </summary>
        void Invalidate();

        /// <summary>
        /// Interface method to get the height of the client area of the control
        /// </summary>
        /// <returns></returns>
        int GetClientRectangleHeight();

        /// <summary>
        /// Interface method to get the width of the client area of the control
        /// </summary>
        /// <returns></returns>
        int GetClientRectangleWidth();
    }
}