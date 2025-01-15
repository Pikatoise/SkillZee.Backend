using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillZee.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class HasDataForOrderSpeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderSpeed",
                columns: new[] { "Id", "CreatedAt", "IsActive", "RewardMultiplier", "Title" },
                values: new object[,]
                {
                    { new Guid("019f5b79-1fe2-435d-99f3-837e38047036"), new DateTime(2025, 1, 15, 12, 0, 0, 0, DateTimeKind.Utc), true, 1.0, "Стандартно" },
                    { new Guid("1a452389-4644-45af-be2c-359ceec260e5"), new DateTime(2025, 1, 15, 12, 0, 0, 0, DateTimeKind.Utc), true, 1.2, "Очень срочно" },
                    { new Guid("7d318e1a-cded-4481-b24b-77b385735245"), new DateTime(2025, 1, 15, 12, 0, 0, 0, DateTimeKind.Utc), true, 1.1000000000000001, "Срочно" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderSpeed",
                keyColumn: "Id",
                keyValue: new Guid("019f5b79-1fe2-435d-99f3-837e38047036"));

            migrationBuilder.DeleteData(
                table: "OrderSpeed",
                keyColumn: "Id",
                keyValue: new Guid("1a452389-4644-45af-be2c-359ceec260e5"));

            migrationBuilder.DeleteData(
                table: "OrderSpeed",
                keyColumn: "Id",
                keyValue: new Guid("7d318e1a-cded-4481-b24b-77b385735245"));
        }
    }
}
