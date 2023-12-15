using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyonu.Models
{
    [Table("Poliklinik")]
    public class Poliklinik
    {
        [Key]

        public int Poliklinid { get; set; }

        [Required(ErrorMessage = "poliklink boş olmaz")]
        [Display(Name = "Poliklinik")]
        public string? PoliklinikAd {  get; set; }
        
        [Required(ErrorMessage = "doktor sayısı boş olmaz")]
        [Range(4,15, ErrorMessage ="doktor sayısı 4le 15 arasında")]
        public int DoktorSayisi{ get; set; }
    }
}
