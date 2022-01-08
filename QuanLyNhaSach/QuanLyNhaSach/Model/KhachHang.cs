using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.Model
{
    class KhachHang
    {
        [Key]
        public int KhachHangId { get; set; }
        [Required, StringLength(100), Display(Name = "Họ tên")]
        public String HoTenKH { get; set; }
        [Required, StringLength(11), Display(Name = "Số điện thoại")]
        public String Sdt { get; set; }
        [StringLength(255), Display(Name = "Địa chỉ")]
        public String DiaChi { get; set; }
    }
}
