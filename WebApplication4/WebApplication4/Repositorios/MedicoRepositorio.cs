using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication4.Modelos;

namespace WebApplication4.Repositorios
{
    public class MedicoRepositorio : IMedicoRepositorio
    {
        private readonly IConnectionProvider connectionProvider;

        public MedicoRepositorio(IConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public async Task<List<Medico>> ObtenerMedicos()
        {
            string sql = @"SELECT id_medico as IdMedico, cmp, apellidos, foto_url FotoUrl, nombres
	                FROM medico;";
            using (var connection = await connectionProvider.OpenAsync())
            {
                var listado = await connection.QueryAsync<Medico>(sql);
                return listado.AsList();
            }
        }

        public async Task<int> NuevoMedico(Medico medico)
        {
            string sql = @"INSERT INTO public.medico(
	                    cmp, apellidos, foto_url, nombres)
	                    VALUES (:CMP, :Apellidos, :FotoUrl, :Nombres);";
            using (var connection = await connectionProvider.OpenAsync())
            {
                var inserted = await connection.ExecuteAsync(sql, new
                {
                    medico.CMP,
                    medico.Apellidos,
                    medico.FotoUrl,
                    medico.Nombres
                });
                return inserted;
            }

        }

        public async Task<int> EliminarMedico(Medico medico)
        {
            string sql = @"DELETE FROM medico WHERE id_medico = :IdMedico";

            using (var connection = await connectionProvider.OpenAsync())
            {
                var affectedRows = 0;
                affectedRows = await connection.ExecuteAsync(sql, new
                {
                    medico.IdMedico
                });
                return affectedRows;
            }
        }

        public async Task<int> ActualizarMedico(Medico medico)
        {
            string sql = @"UPDATE medico
                        SET cmp = :CMP, apellidos = :Apellidos, foto_url = :FotoUrl, nombres = :Nombres
                        WHERE id_medico =:IdMedico";

            using (var connection = await connectionProvider.OpenAsync())
            {

                var affectedRows = 0;
                affectedRows = await connection.ExecuteAsync(sql, new
                {
                    medico.IdMedico,
                    medico.CMP,
                    medico.Apellidos,
                    medico.FotoUrl,
                    medico.Nombres
                });
                return affectedRows;
            }
        }
    }
}
