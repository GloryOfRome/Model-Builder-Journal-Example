using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model_Builder_Journal_Example.Migrations
{
    public partial class buildjournalbuilduseraddseededadminuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FristName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserNumber);
                });

            migrationBuilder.CreateTable(
                name: "Journal",
                columns: table => new
                {
                    UserOwnerNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JournalNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tital = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journal", x => x.UserOwnerNumber);
                    table.ForeignKey(
                        name: "FK_Journal_Users_UserOwnerNumber",
                        column: x => x.UserOwnerNumber,
                        principalTable: "Users",
                        principalColumn: "UserNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserJournals",
                columns: table => new
                {
                    JournalNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserEditorNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJournals", x => new { x.UserEditorNumber, x.JournalNumber });
                    table.ForeignKey(
                        name: "FK_UserJournals_Journal_JournalNumber",
                        column: x => x.JournalNumber,
                        principalTable: "Journal",
                        principalColumn: "UserOwnerNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserJournals_Users_UserEditorNumber",
                        column: x => x.UserEditorNumber,
                        principalTable: "Users",
                        principalColumn: "UserNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserNumber", "FristName" },
                values: new object[] { "001", "Adminstrator" });

            migrationBuilder.CreateIndex(
                name: "IX_UserJournals_JournalNumber",
                table: "UserJournals",
                column: "JournalNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserJournals");

            migrationBuilder.DropTable(
                name: "Journal");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
