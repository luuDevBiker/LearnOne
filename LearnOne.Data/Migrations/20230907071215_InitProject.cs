using System;
using System.Collections.Generic;
using LearnOne.Domain.ObjectValues;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnOne.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CtyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Wards = table.Column<ICollection<Ward>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CtyId",
                        column: x => x.CtyId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Id",
                table: "Cities",
                column: "Id")
                .Annotation("Npgsql:IndexInclude", new[] { "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name")
                .Annotation("Npgsql:IndexInclude", new[] { "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CtyId",
                table: "Districts",
                column: "CtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_Id",
                table: "Districts",
                column: "Id")
                .Annotation("Npgsql:IndexInclude", new[] { "Name", "Wards" });

            migrationBuilder.CreateIndex(
                name: "IX_Districts_Name",
                table: "Districts",
                column: "Name")
                .Annotation("Npgsql:IndexInclude", new[] { "Id", "Wards" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
