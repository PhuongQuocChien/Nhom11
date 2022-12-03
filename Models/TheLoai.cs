using System.ComponentModel.DataAnnotations;
namespace BaiTapNhom11.Models
{
    public class TheLoai
    {
        [Key]
        [Required(ErrorMessage ="Mã thể loại không được bỏ trống")]
        [Display (Name ="Mã thể loại")] 
        public string? MaTheLoai{get; set;}  
        [Required(ErrorMessage ="Tên thể loại không được bỏ trống")] 
        [Display (Name ="Tên loại thẻ")]
        public string? TenTheLoai {get; set;}
    }
}