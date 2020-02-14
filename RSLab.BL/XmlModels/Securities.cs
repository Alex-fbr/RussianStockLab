
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class document
{

    private documentData[] dataField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("data")]
    public documentData[] data
    {
        get
        {
            return this.dataField;
        }
        set
        {
            this.dataField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class documentData
{

    private documentDataMetadata metadataField;

    private documentDataRows rowsField;

    private string idField;

    /// <remarks/>
    public documentDataMetadata metadata
    {
        get
        {
            return this.metadataField;
        }
        set
        {
            this.metadataField = value;
        }
    }

    /// <remarks/>
    public documentDataRows rows
    {
        get
        {
            return this.rowsField;
        }
        set
        {
            this.rowsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class documentDataMetadata
{

    private documentDataMetadataColumn[] columnsField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("column", IsNullable = false)]
    public documentDataMetadataColumn[] columns
    {
        get
        {
            return this.columnsField;
        }
        set
        {
            this.columnsField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class documentDataMetadataColumn
{

    private string nameField;

    private string typeField;

    private ushort bytesField;

    private bool bytesFieldSpecified;

    private byte max_sizeField;

    private bool max_sizeFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort bytes
    {
        get
        {
            return this.bytesField;
        }
        set
        {
            this.bytesField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool bytesSpecified
    {
        get
        {
            return this.bytesFieldSpecified;
        }
        set
        {
            this.bytesFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte max_size
    {
        get
        {
            return this.max_sizeField;
        }
        set
        {
            this.max_sizeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool max_sizeSpecified
    {
        get
        {
            return this.max_sizeFieldSpecified;
        }
        set
        {
            this.max_sizeFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class documentDataRows
{

    private documentDataRowsRow rowField;

    /// <remarks/>
    public documentDataRowsRow row
    {
        get
        {
            return this.rowField;
        }
        set
        {
            this.rowField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class documentDataRowsRow
{

    private string sECIDField;

    private string bOARDIDField;

    private string sHORTNAMEField;

    private decimal pREVPRICEField;

    private bool pREVPRICEFieldSpecified;

    private byte lOTSIZEField;

    private bool lOTSIZEFieldSpecified;

    private byte fACEVALUEField;

    private bool fACEVALUEFieldSpecified;

    private string sTATUSField;

    private string bOARDNAMEField;

    private byte dECIMALSField;

    private bool dECIMALSFieldSpecified;

    private string sECNAMEField;

    private string rEMARKSField;

    private string mARKETCODEField;

    private string iNSTRIDField;

    private string sECTORIDField;

    private decimal mINSTEPField;

    private bool mINSTEPFieldSpecified;

    private decimal pREVWAPRICEField;

    private bool pREVWAPRICEFieldSpecified;

    private string fACEUNITField;

    private System.DateTime pREVDATEField;

    private bool pREVDATEFieldSpecified;

    private uint iSSUESIZEField;

    private bool iSSUESIZEFieldSpecified;

    private string iSINField;

    private string lATNAMEField;

    private string rEGNUMBERField;

    private byte pREVLEGALCLOSEPRICEField;

    private bool pREVLEGALCLOSEPRICEFieldSpecified;

    private byte pREVADMITTEDQUOTEField;

    private bool pREVADMITTEDQUOTEFieldSpecified;

    private string cURRENCYIField;

    private byte sECTYPEField;

    private bool sECTYPEFieldSpecified;

    private byte lISTLEVELField;

    private bool lISTLEVELFieldSpecified;

    private string sETTLEDATEField;

    private ushort data_versionField;

    private bool data_versionFieldSpecified;

    private uint seqnumField;

    private bool seqnumFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SECID
    {
        get
        {
            return this.sECIDField;
        }
        set
        {
            this.sECIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string BOARDID
    {
        get
        {
            return this.bOARDIDField;
        }
        set
        {
            this.bOARDIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SHORTNAME
    {
        get
        {
            return this.sHORTNAMEField;
        }
        set
        {
            this.sHORTNAMEField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal PREVPRICE
    {
        get
        {
            return this.pREVPRICEField;
        }
        set
        {
            this.pREVPRICEField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool PREVPRICESpecified
    {
        get
        {
            return this.pREVPRICEFieldSpecified;
        }
        set
        {
            this.pREVPRICEFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte LOTSIZE
    {
        get
        {
            return this.lOTSIZEField;
        }
        set
        {
            this.lOTSIZEField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool LOTSIZESpecified
    {
        get
        {
            return this.lOTSIZEFieldSpecified;
        }
        set
        {
            this.lOTSIZEFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte FACEVALUE
    {
        get
        {
            return this.fACEVALUEField;
        }
        set
        {
            this.fACEVALUEField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool FACEVALUESpecified
    {
        get
        {
            return this.fACEVALUEFieldSpecified;
        }
        set
        {
            this.fACEVALUEFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string STATUS
    {
        get
        {
            return this.sTATUSField;
        }
        set
        {
            this.sTATUSField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string BOARDNAME
    {
        get
        {
            return this.bOARDNAMEField;
        }
        set
        {
            this.bOARDNAMEField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte DECIMALS
    {
        get
        {
            return this.dECIMALSField;
        }
        set
        {
            this.dECIMALSField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool DECIMALSSpecified
    {
        get
        {
            return this.dECIMALSFieldSpecified;
        }
        set
        {
            this.dECIMALSFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SECNAME
    {
        get
        {
            return this.sECNAMEField;
        }
        set
        {
            this.sECNAMEField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string REMARKS
    {
        get
        {
            return this.rEMARKSField;
        }
        set
        {
            this.rEMARKSField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string MARKETCODE
    {
        get
        {
            return this.mARKETCODEField;
        }
        set
        {
            this.mARKETCODEField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string INSTRID
    {
        get
        {
            return this.iNSTRIDField;
        }
        set
        {
            this.iNSTRIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SECTORID
    {
        get
        {
            return this.sECTORIDField;
        }
        set
        {
            this.sECTORIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal MINSTEP
    {
        get
        {
            return this.mINSTEPField;
        }
        set
        {
            this.mINSTEPField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool MINSTEPSpecified
    {
        get
        {
            return this.mINSTEPFieldSpecified;
        }
        set
        {
            this.mINSTEPFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal PREVWAPRICE
    {
        get
        {
            return this.pREVWAPRICEField;
        }
        set
        {
            this.pREVWAPRICEField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool PREVWAPRICESpecified
    {
        get
        {
            return this.pREVWAPRICEFieldSpecified;
        }
        set
        {
            this.pREVWAPRICEFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string FACEUNIT
    {
        get
        {
            return this.fACEUNITField;
        }
        set
        {
            this.fACEUNITField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    public System.DateTime PREVDATE
    {
        get
        {
            return this.pREVDATEField;
        }
        set
        {
            this.pREVDATEField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool PREVDATESpecified
    {
        get
        {
            return this.pREVDATEFieldSpecified;
        }
        set
        {
            this.pREVDATEFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint ISSUESIZE
    {
        get
        {
            return this.iSSUESIZEField;
        }
        set
        {
            this.iSSUESIZEField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ISSUESIZESpecified
    {
        get
        {
            return this.iSSUESIZEFieldSpecified;
        }
        set
        {
            this.iSSUESIZEFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ISIN
    {
        get
        {
            return this.iSINField;
        }
        set
        {
            this.iSINField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string LATNAME
    {
        get
        {
            return this.lATNAMEField;
        }
        set
        {
            this.lATNAMEField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string REGNUMBER
    {
        get
        {
            return this.rEGNUMBERField;
        }
        set
        {
            this.rEGNUMBERField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte PREVLEGALCLOSEPRICE
    {
        get
        {
            return this.pREVLEGALCLOSEPRICEField;
        }
        set
        {
            this.pREVLEGALCLOSEPRICEField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool PREVLEGALCLOSEPRICESpecified
    {
        get
        {
            return this.pREVLEGALCLOSEPRICEFieldSpecified;
        }
        set
        {
            this.pREVLEGALCLOSEPRICEFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte PREVADMITTEDQUOTE
    {
        get
        {
            return this.pREVADMITTEDQUOTEField;
        }
        set
        {
            this.pREVADMITTEDQUOTEField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool PREVADMITTEDQUOTESpecified
    {
        get
        {
            return this.pREVADMITTEDQUOTEFieldSpecified;
        }
        set
        {
            this.pREVADMITTEDQUOTEFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CURRENCYI
    {
        get
        {
            return this.cURRENCYIField;
        }
        set
        {
            this.cURRENCYIField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte SECTYPE
    {
        get
        {
            return this.sECTYPEField;
        }
        set
        {
            this.sECTYPEField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool SECTYPESpecified
    {
        get
        {
            return this.sECTYPEFieldSpecified;
        }
        set
        {
            this.sECTYPEFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte LISTLEVEL
    {
        get
        {
            return this.lISTLEVELField;
        }
        set
        {
            this.lISTLEVELField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool LISTLEVELSpecified
    {
        get
        {
            return this.lISTLEVELFieldSpecified;
        }
        set
        {
            this.lISTLEVELFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SETTLEDATE
    {
        get
        {
            return this.sETTLEDATEField;
        }
        set
        {
            this.sETTLEDATEField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort data_version
    {
        get
        {
            return this.data_versionField;
        }
        set
        {
            this.data_versionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool data_versionSpecified
    {
        get
        {
            return this.data_versionFieldSpecified;
        }
        set
        {
            this.data_versionFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint seqnum
    {
        get
        {
            return this.seqnumField;
        }
        set
        {
            this.seqnumField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool seqnumSpecified
    {
        get
        {
            return this.seqnumFieldSpecified;
        }
        set
        {
            this.seqnumFieldSpecified = value;
        }
    }
}

