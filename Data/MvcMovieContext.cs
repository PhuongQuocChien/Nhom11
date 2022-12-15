using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BTLNhom11.Models;

    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<BTLNhom11.Models.TheLoai> TheLoai { get; set; } = default!;

        public DbSet<BTLNhom11.Models.QueQuan> QueQuan { get; set; } = default!;

        public DbSet<BTLNhom11.Models.ChucVu> ChucVu { get; set; } = default!;

        public DbSet<BTLNhom11.Models.GioiTinh> GioiTinh { get; set; } = default!;

        public DbSet<BTLNhom11.Models.KhachHang> KhachHang { get; set; } = default!;

        public DbSet<BTLNhom11.Models.NhanVien> NhanVien { get; set; } = default!;

        public DbSet<BTLNhom11.Models.HangHoa> HangHoa { get; set; } = default!;

        public DbSet<BTLNhom11.Models.Kho> Kho { get; set; } = default!;

        public DbSet<BTLNhom11.Models.NhaCungCap> NhaCungCap { get; set; } = default!;

        public DbSet<BTLNhom11.Models.PhieuBH> PhieuBH { get; set; } = default!;

        public DbSet<BTLNhom11.Models.NhapSach> NhapSach { get; set; } = default!;

        public DbSet<BTLNhom11.Models.MenuSach> MenuSach { get; set; } = default!;

        public DbSet<BTLNhom11.Models.KiemKho> KiemKho { get; set; } = default!;
    }
