using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.Model
{
    class NhanVien
    {
        [Key]
        public int NhanVienId { get; set; }
        [Required, StringLength(100), Display(Name = "Họ tên")]
        public String HoTenNV { get; set; }
        [Required, StringLength(11), Display(Name = "Số điện thoại")]
        public String Sdt { get; set; }
        [StringLength(255), Display(Name = "Địa chỉ")]
        public String DiaChi { get; set; }
        [Required, StringLength(50), Display(Name = "Chức vụ")]
        public String ChucVu { get; set; }
        [Required, Display(Name = "Tình trạng")]
        public Boolean TinhTrang { get; set; }
    }
}
