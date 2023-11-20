using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo.ViewModels
{
    internal class BaseViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public bool HasErrors => _errors.Count > 0;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errors.FirstOrDefault(x => x.Key == propertyName).Value;
        }

        public void PropChanged(string field)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(field));
        }

        public void ErrorChanged(string field)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(field));
        }

        protected Dictionary<string,List<string>> _errors = new Dictionary<string,List<string>>();

        public void AddError(string field,string msg)
        {
            if( !_errors.ContainsKey(field) )
            {
                _errors.Add(field, new List<string>());
            }
            _errors[field].Add(msg);
            ErrorChanged(field);
        }

        public void ClearErrors(string field )
        {
            if(_errors.Remove(field))
                ErrorChanged(field);    
        }
    }
}
