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
        public static Studente GetStudenteRandom()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    var cmd = new SqlCommand("select TOP 1 Studenti.*, Corsi.Nome As NomeCorso from Studenti INNER JOIN Corsi ON Studenti.IdCorso = Corsi.Id order by NEWID()", conn);
                    var reader = cmd.ExecuteReader();

                    reader.Read();
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
    
        public static List<Studente> GetStudenti(string filtro) 
        {
            List<Studente> risultati = new List<Studente>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                var command = new SqlCommand("select Studenti.*, Corsi.Nome As NomeCorso from Studenti INNER JOIN Corsi ON Studenti.IdCorso = Corsi.Id where Studenti.Cognome like @filtro OR Studenti.Nome like @filtro order by Studenti.Id", conn);
                command.Parameters.AddWithValue("@filtro", $"%{filtro}%");
                var reader = command.ExecuteReader();

                while(reader.Read())
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
                return risultati;
            }
        }

        internal static void Delete(int id)
        {
            using(SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                var command = new SqlCommand("DELETE FROM Studenti WHERE Id = @Id",conn);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}
