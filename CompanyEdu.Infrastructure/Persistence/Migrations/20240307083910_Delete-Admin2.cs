using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyEdu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteAdmin2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "FullName",
                value: "Kali Admin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "FullName",
                value: "Otabek Alijonov");
        }
    }
}
