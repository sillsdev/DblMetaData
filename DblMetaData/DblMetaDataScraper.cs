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
// File: DblMetaDataScraper.cs
// Responsibility: Trihus
// ---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace DblMetaData
{
    public class DblMetaDataScraper
    {
        #region Properties
        #region Title
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        #endregion Title

        #region LanguageCode
        private string _languageCode;
        public string LanguageCode
        {
            get { return _languageCode; }
            set { _languageCode = value; }
        }
        #endregion LanguageCode

        #region LanguageName
        private string _languageName;
        public string LanguageName
        {
            get { return _languageName; }
            set { _languageName = value; }
        }
        #endregion LanguageName

        #region Scope
        private string _scope;
        public string Scope
        {
            get { return _scope; }
            set { _scope = value; }
        }
        #endregion Scope

        #region Confidential
        private string _confidential;
        public string Confidential
        {
            get { return _confidential; }
            set { _confidential = value; }
        }
        #endregion Confidential

        #region DateCompleted
        private string _dateCompleted;
        public string DateCompleted
        {
            get { return _dateCompleted; }
            set { _dateCompleted = value; }
        }
        #endregion DateCompleted

        #region Publisher
        private string _publisher;
        public string Publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
        }
        #endregion Publisher

        #region ReapUrl
        private string _reapUrl;
        public string ReapUrl
        {
            get { return _reapUrl; }
            set { _reapUrl = value; }
        }
        #endregion ReapUrl

        #region CountryCode
        private string _countryCode;
        public string CountryCode
        {
            get { return _countryCode; }
            set { _countryCode = value; }
        }
        #endregion CountryCode

        #region CountryName
        private string _countryName;
        public string CountryName
        {
            get { return _countryName; }
            set { _countryName = value; }
        }
        #endregion CountryName

        #region Edition
        private string _edition;
        public string Edition
        {
            get { return _edition; }
            set { _edition = value; }
        }
        #endregion Edition

        #region EditionType
        private string _editionType;
        public string EditionType
        {
            get { return _editionType; }
            set { _editionType = value; }
        }
        #endregion EditionType

        #region Range
        private string _range;
        public string Range
        {
            get { return _range; }
            set { _range = value; }
        }
        #endregion Range

        #region RangeDescription
        private string _rangeDescription;
        public string RangeDescription
        {
            get { return _rangeDescription; }
            set { _rangeDescription = value; }
        }
        #endregion RangeDescription
#endregion Properties

        private XmlDocument _webDoc;
        private XmlNamespaceManager _namespaceManager;

        private XmlDocument _dblMetaDataDoc;

        public DblMetaDataScraper()
        {
            _webDoc = new XmlDocument {XmlResolver = null};
            _namespaceManager = new XmlNamespaceManager(_webDoc.NameTable);
            _namespaceManager.AddNamespace("default", "http://www.w3.org/1999/xhtml");
            _namespaceManager.AddNamespace("fn", "http://www.w3.org/2005/xpath-functions");
            _dblMetaDataDoc = new XmlDocument();
            _dblMetaDataDoc.LoadXml(_dblMetaData);
        }

        public void Load(string webDocText)
        {
            _webDoc.LoadXml(webDocText);
        }

        private const string _dblMetaData = @"<?xml version=""1.0"" encoding=""utf-8""?>
<?oxygen RNGSchema=""metadata.rnc"" type=""compact""?>
<DBLScriptureProject resourceURI="""" xml:base=""http://purl.org/ubs/metadata/dc/terms/"" xmlns:dcds=""http://purl.org/dc/xmlns/2008/09/01/dc-ds-xml/"">
  <identification>
    <systemId type=""dbl"" dcds:propertyURI=""identifier/dblID""/>
    <name dcds:propertyURI=""title"">Da Jesus book</name>
    <nameLocal>Da Jesus book</nameLocal>
    <abbreviation>hwc</abbreviation>
    <abbreviationLocal>hwc</abbreviationLocal>
    <scope dcds:propertyURI=""title/scriptureScope"">WNT:New Testament</scope>
    <description dcds:propertyURI=""description"">1st ed.</description>
    <dateCompleted dcds:propertyURI=""date"" dcds:sesURI=""http://purl.org/dc/terms/W3CDTF"">2000</dateCompleted>
    <systemId type=""tms"" dcds:propertyURI=""identifier/tmsID""/>
    <systemId type=""reap"" dcds:propertyURI=""identifier/reapID"" >http://www.reap.insitehome.org/handle/9284745/16286</systemId>
    <systemId type=""paratext"" dcds:propertyURI=""identifier/ptxID""/>
    <isResource>No</isResource>
    <bundleVersion>1.1</bundleVersion>
    <bundleProducer/>
  </identification>
  <confidential dcds:propertyURI=""accessRights/confidential"">No</confidential>
  <agencies>
    <etenPartner>WBT</etenPartner>
    <translation dcds:propertyURI=""description/sponsorship"">Wycliffe Bible Translators</translation>
    <publishing dcds:propertyURI=""publisher"">Wycliffe Bible Translators</publishing>
  </agencies>
  <language>
    <iso dcds:propertyURI=""language/iso"" dcds:sesURI=""http://purl.org/dc/terms/ISO639-3"">hwc</iso>
    <name dcds:propertyURI=""subject/subjectLanguage"" dcds:sesURI=""http://purl.org/dc/terms/ISO639-3"">Hawai'i Creole English</name>
    <script dcds:propertyURI=""language/script"">Latin</script>
    <scriptDirection dcds:propertyURI=""language/scriptDirection"">LTR</scriptDirection>
  </language>
  <country>
    <iso dcds:propertyURI=""coverage/spatial"" dcds:sesURI=""http://purl.org/dc/terms/ISO3166"">US</iso>
    <name dcds:propertyURI=""subject/subjectCountry"">United States</name>
  </country>
  <translation>
    <type dcds:propertyURI=""type/translationType"">New</type>
    <level dcds:propertyURI=""audience"">Common</level>
  </translation>
  <bookNames/>
  <contents dcds:propertyURI=""tableOfContents"">
    <bookList id=""default"">
      <name>Da Jesus book</name>
      <nameLocal>Da Jesus book</nameLocal>
      <abbreviation>hwc</abbreviation>
      <abbreviationLocal>hwc</abbreviationLocal>
      <description>NT: 1st ed.</description>
      <range>Protestant New Testament (27 books)</range>
      <tradition>Western Protestant order</tradition>
      <division id=""NT"">
        <books>
          <book code=""MAT"" />
          <book code=""MRK"" />
          <book code=""LUK"" />
          <book code=""JHN"" />
          <book code=""ACT"" />
          <book code=""ROM"" />
          <book code=""1CO"" />
          <book code=""2CO"" />
          <book code=""GAL"" />
          <book code=""EPH"" />
          <book code=""PHP"" />
          <book code=""COL"" />
          <book code=""1TH"" />
          <book code=""2TH"" />
          <book code=""1TI"" />
          <book code=""2TI"" />
          <book code=""TIT"" />
          <book code=""PHM"" />
          <book code=""HEB"" />
          <book code=""JAS"" />
          <book code=""1PE"" />
          <book code=""2PE"" />
          <book code=""1JN"" />
          <book code=""2JN"" />
          <book code=""3JN"" />
          <book code=""JUD"" />
          <book code=""REV"" />
        </books>
      </division>
    </bookList>
  </contents>
  <progress dcds:propertyURI=""description/stage""/>
  <checking>
    <validatedMarkers dcds:propertyURI=""conformsTo/validatedMarkers"">Yes</validatedMarkers>
    <validatedVerses dcds:propertyURI=""conformsTo/validatedVerses"">Yes</validatedVerses>
  </checking>
  <contact>
    <rightsHolder dcds:propertyURI=""rightsHolder"">Wycliffe Bible Translators</rightsHolder>
    <rightsHolderLocal dcds:propertyURI=""rightsHolder/contactLocal"">Wycliffe Bible Translators</rightsHolderLocal>
    <rightsHolderAbbreviation dcds:propertyURI=""rightsHolder/contactAbbreviation"">WBT</rightsHolderAbbreviation>
    <rightsHolderURL dcds:propertyURI=""rightsHolder/contactURL"">http://www.wycliffe.org</rightsHolderURL>
    <rightsHolderFacebook dcds:propertyURI=""rightsHolder/contactFacebook"">http://www.facebook.com/WycliffeUSA</rightsHolderFacebook>
  </contact>
  <rights>
    <dateLicense dcds:propertyURI=""accessRights/pubLicenseDate"" dcds:sesURI=""http://purl.org/dc/terms/W3CDTF"">2011-06-22</dateLicense>
    <dateLicenseExpiry dcds:propertyURI=""accessRights/pubLicenseExpiryDate"" dcds:sesURI=""http://purl.org/dc/terms/W3CDTF"">2014-06-22</dateLicenseExpiry>
    <rightsStatement dcds:propertyURI=""rights"" contentType=""xhtml"">©2000 Wycliffe Bible Translators, All Rights Reserved.</rightsStatement>
    <publicationRights>
      <allowOffline>Yes</allowOffline>
      <allowAudio>Yes</allowAudio>
      <allowFootnotes>Yes</allowFootnotes>
      <allowCrossReferences>Yes</allowCrossReferences>
      <allowNewPublishers>No</allowNewPublishers>
      <denyPlatforms />
      <exchangeLicenseFCBH>No</exchangeLicenseFCBH>
    </publicationRights>
  </rights>
  <promotion>
    <promoVersionInfo dcds:propertyURI=""description/pubPromoVersionInfo"" contentType=""xhtml""></promoVersionInfo>
    <promoEmail dcds:propertyURI=""description/pubPromoEmail""></promoEmail>
  </promotion>
  <archiveStatus>
    <archivistName dcds:propertyURI=""contributor/archivist""/>
    <dateArchived dcds:propertyURI=""dateSubmitted"" dcds:sesURI=""http://purl.org/dc/terms/W3CDTF"">2011-09-29</dateArchived>
    <dateUpdated dcds:propertyURI=""modified"" dcds:sesURI=""http://purl.org/dc/terms/W3CDTF"">2011-09-29</dateUpdated>
    <comments dcds:propertyURI=""abstract""/>
  </archiveStatus>
  <format dcds:propertyURI=""format"" dcds:sesURI=""http://purl.org/dc/terms/IMT"">text/xml</format>
</DBLScriptureProject>";

        List<string> _firstList = new List<string> {"1st", "first", "[1st]"};

        public void ScrapeReapData()
        {
            _title = GetValue("//default:title");
            _languageCode = GetField("//default:meta[@name='DC.language'][1]/@content", 0);
            _languageName = GetField("//default:meta[@name='DC.language'][1]/@content", 1);
            _scope = GetValue("//default:tr[default:td='dc.title.scriptureScope']/default:td[2]");
            _confidential = GetValue("//default:tr[default:td='sil.sensitivity.metadata']/default:td[2]").ToLower() == "public" ? "No" : "Yes";
            _dateCompleted = GetValue("//default:meta[@name='DCTERMS.issued']/@content");
            _publisher = GetValue("//default:meta[@name='DC.publisher'][1]/@content");
            _reapUrl = GetValue("//default:tr[default:td='dc.identifier.uri']/default:td[2]");
            _countryCode = GetField("//default:meta[@name='DCTERMS.spatial'][1]/@content", 0);
            _countryName = GetField("//default:meta[@name='DCTERMS.spatial'][1]/@content", 1);
            _edition = GetValue("//default:tr[default:td='dc.description.edition']/default:td[2]");
            var valueWords = _edition.Split(' ');
            _editionType = valueWords.Contains(valueWords[0]) ? "New": "<><> Check Edition <><>";
            var range = TextField(_scope, 0) == "WNT" ? "NT" : "<><> Check Range <><>";
            _range = range + ":" + _edition;
            _rangeDescription = TextField(_scope, 1);
        }

        public void InsertDataInDblMetaData(string publicationDescription)
        {
            SetValue(_title, "/DBLScriptureProject/identification/name");
            SetValue(_title, "/DBLScriptureProject/identification/nameLocal");
            SetValue(_title, "/DBLScriptureProject/contents/bookList/name");
            SetValue(_title, "/DBLScriptureProject/contents/bookList/nameLocal");
            SetValue(_languageCode, "/DBLScriptureProject/identification/abbreviation");
            SetValue(_languageCode, "/DBLScriptureProject/identification/abbreviationLocal");
            SetValue(_languageCode, "/DBLScriptureProject/language/iso");
            SetValue(_languageCode, "/DBLScriptureProject/contents/bookList/abbreviation");
            SetValue(_languageCode, "/DBLScriptureProject/contents/bookList/abbreviationLocal");
            SetValue(_languageName, "/DBLScriptureProject/language/name");
            SetValue(_scope, "/DBLScriptureProject/identification/scope");
            SetValue(_confidential, "/DBLScriptureProject/confidential");
            SetValue(_dateCompleted, "/DBLScriptureProject/identification/dateCompleted");
            SetValue(_reapUrl, "/DBLScriptureProject/identification/systemId[@type='reap']");
            SetValue(_publisher, "/DBLScriptureProject/agencies/translation");
            SetValue(_publisher, "/DBLScriptureProject/agencies/publishing");
            SetValue(_publisher, "/DBLScriptureProject/contact/rightsHolder");
            SetValue(_publisher, "/DBLScriptureProject/contact/rightsHolderLocal");
            SetValue(_countryCode, "/DBLScriptureProject/country/iso");
            SetValue(_countryName, "/DBLScriptureProject/country/name");
            SetValue(_editionType, "/DBLScriptureProject/translation/type");
            SetValue(_range, "/DBLScriptureProject/contents/bookList/description");
            if (_publisher != "Wycliffe Bible Translators")
            {
                SetValue("<><> Publisher Email <><>", "/DBLScriptureProject/contact/rightsHolderURL");
                SetValue("<><> Publisher Facebook <><>", "/DBLScriptureProject/contact/rightsHolderFacebook");
            }
            string rightsStatement = "©" + _publisher + " " + _dateCompleted;
            SetValue(rightsStatement, "/DBLScriptureProject/rights/rightsStatement");
            if (_confidential == "No")
            {
                var promoStatements = new PromoStatements();
                if (publicationDescription.Trim().Length > 0)
                    promoStatements.AddParagraph(publicationDescription);
                promoStatements.AddParagraph(rightsStatement);
                promoStatements.AddLicense();
                promoStatements.AddDescription(_edition, _rangeDescription, _languageName);
                SetXmlValue(promoStatements.ToHtml(), "/DBLScriptureProject/promotion/promoVersionInfo");
                SetValue(promoStatements.ToEscapedString(), "/DBLScriptureProject/promotion/promoEmail");
            }
        }

        private void SetValue(string value, string xpath)
        {
            XmlNode xmlNode = _dblMetaDataDoc.SelectSingleNode(xpath);
            xmlNode.InnerText = value;
        }

        private void SetXmlValue(string value, string xpath)
        {
            XmlNode xmlNode = _dblMetaDataDoc.SelectSingleNode(xpath);
            xmlNode.InnerXml = value;
        }

        private string GetValue(string xpath)
        {
            XmlNode xmlNode = _webDoc.SelectSingleNode(xpath, _namespaceManager);
            if (xmlNode != null)
                return xmlNode.InnerText;
            return "<><> Value not found <><>";
        }

        private string GetField(string xpath, int i)
        {
            string value = GetValue(xpath);
            var fields = value.Split(':');
            return fields[i];
        }

        private string TextField(string value, int i)
        {
            var fields = value.Split(':');
            return fields[i];
        }


        //TODO: Copy script name to /DBLScriptureProject/language/script
        //TODO: Copy script direction to /DBLScriptureProject/language/scriptDirection

        internal void Save(string p)
        {
            var sw = new StreamWriter(p);
            var xw = XmlWriter.Create(sw);
            _dblMetaDataDoc.WriteContentTo(xw);
            xw.Close();
            sw.Close();
        }

        internal string GetDefaultName()
        {
            return _languageCode + "MetaData";
        }
    }
}
