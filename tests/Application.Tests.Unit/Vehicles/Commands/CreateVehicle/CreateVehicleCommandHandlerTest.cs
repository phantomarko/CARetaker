﻿using Application.Tests.Fixtures;
using Application.Vehicles.Commands.CreateVehicle;
using Domain.Vehicles;
using Moq;
using SharedKernel.Responses;

namespace Application.Tests.Unit.Vehicles.Commands.CreateVehicle;

public class CreateVehicleCommandHandlerTest : AuthenticatedHandlerTestCase
{
    private readonly Mock<IVehicleRepository> _vehicleRepository;
    private readonly CreateVehicleCommandHandler _handler;
    private readonly CancellationToken _cancellationToken;

    public CreateVehicleCommandHandlerTest()
    {
        _vehicleRepository = new Mock<IVehicleRepository>();
        _handler = new CreateVehicleCommandHandler(
            _identityProvider.Object,
            _vehicleRepository.Object);
        _cancellationToken = new CancellationTokenSource().Token;
    }

    [Theory]
    [ClassData(typeof(CreateVehicleCommandHandlerHandleValidData))]
    public async Task Handle_Should_ReturnGuid(CreateVehicleCommand command)
    {
        UserIsAuthenticated();
        VehicleWillBePersisted();

        var result = await _handler.Handle(command, _cancellationToken);

        Assert.IsType<ResourceCreatedResponse>(result);
        Assert.True(Guid.TryParse(result.Id, out Guid guid));
        _identityProvider.VerifyAll();
        _vehicleRepository.VerifyAll();
    }

    private void VehicleWillBePersisted()
    {
        _vehicleRepository.Setup(mock => mock.AddAsync(It.IsAny<Vehicle>(), _cancellationToken));
    }
}

public class CreateVehicleCommandHandlerHandleValidData : TheoryData<CreateVehicleCommand>
{
    public CreateVehicleCommandHandlerHandleValidData()
    {
        Add(VehiclesMother.MakeCreateVehicleCommand());
    }
}
