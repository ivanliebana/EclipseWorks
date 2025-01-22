using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EclipseWorks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class table_taskcomment_update_oldvalue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "oldvalue",
                table: "operationlog",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "XRkjHJYxNd/WAqJUjPqRVDnRbpMsUA0WKUBSipZSMC8=", "/l09zHexixBPkhAoklwYZRr9otgGwWlYx6IarUdKM6w=", new DateTime(2025, 1, 21, 19, 53, 59, 991, DateTimeKind.Local).AddTicks(9739) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "OArMnzGPtVue/R8ov+/dfYenOspZjVvHGNatY65Ankg=", "rg7vK96gvxDbZojUSgsn9pFB5tgScpZXuYK/1FfM6KU=", new DateTime(2025, 1, 21, 19, 53, 59, 991, DateTimeKind.Local).AddTicks(9840) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "qxfJJI/2g7RPORgNwdSHumytP/Roxbw7Q8kOeOPXkjg=", "ERK5fFyFeMB8Zmqfg718aKhfXixEjs2nwaG+72f7yYU=", new DateTime(2025, 1, 21, 19, 53, 59, 991, DateTimeKind.Local).AddTicks(9907) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "Fk6t3GHzChsXPgfnvMwuM075pIpQDNvONI1o4+E6x8U=", "LtqYyLeuqGo35nNAWpoaUm2Zf6pTf5Y8DH9gOOYYLeE=", new DateTime(2025, 1, 21, 19, 53, 59, 991, DateTimeKind.Local).AddTicks(9956) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "oldvalue",
                table: "operationlog",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "XybX3/JwX5ylzDFJynR32pa7Z0YyTlCGYnbUbpEmaMc=", "HFRvypWShsw37FMDdHCyIWQ47loXdhx0yNUWK1gqR0M=", new DateTime(2025, 1, 21, 19, 35, 54, 14, DateTimeKind.Local).AddTicks(2884) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "IHC/3hY89o8zBp2LMOENdK8aB2P6yPoyGM/iBTmwoyo=", "2aSPRw1R9cyXkw66TrayLTJ+eG89ey8uVLlu9xSEmD8=", new DateTime(2025, 1, 21, 19, 35, 54, 14, DateTimeKind.Local).AddTicks(3067) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "+gPgpeo0UfWjnJ9392iSdJGRfHE3KOaZKXleNALVSqs=", "4wu5PUZJsKCqKJmpDXUeRQ3mY4mUs0kmcTu8eLyOp40=", new DateTime(2025, 1, 21, 19, 35, 54, 14, DateTimeKind.Local).AddTicks(3128) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "xSgwLmaMvi6utWJe5KhXlQyjCNkXuqGYm36wGLtZQJ0=", "fkQjqle9RxxA5DyJhIAZWmh7LkmkdjYIuk7KEcz3LIQ=", new DateTime(2025, 1, 21, 19, 35, 54, 14, DateTimeKind.Local).AddTicks(3177) });
        }
    }
}
