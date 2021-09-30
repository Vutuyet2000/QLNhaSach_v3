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
    public partial class QuanLySach : Form
    {
        BUS_Sach bSach;
        public QuanLySach()
        {

            InitializeComponent();
            bSach = new BUS_Sach();
        }

        private void QuanLySach_Load(object sender, EventArgs e)
        {
            txtMaSach.Enabled = false;
            bSach.HienThiDSNVLenCb(cbNV);
            HienThiDSSachLenDG();
        }
        void HienThiDSSachLenDG()
        {
            dGSach.DataSource = null;
            bSach.HienThiDSSachLenDG(dGSach);
            dGSach.Columns[0].Width = (int)(dGSach.Width * 0.1);
            dGSach.Columns[1].Width = (int)(dGSach.Width * 0.25);
            dGSach.Columns[2].Width = (int)(dGSach.Width * 0.15);
            dGSach.Columns[3].Width = (int)(dGSach.Width * 0.1);
            dGSach.Columns[4].Width = (int)(dGSach.Width * 0.1);
            dGSach.Columns[5].Width = (int)(dGSach.Width * 0.15);
            dGSach.Columns[6].Width = (int)(dGSach.Width * 0.15);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Sach s = new Sach();
            if (txtSoLuong.Text == "" || txtTenSach.Text == "" || txtTacGia.Text == "" || txtTheLoai.Text == ""
                || txtGia.Text == "")
            {
                MessageBox.Show("Thêm thất bại");

            }
            else
            {
                s.TenSach = txtTenSach.Text;
                s.TacGia = txtTacGia.Text;
                s.TheLoai = txtTheLoai.Text;
                s.Gia = Convert.ToDecimal(txtGia.Text);
                s.SoLuongTonKho = int.Parse(txtSoLuong.Text);
                s.NhanVienId = int.Parse(cbNV.SelectedValue.ToString());


                if (bSach.TaoSach(s))
                {
                    MessageBox.Show("Thêm thành công");
                    HienThiDSSachLenDG();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }

                txtTenSach.Text = txtTacGia.Text = txtTheLoai.Text = txtGia.Text = txtSoLuong.Text = "";
                cbNV.SelectedIndex = 0;
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            Sach sachXoa = new Sach();

                sachXoa.SachId = int.Parse(txtMaSach.Text);
                if (bSach.XoaSach(sachXoa))
                {
                    MessageBox.Show("Xóa sách thành công");
                    bSach.HienThiDSSachLenDG(dGSach);
                }
                else
                {
                    MessageBox.Show("Xóa sách thất bại");
                }
           

        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Sach sachSua = new Sach();
            if (txtSoLuong.Text == "" || txtTenSach.Text == "" || txtTacGia.Text == "" || txtTheLoai.Text == ""
                || txtGia.Text == "")
            {
                MessageBox.Show("Sửa thất bại");

            }
            else
            {
                sachSua.SachId = int.Parse(txtMaSach.Text);
                sachSua.TenSach = txtTenSach.Text;
                sachSua.TacGia = txtTacGia.Text;
                sachSua.TheLoai = txtTheLoai.Text;
                sachSua.Gia = Convert.ToDecimal(txtGia.Text);
                sachSua.SoLuongTonKho = int.Parse(txtSoLuong.Text);
                sachSua.NhanVienId = int.Parse(cbNV.SelectedValue.ToString());
                if (bSach.SuaSach(sachSua))
                {
                    MessageBox.Show("Sửa sách thành công");
                    bSach.HienThiDSSachLenDG(dGSach);
                }
                else
                {
                    MessageBox.Show("Sửa sách thất bại");
                }
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dGSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dGSach.Rows.Count) // dòng 0 đến dòng số cuối
            {
                txtMaSach.Text = dGSach.Rows[e.RowIndex].Cells["SachId"].Value.ToString();
                txtTenSach.Text = dGSach.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtTacGia.Text = dGSach.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTheLoai.Text = dGSach.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtGia.Text = dGSach.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtSoLuong.Text = dGSach.Rows[e.RowIndex].Cells[5].Value.ToString();
                cbNV.Text = dGSach.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
        }
    }
}
