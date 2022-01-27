using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perpustakaku_client.Models
{
    public class Rak
    {
        public int id { get; set; }
        public string value { get; set; }
    }
    public class Jenis
    { 
        public int id { get; set; }
        public string value { get; set; }
    }
    public class ResponseRak
    {
        public string code { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public List<Rak> data { get; set; }
    }
    public class SaveRak
    { 
        public string Value { get; set; }
    }
}
