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
        DAO_MatKhau dao_MK;
        public BUS_MatKhau() {
            dao_MK = new DAO_MatKhau();
        }
        public List<MatKhau> layDSDN() {
            return dao_MK.LayDSDangNhap();
        }
    }
}
