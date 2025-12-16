using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoGastoResidencial.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindonomedacolunadatabelaCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transicoes_Categorias_CategoriaId",
                table: "Transicoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transicoes_Pessoa_PessoaId",
                table: "Transicoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transicoes",
                table: "Transicoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa");

            migrationBuilder.RenameTable(
                name: "Transicoes",
                newName: "Transacoes");

            migrationBuilder.RenameTable(
                name: "Pessoa",
                newName: "Pessoas");

            migrationBuilder.RenameColumn(
                name: "Transicao",
                table: "Categorias",
                newName: "Descricao");

            migrationBuilder.RenameIndex(
                name: "IX_Transicoes_PessoaId",
                table: "Transacoes",
                newName: "IX_Transacoes_PessoaId");

            migrationBuilder.RenameIndex(
                name: "IX_Transicoes_CategoriaId",
                table: "Transacoes",
                newName: "IX_Transacoes_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoas",
                table: "Pessoas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Categorias_CategoriaId",
                table: "Transacoes",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Pessoas_PessoaId",
                table: "Transacoes",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Categorias_CategoriaId",
                table: "Transacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Pessoas_PessoaId",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoas",
                table: "Pessoas");

            migrationBuilder.RenameTable(
                name: "Transacoes",
                newName: "Transicoes");

            migrationBuilder.RenameTable(
                name: "Pessoas",
                newName: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Categorias",
                newName: "Transicao");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_PessoaId",
                table: "Transicoes",
                newName: "IX_Transicoes_PessoaId");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_CategoriaId",
                table: "Transicoes",
                newName: "IX_Transicoes_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transicoes",
                table: "Transicoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transicoes_Categorias_CategoriaId",
                table: "Transicoes",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transicoes_Pessoa_PessoaId",
                table: "Transicoes",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
