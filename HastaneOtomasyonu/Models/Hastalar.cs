using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyonu.Models
{
    [Table("Hastalar")]
    public class Hastalar
    {
        [Key]
        public int Tc{ get; set; }
       
        [Required(ErrorMessage = "İsim boş olmaz")]
        [Display(Name = "Hastaİsmi")]
        public string? HastalarAd { get; set; }
       
        [Required(ErrorMessage = "soyad boş olmaz")]
        [Display(Name = "HastaSoyadı")]
        public string? HastalarSoyad { get; set; }
        [Required(ErrorMessage = "telefon boş olmaz")]
        [Display(Name = "HastaTelNo")]
        public string? HastalarTelNo{ get; set; }
        [Required(ErrorMessage = "DogumTarihi boş olmaz")]
        
        [Display(Name = "HastaDogumTarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}",ApplyFormatInEditMode = true)]
        public string? HastalarDogumTarihi { get; set; }
        
        [Required(ErrorMessage = "cinsiyet boş olmaz")]
        [Display(Name = "HastaCinsiyet")]
        [EnumDataType(typeof(Cinsiyet))]
        public string? HastalarCinsiyet { get; set; }
      
        [Required(ErrorMessage = "kan grubu boş olmaz")]
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
        Apzt,
        Bpzt,
        Sıfırpzt,
        Angt,
        Bngt,
        Sıfırngt,
        ABpzt,
        ABngt

    }
}
