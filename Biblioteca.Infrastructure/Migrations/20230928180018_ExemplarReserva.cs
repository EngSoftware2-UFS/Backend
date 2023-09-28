using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExemplarReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_exemplares_reservas_ReservaId",
                table: "exemplares");

            migrationBuilder.DropForeignKey(
                name: "fk_obras_generos",
                table: "obras");

            migrationBuilder.DropIndex(
                name: "IX_exemplares_ReservaId",
                table: "exemplares");

            migrationBuilder.DropColumn(
                name: "ReservaId",
                table: "exemplares");

            migrationBuilder.CreateTable(
                name: "reservaExemplar",
                columns: table => new
                {
                    reservaId = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    exemplarId = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.reservaId, x.exemplarId });
                    table.ForeignKey(
                        name: "fk_reserva_has_exemplares_exemplares1",
                        column: x => x.exemplarId,
                        principalTable: "exemplares",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reserva_has_exemplares_reserva1",
                        column: x => x.reservaId,
                        principalTable: "reservas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "fk_reserva_has_exemplares_exemplares1",
                table: "reservaExemplar",
                column: "exemplarId");

            migrationBuilder.AddForeignKey(
                name: "FK_obras_generos_generoId",
                table: "obras",
                column: "generoId",
                principalTable: "generos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_obras_generos_generoId",
                table: "obras");

            migrationBuilder.DropTable(
                name: "reservaExemplar");

            migrationBuilder.AddColumn<ulong>(
                name: "ReservaId",
                table: "exemplares",
                type: "bigint unsigned",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_exemplares_ReservaId",
                table: "exemplares",
                column: "ReservaId");

            migrationBuilder.AddForeignKey(
                name: "FK_exemplares_reservas_ReservaId",
                table: "exemplares",
                column: "ReservaId",
                principalTable: "reservas",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_obras_generos",
                table: "obras",
                column: "generoId",
                principalTable: "generos",
                principalColumn: "id");
        }
    }
}
