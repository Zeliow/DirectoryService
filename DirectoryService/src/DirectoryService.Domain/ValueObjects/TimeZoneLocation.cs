using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.VO;

public record TimeZoneLocation
{
    public string Value { get; }
    public TimeZoneLocation(string value)
    {
        Value = value;
    }
    

    public static Result<TimeZoneLocation> Create(string value)
    {
        if (!string.IsNullOrWhiteSpace(value)) return Result.Failure<TimeZoneLocation>("value is null");

        var validZone = TimeZoneInfo.GetSystemTimeZones().Select(tz => tz.Id).ToHashSet();
        if (!validZone.Contains(value))
        {
            return Result.Failure<TimeZoneLocation>("not valid IANA code");
        }
        return new TimeZoneLocation(value);
    }
}
