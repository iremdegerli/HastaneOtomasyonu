﻿// <auto-generated />
using System;
using HastaneOtomasyonu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HastaneOtomasyonu.Migrations
{
    [DbContext(typeof(HastaneCS))]
    [Migration("20240101163905_asdfdsa")]
    partial class asdfdsa
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HastaneOtomasyonu.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("AdminMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AdminPassword")
                        .HasColumnType("int");

                    b.HasKey("AdminId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("HastaneOtomasyonu.Models.CalismaSaati", b =>
                {
                    b.Property<int>("SaatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaatID"));

                    b.Property<int>("BaslangicSaati")
                        .HasColumnType("int");

                    b.Property<int>("BitisSaati")
                        .HasColumnType("int");

                    b.Property<string>("CalismaGunu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorlarAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorlarSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SaatID");

                    b.ToTable("CalismaSaati");
                });

            modelBuilder.Entity("HastaneOtomasyonu.Models.Doktorlar", b =>
                {
                    b.Property<int>("DoktorlarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoktorlarId"));

                    b.Property<string>("DoktorlarAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorlarBolum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorlarMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorlarSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoktorlarId");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("HastaneOtomasyonu.Models.Hastalar", b =>
                {
                    b.Property<int>("Tc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Tc"));

                    b.Property<string>("HastalarAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HastalarCinsiyet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HastalarDogumTarihi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HastalarKanGrubu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HastalarSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HastalarTelNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Tc");

                    b.ToTable("Hastalar");
                });

            modelBuilder.Entity("HastaneOtomasyonu.Models.KullaniciHesap", b =>
                {
                    b.Property<int>("KullaniciHesapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KullaniciHesapId"));

                    b.Property<string>("CPassword")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KullaniciHesapId");

                    b.ToTable("KullaniciHesap");
                });

            modelBuilder.Entity("HastaneOtomasyonu.Models.Poliklinik", b =>
                {
                    b.Property<int>("Poliklinid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Poliklinid"));

                    b.Property<int>("DoktorSayisi")
                        .HasColumnType("int");

                    b.Property<string>("PoliklinikAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Poliklinid");

                    b.ToTable("Poliklinik");
                });

            modelBuilder.Entity("HastaneOtomasyonu.Models.Randevu", b =>
                {
                    b.Property<int>("RandevuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RandevuId"));

                    b.Property<string>("DoktorlarAd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorlarSoyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HastalarAd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HastalarSoyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RandevuSaati")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RandevuTarih")
                        .HasColumnType("datetime2");

                    b.Property<int>("Tc")
                        .HasColumnType("int");

                    b.HasKey("RandevuId");

                    b.ToTable("Randevu");
                });
#pragma warning restore 612, 618
        }
    }
}
