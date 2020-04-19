using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private string imgFileName;
        int imgSize = 30;

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
            public Int32 Size;
            [DataMember]
            public Int32 X;
            [DataMember]
            public Int32 Y;

        }

        public MiniProperties SaveMini()
        {
            string imgName;
            if (imgFileName == "DefaultMini" || imgFileName == "DefaultBaddie")
            {
                imgName = imgFileName + ".mini";
            } else
            {
                imgName = Path.GetFileName(imgFileName).Replace(Path.GetExtension(imgFileName), ".mini");
            }
            MiniProperties props = new MiniProperties()
            {
                Name = "Mini",
                ImgName = imgName,
                Active = shown,
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
        }

        public Mini(Mini mini)
        {
            InitializeComponent();
            SetupMini();
            BackgroundImage = mini.BackgroundImage;
        }

        public Mini(Image img)
        {
            InitializeComponent();
            SetupMini();
            BackgroundImage = img;
        }

        public void SetupMini()
        {
            Bitmap miniFill = new Bitmap(ClientSize.Width, ClientSize.Height);
            using (Graphics g = Graphics.FromImage(miniFill)) g.Clear(Color.FromArgb(200, Color.Black));
            Image = miniFill;
            imgFileName = "DefaultMini";
        }

        public void ShowMini()
        {
            Bitmap miniFill = new Bitmap(ClientSize.Width, ClientSize.Height);
            using (Graphics g = Graphics.FromImage(miniFill)) g.Clear(Color.Transparent);
            Image = miniFill;
            shown = true;
            PlayerMini.Image = miniFill;
            PlayerMini.shown = true;
            PlayerMini.Show();
            PlayerMini.BringToFront();
        }

        public void HideMini()
        {
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
                BackgroundImage = Image.FromFile(openFile.FileName);
                imgFileName = Path.GetFileName(openFile.FileName);
                if (PlayerMini != null)
                {
                    PlayerMini.BackgroundImage = BackgroundImage;
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
            if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left)
            {
                PlayerMini.Dispose();
                Dispose();
            }
            else if (ModifierKeys == Keys.Shift && e.Button == MouseButtons.Left)
            {
                if (isBaddie)
                {
                    BackgroundImage = Resources.DefaultMini;
                    PlayerMini.BackgroundImage = BackgroundImage;
                    isBaddie = false;
                    imgFileName = "DefaultMini";
                } else
                {
                    BackgroundImage = Resources.DefaultBaddie;
                    PlayerMini.BackgroundImage = BackgroundImage;
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
                if (imgSize >= 25 && imgSize <= 50)
                {
                    imgSize += Convert.ToInt32(e.Delta * scale_per_delta);
                }
                else if (imgSize < 25)
                {
                    imgSize = 25;
                }
                else if (imgSize > 50)
                {
                    imgSize = 50;
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
    }
}
