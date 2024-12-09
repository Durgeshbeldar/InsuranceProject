using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DsInsurance.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsurancePlans_InsuranceSchemes_SchemeId",
                table: "InsurancePlans");

            migrationBuilder.DropIndex(
                name: "IX_InsurancePlans_SchemeId",
                table: "InsurancePlans");

            migrationBuilder.DropColumn(
                name: "SchemeId",
                table: "InsurancePlans");

            migrationBuilder.AddColumn<Guid>(
                name: "InsurancePlanPlanId",
                table: "InsuranceSchemes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlanId",
                table: "InsuranceSchemes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "InsurancePlans",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "PlanImage",
                table: "InsurancePlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceSchemes_InsurancePlanPlanId",
                table: "InsuranceSchemes",
                column: "InsurancePlanPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceSchemes_InsurancePlans_InsurancePlanPlanId",
                table: "InsuranceSchemes",
                column: "InsurancePlanPlanId",
                principalTable: "InsurancePlans",
                principalColumn: "PlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceSchemes_InsurancePlans_InsurancePlanPlanId",
                table: "InsuranceSchemes");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceSchemes_InsurancePlanPlanId",
                table: "InsuranceSchemes");

            migrationBuilder.DropColumn(
                name: "InsurancePlanPlanId",
                table: "InsuranceSchemes");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "InsuranceSchemes");

            migrationBuilder.DropColumn(
                name: "PlanImage",
                table: "InsurancePlans");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "InsurancePlans",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SchemeId",
                table: "InsurancePlans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePlans_SchemeId",
                table: "InsurancePlans",
                column: "SchemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_InsurancePlans_InsuranceSchemes_SchemeId",
                table: "InsurancePlans",
                column: "SchemeId",
                principalTable: "InsuranceSchemes",
                principalColumn: "SchemeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
