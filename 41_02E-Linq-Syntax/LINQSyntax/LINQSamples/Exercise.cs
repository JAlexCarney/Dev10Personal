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
            return (from person in _people
                   where person.Height > 60
                   select person)
                   .ToList();
        }



        public ICollection<Person> OrderingData()
        {
            return (from person in _people
                    orderby person.LastName, person.FirstName descending
                    select person)
                   .ToList();
        }

        public IEnumerable<IGrouping<string, Person>> Grouping()
        {
            return from person in _people
                   group person by person.State;

        }

        public Person[] ConversionsToArray()
        {
            return (from person in _people
                   select person)
                   .ToArray();
        }
        public Dictionary<int, Person> ConversionsToDictionary()
        {
            return (from person in _people
                    select person)
                    .ToDictionary<Person, int>(key => key.Id);

        }
        public List<Person> ConversionsToList()
        {
            return (from person in _people
                    select person)
                    .ToList();

        }
        public List<string> GetPatientSummary()
        {
            return (from person in _people
                    select $"{person.FirstName} {person.LastName} ({person.City} , {person.State}): {DateTime.Now.Year - person.BirthDate.Year - 1}")
                    .ToList();

        }


    }
}
