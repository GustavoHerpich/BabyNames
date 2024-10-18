using BabyName.Entities;
using BabyName.Models.DTOs;
using BabyName.Models.Login;
using BabyName.Utils.ResultPattern;

namespace BabyName.Services;

public interface IAuthService
{
    Task<Result<User>> RegisterUser(UserModel user);
    Task<Result<TokenModel>> AuthenticateAsync(LoginRequest loginModel);
    Task<Result<string>> RecoverPassword(RecoverPasswordRequest recoverPassword);
}
