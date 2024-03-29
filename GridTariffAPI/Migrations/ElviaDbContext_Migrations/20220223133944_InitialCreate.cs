﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GridTariffApi.Migrations.ElviaDbContext_Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SyncStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Table = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastUpdatedUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SyncStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeteringPointTariff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    MeteringPointId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TariffKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeteringPointTariff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeteringPointTariff_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PriceStructure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    JsonVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JsonPayload = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceStructure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceStructure_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_OrgNumber",
                table: "Company",
                column: "OrgNumber",
                unique: true,
                filter: "[OrgNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MeteringPointTariff_CompanyId",
                table: "MeteringPointTariff",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MeteringPointTariff_MeteringPointId",
                table: "MeteringPointTariff",
                column: "MeteringPointId",
                unique: true,
                filter: "[MeteringPointId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PriceStructure_CompanyId",
                table: "PriceStructure",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SyncStatus_Table",
                table: "SyncStatus",
                column: "Table",
                unique: true,
                filter: "[Table] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeteringPointTariff");

            migrationBuilder.DropTable(
                name: "PriceStructure");

            migrationBuilder.DropTable(
                name: "SyncStatus");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
