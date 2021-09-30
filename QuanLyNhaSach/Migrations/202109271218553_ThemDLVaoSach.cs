namespace QuanLyNhaSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThemDLVaoSach : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO[dbo].[Saches] ([TenSach],[TacGia],[TheLoai],[Gia],[SoLuongTonKho],[NhanVienId]) VALUES('Whale Day', 'Billy Collins', N'Ngoại văn', '50000', '100', '1')");

            Sql("INSERT INTO[dbo].[Saches] ([TenSach],[TacGia],[TheLoai],[Gia],[SoLuongTonKho],[NhanVienId]) VALUES('The Vanishing Half', 'Brit Bennett', N'Ngoại văn', '90000', '120', '2')");

            Sql("INSERT INTO[dbo].[Saches] ([TenSach],[TacGia],[TheLoai],[Gia],[SoLuongTonKho],[NhanVienId]) VALUES('A Promise Land', 'Barack Obama', N'Ngoại văn', '100000', '110', '3')");

            Sql("INSERT INTO[dbo].[Saches] ([TenSach],[TacGia],[TheLoai],[Gia],[SoLuongTonKho],[NhanVienId]) VALUES('Stamped: Racism, Antiracism, and You: A Remix of the National Book Award-winning Stamped from the Beginning', 'Jason Reynolds', N'Ngoại văn', '190000', '60', '1')");

            Sql("INSERT INTO[dbo].[Saches]([TenSach],[TacGia],[TheLoai],[Gia],[SoLuongTonKho],[NhanVienId]) VALUES('Leave the World Behind', 'Rumaan Alam', N'Ngoại văn', '120000', '50', '2')");

            Sql("INSERT INTO[dbo].[Saches] ([TenSach],[TacGia],[TheLoai],[Gia],[SoLuongTonKho],[NhanVienId]) VALUES('Untamed', 'Glennon Doyle', N'Ngoại văn', '200000', '80', '3')");

            Sql("INSERT INTO[dbo].[Saches] ([TenSach],[TacGia],[TheLoai],[Gia],[SoLuongTonKho],[NhanVienId]) VALUES('Caste', 'Isabel Wilkerson', N'Ngoại văn', '200000', '200', '1')");

            Sql("INSERT INTO[dbo].[Saches] ([TenSach],[TacGia],[TheLoai],[Gia],[SoLuongTonKho],[NhanVienId]) VALUES('Hamnet', 'Maggie O.Farrell', N'Ngoại văn', '120000', '100', '2')");
        }
        
        public override void Down()
        {
        }
    }
}
