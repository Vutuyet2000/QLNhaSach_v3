using System;
using System.Windows.Forms;
using QuanLyNhaSach.Model;

namespace QuanLyNhaSach
{
    public partial class FChiTietHoaDon : Form
    {
        public int ma;

        public FChiTietHoaDon()
        {
            InitializeComponent();
        }
        private void CapNhatView()
        {

            //bus.LayDSCTDH(gVCTDH, ma);
            gVCTDH.Columns[0].Width = (int)(0.2 * gVCTDH.Width);
            gVCTDH.Columns[1].Width = (int)(0.2 * gVCTDH.Width);
            gVCTDH.Columns[2].Width = (int)(0.2 * gVCTDH.Width);
            gVCTDH.Columns[3].Width = (int)(0.3 * gVCTDH.Width);

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            bool kt = true;
            if (txtDonGia.Text == "" || txtSoLuong.Text == "")
            {
                kt = false;
                MessageBox.Show("Vui lòng không bỏ trống đơn giá/ số lượng sản phẩm",
                   "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                // kiểm tra thêm chi tiết đơn hàng có trùng sản phẩm không
                for (int i = 0; i < gVCTDH.Rows.Count; i++)
                {
                    if (gVCTDH.CurrentRow.Cells[1].Value.ToString() == cbTenSP.SelectedValue.ToString())
                    {
                        kt = false;
                        MessageBox.Show("Sản phẩm đã được đặt trong đơn hàng",
                   "Thông báo", MessageBoxButtons.OK);
                        break;
                    }
                }
                if (kt)
                {
                    ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon();
                    chiTietHoaDon.ChiTietHoaDonId = int.Parse(txtMaDH.Text);
                    chiTietHoaDon.SachId = int.Parse(cbTenSP.SelectedValue.ToString());
                    chiTietHoaDon.DonGia = decimal.Parse(txtDonGia.Text);
                    chiTietHoaDon.SoLuong = short.Parse(txtSoLuong.Text);
                    //bus.ThemCTDH(order);
                    gVCTDH.Columns.Clear();
                    //bus.LayDSCTDH(gVCTDH, ma);
                }

            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            //int maDH = int.Parse(txtMaDH.Text);
            //int maSP = int.Parse(gVCTDH.CurrentRow.Cells["ProductID"].Value.ToString());
            //bus.XoaCTDH(maDH, maSP);
            //gVCTDH.Columns.Clear();
            //bus.LayDSCTDH(gVCTDH, ma);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
