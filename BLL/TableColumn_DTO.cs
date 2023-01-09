using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TableColumn_DTO
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public bool NOT_NULL { get; set; }
        public bool UNIQUE { get; set; }
        public bool PRIMARY_KEY { get; set; }
    }
}
