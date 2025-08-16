using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiEF.Migrations
{
    /// <inheritdoc />
    public partial class ColumnRelevantCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Relevance",
                table: "Category",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Relevance",
                table: "Category");
        }
    }
}
