using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudEmpleados
{
    internal class CapaDeAccesoBD
    {
        public SqlConnection conn = new SqlConnection("Server=SEBASTIAN-ALVAR\\;Database=AGENDA;Integrated Security=True;");

        public void InsertarContacto(Empleados empleados)
        {
            try
            {
                conn.Open();
                string query = @"
                INSERT INTO Empleados (Nombre, Apellido, Telefono, Direccion, Email)
                VALUES (@Nombre, @Apellido, @Telefono, @Direccion, @Email)";

                SqlParameter Nombre = new SqlParameter("@Nombre", empleados.Nombre);
                SqlParameter Apellido = new SqlParameter("@Apellido", empleados.Apellido);
                SqlParameter Telefono = new SqlParameter("@Telefono", empleados.Telefono);
                SqlParameter Direccion = new SqlParameter("@Direccion", empleados.Direccion);
                SqlParameter Email = new SqlParameter("@Email", empleados.Email);

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(Nombre);
                command.Parameters.Add(Apellido);
                command.Parameters.Add(Telefono);
                command.Parameters.Add(Direccion);
                command.Parameters.Add(Email);

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public void ActualizarContacto(Empleados empleados)
        {

            try
            {
                conn.Open();
                string query = @"UPDATE Empleados
                                SET Nombre = @Nombre,
                                 Apellido = @Apellido,
                                 Telefono = @Telefono,
                                 Direccion = @Direccion,
                                 Email = @Email
                                WHERE idempleado = @idempleado ";

                SqlParameter idempleado = new SqlParameter("@idempleado", empleados.idempleado);
                SqlParameter Nombre = new SqlParameter("@Nombre", empleados.Nombre);
                SqlParameter Apellido = new SqlParameter("@Apellido", empleados.Apellido);
                SqlParameter Telefono = new SqlParameter("@Telefono", empleados.Telefono);
                SqlParameter Direccion = new SqlParameter("@Direccion", empleados.Direccion);
                SqlParameter Email = new SqlParameter("@Email", empleados.Email);

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(idempleado);
                command.Parameters.Add(Nombre);
                command.Parameters.Add(Apellido);
                command.Parameters.Add(Telefono);
                command.Parameters.Add(Direccion);
                command.Parameters.Add(Email);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }

        public void EliminarContacto(int idempleado)
        {
            try
            {
                conn.Open();
                string query = @"DELETE FROM Empleados WHERE idempleado = @idempleado";
                SqlCommand command = new SqlCommand(@query, conn);
                command.Parameters.Add(new SqlParameter("@idempleado", idempleado));
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }

        public List<Empleados> TraerContactos(string textoBusqueda = null)
        {
            List<Empleados> empleados = new List<Empleados>();
            try
            {
                conn.Open();
                string query = @"SELECT idempleado, Nombre, Apellido, Telefono, Direccion, Email FROM Empleados";

                SqlCommand command = new SqlCommand();

                if (!string.IsNullOrEmpty(textoBusqueda))
                {
                    query += @" WHERE Nombre LIKE @textoBusqueda 
                OR Apellido LIKE @textoBusqueda 
                OR Telefono LIKE @textoBusqueda 
                OR Direccion LIKE @textoBusqueda";
                    command.Parameters.Add(new SqlParameter("@textoBusqueda", $"%{textoBusqueda}%"));
                }

                command.CommandText = query;
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    empleados.Add(new Empleados()
                    {
                        idempleado = int.Parse(reader["idempleado"].ToString()),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        Direccion = reader["Direccion"].ToString(),
                        Email = reader["Email"].ToString(),
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return empleados;
        }
    }

}
