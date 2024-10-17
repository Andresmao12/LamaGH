using LamaApp.Shared;

namespace LamaApp.Client.Services.Capitulos
{
    public interface ICapituloService
    {

        Task<List<CapituloSh>> GetCapitulos();
        Task<CapituloSh> GetCapitulo(int id);
    }
}
