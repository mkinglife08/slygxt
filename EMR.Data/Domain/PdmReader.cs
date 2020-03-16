using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EMR.Data.Domain
{
   public class PdmReader
    {
        public const string a = "attribute", c = "collection", o = "object";

        public const string cClasses = "c:Classes";
        public const string oClass = "o:Class";

        public const string cAttributes = "c:Attributes";
        public const string oAttribute = "o:Attribute";

        public const string cPackages = "c:Packages";

        public const string cTables = "c:Tables";
        public const string oTable = "o:Table";

        public const string cColumns = "c:Columns";
        public const string oColumn = "o:Column";


        XmlDocument xmlDoc;
        XmlNamespaceManager xmlnsManager;
        /// <summary>构造函数 </summary>
        public PdmReader()
        {
            // TODO: 在此处添加构造函数逻辑
            xmlDoc = new XmlDocument();
        }
        /// <summary>构造函数 </summary>
        public PdmReader(string pdm_file)
        {
            PdmFile = pdm_file;
        }
        public void Test()
        {
            PdmReader mTest = new PdmReader("D://piggy//CodeTest.pdm");
            mTest.InitData();
           int count = mTest.Tables.Count;
          
        }

        string pdmFile;

        public string PdmFile
        {
            get { return pdmFile; }
            set
            {
                pdmFile = value;
                if (xmlDoc == null)
                {
                    xmlDoc = new XmlDocument();
                    xmlDoc.Load(pdmFile);
                    xmlnsManager = new XmlNamespaceManager(xmlDoc.NameTable);
                    xmlnsManager.AddNamespace("a", "attribute");
                    xmlnsManager.AddNamespace("c", "collection");
                    xmlnsManager.AddNamespace("o", "object");
                }
            }
        }

        IList<TableInfo> tables;

        public IList<TableInfo> Tables
        {
            get { return tables; }
            set { tables = value; }
        }

        /// <summary>
        /// 初始化加载TABLES
        /// </summary>
        public void InitData()
        {
            if (Tables == null) Tables = new List<TableInfo>();
            var xnPackages = xmlDoc.SelectNodes("//" + cPackages, xmlnsManager);
            if (xnPackages.Count == 0) // 没有用包，直接添加表
            {
                var tablesNodes = xmlDoc.SelectNodes("//" + cTables, xmlnsManager);
                foreach (XmlNode tablesNode in tablesNodes)
                {
                    foreach (XmlNode xnTable in tablesNode.ChildNodes)
                    {
                        var table = GetTable(xnTable);
                        table.PackageName = "";
                        Tables.Add(table);
                    }
                }
                return;
            }
            // 循环包添加表
            foreach (XmlNode xnPackage in xnPackages)
            {
                foreach (XmlNode package in xnPackage.ChildNodes)
                {
                    string packageName = "";
                    foreach (XmlNode xnP in package.ChildNodes)
                    {
                        if (xnP.Name == "a:Name")
                        {
                            packageName = xnP.InnerText;
                        }
                        else if (xnP.Name == cTables)
                        {
                            foreach (XmlNode xnTable in xnP.ChildNodes)
                            {
                                var table = GetTable(xnTable);
                                table.PackageName = packageName;
                                Tables.Add(table);
                            }
                        }
                    }
                }
            }
        }

        //初始化"o:Table"的节点
        private TableInfo GetTable(XmlNode xnTable)
        {
            TableInfo mTable = new TableInfo();
            XmlElement xe = (XmlElement)xnTable;
            mTable.TableId = xe.GetAttribute("Id");
            XmlNodeList xnTProperty = xe.ChildNodes;
            foreach (XmlNode xnP in xnTProperty)
            {
                switch (xnP.Name)
                {
                    case "a:ObjectID":
                        mTable.ObjectID = xnP.InnerText;
                        break;
                    case "a:Name":
                        mTable.Name = xnP.InnerText;
                        break;
                    case "a:Code":
                        mTable.Code = xnP.InnerText;
                        break;
                    case "a:CreationDate":
                        mTable.CreationDate = Convert.ToInt32(xnP.InnerText);
                        break;
                    case "a:Creator":
                        mTable.Creator = xnP.InnerText;
                        break;
                    case "a:ModificationDate":
                        mTable.ModificationDate = Convert.ToInt32(xnP.InnerText);
                        break;
                    case "a:Modifier":
                        mTable.Modifier = xnP.InnerText;
                        break;
                    case "a:Comment":
                        mTable.Comment = xnP.InnerText;
                        break;
                    case "a:PhysicalOptions":
                        mTable.PhysicalOptions = xnP.InnerText;
                        break;
                    case "c:Columns":
                        InitColumns(xnP, mTable);
                        break;
                    case "c:Keys":
                        InitKeys(xnP, mTable);
                        break;
                }
            }
            return mTable;
        }
        //初始化"c:Columns"的节点
        private void InitColumns(XmlNode xnColumns, TableInfo pTable)
        {
            foreach (XmlNode xnColumn in xnColumns)
            {
                pTable.AddColumn(GetColumn(xnColumn));
            }
        }

        //初始化c:Keys"的节点
        private void InitKeys(XmlNode xnKeys, TableInfo pTable)
        {
            foreach (XmlNode xnKey in xnKeys)
            {
                pTable.AddKey(GetKey(xnKey));
            }
        }

        private ColumnInfo GetColumn(XmlNode xnColumn)
        {
            ColumnInfo mColumn = new ColumnInfo();
            XmlElement xe = (XmlElement)xnColumn;
            mColumn.ColumnId = xe.GetAttribute("Id");
            XmlNodeList xnCProperty = xe.ChildNodes;
            foreach (XmlNode xnP in xnCProperty)
            {
                switch (xnP.Name)
                {
                    case "a:ObjectID":
                        mColumn.ObjectID = xnP.InnerText;
                        break;
                    case "a:Name":
                        mColumn.Name = xnP.InnerText;
                        break;
                    case "a:Code":
                        mColumn.Code = xnP.InnerText;
                        break;
                    case "a:CreationDate":
                        mColumn.CreationDate = Convert.ToInt32(xnP.InnerText);
                        break;
                    case "a:Creator":
                        mColumn.Creator = xnP.InnerText;
                        break;
                    case "a:ModificationDate":
                        mColumn.ModificationDate = Convert.ToInt32(xnP.InnerText);
                        break;
                    case "a:Modifier":
                        mColumn.Modifier = xnP.InnerText;
                        break;
                    case "a:Comment":
                        mColumn.Comment = xnP.InnerText;
                        break;
                    case "a:DataType":
                        mColumn.DataType = xnP.InnerText;
                        break;
                    case "a:Length":
                        mColumn.Length = xnP.InnerText;
                        break;
                    case "a:Identity":
                        mColumn.Identity = string.Compare(xnP.InnerText, "true", true) == 0;
                        break;
                    case "a:Mandatory":
                        mColumn.Mandatory = string.Compare(xnP.InnerText, "1", true) == 0;
                        break;
                    case "a:PhysicalOptions":
                        mColumn.PhysicalOptions = xnP.InnerText;
                        break;
                    case "a:ExtendedAttributesText":
                        mColumn.ExtendedAttributesText = xnP.InnerText;
                        break;
                }
            }
            return mColumn;
        }

        private PdmKey GetKey(XmlNode xnKey)
        {
            PdmKey mKey = new PdmKey();
            XmlElement xe = (XmlElement)xnKey;
            mKey.KeyId = xe.GetAttribute("Id");
            XmlNodeList xnKProperty = xe.ChildNodes;
            foreach (XmlNode xnP in xnKProperty)
            {
                switch (xnP.Name)
                {
                    case "a:ObjectID":
                        mKey.ObjectID = xnP.InnerText;
                        break;
                    case "a:Name":
                        mKey.Name = xnP.InnerText;
                        break;
                    case "a:Code":
                        mKey.Code = xnP.InnerText;
                        break;
                    case "a:CreationDate":
                        mKey.CreationDate = Convert.ToInt32(xnP.InnerText);
                        break;
                    case "a:Creator":
                        mKey.Creator = xnP.InnerText;
                        break;
                    case "a:ModificationDate":
                        mKey.ModificationDate = Convert.ToInt32(xnP.InnerText);
                        break;
                    case "a:Modifier":
                        mKey.Modifier = xnP.InnerText;
                        break;
                        //还差 <c:Key.Columns>
                }
            }
            return mKey;
        }
    }

    public class ColumnInfo
    {
        public ColumnInfo()
        { }

        string columnId;

        public string ColumnId
        {
            get { return columnId; }
            set { columnId = value; }
        }
        string objectID;

        public string ObjectID
        {
            get { return objectID; }
            set { objectID = value; }
        }
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        int creationDate;

        public int CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }
        string creator;

        public string Creator
        {
            get { return creator; }
            set { creator = value; }
        }
        int modificationDate;

        public int ModificationDate
        {
            get { return modificationDate; }
            set { modificationDate = value; }
        }
        string modifier;

        public string Modifier
        {
            get { return modifier; }
            set { modifier = value; }
        }
        string comment;

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        string dataType;

        public string DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }
        string length;

        public string Length
        {
            get { return length; }
            set { length = value; }
        }
        //是否自增量
        bool identity;

        public bool Identity
        {
            get { return identity; }
            set { identity = value; }
        }
        bool mandatory;
        //禁止为空
        public bool Mandatory
        {
            get { return mandatory; }
            set { mandatory = value; }
        }
        string extendedAttributesText;
        //扩展属性
        public string ExtendedAttributesText
        {
            get { return extendedAttributesText; }
            set { extendedAttributesText = value; }
        }
        string physicalOptions;

        public string PhysicalOptions
        {
            get { return physicalOptions; }
            set { physicalOptions = value; }
        }
    }

    public class PdmKey
    {
        public PdmKey()
        {
        }

        string keyId;

        public string KeyId
        {
            get { return keyId; }
            set { keyId = value; }
        }
        string objectID;

        public string ObjectID
        {
            get { return objectID; }
            set { objectID = value; }
        }
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        int creationDate;

        public int CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }
        string creator;

        public string Creator
        {
            get { return creator; }
            set { creator = value; }
        }
        int modificationDate;

        public int ModificationDate
        {
            get { return modificationDate; }
            set { modificationDate = value; }
        }
        string modifier;

        public string Modifier
        {
            get { return modifier; }
            set { modifier = value; }
        }

        IList<ColumnInfo> columns;

        public IList<ColumnInfo> Columns
        {
            get { return columns; }
        }

        public void AddColumn(ColumnInfo mColumn)
        {
            if (columns == null)
                columns = new List<ColumnInfo>();
            columns.Add(mColumn);
        }
    }


    public class TableInfo
    {
        public TableInfo()
        {
        }
        public string PackageName { get; set; }
        string tableId;

        public string TableId
        {
            get { return tableId; }
            set { tableId = value; }
        }
        string objectID;

        public string ObjectID
        {
            get { return objectID; }
            set { objectID = value; }
        }
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        int creationDate;

        public int CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }
        string creator;

        public string Creator
        {
            get { return creator; }
            set { creator = value; }
        }
        int modificationDate;

        public int ModificationDate
        {
            get { return modificationDate; }
            set { modificationDate = value; }
        }
        string modifier;

        public string Modifier
        {
            get { return modifier; }
            set { modifier = value; }
        }
        string comment;

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        string physicalOptions;

        public string PhysicalOptions
        {
            get { return physicalOptions; }
            set { physicalOptions = value; }
        }


        IList<ColumnInfo> columns;

        public IList<ColumnInfo> Columns
        {
            get { return columns; }
        }

        IList<PdmKey> keys;

        public IList<PdmKey> Keys
        {
            get { return keys; }
        }

        public void AddColumn(ColumnInfo mColumn)
        {
            if (columns == null)
                columns = new List<ColumnInfo>();
            columns.Add(mColumn);
        }

        public void AddKey(PdmKey mKey)
        {
            if (keys == null)
                keys = new List<PdmKey>();
            keys.Add(mKey);
        }
    }
}
