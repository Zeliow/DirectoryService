using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.VO;

public record Name
{
    public const int MIN_VALUE_LENGHT = 3;
    public const int MAX_VALUE_LENGHT = 150;
    public string Value { get; }
    public Name (string value)
    {
        Value = value;
    }
    

    public static Result<Name> Create(string value)
    {

        if (string.IsNullOrWhiteSpace(value) || value.Length < MIN_VALUE_LENGHT || value.Length > MAX_VALUE_LENGHT)
            return Result.Failure<Name>("not valid name");
        return new Name(value);
    }

}
