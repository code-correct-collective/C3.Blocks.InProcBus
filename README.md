# Overview
[![Build](https://github.com/code-correct-collective/C3.Blocks.InProcBus/actions/workflows/main.yml/badge.svg)](https://github.com/code-correct-collective/C3.Blocks.InProcBus/actions/workflows/main.yml)
[![License](https://img.shields.io/badge/license-MIT-orange.svg)](https://github.com/code-correct-collective/C3.Blocks.InProcBus/blob/main/LICENSE)
[![Contributor Covenant](https://img.shields.io/badge/Contributor%20Covenant-2.1-4baaaa.svg)](https://github.com/code-correct-collective/C3.Blocks.InProcBus/blob/main/CODE_OF_CONDUCT.md)

A library wrapper around Mediatr to manage executing commands, queries and events.


## Commands

Commands are used to modify state in the system. As such, they do no return any values.

### A Command Object

We use `record` types as the foundation for our command objects that are used to pass data to command processors.

```csharp
public record CreateBlogCommand(
    string BlogName,
    string CorrelationId
) : DomainCommandBase(CorrelationId);
```

### A Command Processor

We use `class` types as the foundation for our command processors.

```csharp
public class CreateBlogCommandProcessor(
    IUnitOfWork uow,
    IDomainEventBus eventBus,
    ILogger<CreateBlogCommandProcessor> logger
) : DomainCommandProcessorBase<CreateBlogCommand>(logger)
{
    private readonly IUnitOfWork uow = uow;

    private readonly IDomainEventBus eventBus = eventBus;

    /// <inheritdoc/>
    public override async Task ProcessAsync(
        [NotNull] CreateBlogCommand command,
        CancellationToken cancellationToken
    )
    {
        ArgumentNullException.ThrowIfNull(command, nameof(command));

        Blog blog = new()
        {
            Name = command.BlogName
        };

        await this.uow.BlogRepository.AddAsync(blog, cancellationToken).ConfigureAwait(false);
        _ = await this.uow.CommitAsync(cancellationToken).ConfigureAwait(false);

        await this.eventBus.PublishAsync(
            cancellationToken,
            new BlogCreatedEvent(blog, command.CorrelationId)
        ).ConfigureAwait(false);
    }
}
```
## Events

Events are used to send notifications that the system should handle.

### An Event Object

Again we use `recrord` types to represent our event objects

```csharp
public record class BlogCreatedEvent(
    Blog Blog,
    string CorrelationId
) : DomainEventBase(CorrelationId);
```

#### An Event Processor

We use a `class` type to represent our event processors

```csharp
public class BlogCreatedEventProcessor(
    IUnitOfWork uow,
    ILogger<BlogCreatedEventProcessor> logger
) : DomainEventProcessorBase<BlogCreatedEvent>(logger)
{
    private readonly IUnitOfWork uow = uow;

    /// <inheritdoc/>
    public override async Task ProcessEventAsync(
        [NotNull] BlogCreatedEvent @event,
        CancellationToken cancellationToken
    )
    {
        ArgumentNullException.ThrowIfNull(@event, nameof(@event));

        await this.DoesSomeWork(@event);
    }

    private Task DoesSomeWork(BlogCreatedEvent @event)
    {
        // process the BlogCreatedEvent in some way.
    }
}
```
## Queries

Queries are used to fetch data from the system in a well defined way.

### A Query Object

```csharp
public record class GetBlogByNameQuery(
    string BlogName,
    string CorrelationId
) : DomainQueryBase<Blog?>(CorrelationId);
```

#### A Query Processor

Again we use a `class` for our query processor object.

Note that `DomainQueryProcessorBase<TQuery, TResult>` takes a typeparam for both the query object and
the expected return result of the query.

```csharp
public class GetBlogByNameQueryProcessor(
    IUnitOfWork uow,
    ILogger<GetBlogByNameQueryProcessor> logger
) : DomainQueryProcessorBase<GetBlogByNameQuery, Blog?>(logger)
{
    private IUnitOfWork uow = uow;

    /// <inheritdoc/>
    public override async Task<Blog?> ProcessQueryAsync(
        [NotNull] GetBlogByNameQuery query,
        CancellationToken cancellationToken
    )
    {
        ArgumentNullException.ThrowIfNull(query, nameof(query));
        return await this.uow.BlogRepository.FindByNameAsync(
            query.BlogName,
            cancellationToken).ConfigureAwait(false);
    }
}
```

## Registering the Events, Commands, and Queries with the system.

Perform the following registration code where you normally configure your application services, in `Program.cs` for example.

```csharp
// Register In-Proc Bus
services.AddInProcBus()
    .AddCommands()
    // Needs the command and related processor types.
    .AddCommand<CreateBlogCommand, CreateBlogCommandProcessor>()  
    .And()
    .AddEvents()
    // Needs the event and related processor types.
    .AddEvent<BlogCreatedEvent, BlogCreatedEventProcessor>() 
    .And()
    .AddQueries()
    // Needs, the query object, result type, and related processor
    .AddQuery<GetBlogByNameQuery, Blog?, GetBlogByNameQueryProcessor>();  
```