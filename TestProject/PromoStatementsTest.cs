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
            const string promostatement = @"<p>First edition<br/>
<b>The New Testament</b><br/>
in <a href=""http://www.ethnologue.com/show_language.asp?code=acr"">Achi</a></p>
";
            PromoStatements target = new PromoStatements();
            string edition = "First";
            string range = "New Testament";
            string language = "Achi";
            string isoCode = "acr";
            target.AddDescription(edition, range, language, isoCode);
            Assert.AreEqual(promostatement, target.ToHtml());
        }

        /// <summary>
        ///A test for AddIsbn
        ///</summary>
        [TestMethod()]
        public void AddIsbnTest()
        {
            const string expectedstatement = @"<p>Printed book ISBN 0938978217</p>";
            PromoStatements target = new PromoStatements();
            string isbn = "0938978217";
            target.AddIsbn(isbn);
            Assert.AreEqual(expectedstatement, target.ToHtml().Trim());
        }

        /// <summary>
        ///A test for AddLicense
        ///</summary>
        [TestMethod()]
        public void AddLicenseTest()
        {
            const string expectedstatement = @"<p>This translation text is made available to you under the
terms of the Creative Commons License: Attribution-Noncommercial-No Derivative Works.
(<a href=""http://creativecommons.org/licenses/by-nc-nd/3.0/"">http://creativecommons.org/licenses/by-nc-nd/3.0/</a>)
In addition, you have permission to port the text to different file formats, as long as you
do not change any of the text or punctuation of the Bible.</p>

<p>You may share, copy, distribute, transmit, and extract portions
or quotations from this work, provided that you include the above copyright
information:</p>
<ul>
<li>You must give Attribution to the work.</li>
<li>You do not sell this work for a profit.</li>
<li>You do not make any derivative works that change any of the actual words or punctuation of the Scriptures.</li>
</ul>
<p>Permissions beyond the scope of this license may be
available if you <a href=""mailto:ScriptureCopyrightPermissions_Intl@Wycliffe.org"">contact
us</a> with your request. If you want to revise a translation, use a translation
in an adaptation, or use a translation commercially, we will consider your
request.</p>";
            PromoStatements target = new PromoStatements();
            target.AddLicense();
            Assert.AreEqual(expectedstatement, target.ToHtml().Trim());
        }

        /// <summary>
        ///A test for AddParagraph
        ///</summary>
        [TestMethod()]
        public void AddParagraphTest()
        {
            const string expectedstatement = @"<p>My Paragraph</p>";
            PromoStatements target = new PromoStatements(); 
            target.AddParagraph("My Paragraph");
            Assert.AreEqual(expectedstatement, target.ToHtml().Trim());
        }

        /// <summary>
        ///A test for ToEscapedString
        ///</summary>
        [TestMethod()]
        public void ToEscapedStringTest()
        {
            PromoStatements target = new PromoStatements();
            target.AddParagraph("&\"");
            string expected = "&lt;p&gt;&amp;&quot;&lt;/p&gt;";
            string actual = target.ToEscapedString();
            Assert.AreEqual(expected, actual.Trim());
        }

        /// <summary>
        ///A test for ToHtml
        ///</summary>
        [TestMethod()]
        public void ToHtmlTest()
        {
            PromoStatements target = new PromoStatements();
            target.AddParagraph("My Paragraph");
            string expected = "<p>My Paragraph</p>";
            string actual = target.ToHtml();
            Assert.AreEqual(expected, actual.Trim());
        }
    }
}
