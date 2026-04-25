using System;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace DotnetGuid;

public static class Instrumentation
{
    private static TracerProvider? tracerProvider;

    public static void RegisterOpenTelemetry()
    {
        var serviceName = "DotnetGuid";
        var orgId = Environment.GetEnvironmentVariable("AIENT_ORG_ID") ?? "57b0ff8b-15a4-4fb6-af4f-e36a5e636097";
        var publishable = Environment.GetEnvironmentVariable("AIENT_PUBLISHABLE_KEY") ?? "pk_live_db7c2339aa8948e5b9f2882703d91960";

        // Minimal OTEL setup: console exporter and resource service name.
        tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource(serviceName)
            .SetResourceBuilder(
                OpenTelemetry.Resources.ResourceBuilder.CreateDefault()
                    .AddService(serviceName))
            .AddConsoleExporter() // keep simple; external Aient OTLP exporter can be added by user
            .Build();

        // Note: Aient-specific .NET SDK is not available in repo. We provide env vars for Aient.
        Console.WriteLine($"OpenTelemetry initialized for {serviceName} (org={orgId})");
    }

    public static void Shutdown()
    {
        tracerProvider?.Dispose();
        tracerProvider = null;
    }
}
