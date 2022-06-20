﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Simoja.Data;

#nullable disable

namespace Simoja.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220619223419_AlterKendaraan")]
    partial class AlterKendaraan
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Simoja.Entity.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ClientId"));

                    b.Property<string>("Alamat")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<Guid>("ClientGuid")
                        .HasColumnType("uuid");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Fax")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("boolean");

                    b.Property<int?>("JenisUsahaId")
                        .HasColumnType("integer");

                    b.Property<string>("KelurahanID")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("Latitude")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Longitude")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("NoHpPIC")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("PIC")
                        .HasMaxLength(75)
                        .HasColumnType("character varying(75)");

                    b.Property<string>("PenanggungJawab")
                        .HasMaxLength(75)
                        .HasColumnType("character varying(75)");

                    b.Property<string>("Telp")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ClientId");

                    b.HasIndex("KelurahanID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Simoja.Entity.DetailAngkut", b =>
                {
                    b.Property<int>("DetailAngkutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DetailAngkutId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DokumenIzinPath")
                        .HasColumnType("text");

                    b.Property<int>("JmlAngkutan")
                        .HasColumnType("integer");

                    b.Property<string>("NIB")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("NIBPath")
                        .HasColumnType("text");

                    b.Property<string>("NoIzinUsaha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateOnly>("TglAkhirIzin")
                        .HasColumnType("date");

                    b.Property<DateOnly>("TglTerbitIzin")
                        .HasColumnType("date");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("DetailAngkutId");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("DetailAngkut");
                });

            modelBuilder.Entity("Simoja.Entity.DetailKawasan", b =>
                {
                    b.Property<int>("DetailKawasanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DetailKawasanId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DimensiTps")
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<bool?>("IsDipilah")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsOlah")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsPembatasan")
                        .HasColumnType("boolean");

                    b.Property<int>("JenisKegiatanID")
                        .HasColumnType("integer");

                    b.Property<string>("JenisOlah")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("JenisPilah")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<double?>("JumlahPilah")
                        .HasColumnType("double precision");

                    b.Property<string>("LokasiOlah")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LokasiOlahLuar")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("NamaPengolah")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<double?>("OlahAvg")
                        .HasColumnType("double precision");

                    b.Property<string>("PengolahanPath")
                        .HasColumnType("text");

                    b.Property<int?>("PihakAngkutID")
                        .HasColumnType("integer");

                    b.Property<bool?>("PunyaTps")
                        .HasColumnType("boolean");

                    b.Property<int>("StatusKelolaID")
                        .HasColumnType("integer");

                    b.Property<int?>("TimbulanAvg")
                        .HasColumnType("integer");

                    b.Property<string>("TpsPath")
                        .HasColumnType("text");

                    b.Property<bool?>("TpsTerpilah")
                        .HasColumnType("boolean");

                    b.Property<string>("Upaya")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("WadahPath")
                        .HasColumnType("text");

                    b.HasKey("DetailKawasanId");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.HasIndex("JenisKegiatanID");

                    b.HasIndex("PihakAngkutID");

                    b.HasIndex("StatusKelolaID");

                    b.ToTable("DetailKawasan");
                });

            modelBuilder.Entity("Simoja.Entity.DetailOlah", b =>
                {
                    b.Property<int>("DetailOlahId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DetailOlahId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DokumenIzinPath")
                        .HasColumnType("text");

                    b.Property<string>("NIB")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("NIBPath")
                        .HasColumnType("text");

                    b.Property<string>("NoIzinUsaha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateOnly>("TglAkhirIzin")
                        .HasColumnType("date");

                    b.Property<DateOnly>("TglTerbitIzin")
                        .HasColumnType("date");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("DetailOlahId");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("DetailOlah");
                });

            modelBuilder.Entity("Simoja.Entity.JenisKegiatan", b =>
                {
                    b.Property<int>("JenisKegiatanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("JenisKegiatanID"));

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("NamaKegiatan")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.HasKey("JenisKegiatanID");

                    b.ToTable("JenisKegiatan");
                });

            modelBuilder.Entity("Simoja.Entity.JenisKendaraan", b =>
                {
                    b.Property<int>("JenisKendaraanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("JenisKendaraanId"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("GlobalId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("NamaJenis")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("JenisKendaraanId");

                    b.HasIndex("GlobalId")
                        .IsUnique();

                    b.ToTable("JenisKendaraan");
                });

            modelBuilder.Entity("Simoja.Entity.Kabupaten", b =>
                {
                    b.Property<string>("KabupatenID")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<bool>("IsKota")
                        .HasColumnType("boolean");

                    b.Property<string>("Latitude")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Longitude")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("NamaKabupaten")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("ProvinsiID")
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.HasKey("KabupatenID");

                    b.HasIndex("ProvinsiID");

                    b.ToTable("Kabupaten");
                });

            modelBuilder.Entity("Simoja.Entity.Kecamatan", b =>
                {
                    b.Property<string>("KecamatanID")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("KabupatenID")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Latitude")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Longitude")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("NamaKecamatan")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("KecamatanID");

                    b.HasIndex("KabupatenID");

                    b.ToTable("Kecamatan");
                });

            modelBuilder.Entity("Simoja.Entity.Kelurahan", b =>
                {
                    b.Property<string>("KelurahanID")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("KecamatanID")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Latitude")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Longitude")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("NamaKelurahan")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("KelurahanID");

                    b.HasIndex("KecamatanID");

                    b.ToTable("Kelurahan");
                });

            modelBuilder.Entity("Simoja.Entity.Kendaraan", b =>
                {
                    b.Property<long>("KendaraanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("KendaraanId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DokumenKIR")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DokumenSTNK")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FotoKendaraan")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("JenisKendaraanId")
                        .HasColumnType("integer");

                    b.Property<string>("NoPintu")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("NoPolisi")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("TahunPembuatan")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)");

                    b.Property<DateOnly>("TglKIR")
                        .HasColumnType("date");

                    b.Property<DateOnly>("TglSTNK")
                        .HasColumnType("date");

                    b.Property<Guid>("UniqueId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("KendaraanId");

                    b.HasIndex("ClientId");

                    b.HasIndex("JenisKendaraanId");

                    b.ToTable("Kendaraan");
                });

            modelBuilder.Entity("Simoja.Entity.PihakAngkut", b =>
                {
                    b.Property<int>("PihakAngkutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PihakAngkutID"));

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("NamaPihak")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("PihakAngkutID");

                    b.ToTable("PihakAngkut");
                });

            modelBuilder.Entity("Simoja.Entity.Provinsi", b =>
                {
                    b.Property<string>("ProvinsiID")
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.Property<string>("HcKey")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("KodeNegara")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.Property<string>("Latitude")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Longitude")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("NamaProvinsi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ProvinsiID");

                    b.ToTable("Provinsi");
                });

            modelBuilder.Entity("Simoja.Entity.StatusKelola", b =>
                {
                    b.Property<int>("StatusKelolaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StatusKelolaID"));

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("NamaStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("StatusKelolaID");

                    b.ToTable("StatusKelola");
                });

            modelBuilder.Entity("Simoja.Entity.Client", b =>
                {
                    b.HasOne("Simoja.Entity.Kelurahan", "Kelurahan")
                        .WithMany("Clients")
                        .HasForeignKey("KelurahanID");

                    b.Navigation("Kelurahan");
                });

            modelBuilder.Entity("Simoja.Entity.DetailAngkut", b =>
                {
                    b.HasOne("Simoja.Entity.Client", "Client")
                        .WithOne("DetailAngkut")
                        .HasForeignKey("Simoja.Entity.DetailAngkut", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Simoja.Entity.DetailKawasan", b =>
                {
                    b.HasOne("Simoja.Entity.Client", null)
                        .WithOne("DetailKawasan")
                        .HasForeignKey("Simoja.Entity.DetailKawasan", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Simoja.Entity.JenisKegiatan", "JenisKegiatan")
                        .WithMany("DetailKawasans")
                        .HasForeignKey("JenisKegiatanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Simoja.Entity.PihakAngkut", "PihakAngkut")
                        .WithMany("DetailKawasans")
                        .HasForeignKey("PihakAngkutID");

                    b.HasOne("Simoja.Entity.StatusKelola", "StatusKelola")
                        .WithMany("DetailKawasans")
                        .HasForeignKey("StatusKelolaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JenisKegiatan");

                    b.Navigation("PihakAngkut");

                    b.Navigation("StatusKelola");
                });

            modelBuilder.Entity("Simoja.Entity.DetailOlah", b =>
                {
                    b.HasOne("Simoja.Entity.Client", "Client")
                        .WithOne("DetailOlah")
                        .HasForeignKey("Simoja.Entity.DetailOlah", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Simoja.Entity.Kabupaten", b =>
                {
                    b.HasOne("Simoja.Entity.Provinsi", "Provinsi")
                        .WithMany("Kabupatens")
                        .HasForeignKey("ProvinsiID");

                    b.Navigation("Provinsi");
                });

            modelBuilder.Entity("Simoja.Entity.Kecamatan", b =>
                {
                    b.HasOne("Simoja.Entity.Kabupaten", "Kabupaten")
                        .WithMany("Kecamatans")
                        .HasForeignKey("KabupatenID");

                    b.Navigation("Kabupaten");
                });

            modelBuilder.Entity("Simoja.Entity.Kelurahan", b =>
                {
                    b.HasOne("Simoja.Entity.Kecamatan", "Kecamatan")
                        .WithMany("Kelurahans")
                        .HasForeignKey("KecamatanID");

                    b.Navigation("Kecamatan");
                });

            modelBuilder.Entity("Simoja.Entity.Kendaraan", b =>
                {
                    b.HasOne("Simoja.Entity.Client", "Client")
                        .WithMany("Kendaraans")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Simoja.Entity.JenisKendaraan", "JenisKendaraan")
                        .WithMany("Kendaraans")
                        .HasForeignKey("JenisKendaraanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("JenisKendaraan");
                });

            modelBuilder.Entity("Simoja.Entity.Client", b =>
                {
                    b.Navigation("DetailAngkut");

                    b.Navigation("DetailKawasan");

                    b.Navigation("DetailOlah");

                    b.Navigation("Kendaraans");
                });

            modelBuilder.Entity("Simoja.Entity.JenisKegiatan", b =>
                {
                    b.Navigation("DetailKawasans");
                });

            modelBuilder.Entity("Simoja.Entity.JenisKendaraan", b =>
                {
                    b.Navigation("Kendaraans");
                });

            modelBuilder.Entity("Simoja.Entity.Kabupaten", b =>
                {
                    b.Navigation("Kecamatans");
                });

            modelBuilder.Entity("Simoja.Entity.Kecamatan", b =>
                {
                    b.Navigation("Kelurahans");
                });

            modelBuilder.Entity("Simoja.Entity.Kelurahan", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Simoja.Entity.PihakAngkut", b =>
                {
                    b.Navigation("DetailKawasans");
                });

            modelBuilder.Entity("Simoja.Entity.Provinsi", b =>
                {
                    b.Navigation("Kabupatens");
                });

            modelBuilder.Entity("Simoja.Entity.StatusKelola", b =>
                {
                    b.Navigation("DetailKawasans");
                });
#pragma warning restore 612, 618
        }
    }
}
