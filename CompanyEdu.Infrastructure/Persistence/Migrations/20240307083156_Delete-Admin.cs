using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyEdu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "3627909a29c31381a071ec27f7c9ca97726182aed29a7ddd2e54353322cfb30abb9e3a6df2ac2c20fe23436311d678564d0c8d305930575f60e2d3d048184d79");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "f2dc0119c9dac46f49d3b7d0be1f61adf7619b770ff076fb11a2f61ff3fcba6b68d224588c4983670da31b33b4efabd448e38a2fda508622cc33ff8304ddf49c");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "PasswordHash", "Role", "UserName" },
                values: new object[] { 2, "Kallix Jace", "1234567", 1, "Admin2" });
        }
    }
}
