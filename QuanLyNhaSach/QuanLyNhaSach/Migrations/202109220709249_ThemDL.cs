namespace QuanLyNhaSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ThemDL : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.KhachHangs(HoTenKH,Sdt) VALUES('KhachHang1',N'0944810815')" +
                ",('KhachHang2', N'0944810815')" +
                ",('KhachHang3', N'0944810815')");
        }

        public override void Down()
        {
        }
    }
}
