using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketManagement.App.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RezervasyonYapilacakKisiSayisi = table.Column<int>(type: "int", nullable: false),
                    KisilerFarkliVagonlaraYerlestirilebilir = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tickets_trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "trains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vagons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kapasite = table.Column<int>(type: "int", nullable: false),
                    DoluKoltukAdet = table.Column<int>(type: "int", nullable: false),
                    TrainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vagons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vagons_trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "trains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tickets_TrainId",
                table: "tickets",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_vagons_TrainId",
                table: "vagons",
                column: "TrainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "vagons");

            migrationBuilder.DropTable(
                name: "trains");
        }
    }
}
