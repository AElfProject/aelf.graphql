using GraphQL;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;

namespace AElf.GraphQl;

public interface IGraphQLHelper
{
    Task<T> QueryAsync<T>(GraphQLRequest request);
}