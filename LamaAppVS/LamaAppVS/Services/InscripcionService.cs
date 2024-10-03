using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using LamaAppVS.Shared.Models;

public class InscripcionService
{
    private readonly HttpClient _httpClient;

    public InscripcionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Inscripcion>> GetInscripcionesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Inscripcion>>("api/Inscripcion");
    }

    public async Task<Inscripcion> GetInscripcionByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Inscripcion>($"api/Inscripcion/{id}");
    }

    public async Task<HttpResponseMessage> CreateInscripcionAsync(Inscripcion inscripcion)
    {
        return await _httpClient.PostAsJsonAsync("api/Inscripcion", inscripcion);
    }

    public async Task<HttpResponseMessage> UpdateInscripcionAsync(int id, Inscripcion inscripcion)
    {
        return await _httpClient.PutAsJsonAsync($"api/Inscripcion/{id}", inscripcion);
    }

    public async Task<HttpResponseMessage> DeleteInscripcionAsync(int id)
    {
        return await _httpClient.DeleteAsync($"api/Inscripcion/{id}");
    }
}
