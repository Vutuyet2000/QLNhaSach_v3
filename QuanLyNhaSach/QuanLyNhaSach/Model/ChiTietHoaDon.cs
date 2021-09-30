using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhaSach.Model
{
    class ChiTietHoaDon
    {
        [Key]
        public int ChiTietHoaDonId { get; set; }
        [Display(Name = "Đơn giá")]
        public decimal DonGia { get; set; }
        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }

        [Required, Display(Name = "Mã hoá đơn")]
        public int HoaDonId { get; set; }
        public virtual HoaDon Hd { get; set; }

        [Required, Display(Name = "Tên sách")]
        public int SachId { get; set; }
        public virtual Sach s { get; set; }
    }
}
