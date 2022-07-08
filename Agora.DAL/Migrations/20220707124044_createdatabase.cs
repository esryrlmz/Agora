using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agora.DAL.Migrations
{
    public partial class createdatabase : Migration
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
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    ProductStatus = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
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
                table: "Categories",
                columns: new[] { "ID", "CategoryID", "CategoryName", "CreatedDate", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 1, null, "Elektronik", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(259), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, null, "Bebek-Çocuk", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(861), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, null, "Kitap", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(867), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, null, "Ev Textil", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(868), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, null, "Ayakkabı - Çanta", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(871), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, null, "Ev Mobilyası", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(872), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CityName", "CreatedDate", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 60, "Tokat", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2198), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 59, "Tekirdağ", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2198), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 58, "Sivas", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2197), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 57, "Sinop", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2196), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 56, "Siirt", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2195), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 55, "Samsun", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2194), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 54, "Sakarya", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2193), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 53, "Rize", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2192), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 50, "Nevşehir", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2189), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 51, "Niğde", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2190), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 61, "Trabzon", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2199), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 49, "Muş", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2188), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 48, "Muğla", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2187), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 47, "Mardin", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2186), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 46, "Kahramanmaraş", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2185), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 45, "Manisa", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2184), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 44, "Malatya", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2183), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 52, "Ordu", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2191), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 62, "Tunceli", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2201), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 65, "Van", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2204), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 64, "Uşak", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2203), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 81, "Düzce", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2220), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 80, "Osmaniye", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2219), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 79, "Kilis", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2218), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 78, "Karabük", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2217), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 77, "Yalova", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2216), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 76, "Iğdır", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2214), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 75, "Ardahan", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2213), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 74, "Bartın", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2212), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 73, "Şırnak", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2211), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 72, "Batman", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2210), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 71, "Kırıkkale", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2209), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 70, "Karaman", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2208), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 69, "Bayburt", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2207), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 68, "Aksaray", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2207), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 67, "Zonguldak", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2206), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CityName", "CreatedDate", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 66, "Yozgat", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2205), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 43, "Kütahya", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2182), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 63, "Şanlıurfa", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2202), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 42, "Konya", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2181), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 40, "Kırşehir", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2178), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, "Çorum", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2157), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, "Çankırı", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2156), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, "Çanakkale", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2155), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, "Bursa", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2154), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, "Burdur", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2153), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, "Bolu", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2152), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, "Bitlis", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2151), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, "Bingöl", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2150), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, "Bilecik", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2149), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, "Balıkesir", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2148), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, "Aydın", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2147), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, "Artvin", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2145), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, "Antalya", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2144), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, "Ankara", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2143), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, "Amasya", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2142), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, "Ağrı", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2141), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "Afyonkarahisar", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2140), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Adıyaman", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2135), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 41, "Kocaeli", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2179), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, "Adana", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(1888), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, "Denizli", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2158), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, "Edirne", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2160), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 39, "Kırklareli", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2177), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 38, "Kayseri", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2176), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 37, "Kastamonu", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2175), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 36, "Kars", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2174), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 35, "İzmir", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2173), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 34, "İstanbul", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2172), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 33, "Mersin", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2171), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 32, "Isparta", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2170), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 31, "Hatay", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2169), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 30, "Hakkari", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2168), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 29, "Gümüşhane", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2167), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 28, "Giresun", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2166), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 27, "Gaziantep", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2165), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 26, "Eskişehir", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2164), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 25, "Erzurum", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2163), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CityName", "CreatedDate", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 24, "Erzincan", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2162), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 23, "Elazığ", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2161), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, "Diyarbakır", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2159), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "CreatedDate", "ModifiedDate", "Password", "Role", "Status", "UserName" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 7, 7, 15, 40, 43, 567, DateTimeKind.Local).AddTicks(8966), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$FLf1htu5op3/oRzRs/plmeeQe5hPhvFWCFv2krFLpJD5/e3c6Ipqu", 1, 1, "esra" },
                    { 3, new DateTime(2022, 7, 7, 15, 40, 43, 567, DateTimeKind.Local).AddTicks(8979), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$FLf1htu5op3/oRzRs/plmeeQe5hPhvFWCFv2krFLpJD5/e3c6Ipqu", 2, 1, "Btlkc" },
                    { 1, new DateTime(2022, 7, 7, 15, 40, 43, 566, DateTimeKind.Local).AddTicks(6639), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$FLf1htu5op3/oRzRs/plmeeQe5hPhvFWCFv2krFLpJD5/e3c6Ipqu", 1, 1, "admin" },
                    { 4, new DateTime(2022, 7, 7, 15, 40, 43, 567, DateTimeKind.Local).AddTicks(8982), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$FLf1htu5op3/oRzRs/plmeeQe5hPhvFWCFv2krFLpJD5/e3c6Ipqu", 2, 1, "mstfyrlmz" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CategoryID", "CategoryName", "CreatedDate", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 2, 1, "Bilgisayar", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(507), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 1, "Telefon", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(855), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 1, "Küçük Ev Aletleri", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(860), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, 5, "Bebek Mobilyaları", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(863), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, 5, "Bebek Kıyafetleri", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(864), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, 5, "Bebek Oyuncakları", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(865), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, 10, "Halı", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(869), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, 10, "Perde, Nevresim", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(870), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, 14, "Masa", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(873), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, 14, "Sandalye", new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(874), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 650, 47, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4033), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ömerli" },
                    { 649, 47, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4032), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nusaybin" },
                    { 648, 47, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4031), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Midyat" },
                    { 647, 47, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4030), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mazıdağı" },
                    { 646, 47, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4029), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kızıltepe" },
                    { 641, 46, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4023), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ekinözü" },
                    { 644, 46, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4027), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Onikişubat" },
                    { 643, 46, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4025), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dulkadiroğlu" },
                    { 642, 46, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4024), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nurhak" },
                    { 651, 47, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4034), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Savur" },
                    { 640, 46, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4022), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çağlayancerit" },
                    { 645, 47, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4028), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Derik" },
                    { 652, 47, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4035), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dargeçit" },
                    { 657, 48, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4041), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Fethiye" },
                    { 654, 47, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4037), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Artuklu" },
                    { 655, 48, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4039), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bodrum" },
                    { 656, 48, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4040), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Datça" },
                    { 639, 46, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4021), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Türkoğlu" },
                    { 658, 48, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4042), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Köyceğiz" },
                    { 659, 48, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4043), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marmaris" },
                    { 660, 48, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4044), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Milas" },
                    { 661, 48, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4045), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ula" },
                    { 662, 48, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4046), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yatağan" },
                    { 663, 48, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4047), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dalaman" },
                    { 664, 48, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4048), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ortaca" },
                    { 665, 48, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4049), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kavaklıdere" },
                    { 653, 47, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4036), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yeşilli" },
                    { 638, 46, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4020), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pazarcık" },
                    { 633, 45, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4015), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yunusemre" },
                    { 636, 46, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4018), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Elbistan" },
                    { 610, 44, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3989), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pütürge" },
                    { 611, 44, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3991), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yeşilyurt" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 612, 44, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3992), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Battalgazi" },
                    { 613, 44, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3993), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Doğanyol" },
                    { 614, 44, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3994), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kale" },
                    { 615, 44, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3995), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kuluncak" },
                    { 616, 44, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3996), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yazıhan" },
                    { 617, 45, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3997), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akhisar" },
                    { 618, 45, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3998), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alaşehir" },
                    { 619, 45, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3999), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Demirci" },
                    { 620, 45, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4000), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gördes" },
                    { 621, 45, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4001), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kırkağaç" },
                    { 637, 46, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4019), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Göksun" },
                    { 622, 45, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4002), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kula" },
                    { 624, 45, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4004), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarıgöl" },
                    { 625, 45, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4006), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Saruhanlı" },
                    { 626, 45, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4007), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Selendi" },
                    { 627, 45, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4008), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Soma" },
                    { 628, 45, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4009), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Turgutlu" },
                    { 629, 45, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4011), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ahmetli" },
                    { 630, 45, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4012), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gölmarmara" },
                    { 631, 45, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4013), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Köprübaşı" },
                    { 632, 45, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şehzadeler" },
                    { 666, 48, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4050), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Menteşe" },
                    { 634, 46, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4016), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Afşin" },
                    { 635, 46, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4017), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Andırın" },
                    { 623, 45, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4003), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Salihli" },
                    { 667, 48, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4051), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Seydikemer" },
                    { 672, 49, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4057), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hasköy" },
                    { 669, 49, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4054), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Malazgirt" },
                    { 701, 52, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4088), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çatalpınar" },
                    { 702, 52, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4089), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çaybaşı" },
                    { 703, 52, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4090), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İkizce" },
                    { 704, 52, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4091), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kabadüz" },
                    { 705, 52, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4092), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kabataş" },
                    { 706, 52, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4093), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Altınordu" },
                    { 707, 53, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4094), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ardeşen" },
                    { 708, 53, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4095), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çamlıhemşin" },
                    { 709, 53, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4096), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çayeli" },
                    { 710, 53, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4097), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Fındıklı" },
                    { 711, 53, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4098), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İkizdere" },
                    { 712, 53, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4099), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kalkandere" },
                    { 700, 52, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4087), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çamaş" },
                    { 713, 53, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4100), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pazar" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 715, 53, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4103), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Güneysu" },
                    { 716, 53, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4104), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Derepazarı" },
                    { 717, 53, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4105), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hemşin" },
                    { 718, 53, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4106), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İyidere" },
                    { 719, 54, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4107), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akyazı" },
                    { 720, 54, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4108), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Geyve" },
                    { 721, 54, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4109), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hendek" },
                    { 722, 54, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4110), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karasu" },
                    { 723, 54, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4111), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kaynarca" },
                    { 724, 54, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4113), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sapanca" },
                    { 725, 54, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4114), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kocaali" },
                    { 726, 54, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4115), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pamukova" },
                    { 714, 53, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4101), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Rize Merkez" },
                    { 699, 52, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4086), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gürgentepe" },
                    { 698, 52, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4085), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gülyalı" },
                    { 697, 52, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4084), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ünye" },
                    { 670, 49, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4055), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Muş Merkez" },
                    { 671, 49, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4056), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Varto" },
                    { 609, 44, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3962), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hekimhan" },
                    { 673, 49, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4058), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Korkut" },
                    { 674, 50, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4059), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Avanos" },
                    { 675, 50, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4060), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Derinkuyu" },
                    { 676, 50, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4061), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gülşehir" },
                    { 677, 50, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4062), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hacıbektaş" },
                    { 678, 50, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4063), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kozaklı" },
                    { 679, 50, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4064), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 680, 50, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4065), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ürgüp" },
                    { 681, 50, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4066), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Acıgöl" },
                    { 682, 51, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bor" },
                    { 683, 51, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4068), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çamardı" },
                    { 684, 51, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4069), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 685, 51, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4071), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ulukışla" },
                    { 686, 51, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4072), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Altunhisar" },
                    { 687, 51, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4073), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çiftlik" },
                    { 688, 52, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4074), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akkuş" },
                    { 689, 52, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4075), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aybastı" },
                    { 690, 52, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4076), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Fatsa" },
                    { 691, 52, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4077), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gölköy" },
                    { 692, 52, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4079), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Korgan" },
                    { 693, 52, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4080), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kumru" },
                    { 694, 52, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4081), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mesudiye" },
                    { 695, 52, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4082), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Perşembe" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 696, 52, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4083), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ulubey" },
                    { 668, 49, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4053), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bulanık" },
                    { 608, 44, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3961), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Doğanşehir" },
                    { 603, 43, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3956), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pazarlar" },
                    { 606, 44, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3959), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Arguvan" },
                    { 519, 38, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3865), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Felahiye" },
                    { 520, 38, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3866), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İncesu" },
                    { 521, 38, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3867), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pınarbaşı" },
                    { 522, 38, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3868), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarıoğlan" },
                    { 523, 38, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3869), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarız" },
                    { 524, 38, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3870), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tomarza" },
                    { 525, 38, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3871), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yahyalı" },
                    { 526, 38, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3872), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yeşilhisar" },
                    { 527, 38, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3873), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akkışla" },
                    { 528, 38, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3874), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Talas" },
                    { 529, 38, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3875), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kocasinan" },
                    { 530, 38, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3876), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Melikgazi" },
                    { 518, 38, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3864), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Develi" },
                    { 531, 38, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hacılar" },
                    { 533, 39, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3879), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Babaeski" },
                    { 534, 39, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3881), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Demirköy" },
                    { 535, 39, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3883), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 536, 39, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3884), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kofçaz" },
                    { 537, 39, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3885), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lüleburgaz" },
                    { 538, 39, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3886), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pehlivanköy" },
                    { 539, 39, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3887), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pınarhisar" },
                    { 540, 39, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3888), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Vize" },
                    { 541, 40, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3889), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çiçekdağı" },
                    { 542, 40, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3890), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kaman" },
                    { 543, 40, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3891), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 544, 40, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3892), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mucur" },
                    { 532, 38, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3878), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Özvatan" },
                    { 517, 38, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3863), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bünyan" },
                    { 516, 37, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3862), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Seydiler" },
                    { 515, 37, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3860), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hanönü" },
                    { 488, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3832), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karabağlar" },
                    { 489, 36, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3833), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Arpaçay" },
                    { 490, 36, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3834), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Digor" },
                    { 491, 36, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3835), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kağızman" },
                    { 492, 36, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3836), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 493, 36, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3837), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarıkamış" },
                    { 494, 36, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3838), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Selim" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 495, 36, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3839), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Susuz" },
                    { 496, 36, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3840), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akyaka" },
                    { 497, 37, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3841), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Abana" },
                    { 498, 37, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3842), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Araç" },
                    { 499, 37, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3843), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Azdavay" },
                    { 500, 37, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3844), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bozkurt" },
                    { 501, 37, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3845), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cide" },
                    { 502, 37, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3846), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çatalzeytin" },
                    { 503, 37, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Daday" },
                    { 504, 37, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3848), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Devrekani" },
                    { 505, 37, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3850), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İnebolu" },
                    { 506, 37, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3851), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 507, 37, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3852), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Küre" },
                    { 508, 37, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3853), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Taşköprü" },
                    { 509, 37, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3854), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tosya" },
                    { 510, 37, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3855), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İhsangazi" },
                    { 511, 37, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3856), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pınarbaşı" },
                    { 512, 37, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3857), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şenpazar" },
                    { 513, 37, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3858), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ağlı" },
                    { 514, 37, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3859), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Doğanyurt" },
                    { 545, 40, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3893), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akpınar" },
                    { 607, 44, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3960), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Darende" },
                    { 546, 40, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3894), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akçakent" },
                    { 548, 41, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3897), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gebze" },
                    { 580, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3931), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Meram" },
                    { 581, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3932), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Selçuklu" },
                    { 582, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3933), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Taşkent" },
                    { 583, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3934), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ahırlı" },
                    { 584, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3935), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çeltik" },
                    { 585, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3936), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Derbent" },
                    { 586, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3937), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Emirgazi" },
                    { 587, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3938), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Güneysınır" },
                    { 588, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3939), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Halkapınar" },
                    { 589, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3940), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tuzlukçu" },
                    { 590, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3941), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yalıhüyük" },
                    { 591, 43, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3942), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Altıntaş" },
                    { 579, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3930), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karatay" },
                    { 592, 43, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3943), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Domaniç" },
                    { 594, 43, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3945), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gediz" },
                    { 595, 43, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3948), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 596, 43, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3949), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Simav" },
                    { 597, 43, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3950), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tavşanlı" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 598, 43, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3951), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aslanapa" },
                    { 599, 43, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3952), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dumlupınar" },
                    { 600, 43, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3953), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hisarcık" },
                    { 601, 43, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3954), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şaphane" },
                    { 602, 43, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3955), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çavdarhisar" },
                    { 727, 54, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4116), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Taraklı" },
                    { 604, 44, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3957), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akçadağ" },
                    { 605, 44, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3958), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Arapgir" },
                    { 593, 43, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3944), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Emet" },
                    { 578, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3929), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hüyük" },
                    { 577, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3928), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Derebucak" },
                    { 576, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3927), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Altınekin" },
                    { 549, 41, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3898), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gölcük" },
                    { 550, 41, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3899), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kandıra" },
                    { 551, 41, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3900), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karamürsel" },
                    { 552, 41, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3901), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Körfez" },
                    { 553, 41, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3902), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Derince" },
                    { 554, 41, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3903), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Başiskele" },
                    { 555, 41, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3904), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çayırova" },
                    { 556, 41, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3905), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Darıca" },
                    { 557, 41, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3906), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dilovası" },
                    { 558, 41, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3907), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İzmit" },
                    { 559, 41, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3908), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kartepe" },
                    { 560, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3909), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akşehir" },
                    { 561, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3910), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beyşehir" },
                    { 562, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3911), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bozkır" },
                    { 563, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3912), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cihanbeyli" },
                    { 564, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3913), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çumra" },
                    { 565, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3915), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Doğanhisar" },
                    { 566, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3916), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Konya" },
                    { 567, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3917), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hadim" },
                    { 568, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3918), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ilgın" },
                    { 569, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3919), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kadınhanı" },
                    { 570, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3920), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karapınar" },
                    { 571, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3921), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kulu" },
                    { 572, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3923), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarayönü" },
                    { 573, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Seydişehir" },
                    { 574, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3925), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yunak" },
                    { 575, 42, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3926), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akören" },
                    { 547, 40, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3895), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Boztepe" },
                    { 728, 54, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4117), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ferizli" },
                    { 733, 54, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4122), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Erenler" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 730, 54, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4119), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Söğütlü" },
                    { 884, 67, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4340), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alaplı" },
                    { 885, 67, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4341), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gökçebey" },
                    { 886, 67, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4342), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kilimli" },
                    { 887, 67, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4343), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kozlu" },
                    { 888, 68, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4344), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 889, 68, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4345), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ortaköy" },
                    { 890, 68, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4347), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ağaçören" },
                    { 891, 68, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4348), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Güzelyurt" },
                    { 892, 68, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4349), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarıyahşi" },
                    { 893, 68, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4350), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eskil" },
                    { 894, 68, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4351), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gülağaç" },
                    { 895, 69, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4352), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 883, 67, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4339), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 896, 69, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4354), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aydıntepe" },
                    { 898, 70, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4356), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ermenek" },
                    { 899, 70, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4357), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 900, 70, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4358), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ayrancı" },
                    { 901, 70, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4359), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kazımkarabekir" },
                    { 902, 70, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4360), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Başyayla" },
                    { 903, 70, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4361), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarıveliler" },
                    { 904, 71, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4363), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Delice" },
                    { 905, 71, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4364), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Keskin" },
                    { 906, 71, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4365), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 907, 71, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4366), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sulakyurt" },
                    { 908, 71, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4367), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bahşili" },
                    { 909, 71, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4368), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Balışeyh" },
                    { 897, 69, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4355), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Demirözü" },
                    { 882, 67, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4338), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ereğli" },
                    { 881, 67, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4337), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Devrek" },
                    { 880, 67, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4336), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çaycuma" },
                    { 853, 65, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4279), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Başkale" },
                    { 854, 65, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4280), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çatak" },
                    { 855, 65, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4282), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Erciş" },
                    { 856, 65, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4283), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gevaş" },
                    { 857, 65, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4284), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gürpınar" },
                    { 858, 65, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4285), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Muradiye" },
                    { 859, 65, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4286), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Özalp" },
                    { 860, 65, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4287), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bahçesaray" },
                    { 861, 65, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4288), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çaldıran" },
                    { 862, 65, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4289), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Edremit" },
                    { 863, 65, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4290), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Saray" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 864, 65, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4291), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İpekyolu" },
                    { 865, 65, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4319), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tuşba" },
                    { 866, 66, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4321), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akdağmadeni" },
                    { 867, 66, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4322), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Boğazlıyan" },
                    { 868, 66, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4323), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çayıralan" },
                    { 869, 66, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4324), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çekerek" },
                    { 870, 66, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4325), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarıkaya" },
                    { 871, 66, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4327), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sorgun" },
                    { 872, 66, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4328), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şefaatli" },
                    { 873, 66, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4329), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yerköy" },
                    { 874, 66, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4330), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yozgat Merkez" },
                    { 875, 66, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4331), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aydıncık" },
                    { 876, 66, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4332), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çandır" },
                    { 877, 66, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4333), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kadışehri" },
                    { 878, 66, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4334), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Saraykent" },
                    { 879, 66, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4335), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yenifakılı" },
                    { 910, 71, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4369), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çelebi" },
                    { 852, 64, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4278), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Uşak Merkez" },
                    { 911, 71, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4370), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karakeçili" },
                    { 913, 72, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4372), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 945, 77, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4406), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Termal" },
                    { 946, 78, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4407), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eflani" },
                    { 947, 78, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4408), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eskipazar" },
                    { 948, 78, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4409), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 949, 78, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4410), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ovacık" },
                    { 950, 78, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4411), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Safranbolu" },
                    { 951, 78, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4412), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yenice" },
                    { 952, 79, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4413), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 953, 79, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4414), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Elbeyli" },
                    { 954, 79, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4415), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Musabeyli" },
                    { 955, 79, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4416), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Polateli" },
                    { 956, 80, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4418), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bahçe" },
                    { 944, 77, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4405), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çiftlikköy" },
                    { 957, 80, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4419), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kadirli" },
                    { 959, 80, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4421), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Düziçi" },
                    { 960, 80, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4422), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hasanbeyli" },
                    { 961, 80, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4423), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sumbas" },
                    { 962, 80, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4424), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Toprakkale" },
                    { 963, 81, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4425), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akçakoca" },
                    { 964, 81, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4426), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 965, 81, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4427), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yığılca" },
                    { 966, 81, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4428), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cumayeri" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 967, 81, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4429), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gölyaka" },
                    { 968, 81, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4430), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çilimli" },
                    { 969, 81, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4431), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gümüşova" },
                    { 970, 81, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4432), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kaynaşlı" },
                    { 958, 80, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4420), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 943, 77, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4404), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çınarcık" },
                    { 942, 77, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4403), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Armutlu" },
                    { 941, 77, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4402), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Altınova" },
                    { 914, 72, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4373), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beşiri" },
                    { 915, 72, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4374), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gercüş" },
                    { 916, 72, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4375), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kozluk" },
                    { 917, 72, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4376), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sason" },
                    { 918, 72, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4377), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hasankeyf" },
                    { 919, 73, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4378), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beytüşşebap" },
                    { 920, 73, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4379), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cizre" },
                    { 921, 73, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4380), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İdil" },
                    { 922, 73, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4381), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Silopi" },
                    { 923, 73, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4382), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 924, 73, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4383), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Uludere" },
                    { 925, 73, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4384), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Güçlükonak" },
                    { 926, 74, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4386), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 927, 74, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4387), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kurucaşile" },
                    { 928, 74, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4388), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ulus" },
                    { 929, 74, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4389), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Amasra" },
                    { 930, 75, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4390), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 931, 75, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4391), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çıldır" },
                    { 932, 75, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4392), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Göle" },
                    { 933, 75, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4393), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hanak" },
                    { 934, 75, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4394), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Posof" },
                    { 935, 75, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4395), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Damal" },
                    { 936, 76, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4396), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aralık" },
                    { 937, 76, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4397), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 938, 76, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4398), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tuzluca" },
                    { 939, 76, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4399), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karakoyunlu" },
                    { 940, 77, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4400), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 912, 71, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4371), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yahşihan" },
                    { 729, 54, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4118), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karapürçek" },
                    { 851, 64, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4277), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ulubey" },
                    { 849, 64, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4275), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karahallı" },
                    { 762, 57, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4182), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Erfelek" },
                    { 763, 57, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4183), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gerze" },
                    { 764, 57, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4184), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 765, 57, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4185), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Türkeli" },
                    { 766, 57, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4186), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dikmen" },
                    { 767, 57, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4187), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Saraydüzü" },
                    { 768, 58, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4188), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Divriği" },
                    { 769, 58, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4190), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gemerek" },
                    { 770, 58, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4191), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gürün" },
                    { 771, 58, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4192), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hafik" },
                    { 772, 58, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4193), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İmranlı" },
                    { 773, 58, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4194), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kangal" },
                    { 761, 57, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4181), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Durağan" },
                    { 774, 58, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4195), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Koyulhisar" },
                    { 776, 58, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4198), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Suşehri" },
                    { 777, 58, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4199), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şarkışla" },
                    { 778, 58, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4200), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yıldızeli" },
                    { 779, 58, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4201), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Zara" },
                    { 780, 58, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4202), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akıncılar" },
                    { 781, 58, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4203), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Altınyayla" },
                    { 782, 58, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4204), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Doğanşar" },
                    { 783, 58, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4205), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gölova" },
                    { 784, 58, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4206), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ulaş" },
                    { 785, 59, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4207), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çerkezköy" },
                    { 786, 59, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4208), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çorlu" },
                    { 787, 59, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4209), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hayrabolu" },
                    { 775, 58, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4196), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 760, 57, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4180), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Boyabat" },
                    { 759, 57, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4179), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ayancık" },
                    { 758, 56, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4178), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tillo" },
                    { 731, 54, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4120), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Adapazarı" },
                    { 732, 54, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4121), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Arifiye" },
                    { 487, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3831), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bayraklı" },
                    { 734, 54, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4123), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Serdivan" },
                    { 735, 55, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4124), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alaçam" },
                    { 736, 55, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4125), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bafra" },
                    { 737, 55, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4155), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çarşamba" },
                    { 738, 55, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4156), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Havza" },
                    { 739, 55, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4157), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kavak" },
                    { 740, 55, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4159), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ladik" },
                    { 741, 55, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4160), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Terme" },
                    { 742, 55, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4161), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Vezirköprü" },
                    { 743, 55, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4162), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Asarcık" },
                    { 744, 55, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4163), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "43604" },
                    { 745, 55, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4164), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Salıpazarı" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 746, 55, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4166), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tekkeköy" },
                    { 747, 55, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4167), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ayvacık" },
                    { 748, 55, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4168), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yakakent" },
                    { 749, 55, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4169), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Atakum" },
                    { 750, 55, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4170), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Canik" },
                    { 751, 55, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4171), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İlkadım" },
                    { 752, 56, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4172), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Baykan" },
                    { 753, 56, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4173), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eruh" },
                    { 754, 56, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4174), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kurtalan" },
                    { 755, 56, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4175), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pervari" },
                    { 756, 56, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4176), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 757, 56, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4177), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şirvan" },
                    { 788, 59, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4210), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Malkara" },
                    { 850, 64, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4276), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sivaslı" },
                    { 789, 59, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4211), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Muratlı" },
                    { 791, 59, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4213), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şarköy" },
                    { 823, 61, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4247), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hayrat" },
                    { 824, 61, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4248), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Köprübaşı" },
                    { 825, 61, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4249), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ortahisar" },
                    { 826, 62, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4250), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çemişgezek" },
                    { 827, 62, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4251), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hozat" },
                    { 828, 62, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4252), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mazgirt" },
                    { 829, 62, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4254), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nazımiye" },
                    { 830, 62, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4255), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ovacık" },
                    { 831, 62, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4256), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pertek" },
                    { 832, 62, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4257), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pülümür" },
                    { 833, 62, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4258), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 834, 63, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4259), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akçakale" },
                    { 822, 61, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4246), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Düzköy" },
                    { 835, 63, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4260), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Birecik" },
                    { 837, 63, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4263), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ceylanpınar" },
                    { 838, 63, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4264), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Halfeti" },
                    { 839, 63, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4265), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hilvan" },
                    { 840, 63, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4266), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Siverek" },
                    { 841, 63, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4267), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Suruç" },
                    { 842, 63, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4268), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Viranşehir" },
                    { 843, 63, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4269), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Harran" },
                    { 844, 63, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4270), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eyyübiye" },
                    { 845, 63, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4271), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Haliliye" },
                    { 846, 63, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4272), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karaköprü" },
                    { 847, 64, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4273), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Banaz" },
                    { 848, 64, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4274), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eşme" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 836, 63, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4262), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bozova" },
                    { 821, 61, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4245), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dernekpazarı" },
                    { 820, 61, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4244), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çarşıbaşı" },
                    { 819, 61, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4243), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şalpazarı" },
                    { 792, 59, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4214), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marmaraereğlisi" },
                    { 793, 59, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4215), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ergene" },
                    { 794, 59, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4216), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kapaklı" },
                    { 795, 59, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4217), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Süleymanpaşa" },
                    { 796, 60, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4218), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Almus" },
                    { 797, 60, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4219), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Artova" },
                    { 798, 60, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4220), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Erbaa" },
                    { 799, 60, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4222), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Niksar" },
                    { 800, 60, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4223), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Reşadiye" },
                    { 801, 60, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4224), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tokat Merkez" },
                    { 802, 60, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4225), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Turhal" },
                    { 803, 60, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4226), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Zile" },
                    { 804, 60, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4227), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pazar" },
                    { 805, 60, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4228), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yeşilyurt" },
                    { 806, 60, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4230), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Başçiftlik" },
                    { 807, 60, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4231), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sulusaray" },
                    { 808, 61, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4232), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akçaabat" },
                    { 809, 61, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4233), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Araklı" },
                    { 810, 61, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4234), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Arsin" },
                    { 811, 61, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4235), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çaykara" },
                    { 812, 61, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4236), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Maçka" },
                    { 813, 61, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4237), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Of" },
                    { 814, 61, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4238), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sürmene" },
                    { 815, 61, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4239), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tonya" },
                    { 816, 61, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4240), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Vakfıkebir" },
                    { 817, 61, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4241), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yomra" },
                    { 818, 61, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4242), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beşikdüzü" },
                    { 790, 59, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(4212), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Saray" },
                    { 486, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3830), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Güzelbahçe" },
                    { 482, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3825), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Balçova" },
                    { 484, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3827), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gaziemir" },
                    { 153, 11, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3389), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yenipazar" },
                    { 154, 11, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3390), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İnhisar" },
                    { 155, 12, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3391), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bingöl" },
                    { 156, 12, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3393), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Genç" },
                    { 157, 12, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3394), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karlıova" },
                    { 158, 12, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3395), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kiğı" },
                    { 159, 12, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3396), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Solhan" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 160, 12, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3397), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Adaklı" },
                    { 161, 12, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3398), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yayladere" },
                    { 162, 12, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3399), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yedisu" },
                    { 163, 13, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3400), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Adilcevaz" },
                    { 164, 13, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3401), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ahlat" },
                    { 152, 11, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3388), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Söğüt" },
                    { 165, 13, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3402), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bitlis" },
                    { 167, 13, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3404), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mutki" },
                    { 168, 13, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3405), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tatvan" },
                    { 169, 13, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3406), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Güroymak" },
                    { 170, 14, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3407), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bolu" },
                    { 171, 14, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3408), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gerede" },
                    { 172, 14, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3409), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Göynük" },
                    { 173, 14, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3410), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kıbrıscık" },
                    { 174, 14, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3411), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mengen" },
                    { 175, 14, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3412), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mudurnu" },
                    { 176, 14, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3414), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Seben" },
                    { 177, 14, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3415), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dörtdivan" },
                    { 178, 14, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3416), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yeniçağa" },
                    { 166, 13, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3403), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hizan" },
                    { 179, 15, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3417), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ağlasun" },
                    { 151, 11, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3387), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pazaryeri" },
                    { 149, 11, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3385), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gölpazarı" },
                    { 123, 9, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3357), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karpuzlu" },
                    { 124, 9, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3359), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Köşk" },
                    { 125, 9, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3360), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Didim" },
                    { 126, 9, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3361), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Efeler" },
                    { 127, 10, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3362), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ayvalık" },
                    { 128, 10, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3363), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Balya" },
                    { 129, 10, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3364), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bandırma" },
                    { 130, 10, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3365), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bigadiç" },
                    { 131, 10, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3366), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Burhaniye" },
                    { 132, 10, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3367), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dursunbey" },
                    { 133, 10, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3368), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Edremit" },
                    { 134, 10, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3369), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Erdek" },
                    { 150, 11, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3386), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Osmaneli" },
                    { 135, 10, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3370), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gönen" },
                    { 137, 10, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3372), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İvrindi" },
                    { 138, 10, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3373), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kepsut" },
                    { 139, 10, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3374), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Manyas" },
                    { 140, 10, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3375), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Savaştepe" },
                    { 141, 10, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3376), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sındırgı" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 142, 10, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3377), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Susurluk" },
                    { 143, 10, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3378), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marmara" },
                    { 144, 10, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3379), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gömeç" },
                    { 145, 10, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3380), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Altıeylül" },
                    { 146, 10, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3382), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karesi" },
                    { 147, 11, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3383), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bilecik" },
                    { 148, 11, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3384), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bozüyük" },
                    { 136, 10, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3371), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Havran" },
                    { 180, 15, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3418), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bucak" },
                    { 181, 15, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3419), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Burdur" },
                    { 182, 15, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3420), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gölhisar" },
                    { 214, 17, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3454), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ezine" },
                    { 215, 17, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3455), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gelibolu" },
                    { 216, 17, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3456), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gökçeada" },
                    { 217, 17, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3457), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lapseki" },
                    { 218, 17, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3458), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yenice" },
                    { 219, 18, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3459), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çankırı" },
                    { 220, 18, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3460), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çerkeş" },
                    { 221, 18, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3461), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eldivan" },
                    { 222, 18, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3462), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ilgaz" },
                    { 223, 18, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3463), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kurşunlu" },
                    { 224, 18, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3465), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Orta" },
                    { 225, 18, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3466), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şabanözü" },
                    { 213, 17, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3453), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eceabat" },
                    { 226, 18, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3467), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yapraklı" },
                    { 228, 18, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3496), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kızılırmak" },
                    { 229, 18, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3497), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bayramören" },
                    { 230, 18, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3498), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Korgun" },
                    { 231, 19, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3499), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alaca" },
                    { 232, 19, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3500), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bayat" },
                    { 233, 19, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3501), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 234, 19, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3502), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İskilip" },
                    { 235, 19, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3504), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kargı" },
                    { 236, 19, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3505), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mecitözü" },
                    { 237, 19, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3506), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ortaköy" },
                    { 238, 19, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3507), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Osmancık" },
                    { 239, 19, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3508), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sungurlu" },
                    { 227, 18, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3494), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Atkaracalar" },
                    { 212, 17, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3452), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çanakkale" },
                    { 211, 17, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3451), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çan" },
                    { 210, 17, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3450), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bozcaada" },
                    { 183, 15, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3421), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tefenni" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 184, 15, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3422), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yeşilova" },
                    { 185, 15, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3423), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karamanlı" },
                    { 186, 15, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3424), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kemer" },
                    { 187, 15, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3425), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Altınyayla" },
                    { 188, 15, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3426), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çavdır" },
                    { 189, 15, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3427), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çeltikçi" },
                    { 190, 16, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3428), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gemlik" },
                    { 191, 16, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3429), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İnegöl" },
                    { 192, 16, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3431), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İznik" },
                    { 193, 16, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3432), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karacabey" },
                    { 194, 16, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3433), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Keles" },
                    { 195, 16, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3434), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mudanya" },
                    { 196, 16, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3435), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mustafakemalpaşa" },
                    { 197, 16, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3436), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Orhaneli" },
                    { 198, 16, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3437), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Orhangazi" },
                    { 199, 16, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3438), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yenişehir" },
                    { 200, 16, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3439), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Büyükorhan" },
                    { 201, 16, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3440), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Harmancık" },
                    { 202, 16, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3441), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nilüfer" },
                    { 203, 16, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3442), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Osmangazi" },
                    { 204, 16, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3443), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yıldırım" },
                    { 205, 16, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3444), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gürsu" },
                    { 206, 16, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3446), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kestel" },
                    { 207, 17, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ayvacık" },
                    { 208, 17, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3448), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bayramiç" },
                    { 209, 17, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3449), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Biga" },
                    { 122, 9, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3356), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İncirliova" },
                    { 121, 9, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3355), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Buharkent" },
                    { 120, 9, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3354), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yenipazar" },
                    { 119, 9, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3353), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sultanhisar" },
                    { 32, 3, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3195), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sandıklı" },
                    { 33, 3, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3196), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sinanpaşa" },
                    { 34, 3, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3197), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sultandağı" },
                    { 35, 3, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3198), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şuhut" },
                    { 36, 3, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3199), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Başmakçı" },
                    { 37, 3, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3200), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bayat" },
                    { 38, 3, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3201), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İscehisar" },
                    { 39, 3, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3202), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çobanlar" },
                    { 40, 3, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3203), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Evciler" },
                    { 41, 3, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3204), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hocalar" },
                    { 42, 3, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3205), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kızılören" },
                    { 43, 4, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3206), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ağrı Merkez" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 31, 3, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3194), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İhsaniye" },
                    { 44, 4, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3207), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Diyadin" },
                    { 46, 4, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3209), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eleşkirt" },
                    { 47, 4, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3211), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hamur" },
                    { 48, 4, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3212), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Patnos" },
                    { 49, 4, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3213), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Taşlıçay" },
                    { 50, 4, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3214), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tutak" },
                    { 51, 5, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3215), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Amasya Merkez" },
                    { 52, 5, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3216), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Göynücek" },
                    { 53, 5, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3217), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gümüşhacıköy" },
                    { 54, 5, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3218), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merzifon" },
                    { 55, 5, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3219), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Suluova" },
                    { 56, 5, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3221), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Taşova" },
                    { 57, 5, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3222), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hamamözü" },
                    { 45, 4, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3208), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Doğubayazıt" },
                    { 30, 3, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3193), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Emirdağ" },
                    { 29, 3, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3191), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dinar" },
                    { 28, 3, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3190), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dazkırı" },
                    { 1, 1, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(2711), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Seyhan" },
                    { 2, 1, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3156), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ceyhan" },
                    { 3, 1, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3161), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Feke" },
                    { 4, 1, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3162), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karaisalı" },
                    { 5, 1, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3163), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karataş" },
                    { 6, 1, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3165), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kozan" },
                    { 7, 1, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3166), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pozantı" },
                    { 8, 1, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3167), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Saimbeyli" },
                    { 9, 1, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3168), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tufanbeyli" },
                    { 10, 1, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3169), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yumurtalık" },
                    { 11, 1, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3170), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yüreğir" },
                    { 12, 1, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3171), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aladağ" },
                    { 13, 1, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3172), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İmamoğlu" },
                    { 14, 1, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3173), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarıçam" },
                    { 15, 1, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3174), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çukurova" },
                    { 16, 2, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3175), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Adıyaman Merkez" },
                    { 17, 2, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3176), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Besni" },
                    { 18, 2, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3177), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çelikhan" },
                    { 19, 2, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3178), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gerger" },
                    { 20, 2, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3180), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gölbaşı" },
                    { 21, 2, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3181), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kahta" },
                    { 22, 2, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3183), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Samsat" },
                    { 23, 2, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3184), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sincik" },
                    { 24, 2, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3185), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tut" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 25, 3, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3186), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Afyonkarahisar" },
                    { 26, 3, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3188), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bolvadin" },
                    { 27, 3, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3189), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çay" },
                    { 58, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3225), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Altındağ" },
                    { 240, 19, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3509), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Boğazkale" },
                    { 59, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3226), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ayaş" },
                    { 61, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3228), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beypazarı" },
                    { 93, 7, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3262), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Serik" },
                    { 94, 7, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3263), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Demre" },
                    { 95, 7, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3264), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İbradı" },
                    { 96, 7, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3266), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kemer" },
                    { 97, 7, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3267), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aksu" },
                    { 98, 7, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3268), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Döşemealtı" },
                    { 99, 7, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3331), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kepez" },
                    { 100, 7, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3332), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Konyaaltı" },
                    { 101, 7, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3334), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Muratpaşa" },
                    { 102, 8, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3335), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ardanuç" },
                    { 103, 8, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3336), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Arhavi" },
                    { 104, 8, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3337), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Artvin Merkez" },
                    { 92, 7, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3261), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Manavgat" },
                    { 105, 8, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3338), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Borçka" },
                    { 107, 8, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3340), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şavşat" },
                    { 108, 8, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3341), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yusufeli" },
                    { 109, 8, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3342), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Murgul" },
                    { 110, 9, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3343), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bozdoğan" },
                    { 111, 9, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3344), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çine" },
                    { 112, 9, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3345), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Germencik" },
                    { 113, 9, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3346), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karacasu" },
                    { 114, 9, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3347), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Koçarlı" },
                    { 115, 9, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3348), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kuşadası" },
                    { 116, 9, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3350), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kuyucak" },
                    { 117, 9, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3351), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nazilli" },
                    { 118, 9, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3352), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Söke" },
                    { 106, 8, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3339), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hopa" },
                    { 91, 7, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3260), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kumluca" },
                    { 90, 7, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3259), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Korkuteli" },
                    { 89, 7, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3258), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kaş" },
                    { 62, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3229), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çamlıdere" },
                    { 63, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3230), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çankaya" },
                    { 64, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3231), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çubuk" },
                    { 65, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3232), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Elmadağ" },
                    { 66, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3233), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Güdül" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 67, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3234), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Haymana" },
                    { 68, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3235), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kalecik" },
                    { 69, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3236), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kızılcahamam" },
                    { 70, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3237), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nallıhan" },
                    { 71, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3239), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Polatlı" },
                    { 72, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3240), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şereflikoçhisar" },
                    { 73, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3241), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yenimahalle" },
                    { 74, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3242), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gölbaşı" },
                    { 75, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3243), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Keçiören" },
                    { 76, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3244), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mamak" },
                    { 77, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3245), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sincan" },
                    { 78, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3246), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kazan" },
                    { 79, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3247), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akyurt" },
                    { 80, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3248), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Etimesgut" },
                    { 81, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3249), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Evren" },
                    { 82, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3250), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pursaklar" },
                    { 83, 7, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3251), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akseki" },
                    { 84, 7, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3252), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alanya" },
                    { 85, 7, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3253), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Elmalı" },
                    { 86, 7, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3255), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Finike" },
                    { 87, 7, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3256), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gazipaşa" },
                    { 88, 7, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3257), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gündoğmuş" },
                    { 60, 6, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3227), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bala" },
                    { 485, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3829), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Narlıdere" },
                    { 241, 19, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3510), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Uğurludağ" },
                    { 243, 19, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3512), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Laçin" },
                    { 396, 32, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3706), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gelendost" },
                    { 397, 32, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3707), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 398, 32, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3708), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Keçiborlu" },
                    { 399, 32, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3709), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Senirkent" },
                    { 400, 32, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3710), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sütçüler" },
                    { 401, 32, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3711), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şarkikaraağaç" },
                    { 402, 32, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3712), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Uluborlu" },
                    { 403, 32, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3713), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yalvaç" },
                    { 404, 32, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3714), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aksu" },
                    { 405, 32, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3715), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gönen" },
                    { 406, 32, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3716), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yenişarbademli" },
                    { 407, 33, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3717), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Anamur" },
                    { 395, 32, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3705), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eğirdir" },
                    { 408, 33, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3719), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Erdemli" },
                    { 410, 33, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3721), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mut" },
                    { 411, 33, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3722), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Silifke" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 412, 33, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3723), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tarsus" },
                    { 413, 33, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3724), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aydıncık" },
                    { 414, 33, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3725), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bozyazı" },
                    { 415, 33, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3727), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çamlıyayla" },
                    { 416, 33, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3728), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Akdeniz" },
                    { 417, 33, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3729), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mezitli" },
                    { 418, 33, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3730), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Toroslar" },
                    { 419, 33, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3731), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yenişehir" },
                    { 420, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3732), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Adalar" },
                    { 421, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3733), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bakırköy" },
                    { 409, 33, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3720), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gülnar" },
                    { 422, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3734), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beşiktaş" },
                    { 394, 32, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3704), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Atabey" },
                    { 392, 31, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3702), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Defne" },
                    { 366, 28, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3673), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çanakçı" },
                    { 367, 28, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3674), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Doğankent" },
                    { 368, 28, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3675), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Güce" },
                    { 369, 29, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3676), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 370, 29, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3677), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kelkit" },
                    { 371, 29, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3678), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şiran" },
                    { 372, 29, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3679), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Torul" },
                    { 373, 29, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3680), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Köse" },
                    { 374, 29, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3681), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kürtün" },
                    { 375, 30, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3682), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çukurca" },
                    { 376, 30, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3683), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 377, 30, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3684), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şemdinli" },
                    { 393, 31, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3703), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Payas" },
                    { 378, 30, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3686), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yüksekova" },
                    { 380, 31, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3688), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dörtyol" },
                    { 381, 31, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3689), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hassa" },
                    { 382, 31, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3690), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İskenderun" },
                    { 383, 31, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3691), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kırıkhan" },
                    { 384, 31, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3693), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Reyhanlı" },
                    { 385, 31, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3694), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Samandağ" },
                    { 386, 31, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3695), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yayladağı" },
                    { 387, 31, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3696), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Erzin" },
                    { 388, 31, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3697), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Belen" },
                    { 389, 31, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3698), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kumlu" },
                    { 390, 31, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3700), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Antakya" },
                    { 391, 31, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3701), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Arsuz" },
                    { 379, 31, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3687), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Altınözü" },
                    { 423, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3735), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beykoz" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 424, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3736), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beyoğlu" },
                    { 425, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3737), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çatalca" },
                    { 457, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3772), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sancaktepe" },
                    { 458, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3773), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sultangazi" },
                    { 459, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3774), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aliağa" },
                    { 460, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3775), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bayındır" },
                    { 461, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3776), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bergama" },
                    { 462, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3777), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bornova" },
                    { 463, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3778), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çeşme" },
                    { 464, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3779), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dikili" },
                    { 465, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3780), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Foça" },
                    { 466, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3781), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karaburun" },
                    { 467, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3782), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karşıyaka" },
                    { 468, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3783), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kemalpaşa" },
                    { 456, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3771), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Esenyurt" },
                    { 469, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3784), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kınık" },
                    { 471, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3786), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Menemen" },
                    { 472, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3787), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ödemiş" },
                    { 473, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3788), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Seferihisar" },
                    { 474, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3789), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Selçuk" },
                    { 475, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3792), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tire" },
                    { 476, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3793), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Torbalı" },
                    { 477, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3794), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Urla" },
                    { 478, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3795), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beydağ" },
                    { 479, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3796), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Buca" },
                    { 480, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3797), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Konak" },
                    { 481, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3798), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Menderes" },
                    { 483, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3826), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çiğli" },
                    { 470, 35, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3785), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kiraz" },
                    { 455, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3770), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çekmeköy" },
                    { 454, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3769), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beylikdüzü" },
                    { 453, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3768), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Başakşehir" },
                    { 426, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3738), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eyüp" },
                    { 427, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3739), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Fatih" },
                    { 428, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3740), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gaziosmanpaşa" },
                    { 429, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3741), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kadıköy" },
                    { 430, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3742), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kartal" },
                    { 431, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3743), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarıyer" },
                    { 432, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3745), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Silivri" },
                    { 433, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3746), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şile" },
                    { 434, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3747), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şişli" },
                    { 435, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3748), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Üsküdar" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 436, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3749), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Zeytinburnu" },
                    { 437, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3750), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Büyükçekmece" },
                    { 438, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3751), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kağıthane" },
                    { 439, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3752), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Küçükçekmece" },
                    { 440, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3753), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pendik" },
                    { 441, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3754), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ümraniye" },
                    { 442, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3755), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bayrampaşa" },
                    { 443, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3756), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Avcılar" },
                    { 444, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3757), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bağcılar" },
                    { 445, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3759), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bahçelievler" },
                    { 446, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3760), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Güngören" },
                    { 447, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3761), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Maltepe" },
                    { 448, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3762), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sultanbeyli" },
                    { 449, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3764), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tuzla" },
                    { 450, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3765), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Esenler" },
                    { 451, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3766), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Arnavutköy" },
                    { 452, 34, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3767), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ataşehir" },
                    { 242, 19, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3511), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dodurga" },
                    { 364, 28, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3671), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yağlıdere" },
                    { 365, 28, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3672), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çamoluk" },
                    { 362, 28, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3669), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tirebolu" },
                    { 275, 21, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3548), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eğil" },
                    { 276, 21, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3549), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kocaköy" },
                    { 277, 21, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3550), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bağlar" },
                    { 278, 21, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3552), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kayapınar" },
                    { 279, 21, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3553), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sur" },
                    { 280, 21, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3554), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yenişehir" },
                    { 281, 22, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3555), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 282, 22, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3556), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Enez" },
                    { 283, 22, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3557), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Havsa" },
                    { 284, 22, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3558), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İpsala" },
                    { 285, 22, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3559), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Keşan" },
                    { 286, 22, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3561), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lalapaşa" },
                    { 274, 21, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3547), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Silvan" },
                    { 287, 22, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3562), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Meriç" },
                    { 289, 22, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3564), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Süloğlu" },
                    { 290, 23, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3565), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ağın" },
                    { 291, 23, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3566), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Baskil" },
                    { 292, 23, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3567), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 293, 23, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3568), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karakoçan" },
                    { 294, 23, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3569), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Keban" },
                    { 295, 23, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3571), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Maden" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 296, 23, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3572), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Palu" },
                    { 297, 23, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3573), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sivrice" },
                    { 298, 23, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3575), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Arıcak" },
                    { 299, 23, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3576), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kovancılar" },
                    { 300, 23, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3577), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alacakaya" },
                    { 288, 22, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3563), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Uzunköprü" },
                    { 273, 21, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3546), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lice" },
                    { 272, 21, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3545), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kulp" },
                    { 271, 21, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3544), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hazro" },
                    { 244, 19, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3513), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Oğuzlar" },
                    { 245, 20, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3514), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Acıpayam" },
                    { 246, 20, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3515), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Buldan" },
                    { 247, 20, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3516), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çal" },
                    { 248, 20, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3517), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çameli" },
                    { 249, 20, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3518), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çardak" },
                    { 250, 20, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3519), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çivril" },
                    { 251, 20, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3521), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Güney" },
                    { 252, 20, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3522), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kale" },
                    { 253, 20, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3523), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarayköy" },
                    { 254, 20, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3524), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tavas" },
                    { 255, 20, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3525), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Babadağ" },
                    { 256, 20, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bekilli" },
                    { 257, 20, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3527), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Honaz" },
                    { 258, 20, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3529), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Serinhisar" },
                    { 259, 20, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3530), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pamukkale" },
                    { 260, 20, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3531), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Baklan" },
                    { 261, 20, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3532), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beyağaç" },
                    { 262, 20, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3533), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bozkurt" },
                    { 263, 20, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3534), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkezefendi" },
                    { 264, 21, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3535), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bismil" },
                    { 265, 21, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3537), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çermik" },
                    { 266, 21, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3538), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çınar" },
                    { 267, 21, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3539), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çüngüş" },
                    { 268, 21, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3540), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dicle" },
                    { 269, 21, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3541), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ergani" },
                    { 270, 21, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3543), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hani" },
                    { 363, 28, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3670), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Piraziz" },
                    { 302, 24, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3579), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 301, 24, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3578), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çayırlı" },
                    { 304, 24, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3581), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kemah" },
                    { 336, 26, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3616), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alpu" },
                    { 337, 26, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3617), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beylikova" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 338, 26, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3618), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İnönü" },
                    { 339, 26, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3619), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Günyüzü" },
                    { 340, 26, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3620), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Han" },
                    { 341, 26, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3621), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mihalgazi" },
                    { 342, 26, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3622), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Odunpazarı" },
                    { 343, 26, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3623), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tepebaşı" },
                    { 344, 27, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3624), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Araban" },
                    { 345, 27, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3625), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İslahiye" },
                    { 346, 27, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3626), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nizip" },
                    { 347, 27, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3627), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Oğuzeli" },
                    { 303, 24, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3580), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İliç" },
                    { 348, 27, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3628), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yavuzeli" },
                    { 350, 27, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3630), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şehitkamil" },
                    { 351, 27, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3631), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karkamış" },
                    { 352, 27, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3632), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nurdağı" },
                    { 353, 28, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3633), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alucra" },
                    { 354, 28, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3660), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bulancak" },
                    { 355, 28, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3662), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dereli" },
                    { 356, 28, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3663), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Espiye" },
                    { 357, 28, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3664), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eynesil" },
                    { 358, 28, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3665), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Merkez" },
                    { 359, 28, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3666), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Görele" },
                    { 360, 28, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3667), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Keşap" },
                    { 361, 28, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3668), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şebinkarahisar" },
                    { 349, 27, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3629), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şahinbey" },
                    { 334, 26, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3613), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Seyitgazi" },
                    { 335, 26, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3615), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sivrihisar" },
                    { 332, 26, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3611), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mihalıççık" },
                    { 305, 24, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3582), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Kemaliye" },
                    { 306, 24, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3583), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Refahiye" },
                    { 307, 24, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3584), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tercan" },
                    { 308, 24, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3585), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Üzümlü" },
                    { 309, 24, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3586), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Otlukbeli" },
                    { 310, 25, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3587), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aşkale" },
                    { 311, 25, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3588), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çat" },
                    { 312, 25, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3589), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hınıs" },
                    { 313, 25, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3591), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Horasan" },
                    { 314, 25, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3592), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İspir" },
                    { 315, 25, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3593), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karayazı" },
                    { 333, 26, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3612), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sarıcakaya" },
                    { 317, 25, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3595), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Oltu" },
                    { 316, 25, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3594), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Narman" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "CityID", "CreatedDate", "ModifiedDate", "Status", "TownName" },
                values: new object[,]
                {
                    { 319, 25, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3597), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pasinler" },
                    { 331, 26, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3610), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mahmudiye" },
                    { 330, 26, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3609), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Çifteler" },
                    { 329, 25, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3608), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yakutiye" },
                    { 328, 25, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3607), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Palandöken" },
                    { 318, 25, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3596), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Olur" },
                    { 326, 25, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3605), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Aziziye" },
                    { 327, 25, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3606), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Köprüköy" },
                    { 324, 25, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3602), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Uzundere" },
                    { 323, 25, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3601), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Karaçoban" },
                    { 322, 25, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3600), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tortum" },
                    { 321, 25, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3599), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tekman" },
                    { 320, 25, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3598), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Şenkaya" },
                    { 325, 25, new DateTime(2022, 7, 7, 15, 40, 43, 569, DateTimeKind.Local).AddTicks(3604), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pazaryolu" }
                });

            migrationBuilder.InsertData(
                table: "UserDetails",
                columns: new[] { "ID", "Country", "CreatedDate", "Email", "Gender", "ModifiedDate", "NameSurname", "Phone", "Status", "Towner", "UserID" },
                values: new object[,]
                {
                    { 3, "İstanbul", new DateTime(2022, 7, 7, 15, 40, 43, 568, DateTimeKind.Local).AddTicks(9262), "betul@gmail.com", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Betül Koca", "02545896363", 1, "Fatih", 3 },
                    { 1, "Çorum", new DateTime(2022, 7, 7, 15, 40, 43, 568, DateTimeKind.Local).AddTicks(7693), "admin@gmail.com", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "00000000000", 1, "Bayat", 1 },
                    { 2, "Adana", new DateTime(2022, 7, 7, 15, 40, 43, 568, DateTimeKind.Local).AddTicks(9255), "esra@gmail.com", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esra Yorulmaz salman", "05432563636", 1, "Ceyhan", 2 },
                    { 4, "İstanbul", new DateTime(2022, 7, 7, 15, 40, 43, 568, DateTimeKind.Local).AddTicks(9264), "betul@gmail.com", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mustafa Yorulmaz", "05477898989", 1, "Fatih", 4 }
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
                name: "IX_Products_UserID",
                table: "Products",
                column: "UserID");

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
                name: "Towns");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "Transfer");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
