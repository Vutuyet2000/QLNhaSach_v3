using QuanLyNhaSach.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyNhaSach.Dao
{
    class DAO_ChiTietHoaDon
    {

        ApplicationDBContext db;

        public DAO_ChiTietHoaDon()
        {
            db = new ApplicationDBContext();
        }

        public dynamic LayDSCTDH(int maDH)
        {
            // Tìm ds chi tiết đơn hàng bằng mã đơn hàng
            try
            {
                var ds = db.ChiTietHoaDon.Where(s => s.HoaDonId == maDH).Select(s => new
                {
                    s.HoaDonId,
                    s.s.TenSach,
                    s.DonGia,
                    s.SoLuong,
                }).ToList();
                return ds;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // THÊM CHI TIẾT ĐƠN HÀNG
        public bool ThemCTDH(ChiTietHoaDon order)
        {
            bool isThanhCong=false;
            try
            {
                db.ChiTietHoaDon.Add(order);
                db.SaveChanges();
                isThanhCong = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isThanhCong = false;
            }
            return isThanhCong;
        }


        public bool XoaCTDH(int maDH, int maSP)
        {
            bool isThanhCong;
            try
            {
                ChiTietHoaDon ds = db.ChiTietHoaDon.First(s => s.HoaDonId == maDH
                && s.SachId == maSP);
                db.ChiTietHoaDon.Remove(ds);
                db.SaveChanges();
                isThanhCong = true;
            }
            catch (Exception)
            {
                isThanhCong = false;
            }

            return isThanhCong;
        }

        public bool SuaCTDH(ChiTietHoaDon o)
        {
            bool isThanhCong;
            try
            {
                ChiTietHoaDon order = db.ChiTietHoaDon.First(s => s.HoaDonId == o.HoaDonId
                     && s.SachId == o.SachId);
                isThanhCong = true;
                order.DonGia = o.DonGia;

                order.SoLuong = o.SoLuong;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isThanhCong = false;
            }
            return isThanhCong;
        }
    }
}
