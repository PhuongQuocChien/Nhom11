using System.ComponentModel.DataAnnotations;
namespace BTLNhom11.Models;
public class NhaCungCap
{
    [Key]
    [Display(Name = "Mã Nhà cung cấp")]

    [Required(ErrorMessage = "Phải nhập {0}")]
    public string? Mancc { get; set; }

    [Display(Name = "Tên ncc")]
    [Required(ErrorMessage = "Phải nhập {0}")]
    public string? Tenncc { get; set; }

    [Display(Name = "Địa chỉ")]
    [Required(ErrorMessage = "Phải nhập {0}")]
    public string? Diachincc { get; set; }


    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Số điện thoại")]
    [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                       ErrorMessage = "Phải nhập {0}")]
    // [Phone(ErrorMessage = "Phải là Số điện thoại")]
    // [Display(Name = "Số điện thoại")]
    // [MinLength(9)]
    // [MaxLength(11)]
    public string? Sdtncc { get; set; }


    [EmailAddress(ErrorMessage = "Phải là địa chỉ email")]
    [Display(Name = "Email")]
    public string? Emailncc { get; set; }


    [Display(Name = "Ngày kí hợp đồng")]
    [DataType(DataType.Date)]
    public DateTime ngayncc { get; set; }





}