namespace QuanLyNhaSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HoaDons", "KhachHangId", "dbo.KhachHangs");
            CreateTable(
                "dbo.ChiTietHoaDons",
                c => new
                    {
                        ChiTietHoaDonId = c.Int(nullable: false, identity: true),
                        DonGia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SoLuong = c.Int(nullable: false),
                        HoaDonId = c.Int(nullable: false),
                        SachId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChiTietHoaDonId)
                .ForeignKey("dbo.HoaDons", t => t.HoaDonId)
                .ForeignKey("dbo.Saches", t => t.SachId)
                .Index(t => t.HoaDonId)
                .Index(t => t.SachId);
            
            AddColumn("dbo.HoaDons", "NhanVienId", c => c.Int(nullable: false));
            CreateIndex("dbo.HoaDons", "NhanVienId");
            AddForeignKey("dbo.HoaDons", "NhanVienId", "dbo.NhanViens", "NhanVienId");
            AddForeignKey("dbo.HoaDons", "KhachHangId", "dbo.KhachHangs", "KhachHangId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoaDons", "KhachHangId", "dbo.KhachHangs");
            DropForeignKey("dbo.ChiTietHoaDons", "SachId", "dbo.Saches");
            DropForeignKey("dbo.ChiTietHoaDons", "HoaDonId", "dbo.HoaDons");
            DropForeignKey("dbo.HoaDons", "NhanVienId", "dbo.NhanViens");
            DropIndex("dbo.HoaDons", new[] { "NhanVienId" });
            DropIndex("dbo.ChiTietHoaDons", new[] { "SachId" });
            DropIndex("dbo.ChiTietHoaDons", new[] { "HoaDonId" });
            DropColumn("dbo.NhanViens", "TinhTrang");
            DropColumn("dbo.HoaDons", "NhanVienId");
            DropTable("dbo.ChiTietHoaDons");
            AddForeignKey("dbo.HoaDons", "KhachHangId", "dbo.KhachHangs", "KhachHangId", cascadeDelete: true);
        }
    }
}
