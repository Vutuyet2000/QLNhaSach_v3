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
    public partial class FDangNhap : Form
    {
        BUS_MatKhau bMK;
        public FDangNhap()
        {
            InitializeComponent();
            bMK = new BUS_MatKhau();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;
            List<MatKhau> list = bMK.layDSDN();
            var kt = list.Where(ds => ds.username.Equals(tenDangNhap)).ToList();
            if (kt.Count > 0) {
                //Kiểm tra Password
                if (kt[0].password.Equals(matKhau))
                {
                    MessageBox.Show("Đăng nhập thành công!!!");
                    FMain f = new FMain();
                    f.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Đăng nhập thất bại. Mật khẩu không đúng!!!");
            }
            else
                MessageBox.Show("Tên đăng nhập không tồn tại");
        }
    }
}
