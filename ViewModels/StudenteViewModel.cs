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
		private bool isNew;

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

		private string _title;

		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}


		public StudenteViewModel()
        {
			isNew = true;
			_studente = new Studente();
            //_corsi = CorsiController.GetAll();
            CorsiController.GetAll().ContinueWith(t => Corsi = t.Result);
            _title = "Nuovo studente";
        }

        public StudenteViewModel(Studente s)
        {
			isNew = false;
			_studente = s;
			//_corsi = await CorsiController.GetAll();

			CorsiController.GetAll().ContinueWith(t => Corsi = t.Result);

			_title = "Modifica studente";
			//StudenteViewModelAsync();
        }

		public async Task StudenteViewModelAsync()
		{
            _corsi = await CorsiController.GetAll();
        }

        public async Task Conferma()
		{
			if (isNew)
			{
				await StudentiController.Add(Studente);
				Studente.Cognome = "";
				Studente.Nome = "";
				//Studente = new Studente();
			}
			else
				await StudentiController.Edit(Studente);
		}

		public void Annulla()
		{ }
    }
}
