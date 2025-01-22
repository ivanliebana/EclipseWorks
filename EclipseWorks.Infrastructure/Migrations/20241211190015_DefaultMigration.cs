using Microsoft.EntityFrameworkCore.Migrations;

namespace EclipseWorks.Infrastructure.Migrations
{
    public partial class DefaultMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE EXTENSION unaccent;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // You are also responsible for reverthing any changes.
        }
    }
}
