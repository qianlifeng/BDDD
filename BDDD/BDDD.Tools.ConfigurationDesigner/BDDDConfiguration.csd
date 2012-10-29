<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="cf70c3cb-9cf6-40b7-a92c-105745794eaf" namespace="BDDD.Tools.ConfigurationDesigner" xmlSchemaNamespace="urn:BDDD.Tools.ConfigurationDesigner" assemblyName="BDDD.Tools.ConfigurationDesigner" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="BDDDConfigSection" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="bDDDConfigSection">
      <elementProperties>
        <elementProperty name="Application" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="application" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/cf70c3cb-9cf6-40b7-a92c-105745794eaf/ApplicationElement" />
          </type>
        </elementProperty>
        <elementProperty name="Interception" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="interception" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/cf70c3cb-9cf6-40b7-a92c-105745794eaf/InterceptionElement" />
          </type>
        </elementProperty>
        <elementProperty name="ObjectContainer" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="objectContainer" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/cf70c3cb-9cf6-40b7-a92c-105745794eaf/ObjectContainerElement" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElement name="ApplicationElement">
      <attributeProperties>
        <attributeProperty name="Provider" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="provider" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/cf70c3cb-9cf6-40b7-a92c-105745794eaf/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="InterceptionElement">
      <elementProperties>
        <elementProperty name="Interceptors" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="interceptors" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/cf70c3cb-9cf6-40b7-a92c-105745794eaf/InterceptorElementCollection" />
          </type>
        </elementProperty>
        <elementProperty name="Contracts" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="contracts" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/cf70c3cb-9cf6-40b7-a92c-105745794eaf/InterceptContractElementCollection" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElementCollection name="InterceptorElementCollection" xmlItemName="interceptorElement" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/cf70c3cb-9cf6-40b7-a92c-105745794eaf/InterceptorElement" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="InterceptorElement">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/cf70c3cb-9cf6-40b7-a92c-105745794eaf/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Type" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="type" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/cf70c3cb-9cf6-40b7-a92c-105745794eaf/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElementCollection name="InterceptContractElementCollection" xmlItemName="interceptContractElement" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/cf70c3cb-9cf6-40b7-a92c-105745794eaf/InterceptContractElement" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="InterceptContractElement">
      <attributeProperties>
        <attributeProperty name="Type" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="type" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/cf70c3cb-9cf6-40b7-a92c-105745794eaf/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="Methods" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="methods" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/cf70c3cb-9cf6-40b7-a92c-105745794eaf/InterceptMethodElementCollection" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElementCollection name="InterceptMethodElementCollection" xmlItemName="interceptMethodElement" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/cf70c3cb-9cf6-40b7-a92c-105745794eaf/InterceptMethodElement" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="InterceptMethodElement">
      <attributeProperties>
        <attributeProperty name="Signature" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="signature" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/cf70c3cb-9cf6-40b7-a92c-105745794eaf/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="InterceptorRefs" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="interceptorRefs" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/cf70c3cb-9cf6-40b7-a92c-105745794eaf/InterceptorRefElementCollection" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElementCollection name="InterceptorRefElementCollection" xmlItemName="interceptorRefElement" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/cf70c3cb-9cf6-40b7-a92c-105745794eaf/InterceptorRefElement" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="InterceptorRefElement">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/cf70c3cb-9cf6-40b7-a92c-105745794eaf/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="ObjectContainerElement">
      <attributeProperties>
        <attributeProperty name="SectionName" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="sectionName" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/cf70c3cb-9cf6-40b7-a92c-105745794eaf/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Provider" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="provider" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/cf70c3cb-9cf6-40b7-a92c-105745794eaf/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="InitFromConfigFile" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="initFromConfigFile" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/cf70c3cb-9cf6-40b7-a92c-105745794eaf/Boolean" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>