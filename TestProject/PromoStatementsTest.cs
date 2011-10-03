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
// File: PromoStatementsTest.cs
// Responsibility: Trihus
// ---------------------------------------------------------------------------------------------
using DblMetaData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for PromoStatementsTest and is intended
    ///to contain all PromoStatementsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PromoStatementsTest
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
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
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
        ///A test for AddDescription
        ///</summary>
        [TestMethod()]
        public void AddDescriptionTest()
        {
            PromoStatements target = new PromoStatements(); // TODO: Initialize to an appropriate value
            string edition = string.Empty; // TODO: Initialize to an appropriate value
            string range = string.Empty; // TODO: Initialize to an appropriate value
            string language = string.Empty; // TODO: Initialize to an appropriate value
            target.AddDescription(edition, range, language);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddIsbn
        ///</summary>
        [TestMethod()]
        public void AddIsbnTest()
        {
            PromoStatements target = new PromoStatements(); // TODO: Initialize to an appropriate value
            string isbn = string.Empty; // TODO: Initialize to an appropriate value
            target.AddIsbn(isbn);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddLicense
        ///</summary>
        [TestMethod()]
        public void AddLicenseTest()
        {
            PromoStatements target = new PromoStatements(); // TODO: Initialize to an appropriate value
            target.AddLicense();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddParagraph
        ///</summary>
        [TestMethod()]
        public void AddParagraphTest()
        {
            PromoStatements target = new PromoStatements(); // TODO: Initialize to an appropriate value
            string value = string.Empty; // TODO: Initialize to an appropriate value
            target.AddParagraph(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToEscapedString
        ///</summary>
        [TestMethod()]
        public void ToEscapedStringTest()
        {
            PromoStatements target = new PromoStatements(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToEscapedString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToHtml
        ///</summary>
        [TestMethod()]
        public void ToHtmlTest()
        {
            PromoStatements target = new PromoStatements(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToHtml();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
