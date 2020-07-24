using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoiOpdracht.Models;

namespace LoiOpdracht.Controllers
{
    public class SpelerController
    {
        public string errorString = "";
        private IList getAllSpelers()
        {
            using (var context = new MyContext())
            {
                IList lst = context.Speler
                    .OrderBy(b => b.Naam)// Toon op volgorde van naam
                    .Skip(0).Take(100)// Kun je ook weghalen, want het voegt hier niets toe. Wordt interessant bij heel veel data
                    .ToList();
                if (lst == null) lst = new ArrayList();
                return lst;
            }
        }
        public IList getSpelersPaging(int offset, int showrecords)
        {
            using (var context = new MyContext())
            {
                IList lst = context.Speler
                    .OrderBy(b => b.Naam)
                    .Skip(offset).Take(showrecords)
                    .ToList();
                if (lst == null) lst = new ArrayList();
                return lst;
            }
        }
        public List<Speler> findAllByNaam()
        {
            using (var ctx = new MyContext())
            {
                List<Speler> lst = ctx.Speler.OrderBy(a => a.Naam)
                    //.OrderBy(b => b.Naam)// Toon op volgorde van naam
                    .ToList();
                return lst;
            }
        }
        public List<string> getAllSpelerNamen()
        {
            using (var ctx = new MyContext())
            {
                List<string> lst = ctx.Speler.Select(o => o.Naam)
                    .OrderBy(o => o)// Toon op volgorde van naam
                    .ToList();
                return lst;
            }
        }
        public Speler getOnNaam(string Naam)
        {
            using (var context = new MyContext())
            {
                Speler speler = context.Speler
                    //.OrderBy(b => b.Naam)// Orderby is niet nodig, je wilt er maar 1 zien
                    .Where(b => b.Naam.Equals(Naam))
                    .FirstOrDefault();
                return speler;
            }
        }
        public Boolean Exists(int SpelerId)
        {
            Speler speler = getOnId(SpelerId);
            if (speler == null) return false;
            return true;
        }
        public Speler getOnId(int SpelerId)
        {
            using (var context = new MyContext())
            {
                var speler = context.Speler.Find(SpelerId);
                return speler;
            }
        }
        public Speler getSpelerOnId(int SpelerId)
        {
            using (var context = new MyContext())
            {
                var speler = context.Speler.Find(SpelerId);
                return speler;
            }
        }
        public Boolean save(Speler Speler)
        {
            if (hasErrors(Speler)) return false;
            using (var context = new MyContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (Speler.SpelerId == 0)
                        {
                            context.Speler.Add(Speler);
                            context.SaveChanges();
                        }
                        else
                        {
                            context.Speler.Update(Speler);
                            context.SaveChanges();
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
        public Boolean hasErrors(Speler _selectedObject)
        {
            Boolean _hasErrors = false;
            errorString = "";

            ValidationContext context = new ValidationContext(_selectedObject, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(_selectedObject, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                {
                    errorString = errorString + result + "\n\r";
                }
                _hasErrors = true;
            }
            else
            {
                //MessageBox.Show("Validated");
                _hasErrors = false;
            }
            return _hasErrors;
            // EF YourDbContext.Entity(YourEntity).GetValidationResult();
        }
        public Boolean delete(Speler Speler)
        {
            using (var context = new MyContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Speler.Remove(Speler);

                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
                return false;
            }
        }
        public void delete(int id)
        {
            using (var context = new MyContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //context.Remove(context.Coach.Single(a  => a.CoachId == id));
                        context.Speler.Remove(context.Speler.Find(id));
                        //context.Coach
                        //    .Where(b => b.CoachId == id)
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
        public string getErrors()
        {
            return errorString;
        }
    }
}
