using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class Ajuste_llave_Foraneas_Libros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autores_AutoresNavegacionIdAutor",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Categorias_CategoriaNavegacionIdCategoria",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_AutoresNavegacionIdAutor",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_CategoriaNavegacionIdCategoria",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "AutorLibro",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "AutoresNavegacionIdAutor",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "CategoriaNavegacionIdCategoria",
                table: "Libros");

            migrationBuilder.AddColumn<int>(
                name: "AutoresIdAutor",
                table: "Libros",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriasIdCategoria",
                table: "Libros",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Libros_AutoresIdAutor",
                table: "Libros",
                column: "AutoresIdAutor");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_CategoriasIdCategoria",
                table: "Libros",
                column: "CategoriasIdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autores_AutoresIdAutor",
                table: "Libros",
                column: "AutoresIdAutor",
                principalTable: "Autores",
                principalColumn: "IdAutor",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Categorias_CategoriasIdCategoria",
                table: "Libros",
                column: "CategoriasIdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autores_AutoresIdAutor",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Categorias_CategoriasIdCategoria",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_AutoresIdAutor",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_CategoriasIdCategoria",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "AutoresIdAutor",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "CategoriasIdCategoria",
                table: "Libros");

            migrationBuilder.AddColumn<string>(
                name: "AutorLibro",
                table: "Libros",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AutoresNavegacionIdAutor",
                table: "Libros",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Categoria",
                table: "Libros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaNavegacionIdCategoria",
                table: "Libros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Libros_AutoresNavegacionIdAutor",
                table: "Libros",
                column: "AutoresNavegacionIdAutor");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_CategoriaNavegacionIdCategoria",
                table: "Libros",
                column: "CategoriaNavegacionIdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autores_AutoresNavegacionIdAutor",
                table: "Libros",
                column: "AutoresNavegacionIdAutor",
                principalTable: "Autores",
                principalColumn: "IdAutor",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Categorias_CategoriaNavegacionIdCategoria",
                table: "Libros",
                column: "CategoriaNavegacionIdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
