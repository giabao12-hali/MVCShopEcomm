using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM.Models
{

    public enum PhanLoai
    {
        [Display(Name = "Món")]
        Monan = 1,
        [Display(Name = "Combo")]
        Combo = 2,
        [Display(Name = "Nước")]
        Nuoc = 3,
    }
    public class MonAn
    {
        [Key]
        public int MonAnId { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Bạn cần nhập tên.")]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập giá."), Range(0, double.MaxValue, ErrorMessage = "Bạn cần nhập giá.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public double Gia { get; set; }

        [Display(Name = "Phân loại")]
        [Required(ErrorMessage = "Bạn cần chọn phân loại."), Range(0, int.MaxValue, ErrorMessage = "Bạn cần chọn phân loại.")]
        public PhanLoai PhanLoai { get; set; }

        [StringLength(100)]
        [Display(Name = "Hình")]
        public string Hinh { get; set; }

        [NotMapped]
        [Display(Name = "Chọn hình")]
        public IFormFile? ImageFile { get; set; }

        [StringLength(250)]
        [Display(Name = "Mô tả")]
        public string Mota { get; set; }

        [Display(Name = "Đang phục vụ")]
        public bool Trangthai { get; set; }
    }
}
