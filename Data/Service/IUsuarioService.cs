using Spotifo.Data.Model;
using System.Threading.Tasks;

namespace Spotifo.Data.Service
{
    public interface IUsuarioService
    {
        Task<bool> UsuarioInsert(Usuario usuario);
        Task<bool> UsuarioUpdate(Usuario usuario);
    }
}