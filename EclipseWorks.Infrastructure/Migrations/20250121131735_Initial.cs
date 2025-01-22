using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EclipseWorks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    password = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    hash = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    registrationdate = table.Column<DateTime>(type: "timestamp(6) without time zone", nullable: false),
                    ismanager = table.Column<bool>(type: "boolean", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "operationlog",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    table = table.Column<string>(type: "text", nullable: false),
                    modifieddata = table.Column<string>(type: "text", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp(6) without time zone", nullable: false),
                    userid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operationlog", x => x.id);
                    table.ForeignKey(
                        name: "FK_operationlog_user_userid",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project", x => x.id);
                    table.ForeignKey(
                        name: "FK_project_user_userid",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "task",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    projectid = table.Column<long>(type: "bigint", nullable: false),
                    taskpriorityid = table.Column<short>(type: "smallint", nullable: false),
                    taskstatusid = table.Column<short>(type: "smallint", nullable: false),
                    title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "character varying(800)", maxLength: 800, nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task", x => x.id);
                    table.ForeignKey(
                        name: "FK_task_project_projectid",
                        column: x => x.projectid,
                        principalTable: "project",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "taskcomment",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    taskid = table.Column<long>(type: "bigint", nullable: false),
                    comment = table.Column<string>(type: "character varying(800)", maxLength: 800, nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskcomment", x => x.id);
                    table.ForeignKey(
                        name: "FK_taskcomment_task_taskid",
                        column: x => x.taskid,
                        principalTable: "task",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "active", "email", "hash", "ismanager", "name", "password", "registrationdate" },
                values: new object[,]
                {
                    { 1L, true, "ivan@mail.com", "Qc8L9XZYpn/yfkgDqC5Pr7kGNbzPCaDpbxpBlNCOBaM=", true, "Ivan Liebana", "yDhoGoyp50oKIBq5dBJRTzlX4eeED1JNM1fKv57YPEA=", new DateTime(2025, 1, 21, 10, 17, 35, 151, DateTimeKind.Local).AddTicks(8720) },
                    { 2L, true, "aline@mail.com", "KXF8rI0CQ5XJDNey+UacQY+ojVUn5yJNIx3t5i5QspM=", false, "Aline Paula", "1+auljn/H83G6VFsvXQbSGfs617IlCQWSi/fYANLaow=", new DateTime(2025, 1, 21, 10, 17, 35, 151, DateTimeKind.Local).AddTicks(8817) },
                    { 3L, true, "marialaura@mail.com", "RH8JbOpj+OgA72bSvMd0qDwbHkJ0t5oVCMFoni7elVA=", false, "Maria Laura", "U/9QJoKA6R5lGJLVQ6icwVuHXI1JEQf7yk3EdGHQlKI=", new DateTime(2025, 1, 21, 10, 17, 35, 151, DateTimeKind.Local).AddTicks(8868) },
                    { 4L, true, "henry@mail.com", "lI1aPkA9j12KNYFCKkqVkMLHUz2LpFkxqckSSOk1zZk=", false, "Henry", "escjUQll7vFPbjGDz7OQc8X7MEgcixCeR1+C53p5/sg=", new DateTime(2025, 1, 21, 10, 17, 35, 151, DateTimeKind.Local).AddTicks(8981) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_operationlog_userid",
                table: "operationlog",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_project_userid",
                table: "project",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_task_projectid",
                table: "task",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "IX_taskcomment_taskid",
                table: "taskcomment",
                column: "taskid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "operationlog");

            migrationBuilder.DropTable(
                name: "taskcomment");

            migrationBuilder.DropTable(
                name: "task");

            migrationBuilder.DropTable(
                name: "project");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
