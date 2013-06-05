// From http://stackoverflow.com/questions/1849214/render-empty-xml-elements-as-parent-elements
// Testing shows this might not provide the advertized benefit of adding end tags unless you call the methods yourself.
// i.e. the serialization of an in memory xmlDocument doesn't appear to call the WriteEndElement (or the WriteFullEndElement
// doesn't actually add the ending tag on an empty element as the documentation says it does -- I am not sure which.
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
