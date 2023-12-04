using UnityEngine;
using System.Data;
using System;
using Unity.VisualScripting.Dependencies.Sqlite;
using System.Collections.Generic;
using System.Globalization;

public class DDBB : MonoBehaviour
{
    string conn = "URI=file:" + Application.dataPath + "/imnotavirus.db";
    IDbConnection dbconn;

    void Start()
    {
        Conectar();
    }

    void Update()
    {
        
    }

    public void Conectar()
    {
        try
        {
            // Iniciar conexi�n a la base de datos
            dbconn = (IDbConnection)new SQLiteConnection(conn);
            dbconn.Open();

            // Verificar el estado de la conexi�n
            Debug.Log("Estado de la conexion: " + dbconn.State);

            // Ejecutar consulta SELECT
            using (IDbCommand dbcmd = dbconn.CreateCommand())
            {
                string sqlQuery = "SELECT id, xPosition, yPosition, palanca, refranes, acertijos, tresEnraya, numeros, piedraPapelTijera, poste1, poste2 FROM checkpoint";
                dbcmd.CommandText = sqlQuery;

                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    // Leer y mostrar resultados
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        int xPosition = reader.GetInt32(1);
                        int yPosition = reader.GetInt32(2);
                        bool palanca = reader.GetBoolean(3);
                        bool refranes = reader.GetBoolean(4);
                        bool acertijos = reader.GetBoolean(5);
                        bool tresEnRaya = reader.GetBoolean(6);
                        bool numeros = reader.GetBoolean(7);
                        bool piedraPapelTijera = reader.GetBoolean(8);
                        bool poste1 = reader.GetBoolean(9);
                        bool poste2 = reader.GetBoolean(10);

                        Debug.Log($"ID: {id}, Posición X: {xPosition}, Posición y: {yPosition}, Palanca: {palanca}, "
                        + $"Refranes: {refranes}, Acertijos: {acertijos}, Tres en Raya: {tresEnRaya}, Números: {numeros}, "
                        + $"Piedra Papel Tijera: {piedraPapelTijera}, Poste 1: {poste1}, Poste 2: {poste2}");
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error al conectar a la base de datos: " + e.Message);
        }
        finally
        {
            // Cerrar la conexi�n
            if (dbconn != null && dbconn.State != ConnectionState.Closed)
            {
                dbconn.Close();
            }
        }
    }

    // M�todo para modificar la contrase�a de un usuario en la tabla "juego"
    public void ModificarRegistro(string campoHecho)
    {
        string[] campo = campoHecho.Split(" ");
        string nombreCampo = campo[0];
        float xPosition = float.Parse(campo[1], CultureInfo.InvariantCulture.NumberFormat);
        float yPosition = float.Parse(campo[2], CultureInfo.InvariantCulture.NumberFormat);
        bool hecho;

        if(campo[3].Equals("true"))
        {
            hecho = true;
        }
        else
        {
            hecho = false;
        }
        
        try
        {
            using (IDbCommand dbcmd = dbconn.CreateCommand())
            {
                // Consulta de actualizaci�n
                string sqlQueryX = $"UPDATE checkpoint SET xPosition = {xPosition} WHERE id = 1";
                string sqlQueryY = $"UPDATE checkpoint SET yPosition = {yPosition} WHERE id = 1";
                string sqlQuery = $"UPDATE checkpoint SET {nombreCampo} = {hecho} WHERE id = 1";
                
                dbcmd.CommandText = sqlQueryX;
                dbcmd.ExecuteNonQuery();

                dbcmd.CommandText = sqlQueryY;
                dbcmd.ExecuteNonQuery();

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteNonQuery();

                Debug.Log($"Registro modificado correctamente.");
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error al modificar registro: " + e.Message);
        }
    }

    // M�todo OnDestroy se llama cuando el objeto es destruido
    void OnDestroy()
    {
        // Cerrar la conexi�n en OnDestroy para asegurarse de que se cierre incluso si el objeto se destruye
        if (dbconn != null && dbconn.State != ConnectionState.Closed)
        {
            dbconn.Close();
        }
    }
}
