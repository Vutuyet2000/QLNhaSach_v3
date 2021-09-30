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
        public BUS_Sach()
        {
            dSach = new DAO_Sach();
        }
        public void HienThiDSNVLenCb(ComboBox cb)
        {
            cb.DataSource = dSach.LayDSNV();
            cb.DisplayMember = "HoTenNV";
            cb.ValueMember = "NhanVienId";
        }
        public void TaoSach(Sach s)
        {
            try
            {
                dSach.ThemSach(s);
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại");
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

        public void LayDanhSachSach(ComboBox cb)
        {
            cb.DataSource = dSach.LayDSSach();
            cb.DisplayMember = "TenSach";
            cb.ValueMember = "SachId";
        }

        public void Lay1SP(ComboBox cb, int ma)
        {
            dSach.NapCBDSSP(cb, ma);
        }

        public void LayDSSP(ComboBox cb)
        {
            dSach.NapCBDSSP(cb);
        }

        public String LayTenTheoMa(ComboBox combo)
        {
           return dSach.LayTenTheoMaSach(int.Parse(combo.SelectedValue.ToString()));
        }
    }
}
