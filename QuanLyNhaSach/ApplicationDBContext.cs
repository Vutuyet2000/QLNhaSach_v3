using QuanLyNhaSach.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach
{
    class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext() : base("cnStr") { }

        public DbSet<NhanVien> NhanVien { get; set;}
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public DbSet<Sach> Sach { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietHoaDon>().HasRequired(a => a.Hd).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<ChiTietHoaDon>().HasRequired(a => a.s).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<HoaDon>().HasRequired(a => a.Kh).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<HoaDon>().HasRequired(a => a.nv).WithMany().WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
