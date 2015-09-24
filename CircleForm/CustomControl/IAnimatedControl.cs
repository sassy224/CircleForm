using CircleForm.AnimatedShape;
using CircleForm.Enums;
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

        /// <summary>
        /// Interace method to start the timer of the control
        /// </summary>
        void StartAnimation();

        /// <summary>
        /// Interface method to set a custom shape for the control
        /// </summary>
        /// <param name="customShape"></param>
        void SetCustomShape(IAnimatedShape customShape);

        /// <summary>
        /// Set built-in shape of the control
        /// </summary>
        AnimatedShapes Shape { get; set; }

        /// <summary>
        /// The initial size of the shape
        /// </summary>
        int InitSize { get; set; }

        /// <summary>
        /// The grow/shrink speed of the shape
        /// </summary>
        int StepSize { get; set; }

        /// <summary>
        /// The maximum size of the shape
        /// </summary>
        int MaxSize { get; set; }

        /// <summary>
        /// The minimum size of the shape
        /// </summary>
        int MinSize { get; set; }

        /// <summary>
        /// Determine whether the shape auto changes direction when reaches boundaries
        /// </summary>
        bool AutoChangeDirection { get; set; }

        /// <summary>
        /// Determine whether the shape should grow or shrink first
        /// </summary>
        bool IsGrowFirst { get; set; }

        /// <summary>
        /// Set the interval in milliseconds between frames
        /// </summary>
        int TickInterval { get; set; }
    }
}