namespace DotnetGuid;

public class GuidGenerator
{
    private static readonly Func<Guid> s_newGuidFactory = () => Guid.NewGuid();

    private static readonly Func<Guid> s_emptyGuidFactory = () => Guid.Empty;

    private readonly GuidCommand.Settings _settings;

    private readonly Func<Guid> _guidFactory;

    private readonly GuidFormatter _guidFormatter;

    public GuidGenerator(GuidCommand.Settings settings)
    {
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));

        _guidFactory = !settings.Empty ? s_newGuidFactory : s_emptyGuidFactory;
        _guidFormatter = GuidFormatterResolver.GetFormatter(settings);
    }

    public IEnumerable<string> GenerateGuids()
    {
        for (var i = 0; i < _settings.Count; i++)
        {
            yield return GetGuid();
        }
    }

    private string GetGuid()
    {
        var guid = _guidFactory();

        var formattedGuid = GetFormattedGuid(guid);

        var modifiedGuid = GetModifiedGuid(formattedGuid);

        return modifiedGuid;
    }

    private string GetFormattedGuid(Guid guid)
    {
        return _guidFormatter.GetResult(guid);
    }

    private string GetModifiedGuid(string formattedGuid)
    {
        var modifiedGuid = formattedGuid;

        if (_guidFormatter.CanBeCased && _settings.LowerCase)
        {
            modifiedGuid = modifiedGuid.ToLowerInvariant();
        }
        if (_guidFormatter.CanBeCased && _settings.UpperCase)
        {
            modifiedGuid = modifiedGuid.ToUpperInvariant();
        }

        return modifiedGuid;
    }
}
