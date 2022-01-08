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
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien f1 = new QuanLyNhanVien();
            f1.MdiParent = this;
            f1.StartPosition = FormStartPosition.CenterScreen;
            f1.Show();
        }

        private void quảnLýSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLySach f2 = new QuanLySach();
            f2.MdiParent = this;
            f2.StartPosition = FormStartPosition.CenterScreen;
            f2.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FKhachHang f3 = new FKhachHang();
            f3.MdiParent = this;
            f3.StartPosition = FormStartPosition.CenterScreen;
            f3.Show();
        }

        private void quảnLýĐặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FHoaDon f4 = new FHoaDon();
            f4.MdiParent = this;
            f4.StartPosition = FormStartPosition.CenterScreen;
            f4.Show();
        }
    }
}
