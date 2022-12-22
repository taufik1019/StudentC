using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SC.Migrations
{
    public partial class table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfilMahasiswas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prodi = table.Column<string>(nullable: true),
                    TanggalLahir = table.Column<DateTime>(nullable: false),
                    Semester = table.Column<int>(nullable: false),
                    Npm = table.Column<int>(nullable: false),
                    Alamat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilMahasiswas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    ProfilMahasiswaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_ProfilMahasiswas_Id",
                        column: x => x.Id,
                        principalTable: "ProfilMahasiswas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Keluhans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    KeluhanMhs = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keluhans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Keluhans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponKeluhans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    KeluhanId = table.Column<int>(nullable: false),
                    KeluhanMhs = table.Column<string>(nullable: true),
                    Respon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponKeluhans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponKeluhans_Keluhans_KeluhanId",
                        column: x => x.KeluhanId,
                        principalTable: "Keluhans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Keluhans_UserId",
                table: "Keluhans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponKeluhans_KeluhanId",
                table: "ResponKeluhans",
                column: "KeluhanId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponKeluhans");

            migrationBuilder.DropTable(
                name: "Keluhans");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProfilMahasiswas");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
