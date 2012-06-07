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
using System.Text.RegularExpressions;
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

        #region RightsHolder
        private string _rightsHolder;
        public string RightsHolder
        {
            get { return _rightsHolder; }
            set { _rightsHolder = value; }
        }
        #endregion RightsHolder

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
<?xml-model href=""metadataWbt-1.1.rnc"" type=""application/relax-ng-compact-syntax""?>
<DBLScriptureProject resourceURI="""" xml:base=""http://purl.org/ubs/metadata/dc/terms/"" xmlns:dcds=""http://purl.org/dc/xmlns/2008/09/01/dc-ds-xml/"">
  <identification>
    <systemId type=""dbl"" dcds:propertyURI=""identifier/dblID""/>
    <name dcds:propertyURI=""title"">Da Jesus book</name>
    <nameLocal>Da Jesus book</nameLocal>
    <abbreviation>hwcNT</abbreviation>
    <abbreviationLocal>hwcNT</abbreviationLocal>
    <scope dcds:propertyURI=""title/scriptureScope"">NT</scope>
    <description dcds:propertyURI=""description"">1st ed.</description>
    <dateCompleted dcds:propertyURI=""date"" dcds:sesURI=""http://purl.org/dc/terms/W3CDTF"">2000</dateCompleted>
    <systemId type=""tms"" dcds:propertyURI=""identifier/tmsID""/>
    <systemId type=""reap"" dcds:propertyURI=""identifier/reapID"" >http://www.reap.insitehome.org/handle/9284745/16286</systemId>
    <systemId type=""paratext"" dcds:propertyURI=""identifier/ptxID""/>
    <isResource>No</isResource>
    <bundleVersion>1.1</bundleVersion>
    <bundleProducer>Paratext/7.3.0.60</bundleProducer>
  </identification>
  <confidential dcds:propertyURI=""accessRights/confidential"">No</confidential>
  <agencies>
    <etenPartner>WBT</etenPartner>
    <translation dcds:propertyURI=""description/sponsorship"">Wycliffe Inc.</translation>
    <publishing dcds:propertyURI=""publisher"">Wycliffe Inc.</publishing>
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
      <abbreviation>hwcNT</abbreviation>
      <abbreviationLocal>hwcNT</abbreviationLocal>
      <description>NT: 1st Edition</description>
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
    <rightsHolder dcds:propertyURI=""rightsHolder"">Wycliffe Inc.</rightsHolder>
    <rightsHolderLocal dcds:propertyURI=""rightsHolder/contactLocal"">Wycliffe Inc.</rightsHolderLocal>
    <rightsHolderAbbreviation dcds:propertyURI=""rightsHolder/contactAbbreviation"">WBT</rightsHolderAbbreviation>
    <rightsHolderURL dcds:propertyURI=""rightsHolder/contactURL"">http://www.wycliffe.org</rightsHolderURL>
    <rightsHolderFacebook dcds:propertyURI=""rightsHolder/contactFacebook"">http://www.facebook.com/WycliffeUSA</rightsHolderFacebook>
  </contact>
  <rights>
    <dateLicense dcds:propertyURI=""accessRights/pubLicenseDate"" dcds:sesURI=""http://purl.org/dc/terms/W3CDTF"">2011-06-22</dateLicense>
    <dateLicenseExpiry dcds:propertyURI=""accessRights/pubLicenseExpiryDate"" dcds:sesURI=""http://purl.org/dc/terms/W3CDTF"">2014-06-22</dateLicenseExpiry>
    <rightsStatement dcds:propertyURI=""rights"" contentType=""xhtml"">© 2000, Wycliffe Inc. All Rights Reserved.</rightsStatement>
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

        #region dblMetaDataSchema
        private const string DblMetaDataSchema = @"default namespace = """"
namespace dcds = ""http://purl.org/dc/xmlns/2008/09/01/dc-ds-xml/""

