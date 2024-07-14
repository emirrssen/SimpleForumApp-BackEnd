using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleForumApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EndPointGuestActivities");

            migrationBuilder.DropTable(
                name: "EndPointUserActivities");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.CreateTable(
                name: "ExecutionOrders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutionOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimBusinessRules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    ExecutionOrderId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimBusinessRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimBusinessRules_ExecutionOrders_ExecutionOrderId",
                        column: x => x.ExecutionOrderId,
                        principalTable: "ExecutionOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimBusinessRules_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PagePermissions",
                columns: table => new
                {
                    PageId = table.Column<long>(type: "bigint", nullable: false),
                    PermissionId = table.Column<long>(type: "bigint", nullable: false),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagePermissions", x => new { x.PageId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_PagePermissions_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PagePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PagePermissions_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EndPointClaimBusinessRules",
                columns: table => new
                {
                    EndPointId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimBusinessRuleId = table.Column<long>(type: "bigint", nullable: false),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndPointClaimBusinessRules", x => new { x.EndPointId, x.ClaimBusinessRuleId });
                    table.ForeignKey(
                        name: "FK_EndPointClaimBusinessRules_ClaimBusinessRules_ClaimBusinessRuleId",
                        column: x => x.ClaimBusinessRuleId,
                        principalTable: "ClaimBusinessRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EndPointClaimBusinessRules_EndPoints_EndPointId",
                        column: x => x.EndPointId,
                        principalTable: "EndPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EndPointClaimBusinessRules_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PageClaimBusinessRules",
                columns: table => new
                {
                    PageId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimBusinessRuleId = table.Column<long>(type: "bigint", nullable: false),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageClaimBusinessRules", x => new { x.PageId, x.ClaimBusinessRuleId });
                    table.ForeignKey(
                        name: "FK_PageClaimBusinessRules_ClaimBusinessRules_ClaimBusinessRuleId",
                        column: x => x.ClaimBusinessRuleId,
                        principalTable: "ClaimBusinessRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PageClaimBusinessRules_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PageClaimBusinessRules_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ExecutionOrders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Before Execution" },
                    { 2L, "After Execution" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimBusinessRules_ExecutionOrderId",
                table: "ClaimBusinessRules",
                column: "ExecutionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimBusinessRules_StatusId",
                table: "ClaimBusinessRules",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EndPointClaimBusinessRules_ClaimBusinessRuleId",
                table: "EndPointClaimBusinessRules",
                column: "ClaimBusinessRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_EndPointClaimBusinessRules_StatusId",
                table: "EndPointClaimBusinessRules",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PageClaimBusinessRules_ClaimBusinessRuleId",
                table: "PageClaimBusinessRules",
                column: "ClaimBusinessRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_PageClaimBusinessRules_StatusId",
                table: "PageClaimBusinessRules",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PagePermissions_PermissionId",
                table: "PagePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PagePermissions_StatusId",
                table: "PagePermissions",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_StatusId",
                table: "Pages",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EndPointClaimBusinessRules");

            migrationBuilder.DropTable(
                name: "PageClaimBusinessRules");

            migrationBuilder.DropTable(
                name: "PagePermissions");

            migrationBuilder.DropTable(
                name: "ClaimBusinessRules");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "ExecutionOrders");

            migrationBuilder.CreateTable(
                name: "EndPointUserActivities",
                columns: table => new
                {
                    EndPointActivityId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndPointUserActivities", x => x.EndPointActivityId);
                    table.ForeignKey(
                        name: "FK_EndPointUserActivities_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EndPointUserActivities_EndPointActivities_EndPointActivityId",
                        column: x => x.EndPointActivityId,
                        principalTable: "EndPointActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EndPointGuestActivities",
                columns: table => new
                {
                    EndPointActivityId = table.Column<long>(type: "bigint", nullable: false),
                    GuestId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndPointGuestActivities", x => x.EndPointActivityId);
                    table.ForeignKey(
                        name: "FK_EndPointGuestActivities_EndPointActivities_EndPointActivityId",
                        column: x => x.EndPointActivityId,
                        principalTable: "EndPointActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EndPointGuestActivities_Guest_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EndPointGuestActivities_GuestId",
                table: "EndPointGuestActivities",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_EndPointUserActivities_UserId",
                table: "EndPointUserActivities",
                column: "UserId");
        }
    }
}
