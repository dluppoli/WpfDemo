using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo.ModelsEF
{
    public partial class Studenti : IDataErrorInfo
    {
        public string this[string columnName]
        {
            get {
                if(columnName=="Cognome")
                {
                    if (string.IsNullOrEmpty(Cognome))
                        return "Obbligatorio";
                    else
                        return null;
                }
                if (columnName == "Nome")
                {
                    return string.IsNullOrEmpty(Nome) ? "Obbligatorio" : null;
                }
                return null;
            } 
        }


        public string Error => null;


        public bool InRegolaConPagamenti { get; set; } = false;
    }
}
