using Book.Models.Requests;

namespace Book.Blazor.IServices
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task Logout();
    }
}
