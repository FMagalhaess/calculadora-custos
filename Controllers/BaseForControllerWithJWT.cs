using System.Security.Claims;
using calculadora_custos.Results;
using Microsoft.AspNetCore.Mvc;

namespace calculadora_custos.Controllers;

public abstract class BaseForControllerWithJwt : ControllerBase
{
    protected Guid CurrentUserId {
        get
        {
            var sub = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(sub))
                throw new InvalidOperationException("JWT sem claim 'sub'.");
            if (!Guid.TryParse(sub, out var userIdGuid))
                throw new InvalidOperationException("Claim 'sub' não é um GUID.");
            return userIdGuid;
        }
    }
}