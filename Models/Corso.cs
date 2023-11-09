using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo.Models
{
    public class Corso
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Studente[] Studenti { get; set; }
    }
}
