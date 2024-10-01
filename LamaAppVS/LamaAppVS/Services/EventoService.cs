using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using LamaAppVS.Models;

public class EventoService
{
    private readonly HttpClient _httpClient;

    public EventoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Evento>> GetEventosAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Evento>>("api/Evento");
    }

    public async Task<Evento> GetEventoByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Evento>($"api/Evento/{id}");
    }

    public async Task<HttpResponseMessage> CreateEventoAsync(Evento evento)
    {
        return await _httpClient.PostAsJsonAsync("api/Evento", evento);
    }

    public async Task<HttpResponseMessage> UpdateEventoAsync(int id, Evento evento)
    {
        return await _httpClient.PutAsJsonAsync($"api/Evento/{id}", evento);
    }

    public async Task<HttpResponseMessage> DeleteEventoAsync(int id)
    {
        return await _httpClient.DeleteAsync($"api/Evento/{id}");
    }
}
