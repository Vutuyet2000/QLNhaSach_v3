using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.DAO
{
    class DAO_MatKhau
    {
        ApplicationDBContext db;
        public DAO_MatKhau() {
            db = new ApplicationDBContext();
        }
        public dynamic LayDSDangNhap() {
            var dsdn = db.MatKhau.Select(mk => mk).ToList();
            return dsdn;
        }
    }
}
