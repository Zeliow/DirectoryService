namespace DirectoryService.Domain;

public class Location
{
    private Location() { }

    public Location(string name, string adress, string timeZone)
    {
        Id = Guid.NewGuid();
        if (string.IsNullOrWhiteSpace(Name) || (name.Length < 3 || name.Length > 120)) throw new ArgumentException("");
        else Name = name;
        Adress = adress;
        TimeZone = timeZone;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Adress { get; private set; }
    public string TimeZone { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public List<Department> Departments { get; private set; } = new List<Department>();
}
