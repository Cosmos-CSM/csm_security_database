using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSM_Security.Migrations
{
    /// <inheritdoc />
    public partial class _7_incluidingvendorstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // --> Create new tables first to be able to migrate data.
            migrationBuilder.CreateTable(
                name: "Users_Permits",
                columns: table => new
                {
                    Permit = table.Column<long>(type: "bigint", nullable: false),
                    User = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Permits", x => new { x.Permit, x.User });
                    table.ForeignKey(
                        name: "FK_Users_Permits_Permits_Permit",
                        column: x => x.Permit,
                        principalTable: "Permits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Permits_Users_User",
                        column: x => x.User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users_Profiles",
                columns: table => new
                {
                    Profile = table.Column<long>(type: "bigint", nullable: false),
                    User = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Profiles", x => new { x.Profile, x.User });
                    table.ForeignKey(
                        name: "FK_Users_Profiles_Profiles_Profile",
                        column: x => x.Profile,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Profiles_Users_User",
                        column: x => x.User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // --> Migrate data from old tables to new ones before dropping.
            migrationBuilder.Sql(
                """
                INSERT INTO Users_Permits (Permit, [User])
                SELECT Permit, Account FROM Accounts_Permits;
                """);

            migrationBuilder.Sql(
                """
                INSERT INTO Users_Profiles (Profile, [User])
                SELECT Profile, Account FROM Accounts_Profiles;
                """);

            // --> Now it's safe to drop the old tables.
            migrationBuilder.DropTable(
                name: "Accounts_Permits");

            migrationBuilder.DropTable(
                name: "Accounts_Profiles");

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Reference = table.Column<string>(type: "nchar(8)", fixedLength: true, maxLength: 8, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users_Vendors",
                columns: table => new
                {
                    User = table.Column<long>(type: "bigint", nullable: false),
                    Vendor = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Vendors", x => new { x.User, x.Vendor });
                    table.ForeignKey(
                        name: "FK_Users_Vendors_Users_User",
                        column: x => x.User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Vendors_Vendors_Vendor",
                        column: x => x.Vendor,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Permits_User",
                table: "Users_Permits",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Profiles_User",
                table: "Users_Profiles",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Vendors_Vendor",
                table: "Users_Vendors",
                column: "Vendor");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_Name",
                table: "Vendors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_Reference",
                table: "Vendors",
                column: "Reference",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users_Vendors");

            migrationBuilder.DropTable(
                name: "Vendors");

            // --> Restore old tables before dropping new ones.
            migrationBuilder.CreateTable(
                name: "Accounts_Permits",
                columns: table => new
                {
                    Account = table.Column<long>(type: "bigint", nullable: false),
                    Permit = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts_Permits", x => new { x.Account, x.Permit });
                    table.ForeignKey(
                        name: "FK_Accounts_Permits_Permits_Permit",
                        column: x => x.Permit,
                        principalTable: "Permits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Permits_Users_Account",
                        column: x => x.Account,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts_Profiles",
                columns: table => new
                {
                    Account = table.Column<long>(type: "bigint", nullable: false),
                    Profile = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts_Profiles", x => new { x.Account, x.Profile });
                    table.ForeignKey(
                        name: "FK_Accounts_Profiles_Profiles_Profile",
                        column: x => x.Profile,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Profiles_Users_Account",
                        column: x => x.Account,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // --> Migrate data back from new tables to old ones.
            migrationBuilder.Sql(
                """
                INSERT INTO Accounts_Permits (Account, Permit)
                SELECT [User], Permit FROM Users_Permits;
                """);

            migrationBuilder.Sql(
                """
                INSERT INTO Accounts_Profiles (Account, Profile)
                SELECT [User], Profile FROM Users_Profiles;
                """);

            // --> Now it's safe to drop the new tables.
            migrationBuilder.DropTable(
                name: "Users_Permits");

            migrationBuilder.DropTable(
                name: "Users_Profiles");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Permits_Permit",
                table: "Accounts_Permits",
                column: "Permit");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Profiles_Profile",
                table: "Accounts_Profiles",
                column: "Profile");
        }
    }
}
