using LoadFiles.Core.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoadFiles.Migrations
{
    public partial class FillInUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO [dbo].[Users] ([{nameof(User.Name)}]) VALUES ('User1')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Users] ([{nameof(User.Name)}]) VALUES ('User2')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Users] ([{nameof(User.Name)}]) VALUES ('User3')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Users] ([{nameof(User.Name)}]) VALUES ('User4')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[Users] ([{nameof(User.Name)}]) VALUES ('User5')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[Users]");
        }
    }
}
