using Application.Users.Commands.CreateUser;
using Domain.Users;
using Moq;
using SharedKernel.Responses;

namespace Application.Tests.Unit.Users.Commands.CreateUser;

public class CreateUserCommandHandlerTest
{
    private readonly Mock<IUserRepository> _userRepository;
    private readonly CreateUserCommandHandler _handler;

    public CreateUserCommandHandlerTest()
    {
        _userRepository = new Mock<IUserRepository>();
        _handler = new CreateUserCommandHandler(
            Domain.Tests.Fixtures.UsersMother.MakePasswordHasher(),
            _userRepository.Object);
    }

    [Theory]
    [ClassData(typeof(CreateUserCommandHandlerHandleValidData))]
    public async Task Handle_Should_ReturnGuid(CreateUserCommand command)
    {
        var tokenSource = new CancellationTokenSource();
        var result = await _handler.Handle(command, tokenSource.Token);

        Assert.IsType<ResourceCreatedResponse>(result);
        Assert.True(Guid.TryParse(result.Id, out Guid guid));
        _userRepository.Verify(mock => mock.AddAsync(It.IsAny<User>(), tokenSource.Token), Times.Once);
    }
}

public class CreateUserCommandHandlerHandleValidData : TheoryData<CreateUserCommand>
{
    public CreateUserCommandHandlerHandleValidData()
    {
        Add(Fixtures.UsersMother.MakeCreateUserCommand());
    }
}
