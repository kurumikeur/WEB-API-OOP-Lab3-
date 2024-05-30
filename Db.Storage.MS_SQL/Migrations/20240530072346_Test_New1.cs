using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Db.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class Test_New1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tutor_Centers_IsnCenter",
                table: "Tutor");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Centers_IsnCenter",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ClientTutor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tutor",
                table: "Tutor");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Clients");

            migrationBuilder.RenameTable(
                name: "Tutor",
                newName: "Tutors");

            migrationBuilder.RenameIndex(
                name: "IX_Users_IsnCenter",
                table: "Clients",
                newName: "IX_Clients_IsnCenter");

            migrationBuilder.RenameIndex(
                name: "IX_Tutor_IsnCenter",
                table: "Tutors",
                newName: "IX_Tutors_IsnCenter");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "IsnNode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tutors",
                table: "Tutors",
                column: "IsnNode");

            migrationBuilder.CreateTable(
                name: "CenterTutors",
                columns: table => new
                {
                    IsnCenter = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnTutor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CenterIsnNode = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CenterTutors", x => new { x.IsnCenter, x.IsnTutor });
                    table.ForeignKey(
                        name: "FK_CenterTutors_Centers_CenterIsnNode",
                        column: x => x.CenterIsnNode,
                        principalTable: "Centers",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CenterTutors_Tutors_IsnTutor",
                        column: x => x.IsnTutor,
                        principalTable: "Tutors",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TutorClients",
                columns: table => new
                {
                    IsnTutor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnClient = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorClients", x => new { x.IsnTutor, x.IsnClient });
                    table.ForeignKey(
                        name: "FK_TutorClients_Clients_IsnClient",
                        column: x => x.IsnClient,
                        principalTable: "Clients",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorClients_Tutors_IsnTutor",
                        column: x => x.IsnTutor,
                        principalTable: "Tutors",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CenterTutors_CenterIsnNode",
                table: "CenterTutors",
                column: "CenterIsnNode");

            migrationBuilder.CreateIndex(
                name: "IX_CenterTutors_IsnCenter_IsnTutor",
                table: "CenterTutors",
                columns: new[] { "IsnCenter", "IsnTutor" });

            migrationBuilder.CreateIndex(
                name: "IX_CenterTutors_IsnTutor",
                table: "CenterTutors",
                column: "IsnTutor");

            migrationBuilder.CreateIndex(
                name: "IX_TutorClients_IsnClient",
                table: "TutorClients",
                column: "IsnClient");

            migrationBuilder.CreateIndex(
                name: "IX_TutorClients_IsnTutor_IsnClient",
                table: "TutorClients",
                columns: new[] { "IsnTutor", "IsnClient" });

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Centers_IsnCenter",
                table: "Clients",
                column: "IsnCenter",
                principalTable: "Centers",
                principalColumn: "IsnNode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Centers_IsnCenter",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "CenterTutors");

            migrationBuilder.DropTable(
                name: "TutorClients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tutors",
                table: "Tutors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Tutors",
                newName: "Tutor");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_Tutors_IsnCenter",
                table: "Tutor",
                newName: "IX_Tutor_IsnCenter");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_IsnCenter",
                table: "Users",
                newName: "IX_Users_IsnCenter");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tutor",
                table: "Tutor",
                column: "IsnNode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "IsnNode");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tutor_Centers_IsnCenter",
                table: "Tutor",
                column: "IsnCenter",
                principalTable: "Centers",
                principalColumn: "IsnNode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Centers_IsnCenter",
                table: "Users",
                column: "IsnCenter",
                principalTable: "Centers",
                principalColumn: "IsnNode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
