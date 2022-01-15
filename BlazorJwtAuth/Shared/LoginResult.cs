﻿namespace BlazorJwtAuth.Shared;

public record LoginResult(bool IsSuccessful, string Error = null, string Token = null);
