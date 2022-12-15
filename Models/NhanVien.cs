using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BTLNhom11.Models;

namespace BTLNhom11.Models
{
    public class NhanVien
    {
        [Key]
        [Required(ErrorMessage ="Mã nhân viên không được bỏ trống")] 
        [Display (Name ="Mã nhân viên")]
        public string? MaNV { get; set; }
        [Required(ErrorMessage ="Tên nhân viên không được bỏ trống")] 
        [Display (Name ="Họ và tên")]
        public string? TenNV { get; set; }
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
         [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                       ErrorMessage = "Phải nhập {0}")]
        [Display(Name ="Số điện thoại")]
        public string? SDTNV { get; set; }
    }
}