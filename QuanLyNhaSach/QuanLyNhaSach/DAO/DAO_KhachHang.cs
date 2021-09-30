using QuanLyNhaSach.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyNhaSach.Dao
{
    class DAO_KhachHang
    {
        ApplicationDBContext db;
        public DAO_KhachHang()
        {
            db = new ApplicationDBContext();
        }


        public dynamic LayDSKH()
        {
            try
            {
                var ds = db.KhachHang.Select(kh => new
                {
                    kh.KhachHangId,
                    kh.HoTenKH
                }).ToList();
                return ds;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public void ThemKhachHang(KhachHang kh)
        {
            db.KhachHang.Add(kh);
            db.SaveChanges();
        }


        public void SuaTTKhachHang(KhachHang kh)
        {
            var KHDaTao = db.KhachHang.First(n => n.KhachHangId == kh.KhachHangId);

            KHDaTao.HoTenKH = kh.HoTenKH;
            KHDaTao.Sdt = kh.Sdt;
            KHDaTao.DiaChi = kh.DiaChi;

            db.SaveChanges();
        }

        public void XoaTTKhachHang(KhachHang kh)
        {
            var KHDaTao = db.KhachHang.First(n => n.KhachHangId == kh.KhachHangId);

            db.KhachHang.Remove(KHDaTao);
            db.SaveChanges();
        }

       
    }
}

