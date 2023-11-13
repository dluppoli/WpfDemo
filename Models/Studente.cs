using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo.Models
{
    public partial class Studente 
    {
        //Db Mapped
        public int Id { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascita { get; set; }
        public int IdCorso { get; set; }

        public Corso Corso { get; set; }
        
    }
}
