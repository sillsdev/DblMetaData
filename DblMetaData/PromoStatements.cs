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
// File: PromoStatements.cs
// Responsibility: Trihus
// ---------------------------------------------------------------------------------------------
using System.Text;

namespace DblMetaData
{
    class PromoStatements
    {

        #region license
        private string _license = @"
<p>This translation text is made available to you under the
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
request.</p>
";
        #endregion license

        private StringBuilder _sb;

        public PromoStatements()
        {
            _sb = new StringBuilder();
        }

        public void AddParagraph(string value)
        {
            if (value.Substring(0,1) != "<")
                value = "<p>" + value + "</p>\r\n"; 
            _sb.Append(value + "\r\n");
        }

        internal void AddSubhead(string value)
        {
            if (value.Substring(0, 1) != "<")
                value = "<h2>" + value + "</h2>\r\n";
            _sb.Append(value + "\r\n");
        }

        public void AddLicense()
        {
            _sb.Append(_license);
        }

        public void AddIsbn(string isbn)
        {
            _sb.Append(string.Format("<p>Printed book ISBN {0}</p>\r\n\r\n", isbn));
        }

        public void AddDescription(string edition, string range, string language, string isocode)
        {
            if (edition == "First")
            {
                _sb.Append("<p>First edition<br/>\r\n");
            }
            else
            {
                _sb.Append(string.Format("<p>{0}<br/>\r\n", edition));
            }
            _sb.Append(string.Format("<b>The {0}</b><br/>\r\n", range));
            _sb.Append(string.Format("in <a href=\"http://www.ethnologue.com/show_language.asp?code={0}\">{1}</a></p>\r\n", isocode, language));
        }

        public string ToHtml()
        {
            return _sb.ToString();
        }

        public string ToEscapedString()
        {
            var escapedValue = _sb.ToString();
            escapedValue = escapedValue.Replace("&", "&amp;");
            escapedValue = escapedValue.Replace("<", "&lt;");
            escapedValue = escapedValue.Replace(">", "&gt;");
            escapedValue = escapedValue.Replace("\"", "&quot;");
            return escapedValue;
        }
    }
}
