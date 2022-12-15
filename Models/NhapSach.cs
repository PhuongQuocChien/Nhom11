using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BTLNhom11.Models;
public class NhapSach
{
    [Key]
    [Display(Name = "Mã nhập hàng")]
    public string MaNhap { get; set; }
    [Display(Name = "Tên sách")]
    public string MaHH { get; set; }
    [ForeignKey("MaHH")]
    [Display(Name = "Mã hàng hóa")]
    public HangHoa? HangHoa { get; set; }


    [Display(Name = "Mã nhà cung cấp")]
    public string Mancc { get; set; }
    [ForeignKey("Mancc")]
    [Display(Name = "Mã nhà cung cấp")]
    public NhaCungCap? NhaCungCap { get; set; }

    [Display(Name = "Mã kho")]
    public string Makho { get; set; }
    [ForeignKey("Makho")]
    [Display(Name = "Mã kho")]
    public Kho? Kho { get; set; }


    [Display(Name = "Số lượng nhập hàng")]
    [Phone(ErrorMessage = "Ghi số lượng ")]
    public string SoluongNhap { get; set; }



    [Display(Name = "Ngày nhập hàng")]
    public DateTime ngayNhap { get; set; }


}