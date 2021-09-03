using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionePolizza.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Code", "FirstName", "LastName" },
                values: new object[] { 1, "VRDMRA7891LH2D67", "Maria", "Verdi" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Code", "FirstName", "LastName" },
                values: new object[] { 2, "RSSLCA45H67LK097", "Luca", "Rossi" });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "Id", "CustomerId", "ExpirationDate", "MonthlyRate", "Number", "PolicyType" },
                values: new object[] { 1, 2, new DateTime(2025, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 80m, 1872, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
