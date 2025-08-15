using CSharpFunctionalExtensions;
using System.Xml.Linq;

namespace DirectoryService.Domain;

public class Department
{
    private readonly List<Department> _departments = [];
    private readonly List<Position> _positions = [];
    private Department() { }

    private Department(string name, string identifier)
    {
        Id = Guid.NewGuid();
        Name = name;
        Identifier = identifier;    
        IsActive = true;
        CreateAt = DateTime.UtcNow;
        UpdateAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Identifier { get; private set; }
    public string Path { get; private set; }
    public short Depth { get; private set;}
    public int ChildrenCount => Departments.Count;
    public bool IsActive { get; private set; }
    public DateTime CreateAt {  get; private set; }
    public DateTime UpdateAt { get; private set; }


    public IReadOnlyList<Position> Positions  => _positions;
    public IReadOnlyList<Department> Departments => _departments;



    public static Result<Department> Create(string identifier, string name)
    {
        if (string.IsNullOrWhiteSpace(name) || (name.Length < 3 || name.Length > 150)) 
            return Result.Failure<Department>("not valid name");

        if (string.IsNullOrWhiteSpace(identifier) || (identifier.Length < 3 || identifier.Length > 150)) 
            return Result.Failure<Department>("not valid indent");

        var department = new Department(name, identifier);
        return Result.Success(department);
    }

}
