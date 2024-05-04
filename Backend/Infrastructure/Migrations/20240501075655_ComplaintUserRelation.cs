using Microsoft.EntityFrameworkCore.Migrations;
using Infrastructure.DataContexts;
#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ComplaintUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Complaint",
                newName: "ComplainantID");

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_ComplainantID",
                table: "Complaint",
                column: "ComplainantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaint_User_ComplainantID",
                table: "Complaint",
                column: "ComplainantID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaint_User_ComplainantID",
                table: "Complaint");

            migrationBuilder.DropIndex(
                name: "IX_Complaint_ComplainantID",
                table: "Complaint");

            migrationBuilder.RenameColumn(
                name: "ComplainantID",
                table: "Complaint",
                newName: "UserID");
        }
    }
}
