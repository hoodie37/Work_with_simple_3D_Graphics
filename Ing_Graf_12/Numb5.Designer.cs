namespace Ing_Graf_12
{
    partial class Numb5
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
            this.HScrollBarPitch = new System.Windows.Forms.HScrollBar();
            this.HScrollBarYaw = new System.Windows.Forms.HScrollBar();
            this.HScrollBarRoll = new System.Windows.Forms.HScrollBar();
            this.HScrollBarTheta = new System.Windows.Forms.HScrollBar();
            this.MyPictureBox = new System.Windows.Forms.PictureBox();
            this.HScrollBarXOffset = new System.Windows.Forms.HScrollBar();
            this.HScrollBarYOffset = new System.Windows.Forms.HScrollBar();
            this.HScrollBarZOffset = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.MyPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // HScrollBarPitch
            // 
            this.HScrollBarPitch.Location = new System.Drawing.Point(28, 9);
            this.HScrollBarPitch.Name = "HScrollBarPitch";
            this.HScrollBarPitch.Size = new System.Drawing.Size(235, 17);
            this.HScrollBarPitch.TabIndex = 0;
            this.HScrollBarPitch.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarPitch_Scroll);
            // 
            // HScrollBarYaw
            // 
            this.HScrollBarYaw.Location = new System.Drawing.Point(28, 37);
            this.HScrollBarYaw.Name = "HScrollBarYaw";
            this.HScrollBarYaw.Size = new System.Drawing.Size(235, 17);
            this.HScrollBarYaw.TabIndex = 1;
            this.HScrollBarYaw.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarYaw_Scroll);
            // 
            // HScrollBarRoll
            // 
            this.HScrollBarRoll.Location = new System.Drawing.Point(28, 63);
            this.HScrollBarRoll.Name = "HScrollBarRoll";
            this.HScrollBarRoll.Size = new System.Drawing.Size(235, 17);
            this.HScrollBarRoll.TabIndex = 2;
            this.HScrollBarRoll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarRoll_Scroll);
            // 
            // HScrollBarTheta
            // 
            this.HScrollBarTheta.Location = new System.Drawing.Point(556, 9);
            this.HScrollBarTheta.Name = "HScrollBarTheta";
            this.HScrollBarTheta.Size = new System.Drawing.Size(235, 17);
            this.HScrollBarTheta.TabIndex = 3;
            this.HScrollBarTheta.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarTheta_Scroll);
            // 
            // MyPictureBox
            // 
            this.MyPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyPictureBox.Location = new System.Drawing.Point(-1, 83);
            this.MyPictureBox.Name = "MyPictureBox";
            this.MyPictureBox.Size = new System.Drawing.Size(789, 368);
            this.MyPictureBox.TabIndex = 9;
            this.MyPictureBox.TabStop = false;
            // 
            // HScrollBarXOffset
            // 
            this.HScrollBarXOffset.Location = new System.Drawing.Point(556, 37);
            this.HScrollBarXOffset.Maximum = 360;
            this.HScrollBarXOffset.Name = "HScrollBarXOffset";
            this.HScrollBarXOffset.Size = new System.Drawing.Size(235, 17);
            this.HScrollBarXOffset.TabIndex = 10;
            this.HScrollBarXOffset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarXOffset_Scroll_1);
            // 
            // HScrollBarYOffset
            // 
            this.HScrollBarYOffset.Location = new System.Drawing.Point(556, 63);
            this.HScrollBarYOffset.Maximum = 360;
            this.HScrollBarYOffset.Name = "HScrollBarYOffset";
            this.HScrollBarYOffset.Size = new System.Drawing.Size(235, 17);
            this.HScrollBarYOffset.TabIndex = 11;
            this.HScrollBarYOffset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarYOffset_Scroll_1);
            // 
            // HScrollBarZOffset
            // 
            this.HScrollBarZOffset.Location = new System.Drawing.Point(297, 63);
            this.HScrollBarZOffset.Name = "HScrollBarZOffset";
            this.HScrollBarZOffset.Size = new System.Drawing.Size(235, 17);
            this.HScrollBarZOffset.TabIndex = 12;
            this.HScrollBarZOffset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarZOffset_Scroll_1);
            // 
            // Numb5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.HScrollBarZOffset);
            this.Controls.Add(this.HScrollBarYOffset);
            this.Controls.Add(this.HScrollBarXOffset);
            this.Controls.Add(this.MyPictureBox);
            this.Controls.Add(this.HScrollBarTheta);
            this.Controls.Add(this.HScrollBarRoll);
            this.Controls.Add(this.HScrollBarYaw);
            this.Controls.Add(this.HScrollBarPitch);
            this.Name = "Numb5";
            this.Text = "Form 2";
            this.Load += new System.EventHandler(this.Zadanie_5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MyPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.HScrollBar HScrollBarPitch;
        private System.Windows.Forms.HScrollBar HScrollBarYaw;
        private System.Windows.Forms.HScrollBar HScrollBarRoll;
        private System.Windows.Forms.HScrollBar HScrollBarTheta;
        private System.Windows.Forms.PictureBox MyPictureBox;
        private System.Windows.Forms.HScrollBar HScrollBarXOffset;
        private System.Windows.Forms.HScrollBar HScrollBarYOffset;
        private System.Windows.Forms.HScrollBar HScrollBarZOffset;
    }
}