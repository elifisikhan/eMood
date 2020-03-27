using Microsoft.EntityFrameworkCore.Migrations;

namespace e_Mood.Migrations
{
    public partial class Secondary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityAttributes_Activities_ActivityID",
                table: "ActivityAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityAttributes_Emotions_EmotionID",
                table: "ActivityAttributes");

            migrationBuilder.AlterColumn<int>(
                name: "EmotionID",
                table: "ActivityAttributes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityID",
                table: "ActivityAttributes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityAttributes_Activities_ActivityID",
                table: "ActivityAttributes",
                column: "ActivityID",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityAttributes_Emotions_EmotionID",
                table: "ActivityAttributes",
                column: "EmotionID",
                principalTable: "Emotions",
                principalColumn: "EmotionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityAttributes_Activities_ActivityID",
                table: "ActivityAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityAttributes_Emotions_EmotionID",
                table: "ActivityAttributes");

            migrationBuilder.AlterColumn<int>(
                name: "EmotionID",
                table: "ActivityAttributes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActivityID",
                table: "ActivityAttributes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityAttributes_Activities_ActivityID",
                table: "ActivityAttributes",
                column: "ActivityID",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityAttributes_Emotions_EmotionID",
                table: "ActivityAttributes",
                column: "EmotionID",
                principalTable: "Emotions",
                principalColumn: "EmotionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
