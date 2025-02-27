using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vestibular.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Inscricao_IdCandidato",
                table: "Inscricao",
                column: "IdCandidato");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricao_IdCurso",
                table: "Inscricao",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricao_IdProcessoSeletivo",
                table: "Inscricao",
                column: "IdProcessoSeletivo");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscricao_Candidato_IdCandidato",
                table: "Inscricao",
                column: "IdCandidato",
                principalTable: "Candidato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscricao_Curso_IdCurso",
                table: "Inscricao",
                column: "IdCurso",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscricao_ProcessoSeletivo_IdProcessoSeletivo",
                table: "Inscricao",
                column: "IdProcessoSeletivo",
                principalTable: "ProcessoSeletivo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscricao_Candidato_IdCandidato",
                table: "Inscricao");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscricao_Curso_IdCurso",
                table: "Inscricao");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscricao_ProcessoSeletivo_IdProcessoSeletivo",
                table: "Inscricao");

            migrationBuilder.DropIndex(
                name: "IX_Inscricao_IdCandidato",
                table: "Inscricao");

            migrationBuilder.DropIndex(
                name: "IX_Inscricao_IdCurso",
                table: "Inscricao");

            migrationBuilder.DropIndex(
                name: "IX_Inscricao_IdProcessoSeletivo",
                table: "Inscricao");
        }
    }
}
