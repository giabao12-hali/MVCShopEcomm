using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASM.Models
{
    public enum TrangthaiDonhang
    {
        [Display(Name = "Mới đặt")]
        Moidat = 1,
        [Display(Name = "Đang giao")]
        Danggiao = 2,
        [Display(Name = "Đã giao")]
        Dagiao = 3
    }
    public class Donhang
    {
            [Key]
            public int DonhangID { get; set; }

            [ForeignKey("Khachhang")]
            public int KhachhangID { get; set; }

            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            [Required(ErrorMessage = "Bạn cần chọn ngày."), Display(Name = "Ngày đặt")]
            public DateTime Ngaydat { get; set; }

            [Required, Range(0, double.MaxValue, ErrorMessage = "Bạn cần nhập giá.")]
            [Display(Name = "Tổng tiền")]
            public double Tongtien { get; set; }

            [Display(Name = "Trạng thái")]
            public TrangthaiDonhang TrangthaiDonhang { get; set; }

            [StringLength(250)]
            [Display(Name = "Ghi chú")]
            public string Ghichu { get; set; }

            public Khachhang Khachhang { get; set; }

            public List<DonhangChitiet> DonhangChitiets { get; set; }
        }
    }
