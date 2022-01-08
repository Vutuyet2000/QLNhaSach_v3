using QuanLyNhaSach.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach.DAO
{
    class DAO_Sach
    {
        ApplicationDBContext db;

        public DAO_Sach()
        {
            db = new ApplicationDBContext();
            
        }
        public void ThemSach(Sach s)
        {

            db.Sach.Add(s);
            db.SaveChanges();
        }
        public dynamic LayDSSach()
        {
            var sach = db.Sach.Select(s => new {
                s.SachId,
                s.TenSach,
                s.TacGia,
                s.TheLoai,
                s.Gia,
                s.SoLuongTonKho,
                s.Nv.HoTenNV
            }).ToList();
            return sach;
        }
        public void SuaSach(Sach s)
        {
            Sach sachF = db.Sach.Find(s.SachId);
            sachF.TenSach = s.TenSach;
            sachF.TacGia = s.TacGia;
            sachF.TheLoai = s.TheLoai;
            sachF.Gia = s.Gia;
            sachF.SoLuongTonKho = s.SoLuongTonKho;
            sachF.NhanVienId = s.NhanVienId;
            db.SaveChanges();
        }

        public void XoaSach(Sach s)
        {
            Sach sachF = db.Sach.Find(s.SachId);
            db.Sach.Remove(sachF);
            db.SaveChanges();
        }
        public bool KiemTraSach(Sach s)
        {
            Sach sachF = db.Sach.Find(s.SachId);
            if (s != null)
            {
                return true;
            }
            else
                return false;
        }

        // LẤY TÊN SẢN PHẨM THEO MÃ SẢN PHẨM BẰNG METHOD
        public dynamic LayTenTheoMaSP(int ma)
        {
            var tenSP = db.Sach.Where(p => p.SachId == ma)
                .Select(sp => new
                {
                    sp.TenSach,
                    sp.SachId

                });
            return tenSP;
        }

        // NAP DANH SÁCH SAN PHẢM LÊN COMBOBOX THEO MÃ SP
        public void NapCBDSSP(ComboBox cb, int ma)
        {
            cb.DataSource = LayTenTheoMaSP(ma);
            cb.DisplayMember = "TenSach";
            cb.ValueMember = "SachId";
        }

        // NAP DANH SÁCH SAN PHẢM LÊN COMBOBOX SP
        public void NapCBDSSP(ComboBox cb)
        {
            cb.DataSource = LayDSSach();
            cb.DisplayMember = "TenSach";
            cb.ValueMember = "SachId";
        }

        public String LayTenTheoMaSach(int ma)
        {
            Sach s = db.Sach.Find(ma);
            return s.TenSach;
        }
    }
}
