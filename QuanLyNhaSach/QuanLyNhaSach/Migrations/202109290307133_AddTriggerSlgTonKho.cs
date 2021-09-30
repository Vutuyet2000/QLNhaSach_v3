namespace QuanLyNhaSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTriggerSlgTonKho : DbMigration
    {
        public override void Up()
        {
            Sql(@"CREATE TRIGGER [dbo].[tr_datHang]
            on [dbo].[ChiTietHoaDons]
            AFTER INSERT
            AS
	            DECLARE @soLuongDat INT, @soLuongTrongKho INT;
	            SET @soLuongTrongKho=(SELECT SoLuongTonKho 
					            FROM Saches p , INSERTED i 
					            WHERE p.SachId=i.SachId)
	            SELECT @soLuongDat=i.SoLuong
	            FROM INSERTED i
	            IF @soLuongDat>@soLuongTrongKho
	            BEGIN
		            RAISERROR(N'SỐ LƯỢNG TRONG KHO NHỎ HƠN SỐ LƯỢNG ĐẶT',16,10)
		            ROLLBACK TRANSACTION
	            END");
        }
        
        public override void Down()
        {
        }
    }
}
