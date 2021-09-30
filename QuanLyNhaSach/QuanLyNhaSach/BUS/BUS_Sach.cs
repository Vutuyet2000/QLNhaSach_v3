using QuanLyNhaSach.DAO;
using QuanLyNhaSach.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach.BUS
{
    class BUS_Sach
    {
        DAO_Sach dSach;
        DAO_NhanVien dNV;
        public BUS_Sach()
        {
            dSach = new DAO_Sach();
            dNV = new DAO_NhanVien();
        }
        public void HienThiDSNVLenCb(ComboBox cb)
        {
            cb.DataSource = dNV.LayDSNhanVien();
            cb.DisplayMember = "HoTenNV";
            cb.ValueMember = "NhanVienId";
        }
        public bool TaoSach(Sach s)
        {
            try
            {
                dSach.ThemSach(s);
                return true;
            }
            catch (Exception)
            {
                return false;
               
            }

        }
        public void HienThiDSSachLenDG(DataGridView dg)
        {
            dg.DataSource = dSach.LayDSSach();
        }
        public bool SuaSach(Sach s)
        {
            if (dSach.KiemTraSach(s))
            {
                try
                {
                    dSach.SuaSach(s);
                    return true;
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        public bool XoaSach(Sach s)
        {
            if (dSach.KiemTraSach(s))
            {
                try
                {
                    dSach.XoaSach(s);
                    return true;
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
