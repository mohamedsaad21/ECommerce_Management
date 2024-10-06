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
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [FullName], [Discriminator], [BillingAddress], [Default_Shipping_Address], [country], [ProfilePicture], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b9812dfd-6990-4f4c-ae7b-3fafc1ace7e7', N'Admin', N'Customer', NULL, NULL, NULL, NULL, N'Admin', N'ADMIN', N'Admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEK3TB5h9u8TYv1WrxsKnODLislkpNO1Am2B/fhCY6uYpNR3pi8q6dOV2RTW4yviC2g==', N'RDXYBCOFBQOLBW6NPBWE4UNVF35IUQRN', N'edb773cf-9fa5-42cc-84d9-1eae0c2c30ab', NULL, 0, 0, NULL, 1, 0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUsers] WHERE Id = 'b9812dfd-6990-4f4c-ae7b-3fafc1ace7e7'");
        }
    }
}
