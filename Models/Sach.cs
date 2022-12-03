using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaiTapNhom11.Models;

namespace BaiTapNhom11.Models
{
    public class Sach
    {
        [Key]
        [Required(ErrorMessage ="Mã sách không được bỏ trống")] 
        [Display (Name ="Mã sách")]
        public string? MaSach { get; set; }
        [Required(ErrorMessage ="Tên sách không được bỏ trống")] 
        [Display (Name ="Tên sách")]
        public string? TenSach { get; set; }
        [ForeignKey("TenSach")]
        [Display (Name ="Kho sách")]
        public KhoSach? KhoSach {get; set;}

        [Required(ErrorMessage ="Hãy chọn thể loại không được bỏ trống")] 
        [Display (Name ="Mã Thể loại")]
        public string? MaTheLoai {get; set;}
        [ForeignKey("MaTheLoai")]
        public TheLoai? TheLoai {get; set;}
        [DataType(DataType.Date)]
        [Display (Name ="Năm xuất bản")]
        public DateTime? NamXuatBan {get; set;}
        [Required(ErrorMessage ="Tác giả không được bỏ trống")] 
        [Display (Name ="Tên tác giả")]
        public string? TacGia { get; set; }
        [Required(ErrorMessage ="Xin hãy nhập giá tiền ")] 
        [Display (Name ="Gía tiền")]
        public string? GiaTien { get; set; }
    }
}