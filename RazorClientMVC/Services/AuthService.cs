using Hanssens.Net;
using RazorClientMVC.Models;

namespace RazorClientMVC.Services;

public class AuthService
{
    private readonly ApiService<User> Api;
    public AuthService(ApiService<User> api)
    {
        Api = api;
    }
    LocalStorage localStorage = new LocalStorage();
    public async Task<bool> Login(User user)
    {        
        var userList = await Api.GetAll(u => u.Name == user.Name);
        string token;
        if (userList.Any<User>())
        {
            var loggedUser = userList[0];
            token = loggedUser.Token;
            localStorage.Store<string>("token", token);
            return true;
        }
        return false;
    }
    public void Logout()
    {
        localStorage.Remove("token");
    }
    public void Register()
    {

    }
}