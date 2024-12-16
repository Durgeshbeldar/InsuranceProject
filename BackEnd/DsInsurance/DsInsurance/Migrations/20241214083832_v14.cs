using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DsInsurance.Migrations
{
    /// <inheritdoc />
    public partial class v14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InstallmentId",
                table: "PolicyTransactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "PolicyTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PolicyTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Installments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstallmentId",
                table: "PolicyTransactions");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "PolicyTransactions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PolicyTransactions");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Installments");
        }
    }
}
