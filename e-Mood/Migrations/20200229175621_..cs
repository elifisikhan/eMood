using Microsoft.EntityFrameworkCore.Migrations;

namespace e_Mood.Migrations
{
    public partial class _ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityAttributes_Activities_ActivityForeignKey",
                table: "ActivityAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityAttributes_Activities_ActivityId",
                table: "ActivityAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityAttributes_Emotions_EmotionForeignKey",
                table: "ActivityAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityAttributes_Emotions_EmotionId",
                table: "ActivityAttributes");

            migrationBuilder.DropIndex(
                name: "IX_ActivityAttributes_ActivityForeignKey",
                table: "ActivityAttributes");

            migrationBuilder.DropIndex(
                name: "IX_ActivityAttributes_EmotionForeignKey",
                table: "ActivityAttributes");

            migrationBuilder.DropColumn(
                name: "ActivityForeignKey",
                table: "ActivityAttributes");

            migrationBuilder.DropColumn(
                name: "EmotionForeignKey",
                table: "ActivityAttributes");

            migrationBuilder.RenameColumn(
                name: "EmotionId",
                table: "ActivityAttributes",
                newName: "EmotionID");

            migrationBuilder.RenameColumn(
                name: "ActivityId",
                table: "ActivityAttributes",
                newName: "ActivityID");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityAttributes_EmotionId",
                table: "ActivityAttributes",
                newName: "IX_ActivityAttributes_EmotionID");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityAttributes_ActivityId",
                table: "ActivityAttributes",
                newName: "IX_ActivityAttributes_ActivityID");

            migrationBuilder.AlterColumn<int>(
                name: "EmotionID",
                table: "ActivityAttributes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActivityID",
                table: "ActivityAttributes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityAttributes_Activities_ActivityID",
                table: "ActivityAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityAttributes_Emotions_EmotionID",
                table: "ActivityAttributes");

            migrationBuilder.RenameColumn(
                name: "EmotionID",
                table: "ActivityAttributes",
                newName: "EmotionId");

            migrationBuilder.RenameColumn(
                name: "ActivityID",
                table: "ActivityAttributes",
                newName: "ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityAttributes_EmotionID",
                table: "ActivityAttributes",
                newName: "IX_ActivityAttributes_EmotionId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityAttributes_ActivityID",
                table: "ActivityAttributes",
                newName: "IX_ActivityAttributes_ActivityId");

            migrationBuilder.AlterColumn<int>(
                name: "EmotionId",
                table: "ActivityAttributes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "ActivityAttributes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ActivityForeignKey",
                table: "ActivityAttributes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmotionForeignKey",
                table: "ActivityAttributes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityAttributes_ActivityForeignKey",
                table: "ActivityAttributes",
                column: "ActivityForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityAttributes_EmotionForeignKey",
                table: "ActivityAttributes",
                column: "EmotionForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityAttributes_Activities_ActivityForeignKey",
                table: "ActivityAttributes",
                column: "ActivityForeignKey",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityAttributes_Activities_ActivityId",
                table: "ActivityAttributes",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityAttributes_Emotions_EmotionForeignKey",
                table: "ActivityAttributes",
                column: "EmotionForeignKey",
                principalTable: "Emotions",
                principalColumn: "EmotionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityAttributes_Emotions_EmotionId",
                table: "ActivityAttributes",
                column: "EmotionId",
                principalTable: "Emotions",
                principalColumn: "EmotionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
