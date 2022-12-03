﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BaiTapNhom11.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221130045735_GioiTinh")]
    partial class GioiTinh
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("BaiTapNhom11.Models.ChucVu", b =>
                {
                    b.Property<string>("MaChucVu")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenChucVu")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaChucVu");

                    b.ToTable("ChucVu");
                });

            modelBuilder.Entity("BaiTapNhom11.Models.GioiTinh", b =>
                {
                    b.Property<string>("MaGioiTinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenGioiTinh")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaGioiTinh");

                    b.ToTable("GioiTinh");
                });

            modelBuilder.Entity("BaiTapNhom11.Models.KhoSach", b =>
                {
                    b.Property<string>("TenSach")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConLai")
                        .HasColumnType("TEXT");

                    b.Property<string>("DaBan")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("NgayNhap")
                        .HasColumnType("TEXT");

                    b.HasKey("TenSach");

                    b.ToTable("KhoSach");
                });

            modelBuilder.Entity("BaiTapNhom11.Models.Sach", b =>
                {
                    b.Property<string>("MaSach")
                        .HasColumnType("TEXT");

                    b.Property<string>("GiaTien")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaTheLoai")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("NamXuatBan")
                        .HasColumnType("TEXT");

                    b.Property<string>("TacGia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenSach")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaSach");

                    b.HasIndex("MaTheLoai");

                    b.HasIndex("TenSach");

                    b.ToTable("Sach");
                });

            modelBuilder.Entity("BaiTapNhom11.Models.TheLoai", b =>
                {
                    b.Property<string>("MaTheLoai")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenTheLoai")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaTheLoai");

                    b.ToTable("TheLoai");
                });

            modelBuilder.Entity("BaiTapNhom11.Models.Sach", b =>
                {
                    b.HasOne("BaiTapNhom11.Models.TheLoai", "TheLoai")
                        .WithMany()
                        .HasForeignKey("MaTheLoai")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BaiTapNhom11.Models.KhoSach", "KhoSach")
                        .WithMany()
                        .HasForeignKey("TenSach")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhoSach");

                    b.Navigation("TheLoai");
                });
#pragma warning restore 612, 618
        }
    }
}
