using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyNhaSach.Model;
using System.Windows.Forms;
using System.Windows;
namespace QuanLyNhaSach.Dao
{
    class DAO_HoaDon
    {
        ApplicationDBContext db;

        public DAO_HoaDon()
        {
            db = new ApplicationDBContext();
        }

        //lay ds hoa don
        public dynamic LayDSHoaDon()
        {
            return db.HoaDon.Select(hd => new
            {
                hd.nv.HoTenNV,
                hd.Kh.HoTenKH,
                hd.NgayLapHoaDon,
                hd.HoaDonId
            }).ToList();
        }

        //them hoa don
        public bool ThemHoaDon(HoaDon nv)
        {
            db.HoaDon.Add(nv);
            return db.SaveChanges() > 0;
        }

        //update nhan vien
        public bool SuaTTHoaDon(HoaDon hd)
        {
            var HDDaTao = db.HoaDon.First(n => n.HoaDonId == hd.HoaDonId);
            HDDaTao.NgayLapHoaDon = hd.NgayLapHoaDon;
            HDDaTao.NhanVienId = hd.NhanVienId;
            HDDaTao.KhachHangId = hd.KhachHangId;

            return db.SaveChanges() > 0;
        }

        public bool XoaHoaDon(HoaDon hd)
        {
            bool tinhTrang = false;
            try
            {
                tinhTrang = true;
                //1. Tìm đơn hàng cần xoá 

                HoaDon hoaDon = db.HoaDon.Find(hd.HoaDonId);


                //2. Tìm ds chi tiết đơn hàng muốn xoá
                List<ChiTietHoaDon> dsCT = db.ChiTietHoaDon
                    .Where(ct => ct.HoaDonId == hoaDon.HoaDonId)
                    .Select(x => x).ToList();

                //3.Xoá chi tiết đơn hàng của đơn hàng đó
                if (dsCT != null)
                {
                    dsCT.ForEach(s => db.ChiTietHoaDon.Remove(s));
                  
                    db.SaveChanges();
                }

                //4. Xoá đơn hàng
                db.HoaDon.Remove(hoaDon);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                tinhTrang = false;
            }
            return tinhTrang;
        }


       
    }
}
