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
// File: DblMetaDataScraperTest.cs
// Responsibility: Trihus
// ---------------------------------------------------------------------------------------------
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using DblMetaData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{


    /// <summary>
    ///This is a test class for DblMetaDataScraperTest and is intended
    ///to contain all DblMetaDataScraperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DblMetaDataScraperTest
    {
        #region TestContext

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #endregion TestContext

        #region Additional test attributes

        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        private static TestFiles _tf;

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            _tf = new TestFiles("TestProject");
        }

        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #endregion

        /// <summary>
        ///A test for ScrapeReapData
        ///</summary>
        [TestMethod()]
        public void ScrapeReapDataTest()
        {
            var target = new DblMetaDataScraper();
            target.Options = new Options();
            target.Load(_tf.InputData("REAP record page.xml"));
            target.ScrapeReapData();
            Assert.AreEqual("Da Jesus Book", target.Title);
            Assert.AreEqual("hwc", target.LanguageCode);
            Assert.AreEqual("Hawai'i Creole English", target.LanguageName);
            Assert.AreEqual("NT", target.Scope);
            Assert.AreEqual("false", target.Confidential);
            Assert.AreEqual("2000", target.DateCompleted);
            Assert.AreEqual("Wycliffe Bible Translators, Inc.", target.Publisher);
            Assert.AreEqual("http://www.reap.insitehome.org/handle/9284745/16286", target.ReapUrl);
            Assert.AreEqual("US", target.CountryCode);
            Assert.AreEqual("United States", target.CountryName);
        }

        [TestMethod()]
        [DeploymentItem("DblMetaData.exe")]
        public void HwcRevewTest()
        {
            DblMetaDataScraper_Accessor.NoDialogueTesting = true;
            var target = new Form1();
            target.ReviewSiteData(_tf.InputData("REAP record page.xml"), "My Description");
            DblMetaDataScraper_Accessor.NoDialogueTesting = false;
        }

        /// <summary>
        ///A test for ScrapeReapData
        ///</summary>
        [TestMethod()]
        public void ScrapeReapDataTest2()
        {
            var target = new DblMetaDataScraper();
            target.Options = new Options();
            target.Load(_tf.InputData("acuReap.xml"));
            target.ScrapeReapData();
            Assert.AreEqual("Yuse chichame aarmauri: Yamaram chicham", target.Title);
            Assert.AreEqual("acu", target.LanguageCode);
            Assert.AreEqual("Achuar-shiwiar", target.LanguageName);
            Assert.AreEqual("NT", target.Scope);
            Assert.AreEqual("false", target.Confidential);
            Assert.AreEqual("1981", target.DateCompleted);
            Assert.AreEqual("Liga Bíblica Mundial del Hogar", target.Publisher);
            Assert.AreEqual("http://www.reap.insitehome.org/handle/9284745/29385", target.ReapUrl);
            Assert.AreEqual("PE", target.CountryCode);
            Assert.AreEqual("Peru", target.CountryName);
        }

        //[TestMethod()]
        //public void AcuRevewTest()
        //{
        //    var target = new Form1();
        //    target.ReviewSiteData(_tf.InputData("acuReap.xml"), "My Description");
        //}

        /// <summary>
        ///A test for ScrapeReapData
        ///</summary>
        [TestMethod()]
        public void ScrapeReapDataTest3()
        {
            var target = new DblMetaDataScraper();
            target.Options = new Options();
            target.Load(_tf.InputData("shu-chad.xhtml"));
            target.ScrapeReapData();
            Assert.AreEqual("أمثال واحدين من الملك سليمان، الجزء التاني", target.Title);
            Assert.AreEqual("shu", target.LanguageCode);
            Assert.AreEqual("Arabic, Chadian", target.LanguageName);
            Assert.AreEqual("Arabic", target.Script);
            Assert.AreEqual("NT", target.Scope);
            Assert.AreEqual("true", target.Confidential);
            Assert.AreEqual("2010", target.DateCompleted);
            Assert.AreEqual("Alliance Biblique du Tchad", target.Publisher);
            Assert.AreEqual("http://www.reap.insitehome.org/handle/9284745/41224", target.ReapUrl);
            Assert.AreEqual("CD", target.CountryCode);
            Assert.AreEqual("Chad", target.CountryName);
        }

        //[TestMethod()]
        //public void ShuRevewTest()
        //{
        //    var target = new Form1();
        //    target.ReviewSiteData(_tf.InputData("shu-chad.xhtml"), "My Description");
        //}

        /// <summary>
        ///A test for ScrapeReapData
        ///</summary>
        [TestMethod()]
        public void ScrapeReapDataTest4()
        {
            var target = new DblMetaDataScraper();
            target.Options = new Options();
            target.Load(_tf.InputData("acrReap.xhtml"));
            target.ScrapeReapData();
            Assert.AreEqual("I 'utz laj tzij re i dios", target.Title);
            Assert.AreEqual("acr", target.LanguageCode);
            Assert.AreEqual("Achi", target.LanguageName);
            Assert.AreEqual("Latin", target.Script);
            Assert.AreEqual("NT", target.Scope);
            Assert.AreEqual("false", target.Confidential);
            Assert.AreEqual("2009", target.DateCompleted);
            Assert.AreEqual("Wycliffe Bible Translators, Inc.", target.Publisher);
            Assert.AreEqual("http://www.reap.insitehome.org/handle/9284745/10273", target.ReapUrl);
            Assert.AreEqual("GT", target.CountryCode);
            Assert.AreEqual("Guatemala", target.CountryName);
        }

        /// <summary>
        ///A test for ScrapeReapData
        ///</summary>
        [TestMethod()]
        public void ScrapeReapDataTest5()
        {
            var target = new DblMetaDataScraper();
            target.Options = new Options();
            target.Load(_tf.InputData("Amuzgo.xml"));
            target.ScrapeReapData();
            Assert.IsTrue(target.ReapUrl.Contains("reap"), "reap url:" + target.ReapUrl);
        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod()]
        public void SaveTest()
        {
            var target = new DblMetaDataScraper();
            target.Options = new Options();
            const string template = "MetaDataTemplate.xml";
            string p = _tf.Output(template);
            target.Save(p);
            XmlAssert.AreEqual(_tf.Expected(template), p, "Invalid Saved Template");
        }

        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DblMetaData.exe")]
        public void LoadTest()
        {
            var target = new DblMetaDataScraper_Accessor();
            const string webDocText =
                @"<?xml version=""1.0""?><html><head><title>My Title</title></head><body></body></html>";
            target.Load(webDocText);
            var titleNode = target._webDoc.SelectSingleNode("//title");
            var title = (titleNode != null) ? titleNode.InnerText : "Missing Title Node";
            Assert.AreEqual("My Title", title);
        }

        /// <summary>
        ///A test for InsertDataInDblMetaData
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DblMetaData.exe")]
        public void InsertDataInDblMetaDataTest()
        {
            var target = new DblMetaDataScraper_Accessor();
            const string publicationDescription = "My Description";
            target.PublicationDescription = publicationDescription;
            target.Options = new Options();
            target.Load(_tf.InputData("REAP record page.xml"));
            target.ScrapeReapData();
            target.InsertDataInDblMetaData();
            TestXpathValue("hwcNT", "//abbreviation", target);
            TestXpathValue("US:hwc:Hawai'i Creole English", "//identification/name", target);
            TestXpathValue("Da Jesus Book", "//identification/nameLocal", target);
            TestXpathValue("hwc", "//language/iso", target);
            TestXpathValue("Hawai'i Creole English", "//language/name", target);
            TestXpathValue("NT", "//identification/scope", target);
            TestXpathValue("false", "//confidential", target);
            TestXpathValue("2000", "//identification/dateCompleted", target);
            TestXpathValue("http://www.reap.insitehome.org/handle/9284745/16286",
                           "//identification/systemId[@type='reap']", target);
            TestXpathValue("Wycliffe Bible Translators, Inc.", "//agencies/publisher", target);
            TestXpathValue("US", "//country/iso", target);
            TestXpathValue("United States", "//country/name", target);
            TestXpathValue("New", "//translationType", target);
            TestXpathValue("NT", "//contents/bookList/description", target);
            TestXpathValue("http://www.wycliffe.org", "//contact/rightsHolderURL", target);
            TestXpathValue("http://www.facebook.com/WycliffeUSA", "//contact/rightsHolderFacebook", target);
            TestXpathValue("© 2000, Wycliffe Bible Translators, Inc. All rights reserved.", "//copyright/statement", target);
            TestXpathValue(publicationDescription, "//promoVersionInfo", target, publicationDescription.Length);
            TestXpathValue("Hi YouVersion friend,Ni", "//promotion/promoEmail", target,
                           publicationDescription.Length + 9);
        }

        private static void TestXpathValue(string expected, string xpath, DblMetaDataScraper_Accessor target,
                                           int len = 0)
        {
            var node = target._dblMetaDataDoc.SelectSingleNode(xpath);
            var actual = (node != null) ? node.InnerText : "No " + xpath.Substring(2) + " node!";
            if (len > 0)
                Assert.AreEqual(expected, actual.Substring(0, len));
            else
                Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetValue
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DblMetaData.exe")]
        public void GetValueTest()
        {
            var target = new DblMetaDataScraper_Accessor();
            const string webDocText =
                @"<?xml version=""1.0""?><html><head><title>My Title</title></head><body></body></html>";
            target.Load(webDocText);
            const string xpath = "//title";
            const string expected = "My Title";
            string actual = target.GetValue(xpath);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetField
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DblMetaData.exe")]
        public void GetFieldTest()
        {
            var target = new DblMetaDataScraper_Accessor();
            const string webDocText =
                @"<?xml version=""1.0""?><html><head><title>Type:My Title</title></head><body></body></html>";
            target.Load(webDocText);
            const string xpath = "//title";
            const int i = 0;
            const string expected = "Type";
            string actual = target.GetField(xpath, i);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SetValue
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DblMetaData.exe")]
        public void SetValueTest()
        {
            var target = new DblMetaDataScraper_Accessor();
            const string value = "hwc-NT";
            const string xpath = "//abbreviation";
            target.SetValue(value, xpath);
            var titleNode = target._dblMetaDataDoc.SelectSingleNode("//abbreviation");
            var actualTitle = (titleNode != null) ? titleNode.InnerText : "Missing Title node!";
            Assert.AreEqual("hwc-NT", actualTitle);
        }

        /// <summary>
        ///A test for SetXmlValue
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DblMetaData.exe")]
        public void SetXmlValueTest()
        {
            var target = new DblMetaDataScraper_Accessor();
            const string value = "<p>My Description</p>";
            const string xpath = "//promoVersionInfo";
            target.SetXmlValue(value, xpath);
            var promoInfNode = target._dblMetaDataDoc.SelectSingleNode(xpath);
            var actualTitle = (promoInfNode != null) ? promoInfNode.InnerText : "Missing promoVersionInfo node!";
            Assert.AreEqual("My Description", actualTitle);
        }

        /// <summary>
        ///A test for SetBooks
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DblMetaData.exe")]
        public void SetBooksTest()
        {
            var target = new DblMetaDataScraper_Accessor();
            DblMetaDataScraper_Accessor.NoDialogueTesting = true;
            var books = new ArrayList();
            books.Add("GEN");
            books.Add("MAT");
            books.Add("MRK");
            books.Add("XXA");
            target.SetBooks(books);
            DblMetaDataScraper_Accessor.NoDialogueTesting = false;
            var bookNodes = target._dblMetaDataDoc.SelectNodes("//book");
            //Selects nodes from both //bookList and //Progress
            Assert.AreEqual(8, bookNodes.Count);
        }

        #region divisions (template)
        private const string divisions = @"<divisions>
            <division id=""OT"">
                <books>
                    <book code=""GEN""/>
                    <book code=""EXO""/>
                    <book code=""LEV""/>
                    <book code=""NUM""/>
                    <book code=""DEU""/>
                    <book code=""JOS""/>
                    <book code=""JDG""/>
                    <book code=""RUT""/>
                    <book code=""1SA""/>
                    <book code=""2SA""/>
                    <book code=""1KI""/>
                    <book code=""2KI""/>
                    <book code=""1CH""/>
                    <book code=""2CH""/>
                    <book code=""EZR""/>
                    <book code=""NEH""/>
                    <book code=""EST""/>
                    <book code=""JOB""/>
                    <book code=""PSA""/>
                    <book code=""PRO""/>
                    <book code=""ECC""/>
                    <book code=""SNG""/>
                    <book code=""ISA""/>
                    <book code=""JER""/>
                    <book code=""LAM""/>
                    <book code=""EZK""/>
                    <book code=""DAN""/>
                    <book code=""HOS""/>
                    <book code=""JOL""/>
                    <book code=""AMO""/>
                    <book code=""OBA""/>
                    <book code=""JON""/>
                    <book code=""MIC""/>
                    <book code=""NAM""/>
                    <book code=""HAB""/>
                    <book code=""ZEP""/>
                    <book code=""HAG""/>
                    <book code=""ZEC""/>
                    <book code=""MAL""/>
                </books>
            </division>
            <division id=""DC"">
                <books>
                    <book code=""TOB""/>
                    <book code=""JDT""/>
                    <book code=""ESG""/>
                    <book code=""WIS""/>
                    <book code=""SIR""/>
                    <book code=""BAR""/>
                    <book code=""LJE""/>
                    <book code=""S3Y""/>
                    <book code=""SUS""/>
                    <book code=""BEL""/>
                    <book code=""1MA""/>
                    <book code=""2MA""/>
                    <book code=""1ES""/>
                    <book code=""2ES""/>
                    <book code=""MAN""/>
                </books>
            </division>
            <division id=""NT"">
                <books>
                    <book code=""MAT""/>
                    <book code=""MRK""/>
                    <book code=""LUK""/>
                    <book code=""JHN""/>
                    <book code=""ACT""/>
                    <book code=""ROM""/>
                    <book code=""1CO""/>
                    <book code=""2CO""/>
                    <book code=""GAL""/>
                    <book code=""EPH""/>
                    <book code=""PHP""/>
                    <book code=""COL""/>
                    <book code=""1TH""/>
                    <book code=""2TH""/>
                    <book code=""1TI""/>
                    <book code=""2TI""/>
                    <book code=""TIT""/>
                    <book code=""PHM""/>
                    <book code=""HEB""/>
                    <book code=""JAS""/>
                    <book code=""1PE""/>
                    <book code=""2PE""/>
                    <book code=""1JN""/>
                    <book code=""2JN""/>
                    <book code=""3JN""/>
                    <book code=""JUD""/>
                    <book code=""REV""/>
                </books>
            </division>
</divisions>";
        #endregion divisons (template)

        /// <summary>
        ///A test for BookCheck
        ///</summary>
        [TestMethod()]
        public void BookCheckTest()
        {
            var target = new BookCheck();
            var divDoc = new XmlDocument {XmlResolver = null};
            divDoc.LoadXml(divisions);
            target.LoadBooks(divDoc.DocumentElement);
            target.ShowDialog();
            var actual = target.SelectedBooks();
            Assert.AreEqual(27, actual.Count);
            Assert.AreEqual("MAT", actual[0]);
            Assert.AreEqual("REV", actual[26]);
        }

        /// <summary>
        ///A test for TextField
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DblMetaData.exe")]
        public void TextFieldTest()
        {
            var target = new DblMetaDataScraper_Accessor();
            const string value = "WNT:New Testament";
            const int i = 0;
            const string expected = "WNT";
            string actual = target.TextField(value, i);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PromoStatementSchemaTest()
        {
            const string testName = "PromoStatementSchema";
            var target = new DblMetaDataScraper();
            target.Options = new Options();
            target.Load(_tf.InputData("REAP record page.xml"));
            target.ScrapeReapData();
            target.InsertDataInDblMetaData();
            target.Save(_tf.Output(testName + ".xml"));
            var process = new Process();
            process.StartInfo.WorkingDirectory = _tf.Output("");
            process.StartInfo.FileName = Path.Combine("..", "..", "..", "xml", "jing.jar");
            process.StartInfo.Arguments = "-c metadataWbt-1.3.rnc " + testName + ".xml";
            process.Start();
            process.WaitForExit();
            Assert.AreEqual(0, process.ExitCode);
        }

        [TestMethod()]
        public void ResetPromoStatementTest()
        {
            const string testName = "ResetPromoStatementTest";
            var target = new DblMetaDataScraper();
            target.Options = new Options();
            target.Load(_tf.InputData("REAP record page.xml"));
            target.ScrapeReapData();
            target.PublicationDescription = @"Name

Description
  

editions
";
            target.ResetPromoStatements();
            target.InsertDataInDblMetaData();
            var fileName = testName + ".xml";
            target.Save(_tf.Output(fileName));
            XmlAssert.AreEqual(_tf.Expected(fileName), _tf.Output(fileName), "Reset Promo statement error");
        }

        [TestMethod()]
        public void Transform12to12()
        {
            const string data = "aucMetadata.xml";
            var xform = new XslTransform();
            xform.Load(_tf.Input("../../../Xml/UpdateMetaData-1.2.xsl"));
            xform.Transform(_tf.Input(data), _tf.Output(data));
            FileAssert.AreEqual(_tf.Expected(data), _tf.Output(data));
        }

        [TestMethod()]
        public void Transform11to12()
        {
            const string data = "metadata0.xml";
            var xform = new XslTransform();
            xform.Load(_tf.Input("../../../Xml/UpdateMetaData-1.2.xsl"));
            xform.Transform(_tf.Input(data), _tf.Output(data));
            FileAssert.AreEqual(_tf.Expected(data), _tf.Output(data));
        }
    }
}

    
