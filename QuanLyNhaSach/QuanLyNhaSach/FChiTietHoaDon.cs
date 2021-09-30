using System;
using System.Windows.Forms;
using QuanLyNhaSach.BUS;
using QuanLyNhaSach.Model;

namespace QuanLyNhaSach
{
    public partial class FChiTietHoaDon : Form
    {
        public int ma;
        BUS.BUS_Sach bSach;
        BUS_ChiTietHD bChiTietHD;
        public FChiTietHoaDon()
        {
            InitializeComponent();
            bSach = new BUS_Sach();
            bChiTietHD = new BUS_ChiTietHD();
        }
        private void CapNhatView()
        {
            bChiTietHD.LayDSCTDH(gVCTDH,ma);

            gVCTDH.Columns[0].Width = (int)(0.2 * gVCTDH.Width);
            gVCTDH.Columns[1].Width = (int)(0.2 * gVCTDH.Width);
            gVCTDH.Columns[2].Width = (int)(0.2 * gVCTDH.Width);
            gVCTDH.Columns[3].Width = (int)(0.3 * gVCTDH.Width);

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            FDatSach fDatHang = new FDatSach();
            fDatHang.maDH = ma;
            fDatHang.ShowDialog();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int maDH = int.Parse(txtMaDH.Text);
            int maSP = int.Parse(cbSP.SelectedValue.ToString());
            bChiTietHD.XoaCTDH(maDH, maSP);
            gVCTDH.Columns.Clear();
            bChiTietHD.LayDSCTDH(gVCTDH, ma);
        }
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FChiTietHoaDon_Load(object sender, EventArgs e)
        {
            CapNhatView();
            txtMaDH.Text = ma.ToString();
            txtMaDH.Enabled = false;
            bSach.LayDanhSachSach(cbSP);
        }

        private void FChiTietHoaDon_Activated(object sender, EventArgs e)
        {
            bChiTietHD.LayDSCTDH(gVCTDH, ma);
        }

        private void gVCTDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVCTDH.Rows.Count)
            {
                txtMaDH.Text = gVCTDH.Rows[e.RowIndex].Cells["HoaDonId"].Value.ToString();
                txtDonGia.Text = gVCTDH.Rows[e.RowIndex].Cells["DonGia"].Value.ToString();
                txtSoLuong.Text = gVCTDH.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString();
                cbSP.Text = gVCTDH.Rows[e.RowIndex].Cells["TenSach"].Value.ToString();
                //bSach.Lay1SP(cbSP, int.Parse());

            }
        }
    }
}
