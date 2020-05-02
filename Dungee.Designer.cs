namespace Dungee
{
    partial class Dungee
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
            this.DMGroup = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbDmMap = new System.Windows.Forms.PictureBox();
            this.btnPlayerView = new System.Windows.Forms.Button();
            this.zoomScroll = new System.Windows.Forms.HScrollBar();
            this.lblZoom = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFill = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.DMGroup.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDmMap)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DMGroup
            // 
            this.DMGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DMGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DMGroup.Controls.Add(this.panel1);
            this.DMGroup.ForeColor = System.Drawing.Color.White;
            this.DMGroup.Location = new System.Drawing.Point(113, 12);
            this.DMGroup.Margin = new System.Windows.Forms.Padding(0);
            this.DMGroup.Name = "DMGroup";
            this.DMGroup.Padding = new System.Windows.Forms.Padding(0);
            this.DMGroup.Size = new System.Drawing.Size(665, 440);
            this.DMGroup.TabIndex = 0;
            this.DMGroup.TabStop = false;
            this.DMGroup.Text = "DM Map";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pbDmMap);
            this.panel1.Location = new System.Drawing.Point(2, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(662, 421);
            this.panel1.TabIndex = 1;
            this.panel1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel1_Scroll);
            // 
            // pbDmMap
            // 
            this.pbDmMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbDmMap.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbDmMap.Location = new System.Drawing.Point(0, 0);
            this.pbDmMap.Margin = new System.Windows.Forms.Padding(0);
            this.pbDmMap.Name = "pbDmMap";
            this.pbDmMap.Size = new System.Drawing.Size(662, 421);
            this.pbDmMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbDmMap.TabIndex = 0;
            this.pbDmMap.TabStop = false;
            this.pbDmMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pbDmMap_Paint);
            this.pbDmMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbDmMap_MouseDown);
            this.pbDmMap.MouseEnter += new System.EventHandler(this.pbDmMap_MouseEnter);
            this.pbDmMap.MouseLeave += new System.EventHandler(this.pbDmMap_MouseLeave);
            this.pbDmMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbDmMap_MouseMove);
            this.pbDmMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbDmMap_MouseUp);
            // 
            // btnPlayerView
            // 
            this.btnPlayerView.Enabled = false;
            this.btnPlayerView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayerView.ForeColor = System.Drawing.Color.White;
            this.btnPlayerView.Location = new System.Drawing.Point(6, 135);
            this.btnPlayerView.Name = "btnPlayerView";
            this.btnPlayerView.Size = new System.Drawing.Size(86, 23);
            this.btnPlayerView.TabIndex = 0;
            this.btnPlayerView.TabStop = false;
            this.btnPlayerView.Text = "Player View";
            this.btnPlayerView.UseVisualStyleBackColor = true;
            this.btnPlayerView.Click += new System.EventHandler(this.button3_Click);
            this.btnPlayerView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button3_MouseDown);
            this.btnPlayerView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button3_MouseUp);
            // 
            // zoomScroll
            // 
            this.zoomScroll.Enabled = false;
            this.zoomScroll.LargeChange = 50;
            this.zoomScroll.Location = new System.Drawing.Point(5, 202);
            this.zoomScroll.Maximum = 200;
            this.zoomScroll.Minimum = 1;
            this.zoomScroll.Name = "zoomScroll";
            this.zoomScroll.Size = new System.Drawing.Size(105, 17);
            this.zoomScroll.SmallChange = 10;
            this.zoomScroll.TabIndex = 1;
            this.zoomScroll.Value = 100;
            this.zoomScroll.Visible = false;
            this.zoomScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // lblZoom
            // 
            this.lblZoom.AutoSize = true;
            this.lblZoom.Enabled = false;
            this.lblZoom.ForeColor = System.Drawing.Color.White;
            this.lblZoom.Location = new System.Drawing.Point(43, 189);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(34, 13);
            this.lblZoom.TabIndex = 2;
            this.lblZoom.Text = "Zoom";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.btnFill);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnPlayerView);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.groupBox1.Size = new System.Drawing.Size(98, 174);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnFill
            // 
            this.btnFill.Enabled = false;
            this.btnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFill.Location = new System.Drawing.Point(6, 106);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(86, 23);
            this.btnFill.TabIndex = 0;
            this.btnFill.TabStop = false;
            this.btnFill.Text = "Fill Fog";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(6, 77);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear Fog";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(6, 48);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Save Map";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Location = new System.Drawing.Point(6, 19);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(86, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.TabStop = false;
            this.btnLoad.Text = "Load Map";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.ForeColor = System.Drawing.Color.White;
            this.btnHelp.Location = new System.Drawing.Point(12, 422);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(92, 23);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // Dungee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(783, 457);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblZoom);
            this.Controls.Add(this.zoomScroll);
            this.Controls.Add(this.DMGroup);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "Dungee";
            this.Text = "Dungee";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Dungee_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Dungee_KeyUp);
            this.Move += new System.EventHandler(this.Dungee_Move);
            this.Resize += new System.EventHandler(this.Dungee_Resize);
            this.DMGroup.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDmMap)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox DMGroup;
        private System.Windows.Forms.PictureBox pbDmMap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPlayerView;
        public System.Windows.Forms.HScrollBar zoomScroll;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnHelp;
    }
}

