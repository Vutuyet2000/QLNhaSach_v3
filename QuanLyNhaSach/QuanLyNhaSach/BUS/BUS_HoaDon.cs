using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyNhaSach.Dao;
using QuanLyNhaSach.Model;
using System.Windows.Forms;
using QuanLyNhaSach.DAO;

namespace QuanLyNhaSach.Bus
{
    class BUS_HoaDon
    {
        DAO_HoaDon dHD;
        DAO_NhanVien dNV;
        public BUS_HoaDon()
        {
            dHD = new DAO_HoaDon();
            dNV = new DAO_NhanVien();
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

        //public void LayDSKH(ComboBox cb)
        //{
        //    cb.DataSource = dHD.LayDSKH();
        //    cb.DisplayMember = "CompanyName";
        //    cb.ValueMember = "CustomerID";

        //}

        public void LayDSNV(ComboBox cb)
        {
            cb.DataSource = dNV.LayDSNhanVien();
            cb.DisplayMember = "LastName";
            cb.ValueMember = "EmployeeID";
        }

        public void ThemHD(HoaDon hd)
        {
            if (dHD.ThemHoaDon(hd))
                MessageBox.Show("Thêm hoá đơn thành công", "Thông báo", MessageBoxButtons.OK);
            else
                MessageBox.Show("Thêm hoá đơn không thành công", "Thông báo", MessageBoxButtons.OK);

        }

        //public bool ThemCTDH(ChiTietHoaDon dh)
        //{
        //    daCTDH = new DAO_ChiTietDonHang();
        //    return daCTDH.ThemCTDH(dh);
        //}

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
