using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemo.ControllersEF;
using WpfDemo.ModelsEF;

namespace WpfDemo.ViewModels
{
    internal class StudenteRandomViewModel : BaseViewModel
    {
        private string connString = @"Server=E80\SQLEXPRESS;Database=Studenti;Integrated Security=true";

        private Studenti _studente;
        public Studenti Studente
		{
			get { return _studente; }
			set { _studente = value; PropChanged("Studente"); }
		}

		public async Task GetStudenteRandom()
		{ 
			Studente = await StudentiController.GetStudenteRandom();
        }
	}
}
