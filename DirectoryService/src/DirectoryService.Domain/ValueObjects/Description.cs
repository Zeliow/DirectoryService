using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.VO;

public record Description
{
    public const int MAX_VALUE_LENGHT = 100;
    public string Value { get; }
    public Description(string value)
    {
        Value = value;
    }
    

    public static Result<Description> Create(string value)
    {
        if (value.Length > MAX_VALUE_LENGHT)
        {
            return Result.Failure<Description>("too long description");
        }
        return new Description(value);
    }
}

