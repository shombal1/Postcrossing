using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Postcrossing.Storage.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationshipBetween_AddressAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ResidentialAddresses_AddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AddressId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Users",
                newName: "ResidentialAddressId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ResidentialAddresses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Users_ResidentialAddressId",
                table: "Users",
                column: "ResidentialAddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ResidentialAddresses_ResidentialAddressId",
                table: "Users",
                column: "ResidentialAddressId",
                principalTable: "ResidentialAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ResidentialAddresses_ResidentialAddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ResidentialAddressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ResidentialAddresses");

            migrationBuilder.RenameColumn(
                name: "ResidentialAddressId",
                table: "Users",
                newName: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ResidentialAddresses_AddressId",
                table: "Users",
                column: "AddressId",
                principalTable: "ResidentialAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
