using SqlServerUtils;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerApiGen
{

    public class Schema
    {

        public Schema (string name)
        {
            DbSchema = name;
            DbClassSchema = name.First().ToString().ToUpper() + name.Substring(1);
        }

        private List<Table> tables = new List<Table>();
        private string dbSchema;
        private string dbClassSchema;

        public List<Table> Tables { get => tables; set => tables = value; }
        public string DbSchema { get => dbSchema; set => dbSchema = value; }
        public string DbClassSchema { get => dbClassSchema; set => dbClassSchema = value; }
    } 

    public partial class DatabaseTemplate
    {
        private List<Schema> schemas = new List<Schema>();
        private string dbName;

        public DatabaseTemplate (string name)
        {
            DbName = name;
        }

        public string DbName { get => dbName; set => dbName = value; }
        public List<Schema> Schemas { get => schemas; set => schemas = value; }

        public string FirstToLower (string s)
        {
            return s.First().ToString().ToLower() + s.Substring(1);
        }


        public string FirstToUpper(string s)
        {
            return s.First().ToString().ToUpper() + s.Substring(1);
        }
    }

    public class Column
    {
        public string DataType;
        public string Name;
    }

    public partial class Table
    {
        public string Schema;
        public string TableName;
        public List<Column> Columns = new List<Column>();
    }

    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server = DESKTOP-T0L66I3; Trusted_Connection = True;";

            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = false;
            parameters.OutputAssembly = "GenMultivistaDB.dll";
            parameters.ReferencedAssemblies.Add("System.Data.Linq.dll");
            parameters.ReferencedAssemblies.Add("System.Core.dll");
            parameters.ReferencedAssemblies.Add("System.dll");// System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
            parameters.ReferencedAssemblies.Add("System.Data.dll");


            List<string> sources = new List<string>();

            using (DatabaseReader databaseReader = new DatabaseReader(connectionString, "multivista"))
            {
                DatabaseTemplate databaseTemplate = new DatabaseTemplate("multivista");
                foreach (DatabaseTable dbt in databaseReader) {

                    Schema schema = databaseTemplate.Schemas.Find(x => x.DbSchema == dbt.Scheme);
                    if (schema == null)
                    {
                        schema = new Schema(dbt.Scheme);
                        databaseTemplate.Schemas.Add(schema);
                    } 


                    Console.WriteLine($"{dbt.DB} {dbt.Scheme}.{dbt.Name}");
                    Table table = new Table() { TableName = dbt.Name, Schema = dbt.Scheme };

                    

                    using (TableReader tableReader = new TableReader(dbt, connectionString))
                    {
                        foreach (TableColumn col in tableReader)
                        {
                            
                            table.Columns.Add(new Column()
                            {
                                Name = col.Name,
                                DataType = TypeMapping.GetFrameworkString(col.Type)
                            });
                        }
                    }

                    schema.Tables.Add(table);

                }

                string source = databaseTemplate.TransformText();
                File.WriteAllText(@"D:\development\source.cs", source);

                sources.Add(source);

                CompilerResults r = CodeDomProvider.CreateProvider("CSharp").CompileAssemblyFromSource(parameters, sources.ToArray());
                if (r.Errors.HasErrors)
                {
                    foreach (CompilerError err in r.Errors)
                    {
                        Console.WriteLine(err.ErrorText);
                    }
                }

            }





            
            
            if (Debugger.IsAttached == true)
            {
                Console.WriteLine("Waiting for key press");
                Console.ReadKey();
            }
            
        }
    }
}
