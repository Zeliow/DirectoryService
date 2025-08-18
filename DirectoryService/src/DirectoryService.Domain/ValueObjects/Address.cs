using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.VO;

public record Address
{
    public const int MIN_VALUE_LENGHT = 10;
    public const int MAX_VALUE_LENGHT = 100;
    public string Value { get; }
    public Address(string value)
    {
        Value = value;
    }
    

    public static Result<Address> Create(string value)
    {
        if (!string.IsNullOrWhiteSpace(value)) return Result.Failure<Address>("value is null");

        if (string.IsNullOrWhiteSpace(value) || value.Length < MIN_VALUE_LENGHT || value.Length > MAX_VALUE_LENGHT)
            return Result.Failure<Address>("not valid Adress");
        return new Address(value);
    }
}
