using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReservasView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW ReservasView
            AS
                SELECT r.id, r.dataReserva, r.status, o.titulo, r.clienteId
                FROM reservaExemplar re
                JOIN reservas r ON (re.reservaId = r.id)
                JOIN exemplares e ON (re.exemplarId = e.id)
                JOIN obras o ON (o.id = e.obraId)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW ReservasView");
        }
    }
}
