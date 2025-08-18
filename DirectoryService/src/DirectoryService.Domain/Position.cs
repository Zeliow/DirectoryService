using CSharpFunctionalExtensions;

namespace DirectoryService.Domain;

public class Position
{
    public Position(string name, Description description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        IsActive = true;
        CreateAt = DateTime.UtcNow;
        UpdateAt = DateTime.UtcNow;

    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Description? Description { get; set; }
    public bool IsActive { get; set;}
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }


    public static Result<Position> Create (string name, Description description)
    {
        if (string.IsNullOrWhiteSpace(name) || (name.Length < 3 || name.Length > 100)) 
        {
            return Result.Failure<Position>("Not valid Name");
        }
        var position = new Position(name, description);

        return Result.Success<Position>(position);
    }
}

public record Description
{
    public const int MAX_VALUE_LENGHT = 100;
    public Description(string value)
    {
        Value = value;
    }
    public string Value { get; }

    public static Result<Description> Create(string value)
    {
        if (value.Length > MAX_VALUE_LENGHT)
        {
            return Result.Failure<Description>("too long description");
        }
        return new Description(value);
    }
}

