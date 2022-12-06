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
    [Migration("20221205101606_HoaDonBanHang")]
    partial class HoaDonBanHang
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

            modelBuilder.Entity("BaiTapNhom11.Models.HoaDonBanHang", b =>
                {
                    b.Property<string>("MaHoaDon")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaKhachHang")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaNhanVien")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaSach")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("NgayLapHoaDon")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TongTien")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("MaHoaDon");

                    b.HasIndex("MaKhachHang");

                    b.HasIndex("MaNhanVien");

                    b.HasIndex("MaSach");

                    b.ToTable("HoaDonBanHang");
                });

            modelBuilder.Entity("BaiTapNhom11.Models.HoaDonNhap", b =>
                {
                    b.Property<string>("MaHoaDonNhap")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("NgayNhap")
                        .HasColumnType("TEXT");

                    b.Property<string>("NhaCungCap")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SoLuong")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenHoaDonNhap")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenVatPham")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TongTien")
                        .HasColumnType("TEXT");

                    b.HasKey("MaHoaDonNhap");

                    b.ToTable("HoaDonNhap");
                });

            modelBuilder.Entity("BaiTapNhom11.Models.KhachHang", b =>
                {
                    b.Property<string>("MaKhachHang")
                        .HasColumnType("TEXT");

                    b.Property<string>("CMND")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("TEXT");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaGioiTinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaThe")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("TEXT");

                    b.Property<string>("TenKhachHang")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaKhachHang");

                    b.HasIndex("MaGioiTinh");

                    b.HasIndex("MaThe");

                    b.ToTable("KhachHang");
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

            modelBuilder.Entity("BaiTapNhom11.Models.NhanVien", b =>
                {
                    b.Property<string>("MaNhanVien")
                        .HasColumnType("TEXT");

                    b.Property<string>("HoVaTen")
                        .IsRequired()
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

                    b.Property<string>("SDT")
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.Property<string>("SoCMND")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("TEXT");

                    b.HasKey("MaNhanVien");

                    b.HasIndex("MaChucVu");

                    b.HasIndex("MaGioiTinh");

                    b.HasIndex("MaQueQuan");

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("BaiTapNhom11.Models.QueQuan", b =>
                {
                    b.Property<string>("MaQueQuan")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenQueQuan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaQueQuan");

                    b.ToTable("QueQuan");
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

            modelBuilder.Entity("BaiTapNhom11.Models.TheKhachHang", b =>
                {
                    b.Property<string>("MaThe")
                        .HasColumnType("TEXT");

                    b.Property<string>("MauThe")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaThe");

                    b.ToTable("TheKhachHang");
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

            modelBuilder.Entity("BaiTapNhom11.Models.HoaDonBanHang", b =>
                {
                    b.HasOne("BaiTapNhom11.Models.KhachHang", "KhachHang")
                        .WithMany()
                        .HasForeignKey("MaKhachHang");

                    b.HasOne("BaiTapNhom11.Models.NhanVien", "NhanVien")
                        .WithMany()
                        .HasForeignKey("MaNhanVien");

                    b.HasOne("BaiTapNhom11.Models.Sach", "Sach")
                        .WithMany()
                        .HasForeignKey("MaSach");

                    b.Navigation("KhachHang");

                    b.Navigation("NhanVien");

                    b.Navigation("Sach");
                });

            modelBuilder.Entity("BaiTapNhom11.Models.KhachHang", b =>
                {
                    b.HasOne("BaiTapNhom11.Models.GioiTinh", "GioiTinh")
                        .WithMany()
                        .HasForeignKey("MaGioiTinh");

                    b.HasOne("BaiTapNhom11.Models.TheKhachHang", "TheKhachHang")
                        .WithMany()
                        .HasForeignKey("MaThe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GioiTinh");

                    b.Navigation("TheKhachHang");
                });

            modelBuilder.Entity("BaiTapNhom11.Models.NhanVien", b =>
                {
                    b.HasOne("BaiTapNhom11.Models.ChucVu", "ChucVu")
                        .WithMany()
                        .HasForeignKey("MaChucVu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BaiTapNhom11.Models.GioiTinh", "GioiTinh")
                        .WithMany()
                        .HasForeignKey("MaGioiTinh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BaiTapNhom11.Models.QueQuan", "QueQuan")
                        .WithMany()
                        .HasForeignKey("MaQueQuan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChucVu");

                    b.Navigation("GioiTinh");

                    b.Navigation("QueQuan");
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