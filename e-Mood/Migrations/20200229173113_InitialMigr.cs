using Microsoft.EntityFrameworkCore.Migrations;

namespace e_Mood.Migrations
{
    public partial class InitialMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "Emotions",
                columns: table => new
                {
                    EmotionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmotionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emotions", x => x.EmotionId);
                });

            migrationBuilder.CreateTable(
                name: "ActivityAttributes",
                columns: table => new
                {
                    ActivityAttributeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Rate = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    InInside = table.Column<bool>(nullable: false),
                    EmotionForeignKey = table.Column<int>(nullable: false),
                    EmotionId = table.Column<int>(nullable: true),
                    ActivityForeignKey = table.Column<int>(nullable: false),
                    ActivityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityAttributes", x => x.ActivityAttributeID);
                    table.ForeignKey(
                        name: "FK_ActivityAttributes_Activities_ActivityForeignKey",
                        column: x => x.ActivityForeignKey,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityAttributes_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityAttributes_Emotions_EmotionForeignKey",
                        column: x => x.EmotionForeignKey,
                        principalTable: "Emotions",
                        principalColumn: "EmotionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityAttributes_Emotions_EmotionId",
                        column: x => x.EmotionId,
                        principalTable: "Emotions",
                        principalColumn: "EmotionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityEmotions",
                columns: table => new
                {
                    ActivityID = table.Column<int>(nullable: false),
                    EmotionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityEmotions", x => new { x.ActivityID, x.EmotionID });
                    table.ForeignKey(
                        name: "FK_ActivityEmotions_Activities_ActivityID",
                        column: x => x.ActivityID,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityEmotions_Emotions_EmotionID",
                        column: x => x.EmotionID,
                        principalTable: "Emotions",
                        principalColumn: "EmotionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityAttributes_ActivityForeignKey",
                table: "ActivityAttributes",
                column: "ActivityForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityAttributes_ActivityId",
                table: "ActivityAttributes",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityAttributes_EmotionForeignKey",
                table: "ActivityAttributes",
                column: "EmotionForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityAttributes_EmotionId",
                table: "ActivityAttributes",
                column: "EmotionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEmotions_EmotionID",
                table: "ActivityEmotions",
                column: "EmotionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityAttributes");

            migrationBuilder.DropTable(
                name: "ActivityEmotions");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Emotions");
        }
    }
}
