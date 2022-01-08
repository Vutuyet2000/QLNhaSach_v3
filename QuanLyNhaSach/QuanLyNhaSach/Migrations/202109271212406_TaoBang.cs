namespace QuanLyNhaSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaoBang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        HoaDonId = c.Int(nullable: false, identity: true),
                        NgayLapHoaDon = c.DateTime(nullable: false),
                        KhachHangId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HoaDonId)
                .ForeignKey("dbo.KhachHangs", t => t.KhachHangId, cascadeDelete: true)
                .Index(t => t.KhachHangId);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        KhachHangId = c.Int(nullable: false, identity: true),
                        HoTenKH = c.String(nullable: false, maxLength: 100),
                        Sdt = c.String(nullable: false, maxLength: 11),
                        DiaChi = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.KhachHangId);
            
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        NhanVienId = c.Int(nullable: false, identity: true),
                        HoTenNV = c.String(nullable: false, maxLength: 100),
                        Sdt = c.String(nullable: false, maxLength: 11),
                        DiaChi = c.String(maxLength: 255),
                        ChucVu = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.NhanVienId);
            
            CreateTable(
                "dbo.Saches",
                c => new
                    {
                        SachId = c.Int(nullable: false, identity: true),
                        TenSach = c.String(nullable: false, maxLength: 255),
                        TacGia = c.String(nullable: false, maxLength: 100),
                        TheLoai = c.String(maxLength: 100),
                        Gia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SoLuongTonKho = c.Int(nullable: false),
                        NhanVienId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SachId)
                .ForeignKey("dbo.NhanViens", t => t.NhanVienId, cascadeDelete: true)
                .Index(t => t.NhanVienId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Saches", "NhanVienId", "dbo.NhanViens");
            DropForeignKey("dbo.HoaDons", "KhachHangId", "dbo.KhachHangs");
            DropIndex("dbo.Saches", new[] { "NhanVienId" });
            DropIndex("dbo.HoaDons", new[] { "KhachHangId" });
            DropTable("dbo.Saches");
            DropTable("dbo.NhanViens");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.HoaDons");
        }
    }
}
