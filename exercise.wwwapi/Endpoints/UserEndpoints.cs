using AutoMapper;
using exercise.models;
using exercise.wwwapi.DTOs;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace exercise.wwwapi.Endpoints
{
    public static class UserEndpoints
    {
        public static void ConfigureUserEndpoints(this WebApplication app)
        {
            var users = app.MapGroup("users");
            users.MapPost("/", CreateUser).WithSummary("Create user");
            users.MapGet("/", GetUsers).WithSummary("Get all users by first name if provided");
            users.MapGet("/d/{id}", GetUserById).WithSummary("Get user by user id");
            app.MapPatch("/{id}", UpdateUser).WithSummary("Update a user");
            app.MapPost("/login", Login).WithSummary("Localhost Login");
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetUsers(string? firstName, IRepository<User> userRepository)
        {
            IEnumerable<User> results = await userRepository.Get();
            UserDataDto userData = new UserDataDto() { Users = !string.IsNullOrEmpty(firstName) ? results.Where(i => i.Email.Contains(firstName)).ToList() : results.ToList() };            
            APIResponseDTO response = new APIResponseDTO(){  Status = "success",Data = userData};                        
            return TypedResults.Ok(response);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetUserById(int id)
        {
            return TypedResults.Ok();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateUser(int id)
        {
            return TypedResults.Ok();
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateUser(NewUser model)
        {

            return TypedResults.Created();
        }
        public static async Task<IResult> Login()
        {
            return TypedResults.Ok();
        }
    }
}
