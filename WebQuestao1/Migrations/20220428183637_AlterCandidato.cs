using Microsoft.EntityFrameworkCore.Migrations;

namespace WebQuestao1.Migrations
{
    public partial class AlterCandidato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Candidato",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "HorarioTrabalho",
                columns: table => new
                {
                    HorarioTrabalhoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaSemana = table.Column<int>(nullable: false),
                    HoraInicio = table.Column<string>(nullable: true),
                    HoraFim = table.Column<string>(nullable: true),
                    TempoDescanso = table.Column<int>(nullable: false),
                    CargaHoraria = table.Column<int>(nullable: false),
                    CandidatoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioTrabalho", x => x.HorarioTrabalhoID);
                    table.ForeignKey(
                        name: "FK_HorarioTrabalho_Candidato_CandidatoID",
                        column: x => x.CandidatoID,
                        principalTable: "Candidato",
                        principalColumn: "CandidatoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HorarioTrabalho_CandidatoID",
                table: "HorarioTrabalho",
                column: "CandidatoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorarioTrabalho");

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Candidato",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);
        }
    }
}
