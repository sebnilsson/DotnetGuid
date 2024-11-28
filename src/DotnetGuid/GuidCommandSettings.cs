using System.ComponentModel;
using Spectre.Console.Cli;

namespace DotnetGuid;

public class GuidCommandSettings : CommandSettings
{
    [Description(DescriptionTexts.Count)]
    [DefaultValue(1)]
    [CommandArgument(0, "[count]")]
    public int Count { get; init; } = 1;

    [Description(DescriptionTexts.Empty)]
    [CommandOption("-e|--empty")]
    public bool Empty { get; init; }

    [Description(DescriptionTexts.LowerCase)]
    [CommandOption("-l|--lowercase")]
    public bool LowerCase { get; init; }

    [Description(DescriptionTexts.Parse)]
    [CommandOption("-p|--parse")]
    public string Parse { get; init; } = string.Empty;

    [Description(DescriptionTexts.UpperCase)]
    [CommandOption("-u|--uppercase")]
    public bool UpperCase { get; init; }

#if NET9_0_OR_GREATER
    [Description(DescriptionTexts.Version7)]
    [CommandOption("--v7")]
    public bool Version7 { get; init; }

    [Description(DescriptionTexts.Version7Timestamp)]
    [CommandOption("--v7-timestamp")]
    public string Version7Timestamp { get; init; } = string.Empty;
#endif

    [Description(DescriptionTexts.Format)]
    [CommandOption("-f|--format")]
    public GuidFormat? Format { get; init; }

    public enum GuidFormat
    {
        B64,
        B64F,
        N,
        H,
        HB,
        HP,
        X
    }
}
