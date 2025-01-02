﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Moongazing.Ink.Kernel.CrossCuttingConcerns.Exceptions.Types;
using Moongazing.Ink.Kernel.Security.Constants;

namespace Moongazing.Ink.Kernel.Application.Pipelines.Authorization;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ISecuredRequest
{
    private readonly IHttpContextAccessor httpContextAccessor;
    public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {

        ICollection<string>? userRoleClaims = httpContextAccessor.HttpContext?.User?.ClaimRoles()
            ?? throw new AuthorizationException("Claims not found.");

        bool isMatchedAUserRoleClaimWithRequestRoles = !userRoleClaims.Any(userRoleClaim =>
               userRoleClaim == GeneralOperationClaims.Admin || request.Roles.Contains(userRoleClaim));

        if (isMatchedAUserRoleClaimWithRequestRoles)
        {

            throw new AuthorizationException("You are not authorized.");
        }

        TResponse response = await next();

        return response;
    }
}
