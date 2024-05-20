using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class connectionsAddProvider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Connection_ConnectionID",
                table: "Provider");

            migrationBuilder.DropIndex(
                name: "IX_Provider_ConnectionID",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "ConnectionID",
                table: "Provider");

            migrationBuilder.AddColumn<string>(
                name: "Providers",
                table: "Connection",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Providers",
                table: "Connection");

            migrationBuilder.AddColumn<int>(
                name: "ConnectionID",
                table: "Provider",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Provider_ConnectionID",
                table: "Provider",
                column: "ConnectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Connection_ConnectionID",
                table: "Provider",
                column: "ConnectionID",
                principalTable: "Connection",
                principalColumn: "ID");
        }
    }
}
