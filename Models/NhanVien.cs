using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaiTapNhom11.Models;

namespace BaiTapNhom11.Models
{
    public class NhanVien
    {
        [Key]
        [Required(ErrorMessage ="Mã nhân viên không được bỏ trống")] 
        [Display (Name ="Mã nhân viên")]
        public string? MaNhanVien { get; set; }
        [Required(ErrorMessage ="Tên nhân viên không được bỏ trống")] 
        [Display (Name ="Họ và tên")]
        public string? HoVaTen { get; set; }
        [Display (Name ="Ngày sinh")]
        public DateTime? NgaySinh{get; set;}
        [Required(ErrorMessage ="Quê Quán không được bỏ trống")]
        [Display (Name ="Mã quê quán")] 
        public string? MaQueQuan {get; set;}
        [ForeignKey("MaQueQuan")]
        public QueQuan? QueQuan {get; set;}
        [Required(ErrorMessage ="giới tính không được bỏ trống")] 
        [Display (Name ="Mã giới tính")]
        public string? MaGioiTinh {get; set;}
        [ForeignKey("MaGioiTinh")]
        public GioiTinh? GioiTinh {get; set;}
        [Required(ErrorMessage ="Chức vụ không được bỏ trống")] 
        [Display (Name ="Chức vụ")]
        public string? MaChucVu {get; set;}
        [ForeignKey("MaChucVu")]
        public ChucVu? ChucVu {get; set;}
        [Required(ErrorMessage ="Chứng minh nhân dân không được bỏ trống")] 
        [Display (Name ="Số chứng minh nhân dân")]
        [MinLength(10)]// do dai toi thieu la ba ki tu
        [MaxLength(13)]
        public string? SoCMND { get; set; }
    
        [MinLength(10)]// do dai toi thieu la ba ki tu
         [MaxLength(12)]
        [Display (Name ="Số điện thoại")]

        public string? SDT { get; set; }
    }
}
