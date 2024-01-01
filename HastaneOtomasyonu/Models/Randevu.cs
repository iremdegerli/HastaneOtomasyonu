﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyonu.Models
{
    [Table("Randevu")]
    public class Randevu
    {
        [Key]
        public int RandevuId { get; set; }

		public int Tc { get; set; }


		[Display(Name = "Hastaİsmi")]
		public string? HastalarAd { get; set; }

		[Display(Name = "HastaSoyadı")]
		public string? HastalarSoyad { get; set; }

		[Display(Name = "Doktorİsmi")]
		public string? DoktorlarAd { get; set; }

		[Display(Name = "DoktorSoyad")]
		public string? DoktorlarSoyad { get; set; }

        [Display(Name = "RandevuTarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RandevuTarih { get; set; }

		[RegularExpression(@"^[0-9]{2}:[0-9]{2}$", ErrorMessage = "Invalid time format")]
		public DateTime? RandevuSaati { get; set; }
    }
}
