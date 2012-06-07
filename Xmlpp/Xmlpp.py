#!/usr/bin/env python
#-----------------------------------------------------------------------------
# Name:        Xmlpp.py
# Purpose:     Pretty print an xml file
#
# Author:      <greg_trihus@sil.org>
#
# Created:     2012/06/06
# RCS-ID:      $Id: Xmlpp.py $
# Copyright:   (c) 2012
# Licence:     <MIT>
#-----------------------------------------------------------------------------
#Boa:PyApp:main

import os,sys,re
from xml.dom.minidom import parseString
#from lxml import etree

modules ={}

def main(argv):
    # see: http://stackoverflow.com/questions/749796/pretty-printing-xml-in-python
    text_re = re.compile('>\n\s+([^<>\s].*?)\n\s+</', re.DOTALL)
    data = open(argv[1]).read()
    xmldom = parseString(data)
    uglyXml = xmldom.toprettyxml(indent='  ')
    prettyXml0 = text_re.sub('>\g<1></', uglyXml)
    prettyXml1 = re.compile(' +\n').sub('\n', prettyXml0)   # remove spaces at end of lines
    prettyXml = re.compile('\n+', re.MULTILINE).sub('\n', prettyXml1) # multiple lines to 1
    #t = etree.parse(argv[1])
    n = os.path.splitext(argv[1])
    f = open('%spp.xml' % n[0], 'w')
    #f.write(etree.tostring(t, pretty_print=True))
    f.write(prettyXml.encode('utf-8'))
    f.close()

if __name__ == '__main__':
    main(sys.argv)
