using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DsInsurance.Migrations
{
    /// <inheritdoc />
    public partial class v30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_InsuranceSchemes_SchemeName",
                table: "InsuranceSchemes",
                column: "SchemeName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InsuranceSchemes_SchemeName",
                table: "InsuranceSchemes");
        }
    }
}
