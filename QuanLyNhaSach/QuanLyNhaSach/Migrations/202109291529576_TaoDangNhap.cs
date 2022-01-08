namespace QuanLyNhaSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaoDangNhap : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.MatKhaus",
                c => new
                    {
                        username = c.String(nullable: false, maxLength: 50),
                        password = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.username);
                
        }
        
        public override void Down()
        {
            
            DropTable("dbo.MatKhaus");
           
        }
    }
}
