using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhaSach.Model
{
    class HoaDon
    {
        [Key]
        public int HoaDonId { get; set; }
        [Display(Name = "Ngày lập hóa đơn")]
        public DateTime NgayLapHoaDon { get; set; }

        [Required, Display(Name = "Khách hàng")]
        public int KhachHangId { get; set; }
        public virtual KhachHang Kh { get; set; }

        [Required, Display(Name = "Nhân viên")]
        public int NhanVienId { get; set; }
        public virtual NhanVien nv { get; set; }


    }
}
