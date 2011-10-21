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
// File: DblMetaDataScraper.cs
// Responsibility: Trihus
// ---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
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

        #region Abbreviation
        private string _abbreviation;
        public string Abbreviation
        {
            get { return _abbreviation; }
            set { _abbreviation = value; }
        }
        #endregion Abbreviation

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

        #region PublisherUrl
        private string _publisherUrl;
        public string PublisherUrl
        {
            get { return _publisherUrl; }
            set { _publisherUrl = value; }
        }
        #endregion PublisherUrl

        #region PublisherFacebook
        private string _publisherFacebook;
        public string PublisherFacebook
        {
            get { return _publisherFacebook; }
            set { _publisherFacebook = value; }
        }
        #endregion PublisherFacebook

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

        #region RightsStatement
        private string _rightsStatement;
        public string RightsStatement
        {
            get { return _rightsStatement; }
            set { _rightsStatement = value; }
        }
        #endregion RightsStatement

        #region PromoInfo
        private string _promoInfo;
        public string PromoInfo
        {
            get { return _promoInfo; }
            set { _promoInfo = value; }
        }
        #endregion PromoInfo

        #region PromoEmail
        private string _promoEmail;
        public string PromoEmail
        {
            get { return _promoEmail; }
            set { _promoEmail = value; }
        }
        #endregion PromoEmail

        #region PublicationDescription
        private string _publicationDescription;
        public string PublicationDescription
        {
            get { return _publicationDescription; }
            set { _publicationDescription = value; }
        }
        #endregion PublicationDescription
#endregion Properties

        private readonly XmlDocument _webDoc;
        private readonly XmlNamespaceManager _namespaceManager;

        private readonly XmlDocument _dblMetaDataDoc;

        private readonly XmlDocument _publisherDoc;

        public DblMetaDataScraper()
        {
            _webDoc = new XmlDocument {XmlResolver = null};
            _namespaceManager = new XmlNamespaceManager(_webDoc.NameTable);
            _namespaceManager.AddNamespace("default", "http://www.w3.org/1999/xhtml");
            //_namespaceManager.AddNamespace("fn", "http://www.w3.org/2005/xpath-functions");
            _dblMetaDataDoc = new XmlDocument();
            _dblMetaDataDoc.LoadXml(_dblMetaData);
            _publisherDoc = new XmlDocument();
            _publisherDoc.LoadXml(_publisherData);
        }

        public void Load(string webDocText)
        {
            _webDoc.LoadXml(webDocText);
        }

        #region dblMetaData (template)
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
        #endregion dblMetaData (template)

        #region _publisherData
        private readonly string _publisherData = @"
