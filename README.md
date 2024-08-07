# AElf GraphQL

An GraphQL module for use in ABP and Orleans framework.

- [About The Project](#about-the-project)
- [Getting Started](#getting-started)
  - [Installation](#installation)
  - [Configuration](#configuration)
  - [Setup](#setup)
    - [Orleans](#orleans)
- [Examples](#examples)
- [Contributing](#contributing)
- [License](#license)

## About The Project

This project is a module for ABP and Orleans framework to use aelf graphql. It provides a simple and fast way to integrate aelf graphql in ABP and Orleans framework.

## Getting Started


### Configuration

To configure your aelf graphql service name and collector's endpoint, you need to add the following to your appsettings.json file:

```json
{
  "GraphQL": {
    "Configuration": "https://your-dapp-url/graphql"
  }
}
```

### Setup

Add the following dependency to your project's Module class:

```cs
using AElf.GraphQl;

[DependsOn(
    typeof(GraphQlModule)
)]

## Examples

Here are some examples of how to use this module.

```csharp
public class MessageValidatorGrain : Grain, IMessageValidator
{
    private readonly ILogger _logger;
    private readonly IGraphQLHelper _graphQlHelper;

    public MessageValidatorGrain(ILogger<MessageValidatorGrain> logger, IGraphQLHelper graphQlHelper)
    {
        _logger = logger;
        _graphQlHelper = graphQlHelper;
    }

    public async Task<string> GetTestGraphQlAsync(string input)
    {
        // This will start a custom trace for the IsOffensive method
        try
        {
            var res = await _graphQlHelper.QueryAsync<IndexerSymbols>(new GraphQLRequest
            {
                Query = "your graphql query",
                Variables = new
                {
                    input
                }
            });
            Logger.LogError("");
        }
        catch (Exception e)
        {
            Logger.LogError(e, Error.SendVerificationRequestErrorLogPrefix + e.Message);
            return "";
        }
        
        return Task.FromResult(OffensiveWords.Any(message.Contains));
    }
}
```

## Contributing

If you encounter a bug or have a feature request, please use the [Tracker](https://github.com/AElfProject/aelf.graphql). The project is also open to contributions, so feel free to fork the project and open pull requests.

## License

Distributed under the MIT License. See [License](LICENSE) for more information.
