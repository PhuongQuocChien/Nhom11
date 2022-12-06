using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTapNhom11.Models
{
    public class HoaDonBanHang
    {
        [Key]
        [Required(ErrorMessage ="Mã hóa đơn  không được bỏ trống")] 
        [Display (Name ="Mã hóa đơn")]
        public string? MaHoaDon{get; set;}  
        [Display (Name ="Khách Hàng")]
        public string? MaKhachHang {get; set;}
        [ForeignKey("MaKhachHang")]
        public KhachHang? KhachHang {get; set;}
        [Display (Name ="Sách")]
        public string? MaSach {get; set;}
        [ForeignKey("MaSach")]
        public Sach? Sach {get; set;}
        [Display (Name ="Nhân viên phụ trách")]
        public string? MaNhanVien {get; set;}
        [ForeignKey("MaNhanVien")]
        public NhanVien? NhanVien {get; set;}
        [Display (Name ="Ngày lập hóa đơn")]
        [DataType(DataType.Date)]
        public DateTime? NgayLapHoaDon {get; set;}
        [Display (Name ="Tổng tiền")]
        [Required(ErrorMessage ="Hãy nhập vào số tiền")]
        public int? TongTien {get; set;}
    }
}