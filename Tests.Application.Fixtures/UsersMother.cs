﻿using Application.Users.Commands.CreateUser;

namespace Tests.Application.Fixtures;

public class UsersMother
{
    public static CreateUserCommand MakeCreateUserCommand(string? email = null, string? password = null)
    {
        return new CreateUserCommand(
            email ?? "user@domain.example",
            password ?? "P4ssw0rd");
    }
}
