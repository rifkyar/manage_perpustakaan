using System;
using System.Collections.Generic;

#nullable disable

namespace perpustakaan.Models
{
    public partial class TbGenre
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int IdJenis { get; set; }

        public virtual TbJeni IdJenisNavigation { get; set; }
    }
}
