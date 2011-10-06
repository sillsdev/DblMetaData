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
using System.Windows.Forms;

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
            _scraper.InsertDataInDblMetaData();
            var dialog = new SaveFileDialog
                             {FileName = _scraper.GetDefaultName(), 
                                 AddExtension = true, 
                                 DefaultExt = ".xml"};
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _scraper.Save(dialog.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
        }


    }
}
