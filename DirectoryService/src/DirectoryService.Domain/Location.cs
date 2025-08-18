using CSharpFunctionalExtensions;
using DirectoryService.Domain.VO;

namespace DirectoryService.Domain;

public class Location
{


    private readonly List<Department> _departments = [];
    private Location() { }

    public Location(
        string name, 
        Address adress, 
        TimeZoneLocation timeZone, 
        IEnumerable<Department> departments)
    {
        Id = Guid.NewGuid();
        Name = name;
        Adress = adress;
        TimeZone = timeZone;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        _departments = departments.ToList();
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Address Adress { get; private set; }
    public TimeZoneLocation TimeZone { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public List<Department> Departments => _departments;


    public Result<Location> Create(
        string name, 
        Address adress, 
        TimeZoneLocation TimeZone, 
        IEnumerable<Department> departments)
    {
        if (string.IsNullOrWhiteSpace(Name) || (name.Length < 3 || name.Length > 120)) return Result.Failure<Location>("not valid name Location");
        if (departments.ToList().Count == 0 && departments is null) return Result.Failure<Location>("not valid count departments");

        var locatiton = new Location(name, adress, TimeZone, departments);
        return Result.Success<Location>(locatiton);
    }
}
