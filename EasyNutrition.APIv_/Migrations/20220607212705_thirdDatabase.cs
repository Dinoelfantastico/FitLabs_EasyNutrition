using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyNutrition.APIv_.Migrations
{
    public partial class thirdDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "progresses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    session_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_progresses", x => x.id);
                    table.ForeignKey(
                        name: "f_k_progresses__session_session_id",
                        column: x => x.session_id,
                        principalTable: "session",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "progresses",
                columns: new[] { "id", "description", "session_id" },
                values: new object[,]
                {
                    { 1, "Bajó 4 kilos", 1 },
                    { 2, "Aumentó su masa en 3 kilos", 2 },
                    { 3, "Logró bajar mi porcentaje de grasa a un 12%", 3 },
                    { 4, "Aumentó 1kg de masa muscular", 4 },
                    { 5, "Aumentó su masa en 2 kilos", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "i_x_progresses_session_id",
                table: "progresses",
                column: "session_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "progresses");
        }
    }
}
