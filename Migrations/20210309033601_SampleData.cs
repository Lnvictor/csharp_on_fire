using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductApp.Migrations
{
    public partial class SampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Description", "Name", "Value" },
                values: new object[] { 1, "Salga as Paradas", "Sal", 18.2f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
