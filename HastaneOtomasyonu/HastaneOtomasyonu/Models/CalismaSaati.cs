using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyonu.Models
{
    [Table("CalismaSaati")]
    public class CalismaSaati
    {
        [Key]
        public int SaatID { get; set; }

        [Required(ErrorMessage = "İsim boş olmaz")]
        [Display(Name = "Doktorİsmi")]
        public string? DoktorlarAd { get; set; }

        [Required(ErrorMessage = "Soyad boş olmaz")]
        [Display(Name = "DoktorSoyad")]
        public string? DoktorlarSoyad { get; set; }

        [Required(ErrorMessage = "gün bos olmaz")]
        [Display(Name = "calismaGunu")]
        public string? CalismaGunu { get; set; }

        public int BaslangicSaati { get; set; }

        public int BitisSaati { get; set; }
    }
}
