using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HastaneOtomasyonu.Models;
using System.Collections.Generic;

namespace HastaneOtomasyonu.Models
{
        public class HastaneCS : DbContext
        {
            private readonly IConfiguration _configuration;

            public HastaneCS(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public DbSet<KullaniciHesap> KullaniciHesaplar { get; set; }
            public DbSet<CalismaSaati> CalismaSaatleri { get; set; }
            public DbSet<Hastalar> Hastalars { get; set; }
            public DbSet<Admin> Admins { get; set; }
            public DbSet<Doktorlar> Doktorlars { get; set; }
            public DbSet<Randevu> Randevular { get; set; }
            public DbSet<Poliklinik> Poliklinikler { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
                }
            }
        }
    }