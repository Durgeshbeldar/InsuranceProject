using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DsInsurance.Migrations
{
    /// <inheritdoc />
    public partial class v41 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerQueries",
                columns: table => new
                {
                    QueryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyNo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResolvedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResolvedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerQueries", x => x.QueryId);
                    table.ForeignKey(
                        name: "FK_CustomerQueries_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerQueries_Employees_ResolvedBy",
                        column: x => x.ResolvedBy,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_CustomerQueries_PolicyAccounts_PolicyNo",
                        column: x => x.PolicyNo,
                        principalTable: "PolicyAccounts",
                        principalColumn: "PolicyNo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerQueries_CustomerId",
                table: "CustomerQueries",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerQueries_PolicyNo",
                table: "CustomerQueries",
                column: "PolicyNo");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerQueries_ResolvedBy",
                table: "CustomerQueries",
                column: "ResolvedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerQueries");
        }
    }
}
