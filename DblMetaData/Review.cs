﻿// ---------------------------------------------------------------------------------------------
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

        private bool _userAction = false;
        private bool _userSetAbbreviation = false;
        private bool _userSetDescription = false;
        private bool _userSetPromoEmail = false;
        private bool _userSetRightsStatment = false;
        private bool _userSetPublisherUrl = false;
        private bool _userSetPublisherFacebook = false;

        public Review()
        {
            InitializeComponent();
        }

        protected void SetDescription()
        {
            var saveUserAction = _userAction;
            _userAction = false;
            _data.SetDescription();
            description.Text = _data.Description;
            if (!_userSetPromoEmail)
                SetPromoEmail();
            _userAction = saveUserAction;
        }

        protected void SetAbbreviation()
        {
            var saveUserAction = _userAction;
            _userAction = false;
            _data.SetAbbreviation();
            abbreviation.Text = _data.Abbreviation;
            _userAction = saveUserAction;
        }

        protected void SetPromoEmail()
        {
            var saveUserAction = _userAction;
            _userAction = false;
            _data.SetPromoEmail();
            promoEmail.Text = _data.PromoEmail;
            _userAction = saveUserAction;
        }

        protected void SetRightsStatement()
        {
            var saveUserAction = _userAction;
            _userAction = false;
            _data.SetRightsHolderStatement();
            copyright.Text = _data.RightsStatement;
            _userAction = saveUserAction;
        }

        protected void SetPublisherUrl()
        {
            var saveUserAction = _userAction;
            _userAction = false;
            _data.SetRightsHolderUrl();
            publisherUrl.Text = _data.PublisherUrl;
            _userAction = saveUserAction;
        }

        protected void SetPublisherFacebook()
        {
            var saveUserAction = _userAction;
            _userAction = false;
            _data.SetRightsHolderFacebook();
            publisherFacebook.Text = _data.PublisherFacebook;
            _userAction = saveUserAction;
        }

        private void Review_Load(object sender, EventArgs e)
        {
            confidential.Checked = _data.Confidential == "true";
            title.Text = _data.Title;
            scope.Text = _data.Scope;
            dateCompleted.Text = _data.DateCompleted;
            reapUrl.Text = _data.ReapUrl;
			translationType.Text = _data.TranslationType;
            languageCode.Text = _data.LanguageCode;
            languageName.Text = _data.LanguageName;
            script.Text = _data.Script;
            scriptDirection.Text = _data.ScriptDirection;
			uiLanguage.Text = _data.Ldml;
			dialect.Text = _data.Rod;
			numeralScript.Text = _data.NumeralScript;
            countryCode.Text = _data.CountryCode;
            countryName.Text = _data.CountryName;
            abbreviation.Text = _data.Abbreviation;
			description.Text = _data.Description;
            publisher.Text = _data.Publisher;
            publisherUrl.Text = _data.PublisherUrl;
            publisherFacebook.Text = _data.PublisherFacebook;
			copyright.Text = _data.RightsStatement;
            promoInfo.Text = _data.PromoInfo;
            promoEmail.Text = _data.PromoEmail;
            PubDescTextBox.Text = _data.PublicationDescription;
            uiLanguage.Items.AddRange(_data.Options.Ldmls().ToArray());
            publisher.Items.AddRange(_data.publishers().ToArray());
            publisherUrl.Items.AddRange(_data.publisherUrls().ToArray());
            publisherFacebook.Items.AddRange(_data.publisherFacebooks().ToArray());
            _userAction = true;
        }

        private void PreviewInfo_Click(object sender, EventArgs e)
        {
            Preview(promoInfo.Text);
        }

        protected void Preview(string text)
        {
            var xml = new XmlDocument{XmlResolver = null};
            xml.LoadXml("<root/>");
            var node = xml.SelectSingleNode("/root");
            try
            {
                node.InnerXml = text;
            }
            catch (Exception)
            {
                MessageBox.Show("Promo Info Html is not well formed xml");
                return;
            }
            var previewDialog = new PromoPreview();
            previewDialog.XmlData = "<html><body>" + text + "</body></html>";
            previewDialog.ShowDialog();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            _data.PublicationDescription = PubDescTextBox.Text;
            _data.ResetPromoStatements();
            promoInfo.Text = _data.PromoInfo;
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
            if (!_userSetPromoEmail)
                SetPromoEmail();
        }

        private void languageCode_TextChanged(object sender, EventArgs e)
        {
            _data.LanguageCode = languageCode.Text;
            if (!_userSetAbbreviation)
                SetAbbreviation();
        }

        private void languageName_TextChanged(object sender, EventArgs e)
        {
            _data.LanguageName = languageName.Text;
            if (!_userSetDescription)
                SetDescription();
        }

        private void abbreviation_TextChanged(object sender, EventArgs e)
        {
            _data.Abbreviation = abbreviation.Text;
            if (_userAction)
                _userSetAbbreviation = true;
        }

        private void dateCompleted_TextChanged(object sender, EventArgs e)
        {
            _data.DateCompleted = dateCompleted.Text;
            if (!_userSetRightsStatment)
                SetRightsStatement();

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

        private void PubDescTextBox_TextChanged(object sender, EventArgs e)
        {
            _data.PublicationDescription = PubDescTextBox.Text;
        }

        private void script_TextChanged(object sender, EventArgs e)
        {
            _data.Script = script.Text;
        }

        private void scriptDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            _data.ScriptDirection = scriptDirection.Text;
        }

        private void publisherUrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            publisherUrl_Changed();
        }

        private void publisherUrl_Changed()
        {
            _data.PublisherUrl = publisherUrl.Text;
            if (_userAction)
                _userSetPublisherUrl = true;
        }

        private void publisherFacebook_SelectedIndexChanged(object sender, EventArgs e)
        {
            publisherFacebook_Changed();
        }

        private void publisherFacebook_Changed()
        {
            _data.PublisherFacebook = publisherFacebook.Text;
            if (_userAction)
                _userSetPublisherFacebook = true;
        }

        private void publisher_SelectedIndexChanged(object sender, EventArgs e)
        {
            publisher_Changed();
        }

        private void publisher_Changed()
        {
            _data.Publisher = publisher.Text;
            _data.SetRightsHolder();
            if (!_userSetRightsStatment)
                SetRightsStatement();
            if (!_userSetPublisherUrl)
                SetPublisherUrl();
            if (!_userSetPublisherFacebook)
                SetPublisherFacebook();
        }

        private void confidential_CheckedChanged(object sender, EventArgs e)
        {
            _data.Confidential = confidential.Checked ? "true" : "false";
        }

        private void scope_SelectedIndexChanged(object sender, EventArgs e)
        {
            scope_Changed();
        }

        protected void scope_Changed()
        {
            _data.Scope = scope.Text;
            if (!_userSetAbbreviation)
                SetAbbreviation();
            if (!_userSetDescription)
                SetDescription();
        }

        private void translationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            translationType_Changed();
        }

        protected void translationType_Changed()
        {
            _data.TranslationType = translationType.Text;
            if (!_userSetDescription)
                SetDescription();
        }

        private void uiLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            uiLanguage_Changed();
        }

        protected void uiLanguage_Changed()
        {
            _data.Ldml = uiLanguage.Text;
            if (!_userSetPromoEmail)
                SetPromoEmail();
        }

        private void dialect_TextChanged(object sender, EventArgs e)
        {
            _data.Rod = dialect.Text;
            if (!_userSetDescription)
                SetDescription();
        }

        private void numeralScript_TextChanged(object sender, EventArgs e)
        {
            _data.NumeralScript = numeralScript.Text;
        }

        private void description_TextChanged(object sender, EventArgs e)
        {
            _data.Description = description.Text;
            if (!_userSetPromoEmail)
                _data.SetPromoEmail();
            if (_userAction)
                _userSetDescription = true;
        }

        private void copyright_TextChanged(object sender, EventArgs e)
        {
            _data.RightsStatement = copyright.Text;
            if (_userAction)
                _userSetRightsStatment = true;
        }

        private void promoEmail_TextChanged(object sender, EventArgs e)
        {
            _data.PromoEmail = promoEmail.Text;
            if (_userAction)
                _userSetPromoEmail = true;
        }

        private void promoInfo_TextChanged(object sender, EventArgs e)
        {
            _data.PromoInfo = promoInfo.Text;
        }

        private void previewEmail_Click(object sender, EventArgs e)
        {
            Preview(promoEmail.Text);
        }

        private void publisherUrl_TextChanged(object sender, EventArgs e)
        {
            publisherUrl_Changed();
        }

        private void publisherFacebook_TextChanged(object sender, EventArgs e)
        {
            publisherFacebook_Changed();
        }

        private void publisher_TextChanged(object sender, EventArgs e)
        {
            publisher_Changed();
        }

        private void uiLanguage_TextChanged(object sender, EventArgs e)
        {
            uiLanguage_Changed();
        }

        private void translationType_TextChanged(object sender, EventArgs e)
        {
            translationType_Changed();
        }

        private void scope_TextChanged(object sender, EventArgs e)
        {
            scope_Changed();
        }
    }
}
