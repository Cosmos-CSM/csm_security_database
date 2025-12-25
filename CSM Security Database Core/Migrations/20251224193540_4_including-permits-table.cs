using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSM_Security.Migrations
{
    /// <inheritdoc />
    public partial class _4_includingpermitstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permit_Actions_ActionId",
                table: "Permit");

            migrationBuilder.DropForeignKey(
                name: "FK_Permit_Features_FeatureId",
                table: "Permit");

            migrationBuilder.DropForeignKey(
                name: "FK_Permit_Solutions_SolutionId",
                table: "Permit");

            migrationBuilder.DropForeignKey(
                name: "FK_PermitProfile_Permit_PermitsId",
                table: "PermitProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_PermitUser_Permit_PermitsId",
                table: "PermitUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permit",
                table: "Permit");

            migrationBuilder.DropIndex(
                name: "IX_Permit_ActionId",
                table: "Permit");

            migrationBuilder.DropIndex(
                name: "IX_Permit_FeatureId",
                table: "Permit");

            migrationBuilder.DropIndex(
                name: "IX_Permit_SolutionId",
                table: "Permit");

            migrationBuilder.DropColumn(
                name: "ActionId",
                table: "Permit");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Permit");

            migrationBuilder.DropColumn(
                name: "SolutionId",
                table: "Permit");

            migrationBuilder.RenameTable(
                name: "Permit",
                newName: "Permits");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "Permits",
                type: "datetime2(7)",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Reference",
                table: "Permits",
                type: "nchar(8)",
                fixedLength: true,
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Permits",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Permits",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Action",
                table: "Permits",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Feature",
                table: "Permits",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Solution",
                table: "Permits",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permits",
                table: "Permits",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Permits_Action_Solution_Feature",
                table: "Permits",
                columns: new[] { "Action", "Solution", "Feature" });

            migrationBuilder.CreateIndex(
                name: "IX_Permits_Feature",
                table: "Permits",
                column: "Feature");

            migrationBuilder.CreateIndex(
                name: "IX_Permits_Name",
                table: "Permits",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permits_Reference",
                table: "Permits",
                column: "Reference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permits_Solution",
                table: "Permits",
                column: "Solution");

            migrationBuilder.AddForeignKey(
                name: "FK_PermitProfile_Permits_PermitsId",
                table: "PermitProfile",
                column: "PermitsId",
                principalTable: "Permits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permits_Actions_Action",
                table: "Permits",
                column: "Action",
                principalTable: "Actions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Permits_Features_Feature",
                table: "Permits",
                column: "Feature",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Permits_Solutions_Solution",
                table: "Permits",
                column: "Solution",
                principalTable: "Solutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermitUser_Permits_PermitsId",
                table: "PermitUser",
                column: "PermitsId",
                principalTable: "Permits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermitProfile_Permits_PermitsId",
                table: "PermitProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_Permits_Actions_Action",
                table: "Permits");

            migrationBuilder.DropForeignKey(
                name: "FK_Permits_Features_Feature",
                table: "Permits");

            migrationBuilder.DropForeignKey(
                name: "FK_Permits_Solutions_Solution",
                table: "Permits");

            migrationBuilder.DropForeignKey(
                name: "FK_PermitUser_Permits_PermitsId",
                table: "PermitUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permits",
                table: "Permits");

            migrationBuilder.DropIndex(
                name: "IX_Permits_Action_Solution_Feature",
                table: "Permits");

            migrationBuilder.DropIndex(
                name: "IX_Permits_Feature",
                table: "Permits");

            migrationBuilder.DropIndex(
                name: "IX_Permits_Name",
                table: "Permits");

            migrationBuilder.DropIndex(
                name: "IX_Permits_Reference",
                table: "Permits");

            migrationBuilder.DropIndex(
                name: "IX_Permits_Solution",
                table: "Permits");

            migrationBuilder.DropColumn(
                name: "Action",
                table: "Permits");

            migrationBuilder.DropColumn(
                name: "Feature",
                table: "Permits");

            migrationBuilder.DropColumn(
                name: "Solution",
                table: "Permits");

            migrationBuilder.RenameTable(
                name: "Permits",
                newName: "Permit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "Permit",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(7)",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "Reference",
                table: "Permit",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(8)",
                oldFixedLength: true,
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Permit",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Permit",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ActionId",
                table: "Permit",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FeatureId",
                table: "Permit",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SolutionId",
                table: "Permit",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permit",
                table: "Permit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Permit_ActionId",
                table: "Permit",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Permit_FeatureId",
                table: "Permit",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Permit_SolutionId",
                table: "Permit",
                column: "SolutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permit_Actions_ActionId",
                table: "Permit",
                column: "ActionId",
                principalTable: "Actions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permit_Features_FeatureId",
                table: "Permit",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permit_Solutions_SolutionId",
                table: "Permit",
                column: "SolutionId",
                principalTable: "Solutions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PermitProfile_Permit_PermitsId",
                table: "PermitProfile",
                column: "PermitsId",
                principalTable: "Permit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermitUser_Permit_PermitsId",
                table: "PermitUser",
                column: "PermitsId",
                principalTable: "Permit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
