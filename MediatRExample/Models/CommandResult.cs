namespace MediatRExample.Models;

public record CommandResult(bool IsSuccess, string? Error = null);
