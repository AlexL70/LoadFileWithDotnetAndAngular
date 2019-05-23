using Microsoft.EntityFrameworkCore.Migrations;

namespace LoadFiles.Migrations
{
    public partial class FileSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Size",
                table: "Files",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "Files",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
