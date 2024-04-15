using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtualShop.ProductApi.Migrations;

public partial class InsertProducts : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, ImageURL, CategoryId) " +
            "VALUES('Caderno Flamengo 200 folhas', 'Caderno Flamengo 200 folhas', 30, 100, 'caderno+flamengo.png', 2)");

        migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, ImageURL, CategoryId) " +
            "VALUES('Caderno Vasco 200 folhas', 'Caderno Vasco 200 folhas', 25, 100, 'caderno+vasco.png', 2)");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("DELETE FROM Products");
    }
}
