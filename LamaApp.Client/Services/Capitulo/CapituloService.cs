using LamaApp.Shared;
using System.Net.Http.Json;

namespace LamaApp.Client.Services.Capitulos
{
    public class CapituloService:ICapituloService
    {

        private readonly HttpClient _httpClient;

        public CapituloService(HttpClient httpClient) { 
            _httpClient = httpClient;
        }

        public async Task<List<CapituloSh>> GetCapitulos() {
            var response = await _httpClient.GetFromJsonAsync<ResponseApi<List<CapituloSh>>>("api/Capitulo/Capitulo");

            if (response!.statusCode == 200)
            {
                return response.response!;
            }
            else
            {
                throw new Exception(response.mensaje);
            }
        }

        public async Task<CapituloSh> GetCapitulo(int id) {
            var response = await _httpClient.GetFromJsonAsync<ResponseApi<CapituloSh>>($"api/Capitulo/{id}");
            if (response!.statusCode == 200)
            {
                return response.response!;
            }
            else
            {
                throw new Exception(response.mensaje);
            }
        }
    }
}
