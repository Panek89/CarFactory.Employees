using System;
using CarFactory.Employees.Contracts.Events;
using CarFactory.Employees.Domain.Repositories;
using MassTransit;

namespace CarFactory.Employees.Infrastructure.Consumers;

public class FactoryUpdatedConsumer : IConsumer<IFactoryUpdated>
{
  private readonly IFactoryRepository _factoryRepository;
  
  public FactoryUpdatedConsumer(IFactoryRepository factoryRepository)
  {
    _factoryRepository = factoryRepository ?? throw new ArgumentNullException(nameof(factoryRepository));
  }

  public async Task Consume(ConsumeContext<IFactoryUpdated> context)
  {
    var message = context.Message;
    var factory = await _factoryRepository.GetByFactoryIdAsync(message.Id, context.CancellationToken);

    if (factory is not null)
    {
      factory.Name = message.Name;
      factory.IsOpen = message.IsOpen;
      factory.UpdatedBy = "CarFactory_Factories";
      factory.UpdatedAt = DateTime.UtcNow;

      await _factoryRepository.SaveChangesAsync(context.CancellationToken);

      Console.WriteLine($"Factory updated with name: {message.Name} and open status: {message.IsOpen}");
    }
    else
    {
      Console.WriteLine($"Factory with ID: {message.Id} is not found");
    }
  }
}
