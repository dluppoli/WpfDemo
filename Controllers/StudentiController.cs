using System;
using System.Collections.Generic;
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
                    var cmd = new SqlCommand("select TOP 1 * from Studenti order by NEWID()", conn);
                    var reader = cmd.ExecuteReader();

                    reader.Read();
                    return new Studente
                    {
                        Id = (int)reader["Id"],
                        Cognome = (string)reader["Cognome"],
                        Nome = (string)reader["Nome"],
                        DataNascita = (DateTime)reader["DataNascita"],
                        IdCorso = (int)reader["IdCorso"]
                    };
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
