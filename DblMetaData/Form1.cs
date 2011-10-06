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
        private readonly DblMetaDataScraper _scraper;

        public Form1()
        {
            _scraper = new DblMetaDataScraper();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _scraper.InsertDataInDblMetaData();
            var dialog = new SaveFileDialog();
            dialog.FileName = _scraper.GetDefaultName();
            dialog.AddExtension = true;
            dialog.DefaultExt = ".xml";
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
            _scraper.Load(webDocData);
            _scraper.PublicationDescription = description;
            _scraper.ScrapeReapData();
            var review = new Review();
            review.Data = _scraper;
            if (review.ShowDialog() == DialogResult.OK)
            {
                _scraper.Title = review.Data.Title;
                _scraper.LanguageCode = review.Data.LanguageCode;
                _scraper.LanguageName = review.Data.LanguageName;
                _scraper.Scope = review.Data.Scope;
                _scraper.Abbreviation = review.Data.Abbreviation;
                _scraper.Confidential = review.Data.Confidential;
                _scraper.DateCompleted = review.Data.DateCompleted;
                _scraper.Publisher = review.Data.Publisher;
                _scraper.PublisherUrl = review.Data.PublisherUrl;
                _scraper.PublisherFacebook = review.Data.PublisherFacebook;
                _scraper.ReapUrl = review.Data.ReapUrl;
                _scraper.CountryCode = review.Data.CountryCode;
                _scraper.CountryName = review.Data.CountryName;
                _scraper.Edition = review.Data.Edition;
                _scraper.EditionType = review.Data.EditionType;
                _scraper.Range = review.Data.Range;
                _scraper.RangeDescription = review.Data.RangeDescription;
                _scraper.PromoInfo = review.Data.PromoInfo;
                _scraper.PromoEmail = review.Data.PromoEmail;
                save.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            save.Enabled = false;
        }


    }
}
