using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class CriaTabelaSeries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreinoId = table.Column<int>(type: "int", nullable: false),
                    ExercicioId = table.Column<int>(type: "int", nullable: false),
                    VariacaoExercicioId = table.Column<int>(type: "int", nullable: true),
                    Repeticoes = table.Column<int>(type: "int", nullable: true),
                    Peso = table.Column<float>(type: "real", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Series_Exercicios_ExercicioId",
                        column: x => x.ExercicioId,
                        principalTable: "Exercicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Series_Treinos_TreinoId",
                        column: x => x.TreinoId,
                        principalTable: "Treinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Series_VariacoesExercicios_VariacaoExercicioId",
                        column: x => x.VariacaoExercicioId,
                        principalTable: "VariacoesExercicios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Series_ExercicioId",
                table: "Series",
                column: "ExercicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_TreinoId",
                table: "Series",
                column: "TreinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_VariacaoExercicioId",
                table: "Series",
                column: "VariacaoExercicioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
