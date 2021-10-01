using QuanLyNhaSach.DAO;
using QuanLyNhaSach.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.BUS
{
    class BUS_DatSach
    {
        DAO_DatSach da;

        public BUS_DatSach()
        {
            da = new DAO_DatSach();

        }

        public Sach HienThiDSSP(int ma)
        {
            return da.HienThiThongTinSP(ma);
        }
    }
}