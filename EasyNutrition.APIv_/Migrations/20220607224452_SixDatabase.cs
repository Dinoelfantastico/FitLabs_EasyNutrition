using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyNutrition.APIv_.Migrations
{
    public partial class SixDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "schedules",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start_at = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    end_at = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_schedules", x => x.id);
                    table.ForeignKey(
                        name: "f_k_schedules__users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "schedules",
                columns: new[] { "id", "end_at", "start_at", "state", "user_id" },
                values: new object[,]
                {
                    { 1, "Friday, February 22, 2019 2:40:55 PM", "Friday, February 22, 2019 2:00:55 PM", true, 1 },
                    { 2, "Friday, February 23, 2019 6:40:55 PM", "Friday, February 23, 2019 5:00:55 PM", true, 2 },
                    { 3, "Friday, February 24, 2019 8:40:55 PM", "Friday, February 24, 2019 7:00:55 PM", true, 3 },
                    { 4, "Friday, February 25, 2019 10:40:55 PM", "Friday, February 25, 2019 9:00:55 PM", true, 4 },
                    { 5, "Friday, February 03, 2019 3:40:55 PM", "Friday, February 03, 2019 2:00:55 PM", true, 5 },
                    { 6, "Friday, February 18, 2019 6:40:55 PM", "Friday, February 18, 2019 5:00:55 PM", true, 6 },
                    { 7, "Friday, February 02, 2019 4:40:55 PM", "Friday, February 02, 2019 3:00:55 PM", true, 7 },
                    { 8, "Friday, February 10, 2019 3:40:55 PM", "Friday, February 10, 2019 2:00:55 PM", true, 8 },
                    { 9, "Friday, February 11, 2019 2:40:55 PM", "Friday, February 11, 2019 1:00:55 PM", true, 9 },
                    { 10, "Friday, February 13, 2019 6:40:55 PM", "Friday, February 13, 2019 5:00:55 PM", true, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "i_x_schedules_user_id",
                table: "schedules",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "schedules");
        }
    }
}
