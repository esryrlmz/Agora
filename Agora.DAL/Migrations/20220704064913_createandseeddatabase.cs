using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agora.DAL.Migrations
{
    public partial class createandseeddatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TownName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Towns_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "varchar(150)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(11)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Towner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserDetails_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "varchar(80)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsCargo = table.Column<bool>(type: "bit", nullable: false),
                    IsHandDeliver = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    TownID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Towns_TownID",
                        column: x => x.TownID,
                        principalTable: "Towns",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Users_TownID",
                        column: x => x.TownID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interpretation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCheck = table.Column<bool>(type: "bit", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comment_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPictures",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureUrl = table.Column<string>(type: "varchar(300)", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPictures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductPictures_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "varchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductStatus = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Transfer_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transfer_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoTrackingNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    CargoFirm = table.Column<string>(type: "varchar(30)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranserID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cargos_Transfer_TranserID",
                        column: x => x.TranserID,
                        principalTable: "Transfer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CityName", "CreatedDate", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 1, "Adana", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4163), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 60, "Tokat", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4543), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 59, "Tekirdağ", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4542), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 58, "Sivas", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4541), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 57, "Sinop", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4540), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 56, "Siirt", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4539), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 55, "Samsun", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4538), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 54, "Sakarya", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4537), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 61, "Trabzon", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4544), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 53, "Rize", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4535), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 51, "Niğde", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4533), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 50, "Nevşehir", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4532), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 49, "Muş", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4531), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 48, "Muğla", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4530), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 47, "Mardin", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4529), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 46, "Kahramanmaraş", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4527), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 45, "Manisa", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 52, "Ordu", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4534), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 62, "Tunceli", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4545), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 63, "Şanlıurfa", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4546), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 64, "Uşak", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4547), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 81, "Düzce", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4564), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 80, "Osmaniye", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4563), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 79, "Kilis", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4562), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 78, "Karabük", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4561), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 77, "Yalova", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4560), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 76, "Iğdır", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4559), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 75, "Ardahan", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4558), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 74, "Bartın", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4557), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 73, "Şırnak", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4556), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 72, "Batman", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4555), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 71, "Kırıkkale", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4554), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 70, "Karaman", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4553), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 69, "Bayburt", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4552), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 68, "Aksaray", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4551), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 67, "Zonguldak", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4550), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 66, "Yozgat", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4549), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 65, "Van", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4548), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 44, "Malatya", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4525), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 43, "Kütahya", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4524), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 42, "Konya", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4523), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, "Diyarbakır", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4494), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CityName", "CreatedDate", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 19, "Çorum", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4492), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, "Çankırı", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4491), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, "Çanakkale", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4441), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, "Bursa", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4440), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, "Burdur", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4439), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, "Bolu", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4438), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, "Bitlis", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4437), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, "Denizli", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4493), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, "Bingöl", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4436), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, "Balıkesir", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4434), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, "Aydın", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4433), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, "Artvin", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4432), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, "Antalya", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4431), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, "Ankara", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4430), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, "Amasya", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4428), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, "Ağrı", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4427), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, "Bilecik", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4435), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 41, "Kocaeli", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4522), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, "Edirne", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4495), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 23, "Elazığ", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4496), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 40, "Kırşehir", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4521), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 39, "Kırklareli", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4520), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 38, "Kayseri", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4518), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 37, "Kastamonu", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4517), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 36, "Kars", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4516), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 35, "İzmir", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4515), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 34, "İstanbul", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4514), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 33, "Mersin", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4513), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 32, "Isparta", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4512), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 31, "Hatay", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4511), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 30, "Hakkari", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4510), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 29, "Gümüşhane", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4509), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 28, "Giresun", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4508), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 27, "Gaziantep", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4507), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 26, "Eskişehir", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4505), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 25, "Erzurum", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4498), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 24, "Erzincan", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4497), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "Afyonkarahisar", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4425), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Adıyaman", new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(4421), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "CreatedDate", "ModifiedDate", "Password", "Role", "Status", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 4, 9, 49, 13, 444, DateTimeKind.Local).AddTicks(3543), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$OqzBcWcJ54kEslrlqG2CuuSv3fClvtwpEAyuJFPuiEm97LWxDqebG", 1, 1, "admin" },
                    { 2, new DateTime(2022, 7, 4, 9, 49, 13, 445, DateTimeKind.Local).AddTicks(3177), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$OqzBcWcJ54kEslrlqG2CuuSv3fClvtwpEAyuJFPuiEm97LWxDqebG", 1, 1, "esra" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5080), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Seyhan" },
                    { 641, 46, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6445), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ekinözü" },
                    { 642, 46, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6446), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nurhak" },
                    { 643, 46, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dulkadiroğlu" },
                    { 644, 46, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6448), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Onikişubat" },
                    { 645, 47, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6449), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Derik" },
                    { 646, 47, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6450), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kızıltepe" },
                    { 647, 47, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6451), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mazıdağı" },
                    { 648, 47, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6453), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Midyat" },
                    { 649, 47, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6454), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nusaybin" },
                    { 650, 47, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6455), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ömerli" },
                    { 651, 47, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6456), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Savur" },
                    { 652, 47, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6457), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dargeçit" },
                    { 640, 46, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6444), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çağlayancerit" },
                    { 653, 47, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6458), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yeşilli" },
                    { 655, 48, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6460), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bodrum" },
                    { 656, 48, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6461), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Datça" },
                    { 657, 48, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6462), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Fethiye" },
                    { 658, 48, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6463), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Köyceğiz" },
                    { 659, 48, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6464), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marmaris" },
                    { 660, 48, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6465), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Milas" },
                    { 661, 48, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6467), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ula" },
                    { 662, 48, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6468), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yatağan" },
                    { 663, 48, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6469), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dalaman" },
                    { 664, 48, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6470), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ortaca" },
                    { 665, 48, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6471), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kavaklıdere" },
                    { 666, 48, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6472), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Menteşe" },
                    { 654, 47, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6459), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Artuklu" },
                    { 667, 48, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6473), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Seydikemer" },
                    { 639, 46, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6443), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Türkoğlu" },
                    { 637, 46, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6441), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Göksun" },
                    { 611, 44, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6412), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yeşilyurt" },
                    { 612, 44, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6413), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Battalgazi" },
                    { 613, 44, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6414), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Doğanyol" },
                    { 614, 44, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6415), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kale" },
                    { 615, 44, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6416), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kuluncak" },
                    { 616, 44, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6417), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yazıhan" },
                    { 617, 45, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6418), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akhisar" },
                    { 618, 45, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6420), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alaşehir" },
                    { 619, 45, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6421), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Demirci" },
                    { 620, 45, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6422), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gördes" },
                    { 621, 45, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6424), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kırkağaç" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 622, 45, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6425), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kula" },
                    { 638, 46, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6442), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pazarcık" },
                    { 623, 45, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6426), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Salihli" },
                    { 625, 45, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6428), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Saruhanlı" },
                    { 626, 45, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6429), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Selendi" },
                    { 627, 45, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6430), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Soma" },
                    { 628, 45, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6431), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Turgutlu" },
                    { 629, 45, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6432), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ahmetli" },
                    { 630, 45, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6433), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gölmarmara" },
                    { 631, 45, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6434), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Köprübaşı" },
                    { 632, 45, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6435), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şehzadeler" },
                    { 633, 45, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6436), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yunusemre" },
                    { 634, 46, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6437), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Afşin" },
                    { 635, 46, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6438), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Andırın" },
                    { 636, 46, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6440), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Elbistan" },
                    { 624, 45, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6427), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarıgöl" },
                    { 668, 49, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6474), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bulanık" },
                    { 669, 49, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6475), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Malazgirt" },
                    { 670, 49, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6476), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Muş Merkez" },
                    { 702, 52, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6511), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çaybaşı" },
                    { 703, 52, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6512), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İkizce" },
                    { 704, 52, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6513), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kabadüz" },
                    { 705, 52, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6514), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kabataş" },
                    { 706, 52, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6515), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Altınordu" },
                    { 707, 53, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6517), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ardeşen" },
                    { 708, 53, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6518), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çamlıhemşin" },
                    { 709, 53, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6519), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çayeli" },
                    { 710, 53, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6520), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Fındıklı" },
                    { 711, 53, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6521), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İkizdere" },
                    { 712, 53, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6522), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kalkandere" },
                    { 713, 53, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6523), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pazar" },
                    { 701, 52, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6510), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çatalpınar" },
                    { 714, 53, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6524), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Rize Merkez" },
                    { 716, 53, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6553), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Derepazarı" },
                    { 717, 53, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6554), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hemşin" },
                    { 718, 53, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6556), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İyidere" },
                    { 719, 54, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6557), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akyazı" },
                    { 720, 54, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6558), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Geyve" },
                    { 721, 54, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6559), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hendek" },
                    { 722, 54, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6560), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karasu" },
                    { 723, 54, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6561), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kaynarca" },
                    { 724, 54, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6562), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sapanca" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 725, 54, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6563), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kocaali" },
                    { 726, 54, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6564), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pamukova" },
                    { 727, 54, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6565), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Taraklı" },
                    { 715, 53, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Güneysu" },
                    { 700, 52, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6509), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çamaş" },
                    { 699, 52, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6508), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gürgentepe" },
                    { 698, 52, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6507), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gülyalı" },
                    { 671, 49, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6477), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Varto" },
                    { 672, 49, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6478), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hasköy" },
                    { 673, 49, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6479), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Korkut" },
                    { 674, 50, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6480), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Avanos" },
                    { 675, 50, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6481), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Derinkuyu" },
                    { 676, 50, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6482), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gülşehir" },
                    { 677, 50, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6484), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hacıbektaş" },
                    { 678, 50, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6485), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kozaklı" },
                    { 679, 50, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6486), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 680, 50, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6487), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ürgüp" },
                    { 681, 50, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6489), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Acıgöl" },
                    { 682, 51, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6490), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bor" },
                    { 683, 51, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6491), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çamardı" },
                    { 684, 51, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6492), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 685, 51, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6493), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ulukışla" },
                    { 686, 51, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6494), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Altunhisar" },
                    { 687, 51, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6495), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çiftlik" },
                    { 688, 52, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6496), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akkuş" },
                    { 689, 52, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6497), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aybastı" },
                    { 690, 52, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6498), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Fatsa" },
                    { 691, 52, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6500), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gölköy" },
                    { 692, 52, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6501), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Korgan" },
                    { 693, 52, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6502), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kumru" },
                    { 694, 52, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6503), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mesudiye" },
                    { 695, 52, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6504), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Perşembe" },
                    { 696, 52, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6505), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ulubey" },
                    { 697, 52, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6506), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ünye" },
                    { 610, 44, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6411), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pütürge" },
                    { 609, 44, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6410), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hekimhan" },
                    { 608, 44, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6409), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Doğanşehir" },
                    { 607, 44, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6408), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Darende" },
                    { 520, 38, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6285), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İncesu" },
                    { 521, 38, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6286), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pınarbaşı" },
                    { 522, 38, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6287), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarıoğlan" },
                    { 523, 38, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6288), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarız" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 524, 38, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6289), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tomarza" },
                    { 525, 38, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6290), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yahyalı" },
                    { 526, 38, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6292), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yeşilhisar" },
                    { 527, 38, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6293), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akkışla" },
                    { 528, 38, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6294), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Talas" },
                    { 529, 38, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6295), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kocasinan" },
                    { 530, 38, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6296), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Melikgazi" },
                    { 531, 38, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6297), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hacılar" },
                    { 519, 38, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6284), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Felahiye" },
                    { 532, 38, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6298), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Özvatan" },
                    { 534, 39, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6301), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Demirköy" },
                    { 535, 39, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6302), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 536, 39, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6303), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kofçaz" },
                    { 537, 39, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6304), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lüleburgaz" },
                    { 538, 39, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6305), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pehlivanköy" },
                    { 539, 39, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6306), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pınarhisar" },
                    { 540, 39, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6307), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Vize" },
                    { 541, 40, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6308), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çiçekdağı" },
                    { 542, 40, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6309), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kaman" },
                    { 543, 40, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6310), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 544, 40, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6311), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mucur" },
                    { 545, 40, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6312), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akpınar" },
                    { 533, 39, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6300), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Babaeski" },
                    { 518, 38, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6283), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Develi" },
                    { 517, 38, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6282), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bünyan" },
                    { 516, 37, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6281), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Seydiler" },
                    { 489, 36, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6252), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Arpaçay" },
                    { 490, 36, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6253), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Digor" },
                    { 491, 36, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6254), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kağızman" },
                    { 492, 36, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6255), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 493, 36, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6257), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarıkamış" },
                    { 494, 36, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6258), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Selim" },
                    { 495, 36, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6259), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Susuz" },
                    { 496, 36, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6260), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akyaka" },
                    { 497, 37, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6261), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Abana" },
                    { 498, 37, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6262), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Araç" },
                    { 499, 37, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6263), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Azdavay" },
                    { 500, 37, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6264), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bozkurt" },
                    { 501, 37, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6265), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cide" },
                    { 502, 37, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6266), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çatalzeytin" },
                    { 503, 37, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6267), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Daday" },
                    { 504, 37, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6268), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Devrekani" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 505, 37, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6269), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İnebolu" },
                    { 506, 37, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6270), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 507, 37, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6271), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Küre" },
                    { 508, 37, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6272), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Taşköprü" },
                    { 509, 37, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6273), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tosya" },
                    { 510, 37, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6274), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İhsangazi" },
                    { 511, 37, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6276), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pınarbaşı" },
                    { 512, 37, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6277), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şenpazar" },
                    { 513, 37, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6278), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ağlı" },
                    { 514, 37, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6279), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Doğanyurt" },
                    { 515, 37, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6280), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hanönü" },
                    { 546, 40, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6313), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akçakent" },
                    { 728, 54, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6566), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ferizli" },
                    { 547, 40, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6314), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Boztepe" },
                    { 549, 41, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6316), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gölcük" },
                    { 581, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6352), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Selçuklu" },
                    { 582, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6353), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Taşkent" },
                    { 583, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6354), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ahırlı" },
                    { 584, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6355), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çeltik" },
                    { 585, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6356), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Derbent" },
                    { 586, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6357), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Emirgazi" },
                    { 587, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6358), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Güneysınır" },
                    { 588, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6360), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Halkapınar" },
                    { 589, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6361), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tuzlukçu" },
                    { 590, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6362), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yalıhüyük" },
                    { 591, 43, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6363), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Altıntaş" },
                    { 592, 43, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6364), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Domaniç" },
                    { 580, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6351), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Meram" },
                    { 593, 43, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6365), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Emet" },
                    { 595, 43, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6367), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 596, 43, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6368), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Simav" },
                    { 597, 43, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6369), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tavşanlı" },
                    { 598, 43, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6371), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aslanapa" },
                    { 599, 43, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6372), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dumlupınar" },
                    { 600, 43, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6373), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hisarcık" },
                    { 601, 43, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6374), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şaphane" },
                    { 602, 43, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6375), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çavdarhisar" },
                    { 603, 43, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6403), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pazarlar" },
                    { 604, 44, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6405), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akçadağ" },
                    { 605, 44, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6406), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Arapgir" },
                    { 606, 44, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6407), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Arguvan" },
                    { 594, 43, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6366), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gediz" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 579, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6350), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karatay" },
                    { 578, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6349), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hüyük" },
                    { 577, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6348), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Derebucak" },
                    { 550, 41, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6317), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kandıra" },
                    { 551, 41, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6319), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karamürsel" },
                    { 552, 41, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6320), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Körfez" },
                    { 553, 41, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6321), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Derince" },
                    { 554, 41, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6322), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Başiskele" },
                    { 555, 41, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6323), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çayırova" },
                    { 556, 41, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6324), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Darıca" },
                    { 557, 41, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6325), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dilovası" },
                    { 558, 41, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6327), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İzmit" },
                    { 559, 41, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6328), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kartepe" },
                    { 560, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6329), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akşehir" },
                    { 561, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6330), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beyşehir" },
                    { 562, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6331), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bozkır" },
                    { 563, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6332), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cihanbeyli" },
                    { 564, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6333), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çumra" },
                    { 565, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6334), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Doğanhisar" },
                    { 566, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6335), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Konya" },
                    { 567, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6337), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hadim" },
                    { 568, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6338), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ilgın" },
                    { 569, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6339), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kadınhanı" },
                    { 570, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6340), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karapınar" },
                    { 571, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6341), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kulu" },
                    { 572, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6342), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarayönü" },
                    { 573, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6343), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Seydişehir" },
                    { 574, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6344), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yunak" },
                    { 575, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6345), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akören" },
                    { 576, 42, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6346), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Altınekin" },
                    { 548, 41, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6315), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gebze" },
                    { 488, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6224), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karabağlar" },
                    { 729, 54, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6567), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karapürçek" },
                    { 731, 54, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6569), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Adapazarı" },
                    { 884, 67, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6761), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alaplı" },
                    { 885, 67, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6762), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gökçebey" },
                    { 886, 67, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6763), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kilimli" },
                    { 887, 67, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6765), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kozlu" },
                    { 888, 68, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6766), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 889, 68, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6767), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ortaköy" },
                    { 890, 68, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6768), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ağaçören" },
                    { 891, 68, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6770), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Güzelyurt" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 892, 68, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6771), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarıyahşi" },
                    { 893, 68, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6772), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eskil" },
                    { 894, 68, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6773), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gülağaç" },
                    { 895, 69, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6774), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 883, 67, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6760), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 896, 69, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6775), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aydıntepe" },
                    { 898, 70, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6777), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ermenek" },
                    { 899, 70, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6778), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 900, 70, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6779), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ayrancı" },
                    { 901, 70, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6780), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kazımkarabekir" },
                    { 902, 70, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6781), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Başyayla" },
                    { 903, 70, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6782), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarıveliler" },
                    { 904, 71, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6783), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Delice" },
                    { 905, 71, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6784), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Keskin" },
                    { 906, 71, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6785), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 907, 71, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6786), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sulakyurt" },
                    { 908, 71, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6787), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bahşili" },
                    { 909, 71, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6788), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Balışeyh" },
                    { 897, 69, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6776), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Demirözü" },
                    { 910, 71, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6790), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çelebi" },
                    { 882, 67, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6759), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ereğli" },
                    { 880, 67, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6757), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çaycuma" },
                    { 854, 65, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6729), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çatak" },
                    { 855, 65, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6730), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Erciş" },
                    { 856, 65, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6731), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gevaş" },
                    { 857, 65, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6732), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gürpınar" },
                    { 858, 65, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6733), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Muradiye" },
                    { 859, 65, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6735), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Özalp" },
                    { 860, 65, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6736), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bahçesaray" },
                    { 861, 65, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6737), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çaldıran" },
                    { 862, 65, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6738), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Edremit" },
                    { 863, 65, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6739), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Saray" },
                    { 864, 65, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6740), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İpekyolu" },
                    { 865, 65, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6741), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tuşba" },
                    { 881, 67, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6758), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Devrek" },
                    { 866, 66, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6742), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akdağmadeni" },
                    { 868, 66, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6745), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çayıralan" },
                    { 869, 66, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6746), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çekerek" },
                    { 870, 66, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6747), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarıkaya" },
                    { 871, 66, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6748), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sorgun" },
                    { 872, 66, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6749), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şefaatli" },
                    { 873, 66, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6750), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yerköy" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 874, 66, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6751), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yozgat Merkez" },
                    { 875, 66, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6752), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aydıncık" },
                    { 876, 66, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6753), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çandır" },
                    { 877, 66, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6754), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kadışehri" },
                    { 878, 66, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6755), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Saraykent" },
                    { 879, 66, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6756), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yenifakılı" },
                    { 867, 66, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6744), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Boğazlıyan" },
                    { 911, 71, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6791), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karakeçili" },
                    { 912, 71, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6792), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yahşihan" },
                    { 913, 72, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6793), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 945, 77, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6855), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Termal" },
                    { 946, 78, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6856), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eflani" },
                    { 947, 78, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6857), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eskipazar" },
                    { 948, 78, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6858), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 949, 78, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6859), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ovacık" },
                    { 950, 78, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6861), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Safranbolu" },
                    { 951, 78, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6862), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yenice" },
                    { 952, 79, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6863), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 953, 79, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6864), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Elbeyli" },
                    { 954, 79, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6865), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Musabeyli" },
                    { 955, 79, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6866), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Polateli" },
                    { 956, 80, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6867), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bahçe" },
                    { 944, 77, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6854), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çiftlikköy" },
                    { 957, 80, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6868), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kadirli" },
                    { 959, 80, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6871), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Düziçi" },
                    { 960, 80, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6872), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hasanbeyli" },
                    { 961, 80, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6873), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sumbas" },
                    { 962, 80, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6874), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Toprakkale" },
                    { 963, 81, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6875), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akçakoca" },
                    { 964, 81, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6876), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 965, 81, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yığılca" },
                    { 966, 81, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6879), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cumayeri" },
                    { 967, 81, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6880), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gölyaka" },
                    { 968, 81, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6881), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çilimli" },
                    { 969, 81, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6882), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gümüşova" },
                    { 970, 81, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6883), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kaynaşlı" },
                    { 958, 80, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6869), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 943, 77, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6853), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çınarcık" },
                    { 942, 77, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6824), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Armutlu" },
                    { 941, 77, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6823), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Altınova" },
                    { 914, 72, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6794), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beşiri" },
                    { 915, 72, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6795), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gercüş" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 916, 72, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6796), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kozluk" },
                    { 917, 72, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6797), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sason" },
                    { 918, 72, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6798), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hasankeyf" },
                    { 919, 73, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6800), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beytüşşebap" },
                    { 920, 73, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6801), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cizre" },
                    { 921, 73, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6802), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İdil" },
                    { 922, 73, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6803), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Silopi" },
                    { 923, 73, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6804), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 924, 73, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6805), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Uludere" },
                    { 925, 73, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6807), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Güçlükonak" },
                    { 926, 74, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6808), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 927, 74, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6809), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kurucaşile" },
                    { 928, 74, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6810), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ulus" },
                    { 929, 74, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6811), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Amasra" },
                    { 930, 75, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6812), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 931, 75, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6813), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çıldır" },
                    { 932, 75, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6814), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Göle" },
                    { 933, 75, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6815), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hanak" },
                    { 934, 75, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6816), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Posof" },
                    { 935, 75, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6817), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Damal" },
                    { 936, 76, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6818), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aralık" },
                    { 937, 76, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6819), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 938, 76, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6820), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tuzluca" },
                    { 939, 76, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6821), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karakoyunlu" },
                    { 940, 77, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6822), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 853, 65, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6728), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Başkale" },
                    { 852, 64, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6727), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Uşak Merkez" },
                    { 851, 64, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6726), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ulubey" },
                    { 850, 64, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6725), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sivaslı" },
                    { 763, 57, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6604), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gerze" },
                    { 764, 57, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6605), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 765, 57, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6606), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Türkeli" },
                    { 766, 57, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6607), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dikmen" },
                    { 767, 57, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6608), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Saraydüzü" },
                    { 768, 58, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6609), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Divriği" },
                    { 769, 58, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6611), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gemerek" },
                    { 770, 58, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6612), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gürün" },
                    { 771, 58, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6613), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hafik" },
                    { 772, 58, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6614), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İmranlı" },
                    { 773, 58, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6615), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kangal" },
                    { 774, 58, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6616), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Koyulhisar" },
                    { 762, 57, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6603), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Erfelek" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 775, 58, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6617), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 777, 58, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6619), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şarkışla" },
                    { 778, 58, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6620), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yıldızeli" },
                    { 779, 58, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6621), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Zara" },
                    { 780, 58, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6622), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akıncılar" },
                    { 781, 58, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6624), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Altınyayla" },
                    { 782, 58, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6625), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Doğanşar" },
                    { 783, 58, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6626), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gölova" },
                    { 784, 58, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6627), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ulaş" },
                    { 785, 59, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6628), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çerkezköy" },
                    { 786, 59, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6629), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çorlu" },
                    { 787, 59, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6630), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hayrabolu" },
                    { 788, 59, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6631), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Malkara" },
                    { 776, 58, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6618), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Suşehri" },
                    { 761, 57, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6602), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Durağan" },
                    { 760, 57, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6601), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Boyabat" },
                    { 759, 57, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6600), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ayancık" },
                    { 732, 54, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6570), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Arifiye" },
                    { 733, 54, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6571), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Erenler" },
                    { 734, 54, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6572), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Serdivan" },
                    { 735, 55, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6573), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alaçam" },
                    { 736, 55, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6574), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bafra" },
                    { 737, 55, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6575), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çarşamba" },
                    { 738, 55, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6577), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Havza" },
                    { 739, 55, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6578), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kavak" },
                    { 740, 55, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6579), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ladik" },
                    { 741, 55, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6580), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Terme" },
                    { 742, 55, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6582), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Vezirköprü" },
                    { 743, 55, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6583), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Asarcık" },
                    { 744, 55, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6584), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "43604" },
                    { 745, 55, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6585), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Salıpazarı" },
                    { 746, 55, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6586), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tekkeköy" },
                    { 747, 55, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6587), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ayvacık" },
                    { 748, 55, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6588), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yakakent" },
                    { 749, 55, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6589), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Atakum" },
                    { 750, 55, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6590), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Canik" },
                    { 751, 55, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6591), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İlkadım" },
                    { 752, 56, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6592), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Baykan" },
                    { 753, 56, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6593), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eruh" },
                    { 754, 56, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6594), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kurtalan" },
                    { 755, 56, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6595), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pervari" },
                    { 756, 56, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6596), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 757, 56, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6597), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şirvan" },
                    { 758, 56, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6599), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tillo" },
                    { 789, 59, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6632), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Muratlı" },
                    { 730, 54, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6568), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Söğütlü" },
                    { 790, 59, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6633), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Saray" },
                    { 792, 59, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6635), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marmaraereğlisi" },
                    { 824, 61, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6669), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Köprübaşı" },
                    { 825, 61, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6670), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ortahisar" },
                    { 826, 62, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6672), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çemişgezek" },
                    { 827, 62, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6673), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hozat" },
                    { 828, 62, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6674), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mazgirt" },
                    { 829, 62, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6675), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nazımiye" },
                    { 830, 62, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6704), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ovacık" },
                    { 831, 62, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6705), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pertek" },
                    { 832, 62, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6706), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pülümür" },
                    { 833, 62, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6707), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 834, 63, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6708), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akçakale" },
                    { 835, 63, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6709), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Birecik" },
                    { 823, 61, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6668), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hayrat" },
                    { 836, 63, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6710), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bozova" },
                    { 838, 63, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6712), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Halfeti" },
                    { 839, 63, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6713), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hilvan" },
                    { 840, 63, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6714), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Siverek" },
                    { 841, 63, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6715), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Suruç" },
                    { 842, 63, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6717), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Viranşehir" },
                    { 843, 63, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6718), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Harran" },
                    { 844, 63, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6719), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eyyübiye" },
                    { 845, 63, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6720), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Haliliye" },
                    { 846, 63, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6721), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karaköprü" },
                    { 847, 64, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6722), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Banaz" },
                    { 848, 64, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6723), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eşme" },
                    { 849, 64, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6724), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karahallı" },
                    { 837, 63, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6711), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ceylanpınar" },
                    { 822, 61, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6667), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Düzköy" },
                    { 821, 61, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6666), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dernekpazarı" },
                    { 820, 61, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6665), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çarşıbaşı" },
                    { 793, 59, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6636), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ergene" },
                    { 794, 59, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6637), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kapaklı" },
                    { 795, 59, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6638), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Süleymanpaşa" },
                    { 796, 60, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6639), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Almus" },
                    { 797, 60, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6640), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Artova" },
                    { 798, 60, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6641), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Erbaa" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 799, 60, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6643), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Niksar" },
                    { 800, 60, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6644), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Reşadiye" },
                    { 801, 60, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6645), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tokat Merkez" },
                    { 802, 60, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6646), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Turhal" },
                    { 803, 60, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6647), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Zile" },
                    { 804, 60, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6648), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pazar" },
                    { 805, 60, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6649), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yeşilyurt" },
                    { 806, 60, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6650), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Başçiftlik" },
                    { 807, 60, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6651), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sulusaray" },
                    { 808, 61, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6652), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akçaabat" },
                    { 809, 61, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6654), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Araklı" },
                    { 810, 61, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6655), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Arsin" },
                    { 811, 61, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6656), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çaykara" },
                    { 812, 61, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6657), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Maçka" },
                    { 813, 61, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6658), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Of" },
                    { 814, 61, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6659), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sürmene" },
                    { 815, 61, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6660), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tonya" },
                    { 816, 61, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6661), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Vakfıkebir" },
                    { 817, 61, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6662), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yomra" },
                    { 818, 61, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6663), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beşikdüzü" },
                    { 819, 61, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6664), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şalpazarı" },
                    { 791, 59, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6634), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şarköy" },
                    { 487, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6223), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bayraklı" },
                    { 486, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6222), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Güzelbahçe" },
                    { 485, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6221), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Narlıdere" },
                    { 154, 11, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5809), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İnhisar" },
                    { 155, 12, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5810), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bingöl" },
                    { 156, 12, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5811), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Genç" },
                    { 157, 12, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5812), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karlıova" },
                    { 158, 12, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5813), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kiğı" },
                    { 159, 12, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5814), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Solhan" },
                    { 160, 12, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5815), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Adaklı" },
                    { 161, 12, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5816), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yayladere" },
                    { 162, 12, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5817), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yedisu" },
                    { 163, 13, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5818), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Adilcevaz" },
                    { 164, 13, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5819), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ahlat" },
                    { 165, 13, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5820), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bitlis" },
                    { 153, 11, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5808), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yenipazar" },
                    { 166, 13, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5821), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hizan" },
                    { 168, 13, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5824), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tatvan" },
                    { 169, 13, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5825), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Güroymak" },
                    { 170, 14, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5826), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bolu" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 171, 14, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5827), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gerede" },
                    { 172, 14, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5828), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Göynük" },
                    { 173, 14, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5829), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kıbrıscık" },
                    { 174, 14, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5830), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mengen" },
                    { 175, 14, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5831), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mudurnu" },
                    { 176, 14, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5832), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Seben" },
                    { 177, 14, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5833), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dörtdivan" },
                    { 178, 14, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5834), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yeniçağa" },
                    { 179, 15, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5835), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ağlasun" },
                    { 167, 13, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5822), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mutki" },
                    { 180, 15, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5836), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bucak" },
                    { 152, 11, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5807), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Söğüt" },
                    { 150, 11, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5804), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Osmaneli" },
                    { 124, 9, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5719), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Köşk" },
                    { 125, 9, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5720), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Didim" },
                    { 126, 9, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5721), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Efeler" },
                    { 127, 10, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5722), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ayvalık" },
                    { 128, 10, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5723), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Balya" },
                    { 129, 10, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5724), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bandırma" },
                    { 130, 10, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5725), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bigadiç" },
                    { 131, 10, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5726), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Burhaniye" },
                    { 132, 10, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5727), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dursunbey" },
                    { 133, 10, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5728), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Edremit" },
                    { 134, 10, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5729), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Erdek" },
                    { 135, 10, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5730), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gönen" },
                    { 151, 11, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5806), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pazaryeri" },
                    { 136, 10, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5731), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Havran" },
                    { 138, 10, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5733), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kepsut" },
                    { 139, 10, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5736), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Manyas" },
                    { 140, 10, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5737), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Savaştepe" },
                    { 141, 10, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5738), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sındırgı" },
                    { 142, 10, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5739), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Susurluk" },
                    { 143, 10, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5740), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marmara" },
                    { 144, 10, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5741), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gömeç" },
                    { 145, 10, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5742), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Altıeylül" },
                    { 146, 10, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5743), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karesi" },
                    { 147, 11, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5744), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bilecik" },
                    { 148, 11, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5745), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bozüyük" },
                    { 149, 11, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5803), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gölpazarı" },
                    { 137, 10, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5732), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İvrindi" },
                    { 181, 15, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5837), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Burdur" },
                    { 182, 15, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5838), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gölhisar" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 183, 15, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5839), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tefenni" },
                    { 215, 17, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5874), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gelibolu" },
                    { 216, 17, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5875), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gökçeada" },
                    { 217, 17, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5876), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lapseki" },
                    { 218, 17, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yenice" },
                    { 219, 18, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5878), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çankırı" },
                    { 220, 18, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5879), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çerkeş" },
                    { 221, 18, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5880), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eldivan" },
                    { 222, 18, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5881), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ilgaz" },
                    { 223, 18, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5882), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kurşunlu" },
                    { 224, 18, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5884), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Orta" },
                    { 225, 18, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5885), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şabanözü" },
                    { 226, 18, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5886), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yapraklı" },
                    { 214, 17, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5873), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ezine" },
                    { 227, 18, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5887), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Atkaracalar" },
                    { 229, 18, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5889), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bayramören" },
                    { 230, 18, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5890), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Korgun" },
                    { 231, 19, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5891), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alaca" },
                    { 232, 19, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5892), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bayat" },
                    { 233, 19, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5893), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 234, 19, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5894), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İskilip" },
                    { 235, 19, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5895), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kargı" },
                    { 236, 19, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5896), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mecitözü" },
                    { 237, 19, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5897), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ortaköy" },
                    { 238, 19, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5898), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Osmancık" },
                    { 239, 19, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5899), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sungurlu" },
                    { 240, 19, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5900), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Boğazkale" },
                    { 228, 18, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5888), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kızılırmak" },
                    { 213, 17, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5872), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eceabat" },
                    { 212, 17, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5870), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çanakkale" },
                    { 211, 17, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5869), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çan" },
                    { 184, 15, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5841), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yeşilova" },
                    { 185, 15, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5842), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karamanlı" },
                    { 186, 15, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5843), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kemer" },
                    { 187, 15, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5844), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Altınyayla" },
                    { 188, 15, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5845), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çavdır" },
                    { 189, 15, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5846), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çeltikçi" },
                    { 190, 16, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gemlik" },
                    { 191, 16, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5848), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İnegöl" },
                    { 192, 16, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5849), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İznik" },
                    { 193, 16, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5850), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karacabey" },
                    { 194, 16, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5851), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Keles" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 195, 16, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5852), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mudanya" },
                    { 196, 16, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5853), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mustafakemalpaşa" },
                    { 197, 16, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5854), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Orhaneli" },
                    { 198, 16, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5855), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Orhangazi" },
                    { 199, 16, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5857), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yenişehir" },
                    { 200, 16, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5858), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Büyükorhan" },
                    { 201, 16, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5859), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Harmancık" },
                    { 202, 16, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5860), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nilüfer" },
                    { 203, 16, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5861), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Osmangazi" },
                    { 204, 16, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5862), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yıldırım" },
                    { 205, 16, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5863), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gürsu" },
                    { 206, 16, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5864), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kestel" },
                    { 207, 17, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5865), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ayvacık" },
                    { 208, 17, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5866), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bayramiç" },
                    { 209, 17, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5867), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Biga" },
                    { 210, 17, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5868), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bozcaada" },
                    { 123, 9, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5718), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karpuzlu" },
                    { 122, 9, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5716), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İncirliova" },
                    { 121, 9, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5715), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Buharkent" },
                    { 120, 9, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5714), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yenipazar" },
                    { 33, 3, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5579), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sinanpaşa" },
                    { 34, 3, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5580), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sultandağı" },
                    { 35, 3, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5621), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şuhut" },
                    { 36, 3, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5622), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Başmakçı" },
                    { 37, 3, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5623), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bayat" },
                    { 38, 3, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5624), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İscehisar" },
                    { 39, 3, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5625), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çobanlar" },
                    { 40, 3, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5626), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Evciler" },
                    { 41, 3, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5627), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hocalar" },
                    { 42, 3, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5628), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kızılören" },
                    { 43, 4, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5629), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ağrı Merkez" },
                    { 44, 4, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5631), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Diyadin" },
                    { 32, 3, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5578), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sandıklı" },
                    { 45, 4, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5632), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Doğubayazıt" },
                    { 47, 4, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5634), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hamur" },
                    { 48, 4, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5635), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Patnos" },
                    { 49, 4, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5636), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Taşlıçay" },
                    { 50, 4, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5638), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tutak" },
                    { 51, 5, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5640), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Amasya Merkez" },
                    { 52, 5, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5641), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Göynücek" },
                    { 53, 5, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5642), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gümüşhacıköy" },
                    { 54, 5, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5643), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merzifon" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 55, 5, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5644), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Suluova" },
                    { 56, 5, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5645), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Taşova" },
                    { 57, 5, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5646), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hamamözü" },
                    { 58, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5647), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Altındağ" },
                    { 46, 4, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5633), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eleşkirt" },
                    { 31, 3, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5577), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İhsaniye" },
                    { 30, 3, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5576), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Emirdağ" },
                    { 29, 3, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5575), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dinar" },
                    { 2, 1, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5542), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ceyhan" },
                    { 3, 1, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5546), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Feke" },
                    { 4, 1, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5547), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karaisalı" },
                    { 5, 1, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5549), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karataş" },
                    { 6, 1, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5550), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kozan" },
                    { 7, 1, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5551), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pozantı" },
                    { 8, 1, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5552), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Saimbeyli" },
                    { 9, 1, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5553), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tufanbeyli" },
                    { 10, 1, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5554), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yumurtalık" },
                    { 11, 1, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5555), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yüreğir" },
                    { 12, 1, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5556), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aladağ" },
                    { 13, 1, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5557), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İmamoğlu" },
                    { 14, 1, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5558), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarıçam" },
                    { 15, 1, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5559), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çukurova" },
                    { 16, 2, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5560), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Adıyaman Merkez" },
                    { 17, 2, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5561), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Besni" },
                    { 18, 2, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5562), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çelikhan" },
                    { 19, 2, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5563), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gerger" },
                    { 20, 2, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5565), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gölbaşı" },
                    { 21, 2, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5566), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kahta" },
                    { 22, 2, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5567), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Samsat" },
                    { 23, 2, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5569), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sincik" },
                    { 24, 2, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5570), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tut" },
                    { 25, 3, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5571), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Afyonkarahisar" },
                    { 26, 3, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5572), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bolvadin" },
                    { 27, 3, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5573), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çay" },
                    { 28, 3, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5574), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dazkırı" },
                    { 59, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5648), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ayaş" },
                    { 241, 19, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5901), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Uğurludağ" },
                    { 60, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5649), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bala" },
                    { 62, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5651), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çamlıdere" },
                    { 94, 7, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5686), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Demre" },
                    { 95, 7, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5687), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İbradı" },
                    { 96, 7, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5688), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kemer" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 97, 7, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5689), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aksu" },
                    { 98, 7, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5690), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Döşemealtı" },
                    { 99, 7, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5691), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kepez" },
                    { 100, 7, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5692), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Konyaaltı" },
                    { 101, 7, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5694), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Muratpaşa" },
                    { 102, 8, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5695), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ardanuç" },
                    { 103, 8, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5696), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Arhavi" },
                    { 104, 8, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5697), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Artvin Merkez" },
                    { 105, 8, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5698), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Borçka" },
                    { 93, 7, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5685), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Serik" },
                    { 106, 8, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5699), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hopa" },
                    { 108, 8, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5701), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yusufeli" },
                    { 109, 8, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5703), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Murgul" },
                    { 110, 9, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5704), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bozdoğan" },
                    { 111, 9, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5705), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çine" },
                    { 112, 9, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5706), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Germencik" },
                    { 113, 9, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5707), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karacasu" },
                    { 114, 9, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5708), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Koçarlı" },
                    { 115, 9, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5709), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kuşadası" },
                    { 116, 9, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5710), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kuyucak" },
                    { 117, 9, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5711), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nazilli" },
                    { 118, 9, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5712), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Söke" },
                    { 119, 9, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5713), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sultanhisar" },
                    { 107, 8, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5700), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şavşat" },
                    { 92, 7, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5684), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Manavgat" },
                    { 91, 7, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5683), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kumluca" },
                    { 90, 7, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5682), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Korkuteli" },
                    { 63, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5652), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çankaya" },
                    { 64, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5653), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çubuk" },
                    { 65, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5654), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Elmadağ" },
                    { 66, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5656), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Güdül" },
                    { 67, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5657), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Haymana" },
                    { 68, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5658), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kalecik" },
                    { 69, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5659), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kızılcahamam" },
                    { 70, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5660), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nallıhan" },
                    { 71, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5661), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Polatlı" },
                    { 72, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5662), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şereflikoçhisar" },
                    { 73, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5663), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yenimahalle" },
                    { 74, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5664), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gölbaşı" },
                    { 75, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5665), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Keçiören" },
                    { 76, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5666), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mamak" },
                    { 77, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5667), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sincan" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 78, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5668), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kazan" },
                    { 79, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5669), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akyurt" },
                    { 80, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5671), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Etimesgut" },
                    { 81, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5672), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Evren" },
                    { 82, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5673), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pursaklar" },
                    { 83, 7, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5674), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akseki" },
                    { 84, 7, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5675), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alanya" },
                    { 85, 7, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5676), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Elmalı" },
                    { 86, 7, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5677), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Finike" },
                    { 87, 7, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5678), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gazipaşa" },
                    { 88, 7, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5679), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gündoğmuş" },
                    { 89, 7, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5680), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kaş" },
                    { 61, 6, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5650), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beypazarı" },
                    { 242, 19, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5902), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dodurga" },
                    { 243, 19, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5903), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Laçin" },
                    { 244, 19, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5904), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Oğuzlar" },
                    { 398, 32, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6126), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Keçiborlu" },
                    { 399, 32, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6127), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Senirkent" },
                    { 400, 32, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6128), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sütçüler" },
                    { 401, 32, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6129), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şarkikaraağaç" },
                    { 402, 32, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6131), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Uluborlu" },
                    { 403, 32, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6132), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yalvaç" },
                    { 404, 32, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6133), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aksu" },
                    { 405, 32, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6134), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gönen" },
                    { 406, 32, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6135), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yenişarbademli" },
                    { 407, 33, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6136), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Anamur" },
                    { 408, 33, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6138), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Erdemli" },
                    { 409, 33, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6139), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gülnar" },
                    { 397, 32, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6125), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 410, 33, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6140), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mut" },
                    { 412, 33, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6142), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tarsus" },
                    { 413, 33, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6143), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aydıncık" },
                    { 414, 33, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6144), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bozyazı" },
                    { 415, 33, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6145), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çamlıyayla" },
                    { 416, 33, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6147), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akdeniz" },
                    { 417, 33, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6148), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mezitli" },
                    { 418, 33, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6150), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Toroslar" },
                    { 419, 33, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6151), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yenişehir" },
                    { 420, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6152), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Adalar" },
                    { 421, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6153), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bakırköy" },
                    { 422, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6154), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beşiktaş" },
                    { 423, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6155), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beykoz" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 411, 33, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6141), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Silifke" },
                    { 424, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6156), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beyoğlu" },
                    { 396, 32, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6124), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gelendost" },
                    { 394, 32, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6121), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Atabey" },
                    { 368, 28, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6066), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Güce" },
                    { 369, 29, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 370, 29, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6068), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kelkit" },
                    { 371, 29, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6069), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şiran" },
                    { 372, 29, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6070), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Torul" },
                    { 373, 29, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6071), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Köse" },
                    { 374, 29, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6072), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kürtün" },
                    { 375, 30, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6073), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çukurca" },
                    { 376, 30, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6102), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 377, 30, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6103), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şemdinli" },
                    { 378, 30, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6104), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yüksekova" },
                    { 379, 31, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6106), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Altınözü" },
                    { 395, 32, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6123), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eğirdir" },
                    { 380, 31, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6107), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dörtyol" },
                    { 382, 31, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6109), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İskenderun" },
                    { 383, 31, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6110), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kırıkhan" },
                    { 384, 31, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6111), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Reyhanlı" },
                    { 385, 31, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6112), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Samandağ" },
                    { 386, 31, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6113), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yayladağı" },
                    { 387, 31, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6114), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Erzin" },
                    { 388, 31, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6115), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Belen" },
                    { 389, 31, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6116), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kumlu" },
                    { 390, 31, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6117), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Antakya" },
                    { 391, 31, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6118), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Arsuz" },
                    { 392, 31, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6119), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Defne" },
                    { 393, 31, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6120), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Payas" },
                    { 381, 31, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6108), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hassa" },
                    { 425, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6157), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çatalca" },
                    { 426, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6158), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eyüp" },
                    { 427, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6159), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Fatih" },
                    { 459, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6193), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aliağa" },
                    { 460, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6194), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bayındır" },
                    { 461, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6195), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bergama" },
                    { 462, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6196), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bornova" },
                    { 463, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6197), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çeşme" },
                    { 464, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6198), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dikili" },
                    { 465, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6199), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Foça" },
                    { 466, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6200), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karaburun" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 467, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6201), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karşıyaka" },
                    { 468, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6203), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kemalpaşa" },
                    { 469, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6204), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kınık" },
                    { 470, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6205), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kiraz" },
                    { 458, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6192), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sultangazi" },
                    { 471, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6206), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Menemen" },
                    { 473, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6208), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Seferihisar" },
                    { 474, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6209), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Selçuk" },
                    { 475, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6210), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tire" },
                    { 476, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6211), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Torbalı" },
                    { 477, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6212), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Urla" },
                    { 478, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6213), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beydağ" },
                    { 479, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6215), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Buca" },
                    { 480, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6216), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Konak" },
                    { 481, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6217), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Menderes" },
                    { 482, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6218), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Balçova" },
                    { 483, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6219), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çiğli" },
                    { 484, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6220), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gaziemir" },
                    { 472, 35, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6207), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ödemiş" },
                    { 457, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6191), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sancaktepe" },
                    { 456, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6190), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Esenyurt" },
                    { 455, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6189), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çekmeköy" },
                    { 428, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6160), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gaziosmanpaşa" },
                    { 429, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6161), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kadıköy" },
                    { 430, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6162), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kartal" },
                    { 431, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6163), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarıyer" },
                    { 432, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6164), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Silivri" },
                    { 433, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6165), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şile" },
                    { 434, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6166), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şişli" },
                    { 435, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6167), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Üsküdar" },
                    { 436, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6168), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Zeytinburnu" },
                    { 437, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6169), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Büyükçekmece" },
                    { 438, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6171), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kağıthane" },
                    { 439, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6172), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Küçükçekmece" },
                    { 440, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6173), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pendik" },
                    { 441, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6174), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ümraniye" },
                    { 442, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6175), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bayrampaşa" },
                    { 443, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6176), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Avcılar" },
                    { 444, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6177), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bağcılar" },
                    { 445, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6178), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bahçelievler" },
                    { 446, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6179), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Güngören" },
                    { 447, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6180), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Maltepe" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 448, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6182), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sultanbeyli" },
                    { 449, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6183), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tuzla" },
                    { 450, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6184), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Esenler" },
                    { 451, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6185), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Arnavutköy" },
                    { 452, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6186), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ataşehir" },
                    { 453, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6187), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Başakşehir" },
                    { 454, 34, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6188), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beylikdüzü" },
                    { 367, 28, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6065), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Doğankent" },
                    { 366, 28, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6064), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çanakçı" },
                    { 365, 28, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6063), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çamoluk" },
                    { 304, 24, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5996), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kemah" },
                    { 277, 21, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5967), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bağlar" },
                    { 278, 21, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5968), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kayapınar" },
                    { 279, 21, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5969), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sur" },
                    { 280, 21, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5970), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yenişehir" },
                    { 281, 22, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5971), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 282, 22, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5973), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Enez" },
                    { 283, 22, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5974), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Havsa" },
                    { 284, 22, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5975), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İpsala" },
                    { 285, 22, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5976), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Keşan" },
                    { 286, 22, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5977), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lalapaşa" },
                    { 287, 22, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5978), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Meriç" },
                    { 288, 22, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5979), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Uzunköprü" },
                    { 276, 21, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5966), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kocaköy" },
                    { 289, 22, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5981), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Süloğlu" },
                    { 291, 23, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5983), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Baskil" },
                    { 292, 23, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5984), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 293, 23, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5985), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karakoçan" },
                    { 294, 23, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5986), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Keban" },
                    { 295, 23, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5987), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Maden" },
                    { 296, 23, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5988), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Palu" },
                    { 297, 23, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5989), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sivrice" },
                    { 298, 23, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5990), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Arıcak" },
                    { 299, 23, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5991), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kovancılar" },
                    { 300, 23, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5992), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alacakaya" },
                    { 301, 24, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5993), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çayırlı" },
                    { 302, 24, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5994), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 290, 23, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5982), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ağın" },
                    { 303, 24, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5995), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İliç" },
                    { 275, 21, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5965), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eğil" },
                    { 273, 21, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5963), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lice" },
                    { 247, 20, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5908), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çal" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 248, 20, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5909), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çameli" },
                    { 249, 20, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5910), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çardak" },
                    { 250, 20, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5911), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çivril" },
                    { 251, 20, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5912), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Güney" },
                    { 252, 20, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5913), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kale" },
                    { 253, 20, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5914), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarayköy" },
                    { 254, 20, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5915), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tavas" },
                    { 255, 20, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5916), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Babadağ" },
                    { 256, 20, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5917), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bekilli" },
                    { 257, 20, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5918), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Honaz" },
                    { 258, 20, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5919), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Serinhisar" },
                    { 274, 21, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5964), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Silvan" },
                    { 259, 20, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5921), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pamukkale" },
                    { 261, 20, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5923), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beyağaç" },
                    { 262, 20, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5952), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bozkurt" },
                    { 263, 20, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5953), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkezefendi" },
                    { 264, 21, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5954), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bismil" },
                    { 265, 21, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5955), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çermik" },
                    { 266, 21, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5956), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çınar" },
                    { 267, 21, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5957), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çüngüş" },
                    { 268, 21, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5958), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dicle" },
                    { 269, 21, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5959), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ergani" },
                    { 270, 21, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5960), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hani" },
                    { 271, 21, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5961), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hazro" },
                    { 272, 21, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5962), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kulp" },
                    { 260, 20, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5922), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Baklan" },
                    { 364, 28, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6062), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yağlıdere" },
                    { 305, 24, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5997), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kemaliye" },
                    { 306, 24, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5999), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Refahiye" },
                    { 338, 26, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6033), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İnönü" },
                    { 339, 26, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6034), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Günyüzü" },
                    { 340, 26, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6035), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Han" },
                    { 341, 26, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6037), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mihalgazi" },
                    { 342, 26, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6038), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Odunpazarı" },
                    { 343, 26, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6039), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tepebaşı" },
                    { 344, 27, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6040), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Araban" },
                    { 345, 27, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6041), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İslahiye" },
                    { 346, 27, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6042), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nizip" },
                    { 347, 27, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6043), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Oğuzeli" },
                    { 348, 27, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6044), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yavuzeli" },
                    { 349, 27, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6046), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şahinbey" },
                    { 337, 26, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6032), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beylikova" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 350, 27, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6047), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şehitkamil" },
                    { 352, 27, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6049), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nurdağı" },
                    { 353, 28, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6050), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alucra" },
                    { 354, 28, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6051), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bulancak" },
                    { 355, 28, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6052), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dereli" },
                    { 356, 28, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6053), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Espiye" },
                    { 357, 28, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6054), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eynesil" },
                    { 358, 28, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6055), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 359, 28, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6056), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Görele" },
                    { 360, 28, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6058), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Keşap" },
                    { 361, 28, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6059), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şebinkarahisar" },
                    { 362, 28, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6060), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tirebolu" },
                    { 363, 28, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6061), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Piraziz" },
                    { 351, 27, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6048), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karkamış" },
                    { 336, 26, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6031), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alpu" },
                    { 335, 26, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6030), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sivrihisar" },
                    { 334, 26, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6029), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Seyitgazi" },
                    { 307, 24, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6000), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tercan" },
                    { 308, 24, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6001), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Üzümlü" },
                    { 309, 24, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6002), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Otlukbeli" },
                    { 310, 25, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6003), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aşkale" },
                    { 311, 25, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6004), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çat" },
                    { 312, 25, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6005), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hınıs" },
                    { 313, 25, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6006), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Horasan" },
                    { 314, 25, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6007), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İspir" },
                    { 315, 25, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6008), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karayazı" },
                    { 316, 25, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6009), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Narman" },
                    { 317, 25, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6011), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Oltu" },
                    { 318, 25, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6012), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Olur" },
                    { 319, 25, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6013), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pasinler" },
                    { 320, 25, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şenkaya" },
                    { 321, 25, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6016), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tekman" },
                    { 322, 25, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6017), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tortum" },
                    { 323, 25, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6018), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karaçoban" },
                    { 324, 25, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6019), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Uzundere" },
                    { 325, 25, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6020), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pazaryolu" },
                    { 326, 25, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6021), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aziziye" },
                    { 327, 25, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6022), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Köprüköy" },
                    { 328, 25, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6023), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Palandöken" },
                    { 329, 25, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6024), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yakutiye" },
                    { 330, 26, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6025), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çifteler" },
                    { 331, 26, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6026), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mahmudiye" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 332, 26, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6027), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mihalıççık" },
                    { 333, 26, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(6028), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarıcakaya" },
                    { 246, 20, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5906), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Buldan" },
                    { 245, 20, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(5905), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Acıpayam" }
                });

            migrationBuilder.InsertData(
                table: "UserDetails",
                columns: new[] { "ID", "Country", "CreatedDate", "Email", "Gender", "ModifiedDate", "NameSurname", "Phone", "Status", "Towner", "UserID" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(2020), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "00000000000", 1, null, 1 },
                    { 2, null, new DateTime(2022, 7, 4, 9, 49, 13, 446, DateTimeKind.Local).AddTicks(3026), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esra Yorulmaz salman", "05432563636", 1, null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_CargoTrackingNumber",
                table: "Cargos",
                column: "CargoTrackingNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_TranserID",
                table: "Cargos",
                column: "TranserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryID",
                table: "Categories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ProductID",
                table: "Comment",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductID",
                table: "ProductCategories",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPictures_PictureUrl",
                table: "ProductPictures",
                column: "PictureUrl",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductPictures_ProductID",
                table: "ProductPictures",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TownID",
                table: "Products",
                column: "TownID");

            migrationBuilder.CreateIndex(
                name: "IX_Towns_CityID",
                table: "Towns",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_ProductID",
                table: "Transfer",
                column: "ProductID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_UserID",
                table: "Transfer",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserID",
                table: "UserDetails",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductPictures");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "Transfer");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
