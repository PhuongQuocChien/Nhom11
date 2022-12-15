using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BTLNhom11.Models;
public class HangHoa
{
    [Key]
    [Display(Name = "Mã hàng")]
    [Required(ErrorMessage = "Phải nhập ")]

    [StringLength(250)]
    public string? MaHH { get; set; }


    [Display(Name = "Tên hàng hoá")]
    [Required(ErrorMessage = "Phải nhập ")]

    [StringLength(250)]
    public string? TenHH { get; set; }

    [Display(Name = "Giá vốn")]
    [Required(ErrorMessage = "Phải nhập {0}")]
    public decimal GiaVonHH  { get; set; }

    [Display(Name = "Giá bán")]
    [Required(ErrorMessage = "Phải nhập {0}")]
    public decimal GiaBanHH { get; set; }


}