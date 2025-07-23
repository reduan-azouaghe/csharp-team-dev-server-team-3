using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LogEndpoints
    {
        public static void ConfigureLogEndpoints(this WebApplication app)
        {
            var logs = app.MapGroup("/logs");
            logs.MapPost("/", CreateDeliveryLog).WithSummary("Create a delivery log");
        }
        /// <summary>
        /// Creates a new user in the system.
        /// </summary>
        /// <remarks>
        /// This endpoint registers a user with email, password, and role.
        /// </remarks>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateDeliveryLog()
        {
            return TypedResults.Ok();
        }
    }
}
