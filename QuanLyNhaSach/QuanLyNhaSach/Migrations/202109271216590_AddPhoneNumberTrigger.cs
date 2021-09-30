namespace QuanLyNhaSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneNumberTrigger : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    create trigger validate_NhanVien_PhoneNumber on dbo.NhanViens
                    for insert, update
                    as
                    begin
                        declare @sdt nvarchar(11)
                        select @sdt = i.Sdt
                        from inserted i
                        if (left(@sdt, 1) <> '0')
                                begin
                                    rollback;
                                end
                        end"
               );
        }
        
        public override void Down()
        {
        }
    }
}
