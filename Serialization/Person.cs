using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Serialization
{
    [Serializable]
    class Person
    {
        private string _name;
        private DateTime _birthDate;
        private int _weight;
        private int _height;

        public string Name { get { return _name; } set { _name = value; } }
        public DateTime BirthDate { get { return _birthDate; } set { _birthDate = value; } }
        public int Weight { get { return _weight; } set { _weight = value; } }
        public int Heigth { get { return _height; } set { _height = value; } }
        public int Age { get { return CountAge(); } }

        private int CountAge()
        {
            int age = DateTime.Today.Year - _birthDate.Year;
            if (_birthDate > DateTime.Today.AddYears(-age))
                age--;
            return age;
        }

        public Person(string name, DateTime birthDate, int weight, int height)
        {
            this._name = name;
            this._birthDate = birthDate;
            this._weight = weight;
            this._height = height;
        }

        [OnSerialized]
        public void InfoOnSerializable(StreamingContext context)
        {
            Console.WriteLine("\nThe Person's (called " + _name + ") object is under serializing.");
        }
    }
}
