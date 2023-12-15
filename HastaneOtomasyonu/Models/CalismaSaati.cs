using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyonu.Models
{
    [Table("CalismaSaati")]
    public class CalismaSaati
    {
        [Key]
        public int SaatID { get; set; }

		[Required(ErrorMessage = "Doktor ismi boş olamaz")]
		[Display(Name = "Doktorİsmi")]
		public string? DoktorlarAd { get; set; }

		[Required(ErrorMessage = "Doktor soyadı boş olamaz")]
		[Display(Name = "DoktorSoyad")]
		public string? DoktorlarSoyad { get; set; }

		[Required(ErrorMessage = "Çalışma günü bos olmaz")]
        [Display(Name = "calismaGunu")]
        public string? CalismaGunu { get; set; }

        public int BaslangicSaati { get; set; }

        public int BitisSaati { get; set; }
    }
}
