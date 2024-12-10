using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DsInsurance.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_States_StateId",
                table: "Addresses");

            migrationBuilder.AddColumn<Guid>(
                name: "PolicyAccountPolicyNo",
                table: "Nominees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PlanId",
                table: "InsuranceSchemes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Town",
                table: "Addresses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "StateId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Addresses",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<Guid>(
                name: "CityId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PolicyAccounts",
                columns: table => new
                {
                    PolicyNo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchemeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SumAssured = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PremiumType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyTerm = table.Column<int>(type: "int", nullable: false),
                    PremiumAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InstallmentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancellationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaturityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AgentId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyAccounts", x => x.PolicyNo);
                    table.ForeignKey(
                        name: "FK_PolicyAccounts_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId");
                    table.ForeignKey(
                        name: "FK_PolicyAccounts_Agents_AgentId1",
                        column: x => x.AgentId1,
                        principalTable: "Agents",
                        principalColumn: "AgentId");
                    table.ForeignKey(
                        name: "FK_PolicyAccounts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_PolicyAccounts_InsuranceSchemes_SchemeId",
                        column: x => x.SchemeId,
                        principalTable: "InsuranceSchemes",
                        principalColumn: "SchemeId");
                });

            migrationBuilder.CreateTable(
                name: "Installment",
                columns: table => new
                {
                    InstallmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyNo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AmountDue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installment", x => x.InstallmentId);
                    table.ForeignKey(
                        name: "FK_Installment_PolicyAccounts_PolicyNo",
                        column: x => x.PolicyNo,
                        principalTable: "PolicyAccounts",
                        principalColumn: "PolicyNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolicyCoverage",
                columns: table => new
                {
                    CoverageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyNo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoverageType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CoverageLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeductibleAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PremiumImpact = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyCoverage", x => x.CoverageId);
                    table.ForeignKey(
                        name: "FK_PolicyCoverage_PolicyAccounts_PolicyNo",
                        column: x => x.PolicyNo,
                        principalTable: "PolicyAccounts",
                        principalColumn: "PolicyNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolicyTransaction",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyNo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyTransaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_PolicyTransaction_PolicyAccounts_PolicyNo",
                        column: x => x.PolicyNo,
                        principalTable: "PolicyAccounts",
                        principalColumn: "PolicyNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nominees_PolicyAccountPolicyNo",
                table: "Nominees",
                column: "PolicyAccountPolicyNo");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceSchemes_PlanId",
                table: "InsuranceSchemes",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Installment_PolicyNo",
                table: "Installment",
                column: "PolicyNo");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyAccounts_AgentId",
                table: "PolicyAccounts",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyAccounts_AgentId1",
                table: "PolicyAccounts",
                column: "AgentId1");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyAccounts_CustomerId",
                table: "PolicyAccounts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyAccounts_SchemeId",
                table: "PolicyAccounts",
                column: "SchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyCoverage_PolicyNo",
                table: "PolicyCoverage",
                column: "PolicyNo");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyTransaction_PolicyNo",
                table: "PolicyTransaction",
                column: "PolicyNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_States_StateId",
                table: "Addresses",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceSchemes_InsurancePlans_PlanId",
                table: "InsuranceSchemes",
                column: "PlanId",
                principalTable: "InsurancePlans",
                principalColumn: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nominees_PolicyAccounts_PolicyAccountPolicyNo",
                table: "Nominees",
                column: "PolicyAccountPolicyNo",
                principalTable: "PolicyAccounts",
                principalColumn: "PolicyNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_States_StateId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceSchemes_InsurancePlans_PlanId",
                table: "InsuranceSchemes");

            migrationBuilder.DropForeignKey(
                name: "FK_Nominees_PolicyAccounts_PolicyAccountPolicyNo",
                table: "Nominees");

            migrationBuilder.DropTable(
                name: "Installment");

            migrationBuilder.DropTable(
                name: "PolicyCoverage");

            migrationBuilder.DropTable(
                name: "PolicyTransaction");

            migrationBuilder.DropTable(
                name: "PolicyAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Nominees_PolicyAccountPolicyNo",
                table: "Nominees");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceSchemes_PlanId",
                table: "InsuranceSchemes");

            migrationBuilder.DropColumn(
                name: "PolicyAccountPolicyNo",
                table: "Nominees");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlanId",
                table: "InsuranceSchemes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Town",
                table: "Addresses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<Guid>(
                name: "StateId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Addresses",
                type: "bit",
                maxLength: 10,
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CityId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_States_StateId",
                table: "Addresses",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId");
        }
    }
}
