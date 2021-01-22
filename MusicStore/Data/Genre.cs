using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.Data
{
    public class Genre
    {
        public int Id { get; set; }

        [Display(Name = "Tür Adı")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; } = new HashSet<Album>();
    }
}