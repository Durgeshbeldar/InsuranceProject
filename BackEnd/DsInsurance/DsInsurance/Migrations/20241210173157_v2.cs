using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DsInsurance.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Addresses_AddressId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Installment_PolicyAccounts_PolicyNo",
                table: "Installment");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicyCoverage_PolicyAccounts_PolicyNo",
                table: "PolicyCoverage");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicyTransaction_PolicyAccounts_PolicyNo",
                table: "PolicyTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PolicyTransaction",
                table: "PolicyTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PolicyCoverage",
                table: "PolicyCoverage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Installment",
                table: "Installment");

            migrationBuilder.DropIndex(
                name: "IX_Installment_PolicyNo",
                table: "Installment");

            migrationBuilder.RenameTable(
                name: "PolicyTransaction",
                newName: "PolicyTransactions");

            migrationBuilder.RenameTable(
                name: "PolicyCoverage",
                newName: "PolicyCoverages");

            migrationBuilder.RenameTable(
                name: "Installment",
                newName: "Installments");

            migrationBuilder.RenameIndex(
                name: "IX_PolicyTransaction_PolicyNo",
                table: "PolicyTransactions",
                newName: "IX_PolicyTransactions_PolicyNo");

            migrationBuilder.RenameIndex(
                name: "IX_PolicyCoverage_PolicyNo",
                table: "PolicyCoverages",
                newName: "IX_PolicyCoverages_PolicyNo");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlanId",
                table: "InsuranceSchemes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCommission",
                table: "Agents",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "Rating",
                table: "Agents",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<bool>(
                name: "KycVerified",
                table: "Agents",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Agents",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActiveSince",
                table: "Agents",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "PolicyAccountPolicyNo",
                table: "Installments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PolicyTransactions",
                table: "PolicyTransactions",
                column: "TransactionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PolicyCoverages",
                table: "PolicyCoverages",
                column: "CoverageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Installments",
                table: "Installments",
                column: "InstallmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Installments_PolicyAccountPolicyNo",
                table: "Installments",
                column: "PolicyAccountPolicyNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Addresses_AddressId",
                table: "Agents",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Installments_PolicyAccounts_PolicyAccountPolicyNo",
                table: "Installments",
                column: "PolicyAccountPolicyNo",
                principalTable: "PolicyAccounts",
                principalColumn: "PolicyNo");

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyCoverages_PolicyAccounts_PolicyNo",
                table: "PolicyCoverages",
                column: "PolicyNo",
                principalTable: "PolicyAccounts",
                principalColumn: "PolicyNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyTransactions_PolicyAccounts_PolicyNo",
                table: "PolicyTransactions",
                column: "PolicyNo",
                principalTable: "PolicyAccounts",
                principalColumn: "PolicyNo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Addresses_AddressId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Installments_PolicyAccounts_PolicyAccountPolicyNo",
                table: "Installments");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicyCoverages_PolicyAccounts_PolicyNo",
                table: "PolicyCoverages");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicyTransactions_PolicyAccounts_PolicyNo",
                table: "PolicyTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PolicyTransactions",
                table: "PolicyTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PolicyCoverages",
                table: "PolicyCoverages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Installments",
                table: "Installments");

            migrationBuilder.DropIndex(
                name: "IX_Installments_PolicyAccountPolicyNo",
                table: "Installments");

            migrationBuilder.DropColumn(
                name: "PolicyAccountPolicyNo",
                table: "Installments");

            migrationBuilder.RenameTable(
                name: "PolicyTransactions",
                newName: "PolicyTransaction");

            migrationBuilder.RenameTable(
                name: "PolicyCoverages",
                newName: "PolicyCoverage");

            migrationBuilder.RenameTable(
                name: "Installments",
                newName: "Installment");

            migrationBuilder.RenameIndex(
                name: "IX_PolicyTransactions_PolicyNo",
                table: "PolicyTransaction",
                newName: "IX_PolicyTransaction_PolicyNo");

            migrationBuilder.RenameIndex(
                name: "IX_PolicyCoverages_PolicyNo",
                table: "PolicyCoverage",
                newName: "IX_PolicyCoverage_PolicyNo");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlanId",
                table: "InsuranceSchemes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCommission",
                table: "Agents",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Rating",
                table: "Agents",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "KycVerified",
                table: "Agents",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Agents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActiveSince",
                table: "Agents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PolicyTransaction",
                table: "PolicyTransaction",
                column: "TransactionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PolicyCoverage",
                table: "PolicyCoverage",
                column: "CoverageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Installment",
                table: "Installment",
                column: "InstallmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Installment_PolicyNo",
                table: "Installment",
                column: "PolicyNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Addresses_AddressId",
                table: "Agents",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Installment_PolicyAccounts_PolicyNo",
                table: "Installment",
                column: "PolicyNo",
                principalTable: "PolicyAccounts",
                principalColumn: "PolicyNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyCoverage_PolicyAccounts_PolicyNo",
                table: "PolicyCoverage",
                column: "PolicyNo",
                principalTable: "PolicyAccounts",
                principalColumn: "PolicyNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyTransaction_PolicyAccounts_PolicyNo",
                table: "PolicyTransaction",
                column: "PolicyNo",
                principalTable: "PolicyAccounts",
                principalColumn: "PolicyNo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
