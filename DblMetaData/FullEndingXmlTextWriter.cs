// From http://stackoverflow.com/questions/1849214/render-empty-xml-elements-as-parent-elements
using System.IO;
using System.Text;
using System.Xml;

namespace DblMetaData
{
    public class FullEndingXmlTextWriter : XmlTextWriter
    {
        public FullEndingXmlTextWriter(TextWriter w)
            : base(w)
        {
        }

        public FullEndingXmlTextWriter(Stream w, Encoding encoding)
            : base(w, encoding)
        {
        }

        public FullEndingXmlTextWriter(string fileName, Encoding encoding)
            : base(fileName, encoding)
        {
        }

        // Add constructor with default UTF8 encoding
        public FullEndingXmlTextWriter(string fileName)
            : base(fileName, Encoding.UTF8)
        {
        }

        // Forces the end tag to be written for empty elements
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            base.WriteStartElement(prefix, localName, ns);
        }

        public override void WriteEndElement()
        {
            this.WriteFullEndElement();
        }
    }
}
