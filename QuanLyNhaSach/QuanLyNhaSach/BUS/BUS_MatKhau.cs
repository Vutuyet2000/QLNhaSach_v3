using QuanLyNhaSach.DAO;
using QuanLyNhaSach.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.BUS
{
    class BUS_MatKhau
    {
        DAO_MatKhau dMK;
        public BUS_MatKhau() {
            dMK = new DAO_MatKhau();
        }
        public List<MatKhau> layDSDN() {
            return dMK.LayDSDangNhap();
        }
    }
}
