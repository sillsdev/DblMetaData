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
// File: DblMetaDataTest.cs
// Responsibility: Trihus
// ---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DblMetaData;
using NUnit.Framework;

namespace Test
{
    public class DblMetaDataTest : DblMetaDataScraper
    {
        private TestFiles _tf;
        [TestFixtureSetUp]
        public void Setup()
        {
            _tf = new TestFiles();
        }

        [Test]
        public void ScrapeReapDataTest()
        {
            var dblMetaDataScraper = new DblMetaDataScraper();
            dblMetaDataScraper.Load(_tf.InputData("REAP record page.xml"));
            dblMetaDataScraper.ScrapeReapData();
            Assert.AreEqual("Da Jesus book", _title);
            Assert.AreEqual("hwc", _languageCode);
            Assert.AreEqual("Hawai'i Creole English", _languageName);
            Assert.AreEqual("WNT:New Testament", _scope);
            Assert.AreEqual("No", _confidential);
            Assert.AreEqual("2000", _dateCompleted);
            Assert.AreEqual("Wycliffe Bible Translators", _publisher);
            Assert.AreEqual("http://www.reap.insitehome.org/handle/9284745/16286", _reapUrl);
            Assert.AreEqual("US", _countryCode);
            Assert.AreEqual("United States", _countryName);
            Assert.AreEqual("1st ed.", _edition);
            Assert.AreEqual("New", _editionType);
            Assert.AreEqual("NT:1st ed.", _range);
            Assert.AreEqual("New Testament", _rangeDescription);
        }
    }
}
