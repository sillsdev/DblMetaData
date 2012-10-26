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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

namespace DblMetaData
{
    public class DblMetaDataScraper
    {
        #region Properties
        #region Confidential
        private string _confidential;
        public string Confidential
        {
            get { return _confidential; }
            set { _confidential = value; }
        }
        #endregion Confidential

        #region Title
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        #endregion Title

        #region Scope
        private string _scope;
        public string Scope
        {
            get { return _scope; }
            set { _scope = value; }
        }
        #endregion Scope

        #region DateCompleted
        private string _dateCompleted;
        public string DateCompleted
        {
            get { return _dateCompleted; }
            set { _dateCompleted = value; }
        }
        #endregion DateCompleted

        #region ReapUrl
        private string _reapUrl;
        public string ReapUrl
        {
            get { return _reapUrl; }
            set { _reapUrl = value; }
        }
        #endregion ReapUrl

        #region TranslationType
        private string _translationType;
        public string TranslationType
        {
            get { return _translationType; }
            set { _translationType = value; }
        }
        #endregion TranslationType

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

        #region Script
        private string _script;
        public string Script
        {
            get { return _script; }
            set { _script = value; }
        }
        #endregion Script

        #region ScriptDirection
        private string _scriptDirection;
        public string ScriptDirection
        {
            get { return _scriptDirection; }
            set { _scriptDirection = value; }
        }
        #endregion ScriptDirection

        #region Ldml
        private string _ldml = "en";
        public string Ldml
        {
            get { return _ldml; }
            set { _ldml = value; }
        }
        #endregion Ldml

        #region Rod - registry of dialects
        private string _rod = string.Empty;
        public string Rod
        {
            get { return _rod; }
            set { _rod = value; }
        }
        #endregion Rod

        #region DialectName
        private string _dialectName = string.Empty;
        public string DialectName
        {
            get { return _dialectName; }
            set { _dialectName = value; }
        }
        #endregion DialectName

        #region NumeralScript
        private string _numeralScript = string.Empty;
        public string NumeralScript
        {
            get { return _numeralScript; }
            set { _numeralScript = value; }
        }
        #endregion NumeralScript

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

        #region Abbreviation
        private string _abbreviation;
        public string Abbreviation
        {
            get { return _abbreviation; }
            set { _abbreviation = value; }
        }
        #endregion Abbreviation

        #region Description
        private string _description = string.Empty;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        #endregion Description

        #region Range
        private string _range = string.Empty;
        public string Range
        {
            get { return _range; }
            set { _range = value; }
        }
        #endregion Range

        #region Publisher
        private string _publisher;
        public string Publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
        }
        #endregion Publisher

        #region Contributor
        private string _contributor;
        public string Contributor
        {
            get { return _contributor; }
            set { _contributor = value; }
        }
        #endregion Contributor

        #region RightsHolder
        private string _rightsHolder;
        public string RightsHolder
        {
            get { return _rightsHolder; }
            set { _rightsHolder = value; }
        }
        #endregion RightsHolder

        #region RightsHolderLocal
        private string _rightsHolderLocal;
        public string RightsHolderLocal
        {
            get { return _rightsHolderLocal; }
            set { _rightsHolderLocal = value; }
        }
        #endregion RightsHolderLocal

        #region RightsHolderAbbr
        private string _rightsHolderAbbr;
        public string RightsHolderAbbr
        {
            get { return _rightsHolderAbbr; }
            set { _rightsHolderAbbr = value; }
        }
        #endregion RightsHolderAbbr

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

        #region RightsStatement
        private string _rightsStatement;
        public string RightsStatement
        {
            get { return _rightsStatement; }
            set { _rightsStatement = value; }
        }
        #endregion RightsStatement

        #region Isbn
        private string _isbn;
        public string Isbn
        {
            get { return _isbn; }
            set { _isbn = value; }
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

        #region Options
        private Options _options;
        public Options Options
        {
            get { return _options; }
            set { _options = value; }
        }
        #endregion Options
        #endregion Properties

        private readonly XmlDocument _webDoc;
        private readonly XmlNamespaceManager _namespaceManager;

        private readonly XmlDocument _dblMetaDataDoc;

        private readonly XmlDocument _publisherDoc;
        private string _publisherDocName;

        public DblMetaDataScraper()
        {
            _webDoc = new XmlDocument {XmlResolver = null};
            _namespaceManager = new XmlNamespaceManager(_webDoc.NameTable);
            _namespaceManager.AddNamespace("default", "http://www.w3.org/1999/xhtml");
            //_namespaceManager.AddNamespace("fn", "http://www.w3.org/2005/xpath-functions");
            _dblMetaDataDoc = new XmlDocument();
            _dblMetaDataDoc.LoadXml(_dblMetaData);
            _publisherDoc = new XmlDocument {XmlResolver = null};
            _publisherDocName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                           @"SIL\DblDataPrep\Publishers.xml");
            if (File.Exists(_publisherDocName))
            {
                _publisherDoc.Load(_publisherDocName);
                MigratePublisherDoc();
            }
            else
            {
                _publisherDoc.LoadXml(_publisherData);
                var folder = Path.GetDirectoryName(_publisherDocName);
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                _publisherDoc.Save(_publisherDocName);
            }
        }

        private void MigratePublisherDoc()
        {
            Debug.Assert(_publisherDoc != null && _publisherDoc.DocumentElement != null);
            var versionNode = _publisherDoc.DocumentElement.SelectSingleNode("@version");
            int version = (versionNode != null) ? int.Parse(versionNode.InnerText) : 0;
            if (version == 0)
            {
                _publisherDoc.InnerXml = _publisherDoc.InnerXml.Replace("Wycliffe Inc.", "Wycliffe");
                version = 1;
                var versionAttr = _publisherDoc.CreateAttribute("version");
                versionAttr.InnerText = version.ToString();
                _publisherDoc.DocumentElement.Attributes.Append(versionAttr);
                _publisherDoc.Save(_publisherDocName);
            }
        }

