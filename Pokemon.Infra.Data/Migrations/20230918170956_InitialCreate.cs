using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokemon.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pokemon_master",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: false),
                    age = table.Column<int>(type: "INTEGER", nullable: false, defaultValueSql: "((0))"),
                    cpf = table.Column<string>(type: "TEXT", unicode: false, maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__pokemon_master", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pokemon_captured",
                columns: table => new
                {
                    master_name = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: false),
                    pokemon_name = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: false),
                    capture_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    PokemonMasterid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__pokemon_captured", x => new { x.pokemon_name, x.master_name });
                    table.ForeignKey(
                        name: "FK_pokemon_captured_pokemon_master_PokemonMasterid",
                        column: x => x.PokemonMasterid,
                        principalTable: "pokemon_master",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_pokemon_captured_PokemonMasterid",
                table: "pokemon_captured",
                column: "PokemonMasterid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pokemon_captured");

            migrationBuilder.DropTable(
                name: "pokemon_master");
        }
    }
}
