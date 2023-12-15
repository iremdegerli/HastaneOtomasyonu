using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyonu.Models
{
    [Table("Doktorlar")]
    public class Doktorlar
    {
        [Key]
        
       public int DoktorlarId { get; set; }
       
        [Required(ErrorMessage ="İsim boş olmaz")]
        [Display(Name ="Doktorİsmi")]
        public string? DoktorlarAd {  get; set; }
        
        [Required(ErrorMessage = "Soayd boş olmaz")]
        [Display(Name = "DoktorSoyad")]
        public string? DoktorlarSoyad { get; set; }
       
        [Required(ErrorMessage = "Mail boş olmaz")]
        [Display(Name = "DoktorMail")]
        [DataType(DataType.EmailAddress)]
        public string? DoktorlarMail { get; set; }
       
        [Required(ErrorMessage = "Bolum boş olmaz")]
        [Display(Name = "DoktorBolum")]
        public string? DoktorlarBolum { get; set; }
    }
}
