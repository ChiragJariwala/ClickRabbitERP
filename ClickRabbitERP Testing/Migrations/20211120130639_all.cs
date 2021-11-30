using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClickRabbitERP_Testing.Migrations
{
    public partial class all : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderModelPOID",
                table: "VendorMaster",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemCategoryMaster",
                columns: table => new
                {
                    CatgID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatgName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategoryMaster", x => x.CatgID);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderMaster",
                columns: table => new
                {
                    POID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VendorOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorInvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderMaster", x => x.POID);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderMaster",
                columns: table => new
                {
                    SOID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderMaster", x => x.SOID);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseLineMaster",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceNumber = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductQty = table.Column<int>(type: "int", nullable: false),
                    ProducrPrice = table.Column<float>(type: "real", nullable: false),
                    DocLineNumber = table.Column<int>(type: "int", nullable: false),
                    SGST = table.Column<int>(type: "int", nullable: false),
                    CGST = table.Column<int>(type: "int", nullable: false),
                    QuantityToPost = table.Column<int>(type: "int", nullable: false),
                    PostedQty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseLineMaster", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_PurchaseLineMaster_PurchaseOrderMaster_SourceNumber",
                        column: x => x.SourceNumber,
                        principalTable: "PurchaseOrderMaster",
                        principalColumn: "POID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMaster",
                columns: table => new
                {
                    CompID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Compphone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creationdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activationdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesOrderModelSOID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMaster", x => x.CompID);
                    table.ForeignKey(
                        name: "FK_CustomerMaster_SalesOrderMaster_SalesOrderModelSOID",
                        column: x => x.SalesOrderModelSOID,
                        principalTable: "SalesOrderMaster",
                        principalColumn: "SOID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemMaster",
                columns: table => new
                {
                    ProductCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuFacturerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatagoryCode = table.Column<int>(type: "int", nullable: false),
                    TradePrice = table.Column<float>(type: "real", nullable: false),
                    ManufactureDiscount = table.Column<float>(type: "real", nullable: false),
                    ProductLicenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SGST = table.Column<float>(type: "real", nullable: false),
                    CGST = table.Column<float>(type: "real", nullable: false),
                    HSNCode = table.Column<int>(type: "int", nullable: false),
                    PurchaseOrderModelPOID = table.Column<int>(type: "int", nullable: true),
                    SalesOrderModelSOID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMaster", x => x.ProductCode);
                    table.ForeignKey(
                        name: "FK_ItemMaster_ItemCategoryMaster_CatagoryCode",
                        column: x => x.CatagoryCode,
                        principalTable: "ItemCategoryMaster",
                        principalColumn: "CatgID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemMaster_PurchaseOrderMaster_PurchaseOrderModelPOID",
                        column: x => x.PurchaseOrderModelPOID,
                        principalTable: "PurchaseOrderMaster",
                        principalColumn: "POID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemMaster_SalesOrderMaster_SalesOrderModelSOID",
                        column: x => x.SalesOrderModelSOID,
                        principalTable: "SalesOrderMaster",
                        principalColumn: "SOID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesLineMaster",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceNumber = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductQty = table.Column<int>(type: "int", nullable: false),
                    ProducrPrice = table.Column<float>(type: "real", nullable: false),
                    DocLineNumber = table.Column<int>(type: "int", nullable: false),
                    SGST = table.Column<int>(type: "int", nullable: false),
                    CGST = table.Column<int>(type: "int", nullable: false),
                    QuantityToPost = table.Column<int>(type: "int", nullable: false),
                    PostedQty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesLineMaster", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_SalesLineMaster_SalesOrderMaster_SourceNumber",
                        column: x => x.SourceNumber,
                        principalTable: "SalesOrderMaster",
                        principalColumn: "SOID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VendorMaster_PurchaseOrderModelPOID",
                table: "VendorMaster",
                column: "PurchaseOrderModelPOID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMaster_SalesOrderModelSOID",
                table: "CustomerMaster",
                column: "SalesOrderModelSOID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMaster_CatagoryCode",
                table: "ItemMaster",
                column: "CatagoryCode");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMaster_PurchaseOrderModelPOID",
                table: "ItemMaster",
                column: "PurchaseOrderModelPOID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMaster_SalesOrderModelSOID",
                table: "ItemMaster",
                column: "SalesOrderModelSOID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseLineMaster_SourceNumber",
                table: "PurchaseLineMaster",
                column: "SourceNumber");

            migrationBuilder.CreateIndex(
                name: "IX_SalesLineMaster_SourceNumber",
                table: "SalesLineMaster",
                column: "SourceNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_VendorMaster_PurchaseOrderMaster_PurchaseOrderModelPOID",
                table: "VendorMaster",
                column: "PurchaseOrderModelPOID",
                principalTable: "PurchaseOrderMaster",
                principalColumn: "POID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendorMaster_PurchaseOrderMaster_PurchaseOrderModelPOID",
                table: "VendorMaster");

            migrationBuilder.DropTable(
                name: "CustomerMaster");

            migrationBuilder.DropTable(
                name: "ItemMaster");

            migrationBuilder.DropTable(
                name: "PurchaseLineMaster");

            migrationBuilder.DropTable(
                name: "SalesLineMaster");

            migrationBuilder.DropTable(
                name: "ItemCategoryMaster");

            migrationBuilder.DropTable(
                name: "PurchaseOrderMaster");

            migrationBuilder.DropTable(
                name: "SalesOrderMaster");

            migrationBuilder.DropIndex(
                name: "IX_VendorMaster_PurchaseOrderModelPOID",
                table: "VendorMaster");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderModelPOID",
                table: "VendorMaster");
        }
    }
}
