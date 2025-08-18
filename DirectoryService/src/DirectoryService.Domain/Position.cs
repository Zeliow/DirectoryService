using CSharpFunctionalExtensions;
using DirectoryService.Domain.VO;

namespace DirectoryService.Domain;

public class Position
{
    public Position(
        string name, 
        Description description)
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


    public static Result<Position> Create (
        string name,
        Description description)
    {
        if (string.IsNullOrWhiteSpace(name) || (name.Length < 3 || name.Length > 100)) 
        {
            return Result.Failure<Position>("Not valid Name");
        }
        var position = new Position(name, description);

        return Result.Success<Position>(position);
    }
}

