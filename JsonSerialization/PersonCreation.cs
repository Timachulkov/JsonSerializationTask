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

        public void Generate(Person person)
        {
            var Id = Guid.NewGuid();
            return new Person()
            {

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
                    FirstName =$"{childId}",
                    LastName = $"{childId}",
                    BirthDate = (DateTime.UtcNow - TimeSpan.FromDays(random.Next(1 * 365, 18 * 365))).ToBinary(),
                    Gender = random.NextDouble() > 0.5 ? Gender.Female : Gender.Male
                };
            }
        }
    }
}
