namespace DirectoryService.Domain;

public class Position
{
    public Position(string name, string description)
    {
        Id = Guid.NewGuid();
        if (string.IsNullOrWhiteSpace(Name) || (name.Length < 3 || name.Length > 100)) throw new ArgumentException("");
        else Name = name;
        if (description.Length > 1000) throw new ArgumentException("");
        else Description = description;
        IsActive = true;
        CreateAt = DateTime.UtcNow;
        UpdateAt = DateTime.UtcNow;

    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set;}
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
}


