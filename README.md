# ScrutorMediator

ScrutorMediator is a lightweight alternative to MediatR, providing CQRS pattern support
using Scrutor for automatic handler registration.

## Installation

```bash
dotnet add package Jaroszek.CoderHouse.ScrutorMediator
```

## Usage

1. Register ScrutorMediator in your DI container:

```csharp
// Program.cs or Startup.cs
services.AddScrutorMediator(
    // Optional: Change lifetime (default is Scoped)
    ServiceLifetime.Scoped,
    // Provide assemblies to scan for handlers
    typeof(YourCommand).Assembly
);
```

2. Create commands and queries:

```csharp
// Command (request without result)
public record CreateUserCommand(string Name, string Email) : ICommand;

// Command handler
public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
{
    public async Task HandleAsync(CreateUserCommand command, CancellationToken cancellationToken = default)
    {
        // Implementation
    }
}

// Query (request with result)
public record GetUserQuery(int Id) : IQuery<UserDto>;

// Query handler
public class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserDto>
{
    public async Task<UserDto> HandleAsync(GetUserQuery query, CancellationToken cancellationToken = default)
    {
        // Implementation
        return new UserDto();
    }
}
```

3. Inject and use the mediator:

```csharp
public class UserService
{
    private readonly IMediator _mediator;

    public UserService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task CreateUser(string name, string email)
    {
        await _mediator.SendAsync(new CreateUserCommand(name, email));
    }

    public async Task<UserDto> GetUser(int id)
    {
        return await _mediator.SendAsync(new GetUserQuery(id));
    }
}
```

## Benefits Over MediatR

- Lightweight: fewer dependencies
- Simplified API: just what you need
- Full control: extend as you need
- Better performance: optimized for your use case

## License

MIT
