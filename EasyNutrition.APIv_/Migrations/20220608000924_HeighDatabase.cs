using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyNutrition.APIv_.Migrations
{
    public partial class HeighDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subscriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    max_sessions = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_subscriptions", x => x.id);
                    table.ForeignKey(
                        name: "f_k_subscriptions__users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "subscriptions",
                columns: new[] { "id", "active", "max_sessions", "price", "user_id" },
                values: new object[,]
                {
                    { 1, true, 4, 10, 1 },
                    { 2, true, 1, 13, 2 },
                    { 3, true, 4, 10, 3 },
                    { 4, true, 4, 10, 4 },
                    { 5, true, 4, 10, 5 },
                    { 6, true, 4, 10, 6 },
                    { 7, true, 4, 10, 7 },
                    { 8, true, 4, 10, 8 },
                    { 9, true, 4, 10, 9 },
                    { 10, true, 4, 10, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "i_x_subscriptions_user_id",
                table: "subscriptions",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subscriptions");
        }
    }
}
