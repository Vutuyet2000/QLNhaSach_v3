using System;
using System.Windows.Forms;
using QuanLyNhaSach.Bus;
using QuanLyNhaSach.BUS;
using QuanLyNhaSach.Model;

namespace QuanLyNhaSach
{
    public partial class FHoaDon : Form
    {
        BUS_HoaDon bHD;
        Bus_KhachHang bKH;
        public FHoaDon()
        {
            InitializeComponent();
            bHD = new BUS_HoaDon();
            bKH = new Bus_KhachHang();
        }

        private void CapNhapGridView()
        {
            bHD.HienThiDSHoaDon(gVDH);
            gVDH.Columns[0].Width = (int)(0.2 * gVDH.Width);
            gVDH.Columns[1].Width = (int)(0.2 * gVDH.Width);
            gVDH.Columns[2].Width = (int)(0.2 * gVDH.Width);
            gVDH.Columns[3].Width = (int)(0.3 * gVDH.Width);
        }

        private void btThem_Click_1(object sender, EventArgs e)
        {
            HoaDon dh = new HoaDon();
            dh.KhachHangId = int.Parse(cbKH.SelectedValue.ToString());
            dh.NgayLapHoaDon = DateTime.Parse(dtpNgayDH.Value.ToString("yyyy/MM/dd"));
            dh.NhanVienId = int.Parse(cbNhanVien.SelectedValue.ToString());
            if (bHD.ThemHD(dh))
            {
                MessageBox.Show("Thêm hoá đơn thành công", "Thông tin");
            }
            CapNhapGridView();
        }

        private void FHoaDon_Load(object sender, EventArgs e)
        {
            CapNhapGridView();
            bHD.LayDSKH(cbKH);
            bHD.LayDSNV(cbNhanVien);
        }

        private void gVDH_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVDH.Rows.Count)
            {
                txtMaDH.Text = gVDH.Rows[e.RowIndex].Cells["HoaDonId"].Value.ToString();
                cbNhanVien.Text =gVDH.Rows[e.RowIndex].Cells["HoTenNV"].Value.ToString();
                cbKH.Text = gVDH.Rows[e.RowIndex].Cells["HoTenKH"].Value.ToString();
                dtpNgayDH.Text = gVDH.Rows[e.RowIndex].Cells["NgayLapHoaDon"].Value.ToString();
            }
        }

        private void btSua_Click_1(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.HoaDonId = int.Parse(gVDH.CurrentRow.Cells["HoaDonId"].Value.ToString());
            hd.KhachHangId = int.Parse(cbKH.SelectedValue.ToString());
            hd.NhanVienId = int.Parse(cbNhanVien.SelectedValue.ToString());
            hd.NgayLapHoaDon = DateTime.Parse(dtpNgayDH.Value.ToString("yyyy/MM/dd"));
            bHD.SuaHD(hd);
            CapNhapGridView();
        }

        private void btXoa_Click_1(object sender, EventArgs e)
        {
            HoaDon dh = new HoaDon();
            dh.HoaDonId = int.Parse(gVDH.CurrentRow.Cells["HoaDonId"].Value.ToString()); ;
            bHD.XoaHD(dh);
            gVDH.Columns.Clear();
            CapNhapGridView();

        }

        private void btThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void gVDH_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            FChiTietHoaDon fChiTietDH = new FChiTietHoaDon();
            fChiTietDH.ma = int.Parse(gVDH.CurrentRow.Cells["HoaDonId"].Value.ToString());
            fChiTietDH.ShowDialog();
        }

        private void btnCT_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDon hd = new HoaDon();
                hd.KhachHangId = int.Parse(cbKH.SelectedValue.ToString());

                hd.NhanVienId = int.Parse(cbNhanVien.SelectedValue.ToString());

                if (hd.KhachHangId != 0 || hd.NhanVienId != 0)
                {
                    hd.NgayLapHoaDon = DateTime.Parse(dtpNgayDH.Value.ToString("yyyy/MM/dd"));
                    if (bHD.ThemHD(hd))
                    {
                        FChiTietHoaDon fChiTietHoaDon = new FChiTietHoaDon();
                        fChiTietHoaDon.ma = int.Parse(gVDH.CurrentRow.Cells["HoaDonId"].Value.ToString());
                        fChiTietHoaDon.ShowDialog();

                    }
                    CapNhapGridView();
                }
                else
                {
                    MessageBox.Show("Khách hàng hoặc nhân viên không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
