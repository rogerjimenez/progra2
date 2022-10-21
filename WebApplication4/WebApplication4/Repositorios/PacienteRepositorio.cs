using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication4.Modelos;

namespace WebApplication4.Repositorios
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly IConnectionProvider connectionProvider;

        public PacienteRepositorio(IConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public async Task<List<Paciente>> ObtenerPacientes()
        {
            string sql = @"SELECT id_paciente as IdPaciente, apellidos, direccion, dni, email, nombres, telefono
	                FROM paciente;";
            using (var connection = await connectionProvider.OpenAsync())
            {
                var listado = await connection.QueryAsync<Paciente>(sql);
                return listado.AsList();
            }
        }

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

        public async Task<int> NuevoPaciente(Paciente paciente) {
            string sql = @"INSERT INTO public.paciente(
	                    apellidos, direccion, dni, email, nombres, telefono)
	                    VALUES (:Apellidos, :Direccion, :DNI, :Email, :Nombres, :Telefono);";
            using (var connection = await connectionProvider.OpenAsync())
            {
                var inserted = await connection.ExecuteAsync(sql, new { 
                paciente.Apellidos, paciente.Direccion, paciente.DNI, paciente.Email, paciente.Nombres, paciente.Telefono
                });
                return inserted;
            }

        }

        public async Task<int> EliminarPaciente(Paciente paciente)
        {
            string sql = @"DELETE FROM Paciente WHERE id_paciente = :IdPaciente";

            using (var connection = await connectionProvider.OpenAsync())
            {
                var affectedRows = 0;
                affectedRows = await connection.ExecuteAsync(sql, new
                {
                    paciente.IdPaciente
                });
                return affectedRows;
            }
        }

        public async Task<int> ActualizarPaciente(Paciente paciente)
        {
            string sql = @"UPDATE PACIENTE
                        SET apellidos=:Apellidos, direccion=:Direccion, dni=:DNI, email=:Email, nombres=:Nombres, telefono=:Telefono
                        WHERE id_paciente =:IdPaciente";

            using (var connection = await connectionProvider.OpenAsync())
            {

                var affectedRows = 0;
                affectedRows = await connection.ExecuteAsync(sql, new
                {
                    paciente.IdPaciente,
                    paciente.Apellidos,
                    paciente.Direccion,
                    paciente.DNI,
                    paciente.Email,
                    paciente.Nombres,
                    paciente.Telefono
                });
                return affectedRows;
            }
        }
    }
}
