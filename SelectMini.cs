using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dungee.Properties;
using System.Resources;
using System.Globalization;

namespace Dungee
{
    public partial class SelectMini : Form
    {
        ImageList imgListMinis = new ImageList();
        public SelectMini()
        {
            InitializeComponent();
            ResourceManager rm = new ResourceManager(typeof(Resources));
            ResourceSet rSet = rm.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach(DictionaryEntry entry in rSet)
            {
                string resourceKey = entry.Key.ToString();
                object resource = entry.Value;
                if(resource.GetType() == typeof(Image))
                {
                    imgListMinis.Images.Add((Image)resource);
                }
            }
            lvMinis.LargeImageList = imgListMinis;
        }
    }
}
