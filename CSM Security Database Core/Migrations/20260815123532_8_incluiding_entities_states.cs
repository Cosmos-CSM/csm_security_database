using System;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSM_Security.Migrations {
    /// <inheritdoc />
    public partial class _8_incluiding_entities_states : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropIndex(
                name: "IX_Vendors_Reference",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_Reference",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Permits_Reference",
                table: "Permits");

            migrationBuilder.DropIndex(
                name: "IX_Features_Reference",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Actions_Reference",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Permits");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Permits");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Actions");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Solutions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Permits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Features",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Actions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            // --> [State] shadow columns for every [SecurityNamedEntityBase]-derived entity.
            //     defaultValue: 0L is a temporary placeholder, immediately corrected below via
            //     the dynamic "Active" Id backfill, once [EntityStates] is seeded.
            migrationBuilder.AddColumn<long>(
                name: "State",
                table: "Features",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "State",
                table: "Actions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "State",
                table: "Vendors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "State",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "State",
                table: "UserInfos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "State",
                table: "Solutions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "State",
                table: "Profiles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "State",
                table: "Permits",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "EntityStates",
                columns: table => new {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_EntityStates", x => x.Id);
                });

            // --> Populating table with base values: upserts by [Name] so existing rows (and their Ids) are
            //     never touched, preventing duplication, wrong ids or orphaned FK references in
            //     [Actions]/[Features]/[Vendors]/etc.
            migrationBuilder.Sql("""
                MERGE INTO EntityStates AS target
                USING (VALUES
                    (N'Active',     N'Represents an entity currently active and in use within the ecosystem.'),
                    (N'Archived',   N'Represents an entity that has been archived and is no longer in active use.'),
                    (N'Terminated', N'Represents an entity whose lifecycle has been terminated and deleted.'),
                    (N'Disabled',   N'Represents an entity that has been disabled and is temporarily unavailable.')
                ) AS source (Name, Description)
                ON target.Name = source.Name
                WHEN MATCHED THEN
                    UPDATE SET Description = source.Description
                WHEN NOT MATCHED BY TARGET THEN
                    INSERT (Name, Description) VALUES (source.Name, source.Description);
                """);

            // --> Resolve the "Active" state Id dynamically, instead of hardcoding an Id,
            //     since MERGE does not guarantee a fixed Id when inserting for the first time.
            //     Fills every [SecurityNamedEntityBase] table.
            migrationBuilder.Sql("""
                DECLARE @ActiveStateId BIGINT = (SELECT Id FROM EntityStates WHERE Name = N'Active');

                UPDATE Actions SET State = @ActiveStateId WHERE State = 0 OR State IS NULL;
                UPDATE Features SET State = @ActiveStateId WHERE State = 0 OR State IS NULL;
                UPDATE Vendors SET State = @ActiveStateId WHERE State = 0 OR State IS NULL;
                UPDATE Users SET State = @ActiveStateId WHERE State = 0 OR State IS NULL;
                UPDATE UserInfos SET State = @ActiveStateId WHERE State = 0 OR State IS NULL;
                UPDATE Solutions SET State = @ActiveStateId WHERE State = 0 OR State IS NULL;
                UPDATE Profiles SET State = @ActiveStateId WHERE State = 0 OR State IS NULL;
                UPDATE Permits SET State = @ActiveStateId WHERE State = 0 OR State IS NULL;
                """);

            migrationBuilder.CreateIndex(
                name: "IX_Features_State",
                table: "Features",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_State",
                table: "Actions",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_State",
                table: "Vendors",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_Users_State",
                table: "Users",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_State",
                table: "UserInfos",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_State",
                table: "Solutions",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_State",
                table: "Profiles",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_Permits_State",
                table: "Permits",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_EntityStates_Name",
                table: "EntityStates",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_EntityStates_State",
                table: "Actions",
                column: "State",
                principalTable: "EntityStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_EntityStates_State",
                table: "Features",
                column: "State",
                principalTable: "EntityStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_EntityStates_State",
                table: "Vendors",
                column: "State",
                principalTable: "EntityStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_EntityStates_State",
                table: "Users",
                column: "State",
                principalTable: "EntityStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_EntityStates_State",
                table: "UserInfos",
                column: "State",
                principalTable: "EntityStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solutions_EntityStates_State",
                table: "Solutions",
                column: "State",
                principalTable: "EntityStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_EntityStates_State",
                table: "Profiles",
                column: "State",
                principalTable: "EntityStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Permits_EntityStates_State",
                table: "Permits",
                column: "State",
                principalTable: "EntityStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_EntityStates_State",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Features_EntityStates_State",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_EntityStates_State",
                table: "Vendors");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_EntityStates_State",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_EntityStates_State",
                table: "UserInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Solutions_EntityStates_State",
                table: "Solutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_EntityStates_State",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Permits_EntityStates_State",
                table: "Permits");

            migrationBuilder.DropTable(
                name: "EntityStates");

            migrationBuilder.DropIndex(
                name: "IX_Features_State",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Actions_State",
                table: "Actions");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_State",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Users_State",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserInfos_State",
                table: "UserInfos");

            migrationBuilder.DropIndex(
                name: "IX_Solutions_State",
                table: "Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_State",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Permits_State",
                table: "Permits");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "State",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Permits");

            // --> Defensively truncate to avoid trucation errors
            //     when reverting from nvarchar(max) back to nvarchar(200).
            migrationBuilder.Sql("""
                UPDATE Vendors
                SET Description = LEFT(Description, 200)
                WHERE Description IS NOT NULL AND LEN(Description) > 200;
                """);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Vendors",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Vendors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Vendors",
                type: "nchar(8)",
                fixedLength: true,
                maxLength: 8,
                nullable: true); // 1️⃣ Add column as nullable first

            migrationBuilder.Sql("""
                UPDATE Vendors
                SET Reference = SUBSTRING(REPLACE(CONVERT(varchar(36), NEWID()), '-', ''), 1, 8);
                """); // 2️⃣ Always populate NULLs, keep existing non-null values

            migrationBuilder.AlterColumn<string>(
                name: "Reference",
                table: "Vendors",
                type: "nchar(8)",
                fixedLength: true,
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(8)",
                oldFixedLength: true,
                oldMaxLength: 8,
                oldNullable: true); // 3️⃣ Make column non-nullable

            migrationBuilder.Sql("""
                UPDATE Solutions
                SET Description = LEFT(Description, 200)
                WHERE Description IS NOT NULL AND LEN(Description) > 200;
                """);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Solutions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.Sql("""
                UPDATE Profiles
                SET Description = LEFT(Description, 200)
                WHERE Description IS NOT NULL AND LEN(Description) > 200;
                """);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Profiles",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Profiles",
                type: "nchar(8)",
                fixedLength: true,
                maxLength: 8,
                nullable: true);

            migrationBuilder.Sql("""
                UPDATE Profiles
                SET Reference = SUBSTRING(REPLACE(CONVERT(varchar(36), NEWID()), '-', ''), 1, 8);
                """);

            migrationBuilder.AlterColumn<string>(
               name: "Reference",
               table: "Profiles",
               type: "nchar(8)",
               fixedLength: true,
               maxLength: 8,
               nullable: false,
               oldClrType: typeof(string),
               oldType: "nchar(8)",
               oldFixedLength: true,
               oldMaxLength: 8,
               oldNullable: true);

            migrationBuilder.Sql("""
                UPDATE Permits
                SET Description = LEFT(Description, 200)
                WHERE Description IS NOT NULL AND LEN(Description) > 200;
                """);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Permits",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Permits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Permits",
                type: "nchar(8)",
                fixedLength: true,
                maxLength: 8,
                nullable: true);

            migrationBuilder.Sql("""
                UPDATE Permits
                SET Reference = SUBSTRING(REPLACE(CONVERT(varchar(36), NEWID()), '-', ''), 1, 8);
                """);

            migrationBuilder.AlterColumn<string>(
               name: "Reference",
               table: "Permits",
               type: "nchar(8)",
               fixedLength: true,
               maxLength: 8,
               nullable: false,
               oldClrType: typeof(string),
               oldType: "nchar(8)",
               oldFixedLength: true,
               oldMaxLength: 8,
               oldNullable: true);

            migrationBuilder.Sql("""
                UPDATE Features
                SET Description = LEFT(Description, 200)
                WHERE Description IS NOT NULL AND LEN(Description) > 200;
                """);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Features",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Features",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Features",
                type: "nchar(8)",
                fixedLength: true,
                maxLength: 8,
                nullable: true);

            migrationBuilder.Sql("""
                UPDATE Features
                SET Reference = SUBSTRING(REPLACE(CONVERT(varchar(36), NEWID()), '-', ''), 1, 8);
                """);

            migrationBuilder.AlterColumn<string>(
               name: "Reference",
               table: "Features",
               type: "nchar(8)",
               fixedLength: true,
               maxLength: 8,
               nullable: false,
               oldClrType: typeof(string),
               oldType: "nchar(8)",
               oldFixedLength: true,
               oldMaxLength: 8,
               oldNullable: true);

            // --> Defensively truncate to avoid "String or binary data would be truncated"
            //     when reverting from nvarchar(max) back to nvarchar(200).
            migrationBuilder.Sql("""
                UPDATE Actions
                SET Description = LEFT(Description, 200)
                WHERE Description IS NOT NULL AND LEN(Description) > 200;
                """);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Actions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Actions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Actions",
                type: "nchar(8)",
                fixedLength: true,
                maxLength: 8,
                nullable: true);

            migrationBuilder.Sql("""
                UPDATE Actions
                SET Reference = SUBSTRING(REPLACE(CONVERT(varchar(36), NEWID()), '-', ''), 1, 8);
                """);

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

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_Reference",
                table: "Vendors",
                column: "Reference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_Reference",
                table: "Profiles",
                column: "Reference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permits_Reference",
                table: "Permits",
                column: "Reference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_Reference",
                table: "Features",
                column: "Reference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Actions_Reference",
                table: "Actions",
                column: "Reference",
                unique: true);
        }
    }
}
