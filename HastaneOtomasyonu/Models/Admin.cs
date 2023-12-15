using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyonu.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
      
        [Required(ErrorMessage = "Mail boş olamaz")]
        [Display(Name = "AdminMail")]
        [DataType(DataType.EmailAddress)]
        public string? AdminMail { get; set; }
       
        [Required(ErrorMessage = "Şifre boş olamaz")]
        [Display(Name = "AdminPassword")]
        [DataType(DataType.Password)]
        public int AdminPassword { get; set; }

    }
}
