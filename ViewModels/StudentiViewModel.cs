using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemo.Controllers;
using WpfDemo.Models;
using WpfDemo.Views;

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

		private ObservableCollection<Studente> _studenti;
		public ObservableCollection<Studente> Studenti
		{
			get { return _studenti; }
			set { _studenti = value; PropChanged("Studenti"); }
		}

		private Studente _studenteSelezionato;

		public Studente StudenteSelezionato
		{
			get { return _studenteSelezionato; }
			set { _studenteSelezionato = value; PropChanged("StudenteSelezionato"); PropChanged("CanDelete"); }
		}

		public bool CanDelete
		{
			get
			{
				return StudenteSelezionato != null;
			}
		}

		public StudentiViewModel()
        {
			_studenti = new ObservableCollection<Studente>(StudentiController.GetStudenti(Filtro));
        }

        public void Filtra()
		{
			Studenti = new ObservableCollection<Studente>(StudentiController.GetStudenti(Filtro));
			Studenti.Add(new Studente { Cognome = "AAA", Nome = "BBB" });
		}

		public void Elimina()
		{
			if( StudenteSelezionato!=null)
			{
				StudentiController.Delete(StudenteSelezionato.Id);
				Filtro = "";
				StudenteSelezionato=null;
				Filtra();
			}
		}

		public void Nuovo()
		{
			StudenteView view = new StudenteView();
			view.ShowDialog();
			Filtra();
		}

		public void Edit()
		{
			if (StudenteSelezionato != null)
			{
				StudenteView view = new StudenteView(StudenteSelezionato);
				view.ShowDialog();
				Filtra();
			}
        }
	}
}