        public void Load(string webDocText)
        {
            _webDoc.LoadXml(webDocText);
        }

        #region dblMetaData (template)
        private const string _dblMetaData = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<?xml-model href=""metadataWbt-1.2.rnc"" type=""application/relax-ng-compact-syntax""?>
<DBLMetadata xmlns:ns0=""http://purl.org/dc/xmlns/2008/09/01/dc-ds-xml/"" id=""2880c78491b2f8ce"" revision=""3"" type=""text"" typeVersion=""1.2"" xml:base=""http://purl.org/ubs/metadata/dc/terms/"">
  <identification>
    <name ns0:propertyURI=""title"" />
    <nameLocal />
    <abbreviation />
    <abbreviationLocal />
    <scope ns0:propertyURI=""title/scriptureScope"" />
    <description ns0:propertyURI=""description"" />
    <dateCompleted ns0:propertyURI=""date"" ns0:sesURI=""http://purl.org/dc/terms/W3CDTF"" />
    <systemId type=""reap"" ns0:propertyURI=""identifier/reapID"" />
    <systemId type=""paratext"" ns0:propertyURI=""identifier/ptxID"" />
    <systemId type=""tms"" ns0:propertyURI=""identifier/tmsID"">seeReap</systemId>
    <bundleProducer/>
  </identification>
  <confidential ns0:propertyURI=""accessRights/confidential"">false</confidential>
  <agencies>
    <etenPartner>WBT</etenPartner>
    <creator ns0:propertyURI=""creator"">Wycliffe</creator>
    <publisher ns0:propertyURI=""publisher"">Wycliffe</publisher>
    <contributor ns0:propertyURI=""contributor"" />
  </agencies>
  <language>
    <iso ns0:propertyURI=""language/iso"" ns0:sesURI=""http://purl.org/dc/terms/ISO639-3"">eng</iso>
    <name ns0:propertyURI=""subject/subjectLanguage"" ns0:sesURI=""http://purl.org/dc/terms/ISO639-3"">English</name>
    <ldml ns0:propertyURI=""language/ldml"">en</ldml>
    <rod ns0:propertyURI=""language/rod"" />
    <script ns0:propertyURI=""language/script"">Latin</script>
    <scriptDirection ns0:propertyURI=""language/scriptDirection"">LTR</scriptDirection>
    <numerals ns0:propertyURI=""language/numerals"" />
  </language>
  <country>
    <iso ns0:propertyURI=""coverage/spatial"" ns0:sesURI=""http://purl.org/dc/terms/ISO3166"">US</iso>
    <name ns0:propertyURI=""subject/subjectCountry"">United States</name>
  </country>
  <type>
    <translationType ns0:propertyURI=""type/translationType"">New</translationType>
    <audience ns0:propertyURI=""audience"">Common</audience>
  </type>
  <bookNames/>
  <contents ns0:propertyURI=""tableOfContents"">
    <bookList id=""default"">
      <name/>
      <nameLocal/>
      <abbreviation/>
      <abbreviationLocal/>
      <description/>
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
  <contact>
    <rightsHolder ns0:propertyURI=""rightsHolder""/>
    <rightsHolderLocal ns0:propertyURI=""rightsHolder/contactLocal"" />
    <rightsHolderAbbreviation ns0:propertyURI=""rightsHolder/contactAbbreviation"" />
    <rightsHolderURL ns0:propertyURI=""rightsHolder/contactURL"" />
    <rightsHolderFacebook ns0:propertyURI=""rightsHolder/contactFacebook"" />
  </contact>
  <copyright>
    <statement contentType=""xhtml"" ns0:propertyURI=""rights"" />
  </copyright>
  <promotion>
    <promoVersionInfo contentType=""xhtml"" ns0:propertyURI=""description/pubPromoVersionInfo"" />
    <promoEmail contentType=""xhtml"" ns0:propertyURI=""description/pubPromoEmail"" />
  </promotion>
  <archiveStatus>
    <archivistName ns0:propertyURI=""contributor/archivist"" />
    <dateArchived ns0:propertyURI=""dateSubmitted"" ns0:sesURI=""http://purl.org/dc/terms/W3CDTF"">2012-03-12T17:51:32.7907868+00:00</dateArchived>
    <dateUpdated ns0:propertyURI=""modified"" ns0:sesURI=""http://purl.org/dc/terms/W3CDTF"">2012-03-17T14:21:02.8293104+00:00</dateUpdated>
    <comments ns0:propertyURI=""abstract"">DBL example bundle</comments>
  </archiveStatus>
  <format ns0:propertyURI=""format"" ns0:sesURI=""http://purl.org/dc/terms/IMT"">text/xml</format>
</DBLMetadata>";
        #endregion dblMetaData (template)

