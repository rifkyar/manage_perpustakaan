using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perpustakaan
{
    public class ConnectionString
    {
        public string Value { get; set; }
        public ConnectionString(string value)
        {
            Value = value;
        }
    }
}
