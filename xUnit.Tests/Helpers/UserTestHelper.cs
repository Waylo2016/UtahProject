using Utah_Project_API.Models;
using System.Collections.Generic;

namespace xUnit.Tests.Helpers;

public static class UserTestHelper
{
    public static List<User> GetFakeUsers()
    {
        return
        [
            new User { Id = "user-1", UserName = "testuser1", Email = "user1@example.com", RegistrationDate = DateTime.UtcNow },
            new User { Id = "user-2", UserName = "testuser2", Email = "user2@example.com", RegistrationDate = DateTime.UtcNow }
        ];
    }
}
