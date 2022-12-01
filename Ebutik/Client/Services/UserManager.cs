using Blazored.LocalStorage;
using System.Net.Http.Json;

namespace BlazorEcom.Client.Services;

public class UserManager : IUserManager
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    private readonly NavigationManager _navigationManager;
    //private readonly AuthenticationStateProvider _authProvider;

    public UserManager(HttpClient httpClient, NavigationManager navigationManager, ILocalStorageService localStorage
        )
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
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

    public async Task<ApplicationUser> GetUser(string userId)
    {
        var result = await _httpClient.GetFromJsonAsync<ApplicationUser>($"api/user/getuser/{userId}");
            return result;
    }
    public async Task<ApplicationUser> GetCurrentUser()
    {
        return await _httpClient.GetFromJsonAsync<ApplicationUser>($"api/user/getcurrent");
    }
    public async Task<List<ApplicationUser>> GetAllUsers()
    {
        return await _httpClient.GetFromJsonAsync<List<ApplicationUser>>($"api/user/getall");
    }
    public async Task StoreUser(string id)
    {
        if (!String.IsNullOrEmpty(id))
        {
            await _localStorage.SetItemAsStringAsync("user", $"{id}");
        }
    }
}

public interface IUserManager
{
    Task<string> RegisterUser(RegisterModel user);
    Task<string> LoginUser(LoginModel user);
    Task<ApplicationUser> GetCurrentUser();
    Task<ApplicationUser> GetUser(string userId);
}