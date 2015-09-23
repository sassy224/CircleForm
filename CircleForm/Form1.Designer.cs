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
            this.animatedControl1 = new CircleForm.CustomControl.AnimatedControl();
            this.animatedControl2 = new CircleForm.CustomControl.AnimatedControl();
            this.SuspendLayout();
            // 
            // animatedControl1
            // 
            this.animatedControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.animatedControl1.Location = new System.Drawing.Point(12, 12);
            this.animatedControl1.Name = "animatedControl1";
            this.animatedControl1.Size = new System.Drawing.Size(309, 337);
            this.animatedControl1.TabIndex = 0;
            // 
            // animatedControl2
            // 
            this.animatedControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.animatedControl2.Location = new System.Drawing.Point(367, 12);
            this.animatedControl2.Name = "animatedControl2";
            this.animatedControl2.Size = new System.Drawing.Size(309, 337);
            this.animatedControl2.TabIndex = 1;
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
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControl.AnimatedControl animatedControl1;
        private CustomControl.AnimatedControl animatedControl2;

    }
}

