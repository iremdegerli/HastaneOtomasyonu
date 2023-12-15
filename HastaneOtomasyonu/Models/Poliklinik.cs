using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyonu.Models
{
    [Table("Poliklinik")]
    public class Poliklinik
    {
        [Key]

        public int Poliklinid { get; set; }

        [Required(ErrorMessage = "Poliklinik ismi boş olamaz")]
        [Display(Name = "Poliklinik")]
        public string? PoliklinikAd {  get; set; }
        
        [Required(ErrorMessage = "Doktor sayısı giriniz.")]
        [Range(1,7, ErrorMessage ="Doktor sayısı 1 ile 17 arasında olmalı")]
        public int DoktorSayisi{ get; set; }
    }
}
