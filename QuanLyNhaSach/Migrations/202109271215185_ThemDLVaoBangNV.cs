namespace QuanLyNhaSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThemDLVaoBangNV : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.NhanViens(HoTenNV,Sdt,DiaChi,ChucVu) VALUES('Nguyễn Văn A', '0123456789', '254 Bà Hạt', 'Quản lý')");
            Sql("INSERT INTO dbo.NhanViens(HoTenNV,Sdt,DiaChi,ChucVu) VALUES('Đào Thị B', '0123456789', '254 ABC', 'Nhân viên')");
            Sql("INSERT INTO dbo.NhanViens(HoTenNV,Sdt,DiaChi,ChucVu) VALUES('Trần C', '0123456789', '254 CDE', 'Nhân viên')");
        }
        
        public override void Down()
        {
        }
    }
}
