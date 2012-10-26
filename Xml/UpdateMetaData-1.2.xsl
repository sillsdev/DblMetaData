<?xml version="1.0" encoding="UTF-8"?>
<!-- #############################################################
    # Name:        UpdateMetaData-1.2.xsl
    # Purpose:     Update the metadata to the lastest preferrences
    #
    # Author:      Greg Trihus <greg_trihus@sil.org>
    #
    # Created:     2012/06/07
    # Updated:     2012/10/26 gt-removed ethnologue link and Revision
    # Copyright:   (c) 2011 SIL International
    # Licence:     <LPGL>
    ################################################################-->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    
    <xsl:param name="UseProp">false</xsl:param>
    <xsl:variable name="dcds">http://purl.org/dc/xmlns/2008/09/01/dc-ds-xml/</xsl:variable>
   
    <xsl:output encoding="UTF-8" method="xml"/>
    
    <!-- New processing instruction format for relax network grammer validation -->
    <xsl:template match="processing-instruction()"/>
    
    <!-- New root -->
    <xsl:template match="DBLScriptureProject |DBLMetadata">
        <xsl:choose>
            <xsl:when test="'$UseProp' = 'true'">
                <xsl:processing-instruction name="xml-model">href="metadataWbt-1.2.rnc" type="application/relax-ng-compact-syntax"</xsl:processing-instruction>
            </xsl:when>
            <xsl:otherwise>
                <xsl:processing-instruction name="xml-model">href="metadata.rnc" type="application/relax-ng-compact-syntax"</xsl:processing-instruction>
            </xsl:otherwise>
        </xsl:choose>
        <DBLMetadata>
            <!-- xsl:copy-of select="namespace::identification/scope/@*"/ -->
            <xsl:attribute name="id">2880c78491b2f8ce</xsl:attribute>
            <xsl:attribute name="revision">3</xsl:attribute>
            <xsl:attribute name="type">text</xsl:attribute>
            <xsl:attribute name="typeVersion">1.2</xsl:attribute>
            <xsl:if test="'$UseProp' = 'true'">
                <xsl:attribute name="xml:base">http://purl.org/ubs/metadata/dc/terms/</xsl:attribute>
                <!--xsl:attribute name="ns0:propertyURI" namespace="{$dcds}">text</xsl:attribute-->
            </xsl:if>
            <xsl:apply-templates/>
        </DBLMetadata>
    </xsl:template>
    
    <xsl:template match="identification">
        <identification>
            <name>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">title</xsl:attribute>
                </xsl:if>
                <xsl:value-of select="name"/>
            </name>
            <xsl:apply-templates select="nameLocal"/>
            <xsl:apply-templates select="abbreviation"/>
            <xsl:apply-templates select="abbreviationLocal"/>
            <scope>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">title/scriptureScope</xsl:attribute>
                </xsl:if>
                <xsl:text>NT</xsl:text>
            </scope>
            <description>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">description</xsl:attribute>
                </xsl:if>
                <!-- xsl:value-of select="description"/ -->
                <xsl:call-template name="description"/>
            </description>
            <dateCompleted>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">date</xsl:attribute>
                    <xsl:attribute name="sesURI" namespace="{$dcds}">http://purl.org/dc/terms/W3CDTF</xsl:attribute>
                </xsl:if>
                <xsl:value-of select="dateCompleted"/>
            </dateCompleted>
            <xsl:if test="systemId[@type = 'reap']">
                <systemId>
                    <xsl:attribute name="type">reap</xsl:attribute>
                    <xsl:if test="'$UseProp' = 'true'">
                        <xsl:attribute name="propertyURI" namespace="{$dcds}">identifier/reapID</xsl:attribute>
                    </xsl:if>
                    <xsl:value-of select="systemId[@type = 'reap']"/>
                </systemId>
            </xsl:if>
            <systemId>
                <xsl:attribute name="type">paratext</xsl:attribute>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">identifier/ptxID</xsl:attribute>
                </xsl:if>
                <xsl:value-of select="systemId[@type = 'paratext']"/>
            </systemId>
            <systemId>
                <xsl:attribute name="type">tms</xsl:attribute>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">identifier/tmsID</xsl:attribute>
                </xsl:if>
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
            <xsl:if test="'$UseProp' = 'true'">
                <xsl:attribute name="propertyURI" namespace="{$dcds}">accessRights/confidential</xsl:attribute>
            </xsl:if>
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
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">creator</xsl:attribute>
                </xsl:if>
                <xsl:choose>
                    <xsl:when test="(translation |creator)/text() = 'Wycliffe Inc.'">
                        <xsl:text>Wycliffe</xsl:text>
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:value-of select="translation |creator"/>
                    </xsl:otherwise>
                </xsl:choose>
            </creator>
            <publisher>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">publisher</xsl:attribute>
                </xsl:if>
                <xsl:choose>
                    <xsl:when test="(publishing |publisher)/text() = 'Wycliffe Inc.'">
                        <xsl:text>Wycliffe</xsl:text>
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:value-of select="publishing |publisher"/>
                    </xsl:otherwise>
                </xsl:choose>
            </publisher>
            <contributor>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">contributor</xsl:attribute>
                </xsl:if>
            </contributor>
        </agencies>
    </xsl:template>
    
    <xsl:template match="language">
        <language>
            <iso>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">language/iso</xsl:attribute>
                    <xsl:attribute name="sesURI" namespace="{$dcds}">http://purl.org/dc/terms/ISO639-3</xsl:attribute>
                </xsl:if>
                <xsl:value-of select="iso"/>
            </iso>
            <name>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">subject/subjectLanguage</xsl:attribute>
                    <xsl:attribute name="sesURI" namespace="{$dcds}">http://purl.org/dc/terms/ISO639-3</xsl:attribute>
                </xsl:if>
                <xsl:value-of select="name"/>
            </name>
            <ldml>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">language/ldml</xsl:attribute>
                </xsl:if>
                <xsl:text>en</xsl:text>
            </ldml>
            <rod>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">language/rod</xsl:attribute>
                </xsl:if>                        
            </rod>
            <script>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">language/script</xsl:attribute>
                </xsl:if>
                <xsl:value-of select="script"/>
            </script>
            <scriptDirection>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">language/scriptDirection</xsl:attribute>
                </xsl:if>
                <xsl:value-of select="scriptDirection"/>
            </scriptDirection>
            <numerals>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">language/numerals</xsl:attribute>
                </xsl:if>
            </numerals>
        </language>
    </xsl:template>
    
    <xsl:template match="country">
        <country>
            <iso>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">coverage/spatial</xsl:attribute>
                    <xsl:attribute name="sesURI" namespace="{$dcds}">http://purl.org/dc/terms/ISO3166</xsl:attribute>
                </xsl:if>
                <xsl:value-of select="iso"/>
            </iso>
            <name>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">subject/subjectCountry</xsl:attribute>
                </xsl:if>
                <xsl:value-of select="name"/>
            </name>
        </country>
    </xsl:template>
    
    <xsl:template match="translation |/DBLMetadata/type">
        <type>
            <translationType>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">type/translationType</xsl:attribute>
                </xsl:if>
                <xsl:value-of select="type |translationType"/>
            </translationType>
            <audience>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">audience</xsl:attribute>
                </xsl:if>
                <xsl:value-of select="level |audience"/>
            </audience>
        </type>
    </xsl:template>
    
    <xsl:template match="bookNames">
        <bookNames/>
    </xsl:template>
    
    <xsl:template match="contents">
        <contents>
            <xsl:if test="'$UseProp' = 'true'">
                <xsl:attribute name="propertyURI" namespace="{$dcds}">tableOfContents</xsl:attribute>
            </xsl:if>
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
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">rightsHolder</xsl:attribute>
                </xsl:if>
                <xsl:choose>
                    <xsl:when test="rightsHolder/text() = 'Wycliffe Inc.'">
                        <xsl:text>Wycliffe</xsl:text>
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:value-of select="rightsHolder"/>                
                    </xsl:otherwise>
                </xsl:choose>
            </rightsHolder>
            <rightsHolderLocal>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">rightsHolder/contactLocal</xsl:attribute>
                </xsl:if>
                <xsl:choose>
                    <xsl:when test="rightsHolderLocal/text() = 'Wycliffe Inc.'">
                        <xsl:text>Wycliffe</xsl:text>
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:value-of select="rightsHolderLocal"/>                
                    </xsl:otherwise>
                </xsl:choose>
            </rightsHolderLocal>
            <rightsHolderAbbreviation>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">rightsHolder/contactAbbreviation</xsl:attribute>
                </xsl:if>
                <xsl:text>WBT</xsl:text>
            </rightsHolderAbbreviation>
            <rightsHolderURL>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">rightsHolder/contactURL</xsl:attribute>
                </xsl:if>
                <xsl:value-of select="rightsHolderURL"/>                
            </rightsHolderURL>
            <rightsHolderFacebook>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">rightsHolder/contactFacebook</xsl:attribute>
                </xsl:if>
                <xsl:value-of select="rightsHolderFacebook"/>                
            </rightsHolderFacebook>
        </contact>
    </xsl:template>
    
    <xsl:template match="rights |copyright">
        <copyright>
            <statement>
                <xsl:attribute name="contentType">xhtml</xsl:attribute>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">rights</xsl:attribute>
                </xsl:if>
                <xsl:call-template name="string-replace-all">
                    <xsl:with-param name="text" select="rightsStatement |statement"/>
                    <xsl:with-param name="target">Wycliffe Inc.</xsl:with-param>
                    <xsl:with-param name="result">Wycliffe.</xsl:with-param>
                </xsl:call-template>
            </statement>
        </copyright>
    </xsl:template>
    
    <xsl:template match="promotion">
        <promotion>
            <promoVersionInfo>
                <xsl:attribute name="contentType">xhtml</xsl:attribute>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">description/pubPromoVersionInfo</xsl:attribute>
                </xsl:if>
                <xsl:apply-templates select="promoVersionInfo"/>
            </promoVersionInfo>
            <promoEmail>
                <xsl:attribute name="contentType">xhtml</xsl:attribute>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">description/pubPromoEmail</xsl:attribute>
                </xsl:if>
                <p>Hi YouVersion friend,</p>
                <p>
                    <xsl:text>Nice work downloading the </xsl:text>
                    <xsl:call-template name="nameDescription"/>
                    <xsl:text> in the Bible App! Now you'll have anytime, anywhere access to God's Word on your mobile device&#x2014;even if you're outside of service coverage or not connected to the Internet. It also means faster service whenever you read that version since it's stored on your device. Enjoy!</xsl:text>
                </p>
                <p>
                    <xsl:text>This download was made possible by Wycliffe. We really appreciate their passion for making the Bible available to millions of people around the world. Because of their generosity, YouVersion users like you can open up the Bible and hear from God no matter where you are. You can learn more about the great things Wycliffe is doing on many fronts by visiting </xsl:text>
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
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">contributor/archivist</xsl:attribute>
                </xsl:if>
                <xsl:value-of select="archivistName"/>
            </archivistName>
            <dateArchived>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">dateSubmitted</xsl:attribute>
                    <xsl:attribute name="sesURI" namespace="{$dcds}">http://purl.org/dc/terms/W3CDTF</xsl:attribute>
                </xsl:if>
                <xsl:value-of select="dateArchived"/>
                <xsl:if test="string-length(dateUpdated) = 10">
                    <xsl:text>T17:51:32.7907868+00:00</xsl:text>
                </xsl:if>
            </dateArchived>
            <dateUpdated>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">modified</xsl:attribute>
                    <xsl:attribute name="sesURI" namespace="{$dcds}">http://purl.org/dc/terms/W3CDTF</xsl:attribute>
                </xsl:if>
                <xsl:value-of select="dateUpdated"/>
                <xsl:if test="string-length(dateUpdated) = 10">
                    <xsl:text>T17:51:32.7907868+00:00</xsl:text>
                </xsl:if>
            </dateUpdated>
            <comments>
                <xsl:if test="'$UseProp' = 'true'">
                    <xsl:attribute name="propertyURI" namespace="{$dcds}">abstract</xsl:attribute>
                </xsl:if>
                <xsl:choose>
                    <xsl:when test="normalize-space(comments) = ''">
                        <xsl:text>no comment</xsl:text>
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:value-of select="comments"/>
                    </xsl:otherwise>
                </xsl:choose>
            </comments>
        </archiveStatus>
    </xsl:template>
    
    <xsl:template match="format">
        <format>
            <xsl:if test="'$UseProp' = 'true'">
                <xsl:attribute name="propertyURI" namespace="{$dcds}">format</xsl:attribute>
                <xsl:attribute name="sesURI" namespace="{$dcds}">http://purl.org/dc/terms/IMT</xsl:attribute>
            </xsl:if>
            <xsl:text>text/xml</xsl:text>
        </format>
    </xsl:template>
    
    <!-- Copy unaffected non-span elements-->
    <xsl:template match="nameLocal |abbreviation |abbreviationLocal |bundleProducer |etenPartner |division |books |book |h2 |ul |li |b |em">
        <xsl:element name="{name()}" namespace="{namespace-uri()}">
            <xsl:for-each select="@*">
                <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
                    <xsl:value-of select="."/>
                </xsl:attribute>
            </xsl:for-each>
            <xsl:apply-templates/>
        </xsl:element>
    </xsl:template>
    
    <xsl:template match="p">
        <xsl:choose>
            <xsl:when test="text()[1] = 'Revision'">
                <p>
                    <xsl:for-each select="* | text()">
                        <xsl:if test="position() &gt; 3">
                            <xsl:apply-templates select="."/>
                        </xsl:if>
                    </xsl:for-each>
                </p>
            </xsl:when>
            <xsl:otherwise>
                <p>
                    <xsl:for-each select="* | text()">
                        <xsl:apply-templates select="."/>
                    </xsl:for-each>
                </p>
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>
    
    <xsl:template match="a">
        <xsl:choose>
            <xsl:when test="contains(.//@href, 'ethnologue')">
                <xsl:value-of select="text()"/>
            </xsl:when>
            <xsl:otherwise>
                <a>
                    <xsl:for-each select="* | @*">
                        <xsl:copy/>
                    </xsl:for-each>
                    <xsl:apply-templates/>
                </a>
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>
    
    <xsl:template match="text()">
        <xsl:call-template name="string-replace-all">
            <xsl:with-param name="text" select="."/>
            <xsl:with-param name="target">Wycliffe Inc.</xsl:with-param>
            <xsl:with-param name="result">Wycliffe.</xsl:with-param>
        </xsl:call-template>
    </xsl:template>
    
    <xsl:template match="comment()">
        <xsl:copy/>
    </xsl:template>

    <xsl:template name="string-replace-all">
        <xsl:param name="text"/>
        <xsl:param name="target"/>
        <xsl:param name="result"/>
        <xsl:choose>
            <xsl:when test="contains($text,$target)">
                <xsl:copy-of select="substring-before($text, $target)"/>
                <xsl:value-of select="$result"/>
                <xsl:call-template name="string-replace-all">
                    <xsl:with-param name="text" select="substring-after($text, $target)"/>
                    <xsl:with-param name="target" select="$target"/>
                    <xsl:with-param name="result" select="$result"/>
                </xsl:call-template>
            </xsl:when>
            <xsl:otherwise>
                <xsl:value-of select="$text"/>
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>
    
</xsl:stylesheet>
