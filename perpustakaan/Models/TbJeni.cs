using System;
using System.Collections.Generic;

#nullable disable

namespace perpustakaan.Models
{
    public partial class TbJeni
    {
        public TbJeni()
        {
            TbGenres = new HashSet<TbGenre>();
        }

        public int Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<TbGenre> TbGenres { get; set; }
    }
}
