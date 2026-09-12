using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSM_Security.Migrations
{
    /// <inheritdoc />
    public partial class _8_includingstateproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Solutions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "State",
                table: "Solutions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "State",
                table: "Profiles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Permits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "State",
                table: "Permits",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Features",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "State",
                table: "Features",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Actions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "State",
                table: "Actions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "State",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Actions");

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
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Solutions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                nullable: false,
                defaultValue: "");

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
                nullable: false,
                defaultValue: "");

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
                nullable: false,
                defaultValue: "");

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
                nullable: false,
                defaultValue: "");

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
