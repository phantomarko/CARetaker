using Domain.Abstractions;
using Domain.Vehicles;
using MediatR;

namespace Application.Vehicles.Command.CreateCar;

public sealed class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Guid>
{
    private readonly IProductRepository _productRepository;

    public CreateCarCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<Guid> Handle(CreateCarCommand request, CancellationToken cancellationToken = default)
    {
        var car = Car.Create(
            id: Guid.NewGuid(),
            name: VehicleName.Create(request.Name),
            plate: CarPlate.Create(request.Plate));

        _productRepository.Add(car);

        return Task.FromResult(car.Id);
    }
}
