using System.Threading.Tasks;

namespace WebApplication4.Repositorios
{
    public interface IPacienteRepositorio
    {
        Task<int> Count();
    }
}
