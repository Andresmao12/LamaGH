using LamaApp.Shared;

namespace LamaApp.Client.Services.Usuario
{
    public interface IUsuarioService
    {
        Task<List<UsuarioSh>> GetUsuario();

        Task<UsuarioSh> GetUsuario(int id);
        Task<ResponseApi<int>> addUsuario(UsuarioSh usuario);

        Task<ResponseApi<bool>> LoginVerif(string nombreUsuario, string plainPassword);

        Task<bool> DeleteUsuario(int id);

        Task<int> editUsuario(UsuarioSh usuario);

        public class LoginRequest;
    }
}
