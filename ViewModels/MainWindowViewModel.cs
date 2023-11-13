using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
		private bool _isLogged = false;

		public bool IsLogged
		{
			get { return _isLogged; }
			set { _isLogged = value; PropChanged("IsLogged"); }
		}

		public void Logout()
		{
			IsLogged = false;
		}
	}
}
