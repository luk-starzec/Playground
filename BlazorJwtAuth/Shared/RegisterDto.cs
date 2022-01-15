namespace BlazorJwtAuth.Shared;

public record RegisterDto(string Name, string Password, string[] Roles);