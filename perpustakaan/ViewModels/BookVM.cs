using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perpustakaan.ViewModels
{
    public class BookVM
    {
        public int kode_buku { get; set; }
        public string judul_buku { get; set; }
        public DateTime tahun_buku { get; set; }
        public int kode_rak { get; set; }
        public int kode_jenis { get; set; }
        public int kode_genre { get; set; }
    }
    public class SaveBook
    { 
        public int kode_buku { get; set; }
        public string judul_buku { get; set; }
        public DateTime tahun_buku { get; set; }
    }
}
