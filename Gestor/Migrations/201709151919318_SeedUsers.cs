namespace Gestor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5e70b728-db68-42ff-8aa8-a50a5eefd622', N'sergiodifiore@visaocompany.com.br', 0, N'AItbs7bYPlfXv16tCgDn/5CT9TFGUew3S2BbBShjoOUe+0Kgoyrewyj65Qn1wDE8cg==', N'780cd5a4-d9b9-4b9d-9784-ea5003446370', NULL, 0, 0, NULL, 1, 0, N'sergiodifiore@visaocompany.com.br')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bcfb74d5-9df2-4fe0-a275-c63d47ac6c76', N'sergiodifiore@gmail.com', 0, N'AJfjw7MUROoLLKABAa2XhI2ndjdS+E86Q27m1r3FtHPAddQCAeVLnHYIP/sVDUZ4rw==', N'f48d1129-f6e0-4465-988f-6c45ae5ca871', NULL, 0, 0, NULL, 1, 0, N'sergiodifiore@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'22003ef1-aa3e-4f6d-8463-19341087cbf8', N'Administrator')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bcfb74d5-9df2-4fe0-a275-c63d47ac6c76', N'22003ef1-aa3e-4f6d-8463-19341087cbf8')

");
        }
        
        public override void Down()
        {
        }
    }
}
