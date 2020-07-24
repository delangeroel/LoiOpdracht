using SQLitePCL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LoiOpdracht.Models;

namespace LoiOpdracht.Controllers
{
    public class CoachController
    {
        public string errorString = "";
        private IList getAllCoaches()
        {
            using (var context = new MyContext())
            {
                IList lst = context.Coach
                    .OrderBy(b => b.Naam)// Toon op volgorde van naam
                    .Skip(0).Take(100)// Kun je ook weghalen, want het voegt hier niets toe. Wordt interessant bij heel veel data
                    .ToList();
                if (lst == null) lst = new ArrayList();
                return lst;
            }
        }
        public IList getCoachesPaging(int offset, int showrecords)
        {
            using (var context = new MyContext())
            {
                IList lst = context.Coach
                    .OrderBy(b => b.Naam)
                    .Skip(offset).Take(showrecords)
                    .ToList();
                if (lst == null) lst = new ArrayList();
                return lst;
            }
        }
        public List<Coach> findAllByNaam()
        {
            using (var ctx = new MyContext())
            {
                List<Coach> lst = ctx.Coach.OrderBy(a => a.Naam)
                    //.OrderBy(b => b.Naam)// Toon op volgorde van naam
                    .ToList();

                return lst;
            }
        }
        public List<string> getAllCoachNamen()
        {
            using (var ctx = new MyContext())
            {
                List<string> lst = ctx.Coach.Select(o => o.Naam)
                    .OrderBy(o => o)// Toon op volgorde van naam
                    .ToList();
                return lst;
            }
        }
        public Coach getOnNaam(string Naam)
        {
            using (var context = new MyContext())
            {
                Coach coach = context.Coach
                    //.OrderBy(b => b.Naam)// Orderby is niet nodig, je wilt er maar 1 zien
                    .Where(b => b.Naam.Equals(Naam))
                    .FirstOrDefault();
                return coach;
            }
        }
        public Boolean Exists(int CoachId)
        {
            Coach coach = getOnId(CoachId);
            if (coach == null) return false;
            return true;
        }
        public Coach getOnId(int CoachId)
        {
            using (var context = new MyContext())
            {
                var coach = context.Coach.Find(CoachId);
                return coach;
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
        public Boolean save(Coach Coach)
        {
            if (hasErrors(Coach)) return false;

            using (var context = new MyContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (Coach.CoachId == 0)
                        {
                            context.Coach.Add(Coach);
                            context.SaveChanges();
                        }
                        else
                        {
                            context.Coach.Update(Coach);
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
        public Boolean hasErrors(Coach _selectedObject)
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
        public Boolean delete(Coach Coach)
        {
            using (var context = new MyContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Coach.Remove(Coach);

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
        public void delete(Speler Speler)
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
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
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
                        context.Coach.Remove(context.Coach.Find(id));
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
