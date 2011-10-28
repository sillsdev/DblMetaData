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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DblMetaData
{
    class PromoStatements
    {
        private string _license = @"
<p>This translation is presented for informative purposes and may be used, reproduced in 
whole or in part, copied for information, documentation and study from this Site for the 
User’s personal, non-commercial use, without any right to resell them or to compile or 
create derivative works for sale. Subject to the terms and conditions of the Creative 
Commons License (Attribution-Noncommercial-No Derivative Works). </p>
<p><a href=""http://creativecommons.org/licenses/by-nc-nd/3.0/"">http://creativecommons.org/licenses/by-nc-nd/3.0/</a></p>
";
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
            if (edition == "1st ed.")
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
