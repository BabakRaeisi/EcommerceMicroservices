using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;
using Ecommerce.Core.RepositoryContracts;
using Ecommerce.Core.ServiceContracts;

namespace Ecommerce.Core.Services;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository; 
    }
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
         ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
        if (user == null) return null;
        return new AuthenticationResponse(
        user.UserID, user.Email, user.Password, user.PersonName, "success",IsSuccessful:true);

    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        ApplicationUser? user = new ApplicationUser
        {
            PersonName = registerRequest.PersonName,
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            Gender = registerRequest.Gender.ToString()
        };
        ApplicationUser? registeredUser = await
        _userRepository.AddUser(user);
        
        if (registeredUser == null) return null;
        
        return new AuthenticationResponse(
            registeredUser.UserID,
            registeredUser.Email,
            registeredUser.Password,
            registeredUser.PersonName,
            "success",
            IsSuccessful: true);


    }
    
}
 