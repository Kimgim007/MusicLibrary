using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    public partial class Add_Singer_Audio_Tag : Migration
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
                name: "AudioFileSingers",
                columns: table => new
                {
                    AudioFileSingerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AudioFileId = table.Column<int>(type: "int", nullable: false),
                    SingerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioFileSingers", x => x.AudioFileSingerId);
                    table.ForeignKey(
                        name: "FK_AudioFileSingers_AudioFiles_AudioFileId",
                        column: x => x.AudioFileId,
                        principalTable: "AudioFiles",
                        principalColumn: "AudioFileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AudioFileSingers_Singers_SingerId",
                        column: x => x.SingerId,
                        principalTable: "Singers",
                        principalColumn: "SingerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AudioFileTags",
                columns: table => new
                {
                    AudioFileTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AudioFileId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioFileTags", x => x.AudioFileTagId);
                    table.ForeignKey(
                        name: "FK_AudioFileTags_AudioFiles_AudioFileId",
                        column: x => x.AudioFileId,
                        principalTable: "AudioFiles",
                        principalColumn: "AudioFileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AudioFileTags_Tags_TagId",
                        column: x => x.TagId,
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
                name: "IX_AudioFileSingers_AudioFileId",
                table: "AudioFileSingers",
                column: "AudioFileId");

            migrationBuilder.CreateIndex(
                name: "IX_AudioFileSingers_SingerId",
                table: "AudioFileSingers",
                column: "SingerId");

            migrationBuilder.CreateIndex(
                name: "IX_AudioFileTags_AudioFileId",
                table: "AudioFileTags",
                column: "AudioFileId");

            migrationBuilder.CreateIndex(
                name: "IX_AudioFileTags_TagId",
                table: "AudioFileTags",
                column: "TagId");

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
                name: "AudioFileSingers");

            migrationBuilder.DropTable(
                name: "AudioFileTags");

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
