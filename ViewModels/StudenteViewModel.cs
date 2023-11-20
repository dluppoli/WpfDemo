using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemo.ControllersEF;
using WpfDemo.ModelsEF;

namespace WpfDemo.ViewModels
{
    internal class StudenteViewModel : BaseViewModel
    {
		private bool isNew;

		private Studenti _studente;

		public Studenti Studente
		{
			get { return _studente; }
			set { _studente = value; PropChanged("Studente"); }
		}

		private List<Corsi> _corsi;

		public List<Corsi> Corsi
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
			_studente = new Studenti();
            //_corsi = CorsiController.GetAll();
            CorsiController.GetAll().ContinueWith(t => Corsi = t.Result);
            _title = "Nuovo studente";
        }

        public StudenteViewModel(Studenti s)
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
			}
			else
				await StudentiController.Edit(Studente);
		}

		public void Annulla()
		{ }
    }
}
