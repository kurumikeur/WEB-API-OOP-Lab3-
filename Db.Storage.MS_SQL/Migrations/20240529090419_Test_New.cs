using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Db.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class Test_New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Tutor",
                columns: table => new
                {
                    IsnNode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnCenter = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutor", x => x.IsnNode);
                    table.ForeignKey(
                        name: "FK_Tutor_Centers_IsnCenter",
                        column: x => x.IsnCenter,
                        principalTable: "Centers",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientTutor",
                columns: table => new
                {
                    ClientsIsnNode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TutorsIsnNode = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTutor", x => new { x.ClientsIsnNode, x.TutorsIsnNode });
                    table.ForeignKey(
                        name: "FK_ClientTutor_Tutor_TutorsIsnNode",
                        column: x => x.TutorsIsnNode,
                        principalTable: "Tutor",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientTutor_Users_ClientsIsnNode",
                        column: x => x.ClientsIsnNode,
                        principalTable: "Users",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientTutor_TutorsIsnNode",
                table: "ClientTutor",
                column: "TutorsIsnNode");

            migrationBuilder.CreateIndex(
                name: "IX_Tutor_IsnCenter",
                table: "Tutor",
                column: "IsnCenter");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientTutor");

            migrationBuilder.DropTable(
                name: "Tutor");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Users");
        }
    }
}
