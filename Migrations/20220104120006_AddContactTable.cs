using Microsoft.EntityFrameworkCore.Migrations;

namespace AAO_App.Migrations
{
    public partial class AddContactTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ContactsContactId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "DepId",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "LocationsLocationId",
                table: "Trips",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_LocationsLocationId",
                table: "Trips",
                newName: "IX_Trips_LocationId");

            migrationBuilder.AlterColumn<int>(
                name: "ContactId",
                table: "Contacts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_ContactId",
                table: "Trips",
                column: "ContactId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Trips",
                newName: "LocationsLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_LocationId",
                table: "Trips",
                newName: "IX_Trips_LocationsLocationId");

            migrationBuilder.AddColumn<string>(
                name: "ContactsContactId",
                table: "Trips",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactId",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DepId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_ContactsContactId",
                table: "Trips",
                column: "ContactsContactId");

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
