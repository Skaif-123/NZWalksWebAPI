using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalksWebAPI.Migrations.VesselDB
{
    /// <inheritdoc />
    public partial class IntialMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vessels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IMO_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vessel_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Call_Sign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DWT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vessels", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vessels");
        }
    }
}
