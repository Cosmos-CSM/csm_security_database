using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSM_Security.Migrations
{
    /// <inheritdoc />
    public partial class _1_entitiesbasestandarization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "Accounts_Permits");

            migrationBuilder.DropTable(
                name: "Accounts_Profiles");

            migrationBuilder.DropTable(
                name: "Profiles_Permits");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Permits");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Solutions");

            migrationBuilder.RenameColumn(
                name: "Enabled",
                table: "Actions",
                newName: "IsEnabled");

            // 1️⃣ Add column as nullable first
            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Actions",
                type: "nchar(8)",
                fixedLength: true,
                maxLength: 8,
                nullable: true);

            // 2️⃣ Always populate NULLs, keep existing non-null values
            migrationBuilder.Sql(@"
        UPDATE Actions
        SET Reference = SUBSTRING(REPLACE(CONVERT(varchar(36), NEWID()), '-', ''), 1, 8)
        WHERE Reference IS NULL;
    ");

            // 3️⃣ Make column non-nullable
            migrationBuilder.AlterColumn<string>(
                name: "Reference",
                table: "Actions",
                type: "nchar(8)",
                fixedLength: true,
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(8)",
                oldFixedLength: true,
                oldMaxLength: 8,
                oldNullable: true);

            // 4️⃣ Add unique index
            migrationBuilder.CreateIndex(
                name: "IX_Actions_Reference",
                table: "Actions",
                column: "Reference",
                unique: true);

            migrationBuilder.CreateTable(
                name: "Permit",
                columns: table => new {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionId = table.Column<long>(type: "bigint", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Permit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permit_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsMaster = table.Column<bool>(type: "bit", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermitProfile",
                columns: table => new {
                    PermitsId = table.Column<long>(type: "bigint", nullable: false),
                    ProfilesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_PermitProfile", x => new { x.PermitsId, x.ProfilesId });
                    table.ForeignKey(
                        name: "FK_PermitProfile_Permit_PermitsId",
                        column: x => x.PermitsId,
                        principalTable: "Permit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermitProfile_Profile_ProfilesId",
                        column: x => x.ProfilesId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermitUser",
                columns: table => new {
                    PermitsId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_PermitUser", x => new { x.PermitsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_PermitUser_Permit_PermitsId",
                        column: x => x.PermitsId,
                        principalTable: "Permit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermitUser_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileUser",
                columns: table => new {
                    ProfilesId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_ProfileUser", x => new { x.ProfilesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ProfileUser_Profile_ProfilesId",
                        column: x => x.ProfilesId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileUser_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permit_ActionId",
                table: "Permit",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_PermitProfile_ProfilesId",
                table: "PermitProfile",
                column: "ProfilesId");

            migrationBuilder.CreateIndex(
                name: "IX_PermitUser_UsersId",
                table: "PermitUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileUser_UsersId",
                table: "ProfileUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermitProfile");

            migrationBuilder.DropTable(
                name: "PermitUser");

            migrationBuilder.DropTable(
                name: "ProfileUser");

            migrationBuilder.DropTable(
                name: "Permit");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Actions_Reference",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Actions");

            migrationBuilder.RenameColumn(
                name: "IsEnabled",
                table: "Actions",
                newName: "Enabled");

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solutions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sign = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contact = table.Column<long>(type: "bigint", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    User = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Wildcard = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Contacts_Contact",
                        column: x => x.Contact,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<long>(type: "bigint", nullable: false),
                    Feature = table.Column<long>(type: "bigint", nullable: false),
                    Solution = table.Column<long>(type: "bigint", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Reference = table.Column<string>(type: "nchar(8)", fixedLength: true, maxLength: 8, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permits_Actions_Action",
                        column: x => x.Action,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Permits_Features_Feature",
                        column: x => x.Feature,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Permits_Solutions_Solution",
                        column: x => x.Solution,
                        principalTable: "Solutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_Accounts_Profiles_Accounts_Account",
                        column: x => x.Account,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Profiles_Profiles_Profile",
                        column: x => x.Profile,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_Accounts_Permits_Accounts_Account",
                        column: x => x.Account,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Permits_Permits_Permit",
                        column: x => x.Permit,
                        principalTable: "Permits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiles_Permits",
                columns: table => new
                {
                    Permit = table.Column<long>(type: "bigint", nullable: false),
                    Profile = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles_Permits", x => new { x.Permit, x.Profile });
                    table.ForeignKey(
                        name: "FK_Profiles_Permits_Permits_Permit",
                        column: x => x.Permit,
                        principalTable: "Permits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profiles_Permits_Profiles_Profile",
                        column: x => x.Profile,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Contact",
                table: "Accounts",
                column: "Contact",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_User",
                table: "Accounts",
                column: "User",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Permits_Permit",
                table: "Accounts_Permits",
                column: "Permit");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Profiles_Profile",
                table: "Accounts_Profiles",
                column: "Profile");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_EMail",
                table: "Contacts",
                column: "EMail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Phone",
                table: "Contacts",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_Name",
                table: "Features",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permits_Action_Solution_Feature",
                table: "Permits",
                columns: new[] { "Action", "Solution", "Feature" });

            migrationBuilder.CreateIndex(
                name: "IX_Permits_Feature",
                table: "Permits",
                column: "Feature");

            migrationBuilder.CreateIndex(
                name: "IX_Permits_Reference",
                table: "Permits",
                column: "Reference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permits_Solution",
                table: "Permits",
                column: "Solution");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_Name",
                table: "Profiles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_Permits_Profile",
                table: "Profiles_Permits",
                column: "Profile");

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
        }
    }
}
