using QuanLyNhaSach.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.DAO
{
    class DAO_DatSach
    {
        ApplicationDBContext db;
        public DAO_DatSach()
        {
            db = new ApplicationDBContext();
        }

        // LẤY DANH SÁCH SẢN PHẨM BẰNG MỘT LỚP TỰ ĐỊNH NGHĨA
        public Sach HienThiThongTinSP(int ma)
        {
            try
            {
                return db.Sach.Find(ma);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

    }
}
