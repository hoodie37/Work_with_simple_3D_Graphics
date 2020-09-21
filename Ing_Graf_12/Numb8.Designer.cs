namespace Ing_Graf_12
{
    partial class Numb8
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.HScrollBarPitch = new System.Windows.Forms.HScrollBar();
            this.HScrollBarYaw = new System.Windows.Forms.HScrollBar();
            this.HScrollBarRoll = new System.Windows.Forms.HScrollBar();
            this.HScrollBarA = new System.Windows.Forms.HScrollBar();
            this.HScrollBarB = new System.Windows.Forms.HScrollBar();
            this.HScrollBarC = new System.Windows.Forms.HScrollBar();
            this.HScrollBarTheta = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(17, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(878, 507);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // HScrollBarPitch
            // 
            this.HScrollBarPitch.Location = new System.Drawing.Point(9, 9);
            this.HScrollBarPitch.Name = "HScrollBarPitch";
            this.HScrollBarPitch.Size = new System.Drawing.Size(243, 17);
            this.HScrollBarPitch.TabIndex = 9;
            this.HScrollBarPitch.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarPitch_Scroll);
            // 
            // HScrollBarYaw
            // 
            this.HScrollBarYaw.Location = new System.Drawing.Point(9, 26);
            this.HScrollBarYaw.Name = "HScrollBarYaw";
            this.HScrollBarYaw.Size = new System.Drawing.Size(243, 17);
            this.HScrollBarYaw.TabIndex = 10;
            this.HScrollBarYaw.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarYaw_Scroll);
            // 
            // HScrollBarRoll
            // 
            this.HScrollBarRoll.Location = new System.Drawing.Point(9, 43);
            this.HScrollBarRoll.Name = "HScrollBarRoll";
            this.HScrollBarRoll.Size = new System.Drawing.Size(243, 17);
            this.HScrollBarRoll.TabIndex = 11;
            this.HScrollBarRoll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarRoll_Scroll);
            // 
            // HScrollBarA
            // 
            this.HScrollBarA.Location = new System.Drawing.Point(573, 9);
            this.HScrollBarA.Name = "HScrollBarA";
            this.HScrollBarA.Size = new System.Drawing.Size(253, 17);
            this.HScrollBarA.TabIndex = 12;
            this.HScrollBarA.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarA_Scroll);
            // 
            // HScrollBarB
            // 
            this.HScrollBarB.Location = new System.Drawing.Point(573, 26);
            this.HScrollBarB.Name = "HScrollBarB";
            this.HScrollBarB.Size = new System.Drawing.Size(253, 17);
            this.HScrollBarB.TabIndex = 13;
            this.HScrollBarB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarB_Scroll);
            // 
            // HScrollBarC
            // 
            this.HScrollBarC.Location = new System.Drawing.Point(573, 43);
            this.HScrollBarC.Name = "HScrollBarC";
            this.HScrollBarC.Size = new System.Drawing.Size(253, 17);
            this.HScrollBarC.TabIndex = 14;
            this.HScrollBarC.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarC_Scroll);
            // 
            // HScrollBarTheta
            // 
            this.HScrollBarTheta.Location = new System.Drawing.Point(252, 43);
            this.HScrollBarTheta.Name = "HScrollBarTheta";
            this.HScrollBarTheta.Size = new System.Drawing.Size(294, 17);
            this.HScrollBarTheta.TabIndex = 15;
            this.HScrollBarTheta.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarTheta_Scroll);
            // 
            // Numb8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 584);
            this.Controls.Add(this.HScrollBarTheta);
            this.Controls.Add(this.HScrollBarC);
            this.Controls.Add(this.HScrollBarB);
            this.Controls.Add(this.HScrollBarA);
            this.Controls.Add(this.HScrollBarRoll);
            this.Controls.Add(this.HScrollBarYaw);
            this.Controls.Add(this.HScrollBarPitch);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Numb8";
            this.Text = "Form 2";
            this.Load += new System.EventHandler(this.FormLab8_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.HScrollBar HScrollBarPitch;
        private System.Windows.Forms.HScrollBar HScrollBarYaw;
        private System.Windows.Forms.HScrollBar HScrollBarRoll;
        private System.Windows.Forms.HScrollBar HScrollBarA;
        private System.Windows.Forms.HScrollBar HScrollBarB;
        private System.Windows.Forms.HScrollBar HScrollBarC;
        private System.Windows.Forms.HScrollBar HScrollBarTheta;
    }
}