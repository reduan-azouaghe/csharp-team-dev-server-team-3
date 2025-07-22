using Microsoft.AspNetCore.Mvc;
using System;

namespace exercise.wwwapi.Endpoints
{
    public static class UserEndpoints
    {
        public static void ConfigureUserEndpoints(this WebApplication app)
        {
            var users = app.MapGroup("users");
            users.MapGet("/", GetUsers);
            users.MapGet("/{id}", GetUserById);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetUsers(string? firstName)
        {
            if (!string.IsNullOrEmpty(firstName))
            {
                throw new NotImplementedException();
            }
            return TypedResults.Ok();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetUserById(int id)
        {
            return TypedResults.Ok();
        }
    }
}
