using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemo.Models;

namespace WpfDemo.ViewModels
{
    internal class StudenteRandomViewModel : BaseViewModel
    {
        private string connString = @"Server=E80\SQLEXPRESS;Database=Studenti;Integrated Security=true";

        private Studente _studente;
        public Studente Studente
		{
			get { return _studente; }
			set { _studente = value; PropChanged("Studente"); }
		}

		public void GetStudenteRandom()
		{ 
			using(SqlConnection conn = new SqlConnection(connString))
			{
				try
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("select TOP 1 * from Studenti order by NEWID()", conn);
					SqlDataReader reader = cmd.ExecuteReader();

					reader.Read();
					Studente = new Studente
					{
						Id = (int)reader["Id"],
						Cognome = (string)reader["Cognome"],
						Nome = (string)reader["Nome"],
						DataNascita = (DateTime)reader["DataNascita"],
						IdCorso = (int)reader["IdCorso"]
					};

					//Studente = $"{s.Cognome} {s.Nome}";
				}
				catch(Exception ex)
				{

				}
			}
        }
	}
}