start =
  element DBLScriptureProject {
    # resourceURI is overwritten by Paratext
    attribute resourceURI { xsd:anyURI },
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
            text 
            }
         # Name local should default to name 
       | nameLocal
       | element dateCompleted {
           attribute dcds:propertyURI { ""date"" },
           attribute dcds:sesURI { ""http://purl.org/dc/terms/W3CDTF"" },
           xsd:string { pattern = ""\d\d\d\d"" }
           }
       | element scope {
           attribute dcds:propertyURI { ""title/scriptureScope"" },
           (""NT"" | ""BI"") 
           }
         # systemId[@type='dbl'] is overwritten by Paratext
         # systemId[@type='paratext'] is overwritten by Paratext
       | element systemId {
           attribute type { ""dbl"" | ""tms"" | ""reap"" | ""paratext"" | ""biblica"" },
           attribute dcds:propertyURI { ""identifier/dblID"" | ""identifier/tmsID"" | ""identifier/reapID"" | ""identifier/ptxID"" | ""identifier/biblicaID"" },
           text 
           })+,
      # isResource is overwritten by Paratext
      element isResource { ""Yes"" | ""No"" },
      # bundleVersion is overwritten by Paratext
      element bundleVersion { xsd:decimal },
      # bundleProducer is overwritten by Paratext
      element bundleProducer { text }
    },
    element confidential {
      attribute dcds:propertyURI { ""accessRights/confidential"" },
      (""Yes"" | ""No"")
    },
    element agencies {
      element etenPartner { ""UBS"" | ""WBT"" | ""Biblica"" },
      element translation { 
        attribute dcds:propertyURI { ""description/sponsorship"" },
        (""Wycliffe Inc."")
        },
      # publishing may be the same as translation (description/sponsorship) 
      element publishing {
        attribute dcds:propertyURI { ""publisher"" },
        (""Wycliffe Inc."")
        }
    },
    element language {
      element iso { 
        attribute dcds:propertyURI { ""language/iso"" },
        attribute dcds:sesURI { ""http://purl.org/dc/terms/ISO639-3"" },
        xsd:string { pattern = ""[a-z][a-z][a-z]"" } 
        },
      element name { 
        attribute dcds:propertyURI { ""subject/subjectLanguage"" },
        attribute dcds:sesURI { ""http://purl.org/dc/terms/ISO639-3"" }, 
        text 
        },
      element script {
        attribute dcds:propertyURI { ""language/script"" },
        xsd:NCName 
        },
      # LTR (Left to Right) or RTL (Right to Left) 
      # scriptDirection is overwritten by Paratext
      element scriptDirection {
        attribute dcds:propertyURI { ""language/scriptDirection"" },
        (""LTR"" | ""RTL"") 
        }
    },
    element country { 
      element iso { 
      attribute dcds:propertyURI { ""coverage/spatial"" },
      attribute dcds:sesURI { ""http://purl.org/dc/terms/ISO3166"" }, 
      xsd:NCName 
      }, 
    element name { 
      attribute dcds:propertyURI { ""subject/subjectCountry"" }, 
      text 
      }},
    element translation { 
      element type { 
        attribute dcds:propertyURI { ""type/translationType"" }, 
        (""First"" | ""New"" | ""Revision"") 
        }, 
      element level {
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
        element name { text }, 
        # default to name local from identification section 
        nameLocal, 
        abbreviation, 
        abbreviationLocal, 
        # ""NT"" | ""NT + OT"" or <Name> from Cannons.xml
        element description { text }, 
        # Protestant Bible (66 books) 
        element range { (""Protestant New Testament (27 books)"" | ""Protestant Bible (66 books)"") }, 
        # Western Protestant order 
        element tradition { ""Western Protestant order"" },
        element division {
          attribute id { ""OT"" | ""NT"" | ""DC"" },
          element books { 
            element book { 
              attribute code { bookCode }
            }+ } }+ }+ },
    # 1 = draft, 2 = internalReview, 3 = extenalReview, 4 = finalReview 
    # progress is overwritten by Paratext
    element progress {
      attribute dcds:propertyURI { ""description/stage"" },
      element book {
        attribute code { bookCode },
        attribute stage {""1"" | ""2"" | ""3"" | ""4"" | ""-1""}
      }*
    },
    element checking {
      # validatedMarkers is overwritten by Paratext
      element validatedMarkers {
        attribute dcds:propertyURI { ""conformsTo/validatedMarkers"" },
        (""Yes"" | ""No"")
      },
      # validatedVerses is overwritten by Paratext
      element validatedVerses {
        attribute dcds:propertyURI { ""conformsTo/validatedVerses"" },
        (""Yes"" | ""No"")
      }
    },
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
    element rights {
	  # yyyy-mm-dd 
      element dateLicense {
        attribute dcds:propertyURI { ""accessRights/pubLicenseDate"" },
        attribute dcds:sesURI { ""http://purl.org/dc/terms/W3CDTF"" },
        xsd:date
      },
	  # yyyy-mm-dd (must be after dateLicense) 
      element dateLicenseExpiry {
        attribute dcds:propertyURI { ""accessRights/pubLicenseExpiryDate"" },
        attribute dcds:sesURI { ""http://purl.org/dc/terms/W3CDTF"" },
        xsd:date
      },
	  # For example: ©1983, 1992 SIL International 
      element rightsStatement {
        attribute contentType { ""xhtml"" },
        attribute dcds:propertyURI { ""rights"" },
        htmlMarkup
      },
      element publicationRights {
        element allowOffline { ""Yes"" | ""No"" },
        element allowAudio { ""Yes"" | ""No"" },
        element allowFootnotes { ""Yes"" | ""No"" },
        element allowCrossReferences { ""Yes"" | ""No"" },
		# default to No? 
        element allowNewPublishers { ""Yes"" | ""No"" },
        element denyPlatforms { empty },
        element exchangeLicenseFCBH { licenseType | ""No"" }
      }
    },
    element promotion {
      element promoVersionInfo {
        attribute contentType { ""xhtml"" },
        attribute dcds:propertyURI { ""description/pubPromoVersionInfo"" },
		htmlMarkup
      },
      element promoEmail {
        attribute dcds:propertyURI { ""description/pubPromoEmail"" },
        text
      }
    },
    element archiveStatus {
      # archivistName is overwritten by Paratext
      element archivistName {
        attribute dcds:propertyURI { ""contributor/archivist"" },
        text
      },
	  # yyyy-mm-dd
      # dateArchived is overwritten by Paratext
      element dateArchived {
        attribute dcds:propertyURI { ""dateSubmitted"" },
        attribute dcds:sesURI { ""http://purl.org/dc/terms/W3CDTF"" },
        xsd:date
      },
      # dateUpdated is overwritten by Paratext
      element dateUpdated {
        attribute dcds:propertyURI { ""modified"" },
        attribute dcds:sesURI { ""http://purl.org/dc/terms/W3CDTF"" },
        xsd:date
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
nameLocal = element nameLocal { text }
abbreviation = element abbreviation { 
	xsd:string { pattern = ""[a-z][a-z][a-z]NT"" } 
	}
abbreviationLocal = element abbreviationLocal { 
	xsd:string { pattern = ""[a-z][a-z][a-z]NT"" } 
	}
htmlMarkup = (text
         | element p { (text | htmlCharMarkup)+ }
         | element h1 { text }
         | element h2 { text }
         | element h3 { text }
         | element ul { 
             element li { text }+}
         | element ol { 
             element li { text }+}
         | element blockquote { text }
         | htmlCharMarkup)+
htmlCharMarkup = (element a {
             attribute href { xsd:anyURI },
             attribute rel { text }?,
             (htmlCharMarkup | text)
           }
         | element img {
             attribute alt { text }?,
             attribute style { text }?,
             attribute src { xsd:anyURI }
           }
         | element br { empty }
         | element strong { text }
         | element b { text }
         | element em { text }
         | element i { text })
bookCode = (""GEN""   # Genesis
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

        #region _publisherData
        private readonly string _publisherData = @"
<root>
<publisher name=""Wycliffe Inc."" rights=""Wycliffe Inc."" url=""http://www.wycliffe.org"" fb=""http://www.facebook.com/WycliffeUSA""/>
<publisher name=""La Liga Bíblica"" rights=""Bible League International"" url=""http://www.bibleleague.org/"" fb=""http://www.facebook.com/BibleLeagueInternational""/>
<publisher name=""Bible League International"" rights=""Bible League International"" url=""http://www.bibleleague.org/"" fb=""http://www.facebook.com/BibleLeagueInternational""/>
<publisher name=""Bible League"" rights=""Bible League International"" url=""http://www.bibleleague.org/"" fb=""http://www.facebook.com/BibleLeagueInternational""/>
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
            _title = GetValue("//default:title");
            _languageCode = GetField("//default:tr[default:td='dc.language.iso']/default:td[2]", 0);
            _languageName = GetField("//default:tr[default:td='dc.language.iso']/default:td[2]", 1);
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
            var rawScope = "WNT:New Testament";
            if (!_options.AlwaysUseNT)
                rawScope = GetValue("//default:tr[default:td='dc.title.scriptureScope']/default:td[2]");
            _scope = TextField(rawScope, 0).Substring(1);
            _abbreviation = _languageCode + _scope;
            _confidential = GetValue("//default:tr[default:td='sil.sensitivity.metadata']/default:td[2]").ToLower() == "public" ? "No" : "Yes";
            _dateCompleted = GetValue("//default:meta[@name='DCTERMS.issued']/@content");
            _publisher = GetValue("//default:meta[@name='DC.publisher'][1]/@content");
            if (_publisher.ToLower().Contains("wycliffe"))
                _publisher = "Wycliffe Inc.";
            var rightsHolderNode = _publisherDoc.SelectSingleNode(string.Format("//publisher[@name='{0}']/@rights", _publisher));
            if (rightsHolderNode != null)
            {
                _rightsHolder = rightsHolderNode.InnerText;
                _publisher = _rightsHolder;
            }
            else
                _rightsHolder = _publisher;
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
            _isbn = GetValue("//default:tr[default:td='dc.identifier.isbn']/default:td[2]");
            _reapUrl = GetValue("//default:tr[default:td='dc.identifier.uri']/default:td[2]");
            _countryCode = GetField("//default:meta[@name='DCTERMS.spatial'][1]/@content", 0);
            _countryName = GetField("//default:meta[@name='DCTERMS.spatial'][1]/@content", 1);
            _range = GetValue("//default:tr[default:td='dc.description.edition']/default:td[2]");
            var valueWords = _range.Split(' ');
            var range = _scope == "NT" ? "NT" : "<><> Check Range <><>";
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
            _rangeDescription = TextField(rawScope, 1);
            if (_confidential == "No")
            {
                ResetPromoStatements();
            }
            else
            {
                _rightsStatement = "© " + _dateCompleted + ", " + _rightsHolder;
                _promoInfo = "<><>No promoVersionInfo<><>";
                _promoEmail = "<><>No promoVersionEmail<><>";
            }
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
            _rightsStatement = "© " + _dateCompleted + ", " + _rightsHolder + ". All rights reserved.";
            _rightsStatement = _rightsStatement.Replace("..", ".");
            promoStatements.AddParagraph(_rightsStatement);
            promoStatements.AddLicense();
            if (_isbn != null && _isbn.Substring(0,4) != "<><>")
                promoStatements.AddIsbn(_isbn);
            promoStatements.AddDescription(_edition, _rangeDescription, _languageName, _languageCode);
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
            SetValue(_script, "//language/script");
            SetValue(_scriptDirection, "//language/scriptDirection");
            SetValue(_scope, "//identification/scope");
            SetValue(_confidential, "//confidential");
            SetValue(_dateCompleted, "//identification/dateCompleted");
            SetValue(_reapUrl, "//identification/systemId[@type='reap']");
            //SetValue(_publisher, "//agencies/translation"); -- we are using the agency in the constant above for all uploaded files.
            //SetValue(_publisher, "//agencies/publishing");
            SetValue(_options.TransAgency, "//agencies/translation"); 
            SetValue(_options.TransAgency, "//agencies/publishing");
            SetValue(_rightsHolder, "//contact/rightsHolder");
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

        internal void Save(string p)
        {
            var sw = new StreamWriter(p);
            var xw = XmlWriter.Create(sw);
            _dblMetaDataDoc.WriteContentTo(xw);
            xw.Close();
            sw.Close();

            var folder = Path.GetDirectoryName(p);
            var schemaName = Path.Combine(folder, "metadataWbt-1.1.rnc");
            var schemaStreamWriter = new StreamWriter(schemaName);
            schemaStreamWriter.Write(DblMetaDataSchema);
            schemaStreamWriter.Close();
        }

        internal string GetDefaultName()
        {
            return _languageCode + "MetaData";
        }
    }
}
