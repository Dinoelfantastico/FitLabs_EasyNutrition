using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyNutrition.APIv_.Migrations
{
    public partial class thirdDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "diets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    session_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_diets", x => x.id);
                    table.ForeignKey(
                        name: "f_k_diets__session_session_id",
                        column: x => x.session_id,
                        principalTable: "session",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "diets",
                columns: new[] { "id", "description", "session_id", "title" },
                values: new object[,]
                {
                    { 1, "Lunes: x Martes: x Miercoles: x", 1, "Dieta Vegetariana" },
                    { 2, "Lunes: x Martes: x Miercoles: x", 2, "Dieta para aumentar masa musuclar" },
                    { 3, "Lunes: x Martes: x Miercoles: x", 3, "Dieta miniCut" },
                    { 4, "Lunes: x Martes: x Miercoles: x", 4, "Dieta Tonificación Muscular" },
                    { 5, "Lunes: x Martes: x Miercoles: x", 5, "Dieta definición" }
                });

            migrationBuilder.CreateIndex(
            name: "i_x_diets_session_id",
            table: "diets",
            column: "session_id");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "diets");
        }
    }
}
