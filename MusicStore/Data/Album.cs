using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicStore.Data
{
    public class Album
    {
        public int Id { get; set; }

        [Display(Name = "Albüm Adı")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string Name { get; set; }

        public DateTime Date { get; set; } = DateTime.Today;

        [Display(Name = "Albüm Çıkış Yılı")]
        [DataType(DataType.Text)]
        public int? Year { get; set; }

        [Display(Name = "Sanatçı")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public int ArtistId { get; set; }

        [Display(Name = "Tür")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public int GenreId { get; set; }

        public byte[] CoverImage { get; set; }

        public int Reviews { get; set; }

        [Display(Name = "Fiyat")]
        [DataType(DataType.Text)]
        public decimal Price { get; set; }

        [NotMapped]
        [RegularExpression(@"^[0-9]+(\,[0-9]{1,2})?$", ErrorMessage = "Lütfen geçerli bir fiyat giriniz.")]
        public string PriceText { get; set; }



        [NotMapped]
        [Display(Name = "Kapak Fotoğrafı")]
        public HttpPostedFileBase PhotoFile { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Genre Genre { get; set; }
    }
}