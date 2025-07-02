

using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;
using Ecommerce.Core.RepositoryContracts;

namespace Ecommerce.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserID = Guid.NewGuid();

            return user;

        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            return new ApplicationUser()
            {UserID = Guid.NewGuid(),Email = email , Password = password , PersonName ="Person Name" , Gender = GenderOption.Other.ToString() };
        }
    }
}
