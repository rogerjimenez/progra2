using System.Threading.Tasks;

namespace WebApplication4.Servicios
{
    public interface IPacienteServicio
    {
        Task<int> ConteoAsync();
    }
}
