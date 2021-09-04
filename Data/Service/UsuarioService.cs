using Dapper;
using Microsoft.Data.SqlClient;
using Spotifo.Data.Model;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Spotifo.Data.Service
{
    public class UsuarioService : IUsuarioService
    {
        //Connecction Sql Server
        private readonly SqlConnectionConfiguration _configuration;

        public UsuarioService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<bool> UsuarioInsert(Usuario usuario)
        {

            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID_usuario", usuario.ID_usuario, DbType.Int32);
                parameters.Add("Nombre_usuario", usuario.Nombre_usuario, DbType.String);
                parameters.Add("Apellido_usuario", usuario.Apellido_usuario, DbType.String);
                parameters.Add("Email", usuario.Email, DbType.String);
                parameters.Add("Password", usuario.Password, DbType.String);
                parameters.Add("Descripcion", usuario.Descripcion, DbType.String);
                
                if (usuario.ID_usuario != 0 && usuario.Nombre_usuario != ""  && usuario.Apellido_usuario != "" && usuario.Email != "" && usuario.Password != "" && usuario.Descripcion != "")
                {
                    const string query = @"INSERT INTO Usuario(ID_usuario,Nombre_usuario, Apellido_usuario,Email,Password,Descripcion) VALUES (@ID_usuario,@Nombre_usuario, @Apellido_usuario,@Email,@Password,@Descripcion)";
                    await conn.ExecuteAsync(query, new { usuario.ID_usuario, usuario.Nombre_usuario, usuario.Apellido_usuario, usuario.Email, usuario.Password, usuario.Descripcion }, commandType: CommandType.Text);
                }
               
            }

            return true;
        }

        public async Task<bool> UsuarioUpdate(Usuario usuario)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID_usuario", usuario.ID_usuario, DbType.Int32);
                parameters.Add("Nombre_usuario", usuario.Nombre_usuario, DbType.String);
                parameters.Add("Apellido_usuario", usuario.Apellido_usuario, DbType.String);
                parameters.Add("Email", usuario.Email, DbType.String);
                parameters.Add("Password", usuario.Password, DbType.String);
                parameters.Add("Descripcion", usuario.Descripcion, DbType.String);
                const string query = @"UPDATE Usuario
                    SET Nombre_usuario = @Nombre_Usuario,
                        Apellido_usuario = @Apellido_usuario,
                        Email = @Email,
                        Password = @Password,
                        Descripcion = @Descripcion
                        WHERE ID_usuario = @ID_usuario";
                await conn.ExecuteAsync(query, new
                {
                    usuario.ID_usuario,
                    usuario.Nombre_usuario,
                    usuario.Apellido_usuario,
                    usuario.Email,
                    usuario.Password,
                    usuario.Descripcion
                }, commandType: CommandType.Text);
            }
            return true;
        }

    }
}
