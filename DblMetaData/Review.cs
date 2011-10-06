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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            this.title.Text = _data.Title;
            this.languageCode.Text = _data.LanguageCode;
            this.languageName.Text = _data.LanguageName;
            this.scope.Text = _data.Scope;
            this.abbreviation.Text = _data.Abbreviation;
            this.confidential.Text = _data.Confidential;
            this.dateCompleted.Text = _data.DateCompleted;
            this.publisher.Text = _data.Publisher;
            this.publisherUrl.Text = _data.PublisherUrl;
            this.publisherFacebook.Text = _data.PublisherFacebook;
            this.reapUrl.Text = _data.ReapUrl;
            this.countryCode.Text = _data.CountryCode;
            this.countryName.Text = _data.CountryName;
            this.Edition.Text = _data.Edition;
            this.editionType.Text = _data.EditionType;
            this.range.Text = _data.Range;
            this.rangeDescription.Text = _data.RangeDescription;
            this.promoInfo.Text = _data.PromoInfo;
            this.promoEmail.Text = _data.PromoEmail;
            
        }

        private void Preview_Click(object sender, EventArgs e)
        {
            var previewDialog = new PromoPreview();
            previewDialog.XmlData = "<html><body>" + this.promoInfo.Text + "</body></html>";
            previewDialog.ShowDialog();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            _data.PublicationDescription = PubDescTextBox.Text;
            _data.ResetPromoStatements();
            this.promoInfo.Text = _data.PromoInfo;
            this.promoEmail.Text = _data.PromoEmail;
        }
    }
}
