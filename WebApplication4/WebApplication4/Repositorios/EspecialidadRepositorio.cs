using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication4.Modelos;

namespace WebApplication4.Repositorios
{
    public class EspecialidadRepositorio : IEspecialidadRepositorio
    {
        private readonly IConnectionProvider connectionProvider;

        public EspecialidadRepositorio(IConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public async Task<List<Especialidad>> ObtenerEspecialidades()
        {
            string sql = @"SELECT id_especialidad as IdEspecialidad, nombre
	                FROM especialidad;";
            using (var connection = await connectionProvider.OpenAsync())
            {
                var listado = await connection.QueryAsync<Especialidad>(sql);
                return listado.AsList();
            }
        }

        public async Task<int> NuevoEspecialidad(Especialidad especialidad)
        {
            string sql = @"INSERT INTO public.especialidad(
	                    nombre)
	                    VALUES (:Nombre);";
            using (var connection = await connectionProvider.OpenAsync())
            {
                var inserted = await connection.ExecuteAsync(sql, new
                {
                    especialidad.Nombre
                });
                return inserted;
            }

        }

        public async Task<int> EliminarEspecialidad(Especialidad especialidad)
        {
            string sql = @"DELETE FROM Especialidad WHERE id_especialidad = :IdEspecialidad";

            using (var connection = await connectionProvider.OpenAsync())
            {
                var affectedRows = 0;
                affectedRows = await connection.ExecuteAsync(sql, new
                {
                    especialidad.IdEspecialidad
                });
                return affectedRows;
            }
        }

        public async Task<int> ActualizarEspecialidad(Especialidad especialidad)
        {
            string sql = @"UPDATE especialidad
                        SET nombre=:Nombre
                        WHERE id_especialidad =:IdEspecialidad";

            using (var connection = await connectionProvider.OpenAsync())
            {

                var affectedRows = 0;
                affectedRows = await connection.ExecuteAsync(sql, new
                {
                    especialidad.IdEspecialidad,
                    especialidad.Nombre
                });
                return affectedRows;
            }
        }
    }
}