        #region dblMetaDataSchema
        private const string DblMetaDataSchema = @"default namespace = """"
namespace dcds = ""http://purl.org/dc/xmlns/2008/09/01/dc-ds-xml/""

start =
  element DBLMetadata {
    attribute id { xsd:string { pattern = ""[0-9a-f]{16}"" } },
    attribute type { ""text"" },  # “text” | “print” | “audio” | “video”
    attribute typeVersion { ""1.2"" },
    attribute revision { xsd:integer },
    attribute xml:base { ""http://purl.org/ubs/metadata/dc/terms/"" },
    element identification {
      (abbreviation
         # abbreviation local should default to abbreviation
       | abbreviationLocal
       | element description {
           attribute dcds:propertyURI { ""description"" },
           text 
           }
       | element name {
           attribute dcds:propertyURI { ""title"" },
           xsd:string { minLength = ""2"" }
           }
         # Name local should default to name 
       | element nameLocal {
           xsd:string { minLength = ""2"" }
           }
       | element dateCompleted {
           attribute dcds:propertyURI { ""date"" },
           attribute dcds:sesURI { ""http://purl.org/dc/terms/W3CDTF"" },
           #xsd:string { pattern = ""\d{4}"" }
           (xsd:date |xsd:gYear |xsd:gYearMonth |xsd:dateTime)
           }
       | element scope {
           attribute dcds:propertyURI { ""title/scriptureScope"" },
           (""NT"" | scopes) 
           }
         # systemId[@type='paratext'] is overwritten by Paratext
       | element systemId {
           attribute type { ""tms"" | ""reap"" | ""paratext"" | ""biblica"" },
           attribute dcds:propertyURI { ""identifier/dblID"" | ""identifier/tmsID"" | ""identifier/reapID"" | ""identifier/ptxID"" | ""identifier/biblicaID"" },
           text 
           })+,
      # bundleProducer is overwritten by Paratext
      element bundleProducer { text }
    },
    element confidential {
      attribute dcds:propertyURI { ""accessRights/confidential"" },
      #(""true"" | ""false"")
      xsd:boolean
    },
    element agencies {
      element etenPartner { ""UBS"" | ""WBT"" | ""Biblica"" }*,
      element creator { 
        attribute dcds:propertyURI { ""creator"" },
        xsd:string { minLength = ""2"" }
        }+,
      # publisher may be the same as translation (description/sponsorship) 
      element publisher {
        attribute dcds:propertyURI { ""publisher"" },
        xsd:string { minLength = ""2"" }
        }*,
      element contributor {
        attribute dcds:propertyURI { ""contributor"" },
        text
        }*
    },
    element language {
      element iso { 
        attribute dcds:propertyURI { ""language/iso"" },
        attribute dcds:sesURI { ""http://purl.org/dc/terms/ISO639-3"" },
        xsd:string { pattern = ""[a-z]{3}"" } 
        },
      element name { 
        attribute dcds:sesURI { ""http://purl.org/dc/terms/ISO639-3"" },
        attribute dcds:propertyURI { ""subject/subjectLanguage"" },
        xsd:string
        },
      element ldml { 
        attribute dcds:propertyURI { ""language/ldml"" },
        xsd:string { pattern = ""[A-Za-z]{2,3}([\-_][A-Za-z0-9]+){0,3}"" }? 
        },
      element rod { 
        attribute dcds:propertyURI { ""language/rod"" },
        xsd:string { pattern = ""[0-9]{5}"" }?
        },
      element script {
        attribute dcds:propertyURI { ""language/script"" },
        scripts?
        },
      # LTR (Left to Right) or RTL (Right to Left) 
      # scriptDirection is overwritten by Paratext
      element scriptDirection {
        attribute dcds:propertyURI { ""language/scriptDirection"" },
        (""LTR"" | ""RTL"") 
        },
      element numerals {
        attribute dcds:propertyURI { ""language/numerals"" },
        numeralSystems?
        }
    },
    element country { 
      element iso { 
      attribute dcds:propertyURI { ""coverage/spatial"" },
      attribute dcds:sesURI { ""http://purl.org/dc/terms/ISO3166"" }, 
      xsd:string { pattern = ""[A-Za-z]{2,3}"" } 
      }, 
    element name { 
      attribute dcds:propertyURI { ""subject/subjectCountry"" }, 
      xsd:string
      }},
    element type { 
      element translationType { 
        attribute dcds:propertyURI { ""type/translationType"" }, 
        (""First"" | ""New"" | ""Revision"") 
        }, 
      element audience {
        attribute dcds:propertyURI { ""audience"" }, 
        ( ""Basic"" | ""Common"" | ""Common - Literary"" | ""Literary"" | ""Liturgical"")
        }},
    # bookNames/book is overwritten by Paratext
    element bookNames { 
      element book { 
        attribute code { bookCode }, 
        element name { 
          attribute type {""long""}, 
          text 
          }, 
        element name { 
          attribute type {""short""}, 
          text 
          }, 
        element name { 
          attribute type {""abbr""}, 
          text 
          } }* },
    element contents {
      attribute dcds:propertyURI { ""tableOfContents"" },
      element bookList {
        attribute id { ""default"" }?, 
        # default to name from identification section  
        element name { xsd:string { minLength=""2"" } }, 
        # default to name local from identification section
        element nameLocal { xsd:string { minLength=""2"" } },
        abbreviation, 
        abbreviationLocal, 
        # ""NT"" | ""NT + OT"" or <Name> from Cannons.xml
        element description { text }, 
        # Protestant Bible (66 books) 
        element range { xsd:string }, 
        # Western Protestant order 
        element tradition { ""Western Protestant order"" },
        element division {
          attribute id { ""OT"" | ""NT"" | ""DC"" },
          element books { 
            element book { 
              attribute code { bookCode }
            }+ } }+ }+ },
	# Default to Publisher (from agencies) 
    element contact {
      element rightsHolder {
        attribute dcds:propertyURI { ""rightsHolder"" },
        text
      },
	  # Default to rights holder 
      element rightsHolderLocal {
        attribute dcds:propertyURI { ""rightsHolder/contactLocal"" },
        text
      },
      element rightsHolderAbbreviation {
        attribute dcds:propertyURI { ""rightsHolder/contactAbbreviation"" },
        xsd:NCName
      },
      element rightsHolderURL {
        attribute dcds:propertyURI { ""rightsHolder/contactURL"" },
        xsd:anyURI
      },
      element rightsHolderFacebook {
        attribute dcds:propertyURI { ""rightsHolder/contactFacebook"" },
        xsd:anyURI
      }
    },
    element copyright {
	  # For example: ©1983, 1992 SIL International 
      element statement {
        attribute contentType { ""xhtml"" },
        attribute dcds:propertyURI { ""rights"" },
        htmlMarkup
      }
    },
    element promotion {
      element promoVersionInfo {
        attribute contentType { ""xhtml"" },
        attribute dcds:propertyURI { ""description/pubPromoVersionInfo"" },
		htmlMarkup
      },
      element promoEmail {
        attribute contentType { ""xhtml"" },
        attribute dcds:propertyURI { ""description/pubPromoEmail"" },
        htmlMarkup
      }
    },
    element archiveStatus {
      # archivistName is overwritten by Paratext
      element archivistName {
        attribute dcds:propertyURI { ""contributor/archivist"" },
        text
      },
	  # ex. 2012-03-12T17:51:32.7907868+00:00
      # dateArchived is overwritten by Paratext
      element dateArchived {
        attribute dcds:propertyURI { ""dateSubmitted"" },
        attribute dcds:sesURI { ""http://purl.org/dc/terms/W3CDTF"" },
        xsd:dateTime
      },
      # dateUpdated is overwritten by Paratext
      element dateUpdated {
        attribute dcds:propertyURI { ""modified"" },
        attribute dcds:sesURI { ""http://purl.org/dc/terms/W3CDTF"" },
        xsd:dateTime
      },
      element comments {
        attribute dcds:propertyURI { ""abstract"" },
        text
      }
    },
    # format is overwritten by Paratext
    element format {
      attribute dcds:propertyURI { ""format"" },
      attribute dcds:sesURI { ""http://purl.org/dc/terms/IMT"" },
      ""text/xml""
    }
  }

abbreviation = element abbreviation { 
	xsd:string { pattern = ""[A-Za-z0-9]{2,8}"" } 
	}

abbreviationLocal = element abbreviationLocal { 
	xsd:string { pattern = ""[A-Za-z0-9]{2,8}"" } 
	}

htmlMarkup = (
           element p { (text | htmlCharMarkup)+ }
         | element h1 { text }
         | element h2 { text }
         | element h3 { text }
         | element ul { 
             element li { text }+}
         | element ol { 
             element li { text }+}
         | element blockquote { text }
         | htmlCharMarkup)+

htmlCharMarkup = ( text
		 | element a {
             attribute href { xsd:anyURI },
             htmlCharMarkup
           }
         | element img {
            attribute src { xsd:anyURI },
            attribute alt { text }?,
            text
            }           
         | element br { empty }
         | element strong { text }
         | element b { text }
         | element em { text }
         | element i { text })

scopes = (""Bible with Deuterocanon"" |
        ""Bible without Deuterocanon"" |
        ""New Testament and Psalms"" |
        ""New Testament and Shorter Old Testament"" |
        ""New Testament only"" |
        ""Old Testament only"" |
        ""Old Testament with Deuterocanon"" |
        ""Shorter Old Testament only"" |
        ""Study Bible"" |
        ""Portion only"" |
        ""Selection only"")

scripts = (""Arabic"" |
        ""Arabic (Modified)"" |
        ""Armenian"" |
        ""Assamese"" |
        ""Bengali"" |
        ""Burmese"" |
        ""Chinese (Simplified)"" |
        ""Chinese (Traditional)"" |
        ""Cyrillic"" |
        ""Cyrillic (Modified)"" |
        ""Devanagari"" |
        ""Ethiopic"" |
        ""Georgian"" |
        ""Greek"" |
        ""Gurmukhi"" |
        ""Hebrew"" |
        ""Japanese"" |
        ""Khmer"" |
        ""Korean"" |
        ""Latin"" |
        ""Persian"" |
        ""Persian (Modified)"" |
        ""Pollard"" |
        ""Syllabic"" |
        ""Syriac"" |
        ""Syriac"" |
        ""Thai"" |
        ""Tibetan"")

numeralSystems = (""Arabic"" #(a.k.a. 'Hindu') = 0123456789
         | ""Bengali""
         | ""Burmese""
         | ""Devanagari""
         | ""Ethiopic""
         | ""Farsi""
         | ""Gujarati""
         | ""Gurmukhi""
         | ""Hindi"" #(i.e. 'Arabic' as used in Egypt)
         | ""Kannada""
         | ""Khmer""
         | ""Malayalam""
         | ""Oriya""
         | ""Tamil""
         | ""Telugu""
         | ""Thai""
         | ""Tibetan"")

bookCode = (
           ""GEN""   # Genesis
         | ""EXO"" # Exodus
         | ""LEV"" # Leviticus
         | ""NUM"" # Numbers
         | ""DEU"" # Deuteronomy   
         | ""JOS"" # Joshua 
         | ""JDG"" # Judges 
         | ""RUT"" # Ruth 
         | ""1SA"" # 1 Samuel 
         | ""2SA"" # 2 Samuel 
         | ""1KI"" # 1 Kings 
         | ""2KI"" # 2 Kings 
         | ""1CH"" # 1 Chronicles 
         | ""2CH"" # 2 Chronicles 
         | ""EZR"" # Ezra 
         | ""NEH"" # Nehemiah 
         | ""EST"" # Esther (Hebrew)
         | ""JOB"" # Job 
         | ""PSA"" # Psalms 
         | ""PRO"" # Proverbs 
         | ""ECC"" # Ecclesiastes 
         | ""SNG"" # Song of Songs 
         | ""ISA"" # Isaiah 
         | ""JER"" # Jeremiah 
         | ""LAM"" # Lamentations 
         | ""EZK"" # Ezekiel 
         | ""DAN"" # Daniel (Hebrew)
         | ""HOS"" # Hosea 
         | ""JOL"" # Joel 
         | ""AMO"" # Amos 
         | ""OBA"" # Obadiah 
         | ""JON"" # Jonah 
         | ""MIC"" # Micah 
         | ""NAM"" # Nahum 
         | ""HAB"" # Habakkuk 
         | ""ZEP"" # Zephaniah 
         | ""HAG"" # Haggai 
         | ""ZEC"" # Zechariah 
         | ""MAL"" # Malachi 
         | ""MAT"" # Matthew 
         | ""MRK"" # Mark 
         | ""LUK"" # Luke 
         | ""JHN"" # John 
         | ""ACT"" # Acts 
         | ""ROM"" # Romans 
         | ""1CO"" # 1 Corinthians 
         | ""2CO"" # 2 Corinthians 
         | ""GAL"" # Galatians 
         | ""EPH"" # Ephesians 
         | ""PHP"" # Philippians 
         | ""COL"" # Colossians 
         | ""1TH"" # 1 Thessalonians 
         | ""2TH"" # 2 Thessalonians 
         | ""1TI"" # 1 Timothy 
         | ""2TI"" # 2 Timothy 
         | ""TIT"" # Titus 
         | ""PHM"" # Philemon 
         | ""HEB"" # Hebrews 
         | ""JAS"" # James 
         | ""1PE"" # 1 Peter 
         | ""2PE"" # 2 Peter 
         | ""1JN"" # 1 John 
         | ""2JN"" # 2 John 
         | ""3JN"" # 3 John 
         | ""JUD"" # Jude 
         | ""REV"" # Revelation 
         | ""TOB"" # Tobit 
         | ""JDT"" # Judith 
         | ""ESG"" # Esther Greek 
         | ""WIS"" # Wisdom of Solomon 
         | ""SIR"" # Sirach (Ecclesiasticus)
         | ""BAR"" # Baruch 
         | ""LJE"" # Letter of Jeremiah 
         | ""S3Y"" # Song of 3 Young Men 
         | ""SUS"" # Susanna 
         | ""BEL"" # Bel and the Dragon 
         | ""1MA"" # 1 Maccabees 
         | ""2MA"" # 2 Maccabees 
         | ""3MA"" # 3 Maccabees 
         | ""4MA"" # 4 Maccabees 
         | ""1ES"" # 1 Esdras (Greek)
         | ""2ES"" # 2 Esdras (Latin)
         | ""MAN"" # Prayer of Manasseh 
         | ""PS2"" # Psalm 151
         | ""ODA"" # Odes 
         | ""PSS"" # Psalms of Solomon 
         | ""EZA"" # Apocalypse of Ezra 
         | ""5EZ"" # 5 Ezra 
         | ""6EZ"" # 6 Ezra 
         | ""DAG"" # Daniel Greek 
         | ""PS3"" # Psalms 152-155
         | ""2BA"" # 2 Baruch (Apocalypse)
         | ""LBA"" # Letter of Baruch 
         | ""JUB"" # Jubilees 
         | ""ENO"" # Enoch 
         | ""1MQ"" # 1 Meqabyan 
         | ""2MQ"" # 2 Meqabyan 
         | ""3MQ"" # 3 Meqabyan 
         | ""REP"" # Reproof 
         | ""4BA"" # 4 Baruch 
         | ""LAO"" # Laodiceans 
           # Non scripture text Id's
         | ""XXA"" # Extra A, e.g. a hymnal 
         | ""XXB"" # Extra B 
         | ""XXC"" # Extra C 
         | ""XXD"" # Extra D 
         | ""XXE"" # Extra E 
         | ""XXF"" # Extra F 
         | ""XXG"" # Extra G 
         | ""FRT"" # Front Matter 
         | ""BAK"" # Back Matter 
         | ""OTH"" # Other Matter 
         | ""INT"" # Introduction 
         | ""CNC"" # Concordance 
         | ""GLO"" # Glossary 
         | ""TDX"" # Topical Index 
         | ""NDX"") # Names Index 

licenseType = (""BY"" # Attributaion only
         | ""BY-ND""       #  Attribution-NoDerivatives
         | ""BY-NC-ND"" # Attribution-NonCommercial- NoDerivatives 
         | ""BY-NC""       # Attribution-NonCommercial 
         | ""BY-NC-SA"" # Attribution-NonCommercial- ShareAlike 
         | ""BY-SA""       # Attribution-ShareAlike 
         | ""PD"")           # Dedicated to or marked as being in the public domain
";
        #endregion dblMetaDataSchema

        #region license (template)
        private const string _license = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<license id=""66f69e2e951292b7"" xmlns:dcds=""http://purl.org/dc/xmlns/2008/09/01/dc-ds-xml/"">
  <dateLicense>2011-10-01</dateLicense>
  <dateLicenseExpiry>2014-09-30</dateLicenseExpiry>
  <publicationRights>
    <allowOffline>false</allowOffline>
    <allowIntroductions>true</allowIntroductions>
    <allowFootnotes>true</allowFootnotes>
    <allowCrossReferences>true</allowCrossReferences>
    <allowExtendedNotes>false</allowExtendedNotes>
  </publicationRights>
</license>
";
        #endregion license (template)

        #region _publisherData
        private readonly string _publisherData = @"
<root>
<publisher abbr=""WBT"" name=""Wycliffe"" rights=""Wycliffe"" url=""http://www.wycliffe.org"" fb=""http://www.facebook.com/WycliffeUSA""/>
<publisher abbr=""BLI"" name=""La Liga Bíblica"" rights=""Bible League International"" url=""http://www.bibleleague.org/"" fb=""http://www.facebook.com/BibleLeagueInternational""/>
<publisher abbr=""BLI"" name=""Bible League International"" rights=""Bible League International"" url=""http://www.bibleleague.org/"" fb=""http://www.facebook.com/BibleLeagueInternational""/>
<publisher abbr=""BLI"" name=""Bible League"" rights=""Bible League International"" url=""http://www.bibleleague.org/"" fb=""http://www.facebook.com/BibleLeagueInternational""/>
<!-- publisher name="" url="" fb=""/ -->
</root>
";
        #endregion _SubjectBreakout

        //Todo This was included based on an email from Joan Spanne to ETEN Text Format Group 10/26/2011 but upon verification with acr her logic didn't hold
        #region _SubjectBreakout
        private readonly string _subjectBreakout = @"
<root>
<silSubject value=""New Testament"" range=""New Testament"" abbr=""NT"" editionType=""New""/>
<silSubject value=""Old Testament"" range=""Old Testament"" abbr=""OT"" editionType=""New""/>
<silSubject value=""Complete Bible"" range=""Complete Bible"" abbr=""BL"" editionType=""New""/>
<silSubject value=""New Testament revision"" range=""New Testament"" abbr=""NT"" editionType=""Revision""/>
<silSubject value=""Old Testament revision"" range=""Old Testament"" abbr=""OT"" editionType=""Revision""/>
<silSubject value=""Complete Bible revision"" range=""Complete Bible"" abbr=""BL"" editionType=""Revision""/>
<silSubject value=""New Testament reprint"" range=""New Testament"" abbr=""NT"" editionType=""New""/>
<silSubject value=""Old Testament reprint"" range=""Old Testament"" abbr=""OT"" editionType=""New""/>
<silSubject value=""Complete Bible reprint"" range=""Complete Bible"" abbr=""BL"" editionType=""New""/>
</root>
";
        #endregion _subjectBreakout

        readonly List<string> _firstList = new List<string> { "1st", "first", "[1st]" };

        public void ScrapeReapData()
        {
            _confidential = GetValue("//default:tr[default:td='sil.sensitivity.metadata']/default:td[2]").ToLower() == "public" ? "false" : "true";
            _title = GetValue("//default:title");

            // Scope
            var rawScope = "WNT:New Testament";
            if (!_options.AlwaysUseNT)
                rawScope = GetValue("//default:tr[default:td='dc.title.scriptureScope']/default:td[2]");
            _scope = TextField(rawScope, 0).Substring(1);

            _dateCompleted = GetValue("//default:meta[@name='DCTERMS.issued']/@content").Trim(new char[] {',', ' ', '\n', '\r', '\f', '\t', ':', '\'', '"', '(', ')'});
            _reapUrl = GetValue("//default:tr[default:td='dc.identifier.uri']/default:td[2]");

            // TranslationType
            //var typeWords = GetValue("//default:tr[default:td='dc.description.edition']/default:td[2]").Split(' ');
            //_translationType = _firstList.Contains(typeWords[0]) ? "First" : "Revision";
            _translationType = "New";

            _languageCode = GetField("//default:tr[default:td='dc.language.iso']/default:td[2]", 0);
            _languageName = GetField("//default:tr[default:td='dc.language.iso']/default:td[2]", 1);

            // Rod - dialect
            _rod = GetField("//default:tr[default:td='dc.subject.rod']/default:td[2]", 0);
            if (_rod.StartsWith("<>"))
                _rod = string.Empty;
            try
            {
                _dialectName = GetField("//default:tr[default:td='dc.subject.rod']/default:td[2]", 1);
            }
            catch (Exception)
            {
                _dialectName = "";
            }

            // Script & Direction
            try
            {
                _script = GetField("//default:tr[default:td='dc.language.script']/default:td[2]", 1);
                _scriptDirection = "<><> Direction unknown <><>";
            }
            catch (Exception)
            {
                _script = "Latin";
                _scriptDirection = "LTR";
            }

            _countryCode = GetField("//default:meta[@name='DCTERMS.spatial'][1]/@content", 0);
            _countryName = GetField("//default:meta[@name='DCTERMS.spatial'][1]/@content", 1);
            SetAbbreviation();
            SetDescription();
            SetRange();

            // Publisher
            _publisher = GetValue("//default:tr[default:td='dc.publisher']/default:td[2]");
            
            SetRightsHolder();
            SetLocalRightsHolder();
            SetRightsHolderUrl();
            SetRightsHolderFacebook();
            SetRightsHolderStatement();

            _isbn = GetValue("//default:tr[default:td='dc.identifier.isbn']/default:td[2]");

            // PromoInfo
            if (_confidential == "false")
            {
                ResetPromoStatements();
            }
            else
            {
                _promoInfo = "<><>No promoVersionInfo<><>";
            }

            SetPromoEmail();
        }

        public void SetRightsHolder()
        {
            if (_publisher.ToLower().Contains("wycliffe"))
                _publisher = "Wycliffe";

            var rightsHolderNode = _publisherDoc.SelectSingleNode(string.Format("//publisher[@name='{0}']/@rights", _publisher));
            if (rightsHolderNode != null)
            {
                _rightsHolder = rightsHolderNode.InnerText;
                _publisher = _rightsHolder;
            }
            if (!_options.PublisherRights)
                _rightsHolder = _options.TransAgency;
            else if (string.IsNullOrEmpty(_rightsHolder))
                _rightsHolder = _publisher;

            var rightsHolderAbbrNode = _publisherDoc.SelectSingleNode(string.Format("//publisher[@name='{0}']/@abbr", _rightsHolder));
            if (rightsHolderAbbrNode != null)
                _rightsHolderAbbr = rightsHolderAbbrNode.InnerText;
        }

        public void SetLocalRightsHolder()
        {
            _rightsHolderLocal = _rightsHolder;
            if (!string.IsNullOrEmpty(_options.LocalRights))
                _rightsHolderLocal = _options.LocalRights;
        }

        public void SetRightsHolderUrl()
        {
            var publisherUrlNode = _publisherDoc.SelectSingleNode(string.Format("//publisher[@name='{0}']/@url", _rightsHolder));
            if (publisherUrlNode != null)
                _publisherUrl = publisherUrlNode.InnerText;
            else
                _publisherUrl = "<><> Publisher URL <><>";
        }

        public void SetRightsHolderFacebook()
        {
            var publisherFbNode = _publisherDoc.SelectSingleNode(string.Format("//publisher[@name='{0}']/@fb", _rightsHolder));
            if (publisherFbNode != null)
                _publisherFacebook = publisherFbNode.InnerText;
            else
                _publisherFacebook = "<><> Publisher Facebook <><>";
        }

        public void SetRightsHolderStatement()
        {
            _rightsStatement = "© " + _dateCompleted + ", " + _rightsHolder + ". All rights reserved.";
            _rightsStatement = _rightsStatement.Replace("..", ".");
        }

        public string TypeDescription()
        {
            var type = _translationType.ToLower();
            if (type == "first")
                return "First edition of ";
            if (type == "revision")
                return "Revision of ";
            return "";                  // New
        }

        public void SetDescription()
        {
            _description = string.Format("{0}{1} in {2} {3}", TypeDescription(), ScopeDescription(),
                                              _languageName, _dialectName).Trim();
        }

        public void SetRange()
        {
            switch (_scope)
            {
                case "NT":
                    _range = "Protestant New Testament (27 books)";
                    break;
                case "Bible with Deuterocanon":
                    _range = "Bible with DC (Anglican Tradition)";
                    break;
                case "Bible without Deuterocanon":
                    _range = "Protestant Bible (66 books)";
                    break;
                case "New Testament and Psalms":
                    _range = "Protestant New Testament (27 books) and Psalms";
                    break;
                case "New Testament, Psalms and Proverbs":
                    _range = "Protestant New Testament (27 books) with Psalms and Proverbs";
                    break;
                case "New Testament and Shorter Old Testament":
                    _range = "Protestant New Testament (27 books) with a shortened Old Testament";
                    break;
                case "New Testament only":
                    _range = "Protestant New Testament (27 books)";
                    break;
                case "Old Testament only":
                    _range = "Protestant Old Testament (39 books)";
                    break;
                case "Old Testament with Deuterocanon":
                    _range = "Old Testament with DC (Anglican Tradition)";
                    break;
                case "Shorter Old Testament only":
                    _range = "Selections of Protestant Old Testament";
                    break;
                case "Study Bible":
                    _range = "Protestant Bible (66 books) with study notes";
                    break;
                case "Portion only":
                    _range = "Portion of Protestant New Testament";
                    break;
                case "Selection only":
                    _range = "Selections of Protestant New Testament";
                    break;
                default:
                    _range = "Portion of Protestant New Testament";
                    break;
            }
        }

        public void SetAbbreviation()
        {
            _abbreviation = _languageCode;
            switch (_scope)
            {
                case "NT":
                    _abbreviation += "NT";
                    break;
                case "Bible with Deuterocanon":
                    _abbreviation += "BId";
                    break;
                case "Bible without Deuterocanon":
                    _abbreviation += "BI";
                    break;
                case "New Testament and Psalms":
                    _abbreviation += "NTps";
                    break;
                case "New Testament, Psalms and Proverbs":
                    _abbreviation += "NTpp";
                    break;
                case "New Testament and Shorter Old Testament":
                    _abbreviation += "NTpo";
                    break;
                case "New Testament only":
                    _abbreviation += "NT";
                    break;
                case "Old Testament only":
                    _abbreviation += "OT";
                    break;
                case "Old Testament with Deuterocanon":
                    _abbreviation += "OTd";
                    break;
                case "Shorter Old Testament only":
                    _abbreviation += "OTs";
                    break;
                case "Study Bible":
                    _abbreviation += "SBI";
                    break;
                case "Portion only":
                    _abbreviation += "POR";
                    break;
                case "Selection only":
                    _abbreviation += "SEL";
                    break;
                default:
                    _abbreviation += _scope;
                    break;
            }
        }

        public void SetPromoEmail()
        {
            _promoEmail = _options.PromoEmailText(_ldml);
            _promoEmail = _promoEmail.Replace("${name}",  _title);
            _promoEmail = _promoEmail.Replace("${description}", _description);
        }

        public void ResetPromoStatements()
        {
            var promoStatements = new PromoStatements();
            if (_publicationDescription != null)
            {
                var trimmedDescription0 = _publicationDescription.Trim();
                var spaceB4NewLine = new Regex(@"\s+\n", RegexOptions.Multiline | RegexOptions.Compiled);
                var trimmedDescription1 = spaceB4NewLine.Replace(trimmedDescription0, "\n");
                var trimmedDescription = trimmedDescription1.Replace("\n", "<br/>\r\n");
                if (trimmedDescription.Length > 0)
                    promoStatements.AddParagraph(trimmedDescription);
            }
            promoStatements.AddSubhead("Copyright Information");
            promoStatements.AddParagraph(_rightsStatement);
            promoStatements.AddLicense();
            if (_isbn != null && _isbn.Substring(0,4) != "<><>")
                promoStatements.AddIsbn(_isbn);
            promoStatements.AddDescription(_translationType, ScopeDescription(), _languageName, _languageCode);
            _promoInfo = promoStatements.ToHtml();
        }

        public void InsertDataInDblMetaData()
        {
            SetValue(_title, "//identification/name");
            SetValue(_title, "//identification/nameLocal");
            SetValue(_abbreviation, "//identification/abbreviation");
            SetValue(_abbreviation, "//identification/abbreviationLocal");
            SetValue(_scope, "//identification/scope");
            SetValue(_description, "//identification/description"); 
            SetValue(_dateCompleted, "//identification/dateCompleted");
            SetValue(_reapUrl, "//identification/systemId[@type='reap']");

            SetValue(_confidential, "//confidential");
            
            SetValue(_options.TransAgency, "//agencies/creator");
            SetValue(_options.TransAgency, "//agencies/publisher");
            SetValue(_contributor, "//agencies/contributor");
            
            SetValue(_languageCode, "//language/iso");
            SetValue(_languageName, "//language/name");
            SetValue(_ldml, "//language/ldml");
            SetValue(_rod, "//language/rod");
            SetValue(_script, "//language/script");
            SetValue(_scriptDirection, "//language/scriptDirection");
            SetValue(_numeralScript, "//language/numerals");

            SetValue(_countryCode, "//country/iso");
            SetValue(_countryName, "//country/name");

            SetValue(_translationType, "//type/translationType");

            SetValue(_title, "//contents/bookList/name");
            SetValue(_title, "//contents/bookList/nameLocal");
            SetValue(_abbreviation, "//contents/bookList/abbreviation");
            SetValue(_abbreviation, "//contents/bookList/abbreviationLocal");
            SetValue(_scope, "//contents/bookList/description");
            SetValue(_range, "//contents/bookList/range");

            SetValue(_rightsHolder, "//contact/rightsHolder");
            SetValue(_rightsHolderLocal, "//contact/rightsHolderLocal");
            SetValue(_rightsHolderAbbr, "//contact/rightsHolderAbbreviation");
            SetValue(_publisherUrl, "//contact/rightsHolderURL");
            SetValue(_publisherFacebook, "//contact/rightsHolderFacebook");

            SetValue(_rightsStatement, "//copyright/statement");

            SetXmlValue(_promoInfo, "//promotion/promoVersionInfo");
            SetXmlValue(_promoEmail, "//promotion/promoEmail");
        }

        public string ScopeDescription()
        {
            switch (_scope)
            {
                case "NT":
                    return "New Testament";
                case "BI":
                    return "Bible";
                default:
                    return _scope;
            }
        }

        public List<string> publishers()
        {
            var results = _publisherDoc.SelectNodes("//publisher/@name");
            return (from XmlNode node in results select node.InnerText).ToList();
        }

        public List<string> publisherUrls()
        {
            var results = _publisherDoc.SelectNodes("//publisher/@url");
            return (from XmlNode node in results select node.InnerText).ToList();
        }

        public List<string> publisherFacebooks()
        {
            var results = _publisherDoc.SelectNodes("//publisher/@fb");
            return (from XmlNode node in results select node.InnerText).ToList();
        }

        private void SetValue(string value, string xpath)
        {
            if (value == null)
                return;
            XmlNode xmlNode = _dblMetaDataDoc.SelectSingleNode(xpath);
            xmlNode.InnerText = value;
        }

        private void SetXmlValue(string value, string xpath)
        {
            XmlNode xmlNode = _dblMetaDataDoc.SelectSingleNode(xpath);
            xmlNode.InnerXml = value.Replace("<>", "&lt;&gt;");
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

        internal void Save(string p)
        {
            var sw = new StreamWriter(p);
            var xw = XmlWriter.Create(sw);
            _dblMetaDataDoc.WriteContentTo(xw);
            xw.Close();
            sw.Close();

            var folder = Path.GetDirectoryName(p);
            var schemaName = Path.Combine(folder, "metadataWbt-1.2.rnc");
            var schemaStreamWriter = new StreamWriter(schemaName);
            schemaStreamWriter.Write(DblMetaDataSchema);
            schemaStreamWriter.Close();

            // Write License based on options and current date.
            var licenseDoc = new XmlDocument {XmlResolver = null};
            licenseDoc.LoadXml(_license);
            SetLicenseValue(_options.AllowOffline.ToString().ToLower(), "//allowOffline", licenseDoc);
            SetLicenseValue(_options.AllowIntroductions.ToString().ToLower(), "//allowIntroductions", licenseDoc);
            SetLicenseValue(_options.AllowFootnotes.ToString().ToLower(), "//allowFootnotes", licenseDoc);
            SetLicenseValue(_options.AllowCrossReferences.ToString().ToLower(), "//allowCrossReferences", licenseDoc);
            SetLicenseValue(_options.AllowExtendedNotes.ToString().ToLower(), "//allowExtendedNotes", licenseDoc);
            SetLicenseValue(DateTime.Today.ToString("yyyy-MM-dd"), "//dateLicense", licenseDoc);
            SetLicenseValue(DateTime.Today.AddYears(3).ToString("yyyy-MM-dd"), "//dateLicenseExpiry", licenseDoc);
            var licenseName = Path.Combine(folder, _languageCode + "License.xml");
            var licenseStreamWriter = new StreamWriter(licenseName);
            var licenseXmlWriter = XmlWriter.Create(licenseStreamWriter);
            licenseDoc.WriteContentTo(licenseXmlWriter);
            licenseXmlWriter.Close();
            licenseStreamWriter.Close();
        }

        private void SetLicenseValue(string value, string xpath, XmlDocument doc)
        {
            if (value == null)
                return;
            XmlNode xmlNode = doc.SelectSingleNode(xpath);
            Debug.Assert(xmlNode != null);
            xmlNode.InnerText = value;
        }

        internal string GetDefaultName()
        {
            return _languageCode + "MetaData";
        }
    }
}
