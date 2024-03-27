using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleForumApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Country_Statuses_StatusId",
                table: "Country");

            migrationBuilder.DropForeignKey(
                name: "FK_Gender_Statuses_StatusId",
                table: "Gender");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Country_CountryId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Gender_GenderId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Statuses_StatusId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Person_PersonId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Statuses_StatusId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UserId",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gender",
                table: "Gender");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Persons");

            migrationBuilder.RenameTable(
                name: "Gender",
                newName: "Genders");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameIndex(
                name: "IX_User_StatusId",
                table: "Users",
                newName: "IX_Users_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_User_PersonId",
                table: "Users",
                newName: "IX_Users_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_StatusId",
                table: "Persons",
                newName: "IX_Persons_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_GenderId",
                table: "Persons",
                newName: "IX_Persons_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_CountryId",
                table: "Persons",
                newName: "IX_Persons_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Gender_StatusId",
                table: "Genders",
                newName: "IX_Genders_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Country_StatusId",
                table: "Countries",
                newName: "IX_Countries_StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genders",
                table: "Genders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Statuses_StatusId",
                table: "Countries",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Genders_Statuses_StatusId",
                table: "Genders",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Countries_CountryId",
                table: "Persons",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Genders_GenderId",
                table: "Persons",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Statuses_StatusId",
                table: "Persons",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Users_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Persons_PersonId",
                table: "Users",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Statuses_StatusId",
                table: "Users",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Statuses_StatusId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Genders_Statuses_StatusId",
                table: "Genders");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Countries_CountryId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Genders_GenderId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Statuses_StatusId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Users_UserId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Persons_PersonId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Statuses_StatusId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genders",
                table: "Genders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Person");

            migrationBuilder.RenameTable(
                name: "Genders",
                newName: "Gender");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameIndex(
                name: "IX_Users_StatusId",
                table: "User",
                newName: "IX_User_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_PersonId",
                table: "User",
                newName: "IX_User_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_StatusId",
                table: "Person",
                newName: "IX_Person_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_GenderId",
                table: "Person",
                newName: "IX_Person_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_CountryId",
                table: "Person",
                newName: "IX_Person_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Genders_StatusId",
                table: "Gender",
                newName: "IX_Gender_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Countries_StatusId",
                table: "Country",
                newName: "IX_Country_StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gender",
                table: "Gender",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Country_Statuses_StatusId",
                table: "Country",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gender_Statuses_StatusId",
                table: "Gender",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Country_CountryId",
                table: "Person",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Gender_GenderId",
                table: "Person",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Statuses_StatusId",
                table: "Person",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Person_PersonId",
                table: "User",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Statuses_StatusId",
                table: "User",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_User_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
