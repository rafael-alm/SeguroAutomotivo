using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoInsurance.Domian.AutoInsurance.Infrastructure.Persistence.Migrations.WorkflowCore
{
    /// <inheritdoc />
    public partial class WorkflowCoreUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NaturalPersonProposal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CustomerCPF = table.Column<string>(type: "text", nullable: false),
                    CustomerBirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    VehicleLicensePlate = table.Column<string>(type: "text", nullable: false),
                    VehicleManufactureYear = table.Column<int>(type: "integer", nullable: false),
                    VehicleFipeValue = table.Column<decimal>(type: "numeric", nullable: false),
                    ProposalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalPersonProposal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NaturalPersonPolicy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IssueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    StartCoverageDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndCoverageDate = table.Column<DateOnly>(type: "date", nullable: false),
                    NaturalPersonProposalId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalPersonPolicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NaturalPersonPolicy_NaturalPersonProposal_NaturalPersonProp~",
                        column: x => x.NaturalPersonProposalId,
                        principalTable: "NaturalPersonProposal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPersonPolicy_NaturalPersonProposalId",
                table: "NaturalPersonPolicy",
                column: "NaturalPersonProposalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NaturalPersonPolicy");

            migrationBuilder.DropTable(
                name: "NaturalPersonProposal");
        }
    }
}
