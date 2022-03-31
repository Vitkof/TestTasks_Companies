using StepperApp.Services;
using StepperApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace StepperApp.Models
{
    public class CoordinateGridModel : ICoordinateGridModel
    {
        private static readonly IUserService _userService = new UserService();
        private static readonly IDataService _dataService = new DataService();

        //ctor
        public CoordinateGridModel()
        {
        }

        private static Dictionary<string, List<int>> UsersDictionary { get; set; }
        public Grid CoordinateGrid { get; set; } = new Grid();

        private Line HorizontLine { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string FullName { get; set; }


        public Grid GetCoordinateGrid(double w, double h, string name)
        {
            throw new NotImplementedException();
        }
    }
}
