﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTLNhom11.Migrations
{
    [DbContext(typeof(MvcMovieContext))]
    [Migration("20221215133239_KhachHang")]
    partial class KhachHang
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
#pragma warning restore 612, 618
        }
    }
}