using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Availability",
                columns: table => new
                {
                    AvailabilityId = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availability", x => x.AvailabilityId);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassId = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    ColorId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "char(7)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.ColorId);
                });

            migrationBuilder.CreateTable(
                name: "Make",
                columns: table => new
                {
                    MakeId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Make", x => x.MakeId);
                });

            migrationBuilder.CreateTable(
                name: "Transmission",
                columns: table => new
                {
                    TransmissionId = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmission", x => x.TransmissionId);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleId = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    ModelId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassId = table.Column<byte>(type: "tinyint", nullable: false),
                    MakeId = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TransmissionId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.ModelId);
                    table.ForeignKey(
                        name: "FK_Model_Class",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Model_Make",
                        column: x => x.MakeId,
                        principalTable: "Make",
                        principalColumn: "MakeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Model_Transmission",
                        column: x => x.TransmissionId,
                        principalTable: "Transmission",
                        principalColumn: "TransmissionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DOB = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RoleId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_UserRole",
                        column: x => x.RoleId,
                        principalTable: "UserRole",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvailabilityId = table.Column<byte>(type: "tinyint", nullable: false),
                    ColorId = table.Column<short>(type: "smallint", nullable: false),
                    ImgPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mileage = table.Column<double>(type: "float", nullable: true),
                    ModelId = table.Column<short>(type: "smallint", nullable: false),
                    RegPlateNo = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    YearManufactured = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Car_Availability",
                        column: x => x.AvailabilityId,
                        principalTable: "Availability",
                        principalColumn: "AvailabilityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Car_Color",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Car_Model",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    RentalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ExpectedReturnDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.RentalId);
                    table.ForeignKey(
                        name: "FK_Rental_Car",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rental_Employee",
                        column: x => x.EmployeeId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rental_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UQ_Availability_AvailabilityId",
                table: "Availability",
                column: "AvailabilityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Availability_Description",
                table: "Availability",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_AvailabilityId",
                table: "Car",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "UQ_Car_CarId",
                table: "Car",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_ColorId",
                table: "Car",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_ModelId",
                table: "Car",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "UQ_Car_RegPlateNo",
                table: "Car",
                column: "RegPlateNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Class_ClassId",
                table: "Class",
                column: "ClassId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Class_Name",
                table: "Class",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Color_Code",
                table: "Color",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Color_ColorId",
                table: "Color",
                column: "ColorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Color_Name",
                table: "Color",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Make_MakeId",
                table: "Make",
                column: "MakeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Make_Name",
                table: "Make",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Model_ClassId",
                table: "Model",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_MakeId",
                table: "Model",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "UQ_Model_ModelId",
                table: "Model",
                column: "ModelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Model_Name",
                table: "Model",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Model_TransmissionId",
                table: "Model",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_CarId",
                table: "Rental",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_EmployeeId",
                table: "Rental",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "UQ_Rental_RentalId",
                table: "Rental",
                column: "RentalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rental_UserId",
                table: "Rental",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UQ_Transmission_TransmissionId",
                table: "Transmission",
                column: "TransmissionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Transmission_Type",
                table: "Transmission",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_User_Email",
                table: "User",
                column: "DOB",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_User_Phone",
                table: "User",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UQ_User_UserId",
                table: "User",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_UserRole_Name",
                table: "UserRole",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rental");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Availability");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Make");

            migrationBuilder.DropTable(
                name: "Transmission");
        }
    }
}
