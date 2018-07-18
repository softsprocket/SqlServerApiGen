using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerUtils
{
    public static class TypeMapping
    {

        public static System.Type GetFrameworkType(string sqltype) {
            switch (sqltype.ToLower()) {
                case "bigint":
                    return typeof(Int64);
                case "binary":
                    return typeof(Byte[]);
                case "bit":
                    return typeof(Nullable<Boolean>);
                case "char":
                    return typeof(string);
                case "date":
                    return typeof(Nullable<DateTime>);
                case "datetime":
                    return typeof(Nullable<DateTime>);
                case "datetime2":
                    return typeof(Nullable<DateTime>);
                case "datetimeoffset":
                    return typeof(Nullable<DateTimeOffset>);
                case "decimal":
                    return typeof(Nullable<Decimal>);
                case "float":
                    return typeof(Nullable<Double>);
                case "int":
                    return typeof(Nullable<Int32>);
                case "money":
                    return typeof(Nullable<Decimal>);
                case "nchar":
                    return typeof(string);
                case "ntext":
                    return typeof(string);
                case "numeric":
                    return typeof(Nullable<Decimal>);
                case "nvarchar":
                    return typeof(string);
                case "real":
                    return typeof(Nullable<Single>);
                case "rowversion":
                    return typeof(Byte[]);
                case "smallint":
                    return typeof(Nullable<Int16>);
                case "smallmoney":
                    return typeof(Nullable<Decimal>);
                case "sql_variant":
                    return typeof(Object);
                case "text":
                    return typeof(string);
                case "time":
                    return typeof(Nullable<TimeSpan>);
                case "tinyint":
                    return typeof(Nullable<Byte>);
                case "uniqueidentifier":
                    return typeof(Nullable<Guid>);
                case "varbinary":
                    return typeof(Byte[]);
                case "varchar":
                    return typeof(string);
                case "xml":
                    return typeof(string);
                case "smalldatetime":
                    return typeof(Nullable<DateTime>);
                case "image":
                    return typeof(Byte[]);

            }

            return null;
        }
        public static string GetFrameworkString(string sqltype)
        {
            switch (sqltype.ToLower())
            {
                case "bigint":
                    return "Int64";
                case "binary":
                    return "Byte[]";
                case "bit":
                    return "Nullable<Boolean>";
                case "char":
                    return "string";
                case "date":
                    return "Nullable<DateTime>";
                case "datetime":
                    return "Nullable<DateTime>";
                case "datetime2":
                    return "Nullable<DateTime>";
                case "datetimeoffset":
                    return "Nullable<DateTimeOffset>";
                case "decimal":
                    return "Nullable<Decimal>";
                case "float":
                    return "Nullable<Double>";
                case "int":
                    return "Nullable<Int32>";
                case "money":
                    return "Nullable<Decimal>";
                case "nchar":
                    return "string";
                case "ntext":
                    return "string";
                case "numeric":
                    return "Nullable<Decimal>";
                case "nvarchar":
                    return "string";
                case "real":
                    return "Nullable<Single>";
                case "rowversion":
                    return "Byte[]";
                case "smallint":
                    return "Nullable<Int16>";
                case "smallmoney":
                    return "Nullable<Decimal>";
                case "sql_variant":
                    return "Object";
                case "text":
                    return "string";
                case "time":
                    return "Nullable<TimeSpan>";
                case "tinyint":
                    return "Nullable<Byte>";
                case "uniqueidentifier":
                    return "Nullable<Guid>";
                case "varbinary":
                    return "Byte[]";
                case "varchar":
                    return "string";
                case "xml":
                    return "string";
                case "smalldatetime":
                    return "Nullable<DateTime>";
                case "image":
                    return "Byte[]";

            }

            return null;
        }
    }

     // there are these as well
    /*
     User-defined type(UDT)  None The same class that is bound to the user-defined type in the same assembly or a dependent assembly.
    timestamp None    None
    table   None None  
    geography   SqlGeography

    SqlGeography is defined in Microsoft.SqlServer.Types.dll, which is installed with SQL Server and can be downloaded from the SQL Server 2017 feature pack.None
    geometry SqlGeometry

    SqlGeometry is defined in Microsoft.SqlServer.Types.dll, which is installed with SQL Server and can be downloaded from the SQL Server 2017 feature pack.	None
    hierarchyid SqlHierarchyId

    SqlHierarchyId is defined in Microsoft.SqlServer.Types.dll, which is installed with SQL Server and can be downloaded from the SQL Server 2017 feature pack.	None
    */
}
