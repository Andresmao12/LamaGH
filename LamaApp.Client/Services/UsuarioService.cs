using LamaApp.Shared;
using System.Net.Http.Json;

namespace LamaApp.Client.Services
{
    public class UsuarioService:IUsuarioService
    {

        private readonly HttpClient _httpClient;

        public UsuarioService(HttpClient httpClient) { 
            _httpClient = httpClient;
        }

        public async Task<List<UsuarioSh>> GetUsuario()
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseApi<List<UsuarioSh>>>("api/Usuario");

            if (result!.statusCode == 200)
            {
                return result.response!;
            }
            else
            {
                throw new Exception(result.mensaje);
            }
        }

        public async Task<UsuarioSh> GetUsuario(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseApi<UsuarioSh>>($"api/Usuario/{id}");

            if (result!.statusCode == 200)
            {
                return result.response!;
            }
            else
            {
                throw new Exception(result.mensaje);
            }
        }

        public async Task<ResponseApi<int>> addUsuario(UsuarioSh usuario)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Usuario/add", usuario);
            var response = await result.Content.ReadFromJsonAsync<ResponseApi<int>>();

            return response;
        }

        public Task<bool> DeleteUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> editUsuario(UsuarioSh usuario)
        {
            throw new NotImplementedException();
        }

       
    }
}
