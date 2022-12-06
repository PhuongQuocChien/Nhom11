using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BaiTapNhom11.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BaiTapNhom11.Models.KhoSach> KhoSach { get; set; } = default!;

        public DbSet<BaiTapNhom11.Models.ChucVu> ChucVu { get; set; } = default!;

        public DbSet<BaiTapNhom11.Models.TheLoai> TheLoai { get; set; } = default!;

        public DbSet<BaiTapNhom11.Models.Sach> Sach { get; set; } = default!;

        public DbSet<BaiTapNhom11.Models.GioiTinh> GioiTinh { get; set; } = default!;

        public DbSet<BaiTapNhom11.Models.QueQuan> QueQuan { get; set; } = default!;

        public DbSet<BaiTapNhom11.Models.HoaDonNhap> HoaDonNhap { get; set; } = default!;

        public DbSet<BaiTapNhom11.Models.NhanVien> NhanVien { get; set; } = default!;

        public DbSet<BaiTapNhom11.Models.TheKhachHang> TheKhachHang { get; set; } = default!;

        public DbSet<BaiTapNhom11.Models.KhachHang> KhachHang { get; set; } = default!;

        public DbSet<BaiTapNhom11.Models.HoaDonBanHang> HoaDonBanHang { get; set; } = default!;
    }
