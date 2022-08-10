using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonSerialization
{
    internal class PersonCreation : IGenerate
    {
        Random random = new Random();
        int personNum = 10000;

        public Person[] Generate()
        {
            return NewPersons(personNum).ToArray();
        }
        private IEnumerable<Person> NewPersons(int personsNum)
        {
            for (int i = 0; i < personsNum; i++)
            {
                yield return GeneratePerson(i);
            }
        }

        private Person GeneratePerson(int sequence)
        {
            var PersonId = Guid.NewGuid();
            return new Person()
            {
                Id = PersonId.GetHashCode(),
                TransportId = PersonId,
                FirstName = $"{PersonId}",
                LastName = $"{PersonId}",
                SequenceId = sequence,
                CreditCardNumbers = GenerateCreditCards(random.Next(10)).ToArray(),
                Age = random.Next(100),
                Phones = GeneratePhones(random.Next(10)).ToArray(),
                BirthDate = ((DateTimeOffset)DateTime.UtcNow - TimeSpan.FromDays(random.Next(1 * 365, 18 * 365))).ToUnixTimeSeconds(),
                Salary = random.Next(10000, 100000),
                IsMarred = random.NextDouble() > 0.5,
                Gender = random.NextDouble() > 0.5 ? Gender.Female : Gender.Male,
                Children = GenerateChildren(random.Next(3)).ToArray(),
            };
        }
        private IEnumerable<String> GenerateCreditCards(int creditCardsNum)
        {
            var stringBuilder = new StringBuilder(16);
            for (int i = 0; i < creditCardsNum; i++)
            {
                stringBuilder.Clear();
                for (var j = 0; j < 16; j++)
                {
                    stringBuilder.Append(random.Next(1, 9));
                }
                yield return stringBuilder.ToString();
            }
        }
        private IEnumerable<String> GeneratePhones(int phoneNumbers)
        {
            var stringBuilder = new StringBuilder(11);
            for (int i = 0; i < phoneNumbers; i++)
            {
                stringBuilder.Clear();
                stringBuilder.Append("+");
                for(var j = 0; j < 11; j++)
                {
                    stringBuilder.Append(random.Next(1, 9));
                }
                yield return stringBuilder.ToString();
            }
        }
        private IEnumerable<Child> GenerateChildren(int childrenNum)
        {
            for (var i = 0; i < childrenNum; i++)
            {
                var childId = Guid.NewGuid();
                yield return new Child()
                {
                    Id =childId.GetHashCode(),
                    FirstName =$"{childId}",
                    LastName = $"{childId}",
                    BirthDate = ((DateTimeOffset)DateTime.UtcNow - TimeSpan.FromDays(random.Next(1 * 365, 18 * 365))).ToUnixTimeSeconds(),
                    Gender = random.NextDouble() > 0.5 ? Gender.Female : Gender.Male
                };
            }
        }


    }
}
