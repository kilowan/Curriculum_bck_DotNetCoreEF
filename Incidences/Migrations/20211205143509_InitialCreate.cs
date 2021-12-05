﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Incidences.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employee_range",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_range", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "note_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_note_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "piece_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_piece_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    dni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    surname1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    surname2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typeId = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.id);
                    table.ForeignKey(
                        name: "FK_employee_Credentials_id",
                        column: x => x.id,
                        principalTable: "Credentials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_employee_range_typeId",
                        column: x => x.typeId,
                        principalTable: "employee_range",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "piece_class",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typeId = table.Column<int>(type: "int", nullable: false),
                    deleted = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_piece_class", x => x.id);
                    table.ForeignKey(
                        name: "FK_piece_class_piece_type_typeId",
                        column: x => x.typeId,
                        principalTable: "piece_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "incidence",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ownerId = table.Column<int>(type: "int", nullable: false),
                    solverId = table.Column<int>(type: "int", nullable: true),
                    open_dateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    close_dateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incidence", x => x.id);
                    table.ForeignKey(
                        name: "FK_incidence_employee_ownerId",
                        column: x => x.ownerId,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_incidence_employee_solverId",
                        column: x => x.solverId,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_incidence_state_state",
                        column: x => x.state,
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "incidence_piece_log",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pieceId = table.Column<int>(type: "int", nullable: false),
                    incidenceId = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incidence_piece_log", x => x.id);
                    table.ForeignKey(
                        name: "FK_incidence_piece_log_incidence_pieceId",
                        column: x => x.pieceId,
                        principalTable: "incidence",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_incidence_piece_log_piece_class_pieceId",
                        column: x => x.pieceId,
                        principalTable: "piece_class",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeId = table.Column<int>(type: "int", nullable: false),
                    incidenceId = table.Column<int>(type: "int", nullable: false),
                    noteTypeId = table.Column<int>(type: "int", nullable: false),
                    noteStr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Notes_employee_employeeId",
                        column: x => x.employeeId,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_incidence_incidenceId",
                        column: x => x.incidenceId,
                        principalTable: "incidence",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Notes_note_type_noteTypeId",
                        column: x => x.noteTypeId,
                        principalTable: "note_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employee_typeId",
                table: "employee",
                column: "typeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_incidence_ownerId",
                table: "incidence",
                column: "ownerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_incidence_solverId",
                table: "incidence",
                column: "solverId",
                unique: true,
                filter: "[solverId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_incidence_state",
                table: "incidence",
                column: "state",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_incidence_piece_log_pieceId",
                table: "incidence_piece_log",
                column: "pieceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_employeeId",
                table: "Notes",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_incidenceId",
                table: "Notes",
                column: "incidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_noteTypeId",
                table: "Notes",
                column: "noteTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_piece_class_typeId",
                table: "piece_class",
                column: "typeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "incidence_piece_log");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "piece_class");

            migrationBuilder.DropTable(
                name: "incidence");

            migrationBuilder.DropTable(
                name: "note_type");

            migrationBuilder.DropTable(
                name: "piece_type");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "state");

            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropTable(
                name: "employee_range");
        }
    }
}
