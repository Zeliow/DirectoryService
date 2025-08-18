using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace DirectoryService.Domain;

public class Department
{
    private readonly List<Department> _departments = [];
    private readonly List<Position> _positions = [];
    private readonly List<Location> _location = [];
    private Department() { }

    public Department(Name name, string identifier,Path path, Department? parent, short depth, IEnumerable<Location> location)
    {
        Id = Guid.NewGuid();
        Name = name;
        Identifier = identifier;
        Path = path;
        IsActive = true;
        Parent = parent;
        _location = location.ToList();
        CreateAt = DateTime.UtcNow;
        UpdateAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }
    public Name Name { get; private set; }
    public string Identifier { get; private set; }
    public Department? Parent { get; private set; }
    public Path Path { get; private set; }
    public short Depth { get; private set;}
    public int ChildrenCount => ChildrenDepartments.Count;
    public bool IsActive { get; private set; }
    public DateTime CreateAt {  get; private set; }
    public DateTime UpdateAt { get; private set; }
    public IReadOnlyList<Position> Positions  => _positions;
    public IReadOnlyList<Location> Locations => _location;
    public IReadOnlyList<Department> ChildrenDepartments => _departments;


    public static Result<Department> Create(
        Name name, 
        string identifier, 
        Path path, 
        Department? parent, 
        short depth, 
        IEnumerable<Location> locations)
    {    
        if (locations.ToList().Count == 0 && locations is null)
        {
            return Result.Failure<Department>("not valid count locations");
        }

        var department = new Department(name, identifier, path, parent, depth, locations);
        return Result.Success(department);
    }

}

public record Name
{
    public const int MIN_VALUE_LENGHT = 3;
    public const int MAX_VALUE_LENGHT = 150;

    public Name (string value)
    {
        Value = value;
    }
    public string Value { get; }

    public static Result<Name> Crete(string value)
    {

        if (string.IsNullOrWhiteSpace(value) || (value.Length < MIN_VALUE_LENGHT || value.Length > MAX_VALUE_LENGHT))
            return Result.Failure<Name>("not valid name");
        return new Name(value);
    }

}

public record Path
{

    public Path(string value)
    {
        Value = value;
    }
    public string Value { get; }

    //public static Result<Path> Crete(string value)
    //{

    //    string newPath;
    //    short newDepth;

    //    // Выяснение родительского значения
    //    if (parent is null)
    //    {
    //        newPath = identifier;
    //        newDepth = 1;
    //    }
    //    else
    //    {
    //        var parentPath = parent?.Path;
    //        newPath = parentPath + "." + identifier;
    //        newDepth = (short)(parent.Depth + 1);
    //    }
    //}

}

public record Identifier
{
    public const int MIN_VALUE_LENGHT = 3;
    public const int MAX_VALUE_LENGHT = 150;

    public Identifier(string value)
    {
        Value = value;
    }
    public string Value { get; }

    public static Result<Identifier> Crete(string value)
    {

        if (string.IsNullOrWhiteSpace(value) || (value.Length < MIN_VALUE_LENGHT || value.Length > MAX_VALUE_LENGHT) || !Regex.IsMatch(value, @"\P{IsCyrillic}"))
            return Result.Failure<Identifier>("not valid ident");
        return new Identifier(value);
    }
}