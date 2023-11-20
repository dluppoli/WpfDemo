using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemo.Models;
using WpfDemo.ModelsEF;

namespace WpfDemo.ControllersEF
{
    internal class CorsiController
    {
        public static async Task<List<Corsi>> GetAll()
        {
            using(StudentiContext context = new StudentiContext())
            {
                return await context.Corsi.ToListAsync();
            }
        }
    }
}
