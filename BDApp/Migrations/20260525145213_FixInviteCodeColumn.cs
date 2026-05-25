using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDApp.Migrations
{
    /// <inheritdoc />
    public partial class FixInviteCodeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InviteCode",
                table: "Projects",
                newName: "InviteCodeHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InviteCodeHash",
                table: "Projects",
                newName: "InviteCode");
        }
    }
}
