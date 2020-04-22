using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using Dungee.Properties;
using System.Web.Script.Serialization;

namespace Dungee
{
    public partial class Dungee : Form
    {
        public List<Point> currentLine = new List<Point>();
        Image dmMap, playerMap;
        PlayerMap pMap = new PlayerMap();
        float penRadius = 50;
        public Dungee()
        {
            InitializeComponent();
            FillMap();
            pbDmMap.MouseWheel += new MouseEventHandler(pbDmMap_MouseWheel);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "Map File |*.jpg;*.jpeg;*.png;*.sesh",
            };
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                foreach (Mini mini in pbDmMap.Controls.OfType<Mini>())
                {
                    mini.PlayerMini.Dispose();
                    mini.Dispose();
                }
                string FileName = openFile.FileName;
                if (Path.GetExtension(openFile.FileName) == ".sesh")
                {
                    string mapFile = Path.GetFileName(openFile.FileName).Replace(".sesh", ".map");
                    string playerMapFile = Path.GetFileName(openFile.FileName).Replace(".sesh", ".pmap");
                    string fogPlayerFile = Path.GetFileName(openFile.FileName).Replace(".sesh", ".pfog");
                    string fogDMFile = Path.GetFileName(openFile.FileName).Replace(".sesh", ".dmfog");
                    string jsonFile = Path.GetFileName(openFile.FileName).Replace(".sesh", ".json");
                    using (FileStream seshFile = new FileStream(openFile.FileName, FileMode.Open))
                    {
                        using (ZipArchive archive = new ZipArchive(seshFile, ZipArchiveMode.Read))
                        {
                            ZipArchiveEntry mapEntry = archive.GetEntry(mapFile);
                            using (StreamReader readerMap = new StreamReader(mapEntry.Open())) 
                                dmMap = Image.FromStream(readerMap.BaseStream);
                            ZipArchiveEntry playerMapEntry = archive.GetEntry(playerMapFile);
                            using (StreamReader readerMap = new StreamReader(playerMapEntry.Open()))
                                playerMap = Image.FromStream(readerMap.BaseStream);
                            ZipArchiveEntry dmfogEntry = archive.GetEntry(fogDMFile);
                            using (StreamReader readerDMFog = new StreamReader(dmfogEntry.Open())) 
                                pbDmMap.Image = Image.FromStream(readerDMFog.BaseStream);
                            ZipArchiveEntry pfogEntry = archive.GetEntry(fogPlayerFile);
                            using (StreamReader readerPFog = new StreamReader(pfogEntry.Open())) 
                                pMap.pbPlayerMap.Image = Image.FromStream(readerPFog.BaseStream);
                            ZipArchiveEntry miniEntry = archive.GetEntry(jsonFile);
                            using (StreamReader readerMini = new StreamReader(miniEntry.Open()))
                            {
                                JavaScriptSerializer serializer = new JavaScriptSerializer();
                                List<Mini.MiniProperties> minis = 
                                    serializer.Deserialize<List<Mini.MiniProperties>>(readerMini.ReadToEnd());
                                foreach (Mini.MiniProperties mini in minis)
                                {
                                    ZipArchiveEntry miniImgEntry = archive.GetEntry(mini.ImgName);
                                    using (StreamReader readerMiniImg = new StreamReader(miniImgEntry.Open()))
                                    {
                                        Image image = Image.FromStream(readerMiniImg.BaseStream);
                                        Mini addMini = new Mini(image);
                                        addMini.Name = mini.Name;
                                        addMini.imgFileName = mini.ImgName;
                                        pbDmMap.Controls.Add(addMini);
                                        addMini.BringToFront();
                                        addMini.Show();
                                        addMini.Location = new Point(mini.X, mini.Y);
                                        addMini.Size = new Size(mini.Size, mini.Size);
                                        addMini.CreatePlayerMini(pMap.pbPlayerMap);
                                        addMini.PlayerMini.Location = addMini.Location;
                                        addMini.PlayerMini.Size = addMini.Size;
                                        if (mini.Active) addMini.ShowMini();
                                    }
                                }
                            }
                        }
                    }
                    pbDmMap.BackgroundImage = dmMap;
                    pbDmMap.Width = dmMap.Width;
                    pbDmMap.Height = dmMap.Height;
                    pMap.Show();
                    pMap.Location = panel1.PointToScreen(Point.Empty);
                    pMap.Size = panel1.Size;
                    pMap.pbPlayerMap.BackgroundImage = dmMap;
                } else
                {
                    dmMap = Image.FromFile(openFile.FileName);
                    dmMap = ResizeImage(dmMap, false);
                    pbDmMap.Width = dmMap.Width;
                    pbDmMap.Height = dmMap.Height;
                    pbDmMap.BackgroundImage = dmMap;
                    pMap.Show();
                    pMap.Location = panel1.PointToScreen(Point.Empty);
                    pMap.Size = panel1.Size;
                    if (Path.GetFileName(openFile.FileName).Contains("-DM"))
                    {
                        string path = openFile.FileName.Replace(
                            Path.GetFileName(openFile.FileName),
                            Path.GetFileName(openFile.FileName).Replace("-DM", ""));
                        pMap.pbPlayerMap.BackgroundImage = ResizeImage(Image.FromFile(path), false);
                    }
                    else
                    {
                        pMap.pbPlayerMap.BackgroundImage = dmMap;

                    }
                    FillMap();
                }
                btnSave.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                Activate();
            }
        }

        void FillMap()
        {
            if (pbDmMap.Image != null) pbDmMap.Image.Dispose();
            if (pMap.pbPlayerMap.Image != null) pMap.pbPlayerMap.Image.Dispose();
            Size imageSize = new Size(pbDmMap.ClientSize.Width, pbDmMap.ClientSize.Height);
            Bitmap dmFillFog = new Bitmap(imageSize.Width, imageSize.Height);
            Bitmap plFillFog = new Bitmap(imageSize.Width, imageSize.Height);
            using (Graphics g = Graphics.FromImage(dmFillFog)) g.Clear(Color.FromArgb(200, Color.Black));
            using (Graphics g = Graphics.FromImage(plFillFog)) g.Clear(Color.Black);
            pbDmMap.Image = dmFillFog;
            pMap.pbPlayerMap.Image = plFillFog;
            currentLine.Clear();
            pbDmMap.Invalidate();
            pMap.pbPlayerMap.Invalidate();
            pbDmMap.Update();
            pMap.pbPlayerMap.Update();
        }

        void EmptyMap()
        {
            if (pbDmMap.Image != null) pbDmMap.Image.Dispose();
            if (pMap.pbPlayerMap.Image != null) pMap.pbPlayerMap.Image.Dispose();
            Size imageSize = new Size(pbDmMap.ClientSize.Width, pbDmMap.ClientSize.Height);
            Bitmap dmFillFog = new Bitmap(imageSize.Width, imageSize.Height);
            Bitmap plFillFog = new Bitmap(imageSize.Width, imageSize.Height);
            using (Graphics g = Graphics.FromImage(dmFillFog)) g.Clear(Color.Transparent);
            using (Graphics g = Graphics.FromImage(plFillFog)) g.Clear(Color.Transparent);
            pbDmMap.Image = dmFillFog;
            pMap.pbPlayerMap.Image = plFillFog;
            currentLine.Clear();
            pbDmMap.Invalidate();
            pMap.pbPlayerMap.Invalidate();
            pbDmMap.Update();
            pMap.pbPlayerMap.Update();
        }

        private void btnFillFog_Click(object sender, EventArgs e)
        {
            FillMap();
        }

        public void drawOntoImage()
        {
            if(pbDmMap.Image != null)
            {
                using (Graphics G = Graphics.FromImage(pbDmMap.Image))
                {
                    G.CompositingMode = CompositingMode.SourceCopy;
                    G.SmoothingMode = SmoothingMode.HighQuality;
                    G.CompositingQuality = CompositingQuality.HighQuality;

                    using (Pen somePen = new Pen(Color.Transparent, penRadius))
                    {
                        somePen.MiterLimit = penRadius / 2;
                        somePen.EndCap = LineCap.Round;
                        somePen.LineJoin = LineJoin.Round;
                        somePen.StartCap = LineCap.Round;
                        if (currentLine.Count > 1)
                        {
                            G.DrawCurve(somePen, currentLine.ToArray());
                            using (Graphics pG = Graphics.FromImage(pMap.pbPlayerMap.Image))
                            {
                                pG.CompositingMode = G.CompositingMode;
                                pG.CompositingQuality = G.CompositingQuality;
                                pG.SmoothingMode = G.SmoothingMode;
                                pG.DrawCurve(somePen, currentLine.ToArray());
                            }
                        }
                    }
                }
            }

            pbDmMap.Invalidate();
            pMap.pbPlayerMap.Invalidate();
            pbDmMap.Update();
            pMap.pbPlayerMap.Update();
        }

        private void pbDmMap_MouseDown(object sender, MouseEventArgs e)
        {
            if(ModifierKeys == Keys.Shift)
            {
                Mini mini = new Mini(Resources.DefaultMini);
                pbDmMap.Controls.Add(mini);
                mini.BringToFront();
                mini.Show();
                mini.CreatePlayerMini(pMap.pbPlayerMap);
                mini.Location = pbDmMap.PointToClient(Cursor.Position);
            } else
            {
                currentLine.Add(e.Location);
                drawOntoImage();
            }

        }
        private void pbDmMap_MouseUp(object sender, MouseEventArgs e)
        {
            currentLine.Clear();
        }
        private void pbDmMap_MouseEnter(object sender, EventArgs e)
        {
            //Cursor.Hide();
        }
        private void pbDmMap_MouseLeave(object sender, EventArgs e)
        {
            //Cursor.Show();
        }
        private void pbDmMap_MouseWheel(object sender, MouseEventArgs e)
        {
            if((ModifierKeys & Keys.Control) == Keys.Control)
            {
                ((HandledMouseEventArgs)e).Handled = true;
                const float scale_per_delta = 10f / 120;
                if (penRadius >= 10 && penRadius < 500) { 
                    penRadius += e.Delta * scale_per_delta;
                } else if (penRadius < 10)
                {
                    penRadius = 10;
                } else if (penRadius > 500)
                {
                    penRadius = 500;
                }

                pbDmMap.Invalidate();
                pbDmMap.Update();
            } else
            {
                pMap.HorizontalScroll.Value = panel1.HorizontalScroll.Value;
                pMap.VerticalScroll.Value = panel1.VerticalScroll.Value;
            }
        }
        private void pbDmMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentLine.Add(e.Location);
                drawOntoImage();
            }
            pbDmMap.Invalidate();
            pbDmMap.Update();
        }
        private void pbDmMap_Paint(object sender, PaintEventArgs e)
        {
            Point local = pbDmMap.PointToClient(Cursor.Position);
            e.Graphics.DrawEllipse(Pens.White, local.X - penRadius/2, 
                local.Y - penRadius/2, 
                penRadius, penRadius);
        }

        public Bitmap ResizeImage(Image img, bool upscale)
        {
            Rectangle screenSize = Screen.PrimaryScreen.Bounds;
            int height, width;
            float scale = (float)50 / 100;
            height = upscale ? Convert.ToInt32(img.Height / scale) : Convert.ToInt32(img.Height * scale);
            width = upscale ? Convert.ToInt32(img.Height / scale) : Convert.ToInt32(img.Width * scale);
            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap destImage = new Bitmap(width, height);

            destImage.SetResolution(img.HorizontalResolution, img.VerticalResolution);
            using (Graphics G = Graphics.FromImage(destImage))
            {
                G.CompositingMode = CompositingMode.SourceCopy;
                G.CompositingQuality = CompositingQuality.HighQuality;
                G.InterpolationMode = InterpolationMode.HighQualityBicubic;
                G.SmoothingMode = SmoothingMode.HighQuality;
                G.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    G.DrawImage(img, destRect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }

        private void Dungee_Move(object sender, EventArgs e)
        {
            pMap.Location = panel1.PointToScreen(Point.Empty);
            //pMap.Left = Left + 50;
        }

        private void btnClearFog_Click(object sender, EventArgs e)
        {
            EmptyMap();
        }

        private void addMiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mini mini = new Mini(Resources.Kraw);
            ToolStripItem item = sender as ToolStripItem;
            ToolStrip toolStrip = item.Owner as ToolStrip;
            pbDmMap.Controls.Add(mini);
            mini.BringToFront();
            mini.Show();
            mini.CreatePlayerMini(pMap.pbPlayerMap);
            mini.Location = pbDmMap.PointToClient(new Point(toolStrip.Location.X - mini.Width/2, toolStrip.Location.Y - mini.Height/2));
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            ContextMenuStrip toolStrip = menuItem.Owner as ContextMenuStrip;
            Mini mini = toolStrip.SourceControl as Mini;
            if(mini.PlayerMini == null)
            {

                mini.PlayerMini.Location = pbDmMap.PointToClient(new Point(toolStrip.Location.X - mini.Width / 2, toolStrip.Location.Y - mini.Height / 2));
            }
            else
            {
                mini.ShowMini();
            }

            //showToolStripMenuItem.Enabled = false;
            //hideOnPlayerMapToolStripMenuItem.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pMap.Activate();
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            pMap.HorizontalScroll.Value = panel1.HorizontalScroll.Value;
            pMap.VerticalScroll.Value = panel1.VerticalScroll.Value;
            
        }

        private void Dungee_Resize(object sender, EventArgs e)
        {
            pMap.Size = panel1.Size;
        }

        private void hideOnPlayerMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            ContextMenuStrip toolStrip = menuItem.Owner as ContextMenuStrip;
            Mini mini = toolStrip.SourceControl as Mini;
            mini.PlayerMini.Hide();
            //showToolStripMenuItem.Enabled = true;
            //hideOnPlayerMapToolStripMenuItem.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFile = new SaveFileDialog() 
            {
                DefaultExt = "sesh",
                Filter = "Dungee Session File|*.sesh",
                AddExtension = true,
                InitialDirectory = ".",
                RestoreDirectory = true
            })
            {
                if(saveFile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(saveFile.FileName, FileMode.Create))
                    {
                        using (ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Update))
                        {
                            string mapImg = Path.GetFileName(saveFile.FileName).Replace(".sesh", ".map");
                            ZipArchiveEntry map = archive.CreateEntry(mapImg);
                            using (StreamWriter writerMap = new StreamWriter(map.Open()))
                            {
                                pbDmMap.BackgroundImage.Save(writerMap.BaseStream, ImageFormat.Jpeg);
                            }
                            string playerMapImg = Path.GetFileName(saveFile.FileName).Replace(".sesh", ".pmap");
                            ZipArchiveEntry playerMap = archive.CreateEntry(playerMapImg);
                            using (StreamWriter writerMap = new StreamWriter(playerMap.Open()))
                            {
                               pMap.pbPlayerMap.BackgroundImage.Save(writerMap.BaseStream, ImageFormat.Jpeg);
                            }
                            string fogDM = Path.GetFileName(saveFile.FileName).Replace(".sesh", ".dmfog");
                            ZipArchiveEntry dmfog = archive.CreateEntry(fogDM);
                            using (StreamWriter writerDMFog = new StreamWriter(dmfog.Open()))
                            {
                                pbDmMap.Image.Save(writerDMFog.BaseStream, ImageFormat.Png);
                            }
                            string fogPlayer = Path.GetFileName(saveFile.FileName).Replace(".sesh", ".pfog");
                            ZipArchiveEntry pfog = archive.CreateEntry(fogPlayer);
                            using (StreamWriter writerPFog = new StreamWriter(pfog.Open()))
                            {
                                pMap.pbPlayerMap.Image.Save(writerPFog.BaseStream, ImageFormat.Png);
                            }
                            List<Mini.MiniProperties> miniProperties = new List<Mini.MiniProperties>();
                            foreach (Mini mini in pbDmMap.Controls.OfType<Mini>())
                            {
                                if(mini.SaveMini() != null)
                                {
                                    Mini.MiniProperties miniProps = mini.SaveMini();
                                    miniProperties.Add(miniProps);
                                    ZipArchiveEntry miniImg = archive.GetEntry(miniProps.ImgName);
                                    if (miniImg == null)
                                    {
                                        miniImg = archive.CreateEntry(miniProps.ImgName);
                                    }
                                    using (StreamWriter writerMini = new StreamWriter(miniImg.Open()))
                                    {
                                        mini.BackgroundImage.Save(writerMini.BaseStream, ImageFormat.Jpeg);
                                    }
                                }

                            }
                            string miniFile = Path.GetFileName(saveFile.FileName).Replace(".sesh", ".json");
                            ZipArchiveEntry json = archive.CreateEntry(miniFile);
                            using (Stream jsonData = json.Open())
                            {
                                using (StreamWriter writerJson = new StreamWriter(jsonData))
                                {
                                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                                    writerJson.Write(serializer.Serialize(miniProperties));
                                }
                            }

                        }
                    }
                }
            }

            //SaveFileDialog saveFile = new SaveFileDialog()
            //{
            //    DefaultExt = "sesh",
            //    Filter = "Dungee Session File|*.sesh",
            //    AddExtension = true,
            //    InitialDirectory = ".",
            //    RestoreDirectory = true                
            //};
            //if(saveFile.ShowDialog() == DialogResult.OK)
            //{

            //    string FileName = saveFile.FileName;
            //    string PMFileName = Path.GetDirectoryName(FileName) + "\\" + Path.GetFileNameWithoutExtension(FileName) + ".pm" + Path.GetExtension(FileName);
            //    string BGFileName = Path.GetDirectoryName(FileName) + "\\" + Path.GetFileNameWithoutExtension(FileName) + ".bg" + Path.GetExtension(FileName);
            //    pbDmMap.Image.Save(FileName);
            //    pMap.pbPlayerMap.Image.Save(PMFileName);
            //    pbDmMap.BackgroundImage.Save(BGFileName);
            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            EmptyMap();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FillMap();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dungee_KeyDown(object sender, KeyEventArgs e)
        {
            if(ModifierKeys == Keys.Shift && e.KeyCode == Keys.P)
            {
                pMap.Activate();
            }
        }

        private void scrollZoom_Scroll(object sender, ScrollEventArgs e)
        {
            bool upscale;
            if(e.NewValue < e.OldValue)
            {
                upscale = false;

            } else
            {
                upscale = true;
            }
            pbDmMap.Image = ResizeImage(pbDmMap.Image, upscale);
            pbDmMap.BackgroundImage = ResizeImage(pbDmMap.BackgroundImage, upscale);
            pMap.pbPlayerMap.Image = ResizeImage(pMap.pbPlayerMap.Image, upscale);
            pMap.pbPlayerMap.BackgroundImage = ResizeImage(pMap.pbPlayerMap.BackgroundImage, upscale);
            foreach (Mini mini in pbDmMap.Controls.OfType<Mini>())
            {
                //Image bgImage = ResizeImage(mini.BackgroundImage, upscale);
                //mini.BackgroundImage = bgImage;
                //mini.Image = ResizeImage(mini.Image, upscale);
                //mini.PlayerMini.BackgroundImage = bgImage;
                //mini.PlayerMini.Image = ResizeImage(mini.PlayerMini.Image, upscale);
            }
        }

    }
}
