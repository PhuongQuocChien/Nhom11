using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BTLNhom11.Models;
public class Kho
{
    [Key]
    [Display(Name = "Mã kho")]
    [StringLength(250)]
    [Required(ErrorMessage = "Phải nhập ")]
    public string? Makho { get; set; }


    [Display(Name = "Địa chỉ kho")]
    [StringLength(250)]
    [Required(ErrorMessage = "Phải nhập ")]
    public string? Dckho { get; set; }


}