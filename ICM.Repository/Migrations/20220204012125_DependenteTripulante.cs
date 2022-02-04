using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICM.Repository.Migrations
{
    public partial class DependenteTripulante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_ICM_Dependente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocioId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ICM_Dependente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ICM_Dependente_Tbl_ICM_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Tbl_ICM_Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ICM_TituloSocio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumTituloSocio = table.Column<int>(type: "int", nullable: false),
                    SocioId = table.Column<int>(type: "int", nullable: false),
                    EmbarcacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ICM_TituloSocio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ICM_TituloSocio_Tbl_ICM_Embarcacao_EmbarcacaoId",
                        column: x => x.EmbarcacaoId,
                        principalTable: "Tbl_ICM_Embarcacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_ICM_TituloSocio_Tbl_ICM_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Tbl_ICM_Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ICM_Tripulante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmbarcacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ICM_Tripulante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ICM_Tripulante_Tbl_ICM_Embarcacao_EmbarcacaoId",
                        column: x => x.EmbarcacaoId,
                        principalTable: "Tbl_ICM_Embarcacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ICM_Dependente_SocioId",
                table: "Tbl_ICM_Dependente",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ICM_TituloSocio_EmbarcacaoId",
                table: "Tbl_ICM_TituloSocio",
                column: "EmbarcacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ICM_TituloSocio_SocioId",
                table: "Tbl_ICM_TituloSocio",
                column: "SocioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ICM_Tripulante_EmbarcacaoId",
                table: "Tbl_ICM_Tripulante",
                column: "EmbarcacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_ICM_Dependente");

            migrationBuilder.DropTable(
                name: "Tbl_ICM_TituloSocio");

            migrationBuilder.DropTable(
                name: "Tbl_ICM_Tripulante");
        }
    }
}
