namespace SampleCQRService.Infrastructure.Repositories;

public interface ICommandRepository
{
    IUnitOfWork UnitOfWork { get; }
}
