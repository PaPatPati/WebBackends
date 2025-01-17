using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bidding.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_ListedArticles_ListedArticleId",
                table: "Bids");

            migrationBuilder.RenameColumn(
                name: "PathToImage",
                table: "ListedArticles",
                newName: "Image");

            migrationBuilder.AlterColumn<int>(
                name: "ListedArticleId",
                table: "Bids",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_ListedArticles_ListedArticleId",
                table: "Bids",
                column: "ListedArticleId",
                principalTable: "ListedArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_ListedArticles_ListedArticleId",
                table: "Bids");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "ListedArticles",
                newName: "PathToImage");

            migrationBuilder.AlterColumn<int>(
                name: "ListedArticleId",
                table: "Bids",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_ListedArticles_ListedArticleId",
                table: "Bids",
                column: "ListedArticleId",
                principalTable: "ListedArticles",
                principalColumn: "Id");
        }
    }
}
