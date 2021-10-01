using QuanLyNhaSach.Model;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhaSach.BUS
{
    public partial class FDatSach : Form
    {
        public int maDH;
        bool flag = false;
        BUS_Sach busSach;
        BUS_DatSach busDatSach;
        BUS_HoaDon busHD;
        DataTable dtSanPham;
        BUS_ChiTietHD BUS_ChiTiet;
        public FDatSach()
        {
            InitializeComponent();
            busSach = new BUS_Sach();
            busDatSach = new BUS_DatSach();
            busHD = new BUS_HoaDon();
            BUS_ChiTiet = new BUS_ChiTietHD();

        }

        private void CapNhapGridView()
        {
            dtSanPham = new DataTable();

            dtSanPham.Columns.Add("Mã sách");

            dtSanPham.Columns.Add("Giá");
            dtSanPham.Columns.Add("Số lượng");
            dtSanPham.Columns.Add("Tên sách");

            //add datatable vao datagridview
            dGSP.DataSource = dtSanPham;

            dGSP.Columns[0].Width = (int)(0.2 * dGSP.Width);
            dGSP.Columns[1].Width = (int)(0.2 * dGSP.Width);
            dGSP.Columns[2].Width = (int)(0.2 * dGSP.Width);
            dGSP.Columns[3].Width = (int)(0.32 * dGSP.Width);
        }

        private void FDatSach_Load(object sender, EventArgs e)
        {
            txtLoaiSP.Enabled = false;
            txtDonGia.Enabled = false;
            txtMaDH.Enabled = false;
            txtTacGia.Enabled = false;
            busSach.LayDanhSachSach(cbSP);
            flag = true;
            txtMaDH.Text = maDH.ToString();
            CapNhapGridView();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (numSoLuong.Value == 0 || txtDonGia.Text.Equals(""))
                MessageBox.Show("Vui lòng không bỏ trống đơn giá/ số lượng sản phẩm",
                   "Thông báo", MessageBoxButtons.OK);
            bool kiemtra = true;
            foreach (DataRow item in dtSanPham.Rows)
            {
                if (item[0].ToString() == cbSP.SelectedValue.ToString())
                {
                    kiemtra = false;
                    item[2] = int.Parse(item[2].ToString()) + numSoLuong.Value;
                    item[1] = numSoLuong.Value * decimal.Parse(txtDonGia.Text);
                    break;
                }

            }

            if (kiemtra)
            {
                // định nghĩa 1 dòng mới
                DataRow dataRow = dtSanPham.NewRow();
                dataRow[0] = cbSP.SelectedValue.ToString();
                dataRow[1] = numSoLuong.Value * decimal.Parse(txtDonGia.Text);
                dataRow[2] = numSoLuong.Value.ToString();
                dataRow[3] = busSach.LayTenTheoMa(cbSP);
                //add dong moi vao datatable
                dtSanPham.Rows.Add(dataRow);
            }

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            dtSanPham.Rows.RemoveAt(dGSP.CurrentRow.Index);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            bool kt = true;

            if (numSoLuong.Value.Equals(""))
            {
                kt = false;
                MessageBox.Show("Vui lòng không bỏ trống đơn giá/ số lượng sản phẩm",
                   "Thông báo", MessageBoxButtons.OK);
            }
            if (kt)
            {
                int t = dGSP.CurrentRow.Index;
                DataRow d = dtSanPham.Rows[t];
                d[2] = numSoLuong.Value;
                d[1] = numSoLuong.Value * decimal.Parse(txtDonGia.Text);
                d[3] = busSach.LayTenTheoMa(cbSP);
                d.AcceptChanges();
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HienThiThongTinSP(string ma)
        {
            Sach p = busDatSach.HienThiDSSP(int.Parse(ma));
            txtLoaiSP.Text = p.TheLoai;
            txtDonGia.Text = p.Gia.ToString();
            txtTacGia.Text = p.TacGia;
        }

        private void dGSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dGSP.Rows.Count)
            {
                txtDonGia.Text = dGSP.Rows[e.RowIndex].Cells["Giá"].Value.ToString();
                if (dGSP.Rows[e.RowIndex].Cells["Mã sách"].Value.ToString() != "")
                {
                    busSach.Lay1SP(cbSP, int.Parse(dGSP.Rows[e.RowIndex]
                        .Cells["Mã sách"].Value.ToString()));
                    numSoLuong.Value = int.Parse(dGSP.Rows[e.RowIndex]
                        .Cells["Số lượng"].Value.ToString());
                }
                else
                {
                    busSach.LayDSSP(cbSP);
                }
            }
        }

        private void btTaoDonHang_Click(object sender, EventArgs e)
        {
            bool kiemtra = true;
            foreach (DataRow item in dtSanPham.Rows)
            {
                ChiTietHoaDon o = new ChiTietHoaDon();
                o.HoaDonId = maDH;
                o.SachId = int.Parse(item[0].ToString());
                o.SoLuong = short.Parse(item[2].ToString());
                o.DonGia = Int32.Parse(item[1].ToString().Replace(".", ""));

                if (!BUS_ChiTiet.ThemCTDH(o))
                {
                    kiemtra = false;
                    break;
                }
            }

            if (kiemtra)
            {
                MessageBox.Show("Thêm chi tiết đơn hàng thành công", "Thông báo", MessageBoxButtons.OK);
                Close();
            }
            else
                MessageBox.Show("Thêm chi tiết đơn hàng không thành công", "Thông báo", MessageBoxButtons.OK);

            //o.HoaDonId = maDH;
            //o.SachId = int.Parse(cbSP.SelectedValue.ToString());
            ////o.SoLuong = short.Parse(numSoLuong.Value.ToString());

            //o.DonGia = Int32.Parse(txtDonGia.Text.Replace(".", ""));
            //if (BUS_ChiTiet.ThemCTDH(o))
            //{
            //    MessageBox.Show("Thêm chi tiết đơn hàng thành công", "Thông báo", MessageBoxButtons.OK);
            //    Close();
            //}
            //else
            //    MessageBox.Show("Thêm chi tiết đơn hàng không thành công", "Thông báo", MessageBoxButtons.OK);
        }

        private void cbSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == true)
                this.HienThiThongTinSP(cbSP.SelectedValue.ToString());
        }
    }
}