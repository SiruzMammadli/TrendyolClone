namespace Api.Application.Dtos;

public sealed record LoginRequest(
    string Email,
    string Password);
