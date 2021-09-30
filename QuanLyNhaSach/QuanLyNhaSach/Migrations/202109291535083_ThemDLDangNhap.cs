namespace QuanLyNhaSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThemDLDangNhap : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[MatKhaus] ([username],[password]) VALUES ('hang','123')
            INSERT INTO [dbo].[MatKhaus] ([username],[password]) VALUES ('tuyet','123')
            INSERT INTO [dbo].[MatKhaus] ([username],[password]) VALUES ('vananh','123')");
        }
        
        public override void Down()
        {
        }
    }
}
