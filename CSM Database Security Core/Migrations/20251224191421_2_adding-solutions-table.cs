using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSM_Security.Migrations
{
    /// <inheritdoc />
    public partial class _2_addingsolutionstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SolutionId",
                table: "Permit",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Solutions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sign = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solutions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permit_SolutionId",
                table: "Permit",
                column: "SolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_Name",
                table: "Solutions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_Sign",
                table: "Solutions",
                column: "Sign",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Permit_Solutions_SolutionId",
                table: "Permit",
                column: "SolutionId",
                principalTable: "Solutions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permit_Solutions_SolutionId",
                table: "Permit");

            migrationBuilder.DropTable(
                name: "Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Permit_SolutionId",
                table: "Permit");

            migrationBuilder.DropColumn(
                name: "SolutionId",
                table: "Permit");
        }
    }
}
