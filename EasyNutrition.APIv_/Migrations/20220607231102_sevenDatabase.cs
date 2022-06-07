using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyNutrition.APIv_.Migrations
{
    public partial class sevenDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "complaint",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_complaint", x => x.id);
                    table.ForeignKey(
                        name: "f_k_complaint__users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "complaint",
                columns: new[] { "id", "description", "user_id" },
                values: new object[] { 1, "Descripcion de prueba complaint", 1 });

            migrationBuilder.InsertData(
                table: "complaint",
                columns: new[] { "id", "description", "user_id" },
                values: new object[] { 2, "Descripcion de prueba complaint 2", 2 });

            migrationBuilder.InsertData(
                table: "complaint",
                columns: new[] { "id", "description", "user_id" },
                values: new object[] { 3, "Descripcion de prueba complaint 3 ", 3 });

            migrationBuilder.CreateIndex(
                name: "i_x_complaint_user_id",
                table: "complaint",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "complaint");
        }
    }
}
