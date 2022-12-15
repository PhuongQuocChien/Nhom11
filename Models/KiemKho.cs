using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLNhom11.Models;
public class KiemKho
{
    [Key]
    [Display(Name = "Mã kiểm kho")]
    [StringLength(250)]
    [Required(ErrorMessage = "Phải nhập {0}")]
    public string MaKK { get; set; }

    [Display(Name = "Ngày kiểm kho")]
    [Required(ErrorMessage = "Phải nhập {0}")]
    public DateTime NgayKK { get; set; }


    [Display(Name = "Mã hàng hoá")]
    public string MaHH { get; set; }
    [ForeignKey("MaHH")]
    [Display(Name = "Mã hàng hoá")]
    public HangHoa? HangHoa { get; set; }


    [Display(Name = "Mã kho")]

    public string Makho { get; set; }
    [ForeignKey("Makho")]
    [Display(Name = "Mã kho")]
    public Kho? Kho { get; set; }



    [Display(Name = "Số lượng hàng còn trong kho")]
    [Phone(ErrorMessage = "Ghi số lượng ")]
    public string Sluongkk { get; set; }
}