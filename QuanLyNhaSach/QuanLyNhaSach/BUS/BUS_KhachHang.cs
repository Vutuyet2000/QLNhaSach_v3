using QuanLyNhaSach.Dao;
using QuanLyNhaSach.Model;
using System;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach.Bus
{
    class Bus_KhachHang
    {
        DAO_KhachHang dKH;

        public int KhachHangId { get; internal set; }
        public String HoTenKH { get; internal set; }
        public String Sdt { get; internal set; }
        public String DiaChi { get; internal set; }

        public Bus_KhachHang()
        {
            dKH = new DAO_KhachHang();
        }

        public void HienThiDSKhachHang(DataGridView dg)
        {
            dg.DataSource = dKH.LayDSKH();
        }

        public bool ThemKhachHang(KhachHang kh)
        {
            try
            {
                dKH.ThemKhachHang(kh);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SuaTTKhachHang(KhachHang kh)
        {
            try
            {
                dKH.SuaTTKhachHang(kh);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool XoaTTKhachHang(KhachHang kh)
        {
            try
            {
                dKH.XoaTTKhachHang(kh);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
