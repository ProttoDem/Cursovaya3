using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public class Table
    {
        public string Name { get; set; }
        public IEnumerable<TableColumn> Columns { get; set; }
    }
}
