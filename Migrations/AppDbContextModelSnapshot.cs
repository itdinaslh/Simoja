﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Simoja.Data;

#nullable disable

namespace Simoja.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ClientJenisUsaha", b =>
                {
                    b.Property<Guid>("ClientsClientID")
                        .HasColumnType("uuid");

                    b.Property<int>("JenisUsahasJenisUsahaID")
                        .HasColumnType("integer");

                    b.HasKey("ClientsClientID", "JenisUsahasJenisUsahaID");

                    b.HasIndex("JenisUsahasJenisUsahaID");

                    b.ToTable("ClientJenisUsaha");
                });

            modelBuilder.Entity("Simoja.Domain.Entity.LokasiBuang", b =>
                {
                    b.Property<int>("LokasiBuangID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LokasiBuangID"));

                    b.Property<string>("NamaLokasi")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("LokasiBuangID");

                    b.ToTable("LokasiBuang");
                });

            modelBuilder.Entity("Simoja.Entity.Client", b =>
                {
                    b.Property<Guid>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Alamat")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DokumenKTP")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("DokumenNIB")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("DokumenNPWP")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Fax")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<int?>("FlagID")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAngkut")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsOlah")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsUsaha")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("boolean");

                    b.Property<string>("KelurahanID")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("Latitude")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Longitude")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("NIB")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("NIK")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<string>("NPWP")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("NoHpPIC")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<long>("NoUrut")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("NoUrut"));

                    b.Property<string>("PIC")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("character varying(75)");

                    b.Property<string>("PenanggungJawab")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("character varying(75)");

                    b.Property<string>("Telp")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("ClientID");

                    b.HasIndex("FlagID");

                    b.HasIndex("KelurahanID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Simoja.Entity.Flag", b =>
                {
                    b.Property<int>("FlagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FlagID"));

                    b.Property<string>("FlagName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("FlagID");

                    b.ToTable("Flags");
                });

            modelBuilder.Entity("Simoja.Entity.IzinAngkut", b =>
                {
                    b.Property<Guid>("IzinAngkutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientID")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DokumenIzin")
                        .HasColumnType("text");

                    b.Property<int>("JmlAngkutan")
                        .HasColumnType("integer");

                    b.Property<int?>("LokasiBuangID")
                        .HasColumnType("integer");

                    b.Property<int>("LokasiIzinID")
                        .HasColumnType("integer");

                    b.Property<string>("NoIzinUsaha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateOnly>("TglAkhirIzin")
                        .HasColumnType("date");

                    b.Property<DateOnly>("TglTerbitIzin")
                        .HasColumnType("date");

                    b.Property<Guid>("UniqueID")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("IzinAngkutID");

                    b.HasIndex("ClientID");

                    b.HasIndex("LokasiBuangID");

                    b.HasIndex("LokasiIzinID");

                    b.ToTable("IzinAngkut");
                });

            modelBuilder.Entity("Simoja.Entity.IzinKegiatan", b =>
                {
                    b.Property<Guid>("IzinKegiatanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientID")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DokumenIzin")
                        .HasColumnType("text");

                    b.Property<bool?>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<int>("JenisIzinLingkunganID")
                        .HasColumnType("integer");

                    b.Property<int>("JenisKegiatanID")
                        .HasColumnType("integer");

                    b.Property<int>("LokasiIzinID")
                        .HasColumnType("integer");

                    b.Property<string>("NamaKawasan")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("NoIzinUsaha")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("PihakAngkutID")
                        .HasColumnType("integer");

                    b.Property<int?>("StatusKelolaID")
                        .HasColumnType("integer");

                    b.Property<DateOnly?>("TglTerbitIzin")
                        .HasColumnType("date");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("IzinKegiatanID");

                    b.HasIndex("ClientID");

                    b.HasIndex("JenisIzinLingkunganID");

                    b.HasIndex("JenisKegiatanID");

                    b.HasIndex("LokasiIzinID");

                    b.HasIndex("PihakAngkutID");

                    b.HasIndex("StatusKelolaID");

                    b.ToTable("IzinKegiatan");
                });

            modelBuilder.Entity("Simoja.Entity.IzinOlah", b =>
                {
                    b.Property<Guid>("IzinOlahID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientID")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DokumenIzin")
                        .HasColumnType("text");

                    b.Property<int>("JumlahTeknologi")
                        .HasColumnType("integer");

                    b.Property<int>("LokasiIzinID")
                        .HasColumnType("integer");

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

                    b.HasKey("IzinOlahID");

                    b.HasIndex("ClientID");

                    b.HasIndex("LokasiIzinID");

                    b.ToTable("IzinOlah");
                });

            modelBuilder.Entity("Simoja.Entity.JenisIzinLingkungan", b =>
                {
                    b.Property<int>("JenisIzinLingkunganID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("JenisIzinLingkunganID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NamaJenisIzin")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("JenisIzinLingkunganID");

                    b.ToTable("JenisIzinLingkungans");
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
                    b.Property<int>("JenisKendaraanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("JenisKendaraanID"));

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

                    b.HasKey("JenisKendaraanID");

                    b.HasIndex("GlobalId")
                        .IsUnique();

                    b.ToTable("JenisKendaraan");
                });

            modelBuilder.Entity("Simoja.Entity.JenisUsaha", b =>
                {
                    b.Property<int>("JenisUsahaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("JenisUsahaID"));

                    b.Property<string>("NamaJenis")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Prefix")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("JenisUsahaID");

                    b.ToTable("JenisUsaha");
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
                    b.Property<long>("KendaraanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("KendaraanID"));

                    b.Property<string>("BuktiUjiEmisi")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DokumenKIR")
                        .HasColumnType("text");

                    b.Property<string>("DokumenSTNK")
                        .HasColumnType("text");

                    b.Property<string>("FotoKendaraan")
                        .HasColumnType("text");

                    b.Property<Guid>("IzinAngkutID")
                        .HasColumnType("uuid");

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

                    b.Property<Guid>("UniqueID")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("KendaraanID");

                    b.HasIndex("IzinAngkutID");

                    b.HasIndex("JenisKendaraanId");

                    b.HasIndex("UniqueID")
                        .IsUnique();

                    b.ToTable("Kendaraan");
                });

            modelBuilder.Entity("Simoja.Entity.LokasiAngkut", b =>
                {
                    b.Property<int>("LokasiAngkutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LokasiAngkutID"));

                    b.Property<string>("Alamat")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ClientID")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DokumenPath")
                        .HasColumnType("text");

                    b.Property<bool?>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<string>("KelurahanID")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("NamaLokasi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateOnly>("TglAkhirKontrak")
                        .HasColumnType("date");

                    b.Property<DateOnly>("TglAwalKontrak")
                        .HasColumnType("date");

                    b.Property<Guid>("UniqueID")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("LokasiAngkutID");

                    b.HasIndex("ClientID");

                    b.HasIndex("KelurahanID");

                    b.HasIndex("UniqueID")
                        .IsUnique();

                    b.ToTable("LokasiAngkut");
                });

            modelBuilder.Entity("Simoja.Entity.LokasiIzin", b =>
                {
                    b.Property<int>("LokasiIzinID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LokasiIzinID"));

                    b.Property<string>("NamaLokasi")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("LokasiIzinID");

                    b.ToTable("LokasiIzin");
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

            modelBuilder.Entity("ClientJenisUsaha", b =>
                {
                    b.HasOne("Simoja.Entity.Client", null)
                        .WithMany()
                        .HasForeignKey("ClientsClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Simoja.Entity.JenisUsaha", null)
                        .WithMany()
                        .HasForeignKey("JenisUsahasJenisUsahaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Simoja.Entity.Client", b =>
                {
                    b.HasOne("Simoja.Entity.Flag", "Flag")
                        .WithMany()
                        .HasForeignKey("FlagID");

                    b.HasOne("Simoja.Entity.Kelurahan", "Kelurahan")
                        .WithMany("Clients")
                        .HasForeignKey("KelurahanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flag");

                    b.Navigation("Kelurahan");
                });

            modelBuilder.Entity("Simoja.Entity.IzinAngkut", b =>
                {
                    b.HasOne("Simoja.Entity.Client", "Client")
                        .WithMany("IzinAngkuts")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Simoja.Domain.Entity.LokasiBuang", "LokasiBuang")
                        .WithMany("IzinAngkuts")
                        .HasForeignKey("LokasiBuangID");

                    b.HasOne("Simoja.Entity.LokasiIzin", "LokasiIzin")
                        .WithMany("IzinAngkuts")
                        .HasForeignKey("LokasiIzinID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("LokasiBuang");

                    b.Navigation("LokasiIzin");
                });

            modelBuilder.Entity("Simoja.Entity.IzinKegiatan", b =>
                {
                    b.HasOne("Simoja.Entity.Client", "Client")
                        .WithMany("IzinKegiatans")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Simoja.Entity.JenisIzinLingkungan", "JenisIzinLingkungan")
                        .WithMany("Kawasans")
                        .HasForeignKey("JenisIzinLingkunganID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Simoja.Entity.JenisKegiatan", "JenisKegiatan")
                        .WithMany("Kawasans")
                        .HasForeignKey("JenisKegiatanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Simoja.Entity.LokasiIzin", "LokasiIzin")
                        .WithMany("Kawasans")
                        .HasForeignKey("LokasiIzinID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Simoja.Entity.PihakAngkut", null)
                        .WithMany("DetailKawasans")
                        .HasForeignKey("PihakAngkutID");

                    b.HasOne("Simoja.Entity.StatusKelola", null)
                        .WithMany("DetailKawasans")
                        .HasForeignKey("StatusKelolaID");

                    b.Navigation("Client");

                    b.Navigation("JenisIzinLingkungan");

                    b.Navigation("JenisKegiatan");

                    b.Navigation("LokasiIzin");
                });

            modelBuilder.Entity("Simoja.Entity.IzinOlah", b =>
                {
                    b.HasOne("Simoja.Entity.Client", "Client")
                        .WithMany("IzinOlahs")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Simoja.Entity.LokasiIzin", "LokasiIzin")
                        .WithMany("IzinOlahs")
                        .HasForeignKey("LokasiIzinID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("LokasiIzin");
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
                    b.HasOne("Simoja.Entity.IzinAngkut", "IzinAngkut")
                        .WithMany("Kendaraans")
                        .HasForeignKey("IzinAngkutID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Simoja.Entity.JenisKendaraan", "JenisKendaraan")
                        .WithMany("Kendaraans")
                        .HasForeignKey("JenisKendaraanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IzinAngkut");

                    b.Navigation("JenisKendaraan");
                });

            modelBuilder.Entity("Simoja.Entity.LokasiAngkut", b =>
                {
                    b.HasOne("Simoja.Entity.Client", "Client")
                        .WithMany("LokasiAngkuts")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Simoja.Entity.Kelurahan", "Kelurahan")
                        .WithMany("LokasiAngkuts")
                        .HasForeignKey("KelurahanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Kelurahan");
                });

            modelBuilder.Entity("Simoja.Domain.Entity.LokasiBuang", b =>
                {
                    b.Navigation("IzinAngkuts");
                });

            modelBuilder.Entity("Simoja.Entity.Client", b =>
                {
                    b.Navigation("IzinAngkuts");

                    b.Navigation("IzinKegiatans");

                    b.Navigation("IzinOlahs");

                    b.Navigation("LokasiAngkuts");
                });

            modelBuilder.Entity("Simoja.Entity.IzinAngkut", b =>
                {
                    b.Navigation("Kendaraans");
                });

            modelBuilder.Entity("Simoja.Entity.JenisIzinLingkungan", b =>
                {
                    b.Navigation("Kawasans");
                });

            modelBuilder.Entity("Simoja.Entity.JenisKegiatan", b =>
                {
                    b.Navigation("Kawasans");
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

                    b.Navigation("LokasiAngkuts");
                });

            modelBuilder.Entity("Simoja.Entity.LokasiIzin", b =>
                {
                    b.Navigation("IzinAngkuts");

                    b.Navigation("IzinOlahs");

                    b.Navigation("Kawasans");
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
