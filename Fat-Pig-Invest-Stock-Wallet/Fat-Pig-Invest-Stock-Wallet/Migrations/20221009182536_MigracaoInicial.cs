using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fat_Pig_Invest_Stock_Wallet.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Corretoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corretoras", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cnpj = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TiposProvento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProvento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CorretoraId = table.Column<int>(type: "int", nullable: false),
                    NumeroNota = table.Column<int>(type: "int", nullable: false),
                    DataPregao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TaxaLiquidacao = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Emolumentos = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Corretagem = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notas_Corretoras_CorretoraId",
                        column: x => x.CorretoraId,
                        principalTable: "Corretoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Acoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ticker = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acoes_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ordens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NotaId = table.Column<int>(type: "int", nullable: false),
                    TipoOrdem = table.Column<string>(type: "varchar(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AcaoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordens_Acoes_AcaoId",
                        column: x => x.AcaoId,
                        principalTable: "Acoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordens_Notas_NotaId",
                        column: x => x.NotaId,
                        principalTable: "Notas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoProventoId = table.Column<int>(type: "int", nullable: false),
                    AcaoId = table.Column<int>(type: "int", nullable: false),
                    DataProvento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ValorProvento = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proventos_Acoes_AcaoId",
                        column: x => x.AcaoId,
                        principalTable: "Acoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proventos_TiposProvento_TipoProventoId",
                        column: x => x.TipoProventoId,
                        principalTable: "TiposProvento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Corretoras",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "FATPIG INVEST DVTM LTDA" },
                    { 2, "NU INVEST CORRETORA DE VALORES S.A" },
                    { 3, "XP INVESTIMENTOS CCTVM S/A" },
                    { 4, "MODAL DTVM LTDA" }
                });

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "Id", "Cnpj", "Nome" },
                values: new object[,]
                {
                    { 1, "61.532.644/0001-15", "ITAUSA" },
                    { 2, "33.000.167/0001-01", "PETROBRAS" },
                    { 3, "76.535.764/0001-43", "OI SA" },
                    { 4, "90.400.888/0001-42", "SANTANDER BR" },
                    { 5, "07.859.971/0001-30", "TAESA" }
                });

            migrationBuilder.InsertData(
                table: "TiposProvento",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Dividendos" },
                    { 2, "Juros sobre Capital Próprio (JCP)" },
                    { 3, "Rendimentos FIIs" },
                    { 4, "Outros" }
                });

            migrationBuilder.InsertData(
                table: "Acoes",
                columns: new[] { "Id", "EmpresaId", "Ticker" },
                values: new object[,]
                {
                    { 1, 1, "ITSA3" },
                    { 2, 1, "ITSA4" },
                    { 3, 2, "PETR3" },
                    { 4, 2, "PETR4" },
                    { 5, 3, "OIBR3" },
                    { 6, 4, "SANB11" },
                    { 7, 5, "TAEE11" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acoes_EmpresaId",
                table: "Acoes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_CorretoraId",
                table: "Notas",
                column: "CorretoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordens_AcaoId",
                table: "Ordens",
                column: "AcaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordens_NotaId",
                table: "Ordens",
                column: "NotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proventos_AcaoId",
                table: "Proventos",
                column: "AcaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proventos_TipoProventoId",
                table: "Proventos",
                column: "TipoProventoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordens");

            migrationBuilder.DropTable(
                name: "Proventos");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Acoes");

            migrationBuilder.DropTable(
                name: "TiposProvento");

            migrationBuilder.DropTable(
                name: "Corretoras");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
