namespace Stores.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(int Id,String RoleName);
    }
}
