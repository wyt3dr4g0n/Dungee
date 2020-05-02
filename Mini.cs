using System;
using System.Drawing;
using System.Windows.Forms;
using Dungee.Properties;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Dungee
{
    public partial class Mini : PictureBox
    {
        OpenFileDialog openFile;
        public Mini PlayerMini;
        public bool shown = false;
        public bool isBaddie = false;
        public bool isDead = false;
        public string imgFileName;
        public int imgSize = 50;
        public Image miniImg;


        [DataContract]
        public class MiniProperties
        {
            [DataMember]
            public string Name;
            [DataMember]
            public string ImgName;
            [DataMember]
            public bool Active;
            [DataMember]
            public bool Dead;
            [DataMember]
            public Int32 Size;
            [DataMember]
            public Int32 X;
            [DataMember]
            public Int32 Y;

        }

        public MiniProperties SaveMini()
        {
            string imgName;
            if (imgFileName == "DefaultMini" || imgFileName == "DefaultBaddie" || imgFileName == null)
            {
                imgName = imgFileName != null ? imgFileName + ".mini" : Location.X.ToString() + "-" + Location.Y.ToString() + ".mini";
            } else
            {
                imgName = Path.GetFileName(imgFileName).Replace(Path.GetExtension(imgFileName), ".mini");
            }
            MiniProperties props = new MiniProperties()
            {
                Name = Name,
                ImgName = imgName,
                Active = shown,
                Dead = isDead,
                Size = this.Size.Width,
                X = this.Location.X,
                Y = this.Location.Y
            };
            return props;
        }

        public Mini()
        {
            InitializeComponent();
            SetupMini();
            imgFileName = "DefaultMini";
            Width = imgSize;
            Height = imgSize;
        }

        public Mini(Mini mini)
        {
            InitializeComponent();
            SetupMini();
            BackgroundImage = mini.miniImg;
            imgFileName = mini.imgFileName;
            Width = imgSize;
            Height = imgSize;
        }

        public Mini(Image img)
        {
            InitializeComponent();
            miniImg = img;
            BackgroundImage = miniImg;
            SetupMini();
            Width = imgSize;
            Height = imgSize;
        }

        public void SetupMini()
        {
            Bitmap miniFill = new Bitmap(imgSize, imgSize);
            using (Graphics g = Graphics.FromImage(miniFill)) g.Clear(Color.FromArgb(200, Color.Black));
            this.MouseWheel += Mini_MouseWheel;
            Image = miniFill;
            BackColor = Color.Transparent;
            SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void ShowMini()
        {
            Bitmap miniFill = new Bitmap(ClientSize.Width, ClientSize.Height);
            using (Graphics g = Graphics.FromImage(miniFill)) g.Clear(Color.Transparent);
            Image = miniFill;
            shown = true;
            PlayerMini.shown = true;
            PlayerMini.Show();
            PlayerMini.BringToFront();
        }

        public void KillMini()
        {
            if (shown)
            {
                if (isDead)
                {
                    Image = null;
                    PlayerMini.Image = null;
                } else
                {
                    Image = Resources.redx;
                    PlayerMini.Image = Resources.redx;
                }
                isDead = !isDead;
            }
        }

        public void HideMini()
        {
            if (isDead) KillMini();
            SetupMini();
            PlayerMini.Hide();
            PlayerMini.shown = false;
            shown = false;
        }

        public void CreatePlayerMini(PictureBox playerMap)
        {
            PlayerMini = new Mini(this);
            playerMap.Controls.Add(PlayerMini);
            PlayerMini.Hide();
            PlayerMini.Location = Parent.PointToClient(Cursor.Position);
            PlayerMini.BackColor = Color.Transparent;
            PlayerMini.Image = null;
            PlayerMini.SizeMode = PictureBoxSizeMode.StretchImage;
            PlayerMini.BackgroundImage = miniImg;
        }

        private void Mini_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Location = new Point(
                        Parent.PointToClient(Cursor.Position).X - Size.Width / 2,
                        Parent.PointToClient(Cursor.Position).Y - Size.Height / 2);
                if (PlayerMini != null)
                {
                    PlayerMini.Location = new Point(
                        Parent.PointToClient(Cursor.Position).X - Size.Width / 2, 
                        Parent.PointToClient(Cursor.Position).Y - Size.Height / 2);
                }
            }
        }

        private void Mini_DoubleClick(object sender, EventArgs e)
        {
            openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                miniImg = Image.FromFile(openFile.FileName);
                BackgroundImage = miniImg;
                imgFileName = Path.GetFileName(openFile.FileName);
                Name = Path.GetFileNameWithoutExtension(openFile.FileName);
                if (PlayerMini != null)
                {
                    PlayerMini.BackgroundImage = miniImg;
                }
            }
            //SelectMini selectMini = new SelectMini();
            //selectMini.Show();
        }
        
        private void Mini_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                if (shown)
                {
                    HideMini();
                }
                else
                {
                    ShowMini();
                }
            }
            if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Right)
            {
                if (Parent.Controls.Count == 1)
                {
                    Dungee dungee = (Dungee)Parent.Parent.Parent.Parent;
                    dungee.zoomScroll.Visible = true;
                    dungee.zoomScroll.Enabled = true;
                }
                PlayerMini.Dispose();
                Dispose();
            }
            else if (ModifierKeys == Keys.Shift && e.Button == MouseButtons.Left)
            {
                if (isBaddie)
                {
                    BackgroundImage = Resources.DefaultMini;
                    PlayerMini.BackgroundImage = miniImg;
                    isBaddie = false;
                    imgFileName = "DefaultMini";
                } else
                {
                    BackgroundImage = Resources.DefaultBaddie;
                    PlayerMini.BackgroundImage = miniImg;
                    isBaddie = true;
                    imgFileName = "DefaultBaddie";
                }

            }
        }

        private void Mini_MouseWheel(object sender, MouseEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                ((HandledMouseEventArgs)e).Handled = true;
                const float scale_per_delta = 10f / 120;
                if (imgSize >= 25 && imgSize <= 100)
                {
                    imgSize += Convert.ToInt32(e.Delta * scale_per_delta);
                }
                else if (imgSize < 25)
                {
                    imgSize = 25;
                }
                else if (imgSize > 100)
                {
                    imgSize = 100;
                }
                Size = new Size(imgSize, imgSize);
                PlayerMini.Size = Size;
                if (!shown)
                {
                    SetupMini();
                }
                Invalidate();
                Update();
            }
        }

        private void Mini_MouseEnter(object sender, EventArgs e)
        {
            Dungee.mouseOverControl = (Mini)sender;
        }
    }
}
