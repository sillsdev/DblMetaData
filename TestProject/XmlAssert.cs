﻿// --------------------------------------------------------------------------------------------
// <copyright file="XmlAssert.cs" from='2009' to='2009' company='SIL International'>
//      Copyright © 2009, SIL International. All Rights Reserved.   
//    
//      Distributable under the terms of either the Common Public License or the
//      GNU Lesser General Public License, as specified in the LICENSING.txt file.
// </copyright> 
// <author>Greg Trihus</author>
// <email>greg_trihus@sil.org</email>
// Last reviewed: 
// 
// <remarks>
// ODT Test Support
// </remarks>
// --------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace TestProject
{
    public static class XmlAssert
    {
        /// <summary>
        /// Compares the XML file at expected path tand output path to make sure they are the same in terms of what matters to XML.
        /// </summary>
        /// <param name="expectPath">expected output path</param>
        /// <param name="outputPath">output path</param>
        /// <param name="msg">message to display if mismatch</param>
        public static void AreEqual(string expectPath, string outputPath, string msg)
        {
            XmlDocument outputDocument = new XmlDocument { XmlResolver = null };
            outputDocument.Load(outputPath);
            XmlDocument expectDocument = new XmlDocument { XmlResolver = null };
            expectDocument.Load(expectPath);
            XmlDsigC14NTransform outputCanon = new XmlDsigC14NTransform();
            outputCanon.Resolver = null;
            outputCanon.LoadInput(outputDocument);
            XmlDsigC14NTransform expectCanon = new XmlDsigC14NTransform();
            expectCanon.Resolver = null;
            expectCanon.LoadInput(expectDocument);
            Stream outputStream = (Stream)outputCanon.GetOutput(typeof(Stream));
            Stream expectStream = (Stream)expectCanon.GetOutput(typeof(Stream));
            FileAssert.AreEqual(expectStream, outputStream, msg);
        }

        public static void Ignore(string path, string xpath, Dictionary<string, string> nameSpaces)
        {
            XmlDocument xmlDocument = new XmlDocument{XmlResolver = null};
            XmlNamespaceManager ns = new XmlNamespaceManager(xmlDocument.NameTable);
            if (nameSpaces != null)
                foreach (string key in nameSpaces.Keys)
                    ns.AddNamespace(key, nameSpaces[key]);
            xmlDocument.Load(path);
            XmlNode xmlNode = xmlDocument.SelectSingleNode(xpath, ns);
            if (xmlNode != null)
            {
                xmlNode.InnerText = "Ignore";
                xmlDocument.Save(path);
            }
            xmlDocument.RemoveAll();
        }
    }
}
