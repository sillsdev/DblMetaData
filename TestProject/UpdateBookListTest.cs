// ---------------------------------------------------------------------------------------------
#region // Copyright (c) 2013, SIL International. All Rights Reserved.
// <copyright from='2013' to='2013' company='SIL International'>
//		Copyright (c) 2013, SIL International. All Rights Reserved.
//
//		Distributable under the terms of either the Common Public License or the
//		GNU Lesser General Public License, as specified in the LICENSING.txt file.
// </copyright>
#endregion
//
// File: UpdatedBookListTest.cs
// Responsibility: Trihus
// ---------------------------------------------------------------------------------------------
using System.IO;
using DblMetaData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Xml;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for UpdateBookListTest and is intended
    ///to contain all UpdateBookListTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UpdateBookListTest
    {


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
        ///A test for UpdateBookList Constructor - we could use injection to test the resulting book list sent to SaveBooks - GT
        ///</summary>
        //[TestMethod()]
        //public void UpdateBookListConstructorTest()
        //{
        //    DblMetaDataScraper scrapedData = null; // TODO: Initialize to an appropriate value
        //    UpdateBookList target = new UpdateBookList(scrapedData);
        //    Assert.Inconclusive("TODO: Implement code to verify target");
        //}

        /// <summary>
        ///A test for CollectBooksFromDirectory
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DblMetaData.exe")]
        public void CollectBooksFromDirectoryTest()
        {
            var chosenProject = _tf.Input("NKOu3.ssf");
            var paratextPath = Path.GetDirectoryName(chosenProject) + Path.DirectorySeparatorChar;
            var books = new ArrayList();
            UpdateBookList_Accessor.CollectBooksFromDirectory(chosenProject, paratextPath, books);
            Assert.AreEqual(1, books.Count);
        }

        /// <summary>
        ///A test for CollectBooksFromNodes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DblMetaData.exe")]
        public void CollectBooksFromNodesTest()
        {
            var ssfDoc = new XmlDocument {XmlResolver = null};
            ssfDoc.Load(_tf.Input("NKOu1.ssf"));
            var bookNodes = ssfDoc.SelectNodes("//*[substring(local-name(),1,1) = 'B' and substring(local-name(),2,1) <= '9']");
            var books = new ArrayList();
            UpdateBookList_Accessor.CollectBooksFromNodes(bookNodes, books);
            Assert.AreEqual(28, books.Count);
        }

        /// <summary>
        ///A test for CollectChosenBookList
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DblMetaData.exe")]
        public void CollectChosenBookListTest()
        {
            var chosenProject = _tf.Input("NKOu3.ssf");
            var paratextPath = Path.GetDirectoryName(chosenProject) + Path.DirectorySeparatorChar;
            var actual = UpdateBookList_Accessor.CollectChosenBookList(chosenProject, paratextPath);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("MAT", actual[0]);
        }

        /// <summary>
        ///A test for GetListOfProjects
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DblMetaData.exe")]
        public void GetListOfProjectsTest()
        {
            const string languageCode = "acr";
            var paratextPath = Path.GetDirectoryName(_tf.Input("accNT.ssf")) + Path.DirectorySeparatorChar;
            var actual = UpdateBookList_Accessor.GetListOfProjects(languageCode, paratextPath);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(Path.Combine(paratextPath,"accNT.ssf"), actual[0]);
        }

        /// <summary>
        ///A test for GetValueFromRegistry
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DblMetaData.exe")]
        public void GetValueFromRegistryTest()
        {
            const string subKey = @"SOFTWARE\ScrChecks\1.0\Settings_Directory";
            var keyName = string.Empty;
            var actual = UpdateBookList_Accessor.GetValueFromRegistry(subKey, keyName);
            Assert.IsTrue(Path.IsPathRooted(actual));
        }

        /// <summary>
        ///A test for RegistryCanRead
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DblMetaData.exe")]
        public void RegistryCanReadTest()
        {
            string registry = @"SOFTWARE\ScrChecks\1.0\Settings_Directory";
            var actual = UpdateBookList_Accessor.RegistryCanRead(registry);
            Assert.IsTrue(actual);
        }
    }
}
