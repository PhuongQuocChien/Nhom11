using System.ComponentModel.DataAnnotations;
namespace BaiTapNhom11.Models
{
    public class KhoSach
    {
        [Key]
        [Required(ErrorMessage ="Tên sách không được bỏ trống")] 
        [Display (Name ="Tên sách")]
        public string? TenSach {get; set;}
        [DataType(DataType.Date)]
        [Display (Name ="Ngày nhập")]
        public DateTime? NgayNhap {get; set;}
        [MinLength(1)]// do dai toi thieu la ba ki tu
        [Display (Name ="Đã bán")]
        public string? DaBan {get; set;}
        [MinLength(1)]// do dai toi thieu la ba ki tu
        [Display (Name ="Còn lại")]
        public string? ConLai {get; set;}
    }
}