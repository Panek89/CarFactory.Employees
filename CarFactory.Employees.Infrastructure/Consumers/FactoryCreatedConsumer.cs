using CarFactory.Employees.Contracts.Events;
using CarFactory.Employees.Domain.Entities;
using CarFactory.Employees.Domain.ExtensionMethods;
using CarFactory.Employees.Domain.Repositories;
using MassTransit;

namespace CarFactory.Employees.Infrastructure.Consumers;

public class FactoryCreatedConsumer : IConsumer<IFactoryCreated>
{
    private readonly IFactoryRepository _factoryRepository;

    public FactoryCreatedConsumer(IFactoryRepository factoryRepository)
    {
        _factoryRepository = factoryRepository ?? throw new ArgumentNullException(nameof(factoryRepository));
    }

    public async Task Consume(ConsumeContext<IFactoryCreated> context)
    {
        var message = context.Message;
        var factory = new Factory()
        {
            FactoryId = message.Id,
            Name = message.Name,
        }.SetInitialMetaData();

        await _factoryRepository.AddAsync(factory, context.CancellationToken);
        await _factoryRepository.SaveChangesAsync(context.CancellationToken);

        Console.WriteLine($"New Fabric created: {message.Name} with number of employees: {message.NumberOfEmployees}");
    }
}
