using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace practicaBBDDyC;
public class ConexionSQL
{
    private readonly string cadenaConexion = "Server=Guada-Windows\\SQLEXPRESS; Database=Formacion;trusted_connection=True;Encrypt=False";
    public bool Existe(int id)
    {
        using SqlConnection conexion = new SqlConnection(cadenaConexion);
        conexion.Open();
        string consulta = "SELECT COUNT(*) FROM cursos WHERE id = @id";
        using SqlCommand comando = new SqlCommand(consulta, conexion);
        comando.Parameters.AddWithValue("@id", id);
        int existe = (int)comando.ExecuteScalar();
        return existe > 0;
    }

    public List<Cursos> Consultar()
    {
        List<Cursos> lista = new List<Cursos>();
        using SqlConnection conexion = new SqlConnection(cadenaConexion);
        conexion.Open();
        string consulta = "SELECT * FROM cursos";

        using SqlCommand comando = new SqlCommand(consulta, conexion);
        using SqlDataReader lector = comando.ExecuteReader();
        while (lector.Read())
        {
            lista.Add(new Cursos((int)lector["id"],lector["nombreCurso"].ToString(),lector["familiaProfesional"].ToString(), (int)lector["horas"]));
        }
        return lista;
    }
    public bool Insertar(Cursos curso)
    {
        using SqlConnection conexion = new SqlConnection(cadenaConexion);
        conexion.Open();
        string consulta = "INSERT INTO cursos (id, nombreCurso, familiaProfesional, horas) VALUES (@id,@nombreCurso,@familiaProfesional,@horas)";
        using SqlCommand comando = new SqlCommand(consulta, conexion);
        comando.Parameters.AddWithValue("@id", curso.Id);
        comando.Parameters.AddWithValue("@NombreCurso", curso.NombreCurso);
        comando.Parameters.AddWithValue("@FamiliaProfesional", curso.FamiliaProfesional);
        comando.Parameters.AddWithValue("@Horas", curso.Horas);
        return comando.ExecuteNonQuery() > 0;        
    }

    public bool Modificar(Cursos curso)
    {
        using SqlConnection conexion = new SqlConnection(cadenaConexion);
        conexion.Open();
        string consulta = "UPDATE cursos SET id = @id, nombreCurso = @nombreCurso, familiaProfesional = @familiaProfesional, horas = @horas WHERE id = @id";
        using SqlCommand comando = new SqlCommand(consulta, conexion);
        comando.Parameters.AddWithValue("@id", curso.Id);
        comando.Parameters.AddWithValue("@NombreCurso", curso.NombreCurso);
        comando.Parameters.AddWithValue("@FamiliaProfesional", curso.FamiliaProfesional);
        comando.Parameters.AddWithValue("@Horas", curso.Horas);
        return comando.ExecuteNonQuery() > 0;
    }

    public bool Eliminar(int id)
    
    {
        using SqlConnection conexion = new SqlConnection(cadenaConexion);
        conexion.Open();
        string consulta = "DELETE FROM cursos WHERE id = @id";  
        using SqlCommand comando = new SqlCommand(consulta, conexion);
        comando.Parameters.AddWithValue("@id", id);
        return comando.ExecuteNonQuery() > 0;
    }
    
}