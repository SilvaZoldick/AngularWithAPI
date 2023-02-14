using System.Linq.Expressions;
using System.Text;
using Newtonsoft.Json;

namespace RazorClientMVC.Services;

public class ApiService<T> where T : class
{
    private string ApiSource = "http:localhost:5021/";
    private HttpClient client {get; set;}

    public ApiService()
    {
        client = new HttpClient();
        ApiSource += nameof(T);
    }    
    public async Task Create(T model)
    {   var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
        var response = await client.PostAsync(ApiSource, content);
    }
    public async Task<List<T>> GetAll(Expression<Func<T, bool>>? predicate = null)
    {
        var request = client.GetAsync(ApiSource);
        var responseContent =  await request.Result.Content.ReadFromJsonAsync<List<T>>();
        if (responseContent is not null)
            return responseContent;
        else    
            return new List<T>();
    }
    public async Task<T?> Get(int id)
    {
        var request = client.GetAsync(ApiSource + id);
        return await request.Result.Content.ReadFromJsonAsync<T>();
    }    
    public async Task Update(T model)
    {
        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
        await client.PutAsync(ApiSource, content);
    }
    public async Task Delete(int id)
    {
        await client.DeleteAsync(ApiSource + id);
    }
}