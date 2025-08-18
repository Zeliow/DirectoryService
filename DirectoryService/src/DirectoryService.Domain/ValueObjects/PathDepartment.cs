using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace DirectoryService.Domain.VO;

public record PathDepartment
{
    public string Value { get; }

    public PathDepartment(string value)
    {
        Value = value;
    }
    
    public static Result<PathDepartment> Create(string value)
    {
        if (!Regex.IsMatch(value, @"^(?=.*[A-Za-z])[A-Za-z.-]+$")) return Result.Failure<PathDepartment>("not valid Path department");

        return new PathDepartment(value);
    }

}
