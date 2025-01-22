using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EclipseWorks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class table_task_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "Qc8L9XZYpn/yfkgDqC5Pr7kGNbzPCaDpbxpBlNCOBaM=", "yDhoGoyp50oKIBq5dBJRTzlX4eeED1JNM1fKv57YPEA=", new DateTime(2025, 1, 21, 10, 17, 35, 151, DateTimeKind.Local).AddTicks(8720) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "KXF8rI0CQ5XJDNey+UacQY+ojVUn5yJNIx3t5i5QspM=", "1+auljn/H83G6VFsvXQbSGfs617IlCQWSi/fYANLaow=", new DateTime(2025, 1, 21, 10, 17, 35, 151, DateTimeKind.Local).AddTicks(8817) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "RH8JbOpj+OgA72bSvMd0qDwbHkJ0t5oVCMFoni7elVA=", "U/9QJoKA6R5lGJLVQ6icwVuHXI1JEQf7yk3EdGHQlKI=", new DateTime(2025, 1, 21, 10, 17, 35, 151, DateTimeKind.Local).AddTicks(8868) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "lI1aPkA9j12KNYFCKkqVkMLHUz2LpFkxqckSSOk1zZk=", "escjUQll7vFPbjGDz7OQc8X7MEgcixCeR1+C53p5/sg=", new DateTime(2025, 1, 21, 10, 17, 35, 151, DateTimeKind.Local).AddTicks(8981) });
        }
    }
}
