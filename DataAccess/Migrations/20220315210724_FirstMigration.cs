using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class FirstMigration : Migration
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
                name: "Issuers",
                columns: table => new
                {
                    Issuer_Name = table.Column<string>(maxLength: 10, nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issuers", x => x.Issuer_Name);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockId = table.Column<string>(nullable: false),
                    Ammount = table.Column<int>(nullable: false),
                    Issuer_Name = table.Column<string>(nullable: true),
                    Issuer_Name1 = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: true),
                    AccountId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stocks_Issuers_Issuer_Name1",
                        column: x => x.Issuer_Name1,
                        principalTable: "Issuers",
                        principalColumn: "Issuer_Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    IdTransaction = table.Column<string>(nullable: false),
                    Timestamp = table.Column<string>(nullable: true),
                    TypeOperation = table.Column<string>(nullable: false),
                    Issuer_Name = table.Column<string>(nullable: true),
                    Issuer_Name1 = table.Column<string>(nullable: true),
                    Total_Shares = table.Column<int>(nullable: false),
                    Shares_Prices = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.IdTransaction);
                    table.ForeignKey(
                        name: "FK_Transactions_Issuers_Issuer_Name1",
                        column: x => x.Issuer_Name1,
                        principalTable: "Issuers",
                        principalColumn: "Issuer_Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Issuers",
                columns: new[] { "Issuer_Name", "Value" },
                values: new object[,]
                {
                    { "AAPL", 150 },
                    { "MSFT", 276 },
                    { "GOOG", 2532 },
                    { "AMZN", 2845 },
                    { "TSLA", 767 },
                    { "NVDA", 213 },
                    { "TSM", 99 },
                    { "FB", 186 },
                    { "UNH", 486 },
                    { "JNJ", 171 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_AccountId",
                table: "Stocks",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Issuer_Name1",
                table: "Stocks",
                column: "Issuer_Name1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Issuer_Name1",
                table: "Transactions",
                column: "Issuer_Name1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Issuers");
        }
    }
}
