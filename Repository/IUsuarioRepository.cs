using Crud.NET.Model;

namespace Crud.NET.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<User>> SearchUser();
    }
}