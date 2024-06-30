﻿using Application.Maintenances.Commands.CreateMaintenance;
using Application.Maintenances.Services;
using Domain.Maintenances;
using Domain.Maintenances.Proxies;
using Domain.Vehicles;
using Moq;
using SharedKernel.Responses;

namespace Application.Tests.Unit.Maintenances.Commands.CreateMaintenance;

public class CreateMaintenanceCommandHandlerTest : AuthenticatedHandlerTestCase
{
    private readonly Mock<IMaintenanceRepository> _maintenanceRepository;
    private readonly Mock<IVehicleRepository> _vehicleRepository;
    private readonly CreateMaintenanceCommandHandler _handler;
    private readonly CancellationToken _cancellationToken;

    public CreateMaintenanceCommandHandlerTest()
    {
        _maintenanceRepository = new Mock<IMaintenanceRepository>();
        _vehicleRepository = new Mock<IVehicleRepository>();
        _handler = new CreateMaintenanceCommandHandler(
            _identityProvider.Object,
            _maintenanceRepository.Object,
            new VehicleFinder(new VehicleRepositoryProxy(_vehicleRepository.Object)));
        _cancellationToken = new CancellationTokenSource().Token;
    }

    [Theory]
    [ClassData(typeof(CreateMaintenanceCommandData))]
    public async Task Handle_Should_ReturnGuid(CreateMaintenanceCommand command)
    {
        var vehicle = Domain.Tests.Fixtures.VehiclesMother.MakeVehicle(
            id: new Guid(command.VehicleId),
            userId: _userId);
        VehicleExists(vehicle);
        UserIsAuthenticated(_userId);
        MaintenanceWillBePersisted();

        var result = await _handler.Handle(command, _cancellationToken);

        Assert.IsType<ResourceCreatedResponse>(result);
        Assert.True(Guid.TryParse(result.Id, out Guid guid));
        _identityProvider.VerifyAll();
        _maintenanceRepository.VerifyAll();
        _vehicleRepository.VerifyAll();
    }

    private void MaintenanceWillBePersisted()
    {
        _maintenanceRepository.Setup(mock => mock.AddAsync(
            It.IsAny<Maintenance>(),
            _cancellationToken));
    }

    private void VehicleExists(Vehicle vehicle)
    {
        _vehicleRepository.Setup(mock => mock.FindById(vehicle.Id))
            .Returns(vehicle);
    }

    public static CreateMaintenanceCommand MakeCommand(
        string? vehicleId = null,
        string? description = null)
    {
        return Fixtures.MaintenancesMother.MakeCreateMaintenanceCommand(
            vehicleId: vehicleId,
            description: description);
    }
}

public class CreateMaintenanceCommandData : TheoryData<CreateMaintenanceCommand>
{
    public CreateMaintenanceCommandData()
    {
        Add(CreateMaintenanceCommandHandlerTest.MakeCommand());
        Add(CreateMaintenanceCommandHandlerTest.MakeCommand(description: "This is a description"));
    }
}
