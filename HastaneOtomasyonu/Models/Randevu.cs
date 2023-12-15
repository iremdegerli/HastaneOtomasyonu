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

        [Required(ErrorMessage = "İsim boş olmaz")]
        [Display(Name = "Hastaİsmi")]
        public string? HastalarAd { get; set; }

        [Required(ErrorMessage = "soyad boş olmaz")]
        [Display(Name = "HastaSoyadı")]
        public string? HastalarSoyad { get; set; }

        [Required(ErrorMessage = "İsim boş olmaz")]
        [Display(Name = "Doktorİsmi")]
        public string? DoktorlarAd { get; set; }

        [Required(ErrorMessage = "Soyad boş olmaz")]
        [Display(Name = "DoktorSoyad")]
        public string? DoktorlarSoyad { get; set; }

        [Display(Name = "RandevuTarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RandevuTarih { get; set; }

      
        //public DateTime? randevuSaati { get; set; }
    }
}
