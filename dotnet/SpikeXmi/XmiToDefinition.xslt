<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns="http://schemas.nexida.com/codegeneration/definitions/1" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:UML="org.omg.xmi.namespace.UML" exclude-result-prefixes="UML">
	<xsl:output method="xml" indent="yes"/>

	<xsl:template match="/">
		<xsl:apply-templates select="XMI[@xmi.version='1.2' and XMI.header/XMI.metamodel/@xmi.name='UML' and XMI.header/XMI.metamodel/@xmi.version='1.4']"/>
	</xsl:template>

	<xsl:template match="XMI">
		<definitions>
			<types>
				<xsl:apply-templates select="XMI.content/UML:Model" />
			</types>
		</definitions>
	</xsl:template>

	<xsl:template match="UML:Model">
		<xsl:variable name="namespace" select="@name" />
		<xsl:for-each select="UML:Namespace.ownedElement/UML:Package">
			<xsl:call-template name="package">
				<xsl:with-param name="package" select="." />
				<xsl:with-param name="outerNamespace" select="$namespace" />
			</xsl:call-template>
		</xsl:for-each>
	</xsl:template>

	<xsl:template name="package">
		<xsl:param name="package" />
		<xsl:param name="outerNamespace" />
		<xsl:variable name="namespace" select="concat($outerNamespace, '.', $package/@name)" />
		<xsl:for-each select="UML:Namespace.ownedElement/UML:Package">
			<xsl:call-template name="package">
				<xsl:with-param name="package" select="." />
				<xsl:with-param name="outerNamespace" select="$namespace" />
			</xsl:call-template>
		</xsl:for-each>
		<xsl:for-each select="UML:Namespace.ownedElement/UML:Class">
			<xsl:call-template name="class">
				<xsl:with-param name="class" select="." />
				<xsl:with-param name="namespace" select="$namespace" />
			</xsl:call-template>
		</xsl:for-each>
	</xsl:template>

	<xsl:template name="construct-namespace">
		<xsl:param name="class" />
		<xsl:for-each select="ancestor::*[name() = 'UML:Model' or name() = 'UML:Package']">
			<xsl:value-of select="@name"/>
			<xsl:if test="position() = last()">
				<xsl:text>.</xsl:text>
			</xsl:if>
		</xsl:for-each>
	</xsl:template>

	<xsl:template name="class">
		<xsl:param name="class" />
		<xsl:param name="namespace" />
		<type>
			<xsl:attribute name="name">
				<xsl:value-of select="$class/@name" />
			</xsl:attribute>
			<xsl:attribute name="namespace">
				<xsl:value-of select="$namespace" />
			</xsl:attribute>
			<fields>
				<xsl:apply-templates select="UML:Classifier.feature/UML:Attribute" />
				<xsl:for-each select="//UML:Association[@xmi.id and UML:Association.connection/UML:AssociationEnd/UML:AssociationEnd.participant/UML:Class/@xmi.idref = $class/@xmi.id]">
					<xsl:call-template name="association" >
						<xsl:with-param name="class" select="$class" />
						<xsl:with-param name="association" select="$class" />
					</xsl:call-template>
				</xsl:for-each>
			</fields>
		</type>
	</xsl:template>

	<xsl:template match="UML:Attribute">
		<field>
			<xsl:attribute name="name">
				<xsl:value-of select="@name" />
			</xsl:attribute>
		</field>
	</xsl:template>

	<xsl:template name="association">
		<xsl:param name="class" />
		<xsl:param name="association" />
		<field>
			<xsl:attribute name="name">
				<xsl:value-of select="UML:Association.connection/UML:AssociationEnd[UML:AssociationEnd.participant/UML:Class/@xmi.idref != $class/@xmi.id]/@name" />
			</xsl:attribute>
		</field>
	</xsl:template>

</xsl:stylesheet>