using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemo.Models;

namespace WpfDemo.Controllers
{
    internal static class StudentiController
    {
        private static string connString = @"Server=E80\SQLEXPRESS;Database=Studenti;Integrated Security=true";
        public static async Task<Studente> GetStudenteRandom()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    await conn.OpenAsync();
                    var cmd = new SqlCommand("select TOP 1 Studenti.*, Corsi.Nome As NomeCorso from Studenti INNER JOIN Corsi ON Studenti.IdCorso = Corsi.Id order by NEWID()", conn);
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    await reader.ReadAsync();
                    return new Studente
                    {
                        Id = (int)reader["Id"],
                        Cognome = (string)reader["Cognome"],
                        Nome = (string)reader["Nome"],
                        DataNascita = (DateTime)reader["DataNascita"],
                        IdCorso = (int)reader["IdCorso"],
                        Corso = new Corso { 
                            Id = (int)reader["IdCorso"],
                            Nome = (string)reader["NomeCorso"]
                        }
                    };
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    
        public static async Task<List<Studente>> GetStudenti(string filtro) 
        {
            List<Studente> risultati = new List<Studente>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                await conn.OpenAsync();

                //var command = new SqlCommand("select Studenti.*, Corsi.Nome As NomeCorso from Studenti INNER JOIN Corsi ON Studenti.IdCorso = Corsi.Id where Studenti.Cognome like @filtro OR Studenti.Nome like @filtro order by Studenti.Id", conn);
                var command = new SqlCommand("select Studenti.*, Corsi.Nome As NomeCorso from Studenti INNER JOIN Corsi ON Studenti.IdCorso = Corsi.Id order by Studenti.Id", conn);
                //command.Parameters.AddWithValue("@filtro", $"%{filtro}%");
                var reader = await command.ExecuteReaderAsync();

                while(await reader.ReadAsync())
                {
                    Studente s = new Studente
                    {
                        Id = (int)reader["Id"],
                        Cognome = (string)reader["Cognome"],
                        Nome = (string)reader["Nome"],
                        DataNascita = (DateTime)reader["DataNascita"],
                        IdCorso = (int)reader["IdCorso"],
                        Corso = new Corso
                        {
                            Id = (int)reader["IdCorso"],
                            Nome = (string)reader["NomeCorso"]
                        }
                    };
                    risultati.Add(s);
                }

                //Predicate<Studente> f_anon = delegate (Studente s) { return s.CognomeNome.Contains(filtro); };
                Predicate<Studente> f_anon = s => s.CognomeNome.Contains(filtro);

                return risultati.FindAll( s => s.CognomeNome.Contains(filtro) );
                //return risultati.FindAll(s => s.DataNascita.Month==11 );

            }
        }

        internal static async Task Add(Studente studente)
        {
            using (var conn = new SqlConnection(connString))
            {
                await conn.OpenAsync();

                var command = new SqlCommand("INSERT INTO Studenti(Cognome,Nome,DataNascita,IdCorso) VALUES(@Cognome, @Nome, @DataNascita, @IdCorso)", conn);
                command.Parameters.AddWithValue("@Cognome", studente.Cognome);
                command.Parameters.AddWithValue("@Nome", studente.Nome);
                command.Parameters.AddWithValue("@DataNascita", studente.DataNascita);
                command.Parameters.AddWithValue("@IdCorso", studente.IdCorso);

                await command.ExecuteNonQueryAsync();
            }
        }

        internal static async Task Edit(Studente studente)
        {
            using (var conn = new SqlConnection(connString))
            {
                await conn.OpenAsync();

                var command = new SqlCommand("UPDATE Studenti SET Cognome=@Cognome, Nome=@Nome, DataNascita=@DataNascita, IdCorso=@IdCorso WHERE Id=@Id",conn);
                command.Parameters.AddWithValue("@Cognome", studente.Cognome);
                command.Parameters.AddWithValue("@Nome", studente.Nome);
                command.Parameters.AddWithValue("@DataNascita", studente.DataNascita);
                command.Parameters.AddWithValue("@IdCorso", studente.IdCorso);
                command.Parameters.AddWithValue("@Id", studente.Id);

                await command.ExecuteNonQueryAsync();
            }
        }

        internal static async Task Delete(int id)
        {
            using(SqlConnection conn = new SqlConnection(connString))
            {
                await conn.OpenAsync();

                var command = new SqlCommand("DELETE FROM Studenti WHERE Id = @Id",conn);
                command.Parameters.AddWithValue("@Id", id);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
