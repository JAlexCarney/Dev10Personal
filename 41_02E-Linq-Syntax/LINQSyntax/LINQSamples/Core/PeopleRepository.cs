using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileHelpers;

namespace LINQSamples.Core
{

    public class PeopleRepository
    {
        private readonly string _fileName;
        private static ICollection<Person> _people = new List<Person>();

        static PeopleRepository()
        {
            var engine = new FileHelperEngine<Person>();

            // To Read Use:
            var result = engine.ReadFile(".\\data\\MOCK_DATA.csv");
            _people = result;
        }
        public static ICollection<Person> GetAllPeople()
        {
            return _people;
        }
    }
}
