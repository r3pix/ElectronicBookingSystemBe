using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicLibrary.Persistance.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BorrowPrice = table.Column<float>(type: "real", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LMDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LMEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LMDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LMEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookPiece",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReleaseYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LMDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LMEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPiece", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookPiece_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LMDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LMEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Borrow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Penalty = table.Column<float>(type: "real", nullable: false),
                    SumBorrowPrice = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LMDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LMEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Borrow_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LMDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LMEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identity_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookPieceBorrow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookPieceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BorrowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LMDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LMEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPieceBorrow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookPieceBorrow_BookPiece_BookPieceId",
                        column: x => x.BookPieceId,
                        principalTable: "BookPiece",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookPieceBorrow_Borrow_BorrowId",
                        column: x => x.BorrowId,
                        principalTable: "Borrow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BorrowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LMDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LMEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryAddress_Borrow_BorrowId",
                        column: x => x.BorrowId,
                        principalTable: "Borrow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookPiece_BookId",
                table: "BookPiece",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookPieceBorrow_BookPieceId",
                table: "BookPieceBorrow",
                column: "BookPieceId");

            migrationBuilder.CreateIndex(
                name: "IX_BookPieceBorrow_BorrowId",
                table: "BookPieceBorrow",
                column: "BorrowId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrow_UserId",
                table: "Borrow",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAddress_BorrowId",
                table: "DeliveryAddress",
                column: "BorrowId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Identity_UserId",
                table: "Identity",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookPieceBorrow");

            migrationBuilder.DropTable(
                name: "DeliveryAddress");

            migrationBuilder.DropTable(
                name: "Identity");

            migrationBuilder.DropTable(
                name: "BookPiece");

            migrationBuilder.DropTable(
                name: "Borrow");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
