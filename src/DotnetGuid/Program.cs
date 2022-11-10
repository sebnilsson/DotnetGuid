using System;
using Spectre.Console.Cli;

namespace DotnetGuid
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Console.CancelKeyPress += OnCancelKeyPress;

            var app = new CommandApp<GuidCommand>();
            app.Configure(config =>
            {
                config.SetApplicationName("dotnet-guid");

                config.AddExample(new[] { "5", "-f", "N" });
                config.AddExample(new[] { "-f", "X", "-u" });
                config.AddExample(new[] { "-f", "B64" });
                config.AddExample(new[] { "-e" });

                config.ValidateExamples();
            });

            return app.Run(args);
        }

        private static void OnCancelKeyPress(
            object? sender,
            ConsoleCancelEventArgs e)
        {
            Console.ResetColor();
        }
    }
}
