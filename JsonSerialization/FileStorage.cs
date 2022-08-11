using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JsonSerialization
{
    internal class FileStorage : IDataStorage
    {
        string filePath;
        internal FileStorage(string filePathNew)
        {
            filePath = filePathNew;
        }

        public void SetPath(string newPath)
        {
            filePath = newPath;
        }
        DefaultContractResolver contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        };
        public void Save(Person[] peoples)
        {
            using (StreamWriter sw = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.ContractResolver = contractResolver;
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(sw, peoples);
            }
        }
        public Person[] Restore()
        {
            using (StreamReader file = File.OpenText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (Person[])serializer.Deserialize(file, typeof(Person[]));
            }
            throw new NotImplementedException();
        }
        
    }
}
