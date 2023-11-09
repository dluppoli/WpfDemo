using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemo.Controllers;
using WpfDemo.Models;

namespace WpfDemo.ViewModels
{
    internal class StudentiViewModel : BaseViewModel
    {
		private string _filtro="";

		public string Filtro
		{
			get { return _filtro; }
			set { _filtro = value; PropChanged("Filtro"); Filtra(); }
		}

		private List<Studente> _studenti;
		public List<Studente> Studenti
		{
			get { return _studenti; }
			set { _studenti = value; PropChanged("Studenti"); }
		}

        public StudentiViewModel()
        {
            _studenti = StudentiController.GetStudenti(Filtro);
        }

        public void Filtra()
		{
			Studenti = StudentiController.GetStudenti(Filtro);
		}
	}
}
