using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class PopulaTabelaExercicios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inserir dados na tabela Exercicios
            migrationBuilder.InsertData(
                table: "Exercicios",
                columns: new[] { "GrupoMuscularId", "Titulo" },
                values: new object[,]
                {
                // Peitoral
                { 1, "Supino reto" },
                { 1, "Supino inclinado" },
                { 1, "Crucifixo" },

                // Costas
                { 2, "Barra fixa" },
                { 2, "Remada curvada" },
                { 2, "Pulley frontal" },

                // Ombros
                { 3, "Desenvolvimento" },
                { 3, "Elevação lateral" },
                { 3, "Elevação frontal" },

                // Bíceps
                { 4, "Rosca direta" },
                { 4, "Rosca martelo" },
                { 4, "Rosca concentrada" },

                // Tríceps
                { 5, "Tríceps testa" },
                { 5, "Paralelas" },
                { 5, "Tríceps pulley" },

                // Antebraço
                { 6, "Rosca inversa" },
                { 6, "Rosca punho" },
                { 6, "Pronação e supinação" },

                // Quadríceps
                { 7, "Agachamento" },
                { 7, "Leg press" },
                { 7, "Cadeira extensora" },

                // Posteriores da coxa
                { 8, "Stiff" },
                { 8, "Mesa flexora" },
                { 8, "Agachamento sumô" },

                // Glúteos
                { 9, "Hip thrust" },
                { 9, "Afundo" },
                { 9, "Agachamento sumô" },

                // Panturrilhas
                { 10, "Elevação plantar em pé" },
                { 10, "Elevação plantar sentado" },

                // Abdome
                { 11, "Abdominal supra" },
                { 11, "Prancha" },
                { 11, "Abdominal infra" },

                // Lombar
                { 12, "Hiperextensão" },
                { 12, "Levantamento terra" }
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remover todos os registros da tabela Exercicios
            migrationBuilder.Sql("DELETE FROM Exercicios");
        }
    }
}
