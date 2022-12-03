using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaiTapNhom11.Models;

namespace BaiTapNhom11.Models
{
    public class KhachHang
    {
        [Key]
        [Required(ErrorMessage ="Mã khách hàng không được bỏ trống")] 
        [Display (Name ="Mã khách hàng")]

        public string? MaKhachHang { get; set; }
        [Required(ErrorMessage ="Tên khách hàng không được bỏ trống")] 
        [Display (Name ="Tên khách hàng")]
        public string? TenKhachHang { get; set; }
        [DisplayName("Giới Tính")]
        public string? MaGioiTinh {get; set;}
        [ForeignKey("MaGioiTinh")]
        [Display (Name ="Giới tính")]
        public GioiTinh? GioiTinh {get; set;}
        [Required(ErrorMessage ="SDT không được bỏ trống")] 
        [MinLength(10)]// do dai toi thieu la ba ki tu
        [MaxLength(13)]
        [Display (Name ="Số điện thoại")]
        public string? SDT{get; set;}
        [Required(ErrorMessage ="Mã thẻ không được bỏ trống")] 
        [Display (Name ="Màu thẻ")]
        public string? MaThe {get; set;}
        [ForeignKey("MaThe")]
        public TheKhachHang? TheKhachHang {get; set;}
        [Required(ErrorMessage ="Địa chỉ không được bỏ trống")] 
        [Display (Name ="Địa chỉ")]
        public string? DiaChi { get; set; }
        [Required(ErrorMessage ="Số chứng minh nhân dân không được bỏ trống")] 
        [Display (Name ="Chứng minh nhân dân")]
        [MinLength(10)]// do dai toi thieu la ba ki tu
         [MaxLength(13)]
        public string? CMND { get; set; }
    }
}