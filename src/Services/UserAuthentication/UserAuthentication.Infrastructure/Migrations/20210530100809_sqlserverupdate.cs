using Microsoft.EntityFrameworkCore.Migrations;

namespace amznStore.Services.UserAuthentication.Infrastructure.Migrations
{
    public partial class sqlserverupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_AspNetUsers_UserId",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPaymentCard_AspNetUsers_UserId",
                table: "UserPaymentCard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPaymentCard",
                table: "UserPaymentCard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAddress",
                table: "UserAddress");

            migrationBuilder.RenameTable(
                name: "UserPaymentCard",
                newName: "UserPaymentCards");

            migrationBuilder.RenameTable(
                name: "UserAddress",
                newName: "UserAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_UserPaymentCard_UserId",
                table: "UserPaymentCards",
                newName: "IX_UserPaymentCards_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddress_UserId",
                table: "UserAddresses",
                newName: "IX_UserAddresses_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPaymentCards",
                table: "UserPaymentCards",
                column: "CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAddresses",
                table: "UserAddresses",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_AspNetUsers_UserId",
                table: "UserAddresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPaymentCards_AspNetUsers_UserId",
                table: "UserPaymentCards",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_AspNetUsers_UserId",
                table: "UserAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPaymentCards_AspNetUsers_UserId",
                table: "UserPaymentCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPaymentCards",
                table: "UserPaymentCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAddresses",
                table: "UserAddresses");

            migrationBuilder.RenameTable(
                name: "UserPaymentCards",
                newName: "UserPaymentCard");

            migrationBuilder.RenameTable(
                name: "UserAddresses",
                newName: "UserAddress");

            migrationBuilder.RenameIndex(
                name: "IX_UserPaymentCards_UserId",
                table: "UserPaymentCard",
                newName: "IX_UserPaymentCard_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddress",
                newName: "IX_UserAddress_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPaymentCard",
                table: "UserPaymentCard",
                column: "CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAddress",
                table: "UserAddress",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_AspNetUsers_UserId",
                table: "UserAddress",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPaymentCard_AspNetUsers_UserId",
                table: "UserPaymentCard",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
