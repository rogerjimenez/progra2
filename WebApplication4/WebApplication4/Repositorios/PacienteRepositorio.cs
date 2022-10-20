using Dapper;
using System.Threading.Tasks;

namespace WebApplication4.Repositorios
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly IConnectionProvider connectionProvider;

        public PacienteRepositorio(IConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        //public async Task<List<ColegioModelo>> obtenerColegios()
        //{
        //    using (var connection = await connectionProvider.OpenAsync())
        //    {
        //        var listado = await connection.QueryAsync<ColegioModelo>(obtenerColegiosSql);
        //        return listado.AsList();
        //    }
        //}

        //private readonly string obtenerColegiosSql = @"SELECT ID_COLEGIO IdColegio,
        //                                                    NOMBRE Nombre,
        //                                                    CASE ESTADO
        //                                                        WHEN 1 THEN 'Activo'
        //                                                        WHEN 0 THEN 'Inactivo' 
        //                                                    END Estado
        //                                                FROM COLEGIO_PROFESIONAL 
        //                                                ORDER BY ID_COLEGIO";

        //public async Task<int> guardarColegio(ColegioModelo colegio)
        //{
        //    var affectedRows = 0;

        //    using (var connection = await connectionProvider.OpenAsync())
        //    {

        //        using (var trx = connection.BeginTransaction())
        //        {
        //            affectedRows += await connection.ExecuteAsync(guardarColegioSql, new { colegio.Nombre }, trx);
        //            trx.Commit();
        //        }

        //        return affectedRows;
        //    }
        //}
        public async Task<int> Count()
        {
            string sql = @"Select COUNT(1) from paciente";
            var affectedRows = 0;
            using (var connection = await connectionProvider.OpenAsync())
            {

                using (var trx = connection.BeginTransaction())
                {
                    affectedRows += await connection.ExecuteScalarAsync<int>(sql, trx);
                    trx.Commit();
                }

                return affectedRows;
            }
        }
    }
}
