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
// File: Review.cs
// Responsibility: Trihus
// ---------------------------------------------------------------------------------------------
using System;
using System.Windows.Forms;
using System.Xml;

namespace DblMetaData
{
    public partial class Review : Form
    {
        #region Data
        private DblMetaDataScraper _data;
        public DblMetaDataScraper Data
        {
            get { return _data; }
            set { _data = value; }
        }
        #endregion Data

        public Review()
        {
            InitializeComponent();
        }

        private void Review_Load(object sender, EventArgs e)
        {
            title.Text = _data.Title;
            languageCode.Text = _data.LanguageCode;
            languageName.Text = _data.LanguageName;
            scope.Text = _data.Scope;
            abbreviation.Text = _data.Abbreviation;
            confidential.Text = _data.Confidential;
            dateCompleted.Text = _data.DateCompleted;
            publisher.Text = _data.Publisher;
            publisherUrl.Text = _data.PublisherUrl;
            publisherFacebook.Text = _data.PublisherFacebook;
            reapUrl.Text = _data.ReapUrl;
            countryCode.Text = _data.CountryCode;
            countryName.Text = _data.CountryName;
            Edition.Text = _data.Edition;
            editionType.Text = _data.EditionType;
            range.Text = _data.Range;
            rangeDescription.Text = _data.RangeDescription;
            promoInfo.Text = _data.PromoInfo;
            promoEmail.Text = _data.PromoEmail;
            PubDescTextBox.Text = _data.PublicationDescription;
            publisherUrl.Items.AddRange(_data.publisherUrls().ToArray());
            publisherFacebook.Items.AddRange(_data.publisherFacebooks().ToArray());
        }

        private void Preview_Click(object sender, EventArgs e)
        {
            var xml = new XmlDocument{XmlResolver = null};
            xml.LoadXml("<root/>");
            var node = xml.SelectSingleNode("/root");
            try
            {
                node.InnerXml = promoInfo.Text;
            }
            catch (Exception)
            {
                MessageBox.Show("Promo Info Html is not well formed xml");
                return;
            }
            var previewDialog = new PromoPreview();
            previewDialog.XmlData = "<html><body>" + promoInfo.Text + "</body></html>";
            previewDialog.ShowDialog();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            _data.PublicationDescription = PubDescTextBox.Text;
            _data.ResetPromoStatements();
            promoInfo.Text = _data.PromoInfo;
            promoEmail.Text = _data.PromoEmail;
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void title_TextChanged(object sender, EventArgs e)
        {
            _data.Title = title.Text;
        }

        private void languageCode_TextChanged(object sender, EventArgs e)
        {
            _data.LanguageCode = languageCode.Text;
        }

        private void languageName_TextChanged(object sender, EventArgs e)
        {
            _data.LanguageName = languageName.Text;
        }

        private void scope_TextChanged(object sender, EventArgs e)
        {
            _data.Scope = scope.Text;
        }

        private void abbreviation_TextChanged(object sender, EventArgs e)
        {
            _data.Abbreviation = abbreviation.Text;
        }

        private void confidential_TextChanged(object sender, EventArgs e)
        {
            _data.Confidential = confidential.Text;
        }

        private void dateCompleted_TextChanged(object sender, EventArgs e)
        {
            _data.DateCompleted = dateCompleted.Text;
        }

        private void publisher_TextChanged(object sender, EventArgs e)
        {
            _data.Publisher = publisher.Text;
        }

        private void publisherUrl_TextChanged(object sender, EventArgs e)
        {
            _data.PublisherUrl = publisherUrl.Text;
        }

        private void publisherFacebook_TextChanged(object sender, EventArgs e)
        {
            _data.PublisherFacebook = publisherFacebook.Text;
        }

        private void reapUrl_TextChanged(object sender, EventArgs e)
        {
            _data.ReapUrl = reapUrl.Text;
        }

        private void countryCode_TextChanged(object sender, EventArgs e)
        {
            _data.CountryCode = countryCode.Text;
        }

        private void countryName_TextChanged(object sender, EventArgs e)
        {
            _data.CountryName = countryName.Text;
        }

        private void Edition_TextChanged(object sender, EventArgs e)
        {
            _data.Edition = Edition.Text;
        }

        private void editionType_TextChanged(object sender, EventArgs e)
        {
            _data.EditionType = editionType.Text;
        }

        private void range_TextChanged(object sender, EventArgs e)
        {
            _data.Range = range.Text;
        }

        private void rangeDescription_TextChanged(object sender, EventArgs e)
        {
            _data.RangeDescription = rangeDescription.Text;
        }

        private void PubDescTextBox_TextChanged(object sender, EventArgs e)
        {
            _data.PublicationDescription = PubDescTextBox.Text;
        }
    }
}
