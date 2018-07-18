using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerUtils
{
    public class DatabaseTable
    {
        private string schema;
        private string name;
        private string database;

        public string Name { get => name; set => name = value; }
        public string Scheme { get => schema; set => schema = value; }
        public string DB { get => database; set => database = value; }
    }
}
