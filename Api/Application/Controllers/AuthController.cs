using System.Net.Mail;
using System.Security.Cryptography;
using Api.Application.Dtos;
using Api.Domain.Entities;
using Api.Persistence.Repositories.Users;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController(IUserRepository users, TimeProvider clock) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request, CancellationToken ct)
    {
        if (!IsValidEmail(request.Email))
            return BadRequest("Invalid email format.");

        if (request.Role is not (UserRole.Buyer or UserRole.Seller))
            return BadRequest("Role must be Buyer or Seller.");

        if (await users.GetByEmailAsync(request.Email, ct) is not null)
            return Conflict("Email already registered.");

        var user = new User
        {
            Email = request.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Fullname = request.Fullname,
            Role = request.Role,
            CreatedAt = clock.GetUtcNow().UtcDateTime
        };

        await users.AddAsync(user, ct);
        await users.SaveChangesAsync(ct);

        return Ok(new { user.Id });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken ct)
    {
        if (!IsValidEmail(request.Email))
            return BadRequest("Invalid email format.");

        var user = await users.GetByEmailAsync(request.Email, ct);

        if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            return Unauthorized("Invalid email or password.");

        // ponytail: token is not stored/validated server-side; persist it (or switch to JWT) when auth is enforced
        var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

        return Ok(new { token });
    }

    private static bool IsValidEmail(string email) =>
        MailAddress.TryCreate(email, out var mail) && mail.Address == email;
}
