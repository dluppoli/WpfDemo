using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemo.Models;

namespace WpfDemo.Controllers
{
    internal static class CorsiController
    {
        private static string connString = @"Server=E80\SQLEXPRESS;Database=Studenti;Integrated Security=true";
        public static List<Corso> GetAll()
        {
            List<Corso> risultati = new List<Corso>();

            using( var conn = new SqlConnection(connString))
            {
                conn.Open();

                var command = new SqlCommand("SELECT * FROM Corsi", conn);
                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Corso c = new Corso
                    {
                        Id = (int)reader["Id"],
                        Nome = (string)reader["Nome"]
                    };
                    risultati.Add(c);
                }
                return risultati;
            }
        }
    }
}
