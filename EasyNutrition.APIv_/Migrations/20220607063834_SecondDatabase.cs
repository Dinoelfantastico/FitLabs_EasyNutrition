using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyNutrition.APIv_.Migrations
{
    public partial class SecondDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "session",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start_at = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    end_at = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    link = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_session", x => x.id);
                    table.ForeignKey(
                        name: "f_k_session__users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "session",
                columns: new[] { "id", "end_at", "link", "start_at", "user_id" },
                values: new object[,]
                {
                    { 1, "Monday, March 24 ,2019 18:00:00 PM", "https", "Monday, March 24,2019 17:00:00 PM", 1 },
                    { 2, "Thurday, March 26 ,2019 21:00:00 PM", "https", "Thursday, March 26,2019 20:00:00 PM", 2 },
                    { 3, "Monday, March 13 ,2019 18:00:00 PM", "https", "Monday, March 13,2019 17:00:00 PM", 3 },
                    { 4, "Monday, March 24 ,2019 17:00:00 PM", "https", "Monday, March 24,2019 16:00:00 PM", 4 },
                    { 5, "Monday, March 24 ,2019 18:00:00 PM", "https", "Monday, March 24,2019 17:00:00 PM", 5 },
                    { 6, "Monday, March 24 ,2019 18:00:00 PM", "https", "Monday, March 24,2019 17:00:00 PM", 6 },
                    { 7, "Thurday, March 26 ,2019 21:00:00 PM", "https", "Thursday, March 26,2019 20:00:00 PM", 7 },
                    { 8, "Monday, March 13 ,2019 18:00:00 PM", "https", "Monday, March 13,2019 17:00:00 PM", 8 },
                    { 9, "Monday, March 24 ,2019 17:00:00 PM", "https", "Monday, March 24,2019 16:00:00 PM", 9 },
                    { 10, "Monday, March 24 ,2019 18:00:00 PM", "https", "Monday, March 24,2019 17:00:00 PM", 10 }
                });

        

            migrationBuilder.CreateIndex(
                name: "i_x_session_user_id",
                table: "session",
                column: "user_id");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "session");
        }
    }
}
