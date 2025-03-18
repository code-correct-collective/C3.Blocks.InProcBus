namespace C3.Blocks.InProcBus;

[ExcludeFromCodeCoverage]
static partial class LoggingMessages
{
    [LoggerMessage(
        Level = LogLevel.Debug,
        EventId = LoggingEvents.ExecutingCommand,
        Message = "Executing {@command}"
    )]
    public static partial void LogDebugExecutingCommand(this ILogger logger, IDomainCommand command);

    [LoggerMessage(
        Level = LogLevel.Debug,
        EventId = LoggingEvents.ProcessingCommand,
        Message = "Processing {@command}"
    )]
    public static partial void LogDebugProcessingCommand(this ILogger logger, IDomainCommand command);

    [LoggerMessage(
        Level = LogLevel.Debug,
        EventId = LoggingEvents.PublishingEvent,
        Message = "Publishing event {@event}"
    )]
    public static partial void LogDebugPublishingEvent(this ILogger logger, IDomainEvent @event);

    [LoggerMessage(
        Level = LogLevel.Debug,
        EventId = LoggingEvents.PublishingEvent,
        Message = "Processing event {@event}"
    )]
    public static partial void LogDebugProcessingEvent(this ILogger logger, IDomainEvent @event);

    [LoggerMessage(
        Level = LogLevel.Debug,
        EventId = LoggingEvents.PublishingEvent,
        Message = "Publishing {count} event/s"
    )]
    public static partial void LogDebugPublishingCountEvent(this ILogger logger, int count);

    [LoggerMessage(
        Level = LogLevel.Debug,
        EventId = LoggingEvents.ExecutingQuery,
        Message = "Executing query: {@query}"
    )]
    public static partial void LogDebugExecutingQuery(this ILogger logger, IDomainQuery query);

    [LoggerMessage(
        Level = LogLevel.Debug,
        EventId = LoggingEvents.ExecutingQuery,
        Message = "Processing query: {@query}"
    )]
    public static partial void LogDebugProcessingQuery(this ILogger logger, IDomainQuery query);
}
