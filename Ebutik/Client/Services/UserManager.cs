using Blazored.LocalStorage;

namespace BlazorEcom.Client.Services;

public class UserManager : IUserManager
{
    private readonly HttpClient _httpClient;
    //private readonly ILocalStorageService _localStorage;
    private readonly NavigationManager _navigationManager;
    //private readonly AuthenticationStateProvider _authProvider;

    public UserManager(HttpClient httpClient, NavigationManager navigationManager
        )
    {
        _httpClient = httpClient;
        //_localStorage = localStorage;
        _navigationManager = navigationManager;
        //_authProvider = authProvider;
    }

    public async Task<string> RegisterUser(RegisterModel user)
    {
        var result = await _httpClient.PostAsJsonAsync("api/user/register", user);
        if (result.IsSuccessStatusCode)
        {
            return await result.Content.ReadAsStringAsync();
        }
        Console.WriteLine($"UserCreation Failed: {result.StatusCode}");
        return null;
    }

    public async Task<string> LoginUser(LoginModel user)
    {
        var result = await _httpClient.PostAsJsonAsync("api/user/login", user);
        if (result.IsSuccessStatusCode)
        {
            return await result.Content.ReadAsStringAsync();
        }

        return null;
    }

    public async Task<LoginModel> GetUser(LoginModel user)
    {
        var result = await _httpClient.GetFromJsonAsync("api/user/", user);
        if(result.IsSuccessStatusCode)
        {
            return result;
        }
        return null;
    }
}

public interface IUserManager
{
    Task<string> RegisterUser(RegisterModel user);
    Task<string> LoginUser(LoginModel user);
}