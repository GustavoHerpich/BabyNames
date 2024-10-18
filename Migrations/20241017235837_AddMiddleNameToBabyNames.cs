using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BabyName.Migrations
{
    /// <inheritdoc />
    public partial class AddMiddleNameToBabyNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "baby_names",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    births = table.Column<int>(type: "int", nullable: false),
                    pos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_baby_names", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "baby_names");
        }
    }
}
