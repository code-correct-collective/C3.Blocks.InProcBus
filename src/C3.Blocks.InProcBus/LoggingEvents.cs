namespace C3.Blocks.InProcBus;

/// <summary>
/// Provides logging event IDs for the InProcBus.
/// </summary>
public static class LoggingEvents
{
    /// <summary>
    /// Event ID for executing a command.
    /// </summary>
    public const int ExecutingCommand = unchecked((int)0x60020001);

    /// <summary>
    /// Event ID for handling a command.
    /// </summary>
    public const int ProcessingCommand = unchecked((int)0x60020002);

    /// <summary>
    /// Event ID for processing an event.
    /// </summary>
    public const int PublishingEvent = unchecked((int)0x60020003);

    /// <summary>
    /// Event ID for processing an event.
    /// </summary>
    public const int ProcessingEvent = unchecked((int)0x60020004);

    /// <summary>
    /// Event ID for processing a query.
    /// </summary>
    public const int ExecutingQuery = unchecked((int)0x60020005);

    /// <summary>
    /// Event ID for processing a query.
    /// </summary>
    public const int ProcessingQuery = unchecked((int)0x60020006);
}
