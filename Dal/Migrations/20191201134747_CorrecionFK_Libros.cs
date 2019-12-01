using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class CorrecionFK_Libros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autores_AutoresIdAutor",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Categorias_CategoriasIdCategoria",
                table: "Libros");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriasIdCategoria",
                table: "Libros",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AutoresIdAutor",
                table: "Libros",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autores_AutoresIdAutor",
                table: "Libros",
                column: "AutoresIdAutor",
                principalTable: "Autores",
                principalColumn: "IdAutor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Categorias_CategoriasIdCategoria",
                table: "Libros",
                column: "CategoriasIdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autores_AutoresIdAutor",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Categorias_CategoriasIdCategoria",
                table: "Libros");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriasIdCategoria",
                table: "Libros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AutoresIdAutor",
                table: "Libros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}
