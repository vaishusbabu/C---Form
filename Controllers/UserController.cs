using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Form_test.Model;
using System.Threading.Tasks;

namespace Form_test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly RegisterPatientContext _context;

        public UserController(RegisterPatientContext context)
        {
            _context = context;
        }

       
        // POST: api/User/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterPatient registerPatient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Remove the check for existing email, allowing duplicates
            // var existingUser = await _context.RegisterPatient
            //     .FirstOrDefaultAsync(u => u.Email == registerPatient.Email);

            // if (existingUser != null)
            // {
            //     return Conflict("User with this email already exists.");
            // }

            registerPatient.Password = HashPassword(registerPatient.Password);

            // Set registration date and time
            registerPatient.RegistrationDate = DateOnly.FromDateTime(DateTime.UtcNow);
            var now = DateTime.UtcNow;
            registerPatient.RegistrationTime = now.ToString("HH:mm"); // Format the time in HH:mm

            _context.RegisterPatient.Add(registerPatient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Register), new { id = registerPatient.HealthCareNumber }, registerPatient);
        }

        // POST: api/User/Login
        // POST: api/User/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check for user based on email and health care number
            var user = await _context.RegisterPatient
                .FirstOrDefaultAsync(u => u.Email == loginRequest.Email && u.HealthCareNumber == loginRequest.HealthCareNumber);

            if (user == null || !VerifyPassword(loginRequest.Password, user.Password))
            {
                return Unauthorized("Invalid email, health care number, or password.");
            }

            return Ok("Login successful");
        }

        // POST: api/User/ForgotPassword
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            // Check for user based on email and health care number
            var user = await _context.RegisterPatient.FirstOrDefaultAsync(u => u.Email == request.Email && u.HealthCareNumber == request.HealthCareNumber);

            if (user == null)
            {
                return NotFound("User with this email and health care number does not exist.");
            }

            string otp = new Random().Next(1000, 9999).ToString();

            user.Otp = otp;
            user.OtpExpiration = DateTime.UtcNow.AddMinutes(15);

            await _context.SaveChangesAsync();

            SendOtpEmail(user.Email, otp);

            return Ok("OTP sent to your email.");
        }

        
        // POST: api/User/VerifyOtp
        [HttpPost("VerifyOtp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpRequest request)
        {
            // Check for user based on email and health care number
            var user = await _context.RegisterPatient.FirstOrDefaultAsync(u =>
                u.Email == request.Email && u.HealthCareNumber == request.HealthCareNumber);

            if (user == null)
            {
                return NotFound("User with this email and health care number does not exist.");
            }

            if (user.Otp != request.Otp || user.OtpExpiration < DateTime.UtcNow)
            {
                return Unauthorized("Invalid or expired OTP.");
            }

            if (request.NewPassword != request.ConfirmPassword)
            {
                return BadRequest("New password and confirm password do not match.");
            }

            user.Password = HashPassword(request.NewPassword);

            user.Otp = null;
            user.OtpExpiration = null;

            await _context.SaveChangesAsync();

            return Ok("Password reset successful.");
        }

        private void SendOtpEmail(string email, string otp)
        {
            try
            {
                var mail = new MailMessage();
                var smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("vaishusbabu@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Your OTP for Password Reset";
                mail.Body = $"Your OTP is: {otp}";

                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential("vaishusbabu@gmail.com", "fsdpftyvyjmcglnb");
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        private bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            return HashPassword(enteredPassword) == hashedPassword;
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; } = "";
        public string HealthCareNumber { get; set; } = ""; // New property
        public string Password { get; set; } = "";
    }


    public class ForgotPasswordRequest
    {
        public string Email { get; set; }
        public string HealthCareNumber { get; set; } // New property
    }


    public class VerifyOtpRequest
    {
        public string Email { get; set; }
        public string HealthCareNumber { get; set; } // New property
        public string Otp { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }

}
