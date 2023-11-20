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
    internal class StudentiController
    {
        public static async Task<Studenti> GetStudenteRandom() {

            Random rnd = new Random();

            using (var context = new StudentiContext())
            {
                int min = await context.Studenti.MinAsync(m => m.Id);
                int max = await context.Studenti.MaxAsync(m => m.Id);

                while (true)
                {
                    int id = rnd.Next(min, max);
                    Studenti s = await context.Studenti.FirstOrDefaultAsync(m => m.Id == id);
                    if (s != null) return s;
                }
            }
        }

        public static async Task<List<Studenti>> GetStudenti(string filtro) {
            using (var context = new StudentiContext())
            {
                return await context.Studenti
                    .Where(w=> w.Cognome.Contains(filtro) || w.Nome.Contains(filtro))
                    .ToListAsync();
            }
        }

        internal static async Task Add(Studenti studente) { 
            using(StudentiContext context = new StudentiContext())
            {
                context.Studenti.Add(studente);
                await context.SaveChangesAsync();
            }
        }

        internal static async Task Edit(Studenti studente) {
            using(var context = new StudentiContext())
            {
                var candidate = await context.Studenti.FirstOrDefaultAsync(w => w.Id == studente.Id);
                if (candidate != null)
                {
                    candidate.Cognome = studente.Cognome;
                    candidate.Nome = studente.Nome;
                    candidate.DataNascita = studente.DataNascita;
                    candidate.IdCorso = studente.IdCorso;
                    await context.SaveChangesAsync();
                }
            }
        }

        internal static async Task Delete(int id) {
            using(var context = new StudentiContext())
            {
                var candidate = await context.Studenti.FirstOrDefaultAsync(w => w.Id == id);
                context.Studenti.Remove(candidate);
                await context.SaveChangesAsync();
            }
        }
    }
}
