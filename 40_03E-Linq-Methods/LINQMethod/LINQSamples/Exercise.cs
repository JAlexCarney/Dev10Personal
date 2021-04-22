using System;
using System.Collections.Generic;
using System.Linq;
using LINQSamples.Core;

namespace LINQSamples
{
    public class Exercise
    {
        private ICollection<Person> _people;

        public Exercise()
        {
            _people = PeopleRepository.GetAllPeople();
        }

        public List<Person> WhereQuery()
        {
            return _people.Where(p => p.Height > 60).ToList();
        }

        public ICollection<Person> OrderingData()
        {
            return _people.OrderBy(person => person.LastName).ThenBy(person => person.FirstName).ToList();
        }

        public IEnumerable<IGrouping<string, Person>> Grouping()
        {
            return _people.GroupBy(person => person.State);
        }

        public List<string> GetPatientSummary()
        {
            return _people.Select(person => $"{person.FirstName} {person.LastName} ({person.City} , {person.State}): {DateTime.Now.Year - person.BirthDate.Year - 1}").ToList();

        }

        public bool AllPatientsAboveTwentyInches()
        {
            return _people.All(person => person.Height < 20);
        }

        public bool AnyOhioians()
        {
            return _people.Any(person => person.State == "Ohio");
        }

        public bool LiveInSelectStates(string state)
        {
            return _people.Any(person => person.State == state);
        }

        public decimal AverageHeight()
        {
            return _people.Average(person => person.Height);
        }

        public decimal MaxHeight()
        {
            return _people.Max(person => person.Height);
        }

        public decimal MinHeight()
        {
            return _people.Min(person => person.Height);

        }
        public int CountTotalOverOneHundredPounds()
        {
            return _people.Where(person => person.Weight > 100M).Count();
        }
    }
}
