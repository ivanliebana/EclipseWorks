using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EclipseWorks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class table_task_update_completiondate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "completiondate",
                table: "task",
                type: "timestamp(6) without time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "JDMA+T2T1Bu4OfghY39Kw0vRoo273GvamX5YaM9g1LE=", "2Zhr60DG6xQdUKN+415GC5bDN3XJdUNo3RCUT2o5HpA=", new DateTime(2025, 1, 24, 15, 50, 14, 360, DateTimeKind.Local).AddTicks(7178) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "TIsFVUj+jJ4LSnjOxtwboe76jQkgIYInYXxCcEXz2Pc=", "KXHCEFfLxDKQXcmxmsYCQokoWUDgz7NKZQmKActufeo=", new DateTime(2025, 1, 24, 15, 50, 14, 360, DateTimeKind.Local).AddTicks(7272) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "M1I1SgZKaEAvQwDB90bqPaA1+JJG9rW2DWAbi64YjTw=", "Ff91rp9jEMCHUgtj6p5fNng5OOBguonrH4Wvtv9RA98=", new DateTime(2025, 1, 24, 15, 50, 14, 360, DateTimeKind.Local).AddTicks(7337) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "le7gU6vQPfKUPPOeqr8tg9gdG5gbW6BLR+sSwvGXiz8=", "cdDGEKm5WiecCgBwn9A6DxqF1Mn5q1ghTQbt9IWe4Us=", new DateTime(2025, 1, 24, 15, 50, 14, 360, DateTimeKind.Local).AddTicks(7385) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "completiondate",
                table: "task");

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
    }
}
