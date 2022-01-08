using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyNhaSach.Dao;
using QuanLyNhaSach.Model;
using System.Windows.Forms;
using QuanLyNhaSach.DAO;

namespace QuanLyNhaSach.BUS
{
    class BUS_HoaDon
    {
        DAO_HoaDon dHD;
        DAO_NhanVien dNV;
        DAO_KhachHang dKH;
        DAO_ChiTietHoaDon daCTHD;
        public BUS_HoaDon()
        {
            dHD = new DAO_HoaDon();
            dNV = new DAO_NhanVien();
            dKH = new DAO_KhachHang();
        }

        public void HienThiDSHoaDon(DataGridView dg)
        {
            dg.DataSource = dHD.LayDSHoaDon();
        }

        //cap nhat thong tin hoa don
        public bool SuaTTHoaDon(HoaDon hd)
        {
            try
            {
                dHD.SuaTTHoaDon(hd);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public void LayDSKH(ComboBox cb)
        {
            cb.DataSource = dKH.LayDSKH();
            cb.DisplayMember = "HoTenKH";
            cb.ValueMember = "KhachHangId";

        }

        public void LayDSNV(ComboBox cb)
        {
            cb.DataSource = dNV.LayDSNhanVien();
            cb.DisplayMember = "HoTenNV";
            cb.ValueMember = "NhanVienId";
        }

        public bool ThemHD(HoaDon hd)
        {
            return dHD.ThemHoaDon(hd);
        }

        public bool ThemCTHD(ChiTietHoaDon dh)
        {
            daCTHD = new DAO_ChiTietHoaDon();
            return daCTHD.ThemCTDH(dh);
        }

        public void SuaHD(HoaDon o)
        {

            if (dHD.SuaTTHoaDon(o))
                MessageBox.Show("Sửa đơn hàng thành công", "Thông báo", MessageBoxButtons.OK);
            else
                MessageBox.Show("Sửa đơn hàng không thành công", "Thông báo", MessageBoxButtons.OK);

        }

        public void XoaHD(HoaDon order)
        {
            if (dHD.XoaHoaDon(order))
                MessageBox.Show("Xoá đơn hàng thành công", "Thông báo", MessageBoxButtons.OK);
            else
                MessageBox.Show("Xoá đơn hàng không thành công", "Thông báo", MessageBoxButtons.OK);

        }
    }
}