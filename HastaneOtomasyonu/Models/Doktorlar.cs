using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyonu.Models
{
    [Table("Doktorlar")]
    public class Doktorlar
    {
        [Key]
        
       public int DoktorlarId { get; set; }
       
        [Required(ErrorMessage ="Doktor ismi boş olamaz")]
        [Display(Name ="Doktorİsmi")]
        public string? DoktorlarAd {  get; set; }
        
        [Required(ErrorMessage = "Doktor soyadı boş olamaz")]
        [Display(Name = "DoktorSoyad")]
        public string? DoktorlarSoyad { get; set; }
       
        [Required(ErrorMessage = "Doktor maili boş olamaz")]
        [Display(Name = "DoktorMail")]
        [DataType(DataType.EmailAddress)]
        public string? DoktorlarMail { get; set; }
       
        [Required(ErrorMessage = "Doktor alanı boş olamaz")]
        [Display(Name = "DoktorBolum")]
        public string? DoktorlarBolum { get; set; }
    }
}
