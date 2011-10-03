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
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
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
            _tf = new TestFiles();
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
            target.Load(_tf.InputData("REAP record page.xml"));
            target.ScrapeReapData();
            Assert.AreEqual("Da Jesus book", target.Title);
            Assert.AreEqual("hwc", target.LanguageCode);
            Assert.AreEqual("Hawai'i Creole English", target.LanguageName);
            Assert.AreEqual("WNT:New Testament", target.Scope);
            Assert.AreEqual("No", target.Confidential);
            Assert.AreEqual("2000", target.DateCompleted);
            Assert.AreEqual("Wycliffe Bible Translators", target.Publisher);
            Assert.AreEqual("http://www.reap.insitehome.org/handle/9284745/16286", target.ReapUrl);
            Assert.AreEqual("US", target.CountryCode);
            Assert.AreEqual("United States", target.CountryName);
            Assert.AreEqual("1st ed.", target.Edition);
            Assert.AreEqual("New", target.EditionType);
            Assert.AreEqual("NT:1st ed.", target.Range);
            Assert.AreEqual("New Testament", target.RangeDescription);
        }

        /// <summary>
        ///A test for ScrapeReapData
        ///</summary>
        [TestMethod()]
        public void ScrapeReapDataTest2()
        {
            var target = new DblMetaDataScraper();
            target.Load(_tf.InputData("acuReap.xml"));
            target.ScrapeReapData();
            Assert.AreEqual("Yuse chichame aarmauri: Yamaram chicham", target.Title);
            Assert.AreEqual("acu", target.LanguageCode);
            Assert.AreEqual("Achuar-shiwiar", target.LanguageName);
            Assert.AreEqual("WNT:New Testament", target.Scope);
            Assert.AreEqual("No", target.Confidential);
            Assert.AreEqual("1981", target.DateCompleted);
            Assert.AreEqual("Liga Bíblica Mundial del Hogar", target.Publisher);
            Assert.AreEqual("http://www.reap.insitehome.org/handle/9284745/29385", target.ReapUrl);
            Assert.AreEqual("PE", target.CountryCode);
            Assert.AreEqual("Peru", target.CountryName);
            Assert.AreEqual("[1st] ed.", target.Edition);
            Assert.AreEqual("New", target.EditionType);
            Assert.AreEqual("NT:[1st] ed.", target.Range);
            Assert.AreEqual("New Testament", target.RangeDescription);
        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod()]
        public void SaveTest()
        {
            var target = new DblMetaDataScraper();
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
            const string webDocText = @"<?xml version=""1.0""?><html><head><title>My Title</title></head><body></body></html>";
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
            target.Load(_tf.InputData("REAP record page.xml"));
            target.ScrapeReapData();
            target.InsertDataInDblMetaData(publicationDescription);
            var abbrNode = target._dblMetaDataDoc.SelectSingleNode("//abbreviation");
            var actualAbbr = (abbrNode != null) ? abbrNode.InnerText : "No abbreviation node!";
            Assert.AreEqual("hwc-NT", actualAbbr);
            var promoInfNode = target._dblMetaDataDoc.SelectSingleNode("//promoVersionInfo");
            var actualPromoInf = (promoInfNode != null) ? promoInfNode.InnerText : "No promoVersionInfo node!";
            Assert.AreEqual(publicationDescription, actualPromoInf.Substring(0, publicationDescription.Length));
        }

        /// <summary>
        ///A test for GetValue
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DblMetaData.exe")]
        public void GetValueTest()
        {
            var target = new DblMetaDataScraper_Accessor();
            const string webDocText = @"<?xml version=""1.0""?><html><head><title>My Title</title></head><body></body></html>";
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
            const string webDocText = @"<?xml version=""1.0""?><html><head><title>Type:My Title</title></head><body></body></html>";
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
    }
}
