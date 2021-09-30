using QuanLyNhaSach.DAO;
using QuanLyNhaSach.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach.BUS
{
    class BUS_NhanVien
    {
        DAO_NhanVien dNV;
        public BUS_NhanVien()
        {
            dNV = new DAO_NhanVien();
        }

        public void HienThiDSNhanVien(DataGridView dg)
        {
            dg.DataSource = dNV.LayDSNhanVien();
        }

        //cap nhat thong tin nhan vien
        public bool SuaTTNhanVien(NhanVien nv)
        {
            try
            {
                dNV.SuaTTNhanVien(nv);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        //hien thi danh sach chuc vu
        public void HienThiDSChucVu(ComboBox cb)
        {
            //var d = dNV.LayDSChucVu();
            //cb.DataSource = dNV.LayDSChucVu();
            List<string> chucvu_list = new List<string>();
            chucvu_list.Add("Nhân viên");
            chucvu_list.Add("Quản lý");
            cb.DataSource = chucvu_list;
            cb.DisplayMember = "ChucVu";
            //cb.ValueMember = "ChucVu";
        }

        //hien thi danh sach tinh trang
        public void HienThiDSTinhTrang(ComboBox cb)
        {
            Dictionary<string, string> tt_list = new Dictionary<string, string>();
            tt_list.Add("true", "Đang làm việc");
            tt_list.Add("false", "Đã nghỉ");
            cb.DataSource = new BindingSource(tt_list, null);
            cb.DisplayMember = "Value";
            cb.ValueMember = "Key";
        }

        //active/inacctive nhan vien
        //public bool SuaTinhTrangNV(int id, bool tinhTrang)
        //{
        //    try
        //    {
        //        dNV.CapNhatTinhTrangNV(id, tinhTrang);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }
        //}

        //them nhan vien
        public bool themNhanVien(NhanVien nv)
        {
            try
            {
                dNV.ThemNhanVien(nv);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //xoa nhan vien
        public bool xoaNhanVien(NhanVien nv)
        {
            try
            {
                dNV.xoaNhanVien(nv);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
