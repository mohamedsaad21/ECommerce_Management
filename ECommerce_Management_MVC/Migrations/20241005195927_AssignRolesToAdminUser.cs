using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce_Management_MVC.Migrations
{
    /// <inheritdoc />
    public partial class AssignRolesToAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUserRoles] (UserId, RoleId) SELECT 'b770397c-0037-4631-b2da-3bed5770b171', Id FROM [dbo].[AspNetRoles]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUserRoles] WHERE UserId = 'b770397c-0037-4631-b2da-3bed5770b171'");
        }
    }
}