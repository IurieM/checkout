using Identity.Data.Entities;
using System.Collections.Generic;

namespace Identity.Data.Seed
{
    public class IdentitySeed
    {
        public static IEnumerable<User> Users => new List<User>()
        {
            new User()
            {
              Username = "Bob",
              Password = "Bob"
            },
            new User()
            {
              Username = "Ana",
              Password = "Ana"
            }
        };
    }
}
