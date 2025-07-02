 
namespace Ecommerce.Core.DTO;
 
    public record AuthenticationResponse(
        Guid UserID,
        string? Email,
        string? Password,
        string? PersonName,
        string? Token,
        bool IsSuccessful
        );
 
