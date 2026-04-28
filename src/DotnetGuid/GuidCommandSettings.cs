using System.ComponentModel;
using System.Globalization;
using Spectre.Console;
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

    [Description(DescriptionTexts.Version7)]
    [CommandOption("--v7")]
    public bool Version7 { get; init; }

    [Description(DescriptionTexts.Version7Timestamp)]
    [CommandOption("--v7-timestamp")]
    public string Version7Timestamp { get; init; } = string.Empty;

    [Description(DescriptionTexts.Format)]
    [CommandOption("-f|--format")]
    public GuidFormat? Format { get; init; }

    public override ValidationResult Validate()
    {
        if (Count < 1)
        {
            return ValidationResult.Error("Count must be greater than zero.");
        }

        if (LowerCase && UpperCase)
        {
            return ValidationResult.Error("Lowercase and uppercase cannot be used together.");
        }

        if (!string.IsNullOrWhiteSpace(Parse) && !Guid.TryParse(Parse, out _))
        {
            return ValidationResult.Error("Parse must be a valid GUID/UUID string.");
        }

        if (HasMultipleGuidSources())
        {
            return ValidationResult.Error("Use only one GUID source option: empty, parse, or v7.");
        }

        if (!Version7 && !string.IsNullOrWhiteSpace(Version7Timestamp))
        {
            return ValidationResult.Error("The v7 timestamp option requires v7.");
        }

        if (!string.IsNullOrWhiteSpace(Version7Timestamp)
            && !DateTimeOffset.TryParse(Version7Timestamp, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
        {
            return ValidationResult.Error("The v7 timestamp must be a valid timestamp.");
        }

        return ValidationResult.Success();
    }

    private bool HasMultipleGuidSources()
    {
        var sourceCount = 0;

        if (Empty)
        {
            sourceCount++;
        }

        if (!string.IsNullOrWhiteSpace(Parse))
        {
            sourceCount++;
        }

        if (Version7)
        {
            sourceCount++;
        }

        return sourceCount > 1;
    }

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
