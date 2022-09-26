using Microsoft.EntityFrameworkCore.Migrations;

namespace Bissoft.Interview.Data.Migrations
{
    public partial class AddZooKeeper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZooKeeperId",
                table: "Animal",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ZooKeeper",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZooKeeper", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_ZooKeeperId",
                table: "Animal",
                column: "ZooKeeperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_ZooKeeper_ZooKeeperId",
                table: "Animal",
                column: "ZooKeeperId",
                principalTable: "ZooKeeper",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_ZooKeeper_ZooKeeperId",
                table: "Animal");

            migrationBuilder.DropTable(
                name: "ZooKeeper");

            migrationBuilder.DropIndex(
                name: "IX_Animal_ZooKeeperId",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "ZooKeeperId",
                table: "Animal");
        }
    }
}
