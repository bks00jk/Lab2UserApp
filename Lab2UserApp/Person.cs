using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.ProgrammingInCSharp2023.Lab2UserApp
{
    public class Person
    {
        #region Fields
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _birthDate;
        private bool _isAdult;
        private string _sunSign;
        private string _chineseSign;
        private bool _isBirthday;
        private int _age;
        #endregion

        #region Constructors
        public Person(string firstName, string lastName, string email, DateTime birthDate)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _birthDate = birthDate;
            CheckAge(birthDate);
            FindSunSign(birthDate);
            FindChineseSign(birthDate);
        }

        public Person(string firstName, string lastName, string email) : this(firstName, lastName, email, DateTime.Today)
        { }

        public Person(string firstName, string lastName, DateTime birthDate) : this(firstName, lastName, null, birthDate)
        { }
        #endregion

        #region Properties
        public string FirstName
        {
            get { return _firstName; }
            private set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            private set { _lastName = value; }
        }

        public string? Email
        {
            get { return _email; }
            private set { _email = value; }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            private set { _birthDate = value; }
        }

        public bool IsAdult
        {
            get { return _isAdult; }
        }

        public string SunSign
        {
            get { return _sunSign; }
        }

        public string ChineseSign
        {
            get { return _chineseSign; }
        }

        public bool IsBirthday
        {
            get { return _isBirthday; }
        }

        public int Age
        {
            get { return _age; }
        }
        #endregion

        #region Methods
        private void FindChineseSign(DateTime birthDate)
        {
            string[] chineseSigns = { "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Sheep" };
            int zodiacIndex = birthDate.Year % 12;
            _chineseSign = chineseSigns[zodiacIndex];
        }

        private void FindSunSign(DateTime birthDate)
        {

            var day = birthDate.Day;
            var month = birthDate.Month;

            switch (month)
            {
                case 1:
                    _sunSign = (day <= 20) ? "Capricorn" : "Aquarius";
                    break;
                case 2:
                    _sunSign = (day <= 19) ? "Aquarius" : "Pisces";
                    break;
                case 3:
                    _sunSign = (day <= 20) ? "Pisces" : "Aries";
                    break;
                case 4:
                    _sunSign = (day <= 20) ? "Aries" : "Taurus";
                    break;
                case 5:
                    _sunSign = (day <= 21) ? "Taurus" : "Gemini";
                    break;
                case 6:
                    _sunSign = (day <= 21) ? "Gemini" : "Cancer";
                    break;
                case 7:
                    _sunSign = (day <= 22) ? "Cancer" : "Leo";
                    break;
                case 8:
                    _sunSign = (day <= 23) ? "Leo" : "Virgo";
                    break;
                case 9:
                    _sunSign = (day <= 23) ? "Virgo" : "Libra";
                    break;
                case 10:
                    _sunSign = (day <= 23) ? "Libra" : "Scorpio";
                    break;
                case 11:
                    _sunSign = (day <= 22) ? "Scorpio" : "Sagittarius";
                    break;
                case 12:
                    _sunSign = (day <= 21) ? "Sagittarius" : "Capricorn";
                    break;
                default:
                    throw new ArgumentException("Invalid birth month.");
            }
        }

        private void CheckAge(DateTime birthDate)
        {
            _isBirthday = (birthDate.Month == DateTime.Today.Month && birthDate.Day == DateTime.Today.Day) ? true : false;

            _age = DateTime.Today.Year - birthDate.Year;
            if (DateTime.Today.Month < birthDate.Month || (DateTime.Today.Month == birthDate.Month && DateTime.Today.Day < birthDate.Day))
            {
                _age--;
            }

            _isAdult = _age >= 18;
        }
        #endregion
    }
}
