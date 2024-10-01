using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Form_test.Model
{
    public class RegisterPatient
    {
        [Key]
        [Required]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "Health care number must be exactly 14 digits.")]
        public string HealthCareNumber { get; set; } = "";

        [Required]
        [JsonPropertyName("registrationDate")]
        public DateOnly RegistrationDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow); // Default to current date

        [Required]
        [RegularExpression(@"^([01]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Time must be in HH:mm format.")]
        public string RegistrationTime { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(2)")]
        [RegularExpression(@"^(AM|PM)$", ErrorMessage = "Must be AM or PM.")]
        public string AmPm { get; set; } = "";

        [Required, Column(TypeName = "nvarchar(100)")]
        public string PatientFirstName { get; set; } = "";

        [Required, Column(TypeName = "nvarchar(100)")]
        public string PatientLastName { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        [RegularExpression(@"^(Female|Male|N/A)$", ErrorMessage = "Invalid sex option. Allowed values are Female, Male, N/A.")]
        public string Sex { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(9)")]
        [RegularExpression(@"^(January|February|March|April|May|June|July|August|September|October|November|December)$", ErrorMessage = "Please select a valid month.")]
        public string BirthMonth { get; set; } = "";

        [Required]
        [Range(1, 31, ErrorMessage = "Please select a valid day.")]
        public int BirthDay { get; set; }

        [Required]
        [Range(1920, 2024, ErrorMessage = "Please select a valid year.")]
        public int BirthYear { get; set; }

        [NotMapped]
        public DateTime DateOfBirth
        {
            get
            {
                if (IsValidDate(BirthYear, GetMonthNumber(BirthMonth), BirthDay))
                {
                    return new DateTime(BirthYear, GetMonthNumber(BirthMonth), BirthDay);
                }
                throw new ValidationException("Invalid date of birth.");
            }
        }

        private int GetMonthNumber(string monthName)
        {
            return DateTime.ParseExact(monthName, "MMMM", CultureInfo.InvariantCulture).Month;
        }

        [Required]
        [RegularExpression(@"\(\d{3}\) \d{3}-\d{4}", ErrorMessage = "Phone number must be in the format (123) 456-7890.")]
        [Column(TypeName = "nvarchar(15)")]
        public string PhoneNumber { get; set; } = "";

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; } = "";

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must be at least 8 characters long and include uppercase letters, lowercase letters, numbers, and special characters.")]
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string StreetAddress { get; set; } = "";

        [Column(TypeName = "nvarchar(100)")]
        public string StreetAddressLine2 { get; set; } = "";

        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string StateOrProvince { get; set; } = "";

        [Column(TypeName = "nvarchar(20)")]
        public string PostalOrZipCode { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        [RegularExpression(@"^(Single|Married|Divorced|Legally Separated|Widowed)$",
            ErrorMessage = "Marital status must be one of the following: Single, Married, Divorced, Legally Separated, Widowed.")]
        public string MaritalStatus { get; set; } = "";

        [Required]
        public bool IsYoungerThan18 { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string EmergencyContactFirstName { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string EmergencyContactLastName { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string EmergencyContactRelationship { get; set; } = "";

        [Required]
        [RegularExpression(@"\(\d{3}\) \d{3}-\d{4}", ErrorMessage = "Phone number must be in the format (123) 456-7890.")]
        [Column(TypeName = "nvarchar(15)")]
        public string EmergencyContactPhoneNumber { get; set; } = "";

        [Column(TypeName = "nvarchar(100)")]
        public string FamilyDoctorFirstName { get; set; } = "";

        [Column(TypeName = "nvarchar(100)")]
        public string FamilyDoctorLastName { get; set; } = "";

        [Required]
        [RegularExpression(@"\(\d{3}\) \d{3}-\d{4}", ErrorMessage = "Phone number must be in the format (123) 456-7890.")]
        [Column(TypeName = "nvarchar(15)")]
        public string FamilyDoctorPhoneNumber { get; set; } = "";

        [Column(TypeName = "nvarchar(100)")]
        public string PreferredPharmacy { get; set; } = "";

        [Required]
        [RegularExpression(@"\(\d{3}\) \d{3}-\d{4}", ErrorMessage = "Phone number must be in the format (123) 456-7890.")]
        [Column(TypeName = "nvarchar(15)")]
        public string PharmacyPhoneNumber { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string ReasonForRegistration { get; set; } = "";

        [Column(TypeName = "nvarchar(500)")]
        public string AdditionalNotes { get; set; } = "";

        [Required]
        public bool TakingMedications { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string InsuranceCompany { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [RegularExpression(@"^H\d{9}$", ErrorMessage = "Insurance ID must start with 'H' followed by 9 digits (e.g., H123456789).")]
        public string InsuranceID { get; set; } = "";

        [Column(TypeName = "nvarchar(100)")]
        public string PolicyHolderFirstName { get; set; } = "";

        [Column(TypeName = "nvarchar(100)")]
        public string PolicyHolderLastName { get; set; } = "";

        public DateOnly PolicyHolderDateOfBirth { get; set; }

        public static bool IsValidDate(int year, int month, int day)
        {
            try
            {
                DateTime birthDate = new DateTime(year, month, day);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [Column(TypeName = "nvarchar(4)")]
        public string? Otp { get; set; }

        public DateTime? OtpExpiration { get; set; }
    }
}
