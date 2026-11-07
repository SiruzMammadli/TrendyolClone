using System.ComponentModel.DataAnnotations;
using Api.Domain.Entities;

namespace Api.Application.Dtos;

public sealed record RegisterRequest(
    string Email,
    string Password,
    string Fullname,
    UserRole Role);
