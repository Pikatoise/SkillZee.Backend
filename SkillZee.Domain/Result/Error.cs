using SkillZee.Domain.Enum;

namespace SkillZee.Domain.Result
{
    public class Error
    {
        public string Code { get; }

        public string Description { get; }

        public ErrorType Type { get; set; }

        public Error(string code, string description, ErrorType type)
        {
            Code = code;
            Description = description;
            Type = type;
        }

        public static readonly Error None = new(String.Empty, String.Empty, ErrorType.Failure);
        public static readonly Error NullValue = new("Error.NullValue", "Null value was provided", ErrorType.Failure);

        public static Error Failure(string code, string decription) =>
            new(code, decription, ErrorType.Failure);

        public static Error Validation(string code, string decription) =>
            new(code, decription, ErrorType.Validation);

        public static Error NotFound(string code, string decription) =>
            new(code, decription, ErrorType.NotFound);

        public static Error Conflict(string code, string decription) =>
            new(code, decription, ErrorType.Conflict);
    }
}
