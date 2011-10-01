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
        private string _license = @"      <p>User License: Creative Commons Attribution-Noncommercial-No Derivative Works 3.0 Unported 
        License, <a href=""http://creativecommons.org/licenses/by-nc-nd/3.0/"">http://creativecommons.org/licenses/by-nc-nd/3.0/</a></p>
      
      <ul>
        <li>You may make an exact copy of this Work and share it with others.</li>
        <li>You must credit all shared copies using the attribution text.</li>
        <li>You may not sell this Work or use it to make money.</li>
        <li>You may not change or imitate this Work to create new Works.</li>
        <li>You must share this Work using the same by-nc-nd license.</li>
        <li>Attribution: (c) The Publisher; and, (c) Named Rights holders for materials used by permission as specified in the resource file description.</li>
      </ul>

";
        private StringBuilder _sb;

        public PromoStatements()
        {
            _sb = new StringBuilder();
        }

        public void AddParagraph(string value)
        {
            _sb.Append("<p>" + value + "</p>\r\n\r\n");
        }

        public void AddLicense()
        {
            _sb.Append(_license);
        }

        public void AddIsbn(string isbn)
        {
            _sb.Append(string.Format("<p>Printed book ISBN {0}</p>\r\n\r\n", isbn));
        }

        public void AddDescription(string edition, string range, string language)
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
            _sb.Append(string.Format("in {0}</p>\r\n", language));
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
