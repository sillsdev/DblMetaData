// ---------------------------------------------------------------------------------------------
#region // Copyright (c) 2011, SIL International. All Rights Reserved.
// <copyright from='2011' to='2011' company='SIL International'>
//		Copyright (c) 2011, SIL International. All Rights Reserved.
//
//		Distributable under the terms of either the Common Public License or the
//		GNU Lesser General Public License, as specified in the LICENSING.txt file.
// </copyright>
#endregion
//
// File: Form1.cs
// Responsibility: Trihus
// ---------------------------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace DblMetaData
{
    public partial class Form1 : Form
    {
        private DblMetaDataScraper _scraper;

        public Form1()
        {
            _scraper = new DblMetaDataScraper();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _scraper.InsertDataInDblMetaData();
            }
            catch(XmlException)
            {
                MessageBox.Show("The Xml field (probably the Promo Html Info) is not well formed");
                return;
            }
            var dialog = new SaveFileDialog
                             {FileName = _scraper.GetDefaultName(), 
                                 AddExtension = true, 
                                 DefaultExt = ".xml"};
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _scraper.Save(dialog.FileName);
            }
        }

        private void reap_Click(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri("https://www.reap.insitehome.org/browse?type=language");
        }

        private void review_Click(object sender, EventArgs e)
        {
            ReviewSiteData(webBrowser1.DocumentText, "");
        }

        public void ReviewSiteData(string webDocData, string description)
        {
            try
            {
                _scraper.Load(webDocData);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter Insite Authentication data.");
                return;
            }
            _scraper.PublicationDescription = description;
            try
            {
                _scraper.ScrapeReapData();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Reap Page. Browse to 'Show full item record' for the appropriate publication.");
                return;
            }
            var reviewDialog = new Review {Data = _scraper};
            if (reviewDialog.ShowDialog() == DialogResult.OK)
            {
                _scraper = reviewDialog.Data;
                save.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            save.Enabled = false;
            Form1_Resize(sender, e);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Control control = (Control) sender;

            int deltaWidth = control.Size.Width - 960;
            int deltaHeight = control.Size.Height - 714;
            webBrowser1.Size = new Size(918 + deltaWidth, 618 + deltaHeight);
            int buttonTop = deltaHeight + 636;
            reap.Location = new Point(reap.Location.X, buttonTop);
            review.Location = new Point(review.Location.X, buttonTop);
            save.Location = new Point(save.Location.X, buttonTop);
        }


    }
}
