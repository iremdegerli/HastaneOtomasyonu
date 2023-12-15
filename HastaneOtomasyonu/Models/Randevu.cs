using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyonu.Models
{
    [Table("Randevu")]
    public class Randevu
    {
        [Key]
        public int RandevuId { get; set; }

		public int Tc { get; set; }

		[Required(ErrorMessage = "Hasta ismi boş olamaz")]
		[Display(Name = "Hastaİsmi")]
		public string? HastalarAd { get; set; }

		[Required(ErrorMessage = "Hasta soyismi boş olamaz")]
		[Display(Name = "HastaSoyadı")]
		public string? HastalarSoyad { get; set; }

		[Required(ErrorMessage = "Doktor ismi boş olamaz")]
		[Display(Name = "Doktorİsmi")]
		public string? DoktorlarAd { get; set; }

		[Required(ErrorMessage = "Doktor soyadı boş olamaz")]
		[Display(Name = "DoktorSoyad")]
		public string? DoktorlarSoyad { get; set; }

        [Display(Name = "RandevuTarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RandevuTarih { get; set; }

		[RegularExpression(@"^[0-9]{2}:[0-9]{2}$", ErrorMessage = "Invalid time format")]
		public DateTime? randevuSaati { get; set; }
    }
}