<root>
<publisher name=""Wycliffe Bible Translators"" url=""http://www.wycliffe.org"" fb=""http://www.facebook.com/WycliffeUSA""/>
<publisher name=""La Liga Bíblica"" url=""http://www.bibleleague.org/"" fb=""http://www.facebook.com/BibleLeagueInternational""/>
<!-- publisher name="" url="" fb=""/ -->
</root>
";
        #endregion _publisherData

        readonly List<string> _firstList = new List<string> { "1st", "first", "[1st]" };

        public void ScrapeReapData()
        {
            _title = GetValue("//default:title");
            _languageCode = GetField("//default:meta[@name='DC.language'][1]/@content", 0);
            _languageName = GetField("//default:meta[@name='DC.language'][1]/@content", 1);
            _scope = GetValue("//default:tr[default:td='dc.title.scriptureScope']/default:td[2]");
            _abbreviation = _languageCode + "-" + TextField(_scope, 0).Substring(1);
            _confidential = GetValue("//default:tr[default:td='sil.sensitivity.metadata']/default:td[2]").ToLower() == "public" ? "No" : "Yes";
            _dateCompleted = GetValue("//default:meta[@name='DCTERMS.issued']/@content");
            _publisher = GetValue("//default:meta[@name='DC.publisher'][1]/@content");
            var publisherUrlNode = _publisherDoc.SelectSingleNode(string.Format("//publisher[@name='{0}']/@url", _publisher));
            if (publisherUrlNode != null)
                _publisherUrl = publisherUrlNode.InnerText;
            else
                _publisherUrl = "<><> Publisher URL <><>";
            var publisherFbNode = _publisherDoc.SelectSingleNode(string.Format("//publisher[@name='{0}']/@fb", _publisher));
            if (publisherFbNode != null)
                _publisherFacebook = publisherFbNode.InnerText;
            else
                _publisherFacebook = "<><> Publisher Facebook <><>";
            _reapUrl = GetValue("//default:tr[default:td='dc.identifier.uri']/default:td[2]");
            _countryCode = GetField("//default:meta[@name='DCTERMS.spatial'][1]/@content", 0);
            _countryName = GetField("//default:meta[@name='DCTERMS.spatial'][1]/@content", 1);
            _range = GetValue("//default:tr[default:td='dc.description.edition']/default:td[2]");
            var valueWords = _range.Split(' ');
            var range = TextField(_scope, 0) == "WNT" ? "NT" : "<><> Check Range <><>";
            _range = range + ":" + _range;
            if (_firstList.Contains(valueWords[0]))
            {
                _editionType = "New";
                _edition = "First edition";
            }
            else
            {
                _editionType = "<><> Check Edition <><>";
                _edition = _range.Replace("ed.", "edition");
            }
            _rangeDescription = TextField(_scope, 1);
            if (_confidential == "No")
            {
                ResetPromoStatements();
            }
            else
            {
                _rightsStatement = "©" + _publisher + " " + _dateCompleted;
                _promoInfo = "<><>No promoVersionInfo<><>";
                _promoEmail = "<><>No promoVersionEmail<><>";
            }
        }

        public void ResetPromoStatements()
        {
            var promoStatements = new PromoStatements();
            if (_publicationDescription != null)
            {
                var trimmedDescription = _publicationDescription.Trim().Replace("\r\n", "<br/>\r\n");
                if (trimmedDescription.Length > 0)
                    promoStatements.AddParagraph(trimmedDescription);
            }
            _rightsStatement = "©" + _publisher + " " + _dateCompleted;
            promoStatements.AddParagraph(_rightsStatement);
            promoStatements.AddLicense();
            promoStatements.AddDescription(_edition, _rangeDescription, _languageName);
            _promoInfo = promoStatements.ToHtml();
            _promoEmail = promoStatements.ToEscapedString();
        }

        public void InsertDataInDblMetaData()
        {
            SetValue(_title, "//identification/name");
            SetValue(_title, "//identification/nameLocal");
            SetValue(_title, "//contents/bookList/name");
            SetValue(_title, "//contents/bookList/nameLocal");
            SetValue(_abbreviation, "//identification/abbreviation");
            SetValue(_abbreviation, "//identification/abbreviationLocal");
            SetValue(_abbreviation, "//contents/bookList/abbreviation");
            SetValue(_abbreviation, "//contents/bookList/abbreviationLocal");
            SetValue(_languageCode, "//language/iso");
            SetValue(_languageName, "//language/name");
            SetValue(_scope, "//identification/scope");
            SetValue(_confidential, "//confidential");
            SetValue(_dateCompleted, "//identification/dateCompleted");
            SetValue(_reapUrl, "//identification/systemId[@type='reap']");
            SetValue(_publisher, "//agencies/translation");
            SetValue(_publisher, "//agencies/publishing");
            SetValue(_publisher, "//contact/rightsHolder");
            SetValue(_publisher, "//contact/rightsHolderLocal");
            SetValue(_countryCode, "//country/iso");
            SetValue(_countryName, "//country/name");
            SetValue(_editionType, "//translation/type");
            SetValue(_range, "//contents/bookList/description");
            SetValue(_publisherUrl, "//contact/rightsHolderURL");
            SetValue(_publisherFacebook, "//contact/rightsHolderFacebook");
            SetValue(_rightsStatement, "//rights/rightsStatement");
            SetXmlValue(_promoInfo, "//promotion/promoVersionInfo");
            SetValue(_promoEmail, "//promotion/promoEmail");
        }

        public List<string> publisherUrls()
        {
            var urls = new List<string>();
            var results = _publisherDoc.SelectNodes("//publisher/@url");
            foreach (XmlNode node in results)
            {
                urls.Add(node.InnerText);
            }
            return urls;
        }

        public List<string> publisherFacebooks()
        {
            var urls = new List<string>();
            var results = _publisherDoc.SelectNodes("//publisher/@fb");
            foreach (XmlNode node in results)
            {
                urls.Add(node.InnerText);
            }
            return urls;
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


        //TODO: Copy script name to //language/script
        //TODO: Copy script direction to //language/scriptDirection

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
