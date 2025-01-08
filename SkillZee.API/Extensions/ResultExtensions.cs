using SkillZee.Domain.Enum;
using SkillZee.Domain.Result;

namespace SkillZee.API.Extensions
{
    public static class ResultExtensions
    {
        public static IResult ToProblemDetails(this BaseResult result)
        {
            if (result.IsSuccess)
                throw new InvalidOperationException("Attempt to return success result as error");

            return Results.Problem
                (
                    statusCode: GetStatusCode(result.Error.Type),
                    title: GetTitle(result.Error.Type),
                    detail: result.Error.Description
                );
        }

        static int GetStatusCode(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError
            };

        static string GetTitle(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.Failure => "Server Failure",
                ErrorType.Validation => "Incorrect data",
                ErrorType.NotFound => "No data found",
                ErrorType.Conflict => "Caused conflict",
                _ => "Unexpected failure"
            };
    }
}
