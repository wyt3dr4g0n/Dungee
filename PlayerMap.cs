using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dungee
{
    public partial class PlayerMap : Form
    {
        Dungee main;
        public PlayerMap(Dungee dungee)
        {
            InitializeComponent();
            main = dungee;
        }

        public void pbPlayerMap_Paint(object sender, PaintEventArgs e)
        {
            switch (main.cursorType)
            {
                case Dungee.CursorType.AOE:
                    Point local = pbPlayerMap.PointToClient(Cursor.Position);
                    e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(100, Color.Red)), local.X - main.penRadius / 2,
                        local.Y - main.penRadius / 2,
                        main.penRadius, main.penRadius);
                    break;
            }
        }

        private void PlayerMap_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S:
                    main.Activate();
                    break;
            }
        }
    }
}
