<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="DBLScriptureProject |DBLMetadata">
        <html>
            <head></head>
            <body>
                <xsl:apply-templates />
            </body>
        </html>
    </xsl:template>
    
    <xsl:template match="identification">
        <h1>Identification</h1>
        <table>
            <xsl:apply-templates />
        </table>
    </xsl:template>
    
    <xsl:template match="systemId">
        <tr>
            <td><b>
                <xsl:value-of select="@type"/>
                <xsl:text> id</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="identification/name">
        <tr>
            <td><b>
                <xsl:text>Title</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="nameLocal">
        <tr>
            <td><b>
                <xsl:text>Local Title</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="abbreviation">
        <tr>
            <td><b>
                <xsl:text>Abbreviation</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="abbreviationLocal">
        <tr>
            <td><b>
                <xsl:text>Local abbreviation</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="scope">
        <tr>
            <td><b>
                <xsl:text>Scope</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="description">
        <tr>
            <td><b>
                <xsl:text>Description</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="dateCompleted">
        <tr>
            <td><b>
                <xsl:text>Date Completed</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="isResource">
        <tr>
            <td><b>
                <xsl:text>Paratext Resource?</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="bundleVersion">
        <tr>
            <td><b>
                <xsl:text>Bundle Version</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="bundleProducer">
        <tr>
            <td><b>
                <xsl:text>Bundle creation software</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="confidential">
        <table>
            <tr>
                <td><b>
                    <xsl:text>Confidential</xsl:text>
                </b></td>
                <td>
                    <xsl:value-of select="."/>
                </td>
            </tr>
        </table>
    </xsl:template>
    
    <xsl:template match="agencies">
        <h1>Agencies</h1>
        <table>
            <xsl:apply-templates />
        </table>
    </xsl:template>
    
    <xsl:template match="etenPartner">
        <tr>
            <td><b>
                <xsl:text>ETEN Partner</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="agencies/translation |creator">
        <tr>
            <td><b>
                <xsl:text>Creator</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="publishing |publisher">
        <tr>
            <td><b>
                <xsl:text>Publisher</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="contributor">
        <tr>
            <td><b>
                <xsl:text>Contributor</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="language">
        <h1>Language</h1>
        <table>
            <xsl:apply-templates />
        </table>
    </xsl:template>
    
    <xsl:template match="language/iso">
        <tr>
            <td><b>
                <xsl:text>ISO language code</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="language/name">
        <tr>
            <td><b>
                <xsl:text>Language name</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="ldml">
        <tr>
            <td><b>
                <xsl:text>UI Language (ldml)</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="rod">
        <tr>
            <td><b>
                <xsl:text>ROD (dialect)</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="script">
        <tr>
            <td><b>
                <xsl:text>Script</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="scriptDirection">
        <tr>
            <td><b>
                <xsl:text>Script direction</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="numerals">
        <tr>
            <td><b>
                <xsl:text>Numerals script</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="country">
        <h1>Country</h1>
        <table>
            <xsl:apply-templates />
        </table>
    </xsl:template>

    <xsl:template match="country/iso">
        <tr>
            <td><b>
                <xsl:text>Country code</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="country/name">
        <tr>
            <td><b>
                <xsl:text>Country name</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="DBLScriptureProject/translation |DBLMetadata/type">
        <h1>Type</h1>
        <table>
            <xsl:apply-templates />
        </table>
    </xsl:template>

    <xsl:template match="DBLScriptureProject/translation/type |translationType">
        <tr>
            <td><b>
                <xsl:text>Translation Type</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="level |audience">
        <tr>
            <td><b>
                <xsl:text>Audience</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="bookNames">
        <h1>Book names</h1>
        <table>
            <tr>
                <th>Code</th>
                <th>Long name</th>
                <th>Short name</th>
                <th>Abbr</th>
            </tr>
            <xsl:apply-templates />
        </table>
    </xsl:template>

    <xsl:template match="bookNames/book">
        <tr>
            <td><xsl:value-of select="@code"/></td>
            <td><xsl:value-of select="name[@type='long']"/></td>
            <td><xsl:value-of select="name[@type='short']"/></td>
            <td><xsl:value-of select="name[@type='abbr']"/></td>
        </tr>
    </xsl:template>

    <xsl:template match="contents">
        <h1>Contents</h1>
        <table>
            <xsl:apply-templates />
        </table>
    </xsl:template>
    
    <xsl:template match="bookList">
        <h2>
            <xsl:text>Book:</xsl:text>
            <xsl:value-of select="@id"/>
        </h2>
        <table>
            <xsl:apply-templates />
        </table>
    </xsl:template>
    
    <xsl:template match="bookList/name">
        <tr>
            <td><b>
                <xsl:text>Title</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="range">
        <tr>
            <td><b>
                <xsl:text>Range</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="tradition">
        <tr>
            <td><b>
                <xsl:text>Tradition</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="division">
        <h3>
            <xsl:text>Division:</xsl:text>
            <xsl:value-of select="@id"/>
        </h3>
        <p>
            <xsl:apply-templates />
        </p>
    </xsl:template>
    
    <xsl:template match="division/books">
        <xsl:for-each select="book">
            <xsl:if test="position()&gt;1">
                <xsl:text>, </xsl:text>
            </xsl:if>
            <xsl:value-of select="@code"/>
        </xsl:for-each>
    </xsl:template>

    <xsl:template match="checking">
        <h1>Checking</h1>
        <table>
            <xsl:apply-templates />
        </table>
    </xsl:template>
    
    <xsl:template match="validatedMarkers">
        <tr>
            <td><b>
                <xsl:text>Do markers validate?</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="validatedVerses">
        <tr>
            <td><b>
                <xsl:text>Do verses validate?</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="contact">
        <h1>Contact</h1>
        <table>
            <xsl:apply-templates />
        </table>
    </xsl:template>
    
    <xsl:template match="rightsHolder">
        <tr>
            <td><b>
                <xsl:text>Rights holder</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="rightsHolderLocal">
        <tr>
            <td><b>
                <xsl:text>Local rights holder</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="rightsHolderAbbreviation">
        <tr>
            <td><b>
                <xsl:text>abbreviation</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="rightsHolderURL">
        <tr>
            <td><b>
                <xsl:text>URL</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="rightsHolderFacebook">
        <tr>
            <td><b>
                <xsl:text>Facebook</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="rights |copyright">
        <h1>Rights</h1>
        <table>
            <xsl:apply-templates />
        </table>
    </xsl:template>

    <xsl:template match="dateLicense">
        <tr>
            <td><b>
                <xsl:text>License date</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="dateLicenseExpiry">
        <tr>
            <td><b>
                <xsl:text>Date license expires</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="rightsStatement |statement">
        <tr>
            <td><b>
                <xsl:text>Rights statement</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="publicationRights">
        <table>
            <tr><th><font size="+1">Publication rights</font></th><th></th></tr>
            <xsl:apply-templates />
        </table>
    </xsl:template>

    <xsl:template match="allowOffline">
        <tr>
            <td><b>
                <xsl:text>Allow off line</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="allowAudio">
        <tr>
            <td><b>
                <xsl:text>Allow audio</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="allowFootnotes">
        <tr>
            <td><b>
                <xsl:text>Allow footnotes</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="allowCrossReferences">
        <tr>
            <td><b>
                <xsl:text>Allow cross references</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>
    
    <xsl:template match="allowNewPublishers">
        <tr>
            <td><b>
                <xsl:text>Allow sub licensing</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="denyPlatforms">
        <tr>
            <td><b>
                <xsl:text>Deny Platforms</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="exchangeLicenseFCBH">
        <tr>
            <td><b>
                <xsl:text>FCBH exhange</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="promotion">
        <h1>Promotion</h1>
        <table>
            <xsl:apply-templates />
        </table>
    </xsl:template>

    <xsl:template match="promoVersionInfo">
        <xsl:apply-templates/>
    </xsl:template>

    <!--Straight copy for these elements. -->
    <xsl:template match="a | em | br | ol | ul | img | p | li | h2 | b | i">
        <xsl:copy>
            <xsl:for-each select="@*">
                <xsl:copy/>
            </xsl:for-each>
            <xsl:apply-templates/>
        </xsl:copy>
    </xsl:template>
    
    <xsl:template match="promoEmail">
        <h2>Email text</h2>
        <table>
            <xsl:apply-templates />
        </table>
    </xsl:template>
    
    <xsl:template match="archiveStatus">
        <h1>Archive status</h1>
        <table>
            <xsl:apply-templates />
        </table>
    </xsl:template>
    
    <xsl:template match="archivistName">
        <tr>
            <td><b>
                <xsl:text>Archivist's name</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="dateArchived">
        <tr>
            <td><b>
                <xsl:text>Date archived</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="dateUpdated">
        <tr>
            <td><b>
                <xsl:text>Date updated</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="comments">
        <tr>
            <td><b>
                <xsl:text>Comments</xsl:text>
            </b></td>
            <td>
                <xsl:value-of select="."/>
            </td>
        </tr>
    </xsl:template>

    <xsl:template match="format">
        <table>
            <tr>
                <td><b>
                    <xsl:text>Format</xsl:text>
                </b></td>
                <td>
                    <xsl:value-of select="."/>
                </td>
            </tr>
        </table>
    </xsl:template>
</xsl:stylesheet>
