using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Employees_ICS.Models
{
    public class Employee : IDataErrorInfo
    {
        public static readonly string Dummy = "<?>";
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public DateTime DateBirth { get; set; }
        public uint Salary { get; set; }


        #region Реализация IDataErrorInfo
        public string _Error;
        public string Error => _Error;
       

        public string this[string columnName]
        {
            get
            {                
                switch (columnName)
                {
                    case "FirstName":
                        return ValidText(FirstName, columnName);
                    case "LastName":
                        return ValidText(LastName, columnName);
                    case "Position":
                        return ValidText(Position, columnName);
                    case "DateBirth":
                        _Error = "DateBirth";
                        if ((DateTime.Today - DateBirth).Days / 365.25 < 16 ||
                            (DateTime.Today - DateBirth).Days / 365.25 > 100)
                            return "The Date of Birth incorrect";
                        break;
                    case "Salary":
                        _Error = "Salary";
                        if (Salary <= 0) return "The Salary cannot be <= 0";
                        break;
                }
                _Error = String.Empty;
                return _Error;
            }
        }

        string ValidText(string data, string name)
        {
            _Error = name;
            if (String.IsNullOrEmpty(data)) return $"{name} cannot be empty";
            if (data.Contains(Dummy)) return $"Enter {name}";
            if (data.Length == 1) return "Short length";
            if (!Regex.IsMatch(data, @"^[a-zA-Z-]+$")) return $"{name} is not in English";
            _Error = String.Empty;
            return _Error;
        }
        #endregion
    }
}
