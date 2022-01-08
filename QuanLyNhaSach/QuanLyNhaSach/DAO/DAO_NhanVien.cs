using QuanLyNhaSach.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.DAO
{
    class DAO_NhanVien
    {
        ApplicationDBContext db;
        public DAO_NhanVien()
        {
            db = new ApplicationDBContext();
        }


        //lay ds nhan vien
        public dynamic LayDSNhanVien()
        {
            return db.NhanVien.Select(nv => new
            {
                nv.NhanVienId,
                nv.HoTenNV,
                nv.Sdt,
                nv.DiaChi,
                nv.ChucVu,
                nv.TinhTrang
                
            }).ToList();
        }

        //them nhan vien
        public void ThemNhanVien(NhanVien nv)
        {
            db.NhanVien.Add(nv);
            db.SaveChanges();
        }

        //update nhan vien
        public void SuaTTNhanVien(NhanVien nv)
        {
            var NVDaTao = db.NhanVien.First(n => n.NhanVienId == nv.NhanVienId);

            NVDaTao.HoTenNV = nv.HoTenNV;
            NVDaTao.Sdt = nv.Sdt;
            NVDaTao.DiaChi = nv.DiaChi;
            NVDaTao.ChucVu = nv.ChucVu;
            NVDaTao.TinhTrang = nv.TinhTrang;

            db.SaveChanges();
        }

        //Danh cho chuc nang Vo hieu hoa nhan vien (xoa)
        //public void CapNhatTinhTrangNV(int NVId, bool tinhTrang)
        //{
        //    var NVDaTao = db.NhanVien.First(n => n.NhanVienId == NVId);
        //    NVDaTao.TinhTrang = tinhTrang;

        //    db.SaveChanges();
        //}

        //lay dannh sach chuc vu
        public dynamic LayDSChucVu()
        {
            var ds = db.NhanVien.Select(nv => new
            {
                nv.ChucVu
            }).Distinct().ToList();
            return ds;
        }

        //xoa nhan vien
        public void xoaNhanVien(NhanVien nv)
        {
            NhanVien nvXoa = db.NhanVien.First(n => n.NhanVienId == nv.NhanVienId);

            db.NhanVien.Remove(nvXoa);
            db.SaveChanges();
        }
    }
}
