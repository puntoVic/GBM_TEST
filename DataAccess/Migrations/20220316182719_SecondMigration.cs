using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cash = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Issuer",
                columns: table => new
                {
                    Issuer_Name = table.Column<string>(nullable: false),
                    Total_Shares = table.Column<int>(nullable: false),
                    Shares_Price = table.Column<int>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    AccountId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issuer", x => x.Issuer_Name);
                    table.ForeignKey(
                        name: "FK_Issuer_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    IdTransaction = table.Column<string>(nullable: false),
                    Timestamp = table.Column<string>(nullable: true),
                    TypeOperation = table.Column<string>(nullable: true),
                    Issuer_Name = table.Column<string>(nullable: true),
                    Issuer_Name1 = table.Column<string>(nullable: true),
                    Total_Shares = table.Column<int>(nullable: false),
                    Shares_Prices = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    AccountId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.IdTransaction);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Issuer_Issuer_Name1",
                        column: x => x.Issuer_Name1,
                        principalTable: "Issuer",
                        principalColumn: "Issuer_Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issuer_AccountId",
                table: "Issuer",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Issuer_Name1",
                table: "Transactions",
                column: "Issuer_Name1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Issuer");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
