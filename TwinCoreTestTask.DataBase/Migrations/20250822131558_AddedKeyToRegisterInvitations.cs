using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwinCoreTestTask.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class AddedKeyToRegisterInvitations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "RegisterInvitations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegisterInvitations",
                table: "RegisterInvitations",
                column: "Token");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "b772b64d-b3bf-43f3-8af0-86d31426fb76");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6021240f-f480-4907-999f-bc0712659c24");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterInvitations_Email",
                table: "RegisterInvitations",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RegisterInvitations",
                table: "RegisterInvitations");

            migrationBuilder.DropIndex(
                name: "IX_RegisterInvitations_Email",
                table: "RegisterInvitations");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "RegisterInvitations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}
