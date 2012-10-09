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
// File: FileAssert.cs
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
    public class FileAssert
    {
        public static void AreEqual(Stream expectStream, Stream outputStream, string msg)
        {
            try
            {
                if (outputStream.Length != expectStream.Length)
                    Assert.Fail("{0}: Output is {1} bytes, Expected {2}", msg, outputStream.Length, expectStream.Length);
                for (long i = expectStream.Length; i > 0; i--)
                {
                    var expect = expectStream.ReadByte();
                    var output = outputStream.ReadByte();
                    if (expect != output)
                        Assert.Fail(string.Format("{0} at {1} of {0}", msg, i, expectStream.Length));
                }
                expectStream.Close();
                outputStream.Close();
            }
            catch (Exception)
            {
                Assert.Fail(msg);
            }
        }

        public static void AreEqual(StreamReader expectStream, StreamReader outputStream, string msg)
        {
            try
           {
                while (!expectStream.EndOfStream)
                {
                    var expect = expectStream.ReadToEnd();
                    var output = outputStream.ReadToEnd();
                    if (expect != output)
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
        public static void AreEqual(string expectPath, string outputPath, string msg)
        {
            try
            {
                StreamReader expectStream = new StreamReader(expectPath);
                StreamReader outputStream = new StreamReader(outputPath);
                AreEqual(expectStream, outputStream, msg);
            }
            catch (Exception)
            {
                Assert.Fail(msg);
            }
        }

        public static void AreEqual(StreamReader expectStream, StreamReader outputStream)
        {
            AreEqual(expectStream, outputStream, null);
        }

        public static void AreEqual(string expectPath, string outputPath)
        {
            AreEqual(expectPath, outputPath, null);
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
