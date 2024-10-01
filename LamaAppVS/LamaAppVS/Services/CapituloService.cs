using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using LamaAppVS.Models;

public class CapituloService
{
    private readonly HttpClient _httpClient;

    public CapituloService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Capitulo>> GetCapitulosAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Capitulo>>("api/Capitulo");
    }

    public async Task<Capitulo> GetCapituloByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Capitulo>($"api/Capitulo/{id}");
    }

    public async Task<HttpResponseMessage> CreateCapituloAsync(Capitulo capitulo)
    {
        return await _httpClient.PostAsJsonAsync("api/Capitulo", capitulo);
    }

    public async Task<HttpResponseMessage> UpdateCapituloAsync(int id, Capitulo capitulo)
    {
        return await _httpClient.PutAsJsonAsync($"api/Capitulo/{id}", capitulo);
    }

    public async Task<HttpResponseMessage> DeleteCapituloAsync(int id)
    {
        return await _httpClient.DeleteAsync($"api/Capitulo/{id}");
    }
}
