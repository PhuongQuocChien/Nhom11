﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTLNhom11.Migrations
{
    [DbContext(typeof(MvcMovieContext))]
    [Migration("20221215134749_PhieuBH")]
    partial class PhieuBH
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("BTLNhom11.Models.ChucVu", b =>
                {
                    b.Property<string>("MaChucVu")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenChucVu")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaChucVu");

                    b.ToTable("ChucVu");
                });

            modelBuilder.Entity("BTLNhom11.Models.GioiTinh", b =>
                {
                    b.Property<string>("MaGioiTinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenGioiTinh")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaGioiTinh");

                    b.ToTable("GioiTinh");
                });

            modelBuilder.Entity("BTLNhom11.Models.HangHoa", b =>
                {
                    b.Property<string>("MaHH")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("GiaBanHH")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("GiaVonHH")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenHH")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("MaHH");

                    b.ToTable("HangHoa");
                });

            modelBuilder.Entity("BTLNhom11.Models.KhachHang", b =>
                {
                    b.Property<string>("MaKH")
                        .HasColumnType("TEXT");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaGioiTinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("SDTKH")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenKH")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaKH");

                    b.HasIndex("MaGioiTinh");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("BTLNhom11.Models.Kho", b =>
                {
                    b.Property<string>("Makho")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Dckho")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("Makho");

                    b.ToTable("Kho");
                });

            modelBuilder.Entity("BTLNhom11.Models.NhaCungCap", b =>
                {
                    b.Property<string>("Mancc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Diachincc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Emailncc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sdtncc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tenncc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ngayncc")
                        .HasColumnType("TEXT");

                    b.HasKey("Mancc");

                    b.ToTable("NhaCungCap");
                });

            modelBuilder.Entity("BTLNhom11.Models.NhanVien", b =>
                {
                    b.Property<string>("MaNV")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaChucVu")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaGioiTinh")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaQueQuan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("SDTNV")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenNV")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaNV");

                    b.HasIndex("MaChucVu");

                    b.HasIndex("MaGioiTinh");

                    b.HasIndex("MaQueQuan");

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("BTLNhom11.Models.PhieuBH", b =>
                {
                    b.Property<string>("MaPBH")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaKH")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaNV")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NgayBan")
                        .HasColumnType("TEXT");

                    b.Property<string>("TinhTrang")
                        .HasColumnType("TEXT");

                    b.HasKey("MaPBH");

                    b.HasIndex("MaKH");

                    b.HasIndex("MaNV");

                    b.ToTable("PhieuBH");
                });

            modelBuilder.Entity("BTLNhom11.Models.QueQuan", b =>
                {
                    b.Property<string>("MaQueQuan")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenQueQuan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaQueQuan");

                    b.ToTable("QueQuan");
                });

            modelBuilder.Entity("BTLNhom11.Models.TheLoai", b =>
                {
                    b.Property<string>("MaTheLoai")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenTheLoai")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaTheLoai");

                    b.ToTable("TheLoai");
                });

            modelBuilder.Entity("BTLNhom11.Models.KhachHang", b =>
                {
                    b.HasOne("BTLNhom11.Models.GioiTinh", "GioiTinh")
                        .WithMany()
                        .HasForeignKey("MaGioiTinh");

                    b.Navigation("GioiTinh");
                });

            modelBuilder.Entity("BTLNhom11.Models.NhanVien", b =>
                {
                    b.HasOne("BTLNhom11.Models.ChucVu", "ChucVu")
                        .WithMany()
                        .HasForeignKey("MaChucVu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTLNhom11.Models.GioiTinh", "GioiTinh")
                        .WithMany()
                        .HasForeignKey("MaGioiTinh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTLNhom11.Models.QueQuan", "QueQuan")
                        .WithMany()
                        .HasForeignKey("MaQueQuan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChucVu");

                    b.Navigation("GioiTinh");

                    b.Navigation("QueQuan");
                });

            modelBuilder.Entity("BTLNhom11.Models.PhieuBH", b =>
                {
                    b.HasOne("BTLNhom11.Models.KhachHang", "KhachHang")
                        .WithMany()
                        .HasForeignKey("MaKH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTLNhom11.Models.NhanVien", "NhanVien")
                        .WithMany()
                        .HasForeignKey("MaNV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");

                    b.Navigation("NhanVien");
                });
#pragma warning restore 612, 618
        }
    }
}
