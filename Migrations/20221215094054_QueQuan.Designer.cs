﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTLNhom11.Migrations
{
    [DbContext(typeof(MvcMovieContext))]
    [Migration("20221215094054_QueQuan")]
    partial class QueQuan
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

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
#pragma warning restore 612, 618
        }
    }
}
