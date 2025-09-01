
using exercise.wwwapi.DTOs.Register;
using exercise.wwwapi.DTOs.Validation;
using exercise.wwwapi.Helpers;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.Endpoints
{
    public static class ValidationEndpoint
    {
        public static void ConfigureValidationEndpoint(this WebApplication app)
        {
            var validatiors = app.MapGroup("/validation");
            validatiors.MapPost("/password", ValidatePassword).WithSummary("Validate a password");
            validatiors.MapPost("/email", ValidateEmail).WithSummary("Validate an email address");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static IResult ValidateEmail(IRepository<User> repository, EmailDTO email)
        {
            string result = Helpers.Validator.Email(email.Email);
            var emailExists = repository.GetAllFiltered(q => q.Email == email.Email);
            if (result == null) return TypedResults.BadRequest("Something went wrong!");
            if (result != "Accepted") return TypedResults.BadRequest(result);
            return TypedResults.Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static  IResult ValidatePassword(PasswordDTO password)
        {
            string result = Helpers.Validator.Password(password.password);
            if (result == null) return TypedResults.BadRequest("Something went wrong!");
            else if (result == "Accepted") return TypedResults.Ok();
            else return TypedResults.BadRequest(result);
        }
    }
}
