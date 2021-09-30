using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.Model
{
    class Sach
    {
        [Key]
        public int SachId { get; set; }
        [Required, StringLength(255), Display(Name = "Tên sách")]
        public String TenSach { get; set; }
        [Required, StringLength(100), Display(Name = "Tác giả")]
        public String TacGia { get; set; }
        [StringLength(100), Display(Name = "Thể loại")]
        public String TheLoai { get; set; }
        [Display(Name = "Giá")]
        public decimal Gia { get; set; }
        [Display(Name = "Số lượng tồn kho")]
        public int SoLuongTonKho { get; set; }

        public int NhanVienId { get; set; }
        public virtual NhanVien Nv { get; set; }
    }
}
