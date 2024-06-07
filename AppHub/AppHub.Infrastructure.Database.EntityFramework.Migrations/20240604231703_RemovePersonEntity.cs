using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppHub.Infrastructure.Database.EntityFramework.Migrations
{
    public partial class RemovePersonEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthPerson_Person_PersonId",
                table: "AuthPerson");

            migrationBuilder.DropIndex(
                name: "IX_AuthPerson_PersonId",
                table: "AuthPerson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AuthPerson_PersonId",
                table: "AuthPerson",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthPerson_Person_PersonId",
                table: "AuthPerson",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
