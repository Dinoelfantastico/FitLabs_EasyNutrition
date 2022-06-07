using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyNutrition.APIv_.Migrations
{
    public partial class FiveDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "experience",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_experience", x => x.id);
                    table.ForeignKey(
                        name: "f_k_experience__users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "experience",
                columns: new[] { "id", "description", "name", "user_id" },
                values: new object[] { 1, "Estoy notando los resultados positivos", "Augusto", 1 });

            migrationBuilder.InsertData(
                table: "experience",
                columns: new[] { "id", "description", "name", "user_id" },
                values: new object[] { 4, "Excelentes resultados por las dietas", "Hernesto", 2 });

            migrationBuilder.CreateIndex(
                name: "i_x_experience_user_id",
                table: "experience",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "experience");
        }
    }
}
