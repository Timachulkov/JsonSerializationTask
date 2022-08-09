// See https://aka.ms/new-console-template for more information

using JsonSerialization;
Console.WriteLine("Hello, World!");

IGenerate obj = new PersonCreation();
var array = obj.Generate();
Console.WriteLine(array.Length);
var objct = array.ElementAt(1);

Console.WriteLine(objct.Id);
