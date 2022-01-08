using QuanLyNhaSach.BUS;
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
    public partial class QuanLyNhanVien : Form
    {
        BUS_NhanVien bNV;
        public QuanLyNhanVien()
        {
            InitializeComponent();
            bNV = new BUS_NhanVien();
        }
        //Hien thi ds nhan vien
        public void HienThiDSNV()
        {
            bNV.HienThiDSNhanVien(dGNV);
            bNV.HienThiDSChucVu(cbChucVu);
            bNV.HienThiDSTinhTrang(cbTinhTrang);
            dGNV.Columns[0].Width = (int)(dGNV.Width * 0.11);
            dGNV.Columns[1].Width = (int)(dGNV.Width * 0.15);
            dGNV.Columns[2].Width = (int)(dGNV.Width * 0.15);
            dGNV.Columns[3].Width = (int)(dGNV.Width * 0.22);
            dGNV.Columns[4].Width = (int)(dGNV.Width * 0.12);
            dGNV.Columns[5].Width = (int)(dGNV.Width * 0.15);

        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            HienThiDSNV();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.HoTenNV = txtTenNV.Text;
            nv.Sdt = txtSdt.Text;
            nv.DiaChi = txtDiaChi.Text;
            nv.ChucVu = cbChucVu.SelectedValue.ToString();
            nv.TinhTrang = bool.Parse(cbTinhTrang.SelectedValue.ToString());
            if (bNV.themNhanVien(nv))
            {
                MessageBox.Show("Thêm thành công.");
                HienThiDSNV();
            }
            else
            {
                MessageBox.Show("Thêm thất bại. Số điện thoại phải bắt đầu bằng 0.");
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.NhanVienId = int.Parse(txtMa.Text);
            nv.HoTenNV = txtTenNV.Text;
            nv.Sdt = txtSdt.Text;
            nv.DiaChi = txtDiaChi.Text;
            nv.ChucVu = cbChucVu.SelectedValue.ToString();
            nv.TinhTrang = bool.Parse(cbTinhTrang.SelectedValue.ToString());

            if (bNV.SuaTTNhanVien(nv))
            {
                MessageBox.Show("Cập nhật thông tin nhân viên thành công");
                HienThiDSNV();
            }
            else
            {
                MessageBox.Show("Sửa thất bại. Số điện thoại phải bắt đầu bằng 0.");
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.NhanVienId = int.Parse(txtMa.Text);
            if (bNV.xoaNhanVien(nv))
            {
                MessageBox.Show("Xóa thành công.");
                HienThiDSNV();
            }
            else
            {
                MessageBox.Show("Xóa thất bại.");
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dGNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dGNV.Rows[e.RowIndex].Cells["NhanVienId"].Value.ToString();
            txtTenNV.Text = dGNV.Rows[e.RowIndex].Cells["HoTenNV"].Value.ToString();
            txtSdt.Text = dGNV.Rows[e.RowIndex].Cells["Sdt"].Value.ToString();
            txtDiaChi.Text = dGNV.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
            cbChucVu.Text = dGNV.Rows[e.RowIndex].Cells["ChucVu"].Value.ToString();
            if (dGNV.Rows[e.RowIndex].Cells["TinhTrang"].Value.ToString() == "True")
            {
                cbTinhTrang.SelectedIndex = 0;
            }
            else
            {
                cbTinhTrang.SelectedIndex = 1;
            }
        }
    }
}
