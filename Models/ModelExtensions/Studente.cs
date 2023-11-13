using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo.Models
{
    public partial class Studente : INotifyPropertyChanged
    {
        //Not Mapped
        public string CognomeNome { get { return $"{Cognome} {Nome} {Corso.Nome}"; } }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
