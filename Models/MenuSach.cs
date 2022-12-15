using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BTLNhom11.Models;

namespace BTLNhom11.Models
{
    public class MenuSach
    {
        [Key]
        [Required(ErrorMessage ="Mã sách không được bỏ trống")] 
        [Display (Name ="Mã sách")]
        public string? MaSach { get; set; }
        [Required(ErrorMessage ="Tên sách không được bỏ trống")] 
        [Display (Name ="Tên sách")]
        public string? MaNhap { get; set; }
        [ForeignKey("MaNhap")]
        public NhapSach? NhapSach {get; set;}

        [Required(ErrorMessage ="Hãy chọn thể loại không được bỏ trống")] 
        [Display (Name ="Mã Thể loại")]
        public string? MaTheLoai {get; set;}
        [ForeignKey("MaTheLoai")]
        public TheLoai? TheLoai {get; set;}
        [DataType(DataType.Date)]
        public string? TacGia { get; set; }
        [Required(ErrorMessage ="Xin hãy nhập giá tiền ")] 
        [Display (Name ="Gía tiền")]
        public string? GiaTien { get; set; }
    }
}