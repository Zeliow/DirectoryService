using CSharpFunctionalExtensions;
using DirectoryService.Domain.VO;
using System.Xml.Linq;

namespace DirectoryService.Domain;

public class Department
{
    private readonly List<Department> _departments = [];
    private readonly List<Position> _positions = [];
    private readonly List<Location> _location = [];
    private Department() { }

    public Department(
        Name name, 
        Identifier identifier, 
        PathDepartment path, 
        Department? parent, 
        short depth, 
        IEnumerable<Location> location)
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
    public Identifier Identifier { get; private set; }
    public Department? Parent { get; private set; }
    public PathDepartment Path { get; private set; }
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
        Identifier identifier, 
        PathDepartment path, 
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
