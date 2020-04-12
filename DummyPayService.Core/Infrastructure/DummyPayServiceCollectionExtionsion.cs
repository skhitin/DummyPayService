using DummyPayService.BankEmitentClient;
using DummyPayService.Core.CommandHandlers;
using DummyPayService.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DummyPayService.Core.Infrastructure
{
    public static class DummyPayServiceCollectionExtionsion
    {
        public static IServiceCollection AddDummyPayServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IBankEmitentClient, FakeBankEmitentClient>();

            serviceCollection.AddMediatR(typeof(CreatePaymentCommandHandler).Assembly);

            return serviceCollection;
        }
    }
}
