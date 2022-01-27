using System;
using System.Collections.Generic;

#nullable disable

namespace perpustakaan.Models
{
    public partial class TbTrBuku
    {
        public int? KodeBuku { get; set; }
        public string JudulBuku { get; set; }
        public DateTime? TahunBuku { get; set; }
        public int? Rak { get; set; }
        public int? Jenis { get; set; }
        public int? Genre { get; set; }
    }
}
