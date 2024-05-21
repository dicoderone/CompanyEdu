using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyEdu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAdmin2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "0973AE8A344EBED06413F630F8E9B2DE0BAEFD310D226D6EFC123FC7E98D66BB006585AAFD5DA15EAB0E473A8F03192B651B09EA0B71E758931219543753CBA1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "3627909a29c31381a071ec27f7c9ca97726182aed29a7ddd2e54353322cfb30abb9e3a6df2ac2c20fe23436311d678564d0c8d305930575f60e2d3d048184d79");
        }
    }
}
