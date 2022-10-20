using System.Data;
using System.Threading.Tasks;

namespace WebApplication4.Repositorios { 
    public interface IConnectionProvider
    {
        Task<IDbConnection> OpenAsync();
    }
}
