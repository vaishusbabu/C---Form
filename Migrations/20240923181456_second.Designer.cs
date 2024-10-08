﻿// <auto-generated />
using System;
using Form_test.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Form_test.Migrations
{
    [DbContext(typeof(RegisterPatientContext))]
    [Migration("20240923181456_second")]
    partial class second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Form_test.Model.RegisterPatient", b =>
                {
                    b.Property<string>("HealthCareNumber")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AdditionalNotes")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("AmPm")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)");

                    b.Property<int>("BirthDay")
                        .HasColumnType("int");

                    b.Property<string>("BirthMonth")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)");

                    b.Property<int>("BirthYear")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmergencyContactFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmergencyContactLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmergencyContactPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("EmergencyContactRelationship")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FamilyDoctorFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FamilyDoctorLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FamilyDoctorPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("InsuranceCompany")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("InsuranceID")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsYoungerThan18")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("MaritalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Otp")
                        .HasColumnType("nvarchar(4)");

                    b.Property<DateTime?>("OtpExpiration")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PatientFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PatientLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PharmacyPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateOnly>("PolicyHolderDateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("PolicyHolderFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PolicyHolderLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PostalOrZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PreferredPharmacy")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ReasonForRegistration")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateOnly>("RegistrationDate")
                        .HasColumnType("date")
                        .HasAnnotation("Relational:JsonPropertyName", "registrationDate");

                    b.Property<string>("RegistrationTime")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("StateOrProvince")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StreetAddressLine2")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("TakingMedications")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("HealthCareNumber");

                    b.ToTable("RegisterPatient");
                });
#pragma warning restore 612, 618
        }
    }
}
