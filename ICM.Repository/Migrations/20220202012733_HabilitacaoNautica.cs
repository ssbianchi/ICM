using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICM.Repository.Migrations
{
    public partial class HabilitacaoNautica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_ICM_HabilitacaoNautica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocioId = table.Column<int>(type: "int", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoHabilitacao = table.Column<int>(type: "int", nullable: false),
                    NumHabilitacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ICM_HabilitacaoNautica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ICM_HabilitacaoNautica_Tbl_ICM_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Tbl_ICM_Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ICM_HabilitacaoNautica_SocioId",
                table: "Tbl_ICM_HabilitacaoNautica",
                column: "SocioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_ICM_HabilitacaoNautica");
        }
    }
}
