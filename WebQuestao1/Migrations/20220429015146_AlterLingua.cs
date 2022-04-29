using Microsoft.EntityFrameworkCore.Migrations;

namespace WebQuestao1.Migrations
{
    public partial class AlterLingua : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinguaEstrangeira_Candidato_CandidatoId",
                table: "LinguaEstrangeira");

            migrationBuilder.DropIndex(
                name: "IX_LinguaEstrangeira_CandidatoId",
                table: "LinguaEstrangeira");

            migrationBuilder.DropColumn(
                name: "CandidatoId",
                table: "LinguaEstrangeira");

            migrationBuilder.RenameColumn(
                name: "CandidatoId",
                table: "Candidato",
                newName: "CandidatoID");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "LinguaEstrangeira",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Candidato",
                maxLength: 17,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Candidato",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Candidato",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Candidato",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CandidatoIdioma",
                columns: table => new
                {
                    CandidatoIdiomaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidatoID = table.Column<int>(nullable: false),
                    LinguaEstrangeiraID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatoIdioma", x => x.CandidatoIdiomaID);
                    table.ForeignKey(
                        name: "FK_CandidatoIdioma_Candidato_CandidatoID",
                        column: x => x.CandidatoID,
                        principalTable: "Candidato",
                        principalColumn: "CandidatoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatoIdioma_LinguaEstrangeira_LinguaEstrangeiraID",
                        column: x => x.LinguaEstrangeiraID,
                        principalTable: "LinguaEstrangeira",
                        principalColumn: "LinguaEstrangeiraID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoIdioma_CandidatoID",
                table: "CandidatoIdioma",
                column: "CandidatoID");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoIdioma_LinguaEstrangeiraID",
                table: "CandidatoIdioma",
                column: "LinguaEstrangeiraID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatoIdioma");

            migrationBuilder.RenameColumn(
                name: "CandidatoID",
                table: "Candidato",
                newName: "CandidatoId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "LinguaEstrangeira",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "CandidatoId",
                table: "LinguaEstrangeira",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Candidato",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 17,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Candidato",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Candidato",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Candidato",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 14);

            migrationBuilder.CreateIndex(
                name: "IX_LinguaEstrangeira_CandidatoId",
                table: "LinguaEstrangeira",
                column: "CandidatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_LinguaEstrangeira_Candidato_CandidatoId",
                table: "LinguaEstrangeira",
                column: "CandidatoId",
                principalTable: "Candidato",
                principalColumn: "CandidatoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
