using Spectre.Console;
using Spectre.Console.Cli;

namespace DotnetGuid;

public class Program
{
    public static int Main(string[] args)
    {
        // Initialize OpenTelemetry as early as possible
        try
        {
            Instrumentation.RegisterOpenTelemetry();
        }
        catch (Exception ex)
        {
            // Do not fail startup if telemetry fails
            Console.WriteLine($"Telemetry initialization failed: {ex.Message}");
        }
        Console.CancelKeyPress += OnCancelKeyPress;

        var app = new CommandApp<GuidCommand>();
        app.Configure(config =>
        {
            config.SetApplicationName("dotnet-guid");

            config.AddExample(["5", "-f", "N"]);
            config.AddExample(["-f", "X", "-u"]);
            config.AddExample(["-f", "B64"]);
            config.AddExample(["-e"]);
            config.AddExample(["--v7"]);

#if DEBUG
            config.PropagateExceptions();
            config.ValidateExamples();
#endif
        });

        try
        {
            return app.Run(args);
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
            return -99;
        }
    }

    private static void OnCancelKeyPress(
        object? sender,
        ConsoleCancelEventArgs e)
    {
        Console.ResetColor();
    }
}
