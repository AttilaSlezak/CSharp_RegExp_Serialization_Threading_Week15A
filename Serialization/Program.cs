using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    class Program
    {
        private static void Serialize(Person sPerson)
        {
            FileStream fileStream = new FileStream(@"C:\testfiles\Person.dat", FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(fileStream, sPerson);
            fileStream.Close();
        }

        private static Person Deserialize()
        {
            Person dsPerson = new Person();
            FileStream fileStream = new FileStream(@"C:\testfiles\Person.dat", FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            dsPerson = (Person)bFormatter.Deserialize(fileStream);
            fileStream.Close();
            return dsPerson;
        }

        private static Person createPersonFromArgs(string[] args)
        {
            string name;
            DateTime birthDate;
            int weight;
            double height;

            if (!Regex.IsMatch(args[0], @"^[A-Za-z][A-Za-z .]*$"))
            {
                Console.WriteLine("The first argument must be a name in quotation marks!");
                System.Environment.Exit(1);
            }

            name = args[0];
            bool isDateTime = DateTime.TryParse(args[1], out birthDate);
            bool isIntWeight = Int32.TryParse(args[2], out weight);
            bool isDoubleHeight = Double.TryParse(args[3], out height);
            
            if (!isDateTime)
            {
                Console.WriteLine("The second argument must be a DateTime type data!");
                System.Environment.Exit(1);
            }

            if (!isDoubleHeight || !isIntWeight)
            {
                Console.WriteLine("The third argument must be an integer and the fourth one is a decimal number!");
                System.Environment.Exit(1);
            }

            return new Person(name, birthDate, weight, height);
        }

        static void Main(string[] args)
        {
            Person person;

            if (args.Length == 4)
            {
                person = createPersonFromArgs(args);
            }
            else
            {
                if (args.Length > 0)
                {
                    Console.WriteLine("\nYou have to give 4 arguments: a name in quotation marks, a birthdate, and a weight (int), and a height (int)!");
                }
                Console.WriteLine("Now program works with a default Person:");
                DateTime birthDate = Convert.ToDateTime("1809.02.12");
                person = new Person("Abraham Lincoln", birthDate, 82, 1.92);
            }

            Console.WriteLine("\nBefore serialization: {0} is {1} years old, {2} m high and {3} kg.", 
                person.Name, person.Age, person.Heigth, person.Weight);

            Serialize(person);
            Person dsPerson = Deserialize();

            Console.WriteLine("\nAfter deserialization: {0} is still {1} years old, {2} m high and {3} kg.", 
                dsPerson.Name, dsPerson.Age, dsPerson.Heigth, dsPerson.Weight);
        }
    } 
}
