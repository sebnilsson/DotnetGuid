namespace DotnetGuid;

public class GuidGenerator(GuidCommandSettings settings)
{
    private readonly Func<Guid> _guidFactory = GuidFactoryResolver.Create(settings);

    private readonly GuidFormatter _guidFormatter = GuidFormatterResolver.GetFormatter(settings);

    public IEnumerable<string> GenerateGuids()
    {
        for (var i = 0; i < settings.Count; i++)
        {
            yield return GetGuid();
        }
    }

    private string GetGuid()
    {
        var guid = _guidFactory();

        var formattedGuid = GetFormattedGuid(guid);

        var casedGuid = GetCasedGuid(formattedGuid);

        return casedGuid;
    }

    private string GetFormattedGuid(Guid guid)
    {
        return _guidFormatter.GetResult(guid);
    }

    private string GetCasedGuid(string formattedGuid)
    {
        var modifiedGuid = formattedGuid;

        if (_guidFormatter.CanBeCased && settings.LowerCase)
        {
            modifiedGuid = modifiedGuid.ToLowerInvariant();
        }
        if (_guidFormatter.CanBeCased && settings.UpperCase)
        {
            modifiedGuid = modifiedGuid.ToUpperInvariant();
        }

        return modifiedGuid;
    }
}
