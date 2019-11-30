using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class AjusteCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoLibro",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "IdCategoia",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "EstadoCategoria",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "NombreCategoria",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "EstadoAutor",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "NombreAutor",
                table: "Autores");

            migrationBuilder.AddColumn<string>(
                name: "AutorLibro",
                table: "Libros",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AutoresNavegacionIdAutor",
                table: "Libros",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Categoria",
                table: "Libros",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Libros",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Descripcion",
                table: "Categorias",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Categorias",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "Autores",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Autores",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Autores",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Libros_AutoresNavegacionIdAutor",
                table: "Libros",
                column: "AutoresNavegacionIdAutor");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autores_AutoresNavegacionIdAutor",
                table: "Libros",
                column: "AutoresNavegacionIdAutor",
                principalTable: "Autores",
                principalColumn: "IdAutor",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autores_AutoresNavegacionIdAutor",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_AutoresNavegacionIdAutor",
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
                name: "ISBN",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Autores");

            migrationBuilder.AddColumn<bool>(
                name: "EstadoLibro",
                table: "Libros",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "IdCategoia",
                table: "Libros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EstadoCategoria",
                table: "Categorias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NombreCategoria",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EstadoAutor",
                table: "Autores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NombreAutor",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
