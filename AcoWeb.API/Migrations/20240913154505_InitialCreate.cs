using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AcoWeb.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleInCompany = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Salary = table.Column<decimal>(type: "TEXT", maxLength: 50, nullable: false),
                    OfficeId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("170ff47b-290a-4b22-acf7-8e265afeafb5"), "	876 Chicago Avenue", "Lindsay" },
                    { new Guid("5ab77607-42e8-4a25-b47a-db8983a652e8"), "1492 Brentwood Drive", "Oscar" },
                    { new Guid("7c862b39-c6d1-4c91-8181-c6cc35890bca"), "1477 Liberty Street", "WASHINGTON" },
                    { new Guid("99bc7e9d-9033-4752-a3db-a577447a7df3"), "1698 Brown Street d", "Payson" },
                    { new Guid("a228f20b-7458-4a8c-95ba-4b209965d677"), "1641 Granville Lane", "Newark" },
                    { new Guid("ca2abc8e-1bdc-4887-8f97-215fe050f22f"), "3406 Thrash Trail", "Maud" },
                    { new Guid("d097a599-4619-4473-ae86-d353c3069597"), "784 Byers Lanet", "Redding" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "HireDate", "LastName", "OfficeId", "RoleInCompany", "Salary" },
                values: new object[,]
                {
                    { new Guid("217cfe3f-f278-4ce8-84de-d9d523ca3802"), "Diane", new DateTimeOffset(new DateTime(2022, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Perry", new Guid("d097a599-4619-4473-ae86-d353c3069597"), "Sellman", 100000m },
                    { new Guid("270ed53a-053b-442a-9302-716959d0a51a"), "Kristi", new DateTimeOffset(new DateTime(2022, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Mauricio", new Guid("5ab77607-42e8-4a25-b47a-db8983a652e8"), "Credit officer", 200000m },
                    { new Guid("3675f42d-9bbb-488f-bd36-c7e6411c87d5"), "Crystal", new DateTimeOffset(new DateTime(2022, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Krupa", new Guid("5ab77607-42e8-4a25-b47a-db8983a652e8"), "Developer", 420000m },
                    { new Guid("4fa3169e-0779-45cc-9139-dc4ee92cbd5f"), "Colton", new DateTimeOffset(new DateTime(2022, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Minton", new Guid("5ab77607-42e8-4a25-b47a-db8983a652e8"), "Backend developer", 190000m },
                    { new Guid("532c9736-4fb6-4a4d-aa8f-e7a2d6a4ca49"), "Sarah", new DateTimeOffset(new DateTime(2022, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Crews", new Guid("d097a599-4619-4473-ae86-d353c3069597"), "Sellman", 240000m },
                    { new Guid("5c0bd7ac-a87b-4e92-81bb-14de6fdc6808"), "Bart", new DateTimeOffset(new DateTime(2022, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Burgess", new Guid("d097a599-4619-4473-ae86-d353c3069597"), "Credit officer", 250000m },
                    { new Guid("6978cc16-5f5a-4020-bb79-4cc4dcc36b72"), "Antonio", new DateTimeOffset(new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "P Summers", new Guid("5ab77607-42e8-4a25-b47a-db8983a652e8"), "Manager", 200000m },
                    { new Guid("8588c7bf-2bd4-436a-a1fc-9c790895b9d5"), "Rhonda", new DateTimeOffset(new DateTime(2022, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Macklin", new Guid("ca2abc8e-1bdc-4887-8f97-215fe050f22f"), "Backend developer", 190000m },
                    { new Guid("85cbcd1f-8b72-4398-b2fe-b2776ab0be0f"), "Jessica", new DateTimeOffset(new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Gibbs", new Guid("ca2abc8e-1bdc-4887-8f97-215fe050f22f"), "Manager", 200000m },
                    { new Guid("b1ee8f72-0cc0-4cd9-bcc6-11183cf24da8"), "Thomas", new DateTimeOffset(new DateTime(2022, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Spates", new Guid("7c862b39-c6d1-4c91-8181-c6cc35890bca"), "Sellman", 200000m },
                    { new Guid("c3f4100c-f746-467b-ab9e-4c16361a44af"), "Willie", new DateTimeOffset(new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Overton", new Guid("ca2abc8e-1bdc-4887-8f97-215fe050f22f"), "Head Of Developers", 12500000m },
                    { new Guid("c5dceee6-ab09-42ab-bc30-cb0e91114b3d"), "Candy", new DateTimeOffset(new DateTime(2022, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Gilbert", new Guid("7c862b39-c6d1-4c91-8181-c6cc35890bca"), "Web developer", 500000m },
                    { new Guid("d11d3a8d-30b6-4b3a-ad9b-ab2141a2f6bb"), "Gary", new DateTimeOffset(new DateTime(2022, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Owens", new Guid("d097a599-4619-4473-ae86-d353c3069597"), "Sellman", 100000m },
                    { new Guid("d447d3e9-82d3-4aba-80ae-223a6683f5c3"), "Pattie", new DateTimeOffset(new DateTime(2022, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Foster", new Guid("7c862b39-c6d1-4c91-8181-c6cc35890bca"), "Sellman", 400000m },
                    { new Guid("ea3a236e-fda4-4e3f-ae1d-3bd3a535a177"), "Caitlin", new DateTimeOffset(new DateTime(2022, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Nicholson", new Guid("5ab77607-42e8-4a25-b47a-db8983a652e8"), "Sellman", 100000m },
                    { new Guid("f3ad3974-0c05-4db0-bda0-dee18f00a291"), "Catherine", new DateTimeOffset(new DateTime(2022, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Easley", new Guid("d097a599-4619-4473-ae86-d353c3069597"), "Web developer", 100000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OfficeId",
                table: "Employees",
                column: "OfficeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}
