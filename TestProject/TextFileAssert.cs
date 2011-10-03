// ---------------------------------------------------------------------------------------------
#region // Copyright (c) 2010, SIL International. All Rights Reserved.
// <copyright from='2010' to='2010' company='SIL International'>
//		Copyright (c) 2010, SIL International. All Rights Reserved.
//
//		Distributable under the terms of either the Common Public License or the
//		GNU Lesser General Public License, as specified in the LICENSING.txt file.
// </copyright>
#endregion
//
// File: TextFileAssert.cs
// Responsibility: Trihus
// ---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    /// ----------------------------------------------------------------------------------------
    /// <summary>
    /// compare text files while ignoring line endings
    /// </summary>
    /// ----------------------------------------------------------------------------------------
    public class TextFileAssert
    {
        public static void AreEqualEx(string expectPath, string outputPath, ArrayList ex, string msg)
        {
            try
           {
                Int32 line = 0;
                StreamReader expectStream = new StreamReader(expectPath);
                StreamReader outputStream = new StreamReader(outputPath);
                while (!expectStream.EndOfStream)
                {
                    line += 1;
                    var expectLine = expectStream.ReadLine();
                    var outputLine = outputStream.ReadLine();
                    if (ex != null && ex.Contains(line)) continue;
                    if (expectLine != outputLine)
                        Assert.Fail(msg);
                }
                if (!outputStream.EndOfStream)
                    Assert.Fail(msg);
                expectStream.Close();
                outputStream.Close();
            }
            catch (Exception)
            {
                Assert.Fail(msg);
            }
        }
        public static void AreEqualEx(string expectPath, string outputPath, ArrayList ex)
        {
            AreEqualEx(expectPath, outputPath, ex, null);
        }
        public static void AreEqual(string expectPath, string outputPath, string msg)
        {
            AreEqualEx(expectPath, outputPath, null, msg);
        }
        public static void AreEqual(string expectPath, string outputPath)
        {
            AreEqualEx(expectPath, outputPath, null, null);
        }
        public static void AreNotEqual(string expectPath, string outputPath, string msg)
        {
            try
            {
                StreamReader expectStream = new StreamReader(expectPath);
                StreamReader outputStream = new StreamReader(outputPath);
                while (!expectStream.EndOfStream)
                {
                    var expectLine = expectStream.ReadLine();
                    var outputLine = outputStream.ReadLine();
                    if (expectLine != outputLine)
                        return;
                }
                if (!outputStream.EndOfStream)
                    return;
                expectStream.Close();
                outputStream.Close();
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail(msg);
        }
    }
}
