<?xml version="1.0" encoding="UTF-8"?>
<!-- #############################################################
    # Name:        UpdateMetaData-1.1.xsl
    # Purpose:     Update the metadata to the lastest preferrences
    #
    # Author:      Greg Trihus <greg_trihus@sil.org>
    #
    # Created:     2012/06/07
    # Copyright:   (c) 2011 SIL International
    # Licence:     <LPGL>
    ################################################################-->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    
    <xsl:output encoding="UTF-8" method="xml"/>
    
    <!-- New processing instruction format for relax network grammer validation -->
    <xsl:template match="processing-instruction()">
        <xsl:processing-instruction name="xml-model">href="metadataWbt-1.1.rnc" type="application/relax-ng-compact-syntax"</xsl:processing-instruction>
    </xsl:template>

    <!-- Use 3 letter language code with NT after it (no dash) -->
    <xsl:template match="abbreviation |abbreviationLocal">
        <xsl:copy>
            <xsl:value-of select="substring(text(),0,4)"/>
            <xsl:text>NT</xsl:text>
        </xsl:copy>
    </xsl:template>
    
    <!-- Scope should just be NT (not the full scope description from REAP) -->
    <xsl:template match="scope">
        <xsl:copy>
            <xsl:for-each select="@*">
                <xsl:copy/>
            </xsl:for-each>
            <xsl:text>NT</xsl:text>
        </xsl:copy>
    </xsl:template>
    
    <!-- Translation and Publishing agency should always be "Wycliffe Inc." (for us) -->
    <xsl:template match="publisher |creator">
        <xsl:copy>
            <xsl:for-each select="@*">
                <xsl:copy/>
            </xsl:for-each>
            <xsl:text>Wycliffe Inc.</xsl:text>
        </xsl:copy>
    </xsl:template>
    
    <!-- Don't allow multiple br -->
    <xsl:template match="br">
        <xsl:if test="not(name(preceding-sibling::node()[1]) = 'br')">
            <xsl:copy/>
        </xsl:if>
    </xsl:template>
    
    <!-- Copy unaffected non-span elements-->
    <xsl:template
        match="DBLScriptureProject |identification |confidential |agencies |language |country |translation |bookNames |contents |progress |checking |contact |rights |promotion |archiveStatus |format |systemId |name |nameLocal |description |dateCompleted |isResource |bundleVersion |bundleProducer |etenPartner |translation |iso |script |scriptDirection |type |level |book |bookList |range |tradition |division |books |validatedMarkers |validatedVerses |rightsHolder |rightsHolderLocal |rightsHolderAbbreviation |rightsHolderURL |rightsHolderFacebook |dateLicense |dateLicenseExpiry |rightsStatement |publicationRights |allowOffline |allowAudio |allowFootnotes |allowCrossReferences |allowNewPublishers |denyPlatforms |exchangeLicenseFCBH |promoVersionInfo |promoEmail |h2 |p |ul |li |a |b |archivistName |dateArchived |dateUpdated |comments | comment()">
        <xsl:copy>
            <xsl:for-each select="@*">
                <xsl:copy/>
            </xsl:for-each>
            <xsl:apply-templates/>
        </xsl:copy>
    </xsl:template>

</xsl:stylesheet>
