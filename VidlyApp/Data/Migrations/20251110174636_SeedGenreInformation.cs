using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VidlyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedGenreInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (1, 'Action')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (2, 'Comedy')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (3, 'Family')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (4, 'Romance')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Genre WHERE Id IN (1, 2, 3, 4)");
        }
    }
}
