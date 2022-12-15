using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BTLNhom11.Models;

namespace BTLNhom11.Models
{
    public class KhachHang
    {
        [Key]
        [Required(ErrorMessage ="Mã khách hàng không được bỏ trống")] 
        [Display (Name ="Mã khách hàng")]

        public string? MaKH { get; set; }
        [Required(ErrorMessage ="Tên khách hàng không được bỏ trống")] 
        [Display (Name ="Tên khách hàng")]
        public string? TenKH { get; set; }
        [DisplayName("Giới Tính")]
        public string? MaGioiTinh {get; set;}
        [ForeignKey("MaGioiTinh")]
        [Display (Name ="Giới tính")]
        public GioiTinh? GioiTinh {get; set;}
        [Required(ErrorMessage ="SDT không được bỏ trống")] 
         [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                       ErrorMessage = "Phải nhập {0}")]
        [Display(Name ="Số điện thoại")]
        public string? SDTKH{get; set;}
        
        
        [Required(ErrorMessage ="Địa chỉ không được bỏ trống")] 
        [Display (Name ="Địa chỉ")]
        public string? DiaChi { get; set; }
    }
}