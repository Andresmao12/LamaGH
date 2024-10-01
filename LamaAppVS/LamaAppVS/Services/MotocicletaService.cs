using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using LamaAppVS.Models;

public class MotocicletaService
{
    private readonly HttpClient _httpClient;

    public MotocicletaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Motocicleta>> GetMotocicletasAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Motocicleta>>("api/Motocicleta");
    }

    public async Task<Motocicleta> GetMotocicletaByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Motocicleta>($"api/Motocicleta/{id}");
    }

    public async Task<HttpResponseMessage> CreateMotocicletaAsync(Motocicleta motocicleta)
    {
        return await _httpClient.PostAsJsonAsync("api/Motocicleta", motocicleta);
    }

    public async Task<HttpResponseMessage> UpdateMotocicletaAsync(int id, Motocicleta motocicleta)
    {
        return await _httpClient.PutAsJsonAsync($"api/Motocicleta/{id}", motocicleta);
    }

    public async Task<HttpResponseMessage> DeleteMotocicletaAsync(int id)
    {
        return await _httpClient.DeleteAsync($"api/Motocicleta/{id}");
    }
}
