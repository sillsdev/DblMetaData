#!/usr/bin/env python
#-----------------------------------------------------------------------------
# Name:        AddToc.py
# Purpose:     Add \toc1, \toc2 and \toc3 to *.SFM files
#
# Author:      <greg_trihus@sil.org>
#
# Created:     2012/06/06
# RCS-ID:      $Id: AddToc.py $
# Copyright:   (c) 2012
# Licence:     <MIT>
#-----------------------------------------------------------------------------
#Boa:PyApp:main

import os,sys,glob

modules ={}

fullName = {"GEN": "Genesis",
            "EXO": "Exodus",
            "LEV": "Leviticus",
            "NUM": "Numbers",
            "DEU": "Deuteronomy",
            "JOS": "Joshua",
            "JDG": "Judges",
            "RUT": "Ruth",
            "1SA": "1 Samuel",
            "2SA": "2 Samuel",
            "1KI": "1 Kings",
            "2KI": "2 Kings",
            "1CH": "1 Chronicles",
            "2CH": "2 Chronicles",
            "EZR": "Ezra",
            "NEH": "Nehemiah",
            "EST": "Esther",
            "JOB": "Job",
            "PSA": "Psalms",
            "PRO": "Proverbs", 
            "ECC": "Ecclesiastes",
            "SNG": "Song of Songs",
            "ISA": "Isaiah",
            "JER": "Jeremiah", 
            "LAM": "Lamentations",
            "EZK": "Ezekiel", 
            "DAN": "Daniel",
            "HOS": "Hosea",
            "JOL": "Joel",
            "AMO": "Amos",
            "OBA": "Obadiah",
            "JON": "Jonah",
            "MIC": "Micah",
            "NAM": "Nahum",
            "HAB": "Habakkuk",
            "ZEP": "Zephaniah",
            "HAG": "Haggai",
            "ZEC": "Zechariah",
            "MAL": "Malachi",
            "MAT": "Matthew",
            "MRK": "Mark",
            "LUK": "Luke",
            "JHN": "John",
            "ACT": "Acts",
            "ROM": "Romans", 
            "1CO": "1 Corinthians",
            "2CO": "2 Corinthians",
            "GAL": "Galatians",
            "EPH": "Ephesians",
            "PHP": "Philippians", 
            "COL": "Colossians",
            "1TH": "1 Thessalonians",
            "2TH": "2 Thessalonians",
            "1TI": "1 Timothy",
            "2TI": "2 Timothy",
            "TIT": "Titus",
            "PHM": "Philemon",
            "HEB": "Hebrews",
            "JAS": "James",
            "1PE": "1 Peter", 
            "2PE": "2 Peter", 
            "1JN": "1 John", 
            "2JN": "2 John", 
            "3JN": "3 John", 
            "JUD": "Jude", 
            "REV": "Revelation" }

def main(argv):
    if len(argv) > 1:
        targetDir = argv[1]
    else:
        targetDir = os.getcwd()
    if targetDir.find('*') < 0:
        targetDir = os.path.join(targetDir, '*.SFM')
    for f in glob.glob(targetDir):
        data = open(f).read()
        line = data.split('\n')
        toc3 = toc2 = toc1 = ''
        headIdx = 1
        if data[:4] == '\\id ':
            toc3 = data[4:7]
        if line[1][:3] == '\h ':
            toc2 = line[1][3:]
            headIdx = 2
        if toc3 != '' and toc2 == '':
            toc2 = fullName[toc3]
        toc1set = False
        for ln in range(headIdx,len(line)):
            if line[ln][:5] == '\\mt1 ' and not toc1set:
                toc1 = line[ln][5:]
                break
            elif line[ln][:4] == '\\mt ': #and not toc1set:
                toc1 = line[ln][4:]
                break
            elif line[ln][:3] == '\\c ':
                break
            elif line[ln][:6] == '\\toc1 ':
                toc1 = ''
                toc1set = True
            elif line[ln][:6] == '\\toc2 ':
                toc2 = ''
            elif line[ln][:6] == '\\toc3 ':
                toc3 = ''
        fl = open(f, 'w')
        for ln in range(0,headIdx):
            fl.write(line[ln] + '\n')
        if headIdx == 1:
            fl.write('\\h ' + toc2 + '\n')
        if toc1 != '':
            fl.write('\\toc1 ' + toc1 + '\n')
        if toc2 != '':
            fl.write('\\toc2 ' + toc2 + '\n')
        if toc3 != '':
            fl.write('\\toc3 ' + toc3 + '\n')
        for ln in range(headIdx,len(line)):
            if line[ln][:6] != '\\toc1 ' or toc1 == '':
                fl.write(line[ln] + '\n')
        fl.close()
if __name__ == '__main__':
    main(sys.argv)
