// See https://aka.ms/new-console-template for more information
using JsonSerialization;
IGenerate obj = new PersonCreation();
string newFolder = "Persons.json";
string path = System.IO.Path.Combine( Environment.GetFolderPath(Environment.SpecialFolder.Desktop),newFolder);
IDataStorage dataStorage = new FileStorage(path);
dataStorage.Save(obj.Generate());
var array = dataStorage.Restore();
Console.WriteLine("Person count: "+array.Length);
Console.WriteLine("Person CardCount: "+array.Sum(n => n.CreditCardNumbers.Count()));
List<long> kidsAge = new List<long>();
foreach(Person person in array)
{
    foreach(Child child in person.Children)
    {
        kidsAge.Add(child.BirthDate);
    }
}
double ageRaw = kidsAge.Average();
var age = DateTimeOffset.FromUnixTimeSeconds((long)ageRaw).Year;
var now =((DateTimeOffset)DateTime.UtcNow).Year;
Console.WriteLine("Average child age: " + (now - age));