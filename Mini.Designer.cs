﻿namespace Dungee
{
    partial class Mini
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
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Mini
            // 
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Size = new System.Drawing.Size(50, 50);
            this.DoubleClick += new System.EventHandler(this.Mini_DoubleClick);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mini_MouseClick);
            this.MouseEnter += new System.EventHandler(this.Mini_MouseEnter);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mini_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion
    }
}
