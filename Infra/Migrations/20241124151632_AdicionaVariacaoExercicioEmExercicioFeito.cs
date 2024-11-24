using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaVariacaoExercicioEmExercicioFeito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VariacaoExercicioId",
                table: "ExerciciosFeitos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciciosFeitos_ExercicioId",
                table: "ExerciciosFeitos",
                column: "ExercicioId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciciosFeitos_VariacaoExercicioId",
                table: "ExerciciosFeitos",
                column: "VariacaoExercicioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciciosFeitos_Exercicios_ExercicioId",
                table: "ExerciciosFeitos",
                column: "ExercicioId",
                principalTable: "Exercicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciciosFeitos_VariacoesExercicios_VariacaoExercicioId",
                table: "ExerciciosFeitos",
                column: "VariacaoExercicioId",
                principalTable: "VariacoesExercicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciciosFeitos_Exercicios_ExercicioId",
                table: "ExerciciosFeitos");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciciosFeitos_VariacoesExercicios_VariacaoExercicioId",
                table: "ExerciciosFeitos");

            migrationBuilder.DropIndex(
                name: "IX_ExerciciosFeitos_ExercicioId",
                table: "ExerciciosFeitos");

            migrationBuilder.DropIndex(
                name: "IX_ExerciciosFeitos_VariacaoExercicioId",
                table: "ExerciciosFeitos");

            migrationBuilder.DropColumn(
                name: "VariacaoExercicioId",
                table: "ExerciciosFeitos");
        }
    }
}
