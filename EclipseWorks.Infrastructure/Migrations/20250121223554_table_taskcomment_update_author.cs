using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EclipseWorks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class table_taskcomment_update_author : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "authorid",
                table: "taskcomment",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "authorid",
                table: "taskcomment");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "nna/e58iKP5BTbCabSTqFB1qyGfhghCaOwoDJT+pGZU=", "aIo1GOtpgDx7q3Pdt72cpvcXnS8+6DqD2sm0DLvXtjw=", new DateTime(2025, 1, 21, 19, 11, 40, 579, DateTimeKind.Local).AddTicks(5616) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "gNIcHcTowv8trea8SBauCmtX9GbbfY7yJvjCEWG2/Pg=", "vXg+und/BxnBk3mfsK4pYXBGApEsfGDMQ34nrvxtbHo=", new DateTime(2025, 1, 21, 19, 11, 40, 579, DateTimeKind.Local).AddTicks(6119) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "KeELVcME3dMoUodI0Laou8JV4dDt67j0coov5vTs+wQ=", "7bmHHB/yvBlvzZ21qrn5fpZ28OD7wj6PztGju8r+Eeg=", new DateTime(2025, 1, 21, 19, 11, 40, 579, DateTimeKind.Local).AddTicks(6488) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "hash", "password", "registrationdate" },
                values: new object[] { "Z49PDWv8uONKlDaFgwQd/vm8db37erIIreYggnIlbHQ=", "a1X8kuC5xLyjSAXlo2tRCV92Y8e/adsvLkB10d+5COQ=", new DateTime(2025, 1, 21, 19, 11, 40, 579, DateTimeKind.Local).AddTicks(6816) });
        }
    }
}
