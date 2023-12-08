using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;

namespace Serilog.Sinks.SpeedConsole;

public static class SpeedConsoleSinkExtensions
{
    public static LoggerConfiguration SpeedConsole(
        this LoggerSinkConfiguration loggerConfiguration,
        SpeedConsoleSinkOptions? sinkOptions = null,
        string? outputTemplate = null,
        ITextFormatter? textFormatter = null,
        LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum,
        LoggingLevelSwitch? loggingLevelSwitch = null)
    {
        sinkOptions ??= new SpeedConsoleSinkOptions();

        // create text formatter if only output template is specified
        if (textFormatter == null && !string.IsNullOrWhiteSpace(outputTemplate))
            textFormatter = new MessageTemplateTextFormatter(outputTemplate!);

        var sink = new SpeedConsoleSink(sinkOptions, textFormatter);

        return loggerConfiguration.Sink(sink, restrictedToMinimumLevel, loggingLevelSwitch);
    }
}
