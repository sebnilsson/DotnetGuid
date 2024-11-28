namespace DotnetGuid;

internal static class GuidFormatterResolver
{
    public static GuidFormatter GetFormatter(GuidCommandSettings settings)
    {
        return settings switch
        {
            { Format: GuidCommandSettings.GuidFormat.B64 } => GuidFormatter.CreateForBase64(trim: true),
            { Format: GuidCommandSettings.GuidFormat.B64F } => GuidFormatter.CreateForBase64(trim: false),
            { Format: GuidCommandSettings.GuidFormat.N } => GuidFormatter.CreateForToString("N"),
            { Format: GuidCommandSettings.GuidFormat.H } => GuidFormatter.CreateForToString("D"),
            { Format: GuidCommandSettings.GuidFormat.HB } => GuidFormatter.CreateForToString("B"),
            { Format: GuidCommandSettings.GuidFormat.HP } => GuidFormatter.CreateForToString("P"),
            { Format: GuidCommandSettings.GuidFormat.X } => GuidFormatter.CreateForToString("X"),
            _ => GuidFormatter.CreateDefault()
        };
    }
}
