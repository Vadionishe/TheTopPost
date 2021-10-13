using Microsoft.EntityFrameworkCore.Migrations;

namespace TheTopPost.Migrations
{
    public partial class RemoveCodeDependencyForMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_SendCodes_CodeId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_CodeId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CodeId",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Messages");

            migrationBuilder.AddColumn<long>(
                name: "CodeId",
                table: "Messages",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CodeId",
                table: "Messages",
                column: "CodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_SendCodes_CodeId",
                table: "Messages",
                column: "CodeId",
                principalTable: "SendCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
