using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class ExcluiTabelaExercicioFeito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciciosFeitos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciciosFeitos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExercicioId = table.Column<int>(type: "int", nullable: false),
                    VariacaoExercicioId = table.Column<int>(type: "int", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peso = table.Column<float>(type: "real", nullable: true),
                    Repeticoes = table.Column<int>(type: "int", nullable: true),
                    Series = table.Column<int>(type: "int", nullable: true),
                    TreinoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciciosFeitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciciosFeitos_Exercicios_ExercicioId",
                        column: x => x.ExercicioId,
                        principalTable: "Exercicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciciosFeitos_Treinos_TreinoId",
                        column: x => x.TreinoId,
                        principalTable: "Treinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciciosFeitos_VariacoesExercicios_VariacaoExercicioId",
                        column: x => x.VariacaoExercicioId,
                        principalTable: "VariacoesExercicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciciosFeitos_ExercicioId",
                table: "ExerciciosFeitos",
                column: "ExercicioId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciciosFeitos_TreinoId",
                table: "ExerciciosFeitos",
                column: "TreinoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciciosFeitos_VariacaoExercicioId",
                table: "ExerciciosFeitos",
                column: "VariacaoExercicioId");
        }
    }
}
