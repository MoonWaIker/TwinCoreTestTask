using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwinCoreTestTask.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class HangFireTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "82aa7fd1-2a7a-4fc3-97ef-8d5a472a901f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c8273b2f-3b8a-4e65-8492-a994ac268bb1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "c17bb403-02be-479d-aeb3-7934bf026a88");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d9d3e5e7-34b3-4513-bc89-1b8dc6c90cb8");
        }
    }
}
