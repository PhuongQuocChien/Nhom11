using System.ComponentModel.DataAnnotations;
namespace BTLNhom11.Models
{
    public class GioiTinh
    {
        [Key]
        [Required(ErrorMessage ="Mã giới tính  không được bỏ trống")] 
        [Display (Name ="Mã giới tính")]
        public string? MaGioiTinh{get; set;}  
        [Required(ErrorMessage ="Tên chức vụ cấp không được bỏ trống")]
        [Display (Name ="Tên chức vụ")]  
        public string? TenGioiTinh {get; set;}
    }
}