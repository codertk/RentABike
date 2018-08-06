namespace RentABike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'4138b04c-dce3-40bf-af67-2e34fcb16efa', N'admin', N'ANzI0RkC6WLC4j0iWPQiyoxPt6jvEoB3i3eM4NpT5cdInyl2tryNJ6g0Vq1z4pPXKw==', N'581b210b-4610-4e92-aa87-07c9640e30ba', N'ApplicationUser')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'dee755b0-2cae-4abc-b516-fac2b1efab2c', N'guest', N'AOClNKO5n1d0tBjDuNTydEEJp+cy/m87hoIxScpKprRfUoBsaOhgwDemw8FtGrBrOQ==', N'484b6b7c-706e-4a6b-aec7-679a9e16e075', N'ApplicationUser')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'12502c0c-33f9-4ee5-a903-ba74faa70a10', N'CanManageBikes')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4138b04c-dce3-40bf-af67-2e34fcb16efa', N'12502c0c-33f9-4ee5-a903-ba74faa70a10')

");
        }

        public override void Down()
        {

        }
    }
}
