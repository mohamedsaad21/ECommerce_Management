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
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUserRoles] (UserId, RoleId) SELECT '91d92b24-039c-4ae6-a6bd-0eb2e071868f', Id FROM [dbo].[AspNetRoles]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUserRoles] WHERE UserId = '91d92b24-039c-4ae6-a6bd-0eb2e071868f'");
        }
    }
}
