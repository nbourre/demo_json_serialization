using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace serialization_object
{
    class Program
    {
        static Person p = new Person
        {
            FirstName = "Nick",
            LastName = "B",
            City = "Shawinigan",
            Birthday = DateTime.Parse("1980-01-01")
        };

        public static void simple_object_test(Formatting format = Formatting.None)
        {            
            string resultat = JsonConvert.SerializeObject(p, format);

            Console.WriteLine("Exemple de conversion d'un objet simple");
            Console.WriteLine(resultat);
            Console.WriteLine("Appuyez sur une touche.");

            Console.ReadLine();

            /**
                * Sortie
                * Exemple de conversion d'un objet simple
                * {"FirstName":"Nick","LastName":"B","FullName":"B, Nick","Birthday":"1980-01-01T00:00:00","City":"Shawinigan","Province":null,"Email":null,"Mobile":null}
                * Appuyez sur pause
                * */
        }

        static void save_to_file(string filename)
        {

            string resultat = JsonConvert.SerializeObject(p, Formatting.Indented);

            using (var tw = new StreamWriter(filename, true))
            {
                tw.WriteLine(resultat);
                tw.Close();
            }

            Console.WriteLine($"Exemple de sauvegarde dans le fichier {filename}");
            Console.WriteLine($"Ouvrir le fichier {filename} dans un éditeur pour voir le résultat");
            Console.WriteLine("Appuyez sur une touche.");

            Console.ReadLine();
        }

        static void serialize_array()
        {
            var data = new List<Person>
            {
                new Person { FirstName = "Ayanna", LastName = "Vargas", Birthday = DateTime.Parse("1967-12-25"), City = "Pickering", Province = "ON", Email = "purus.in@semvitae.edu", Mobile = "647-142-8014" },
                new Person { FirstName = "Whitney", LastName = "Parks", Birthday = DateTime.Parse("1978-03-24"), City = "Greater Sudbury", Province = "ON", Email = "consectetuer.euismod@adipiscingelit.net", Mobile = "624-767-4994" },
                new Person { FirstName = "Louis", LastName = "Watts", Birthday = DateTime.Parse("1974-07-09"), City = "Fredericton", Province = "NB", Email = "at@gravidamolestie.ca", Mobile = "253-179-3847" },
                new Person { FirstName = "Pamela", LastName = "Knapp", Birthday = DateTime.Parse("1985-03-13"), City = "Mission", Province = "BC", Email = "eget.dictum@Aliquamvulputate.ca", Mobile = "501-312-8343" },
            };

            var resultat = JsonConvert.SerializeObject(data, Formatting.Indented);

            Console.WriteLine(resultat);
            Console.WriteLine("Appuyez sur une touche.");
        }
            

        static void Main(string[] args)
        {
            //simple_object_test(Formatting.Indented);
            //save_to_file("person.json");
            serialize_array();
        }
    }
}
