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
// File: TextFiles.cs
// Responsibility: Trihus
// ---------------------------------------------------------------------------------------------
using System;
using System.IO;
using System.Threading;

namespace TestProject
{
    public class TestFiles
    {
        private string _inputPath;
        private string _outputPath;
        private string _expectedPath;

        public TestFiles()
        {
            string curDir = Environment.CurrentDirectory;
            int testPart = curDir.IndexOf("TestProject") + 11;
            string testPath = Path.Combine(curDir.Substring(0, testPart), "TestFiles");
            _inputPath = Path.Combine(testPath, "Input");
            _outputPath = Path.Combine(testPath, "output");
            _expectedPath = Path.Combine(testPath, "Expected");
            if (Directory.Exists(_outputPath))
            {
                Directory.Delete(_outputPath, true);
                Thread.Sleep(1000);
            }
            Directory.CreateDirectory(_outputPath);
        }

        public string Input(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return _inputPath;
            return Path.Combine(_inputPath, fileName);
        }

        public string InputData(string fileName)
        {
            string fullName = Input(fileName);
            var sr = new StreamReader(fullName);
            string fileData = sr.ReadToEnd();
            sr.Close();
            return fileData;
        }

        public string Copy(string fileName)
        {
            string output = Output(fileName);
            File.Copy(Input(fileName), output, true);
            return output;
        }

        public string Output(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return _outputPath;
            return Path.Combine(_outputPath, fileName);
        }

        public string SubOutput(string test, string fileName)
        {
            var subPath = Path.Combine(_outputPath, test);
            if (!Directory.Exists(subPath))
            {
                Directory.CreateDirectory(subPath);
                Thread.Sleep(1000);
            }
            if (string.IsNullOrEmpty(fileName))
                return subPath;
            return Path.Combine(subPath, fileName);
        }

        public string Expected(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return _expectedPath;
            return Path.Combine(_expectedPath, fileName);
        }

        public string SubExpected(string test, string fileName)
        {
            var subPath = Path.Combine(_expectedPath, test);
            if (string.IsNullOrEmpty(fileName))
                return subPath;
            return Path.Combine(subPath, fileName);
        }
    }
}
