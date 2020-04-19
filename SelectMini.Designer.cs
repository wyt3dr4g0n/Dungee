namespace Dungee
{
    partial class SelectMini
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
            this.lvMinis = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvMinis
            // 
            this.lvMinis.HideSelection = false;
            this.lvMinis.Location = new System.Drawing.Point(12, 12);
            this.lvMinis.Name = "lvMinis";
            this.lvMinis.Size = new System.Drawing.Size(370, 315);
            this.lvMinis.TabIndex = 0;
            this.lvMinis.UseCompatibleStateImageBehavior = false;
            // 
            // SelectMini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 339);
            this.Controls.Add(this.lvMinis);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectMini";
            this.Text = "Select Mini";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvMinis;
    }
}