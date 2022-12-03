using System.ComponentModel.DataAnnotations;
namespace BaiTapNhom11.Models
{
    public class HoaDonNhap
    {
        [Key]
        [Required(ErrorMessage ="Mã hóa đơn không được bỏ trống")]
        [Display (Name ="Mã hóa đơn")]
        public string? MaHoaDonNhap{get; set;}  
        [Required(ErrorMessage ="Tên hóa đơn không được bỏ trống")]
        [Display (Name ="Tên hóa đơn")]
        public string? TenHoaDonNhap {get; set;}
        [Required(ErrorMessage ="Tên Nhà cung cấp không được bỏ trống")]
        [Display (Name ="Nhà cung cấp")]
        public string? NhaCungCap {get; set;}
        [Required(ErrorMessage ="Tên vật phẩm cấp không được bỏ trống")]
        [Display (Name ="Tên vật vật")]
        public string? TenVatPham {get; set;}
        [MinLength(5)]// do dai toi thieu la ba ki tu
        [Display (Name ="Số lượng")]
        public string? SoLuong {get; set;}
        [MinLength(1)]// do dai toi thieu la ba ki tu
        [Display (Name ="Tổng tiền")]
        public string? TongTien {get; set;}
        [DataType(DataType.Date)]
        [Display (Name ="Ngày nhập")]
        public DateTime? NgayNhap {get; set;}
    }
}