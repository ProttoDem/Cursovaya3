using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public class ReadData
    {
        public string TableName { get; set; }
        public int? Top { get; set; }
        public string? Condition { get; set; }

    }
}
