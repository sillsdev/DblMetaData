// ---------------------------------------------------------------------------------------------
#region // Copyright (c) 2012, SIL International. All Rights Reserved.
// <copyright from='2012' to='2012' company='SIL International'>
//		Copyright (c) 2012, SIL International. All Rights Reserved.
//
//		Distributable under the terms of either the Common Public License or the
//		GNU Lesser General Public License, as specified in the LICENSING.txt file.
// </copyright>
#endregion
//
// File: Options.cs
// Responsibility: Trihus
// ---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace DblMetaData
{
    public partial class Options : Form
    {
        #region AlwaysNT
        private bool _alwaysUseNT;
        public bool AlwaysUseNT
        {
            get { return _alwaysUseNT; }
            set { _alwaysUseNT = value; }
        }
        #endregion AlwaysNT

        #region PublisherRights
        private bool _publisherRights;
        public bool PublisherRights
        {
            get { return _publisherRights; }
            set { _publisherRights = value; }
        }
        #endregion PublisherRights

        #region AllowOffline
        private bool _allowOffline;
        public bool AllowOffline
        {
            get { return _allowOffline; }
            set { _allowOffline = value; }
        }
        #endregion AllowOffline

        #region AllowIntroductions
        private bool _allowIntroductions;
        public bool AllowIntroductions
        {
            get { return _allowIntroductions; }
            set { _allowIntroductions = value; }
        }
        #endregion AllowIntroductions

        #region AllowFootnotes
        private bool _allowFootnotes;
        public bool AllowFootnotes
        {
            get { return _allowFootnotes; }
            set { _allowFootnotes = value; }
        }
        #endregion AllowFootnotes

        #region AllowCrossReferences
        private bool _allowCrossReferences;
        public bool AllowCrossReferences
        {
            get { return _allowCrossReferences; }
            set { _allowCrossReferences = value; }
        }
        #endregion AllowCrossReferences

        #region AllowExtendedNotes
        private bool _allowExtendedNotes;
        public bool AllowExtendedNotes
        {
            get { return _allowExtendedNotes; }
            set { _allowExtendedNotes = value; }
        }
        #endregion AllowExtendedNotes

        #region TransAgency
        private string _translationAgency;
        public string TransAgency 
        {
            get { return _translationAgency; }
            set { _translationAgency = value; }
        }
        #endregion TransAgency

        #region LocalRightsHolder
        private string _localRightsHolder;
        public string LocalRights
        {
            get { return _localRightsHolder; }
            set { _localRightsHolder = value; }
        }
        #endregion TransAgency

        #region PromoEmail
        private string _promoEmail;
        public string PromoEmail
        {
            get { return _promoEmail; }
            set { _promoEmail = value; }
        }
        #endregion PromoEmail

        private string _optionsName;
        private readonly XmlDocument _optionsDoc = new XmlDocument();

        public Options()
        {
            InitializeComponent();
            _optionsName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                           @"SIL\DblDataPrep\Options.xml");
            _optionsDoc.XmlResolver = null;
            if (File.Exists(_optionsName))
                _optionsDoc.Load(_optionsName);
            else
            {
                _optionsDoc.Load(XmlReader.Create(Assembly.GetExecutingAssembly().GetManifestResourceStream("DblMetaData.Options.xml")));
            }
            Migrate();
            _alwaysUseNT = ReadBooleanValue("//NTscope");
            _publisherRights = ReadBooleanValue("//publisherHoldsRights");
            _allowOffline = ReadBooleanValue("//allowOffline");
            _allowIntroductions = ReadBooleanValue("//allowIntroductions");
            _allowFootnotes = ReadBooleanValue("//allowFootnotes");
            _allowCrossReferences = ReadBooleanValue("//allowCrossReferences");
            _allowExtendedNotes = ReadBooleanValue("//allowExtendedNotes");
            var translationAgencyNode = _optionsDoc.SelectSingleNode("//translationAgency");
            Debug.Assert(translationAgencyNode != null);
            _translationAgency = translationAgencyNode.InnerText.Trim();
            var localRightsHolderNode = _optionsDoc.SelectSingleNode("//localRightsHolder");
            Debug.Assert(localRightsHolderNode != null);
            _localRightsHolder = localRightsHolderNode.InnerText.Trim();
            _promoEmail = PromoEmailText("en");
        }

        private bool ReadBooleanValue(string xpath)
        {
            var node = _optionsDoc.SelectSingleNode(xpath);
            Debug.Assert(node != null);
            return node.InnerText.Trim().ToLower() == "true";
        }

        private void Migrate()
        {
            Debug.Assert(_optionsDoc != null);
            var versionNode = _optionsDoc.DocumentElement.SelectSingleNode("@version");
            Debug.Assert(versionNode != null);
            var version = int.Parse(versionNode.InnerText);
            if (version == 1)
            {
                Debug.Assert(_optionsDoc.DocumentElement != null, "_optionsDoc.DocumentElement != null");
                _optionsDoc.DocumentElement.AppendChild(NewXmlNode("allowOffline", "true"));
                _optionsDoc.DocumentElement.AppendChild(NewXmlNode("allowIntroductions", "true"));
                _optionsDoc.DocumentElement.AppendChild(NewXmlNode("allowFootnotes", "true"));
                _optionsDoc.DocumentElement.AppendChild(NewXmlNode("allowCrossReferences", "true"));
                _optionsDoc.DocumentElement.AppendChild(NewXmlNode("allowExtendedNotes", "false"));
                versionNode.InnerText = "2";
                version = 2;
            }
            if (version == 2)
            {
                Debug.Assert(_optionsDoc.DocumentElement != null, "_optionsDoc.DocumentElement != null");
                _optionsDoc.DocumentElement.AppendChild(NewXmlNode("localRightsHolder", ""));
                versionNode.InnerText = "3";
                version = 3;
            }
            if (version == 3)
            {
                Debug.Assert(_optionsDoc.DocumentElement != null, "_optionsDoc.DocumentElement != null");
                var transAgency = _optionsDoc.SelectSingleNode("//translationAgency");
                Debug.Assert(transAgency != null);
                if (transAgency.InnerText == "Wycliffe Inc.")
                    transAgency.InnerText = "Wycliffe";
                var email = _optionsDoc.SelectSingleNode("//email");
                Debug.Assert(email != null);
                if (email.InnerXml.Contains("Wycliffe Inc."))
                    email.InnerXml = email.InnerXml.Replace("Wycliffe Inc.", "Wycliffe");
                versionNode.InnerText = "4";
                version = 4;
            }
        }

        private XmlElement NewXmlNode(string name, string value)
        {
            var node = _optionsDoc.CreateElement(name);
            node.InnerText = value;
            return node;
        }

        public string PromoEmailText(string lang)
        {
            var emailNode = _optionsDoc.SelectSingleNode(string.Format("//email[@lang='{0}']", lang));
            if (emailNode == null)
                emailNode = _optionsDoc.SelectSingleNode("//email[@lang='en']");
            Debug.Assert(emailNode != null);
            return emailNode.InnerXml;
        }

        public List<string> Ldmls()
        {
            var results = _optionsDoc.SelectNodes("//email/@lang");
            Debug.Assert(results != null);
            return (from XmlNode node in results select node.InnerText).ToList();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            AlwaysNT.Checked = _alwaysUseNT;
            TranslationAgency.Text = _translationAgency;
            LocalRightsHolder.Text = _localRightsHolder;
            Ldml.Items.AddRange(Ldmls().ToArray());
            Ldml.SelectedIndex = 0;
            Email.Text = _promoEmail;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var dirName = Path.GetDirectoryName(_optionsName);
            if (!Directory.Exists(dirName))
                Directory.CreateDirectory(dirName);
            _optionsDoc.Save(_optionsName);
        }

        private void AlwaysNT_CheckedChanged(object sender, EventArgs e)
        {
            _alwaysUseNT = AlwaysNT.Checked;
            var ntScopeNode = _optionsDoc.SelectSingleNode("//NTscope");
            Debug.Assert(ntScopeNode != null);
            ntScopeNode.InnerText = _alwaysUseNT? "true": "false";
        }

        private void TranslationAgency_TextChanged(object sender, EventArgs e)
        {
            _translationAgency = TranslationAgency.Text;
            var translationAgencyNode = _optionsDoc.SelectSingleNode("//translationAgency");
            Debug.Assert(translationAgencyNode != null);
            translationAgencyNode.InnerText = _translationAgency;
        }

        private void Email_TextChanged(object sender, EventArgs e)
        {
            var lang = Ldml.Items[Ldml.SelectedIndex].ToString();
            XmlNode xmlNode = _optionsDoc.SelectSingleNode(string.Format("//email[@lang='{0}']", lang));
            if (xmlNode == null)
            {
                xmlNode = _optionsDoc.CreateElement("email");
                var attr = _optionsDoc.CreateAttribute("lang");
                attr.Value = lang;
                Debug.Assert(xmlNode.Attributes != null);
                xmlNode.Attributes.Append(attr);
                Debug.Assert(_optionsDoc.DocumentElement != null);
                _optionsDoc.DocumentElement.AppendChild(xmlNode);
            }
            xmlNode.InnerXml = Email.Text;
        }

        private void PublisherHoldsRights_CheckedChanged(object sender, EventArgs e)
        {
            _publisherRights = PublisherHoldsRights.Checked;
        }

        private void AllowOfflineCb_CheckedChanged(object sender, EventArgs e)
        {
            _allowOffline = AllowOfflineCb.Checked;
        }

        private void AllowIntroductionsCb_CheckedChanged(object sender, EventArgs e)
        {
            _allowIntroductions = AllowIntroductionsCb.Checked;
        }

        private void AllowFootnotesCb_CheckedChanged(object sender, EventArgs e)
        {
            _allowFootnotes = AllowFootnotesCb.Checked;
        }

        private void AllowCrossReferencesCb_CheckedChanged(object sender, EventArgs e)
        {
            _allowCrossReferences = AllowCrossReferencesCb.Checked;
        }

        private void AllowExtendedNotesCb_CheckedChanged(object sender, EventArgs e)
        {
            _allowExtendedNotes = AllowExtendedNotesCb.Checked;
        }

        private void LocalRightsHolder_TextChanged(object sender, EventArgs e)
        {
            _localRightsHolder = LocalRightsHolder.Text;
            var localRightsHolderNode = _optionsDoc.SelectSingleNode("//localRightsHolder");
            Debug.Assert(localRightsHolderNode != null);
            localRightsHolderNode.InnerText = _localRightsHolder;
        }
    }
}
