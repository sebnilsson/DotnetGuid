namespace DotnetGuid.Tests;

public class GuidGeneratorTest
{
    private const string s_emptyGuid = "00000000-0000-0000-0000-000000000000";
    private const string s_sampleGuid = "12345678-abcd-1234-abcd-123456789012";

    [Fact]
    public void GenerateGuids_WithEmpty_ReturnsEmptyGuid()
    {
        // Arrange
        var settings = new GuidCommandSettings { Empty = true };
        var generator = new GuidGenerator(settings);

        // Act
        var guid = generator.GenerateGuids().First();

        // Assert
        Assert.Equal(s_emptyGuid, guid);
    }

    [Fact]
    public void GenerateGuids_WithUpperCase_ReturnsUpperCaseGuid()
    {
        // Arrange
        var settings = new GuidCommandSettings { UpperCase = true, Parse = s_sampleGuid };
        var generator = new GuidGenerator(settings);

        // Act
        var guid = generator.GenerateGuids().First();

        // Assert
        Assert.Equal(s_sampleGuid.ToUpperInvariant(), guid);
    }

    [Fact]
    public void GenerateGuids_WithLowerCase_ReturnsLowerCaseGuid()
    {
        // Arrange
        var settings = new GuidCommandSettings { LowerCase = true, Parse = s_sampleGuid };
        var generator = new GuidGenerator(settings);

        // Act
        var guid = generator.GenerateGuids().First();

        // Assert
        Assert.Equal(s_sampleGuid.ToLowerInvariant(), guid);
    }

    [Fact]
    public void GenerateGuids_WithCount5_Returns5Guids()
    {
        // Arrange
        var settings = new GuidCommandSettings { Count = 5 };
        var generator = new GuidGenerator(settings);

        // Act
        var guids = generator.GenerateGuids();

        // Assert
        Assert.Equal(5, guids.Count());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Validate_WithInvalidCount_ReturnsError(int count)
    {
        // Arrange
        var settings = new GuidCommandSettings { Count = count };

        // Act
        var result = settings.Validate();

        // Assert
        Assert.False(result.Successful);
        Assert.Equal("Count must be greater than zero.", result.Message);
    }

    [Fact]
    public void Validate_WithInvalidParse_ReturnsError()
    {
        // Arrange
        var settings = new GuidCommandSettings { Parse = "not-a-guid" };

        // Act
        var result = settings.Validate();

        // Assert
        Assert.False(result.Successful);
        Assert.Equal("Parse must be a valid GUID/UUID string.", result.Message);
    }

    [Fact]
    public void Validate_WithUpperCaseAndLowerCase_ReturnsError()
    {
        // Arrange
        var settings = new GuidCommandSettings { LowerCase = true, UpperCase = true };

        // Act
        var result = settings.Validate();

        // Assert
        Assert.False(result.Successful);
        Assert.Equal("Lowercase and uppercase cannot be used together.", result.Message);
    }

    [Fact]
    public void Validate_WithEmptyAndParse_ReturnsError()
    {
        // Arrange
        var settings = new GuidCommandSettings { Empty = true, Parse = s_sampleGuid };

        // Act
        var result = settings.Validate();

        // Assert
        Assert.False(result.Successful);
#if NET9_0_OR_GREATER
        Assert.Equal("Use only one GUID source option: empty, parse, or v7.", result.Message);
#else
        Assert.Equal("Use only one GUID source option: empty or parse.", result.Message);
#endif
    }

    [Theory]
    [InlineData(GuidCommandSettings.GuidFormat.B64, "eFY0Es2rNBKrzRI0VniQEg")]
    [InlineData(GuidCommandSettings.GuidFormat.B64F, "eFY0Es2rNBKrzRI0VniQEg==")]
    [InlineData(GuidCommandSettings.GuidFormat.N, "12345678abcd1234abcd123456789012")]
    [InlineData(GuidCommandSettings.GuidFormat.H, "12345678-abcd-1234-abcd-123456789012")]
    [InlineData(GuidCommandSettings.GuidFormat.HB, "{12345678-abcd-1234-abcd-123456789012}")]
    [InlineData(GuidCommandSettings.GuidFormat.HP, "(12345678-abcd-1234-abcd-123456789012)")]
    [InlineData(GuidCommandSettings.GuidFormat.X, "{0x12345678,0xabcd,0x1234,{0xab,0xcd,0x12,0x34,0x56,0x78,0x90,0x12}}")]
    public void GenerateGuids_WithFormatting_ReturnsFormattedGuid(GuidCommandSettings.GuidFormat format, string expect)
    {
        // Arrange
        var settings = new GuidCommandSettings { Parse = s_sampleGuid, Format = format };
        var generator = new GuidGenerator(settings);

        // Act
        var guid = generator.GenerateGuids().First();

        // Assert
        Assert.Equal(expect, guid);
    }

#if NET9_0_OR_GREATER
    [Fact]
    public void GenerateGuids_WithVersion7_ReturnsVersion7Guid()
    {
        // Arrange
        var settings = new GuidCommandSettings { Version7 = true };
        var generator = new GuidGenerator(settings);

        // Act
        var guidValue = generator.GenerateGuids().First();
        var guid = new Guid(guidValue);

        // Assert
        Assert.Equal(7, guid.Version);
    }

    [Fact]
    public void Validate_WithVersion7TimestampWithoutVersion7_ReturnsError()
    {
        // Arrange
        var settings = new GuidCommandSettings { Version7Timestamp = "2024-01-01T00:00:00Z" };

        // Act
        var result = settings.Validate();

        // Assert
        Assert.False(result.Successful);
        Assert.Equal("The v7 timestamp option requires v7.", result.Message);
    }

    [Fact]
    public void Validate_WithInvalidVersion7Timestamp_ReturnsError()
    {
        // Arrange
        var settings = new GuidCommandSettings { Version7 = true, Version7Timestamp = "not-a-timestamp" };

        // Act
        var result = settings.Validate();

        // Assert
        Assert.False(result.Successful);
        Assert.Equal("The v7 timestamp must be a valid timestamp.", result.Message);
    }
#endif
}
