using QuanLyNhaSach.Dao;
using QuanLyNhaSach.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach.BUS
{
    class BUS_ChiTietHD
    {

        DAO_ChiTietHoaDon da;
        DAO.DAO_Sach dSach;
        public BUS_ChiTietHD()
        {
            da = new DAO_ChiTietHoaDon();
            dSach = new DAO.DAO_Sach();
        }
        // LẤY DANH SÁCH CHI TIẾT ĐƠN HÀNG THEO MÃ ĐƠN HÀNG
        public void LayDSCTDH(DataGridView data, int ma)
        {
            try
            {
                data.DataSource = da.LayDSCTDH(ma);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Cảnh báo", MessageBoxButtons.OK);
            }
        }

        // THÊM CHI TIẾT ĐƠN HÀNG
        public bool ThemCTDH(ChiTietHoaDon o)
        {
           return da.ThemCTDH(o);
             
        }

        // XOÁ CHI TIẾT ĐƠN HÀNG THEO MÃ ĐƠN HÀNG VÀ MÃ SẢN PHÂM
        public void XoaCTDH(int maDH, int maSP)
        {
            if (da.XoaCTDH(maDH, maSP))
                MessageBox.Show("Xoá chi tiết đơn hàng thành công", "Thông báo", MessageBoxButtons.OK);
            else
                MessageBox.Show("Xoá chi tiết đơn hàng không thành công", "Thông báo", MessageBoxButtons.OK);

        }

        // SỬA CHI TIẾT ĐƠN HÀNG
        public void SuaCTDH(ChiTietHoaDon o)
        {
            if (da.SuaCTDH(o))
                MessageBox.Show("Sửa chi tiết đơn hàng thành công", "Thông báo", MessageBoxButtons.OK);
            else
                MessageBox.Show("Sửa chi tiết đơn hàng không thành công", "Thông báo", MessageBoxButtons.OK);
        }

        
    }
}
