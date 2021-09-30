using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyNhaSach.Dao
{
    class DAO_ChiTietHoaDon
    {

        ApplicationDBContext db;

        public DAO_ChiTietHoaDon()
        {
            db = new ApplicationDBContext();
        }
    }
}
