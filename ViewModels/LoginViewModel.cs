using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Annotations;
using WpfDemo.Models;

namespace WpfDemo.ViewModels
{
    internal class LoginViewModel : BaseViewModel
    {
		private string _username;

		public string Username
		{
			get { return _username; }
			set { 
				_username = value; 
				PropChanged("Username"); 

				ClearErrors("Username");
				if (string.IsNullOrEmpty(value)) 
					AddError("Username", "Obbligatorio");
                
				PropChanged("CanLogin");
            }
		}

		private string _password;

		public string Password
		{
			get { return _password; }
			set { _password = value; PropChanged("Password"); PropChanged("CanLogin"); }
		}

		private string _risultato;

		public string Risultato
		{
			get { return _risultato; }
			set { _risultato = value; PropChanged("Risultato"); }
		}

		public bool CanLogin
		{
			get { return !HasErrors; }
				//return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password); }
            // !( string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password) )
        }

        public bool Login()
		{
			string connectionString = @"Server=E80\SQLEXPRESS;Database=Studenti;Integrated Security=true";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand($"SELECT * FROM Users WHERE Username = @username AND Password=@password", connection);
					command.Parameters.AddWithValue("@username", Username);
					command.Parameters.AddWithValue("@password", Password);
					SqlDataReader reader = command.ExecuteReader();

					if (reader.Read())
					{
						//Login corretto
						User u = new User
						{
							Username = (string)reader["Username"],
							Password = (string)reader["Password"],
							FullName = (string)reader["FullName"]
						};
						Risultato = $"Benvenuto {u.FullName}";
						return true;
					}
					else
					{
						//Login errato
						Risultato = "Login errato";
						return false;
					}
				}
				catch (Exception ex)
				{
					return false;
				}
				//connection.Close();
			}
		}
	}
}
