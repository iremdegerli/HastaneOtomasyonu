using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyonu.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
      
        [Required(ErrorMessage = "Mail boş olmaz")]
        [Display(Name = "AdminMail")]
        [DataType(DataType.EmailAddress)]
        public string? AdminMail { get; set; }
       
        [Required(ErrorMessage = "şifre boş olmaz")]
        [Display(Name = "AdminPassword")]
        [DataType(DataType.Password)]
        public int AdminPassword { get; set; }

    }
}
