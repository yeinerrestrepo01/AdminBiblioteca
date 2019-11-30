using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    IdAutor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAutor = table.Column<string>(nullable: true),
                    EstadoAutor = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.IdAutor);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoria = table.Column<string>(nullable: true),
                    EstadoCategoria = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    IdLibro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreLibro = table.Column<string>(nullable: true),
                    EstadoLibro = table.Column<bool>(nullable: false),
                    IdCategoia = table.Column<int>(nullable: false),
                    CategoriaNavegacionIdCategoria = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.IdLibro);
                    table.ForeignKey(
                        name: "FK_Libros_Categorias_CategoriaNavegacionIdCategoria",
                        column: x => x.CategoriaNavegacionIdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_CategoriaNavegacionIdCategoria",
                table: "Libros",
                column: "CategoriaNavegacionIdCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
