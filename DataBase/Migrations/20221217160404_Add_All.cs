using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    public partial class Add_All : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AudioFiles",
                columns: table => new
                {
                    AudioFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioFiles", x => x.AudioFileId);
                });

            migrationBuilder.CreateTable(
                name: "Singers",
                columns: table => new
                {
                    SingerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotoSinger = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Singers", x => x.SingerId);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "AudioFileSinger",
                columns: table => new
                {
                    AudioFilesAudioFileId = table.Column<int>(type: "int", nullable: false),
                    SingersSingerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioFileSinger", x => new { x.AudioFilesAudioFileId, x.SingersSingerId });
                    table.ForeignKey(
                        name: "FK_AudioFileSinger_AudioFiles_AudioFilesAudioFileId",
                        column: x => x.AudioFilesAudioFileId,
                        principalTable: "AudioFiles",
                        principalColumn: "AudioFileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AudioFileSinger_Singers_SingersSingerId",
                        column: x => x.SingersSingerId,
                        principalTable: "Singers",
                        principalColumn: "SingerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AudioFileTag",
                columns: table => new
                {
                    AudioFilesAudioFileId = table.Column<int>(type: "int", nullable: false),
                    TagsTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioFileTag", x => new { x.AudioFilesAudioFileId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_AudioFileTag_AudioFiles_AudioFilesAudioFileId",
                        column: x => x.AudioFilesAudioFileId,
                        principalTable: "AudioFiles",
                        principalColumn: "AudioFileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AudioFileTag_Tags_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SingerTags",
                columns: table => new
                {
                    SingerTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SingerId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingerTags", x => x.SingerTagId);
                    table.ForeignKey(
                        name: "FK_SingerTags_Singers_SingerId",
                        column: x => x.SingerId,
                        principalTable: "Singers",
                        principalColumn: "SingerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SingerTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AudioFileSinger_SingersSingerId",
                table: "AudioFileSinger",
                column: "SingersSingerId");

            migrationBuilder.CreateIndex(
                name: "IX_AudioFileTag_TagsTagId",
                table: "AudioFileTag",
                column: "TagsTagId");

            migrationBuilder.CreateIndex(
                name: "IX_Singers_Nickname",
                table: "Singers",
                column: "Nickname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SingerTags_SingerId",
                table: "SingerTags",
                column: "SingerId");

            migrationBuilder.CreateIndex(
                name: "IX_SingerTags_TagId",
                table: "SingerTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AudioFileSinger");

            migrationBuilder.DropTable(
                name: "AudioFileTag");

            migrationBuilder.DropTable(
                name: "SingerTags");

            migrationBuilder.DropTable(
                name: "AudioFiles");

            migrationBuilder.DropTable(
                name: "Singers");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
