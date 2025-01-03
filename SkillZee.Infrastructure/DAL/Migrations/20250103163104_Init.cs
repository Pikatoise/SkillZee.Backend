using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillZee.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderSpeed",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    RewardMultiplier = table.Column<double>(type: "double precision", nullable: false, defaultValue: 1.0),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSpeed", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Nickname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Balance = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                    AvatarUri = table.Column<string>(type: "text", nullable: false),
                    IsWorker = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    SuccessOrders = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    LastOnline = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WorkerInfoId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BalanceTransaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BalanceTransaction_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    Reward = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                    OrderSpeedId = table.Column<Guid>(type: "uuid", nullable: false),
                    AreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkerId = table.Column<Guid>(type: "uuid", nullable: true),
                    ResultId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_OrderSpeed_OrderSpeedId",
                        column: x => x.OrderSpeedId,
                        principalTable: "OrderSpeed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_User_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_User_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkerInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    WorkerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerInfo_User_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalReward = table.Column<double>(type: "double precision", nullable: false),
                    WorkingTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    WorkerScore = table.Column<byte>(type: "smallint", nullable: true),
                    CustomerScore = table.Column<byte>(type: "smallint", nullable: true),
                    TipId = table.Column<Guid>(type: "uuid", nullable: true),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderResult_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreaWorkerInfo",
                columns: table => new
                {
                    WorkerAreasId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkerInfosId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaWorkerInfo", x => new { x.WorkerAreasId, x.WorkerInfosId });
                    table.ForeignKey(
                        name: "FK_AreaWorkerInfo_Area_WorkerAreasId",
                        column: x => x.WorkerAreasId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaWorkerInfo_WorkerInfo_WorkerInfosId",
                        column: x => x.WorkerInfosId,
                        principalTable: "WorkerInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillWorkerInfo",
                columns: table => new
                {
                    WorkerInfosId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkerSkillsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillWorkerInfo", x => new { x.WorkerInfosId, x.WorkerSkillsId });
                    table.ForeignKey(
                        name: "FK_SkillWorkerInfo_Skill_WorkerSkillsId",
                        column: x => x.WorkerSkillsId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillWorkerInfo_WorkerInfo_WorkerInfosId",
                        column: x => x.WorkerInfosId,
                        principalTable: "WorkerInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tip",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    ResultId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tip_OrderResult_ResultId",
                        column: x => x.ResultId,
                        principalTable: "OrderResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaWorkerInfo_WorkerInfosId",
                table: "AreaWorkerInfo",
                column: "WorkerInfosId");

            migrationBuilder.CreateIndex(
                name: "IX_BalanceTransaction_UserId",
                table: "BalanceTransaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AreaId",
                table: "Order",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderSpeedId",
                table: "Order",
                column: "OrderSpeedId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_WorkerId",
                table: "Order",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderResult_OrderId",
                table: "OrderResult",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkillWorkerInfo_WorkerSkillsId",
                table: "SkillWorkerInfo",
                column: "WorkerSkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tip_ResultId",
                table: "Tip",
                column: "ResultId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkerInfo_WorkerId",
                table: "WorkerInfo",
                column: "WorkerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaWorkerInfo");

            migrationBuilder.DropTable(
                name: "BalanceTransaction");

            migrationBuilder.DropTable(
                name: "SkillWorkerInfo");

            migrationBuilder.DropTable(
                name: "Tip");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "WorkerInfo");

            migrationBuilder.DropTable(
                name: "OrderResult");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "OrderSpeed");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
