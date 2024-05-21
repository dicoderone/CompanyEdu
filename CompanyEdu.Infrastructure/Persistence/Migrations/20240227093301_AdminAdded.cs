using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyEdu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdminAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "PasswordHash", "Role", "UserName" },
                values: new object[] { 1, "Otabek Alijonov", "22C5D20222F190966E71921E074D6EF254616C3536ABC192CA111D25E707B46592717C70BE06592997A73F13ED2884FF63775C78A2FA73CFDD6F7A3DCF296086", 1, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
