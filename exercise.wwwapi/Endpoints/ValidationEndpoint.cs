
using exercise.wwwapi.DTOs.Register;
using exercise.wwwapi.DTOs.Validation;
using exercise.wwwapi.Helpers;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class ValidationEndpoint
    {
        public static void ConfigureValidationEndpoint(this WebApplication app)
        {
            var validatiors = app.MapGroup("/validation");
            validatiors.MapPost("/password", ValidatePassword).WithSummary("Validate a password");
            validatiors.MapPost("/username", ValidateUsername).WithSummary("Validate a Username");
        }

        /// <summary>
        /// Validates a password using custom password rules.
        /// </summary>
        /// <param name="password">A <see cref="PasswordDTO"/> object containing the password to validate.</param>
        /// <returns>
        /// 200 OK response if the password is accepted.<br/>
        /// 400 Bad Request with a message if the password is invalid or if validation fails. 
        /// </returns>
        /// <response code="200">Password is valid and accepted.</response>
        /// <response code="400">Password is invalid or validation failed.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static IResult ValidatePassword(PasswordDTO passwordDTO)
        {
            if (passwordDTO == null || string.IsNullOrEmpty(passwordDTO.password))
                return TypedResults.BadRequest("Something went wrong!");
            string result = Validator.Password(passwordDTO.password);
            if (result == null) return TypedResults.BadRequest("Something went wrong!");
            else if (result == "Accepted") return TypedResults.Ok();
            else return TypedResults.BadRequest(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static IResult ValidateUsername(UsernameDTO usernameDTO)
        {
            if (usernameDTO == null || string.IsNullOrEmpty(usernameDTO.Username))
                return TypedResults.BadRequest("Something went wrong!");
            string result = Validator.Username(usernameDTO.Username);
            if (result == null) return TypedResults.BadRequest("Something went wrong!");
            else if (result == "Accepted") return TypedResults.Ok();
            else return TypedResults.BadRequest(result);
        }
    }
}
