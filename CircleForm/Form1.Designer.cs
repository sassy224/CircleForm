namespace CircleForm
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.animatedControl2 = new CircleForm.CustomControl.AnimatedControl();
            this.animatedControl1 = new CircleForm.CustomControl.AnimatedControl();
            this.SuspendLayout();
            // 
            // animatedControl2
            // 
            this.animatedControl2.AutoChangeDirection = true;
            this.animatedControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.animatedControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.animatedControl2.InitSize = 0;
            this.animatedControl2.IsGrowFirst = false;
            this.animatedControl2.Location = new System.Drawing.Point(338, 0);
            this.animatedControl2.MaxSize = 300;
            this.animatedControl2.MinSize = 50;
            this.animatedControl2.Name = "animatedControl2";
            this.animatedControl2.Shape = CircleForm.Enums.AnimatedShapes.Circle;
            this.animatedControl2.Size = new System.Drawing.Size(350, 361);
            this.animatedControl2.StepSize = 10;
            this.animatedControl2.TabIndex = 1;
            // 
            // animatedControl1
            // 
            this.animatedControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.animatedControl1.AutoChangeDirection = false;
            this.animatedControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.animatedControl1.InitSize = 0;
            this.animatedControl1.IsGrowFirst = false;
            this.animatedControl1.Location = new System.Drawing.Point(0, 0);
            this.animatedControl1.MaxSize = 300;
            this.animatedControl1.MinSize = 50;
            this.animatedControl1.Name = "animatedControl1";
            this.animatedControl1.Shape = CircleForm.Enums.AnimatedShapes.Square;
            this.animatedControl1.Size = new System.Drawing.Size(340, 361);
            this.animatedControl1.StepSize = 10;
            this.animatedControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 361);
            this.Controls.Add(this.animatedControl2);
            this.Controls.Add(this.animatedControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControl.AnimatedControl animatedControl1;
        private CustomControl.AnimatedControl animatedControl2;

    }
}

