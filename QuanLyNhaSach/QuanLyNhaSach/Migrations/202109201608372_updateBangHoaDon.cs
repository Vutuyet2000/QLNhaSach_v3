namespace QuanLyNhaSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class updateBangHoaDon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoaDons", "NhanVienId", c => c.Int(nullable: false));
            CreateIndex("dbo.HoaDons", "NhanVienId");
            AddForeignKey("dbo.HoaDons", "NhanVienId", "dbo.NhanViens", "NhanVienId", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.HoaDons", "NhanVienId", "dbo.NhanViens");
            DropIndex("dbo.HoaDons", new[] { "NhanVienId" });
            DropColumn("dbo.HoaDons", "NhanVienId");
        }
    }
}