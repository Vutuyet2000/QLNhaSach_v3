namespace QuanLyNhaSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThemDLVaoBangNV : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO dbo.NhanViens(HoTenNV,Sdt,DiaChi,ChucVu) VALUES(N'Nguyễn Văn A', '0123456789', N'254 Bà Hạt', N'Quản lý')");
            Sql("INSERT INTO dbo.NhanViens(HoTenNV,Sdt,DiaChi,ChucVu) VALUES(N'Đào Thị B', '0123456789', N'254 ABC', N'Nhân viên')");
            Sql("INSERT INTO dbo.NhanViens(HoTenNV,Sdt,DiaChi,ChucVu) VALUES(N'Trần C', '0123456789', N'254 CDE', N'Nhân viên')");
        }
        
        public override void Down()
        {
        }
    }
}
