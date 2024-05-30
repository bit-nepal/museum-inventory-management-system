using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mims.Migrations
{
    /// <inheritdoc />
    public partial class DBOverhaul1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "period",
                table: "Artifacts");

            migrationBuilder.DropColumn(
                name: "photo_no",
                table: "Artifacts");

            migrationBuilder.DropColumn(
                name: "signature_of_receiver",
                table: "Artifacts");

            migrationBuilder.RenameColumn(
                name: "number_of_object",
                table: "Artifacts",
                newName: "number_of_objects");

            migrationBuilder.RenameColumn(
                name: "used_matriel",
                table: "Artifacts",
                newName: "time_period");

            migrationBuilder.AlterColumn<int>(
                name: "estimated_value",
                table: "Artifacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "date_of_aquisition",
                table: "Artifacts",
                type: "date",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "PrimaryPhotoId",
                table: "Artifacts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_inscription",
                table: "Artifacts",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "mode_of_acquisition",
                table: "Artifacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    image_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    image_no = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image_url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ArtifactId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.image_id);
                    table.ForeignKey(
                        name: "FK_Image_Artifacts_ArtifactId",
                        column: x => x.ArtifactId,
                        principalTable: "Artifacts",
                        principalColumn: "artifact_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Artifacts_PrimaryPhotoId",
                table: "Artifacts",
                column: "PrimaryPhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ArtifactId",
                table: "Image",
                column: "ArtifactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artifacts_Image_PrimaryPhotoId",
                table: "Artifacts",
                column: "PrimaryPhotoId",
                principalTable: "Image",
                principalColumn: "image_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artifacts_Image_PrimaryPhotoId",
                table: "Artifacts");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Artifacts_PrimaryPhotoId",
                table: "Artifacts");

            migrationBuilder.DropColumn(
                name: "PrimaryPhotoId",
                table: "Artifacts");

            migrationBuilder.DropColumn(
                name: "has_inscription",
                table: "Artifacts");

            migrationBuilder.DropColumn(
                name: "mode_of_acquisition",
                table: "Artifacts");

            migrationBuilder.RenameColumn(
                name: "number_of_objects",
                table: "Artifacts",
                newName: "number_of_object");

            migrationBuilder.RenameColumn(
                name: "time_period",
                table: "Artifacts",
                newName: "used_matriel");

            migrationBuilder.AlterColumn<string>(
                name: "estimated_value",
                table: "Artifacts",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "date_of_aquisition",
                table: "Artifacts",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "period",
                table: "Artifacts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "photo_no",
                table: "Artifacts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "signature_of_receiver",
                table: "Artifacts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
