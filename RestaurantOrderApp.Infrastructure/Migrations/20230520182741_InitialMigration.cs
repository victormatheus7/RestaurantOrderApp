using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantOrderApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dish_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dish_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dishes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dishes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "times_of_day",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_times_of_day", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order_possibilities",
                columns: table => new
                {
                    time_of_day_id = table.Column<int>(type: "integer", nullable: false),
                    dish_type_id = table.Column<int>(type: "integer", nullable: false),
                    dish_id = table.Column<int>(type: "integer", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_possibilities", x => new { x.time_of_day_id, x.dish_type_id });
                    table.ForeignKey(
                        name: "FK_order_possibilities_dish_types_dish_type_id",
                        column: x => x.dish_type_id,
                        principalTable: "dish_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_possibilities_dishes_dish_id",
                        column: x => x.dish_id,
                        principalTable: "dishes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_possibilities_times_of_day_time_of_day_id",
                        column: x => x.time_of_day_id,
                        principalTable: "times_of_day",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uuid", nullable: false),
                    sequence = table.Column<int>(type: "integer", nullable: false),
                    time_of_day_id = table.Column<int>(type: "integer", nullable: false),
                    dish_type_id = table.Column<int>(type: "integer", nullable: false),
                    dish_id = table.Column<int>(type: "integer", nullable: true),
                    modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => new { x.guid, x.sequence });
                    table.ForeignKey(
                        name: "FK_orders_dishes_dish_id",
                        column: x => x.dish_id,
                        principalTable: "dishes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_orders_times_of_day_time_of_day_id",
                        column: x => x.time_of_day_id,
                        principalTable: "times_of_day",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "dish_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "entrée" },
                    { 2, "side" },
                    { 3, "drink" },
                    { 4, "dessert" }
                });

            migrationBuilder.InsertData(
                table: "dishes",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 0, "eggs" },
                    { 1, "Toast" },
                    { 2, "coffee" },
                    { 3, "steak" },
                    { 4, "potato" },
                    { 5, "wine" },
                    { 6, "cake" }
                });

            migrationBuilder.InsertData(
                table: "times_of_day",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 0, "morning" },
                    { 1, "night" }
                });

            migrationBuilder.InsertData(
                table: "order_possibilities",
                columns: new[] { "dish_type_id", "time_of_day_id", "dish_id" },
                values: new object[,]
                {
                    { 1, 0, 0 },
                    { 2, 0, 1 },
                    { 3, 0, 2 },
                    { 1, 1, 3 },
                    { 2, 1, 4 },
                    { 3, 1, 5 },
                    { 4, 1, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_possibilities_dish_id",
                table: "order_possibilities",
                column: "dish_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_possibilities_dish_type_id",
                table: "order_possibilities",
                column: "dish_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_dish_id",
                table: "orders",
                column: "dish_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_time_of_day_id",
                table: "orders",
                column: "time_of_day_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_possibilities");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "dish_types");

            migrationBuilder.DropTable(
                name: "dishes");

            migrationBuilder.DropTable(
                name: "times_of_day");
        }
    }
}
