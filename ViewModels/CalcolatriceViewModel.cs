using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo.ViewModels
{
    internal class CalcolatriceViewModel : INotifyPropertyChanged
    {
        private string _risultato = "0";
        public string risultato
        {
            get
            {
                return _risultato;
            }
            set
            {
                _risultato = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("risultato"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Tasto(string t)
        {
            risultato += t;
        }
    }
}
