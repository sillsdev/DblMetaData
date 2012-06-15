<?xml version="1.0" encoding="UTF-8"?>
<!-- #############################################################
    # Name:        UpdateMetaData-1.2.xsl
    # Purpose:     Update the metadata to the lastest preferrences
    #
    # Author:      Greg Trihus <greg_trihus@sil.org>
    #
    # Created:     2012/06/07
    # Copyright:   (c) 2011 SIL International
    # Licence:     <LPGL>
    ################################################################-->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    
    <xsl:variable name="dcds">http://purl.org/dc/xmlns/2008/09/01/dc-ds-xml/</xsl:variable>
   
    <xsl:output encoding="UTF-8" method="xml"/>
    
    <!-- New processing instruction format for relax network grammer validation -->
    <xsl:template match="processing-instruction()"/>
    
    <!-- New root -->
    <xsl:template match="DBLScriptureProject |DBLMetadata">
        <xsl:processing-instruction name="xml-model">href="metadataWbt-1.2.rnc" type="application/relax-ng-compact-syntax"</xsl:processing-instruction>
        <DBLMetadata>
            <!-- xsl:copy-of select="namespace::identification/scope/@*"/ -->
            <xsl:attribute name="id">2880c78491b2f8ce</xsl:attribute>
            <xsl:attribute name="revision">3</xsl:attribute>
            <xsl:attribute name="type">text</xsl:attribute>
            <xsl:attribute name="typeVersion">1.2</xsl:attribute>
            <xsl:attribute name="xml:base">http://purl.org/ubs/metadata/dc/terms/</xsl:attribute>
            <!--xsl:attribute name="ns0:propertyURI" namespace="{$dcds}">text</xsl:attribute-->
            <xsl:apply-templates/>
        </DBLMetadata>
    </xsl:template>
    
    <xsl:template match="identification">
        <identification>
            <name>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">title</xsl:attribute>
                <xsl:value-of select="name"/>
            </name>
            <xsl:apply-templates select="nameLocal"/>
            <xsl:apply-templates select="abbreviation"/>
            <xsl:apply-templates select="abbreviationLocal"/>
            <scope>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">title/scriptureScope</xsl:attribute>
                <xsl:text>NT</xsl:text>
            </scope>
            <description>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">description</xsl:attribute>
                <!-- xsl:value-of select="description"/ -->
                <xsl:call-template name="description"/>
            </description>
            <dateCompleted>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">date</xsl:attribute>
                <xsl:attribute name="sesURI" namespace="{$dcds}">http://purl.org/dc/terms/W3CDTF</xsl:attribute>
                <xsl:value-of select="dateCompleted"/>
            </dateCompleted>
            <xsl:if test="systemId[@type = 'reap']">
                <systemId>
                    <xsl:attribute name="type">reap</xsl:attribute>
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">identifier/reapID</xsl:attribute>
                    <xsl:value-of select="systemId[@type = 'reap']"/>
                </systemId>
            </xsl:if>
            <systemId>
                <xsl:attribute name="type">paratext</xsl:attribute>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">identifier/ptxID</xsl:attribute>
                <!--xsl:value-of select="systemId[@type = 'paratext']"/-->
            </systemId>
            <systemId>
                <xsl:attribute name="type">tms</xsl:attribute>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">identifier/tmsID</xsl:attribute>
                <xsl:text>seeReap</xsl:text>
            </systemId>
            <xsl:apply-templates select="bundleProducer"/>
        </identification>
    </xsl:template>
    
    <xsl:template name="description">
        <xsl:text>New Testament in </xsl:text>
        <xsl:value-of select="//language/name"/>
    </xsl:template>
    
    <xsl:template match="confidential">
        <confidential>
            <xsl:attribute name="propertyURI" namespace="{$dcds}">accessRights/confidential</xsl:attribute>
            <xsl:choose>
                <xsl:when test="text() = 'No'">false</xsl:when>
                <xsl:when test="text() = 'Yes'">true</xsl:when>
                <xsl:otherwise>
                    <xsl:value-of select="."/>
                </xsl:otherwise>
            </xsl:choose>
        </confidential>
    </xsl:template>
    
    <xsl:template match="agencies">
        <agencies>
            <xsl:apply-templates select="etenPartner" />
            <creator>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">creator</xsl:attribute>
                <xsl:value-of select="translation |creator"/>
            </creator>
            <publisher>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">publisher</xsl:attribute>
                <xsl:value-of select="publishing |publisher"/>
            </publisher>
            <contributor>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">contributor</xsl:attribute>
            </contributor>
        </agencies>
    </xsl:template>
    
    <xsl:template match="language">
        <language>
            <iso>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">language/iso</xsl:attribute>
                <xsl:attribute name="sesURI" namespace="{$dcds}">http://purl.org/dc/terms/ISO639-3</xsl:attribute>
                <xsl:value-of select="iso"/>
            </iso>
            <name>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">subject/subjectLanguage</xsl:attribute>
                <xsl:attribute name="sesURI" namespace="{$dcds}">http://purl.org/dc/terms/ISO639-3</xsl:attribute>
                <xsl:value-of select="name"/>
            </name>
            <ldml>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">language/ldml</xsl:attribute>
                <xsl:text>en</xsl:text>
            </ldml>
            <rod>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">language/rod</xsl:attribute>
            </rod>
            <script>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">language/script</xsl:attribute>
                <xsl:value-of select="script"/>
            </script>
            <scriptDirection>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">language/scriptDirection</xsl:attribute>
                <xsl:value-of select="scriptDirection"/>
            </scriptDirection>
            <numerals>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">language/numerals</xsl:attribute>
            </numerals>
        </language>
    </xsl:template>
    
    <xsl:template match="country">
        <country>
            <iso>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">coverage/spatial</xsl:attribute>
                <xsl:attribute name="sesURI" namespace="{$dcds}">http://purl.org/dc/terms/ISO3166</xsl:attribute>
                <xsl:value-of select="iso"/>
            </iso>
            <name>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">subject/subjectCountry</xsl:attribute>
                <xsl:value-of select="name"/>
            </name>
        </country>
    </xsl:template>
    
    <xsl:template match="translation |/DBLMetadata/type">
        <type>
            <translationType>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">type/translationType</xsl:attribute>
                <xsl:value-of select="type |translationType"/>
            </translationType>
            <audience>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">audience</xsl:attribute>
                <xsl:value-of select="level |audience"/>
            </audience>
        </type>
    </xsl:template>
    
    <xsl:template match="bookNames">
        <bookNames/>
    </xsl:template>
    
    <xsl:template match="contents">
        <contents>
            <xsl:attribute name="propertyURI" namespace="{$dcds}">tableOfContents</xsl:attribute>
            <bookList>
                <xsl:attribute name="id">default</xsl:attribute>
                <name>
                    <xsl:value-of select="bookList/name"/>
                </name>
                <xsl:apply-templates select="bookList/nameLocal"/>
                <xsl:apply-templates select="bookList/abbreviation"/>
                <xsl:apply-templates select="bookList/abbreviationLocal"/>
                <description>NT</description>
                <range>Protestant New Testament (27 books)</range>
                <tradition>Western Protestant order</tradition>
                <xsl:apply-templates select="bookList/division"/>
            </bookList>
        </contents>
    </xsl:template>

    <!-- remove progress and checking nodes -->
    <xsl:template match="progress | checking"/>
    
    <xsl:template match="contact">
        <contact>
            <rightsHolder>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">rightsHolder</xsl:attribute>
                <xsl:value-of select="rightsHolder"/>                
            </rightsHolder>
            <rightsHolderLocal>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">rightsHolder/contactLocal</xsl:attribute>
                <xsl:value-of select="rightsHolderLocal"/>                
            </rightsHolderLocal>
            <rightsHolderAbbreviation>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">rightsHolder/contactAbbreviation</xsl:attribute>
                <xsl:text>WBT</xsl:text>
            </rightsHolderAbbreviation>
            <rightsHolderURL>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">rightsHolder/contactURL</xsl:attribute>
                <xsl:value-of select="rightsHolderURL"/>                
            </rightsHolderURL>
            <rightsHolderFacebook>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">rightsHolder/contactFacebook</xsl:attribute>
                <xsl:value-of select="rightsHolderFacebook"/>                
            </rightsHolderFacebook>
        </contact>
    </xsl:template>
    
    <xsl:template match="rights |copyright">
        <copyright>
            <statement>
                <xsl:attribute name="contentType">xhtml</xsl:attribute>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">rights</xsl:attribute>
                <xsl:value-of select="rightsStatement |statement"/>
            </statement>
        </copyright>
    </xsl:template>
    
    <xsl:template match="promotion">
        <promotion>
            <promoVersionInfo>
                <xsl:attribute name="contentType">xhtml</xsl:attribute>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">description/pubPromoVersionInfo</xsl:attribute>
                <xsl:apply-templates select="promoVersionInfo"/>
            </promoVersionInfo>
            <promoEmail>
                <xsl:attribute name="contentType">xhtml</xsl:attribute>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">description/pubPromoEmail</xsl:attribute>
                <p>Hi YouVersion friend,</p>
                <p>
                    <xsl:text>Nice work downloading the </xsl:text>
                    <xsl:call-template name="nameDescription"/>
                    <xsl:text> in the Bible App! Now you'll have anytime, anywhere access to God's Word on your mobile device—even if you're outside of service coverage or not connected to the Internet. It also means faster service whenever you read that version since it's stored on your device. Enjoy!</xsl:text>
                </p>
                <p>
                    <xsl:text>This download was made possible by Wycliffe Inc. We really appreciate their passion for making the Bible available to millions of people around the world. Because of their generosity, YouVersion users like you can open up the Bible and hear from God no matter where you are. You can learn more about the great things Wycliffe Inc. is doing on many fronts by visiting </xsl:text>
                    <xsl:element name="a">
                        <xsl:attribute name="href">http://www.wycliffe.org</xsl:attribute>
                        <xsl:text>www.wycliffe.org.</xsl:text>
                    </xsl:element>
                </p>
                <p>
                    <xsl:text>Again, we're glad you downloaded the </xsl:text>
                    <xsl:call-template name="nameDescription"/>
                    <xsl:text> and hope it enriches your interaction with God's Word.</xsl:text>
                </p>
                <p>Your Friends at YouVersion</p>
            </promoEmail>
        </promotion>
    </xsl:template>
    
    <xsl:template name="nameDescription">
        <xsl:element name="em">
            <xsl:value-of select="//identification/name"/>
        </xsl:element>
        <xsl:text> (</xsl:text>
        <xsl:call-template name="description"/>
        <xsl:text>)</xsl:text>
    </xsl:template>
    
    <!-- Don't allow multiple br -->
    <xsl:template match="br">
        <xsl:if test="not(name(preceding-sibling::node()[1]) = 'br' or 
            normalize-space(preceding-sibling::node()[1]) = '' and name(preceding-sibling::node()[2]) = 'br')">
            <br/>
        </xsl:if>
    </xsl:template>
    
    <xsl:template match="archiveStatus">
        <archiveStatus>
            <archivistName>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">contributor/archivist</xsl:attribute>
                <xsl:value-of select="archivistName"/>
            </archivistName>
            <dateArchived>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">dateSubmitted</xsl:attribute>
                <xsl:attribute name="sesURI" namespace="{$dcds}">http://purl.org/dc/terms/W3CDTF</xsl:attribute>
                <xsl:value-of select="dateArchived"/>
                <xsl:if test="string-length(dateUpdated) = 10">
                    <xsl:text>T17:51:32.7907868+00:00</xsl:text>
                </xsl:if>
            </dateArchived>
            <dateUpdated>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">modified</xsl:attribute>
                <xsl:attribute name="sesURI" namespace="{$dcds}">http://purl.org/dc/terms/W3CDTF</xsl:attribute>
                <xsl:value-of select="dateUpdated"/>
                <xsl:if test="string-length(dateUpdated) = 10">
                    <xsl:text>T17:51:32.7907868+00:00</xsl:text>
                </xsl:if>
            </dateUpdated>
            <comments>
                <xsl:attribute name="propertyURI" namespace="{$dcds}">abstract</xsl:attribute>
                <xsl:value-of select="comments"/>
            </comments>
        </archiveStatus>
    </xsl:template>
    
    <xsl:template match="format">
        <format>
            <xsl:attribute name="propertyURI" namespace="{$dcds}">format</xsl:attribute>
            <xsl:attribute name="sesURI" namespace="{$dcds}">http://purl.org/dc/terms/IMT</xsl:attribute>
            <xsl:text>text/xml</xsl:text>
        </format>
    </xsl:template>
    
    <!-- Copy unaffected non-span elements-->
    <xsl:template match="nameLocal |abbreviation |abbreviationLocal |bundleProducer |etenPartner |division |books |book |h2 |p |ul |li |a |b |em">
        <xsl:element name="{name()}" namespace="{namespace-uri()}">
            <xsl:for-each select="@*">
                <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
                    <xsl:value-of select="."/>
                </xsl:attribute>
            </xsl:for-each>
            <xsl:apply-templates/>
        </xsl:element>
    </xsl:template>
    
    <xsl:template match="comment()">
        <xsl:copy/>
    </xsl:template>

</xsl:stylesheet>
