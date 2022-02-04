using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICM.Repository.Migrations
{
    public partial class InfoBasica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Tbl_ICM_Socio",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Tbl_ICM_Socio",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tbl_ICM_InfoBasica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocioId = table.Column<int>(type: "int", nullable: false),
                    NumTelefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ICM_InfoBasica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ICM_InfoBasica_Tbl_ICM_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Tbl_ICM_Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ICM_InfoBasica_SocioId",
                table: "Tbl_ICM_InfoBasica",
                column: "SocioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_ICM_InfoBasica");

            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Tbl_ICM_Socio");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Tbl_ICM_Socio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
