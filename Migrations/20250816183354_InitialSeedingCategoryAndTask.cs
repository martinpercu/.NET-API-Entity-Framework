using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apiEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeedingCategoryAndTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Relevance" },
                values: new object[,]
                {
                    { new Guid("00f9d419-1430-4312-bfe3-834e5f8727ca"), null, "Outdoor activities", 40 },
                    { new Guid("00f9d419-1430-4312-bfe3-834e5f8727cb"), null, "Indoor activities", 15 }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "DateCreation", "Description", "PriorityTask", "Title" },
                values: new object[,]
                {
                    { new Guid("00f9d419-1430-4312-bfe3-834e5f872710"), new Guid("00f9d419-1430-4312-bfe3-834e5f8727ca"), new DateTime(2025, 8, 16, 18, 0, 0, 0, DateTimeKind.Utc), null, 2, "Run 20 min" },
                    { new Guid("00f9d419-1430-4312-bfe3-834e5f872712"), new Guid("00f9d419-1430-4312-bfe3-834e5f8727ca"), new DateTime(2025, 8, 16, 18, 0, 0, 0, DateTimeKind.Utc), null, 0, "Climb Everest" },
                    { new Guid("00f9d419-1430-4312-bfe3-834e5f872714"), new Guid("00f9d419-1430-4312-bfe3-834e5f8727cb"), new DateTime(2025, 8, 16, 18, 0, 0, 0, DateTimeKind.Utc), null, 1, "Play Chess" },
                    { new Guid("00f9d419-1430-4312-bfe3-834e5f872716"), new Guid("00f9d419-1430-4312-bfe3-834e5f8727cb"), new DateTime(2025, 8, 16, 18, 0, 0, 0, DateTimeKind.Utc), null, 0, "Clean under the bed" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("00f9d419-1430-4312-bfe3-834e5f872710"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("00f9d419-1430-4312-bfe3-834e5f872712"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("00f9d419-1430-4312-bfe3-834e5f872714"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("00f9d419-1430-4312-bfe3-834e5f872716"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("00f9d419-1430-4312-bfe3-834e5f8727ca"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("00f9d419-1430-4312-bfe3-834e5f8727cb"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
