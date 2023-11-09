using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemo.Controllers;
using WpfDemo.Models;

namespace WpfDemo.ViewModels
{
    internal class StudenteViewModel : BaseViewModel
    {
		private Studente _studente;

		public Studente Studente
		{
			get { return _studente; }
			set { _studente = value; PropChanged("Studente"); }
		}

		private List<Corso> _corsi;

		public List<Corso> Corsi
		{
			get { return _corsi; }
			set { _corsi = value; }
		}

        public StudenteViewModel()
        {
			_studente = new Studente();
			_corsi = CorsiController.GetAll();
        }

        public void Conferma()
		{
			StudentiController.Add(Studente);
		}

		public void Annulla()
		{ }
    }
}
