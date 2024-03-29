﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoCollectionDisplay.Migrations
{
    /// <inheritdoc />
    public partial class PhotoCategoryConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Photo",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1); //<------- Changed 0 to 1 in our defaultValue ( we Created a 1 in our table, not 0! )

            migrationBuilder.CreateIndex(
                name: "IX_Photo_CategoryId",
                table: "Photo",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Category_CategoryId",
                table: "Photo",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Category_CategoryId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_CategoryId",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Photo");
        }
    }
}
