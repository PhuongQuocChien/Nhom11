using System.ComponentModel.DataAnnotations;
namespace BTLNhom11.Models
{
    public class ChucVu
    {
        [Key]
        [Display (Name ="Mã chức vụ")]
        [Required(ErrorMessage ="Mã chức vụ  không được bỏ trống")]
        public string? MaChucVu{get; set;} 
        [Required(ErrorMessage ="Tên chức vụ Không được bỏ trống")] 
        [Display (Name ="Tên chức vụ")]
        public string? TenChucVu {get; set;}
    }
}
