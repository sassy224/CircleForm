namespace CircleForm.CustomControl
{
    partial class AnimatedControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmTick = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmTick
            // 
            this.tmTick.Tick += new System.EventHandler(this.tmTick_Tick);
            // 
            // AnimatedControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "AnimatedControl";
            this.Load += new System.EventHandler(this.AnimatedControl_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AnimatedControl_Paint);
            this.Resize += new System.EventHandler(this.AnimatedControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmTick;
    }
}
