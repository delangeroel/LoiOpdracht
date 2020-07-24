using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using LoiOpdracht.Models;

namespace LoiOpdracht.Controllers
{
    public class TeamController
    {
        public string errorString = "";
        private IList getAllTeams()
        {
            using (var context = new MyContext())
            {
                IList lst = context.Team
                    .OrderBy(b => b.TeamNaam)// Toon op volgorde van naam
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
                IList lst = context.Team
                    .OrderBy(b => b.TeamNaam)
                    .Skip(offset).Take(showrecords)
                    .ToList();
                if (lst == null) lst = new ArrayList();
                return lst;
            }
        }
        public List<Team> findAllByNaam()
        {
            using (var ctx = new MyContext())
            {
                List<Team> lst = ctx.Team.OrderBy(a => a.TeamNaam)
                    //.OrderBy(b => b.Naam)// Toon op volgorde van naam
                    .ToList();
                return lst;
            }
        }
        public List<string> getAllCoachNamen()
        {
            using (var ctx = new MyContext())
            {
                List<string> lst = ctx.Team.Select(o => o.TeamNaam)
                    .OrderBy(o => o)// Toon op volgorde van naam
                    .ToList();
                return lst;
            }
        }
        public Team getOnNaam(string Naam)
        {
            using (var context = new MyContext())
            {
                Team team = context.Team
                    //.OrderBy(b => b.Naam)// Orderby is niet nodig, je wilt er maar 1 zien
                    .Where(b => b.TeamNaam.Equals(Naam))
                    .Include("Coach")
                    .Include("Speler1")
                    .Include("Speler2")
                    .FirstOrDefault();
                return team;
            }
        }
        public Boolean Exists(int TeamId)
        {
            Team team = getOnId(TeamId);
            if (team == null) return false;
            return true;
        }
        public Team getOnId(int TeamId)
        {
            using (var context = new MyContext())
            {
                var team = context.Team.Find(TeamId);
                return team;
            }
        }
        public Team getTeamOnId(int TeamId)
        {
            using (var context = new MyContext())
            {
                var team = context.Team.Find(TeamId);
                return team;
            }
        }
        public Boolean save(Team Team)
        {
            if (hasErrors(Team)) return false;
            using (var context = new MyContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (Team.TeamId == 0)
                        {
                            context.Team.Add(Team);
                            context.SaveChanges();
                        }
                        else
                        {
                            context.Team.Update(Team);
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


        public Boolean hasErrors(Team _selectedObject)
        {
            hasCustomErrors(_selectedObject);

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
        private Boolean hasCustomErrors(Team _selectedObject)
        {
            int foundErrors = 0;

            return foundErrors > 0 ? false : true;
        }
        public Boolean delete(Team Team)
        {
            using (var context = new MyContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Team.Remove(Team);

                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
            return false;
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
                        context.Team.Remove(context.Team.Find(id));
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
    }
}
