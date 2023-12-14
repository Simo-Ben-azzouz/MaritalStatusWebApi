using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace patrickLearn.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "husbands",
                columns: table => new
                {
                    HusbandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDay = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CIN = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HusbandImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_husbands", x => x.HusbandId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Wife",
                columns: table => new
                {
                    WifeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<int>(type: "int", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CIN = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WifeImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HusbandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wife", x => x.WifeId);
                    table.ForeignKey(
                        name: "FK_Wife_husbands_HusbandId",
                        column: x => x.HusbandId,
                        principalTable: "husbands",
                        principalColumn: "HusbandId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Chilldren",
                columns: table => new
                {
                    ChilldrenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDay = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ChilldImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WifeId = table.Column<int>(type: "int", nullable: false),
                    HusbandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chilldren", x => x.ChilldrenId);
                    table.ForeignKey(
                        name: "FK_Chilldren_Wife_WifeId",
                        column: x => x.WifeId,
                        principalTable: "Wife",
                        principalColumn: "WifeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chilldren_husbands_HusbandId",
                        column: x => x.HusbandId,
                        principalTable: "husbands",
                        principalColumn: "HusbandId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Chilldren_HusbandId",
                table: "Chilldren",
                column: "HusbandId");

            migrationBuilder.CreateIndex(
                name: "IX_Chilldren_WifeId",
                table: "Chilldren",
                column: "WifeId");

            migrationBuilder.CreateIndex(
                name: "IX_Wife_HusbandId",
                table: "Wife",
                column: "HusbandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chilldren");

            migrationBuilder.DropTable(
                name: "Wife");

            migrationBuilder.DropTable(
                name: "husbands");
        }
    }
}
