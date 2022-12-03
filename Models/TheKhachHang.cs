using System.ComponentModel.DataAnnotations;
namespace BaiTapNhom11.Models
{
    public class TheKhachHang
    {
        [Key]
        [Required(ErrorMessage ="Mã Thẻ không được bỏ trống")] 
        [Display (Name ="Mã thẻ")]
        public string? MaThe{get; set;}  
        [Required(ErrorMessage ="Màu thẻ không được bỏ trống")] 
        [Display (Name ="Màu thẻ")]
        public string? MauThe{get; set;}
    }
}