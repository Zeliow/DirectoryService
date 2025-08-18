using CSharpFunctionalExtensions;

namespace DirectoryService.Domain;

public class Location
{


    private readonly List<Department> _departments = [];
    private Location() { }

    public Location(string name, Address adress, TimeZone timeZone, IEnumerable<Department> departments)
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
    public TimeZone TimeZone { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public List<Department> Departments => _departments;


    public Result<Location> Create(string name, Address adress, TimeZone TimeZone, IEnumerable<Department> departments)
    {
        if (string.IsNullOrWhiteSpace(Name) || (name.Length < 3 || name.Length > 120)) return Result.Failure<Location>("not valid name Location");
        if (departments.ToList().Count == 0 && departments is null) return Result.Failure<Location>("not valid count departments");

        var locatiton = new Location(name, adress, TimeZone, departments);
        return Result.Success<Location>(locatiton);
    }
}

public record TimeZone
{
    public TimeZone(string value)
    {
        Value = value;
    }
    public string Value { get; }

    public static Result<TimeZone> Create(string value)
    {
        if (!string.IsNullOrWhiteSpace(value)) return Result.Failure<TimeZone>("value is null");

        var validZone = TimeZoneInfo.GetSystemTimeZones().Select(tz => tz.Id).ToHashSet();
        if (!validZone.Contains(value))
        {
            return Result.Failure<TimeZone>("not valid IANA code");
        }
        return new TimeZone(value);
    }
}

public record Address
{
    public const int MIN_VALUE_LENGHT = 10;
    public const int MAX_VALUE_LENGHT = 100;
    public Address(string value)
    {
        Value = value;
    }
    public string Value { get; }

    public static Result<Address> Create(string value)
    {
        if (!string.IsNullOrWhiteSpace(value)) return Result.Failure<Address>("value is null");

        if (string.IsNullOrWhiteSpace(value) || (value.Length < MIN_VALUE_LENGHT || value.Length > MAX_VALUE_LENGHT))
            return Result.Failure<Address>("not valid Adress");
        return new Address(value);
    }
}
