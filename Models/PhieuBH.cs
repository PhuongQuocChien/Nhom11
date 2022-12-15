using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BTLNhom11.Models;

namespace BTLNhom11.Models
{
    public class PhieuBH
    {
        [Key]
        [Required(ErrorMessage ="Mã Phiếu không được bỏ trống")] 
        [Display (Name ="Mã Phiếu Bán Hàng")]

        public string? MaPBH { get; set; }
        [Required(ErrorMessage ="Tên khách hàng không được bỏ trống")] 
        [Display (Name ="Tên khách hàng")]
        public string? MaKH { get; set; }
        [ForeignKey("MaKH")]
        public KhachHang? KhachHang {get; set;}

        [Required(ErrorMessage ="Nhân viên không được bỏ trống")] 
        [Display (Name ="Nhân Viên")]
        public string? MaNV {get; set;}
        [ForeignKey("MaNV")]
        public NhanVien? NhanVien {get; set;}

        [Display(Name = "Ngày bán hàng")]
        public DateTime NgayBan { get; set; }



       [Display(Name = "Tình trạng phiếu bán")]
       public string? TinhTrang { get; set; }

    }
}