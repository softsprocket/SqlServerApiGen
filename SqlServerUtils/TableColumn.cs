using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerUtils
{
    public class TableColumn
    {
        private string name;
        private string type;
        private string isNullable;
        private int? maximumLength;

        public string Type { get => type; set => type = value; }
        public string Name { get => name; set => name = value; }
        public string IsNullable { get => isNullable; set => isNullable = value; }
        public int? MaximumLength { get => maximumLength; set => maximumLength = value; }
    }
}
