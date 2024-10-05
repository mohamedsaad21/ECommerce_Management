using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce_Management_MVC.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [FullName], [Discriminator], [BillingAddress], [Default_Shipping_Address], [country], [ProfilePicture], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b770397c-0037-4631-b2da-3bed5770b171', N'Mohamed Saad', N'Customer', NULL, NULL, NULL, NULL, N'admin', N'ADMIN', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEL0poSakMUe3RlvXX4DOLVilCgkk+v4pQxTME1xYXu0ZNZi6RU/3KEhsBaosqMEG2A==', N'GLYJX2JDBY3INELFVOR55Q6V57GQY7CK', N'9eae9137-75a7-4423-9c5c-68a0c64cfe5e', NULL, 0, 0, NULL, 1, 0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUsers] WHERE Id = 'b770397c-0037-4631-b2da-3bed5770b171'");
        }
    }
}
