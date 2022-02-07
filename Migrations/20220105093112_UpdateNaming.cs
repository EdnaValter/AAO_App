using Microsoft.EntityFrameworkCore.Migrations;

namespace AAO_App.Migrations
{
    public partial class UpdateNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Contacts_ContactId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Locations_LocationId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_ContactId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_LocationId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Trips");

            migrationBuilder.AddColumn<int>(
                name: "ContactsContactId",
                table: "Trips",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationsLocationId",
                table: "Trips",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_ContactsContactId",
                table: "Trips",
                column: "ContactsContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_LocationsLocationId",
                table: "Trips",
                column: "LocationsLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Contacts_ContactsContactId",
                table: "Trips",
                column: "ContactsContactId",
                principalTable: "Contacts",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Locations_LocationsLocationId",
                table: "Trips",
                column: "LocationsLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Contacts_ContactsContactId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Locations_LocationsLocationId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_ContactsContactId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_LocationsLocationId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ContactsContactId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "LocationsLocationId",
                table: "Trips");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_ContactId",
                table: "Trips",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_LocationId",
                table: "Trips",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Contacts_ContactId",
                table: "Trips",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Locations_LocationId",
                table: "Trips",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
