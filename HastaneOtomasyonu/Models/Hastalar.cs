using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyonu.Models
{
    [Table("Hastalar")]
    public class Hastalar
    {
        [Key]
        public int Tc{ get; set; }
       
        [Required(ErrorMessage = "Hasta ismi boş olamaz")]
        [Display(Name = "Hastaİsmi")]
        public string? HastalarAd { get; set; }
       
        [Required(ErrorMessage = "Hasta soyismi boş olamaz")]
        [Display(Name = "HastaSoyadı")]
        public string? HastalarSoyad { get; set; }
       
        [Required(ErrorMessage = "Hasta telefonu boş olamaz")]
        [Display(Name = "HastaTelNo")]
        public string? HastalarTelNo{ get; set; }
       
        [Required(ErrorMessage = "Hasta doğum tarihi boş olamaz")]
        [Display(Name = "HastaDogumTarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}",ApplyFormatInEditMode = true)]
        public string? HastalarDogumTarihi { get; set; }
        
        [Required(ErrorMessage = "Cinsiyet boş olamaz")]
        [Display(Name = "HastaCinsiyet")]
        [EnumDataType(typeof(Cinsiyet))]
        public string? HastalarCinsiyet { get; set; }
      
        [Required(ErrorMessage = "Kan grubu boş olamaz")]
        [Display(Name = "HastaKanGrubu")]
        [EnumDataType(typeof(KanGrubu))]
        public string? HastalarKanGrubu { get; set; }

    }
    public enum Cinsiyet
    {
        erkek, 
        kadın,
        diğer
    }
    public enum KanGrubu
    {
        Apozitif,
        Bpozitif,
        Sıfırpoizit,
		ABpozitif,
		Anegatif,
        Bnegatif,
        Sıfırnegatif,
        ABnegatif

    }
}
