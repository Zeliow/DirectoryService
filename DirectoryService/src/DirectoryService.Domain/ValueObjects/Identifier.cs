using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace DirectoryService.Domain.VO;

public record Identifier
{
    public const int MIN_VALUE_LENGHT = 3;
    public const int MAX_VALUE_LENGHT = 150;
    public string Value { get; }

    public Identifier(string value)
    {
        Value = value;
    }
    
    public static Result<Identifier> Create(string value)
    {

        if (string.IsNullOrWhiteSpace(value) || (value.Length < MIN_VALUE_LENGHT || value.Length > MAX_VALUE_LENGHT) || !Regex.IsMatch(value, @"\P{IsCyrillic}"))
            return Result.Failure<Identifier>("not valid identifier");
        return new Identifier(value);
    }
}