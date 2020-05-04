using Microsoft.EntityFrameworkCore.Migrations;

namespace e_Mood.Migrations
{
    public partial class MyFirstMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePathString",
                table: "ImageStore",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePathString",
                table: "ImageStore");
        }
    }
}
