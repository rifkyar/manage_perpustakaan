using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perpustakaan.Models
{
    public class Response
    {
        public string Code { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
