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

        #region TransAgency
        private string _translationAgency;
        public string TransAgency 
        {
            get { return _translationAgency; }
            set { _translationAgency = value; }
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
            var ntScopeNode = _optionsDoc.SelectSingleNode("//NTscope");
            Debug.Assert(ntScopeNode != null);
            var ntScope = ntScopeNode.InnerText.Trim().ToLower();
            _alwaysUseNT = (ntScope == "true");
            var publisherRights = _optionsDoc.SelectSingleNode("//publisherHoldsRights");
            Debug.Assert(publisherRights != null);
            _publisherRights = publisherRights.InnerText.Trim().ToLower() == "true";
            var translationAgencyNode = _optionsDoc.SelectSingleNode("//translationAgency");
            Debug.Assert(translationAgencyNode != null);
            _translationAgency = translationAgencyNode.InnerText.Trim();
            _promoEmail = PromoEmailText("en");
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
    }
}
