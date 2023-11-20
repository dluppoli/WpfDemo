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
			BackgroundJob();
            StudentiController.GetStudenti(Filtro)
				.ContinueWith( t => Studenti = new ObservableCollection<Studente>(t.Result));
            //_studenti = new ObservableCollection<Studente>(StudentiController.GetStudenti(Filtro));
        }

		public async void BackgroundJob()
		{
			while(true)
			{
				await Task.Delay(30000);
				await Filtra();
			}
		}


        public async Task Filtra()
		{
            Studenti = new ObservableCollection<Studente>(await StudentiController.GetStudenti(Filtro));
			if( StudenteSelezionato != null) StudenteSelezionato = Studenti.FirstOrDefault(q => q.Id == StudenteSelezionato.Id);
            //StudentiController.GetStudenti(Filtro)
			//    .ContinueWith(t => Studenti = new ObservableCollection<Studente>(t.Result));
        }

        public async Task Elimina()
		{
			if( StudenteSelezionato!=null)
			{
				await StudentiController.Delete(StudenteSelezionato.Id);
				Filtro = "";
				StudenteSelezionato=null;
				await Filtra();
			}
		}

		public async void Nuovo()
		{
			StudenteView view = new StudenteView();
			view.ShowDialog();
			await Filtra();
		}

		public async void Edit()
		{
			if (StudenteSelezionato != null)
			{
				StudenteView view = new StudenteView(StudenteSelezionato);
				view.ShowDialog();
				await Filtra();
			}
        }
	}
}
