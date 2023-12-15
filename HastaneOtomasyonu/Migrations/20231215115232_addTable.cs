using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneOtomasyonu.Migrations
{
    /// <inheritdoc />
    public partial class addTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminPassword = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "CalismaSaati",
                columns: table => new
                {
                    SaatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorlarAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoktorlarSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalismaGunu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaslangicSaati = table.Column<int>(type: "int", nullable: false),
                    BitisSaati = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalismaSaati", x => x.SaatID);
                });

            migrationBuilder.CreateTable(
                name: "Doktorlar",
                columns: table => new
                {
                    DoktorlarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorlarAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoktorlarSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoktorlarMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoktorlarBolum = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktorlar", x => x.DoktorlarId);
                });

            migrationBuilder.CreateTable(
                name: "Hastalar",
                columns: table => new
                {
                    Tc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastalarAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HastalarSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HastalarTelNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HastalarDogumTarihi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HastalarCinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HastalarKanGrubu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastalar", x => x.Tc);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciHesap",
                columns: table => new
                {
                    KullaniciHesapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CPassword = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciHesap", x => x.KullaniciHesapId);
                });

            migrationBuilder.CreateTable(
                name: "Poliklinik",
                columns: table => new
                {
                    Poliklinid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliklinikAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoktorSayisi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poliklinik", x => x.Poliklinid);
                });

            migrationBuilder.CreateTable(
                name: "Randevu",
                columns: table => new
                {
                    RandevuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tc = table.Column<int>(type: "int", nullable: false),
                    HastalarAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HastalarSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoktorlarAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoktorlarSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RandevuTarih = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevu", x => x.RandevuId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "CalismaSaati");

            migrationBuilder.DropTable(
                name: "Doktorlar");

            migrationBuilder.DropTable(
                name: "Hastalar");

            migrationBuilder.DropTable(
                name: "KullaniciHesap");

            migrationBuilder.DropTable(
                name: "Poliklinik");

            migrationBuilder.DropTable(
                name: "Randevu");
        }
    }
}
