using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DblMetaData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var scraper = new DblMetaDataScraper();
            scraper.Load(webBrowser1.DocumentText);
            scraper.ScrapeReapData();
            scraper.InsertDataInDblMetaData(textBox1.Text);
            var dialog = new SaveFileDialog();
            dialog.FileName = scraper.GetDefaultName();
            dialog.AddExtension = true;
            dialog.DefaultExt = ".xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                scraper.Save(dialog.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri("https://www.reap.insitehome.org/browse?type=language");
        }


    }
}
