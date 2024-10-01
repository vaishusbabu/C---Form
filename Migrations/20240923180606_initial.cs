using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Form_test.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RegisterPatient",
                columns: table => new
                {
                    HealthCareNumber = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegistrationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    RegistrationDateString = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegistrationTime = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AmPm = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    PatientFirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PatientLastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    BirthMonth = table.Column<string>(type: "nvarchar(9)", nullable: false),
                    BirthDay = table.Column<int>(type: "int", nullable: false),
                    BirthYear = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    StreetAddressLine2 = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    StateOrProvince = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PostalOrZipCode = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    IsYoungerThan18 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EmergencyContactFirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    EmergencyContactLastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    EmergencyContactRelationship = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EmergencyContactPhoneNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    FamilyDoctorFirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    FamilyDoctorLastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    FamilyDoctorPhoneNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    PreferredPharmacy = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PharmacyPhoneNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    ReasonForRegistration = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    TakingMedications = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    InsuranceCompany = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    InsuranceID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PolicyHolderFirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PolicyHolderLastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PolicyHolderDateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Otp = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    OtpExpiration = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterPatient", x => x.HealthCareNumber);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterPatient");
        }
    }
}
