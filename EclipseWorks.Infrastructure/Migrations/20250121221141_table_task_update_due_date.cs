using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EclipseWorks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class table_task_update_due_date : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "duedate",
                table: "task",
                type: "timestamp(6) without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "duedate",
                table: "task");

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
    }
}
