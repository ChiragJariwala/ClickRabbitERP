using Microsoft.EntityFrameworkCore.Migrations;

namespace ClickRabbitERP_Testing.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VendorMaster",
                columns: table => new
                {
                    CompID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Compphone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creationdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activationdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorMaster", x => x.CompID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendorMaster");
        }
    }
}
