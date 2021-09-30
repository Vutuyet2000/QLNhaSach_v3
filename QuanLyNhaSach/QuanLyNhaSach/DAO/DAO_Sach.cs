using QuanLyNhaSach.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
