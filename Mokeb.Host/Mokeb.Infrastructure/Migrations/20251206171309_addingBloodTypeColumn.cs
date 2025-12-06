using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mokeb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingBloodTypeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityInformation_BloodType",
                table: "IndividualPrincipals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentityInformation_BloodType",
                table: "CaravanPrincipals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityInformation_BloodType",
                table: "IndividualPrincipals");

            migrationBuilder.DropColumn(
                name: "IdentityInformation_BloodType",
                table: "CaravanPrincipals");
        }
    }
}
