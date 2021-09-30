using QuanLyNhaSach.Bus;
using QuanLyNhaSach.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class FKhachHang : Form
    {
        Bus_KhachHang busKH;
        private int tam;

        public FKhachHang()
        {
            InitializeComponent();
            busKH = new Bus_KhachHang();
        }

        public void HienThiDSKH()
        {
            busKH.HienThiDSKhachHang(dGKH);
        }
        private void FKhachHang_Load(object sender, EventArgs e)
        {
            busKH.HienThiDSKhachHang(dGKH);
            HienThiDSKhachHang();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.HoTenKH = txtTenKH.Text;
            kh.Sdt = txtSDT.Text;
            kh.DiaChi = txtDiaChi.Text;
            if (busKH.ThemKhachHang(kh))
            {
                MessageBox.Show("Thêm thông tin khách hàng thành công.");
                HienThiDSKhachHang();
            }
            else
            {
                MessageBox.Show("Thêm thông tin khách hàng thất bại.");
            }
        }

        void HienThiDSKhachHang()
        {
            //dGKH.DataSource = null;
            busKH.HienThiDSKhachHang(dGKH);
            dGKH.Columns[0].Width = (int)(dGKH.Width * 0.22);
            dGKH.Columns[1].Width = (int)(dGKH.Width * 0.24);
            dGKH.Columns[2].Width = (int)(dGKH.Width * 0.24);
            dGKH.Columns[3].Width = (int)(dGKH.Width * 0.24);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.KhachHangId = int.Parse(txtMaKH.Text);
            kh.HoTenKH = txtTenKH.Text;
            kh.Sdt = txtSDT.Text;
            kh.DiaChi = txtDiaChi.Text;

            if (busKH.SuaTTKhachHang(kh))
            {
                MessageBox.Show("Cập nhật thông tin Khách hàng thành công");
                HienThiDSKhachHang();
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin Khách hàng thất bại");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHang kh = new KhachHang();
                kh.KhachHangId = int.Parse(txtMaKH.Text);
                if (busKH.XoaTTKhachHang(kh))
                {
                    MessageBox.Show("Xóa thành công.");
                    busKH.HienThiDSKhachHang(dGKH);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dGKH_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Text = dGKH.Rows[e.RowIndex].Cells["KhachHangId"].Value.ToString();
            txtTenKH.Text = dGKH.Rows[e.RowIndex].Cells["HoTenKH"].Value.ToString();
            txtSDT.Text = dGKH.Rows[e.RowIndex].Cells["Sdt"].Value.ToString();
            if (dGKH.Rows[e.RowIndex].Cells["DiaChi"].Value == null)
            {
                txtDiaChi.Text = null;
            }
            else
            {
                txtDiaChi.Text = dGKH.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
            }
            //txtDiaChi.Text = dGKH.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();

            if (e.RowIndex >= 0 && e.RowIndex < dGKH.Rows.Count) ;
        }

    }
}
