using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateConnections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConnectionID",
                table: "Provider",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArrivalTimes",
                table: "Connection",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DepartureTimes",
                table: "Connection",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Stations",
                table: "Connection",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ArrivalTimes",
                table: "Connection");

            migrationBuilder.DropColumn(
                name: "DepartureTimes",
                table: "Connection");

            migrationBuilder.DropColumn(
                name: "Stations",
                table: "Connection");
        }
    }
}
