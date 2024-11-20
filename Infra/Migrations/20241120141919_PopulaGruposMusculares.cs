using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class PopulaGruposMusculares : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GruposMusculares",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Peitoral" },
                    { 2, "Costas" },
                    { 3, "Ombros" },
                    { 4, "Bíceps" },
                    { 5, "Tríceps" },
                    { 6, "Antebraço" },
                    { 7, "Quadríceps" },
                    { 8, "Posteriores da coxa" },
                    { 9, "Glúteos" },
                    { 10, "Panturrilhas" },
                    { 11, "Abdome" },
                    { 12, "Lombar" }
                }
            ); 

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GruposMusculares",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
        }
    }
}
