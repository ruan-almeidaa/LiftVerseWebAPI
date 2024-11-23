using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class PopulaTabelaVariacoesExercicios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
    table: "VariacoesExercicios",
    columns: new[] { "ExercicioId", "Titulo" },
    values: new object[,]
    {
                // Supino reto
                { 1, "Supino reto com barra" },
                { 1, "Supino reto com halteres" },

                // Supino inclinado
                { 2, "Supino inclinado com barra" },
                { 2, "Supino inclinado com halteres" },

                // Crucifixo
                { 3, "Crucifixo reto com halteres" },
                { 3, "Crucifixo inclinado com halteres" },

                // Barra fixa
                { 4, "Barra fixa com pegada pronada" },
                { 4, "Barra fixa com pegada supinada" },

                // Remada curvada
                { 5, "Remada curvada com barra" },
                { 5, "Remada curvada com halteres" },

                // Pulley frontal
                { 6, "Pulley frontal com barra reta" },
                { 6, "Pulley frontal com pegador neutro" },

                // Desenvolvimento
                { 7, "Desenvolvimento com barra" },
                { 7, "Desenvolvimento com halteres" },

                // Elevação lateral
                { 8, "Elevação lateral com halteres" },

                // Elevação frontal
                { 9, "Elevação frontal com barra" },
                { 9, "Elevação frontal com halteres" },

                // Rosca direta
                { 10, "Rosca direta com barra" },
                { 10, "Rosca direta com halteres" },

                // Rosca martelo
                { 11, "Rosca martelo com halteres" },

                // Rosca concentrada
                { 12, "Rosca concentrada unilateral" },

                // Tríceps testa
                { 13, "Tríceps testa com barra" },
                { 13, "Tríceps testa com halteres" },

                // Paralelas
                { 14, "Paralelas no peso corporal" },

                // Tríceps pulley
                { 15, "Tríceps pulley com corda" },
                { 15, "Tríceps pulley com barra reta" },

                // Rosca inversa
                { 16, "Rosca inversa com barra" },

                // Rosca punho
                { 17, "Rosca punho com barra" },

                // Pronação e supinação
                { 18, "Pronação e supinação com halteres" },

                // Agachamento
                { 19, "Agachamento livre com barra" },
                { 19, "Agachamento no Smith" },

                // Leg press
                { 20, "Leg press horizontal" },

                // Cadeira extensora
                { 21, "Cadeira extensora unilateral" },

                // Stiff
                { 22, "Stiff com barra" },
                { 22, "Stiff com halteres" },

                // Mesa flexora
                { 23, "Mesa flexora bilateral" },

                // Agachamento sumô
                { 24, "Agachamento sumô com barra" },
                { 27, "Agachamento sumô com halteres" },

                // Hip thrust
                { 25, "Hip thrust com barra" },

                // Afundo
                { 26, "Afundo com halteres" },

                // Elevação plantar em pé
                { 28, "Elevação plantar em pé no Smith" },

                // Elevação plantar sentado
                { 29, "Elevação plantar sentado com halteres" },

                // Abdominal supra
                { 30, "Abdominal supra com peso" },

                // Prancha
                { 31, "Prancha isométrica" },

                // Abdominal infra
                { 32, "Abdominal infra com elevação de pernas" },

                // Hiperextensão
                { 33, "Hiperextensão com peso" },

                // Levantamento terra
                { 34, "Levantamento terra sumô" }
    });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove os registros da tabela VariacoesExercicios
            migrationBuilder.Sql("DELETE FROM VariacoesExercicios");
        }
    }
}
