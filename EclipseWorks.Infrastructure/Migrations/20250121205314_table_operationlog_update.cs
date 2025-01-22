using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EclipseWorks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class table_operationlog_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "modifieddata",
                table: "operationlog",
                newName: "oldvalue");

            migrationBuilder.AddColumn<string>(
                name: "column",
                table: "operationlog",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "newvalue",
                table: "operationlog",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "+5uID654AVsUeK5zg9fvzMNiy6PzcaKiopzAb33eGNg=", "4TOnu2+UCbyV5so9CRn97VcrqKnW4Q/6IFtjCgvRr88=", new DateTime(2025, 1, 21, 17, 53, 13, 771, DateTimeKind.Local).AddTicks(3686) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "QbTFcoZOiSfOaolWHHAwT3S0Ara7So3wq037nSImMM0=", "fLcOS31V0W7ua0c3gmJbV4v2xU/7ZUnDVIvUgiHDUsw=", new DateTime(2025, 1, 21, 17, 53, 13, 771, DateTimeKind.Local).AddTicks(3793) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "nZAplDfYFrgXy6ddzOTEvudjULRw72nydBUz0fhQEC8=", "P1++esUlgCLOFnzpsXjqpQQSax3GHYQdDNnzCVF0ES4=", new DateTime(2025, 1, 21, 17, 53, 13, 771, DateTimeKind.Local).AddTicks(3912) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "50ZMTL07UksJU5k4z1P5//YzH1uMDnry3wzcLEGP6+I=", "wx8HG67ViVgS/vqNiP8OvfckaH/xqKJc8LD+1wisNPA=", new DateTime(2025, 1, 21, 17, 53, 13, 771, DateTimeKind.Local).AddTicks(3965) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "column",
                table: "operationlog");

            migrationBuilder.DropColumn(
                name: "newvalue",
                table: "operationlog");

            migrationBuilder.RenameColumn(
                name: "oldvalue",
                table: "operationlog",
                newName: "modifieddata");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "Bgww0uoznBPlYtfo8tm/YNQohyinF/ib47IdN76tANk=", "5ex3AdaQD2k1pnObA3NOm3kPnaFoS4bdhKMIJiClr0c=", new DateTime(2025, 1, 21, 13, 45, 21, 594, DateTimeKind.Local).AddTicks(5276) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "LJCEaNu2aw/et7eFmKzEp3XArNVCQD+Nzl84SgVxd1g=", "8s45fbEH6eLpmn0svRejrgvf+K/m/LMVRot6uRTzygw=", new DateTime(2025, 1, 21, 13, 45, 21, 594, DateTimeKind.Local).AddTicks(5373) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "LYoFpSK5uQj/CcHTTmNNdo+bdlFYmKF3iVZ5n9g1HE4=", "ywDgRo6LP3g/qmx8RACcTFNBVWknwfRDgc7KxWWu5XM=", new DateTime(2025, 1, 21, 13, 45, 21, 594, DateTimeKind.Local).AddTicks(5420) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "cOK+6SZCckh5OKGvEAXG1WX+qWT2sIIp+yIxpWEwiKY=", "exsHteB5ajFQTv0nSrf6GE1akWr1AA99fcCAUWX3CnY=", new DateTime(2025, 1, 21, 13, 45, 21, 594, DateTimeKind.Local).AddTicks(5464) });
        }
    }
}
