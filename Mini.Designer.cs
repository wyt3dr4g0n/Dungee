namespace Dungee
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
            this.Size = new System.Drawing.Size(imgSize, imgSize);
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DoubleClick += Mini_DoubleClick;
            this.MouseMove += Mini_MouseMove;
            this.MouseClick += Mini_MouseClick;
            this.MouseWheel += Mini_MouseWheel;
            //this.Location = Parent.PointToScreen(System.Windows.Forms.Cursor.Position);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion
    }
}
