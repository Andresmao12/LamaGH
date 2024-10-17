using LamaApp.Shared;

namespace LamaApp.Client.Services
{
    public interface IUsuarioService
    {
        Task<List<UsuarioSh>> GetUsuario();

        Task<UsuarioSh> GetUsuario(int id);
        Task<ResponseApi<int>> addUsuario(UsuarioSh usuario);

        Task<bool> DeleteUsuario(int id);

        Task<int> editUsuario(UsuarioSh usuario);
    }
}
