using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyNutrition.APIv_.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    password = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    birthday = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    linkedin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_users", x => x.id);
                    table.ForeignKey(
                        name: "f_k_users_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Nutricionista" },
                    { 2, "Cliente" },
                    { 3, "Administrador" },
                    { 4, "Invitado" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "active", "address", "birthday", "email", "lastname", "linkedin", "name", "password", "phone", "role_id", "username" },
                values: new object[,]
                {
                    { 1, true, "Las Malvinas 123", "10/10/1985", "alfredito@gmail.com", "Gomez", "https:\\afjaowjfiawj.com", "Alfredo", "dbJe*D4xqfd|e]*p&", "97531546", 1, "Alfredo Gomez" },
                    { 2, true, "Las Malvinas 667", "10/10/1990", "hernes@gmail.com", "Sanchez", "https:\\afjaowjfiawj.com", "Hernesto", "1WH1wm%tL#AUsgqB@", "97531546", 1, "Hernesto Sanchez" },
                    { 3, true, "Las Poncinas 314", "10/10/1970", "augus@gmail.com", "Hernandez", "https:\\afjaowjfiawj.com", "Agusto", "exCBHH0UdzyGpCxE~", "97532346", 2, "Agusto Hernandez" },
                    { 4, true, "Villanueva 454", "10/10/1989", "jere@gmail.com", "ALfonso", "https:\\afjaowjfiawj.com", "Jeremy", "HYO|@o7XJK@T<^W(^", "978561234", 3, "Jeremy ALfonso" },
                    { 5, true, "Las doce 123", "10/10/1987", "augus_14@gmail.com", "Salazar", "https:\\afjaowjfiawj.com", "Augusto", "1b}%Ct(Th*(0odt1l", "97512346", 2, "Augusto Salazar" },
                    { 6, true, "CHavin 123", "10/10/1982", "yim23@gmail.com", "Neutron", "https:\\afjaowjfiawj.com", "Yimmy", "MW~#o2z2#I)!WjDKR", "97559746", 1, "Yimmy Neutron" },
                    { 7, true, "Cajamarca 123", "10/10/1990", "steve789@gmail.com", "Robi", "https:\\afjaowjfiawj.com", "Steve", "7k<GV(qEe%PHJOFc#", "97539756", 2, "Steve Robi" },
                    { 8, true, "Av. Ayacucho 123", "10/10/1990", "san23@gmail.com", "Quispe", "https:\\afjaowjfiawj.com", "Sandro", "mh$!iPSvXAfCWkh$f", "94561546", 3, "Sandro Quispe" },
                    { 9, true, "Av- Bolivar 123", "10/10/1987", "alimoha@gmail.com", "Jamelio", "https:\\afjaowjfiawj.com", "Ali", "OHG2|CZ^9Z6#d!*Xf", "97821546", 1, "Ali Jamelio" },
                    { 10, true, "Alfonso Ugarte 123", "10/10/1989", "angel123@gmail.com", "Gavidia", "https:\\afjaowjfiawj.com", "Angel", "ZNrr&l*xeucG2W(*D", "94861546", 4, "Angel Gavidia" }
                });

            migrationBuilder.CreateIndex(
                name: "i_x_users_role_id",
                table: "users",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
