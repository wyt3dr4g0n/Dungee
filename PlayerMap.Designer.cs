namespace Dungee
{
    partial class PlayerMap
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
            this.pbPlayerMap = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerMap)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPlayerMap
            // 
            this.pbPlayerMap.Location = new System.Drawing.Point(0, 0);
            this.pbPlayerMap.Margin = new System.Windows.Forms.Padding(0);
            this.pbPlayerMap.Name = "pbPlayerMap";
            this.pbPlayerMap.Size = new System.Drawing.Size(661, 410);
            this.pbPlayerMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPlayerMap.TabIndex = 0;
            this.pbPlayerMap.TabStop = false;
            // 
            // PlayerMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(661, 410);
            this.Controls.Add(this.pbPlayerMap);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlayerMap";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Player Map (SHARE THIS SCREEN)";
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pbPlayerMap;
    }
}