using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using LamaAppVS.Shared.Models;

public class UsuarioService
{
    private readonly HttpClient _httpClient;

    public UsuarioService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Usuario>> GetUsuariosAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Usuario>>("api/Usuario");
    }

    public async Task<Usuario> GetUsuarioByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Usuario>($"api/Usuario/{id}");
    }

    public async Task<HttpResponseMessage> CreateUsuarioAsync(Usuario usuario)
    {
        return await _httpClient.PostAsJsonAsync("api/Usuario", usuario);
    }

    public async Task<HttpResponseMessage> UpdateUsuarioAsync(int id, Usuario usuario)
    {
        return await _httpClient.PutAsJsonAsync($"api/Usuario/{id}", usuario);
    }

    public async Task<HttpResponseMessage> DeleteUsuarioAsync(int id)
    {
        return await _httpClient.DeleteAsync($"api/Usuario/{id}");
    }
}
