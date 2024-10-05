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
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [FullName], [Discriminator], [BillingAddress], [Default_Shipping_Address], [country], [ProfilePicture], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'91d92b24-039c-4ae6-a6bd-0eb2e071868f', N'Mohamed Saad', N'Customer', NULL, NULL, NULL, NULL, N'admin', N'ADMIN', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEA9JU5NWQl2oiRiALFqXPxuHI0iBJ2kWbu5QNZ1EOpsgDiFLU3isTecJAdcKTeZLOA==', N'2X6Q6K7L4LCEQTPS2KPUX27GSV5HSQOP', N'9821d972-4ade-4b5e-ae20-01959ab852e4', NULL, 0, 0, NULL, 1, 0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUsers] WHERE Id = '91d92b24-039c-4ae6-a6bd-0eb2e071868f'");
        }
    }
}
