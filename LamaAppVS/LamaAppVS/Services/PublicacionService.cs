using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using LamaAppVS.Models;

public class PublicacionService
{
    private readonly HttpClient _httpClient;

    public PublicacionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Publicacion>> GetPublicacionesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Publicacion>>("api/Publicacion");
    }

    public async Task<Publicacion> GetPublicacionByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Publicacion>($"api/Publicacion/{id}");
    }

    public async Task<HttpResponseMessage> CreatePublicacionAsync(Publicacion publicacion)
    {
        return await _httpClient.PostAsJsonAsync("api/Publicacion", publicacion);
    }

    public async Task<HttpResponseMessage> UpdatePublicacionAsync(int id, Publicacion publicacion)
    {
        return await _httpClient.PutAsJsonAsync($"api/Publicacion/{id}", publicacion);
    }

    public async Task<HttpResponseMessage> DeletePublicacionAsync(int id)
    {
        return await _httpClient.DeleteAsync($"api/Publicacion/{id}");
    }
}
