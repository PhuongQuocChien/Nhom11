using System.ComponentModel.DataAnnotations;
namespace BaiTapNhom11.Models
{
    public class QueQuan
    {
        [Key]
        [Required(ErrorMessage ="Mã quê quán không được bỏ trống")] 
        [Display (Name ="Mã quê quán")]
        public string? MaQueQuan{get; set;}  
        [Required(ErrorMessage ="tên quê quán không được bỏ trống")] 
        [Display (Name ="Tên quê quán")]
        public string? TenQueQuan {get; set;}
    }
}