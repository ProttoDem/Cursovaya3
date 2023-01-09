using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DatabaseAccess
{
    public class TableColumn
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public bool NOT_NULL { get; set; }
        public bool UNIQUE { get; set; }
        public bool PRIMARY_KEY { get; set; }
    }
}
