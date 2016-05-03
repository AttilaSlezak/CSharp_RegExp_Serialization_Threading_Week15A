using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Serialization
{
    [Serializable]
    class Person : ISerializable, IDeserializationCallback
    {
        private string _name;
        private DateTime _birthDate;
        [NonSerialized] private int _age;
        private int _weight;
        private double _height;

        public string Name { get { return _name; } set { _name = value; } }
        public DateTime BirthDate { get { return _birthDate; } set { _birthDate = value; } }
        public int Weight { get { return _weight; } set { _weight = value; } }
        public double Heigth { get { return _height; } set { _height = value; } }
        public int Age { get { return _age; } }

        private int CalculateAge()
        {
            int age = DateTime.Today.Year - _birthDate.Year;
            if (_birthDate > DateTime.Today.AddYears(-age))
                age--;
            return age;
        }

        public Person()
        {

        }

        public Person(string name, DateTime birthDate, int weight, double height)
        {
            this._name = name;
            this._birthDate = birthDate;
            this._weight = weight;
            this._height = height;
            this._age = CalculateAge();
        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            _name = info.GetString("Name");
            _birthDate = info.GetDateTime("Date of birth");
            _age = CalculateAge();
            _weight = info.GetInt32("Weight");
            _height = info.GetDouble("Height");
        }

        [OnSerialized]
        public void InfoOnSerializable(StreamingContext context)
        {
            Console.WriteLine("\nThe Person's (called " + _name + ") object is under serializing.");
        }

        void IDeserializationCallback.OnDeserialization(object sender)
        {
            _age = CalculateAge();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", _name);
            info.AddValue("Date of birth", _birthDate);
            info.AddValue("Weight", _weight);
            info.AddValue("Height", _height);
        }
    }
}
