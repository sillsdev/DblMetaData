// ---------------------------------------------------------------------------------------------
#region // Copyright (c) 2013, SIL International. All Rights Reserved.
// <copyright from='2011' to='2013' company='SIL International'>
//		Copyright (c) 2013, SIL International. All Rights Reserved.
//
//		Distributable under the terms of either the Common Public License or the
//		GNU Lesser General Public License, as specified in the LICENSING.txt file.
// </copyright>
#endregion
//
// File: UpdateBookList.cs
// Responsibility: Trihus
// ---------------------------------------------------------------------------------------------
using System;
using Microsoft.Win32;
using System.Security.Permissions;
using System.Xml;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace DblMetaData
{
    public class UpdateBookList
    {
        public UpdateBookList(DblMetaDataScraper scrapedData)
        {

            var paratextPath = GetValueFromRegistry(@"SOFTWARE\ScrChecks\1.0\Settings_Directory", "");
            var projectList = GetListOfProjects(scrapedData.LanguageCode, paratextPath);
            var chosenProject = (string)projectList[0];
            if (projectList.Count > 1)
            {
                //chosenProject = ChooseProject(projects);      - assuming first if more than one.
            }
            var books = CollectChosenBookList(chosenProject, paratextPath);
            scrapedData.SetBooks(books);
        }

        private static ArrayList GetListOfProjects(string languageCode, string paratextPath)
        {
            var projectList = new ArrayList();
            var ssfDoc = new XmlDocument { XmlResolver = null };
            var directoryInfo = new DirectoryInfo(paratextPath);

            foreach (FileInfo fileInfo in directoryInfo.GetFiles("*.ssf"))
            {
                ssfDoc.Load(fileInfo.FullName);
                var node = ssfDoc.SelectSingleNode("//EthnologueCode");
                if (node != null && node.InnerText == languageCode)
                {
                    projectList.Add(fileInfo.FullName);
                }
                ssfDoc.RemoveAll();
            }
            if (projectList.Count == 0)
            {
                throw new FileNotFoundException();
            }
            return projectList;
        }

        private static ArrayList CollectChosenBookList(string chosenProject, string paratextPath)
        {
            var ssfDoc = new XmlDocument { XmlResolver = null };

            ssfDoc.Load(chosenProject);
            var books = new ArrayList();
            var bookNodes = ssfDoc.SelectNodes("//*[substring(local-name(),1,1) = 'B' and substring(local-name(),2,1) <= '9']");
            if (bookNodes.Count > 0)
            {
                CollectBooksFromNodes(bookNodes, books);
            }
            else
            {
                CollectBooksFromDirectory(chosenProject, paratextPath, books);
            }
            ssfDoc.RemoveAll();
            if (books.Count == 0)
            {
                throw new ArgumentException();
            }
            return books;
        }

        private static void CollectBooksFromNodes(XmlNodeList bookNodes, ArrayList books)
        {
            foreach (XmlNode node in bookNodes)
            {
                var match = Regex.Match(node.Name, "_([A-Z0-9]*)");
                if (match.Success)
                {
                    books.Add(match.Groups[1].Value);
                }
            }
        }

        private static void CollectBooksFromDirectory(string chosenProject, string paratextPath, ArrayList books)
        {
            var namePart = Path.GetFileNameWithoutExtension(chosenProject);
            var projDirectoryInfo = new DirectoryInfo(Path.Combine(paratextPath, namePart));
            foreach (FileInfo bookInfo in projDirectoryInfo.GetFiles("*.SFM"))
            {
                var match = Regex.Match(bookInfo.Name, "^[0-9]{2}([0-9A-Z]{3})");
                if (match.Success)
                {
                    books.Add(match.Groups[1].Value);
                }
            }
        }

        private static string GetValueFromRegistry(string subKey, string keyName)
        {
            // Opening the registry key

            RegistryKey rk = Registry.LocalMachine;
            // Open a subKey as read-only

            RegistryKey sk1 = rk.OpenSubKey(subKey);
            // If the RegistrySubKey doesn't exist -> (null)

            if (sk1 == null)
            {
                return null;
            }
            else
            {
                try
                {
                    if (RegistryCanRead(keyName.ToUpper()) == false)
                    {
                        return null;
                    }

                    // If the RegistryKey exists I get its value
                    return (string)sk1.GetValue(keyName.ToUpper());
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        private static bool RegistryCanRead(string registry)
        {
            bool isPermission;
            try
            {
                RegistryPermission perm1 = new RegistryPermission(RegistryPermissionAccess.Read, registry);
                perm1.Demand();
                isPermission = true;
            }
            catch (System.Security.SecurityException ex)
            {
                isPermission = false;
            }
            return isPermission;
        }

    }
}
