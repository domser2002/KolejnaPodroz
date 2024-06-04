using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReorganizeModelMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accepted = table.Column<bool>(type: "bit", nullable: false),
                    Verified = table.Column<bool>(type: "bit", nullable: false),
                    FirebaseID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StatisticCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirebaseID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PreferedSeatType = table.Column<int>(type: "int", nullable: false),
                    PreferedSeatLocation = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Verified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Connection",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderID = table.Column<int>(type: "int", nullable: false),
                    ProviderID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connection", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Connection_Provider_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Provider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Connection_Provider_ProviderID1",
                        column: x => x.ProviderID1,
                        principalTable: "Provider",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Complaint",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplainantID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Response = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsResponded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Complaint_User_ComplainantID",
                        column: x => x.ComplainantID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Statistics_StatisticCategory_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "StatisticCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Statistics_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerID = table.Column<int>(type: "int", nullable: false),
                    ConnectionID = table.Column<int>(type: "int", nullable: false),
                    Purchased = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ticket_User_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDiscount",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    DiscountID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDiscount", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserDiscount_Discount_DiscountID",
                        column: x => x.DiscountID,
                        principalTable: "Discount",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDiscount_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StopDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DepartureTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    StationID = table.Column<int>(type: "int", nullable: false),
                    ConnectionID = table.Column<int>(type: "int", nullable: false),
                    ConnectionID1 = table.Column<int>(type: "int", nullable: true),
                    StationID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StopDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StopDetails_Connection_ConnectionID",
                        column: x => x.ConnectionID,
                        principalTable: "Connection",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StopDetails_Connection_ConnectionID1",
                        column: x => x.ConnectionID1,
                        principalTable: "Connection",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_StopDetails_Station_StationID",
                        column: x => x.StationID,
                        principalTable: "Station",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StopDetails_Station_StationID1",
                        column: x => x.StationID1,
                        principalTable: "Station",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_ComplainantID",
                table: "Complaint",
                column: "ComplainantID");

            migrationBuilder.CreateIndex(
                name: "IX_Connection_ProviderID",
                table: "Connection",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_Connection_ProviderID1",
                table: "Connection",
                column: "ProviderID1");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_CategoryID",
                table: "Statistics",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_UserID",
                table: "Statistics",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_StopDetails_ConnectionID",
                table: "StopDetails",
                column: "ConnectionID");

            migrationBuilder.CreateIndex(
                name: "IX_StopDetails_ConnectionID1",
                table: "StopDetails",
                column: "ConnectionID1");

            migrationBuilder.CreateIndex(
                name: "IX_StopDetails_StationID",
                table: "StopDetails",
                column: "StationID");

            migrationBuilder.CreateIndex(
                name: "IX_StopDetails_StationID1",
                table: "StopDetails",
                column: "StationID1");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_OwnerID",
                table: "Ticket",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscount_DiscountID",
                table: "UserDiscount",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscount_UserID",
                table: "UserDiscount",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Complaint");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "StopDetails");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "UserDiscount");

            migrationBuilder.DropTable(
                name: "StatisticCategory");

            migrationBuilder.DropTable(
                name: "Connection");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Provider");
        }
    }
}
