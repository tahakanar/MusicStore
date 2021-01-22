using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicStore.Data
{
    public class Artist
    {
        public int Id { get; set; }

        [Display(Name = "Sanatçı Adı")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string Name { get; set; } 
        public byte[] Photo { get; set; }

        [NotMapped]
        [Display(Name = "Sanatçı Fotoğrafı")]
        public HttpPostedFileBase PhotoFile { get; set; }

        public virtual ICollection<Album> Albums { get; set; } = new HashSet<Album>();
    }
}