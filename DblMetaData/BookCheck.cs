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
// File: BookCheck.cs
// Responsibility: Trihus
// ---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;

namespace DblMetaData
{
    public partial class BookCheck : Form
    {
        public BookCheck()
        {
            InitializeComponent();
        }

        public void LoadBooks(XmlNode bookList)
        {
            foreach (XmlNode division in bookList.SelectNodes("//division"))
            {
                Debug.Assert(division.Attributes != null);
                var node = bookTree.Nodes.Add(division.Attributes["id"].InnerText);
                node.Checked = true;
                LoadBookNodes(node, division);
            }
            bookTree.ExpandAll();
        }

        private void LoadBookNodes(TreeNode node, XmlNode division)
        {
            foreach (XmlNode bookNode in division.SelectNodes(".//book"))
            {
                Debug.Assert(bookNode.Attributes != null);
                var subNode = node.Nodes.Add(bookNode.Attributes["code"].InnerText);
                subNode.Checked = true;
            }
        }

        public ArrayList SelectedBooks()
        {
            var books = new ArrayList();
            foreach (TreeNode division in bookTree.Nodes)
            {
                foreach (TreeNode node in division.Nodes)
                {
                    if (node.Checked)
                    {
                        books.Add(node.Text);
                    }
                }
            }
            return books;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bookTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode subnode in e.Node.Nodes)
            {
                subnode.Checked = e.Node.Checked;
            }
        }
    }
}
