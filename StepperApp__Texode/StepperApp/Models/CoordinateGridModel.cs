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
        private const double min = 0.06;
        private const double max = 0.94;

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
            Width = CoordinateGrid.Width = w;
            Height = CoordinateGrid.Height = h;
            CoordinateGrid.Background = new SolidColorBrush(Colors.White);

            TimeLine();
            Diagram(name);
            return CoordinateGrid;
        }


        public void TimeLine()
        {
            CoordinateGrid.Children.Clear();

            HorizontLine = new Line
            {
                X1 = min * Width,
                Y1 = max * Height,
                X2 = 0.98 * Width,
                Y2 = max * Height,
                Stroke = Brushes.Black
            };
            CoordinateGrid.Children.Add(HorizontLine);

            int countCoordinateX = 0;
            for (double i = HorizontLine.X1; i <= HorizontLine.X2 + 1; i += (HorizontLine.X2 - HorizontLine.X1) / 30)
            {
                Line dayLine = new()
                {
                    X1 = i,
                    Y1 = HorizontLine.Y1 - 3,
                    X2 = i,
                    Y2 = HorizontLine.Y2 + 3,
                    Stroke = Brushes.Black
                };
                CoordinateGrid.Children.Add(dayLine);

                if (countCoordinateX % 5 == 0)
                {
                    var textDay = new TextBlock()
                    {
                        Margin = new Thickness(dayLine.X1 - 3, dayLine.Y2 + 5, 0, 0),
                        Text = countCoordinateX.ToString(),
                        FontSize = 10
                    };
                    CoordinateGrid.Children.Add(textDay);
                }
                countCoordinateX++;
            }

        }


        public void Diagram(string name)
        {
            var getAllUsersFromFiles = _dataService.GetData();
            UsersDictionary = _dataService.GetUsersDict(getAllUsersFromFiles);
            var userFromButton = _userService.GetUserByName(UsersDictionary, name);

            Line verticalLine = new()
            {
                X1 = min * Width,
                X2 = min * Width,
                Y1 = min * Height,
                Y2 = max * Height,
                Stroke = Brushes.Black
            };
            CoordinateGrid.Children.Add(verticalLine);

            double countCoordinateY = 0.0;
            double oneLabel = userFromButton.Max / 0.8 / 5;
            double step = (verticalLine.Y2 - verticalLine.Y1) / 5;

            for (double i = verticalLine.Y2; i >= verticalLine.Y1; i -= step)
            {
                Line stepsLine = new()
                {
                    X1 = verticalLine.X1 - 3,
                    X2 = verticalLine.X2 + 3,
                    Y1 = i,
                    Y2 = i,
                    Stroke = Brushes.Black
                };
                CoordinateGrid.Children.Add(stepsLine);

                var stepsValue = new TextBlock()
                {
                    Margin = new Thickness(stepsLine.X1 - 25, stepsLine.Y2 - 7, 0, 0),
                    Text = Math.Ceiling(countCoordinateY).ToString(CultureInfo.InvariantCulture),
                    FontFamily = new FontFamily("Century Gothic"),
                    FontSize = 8,
                    FontStyle = FontStyles.Italic,
                    FontWeight = FontWeights.UltraBold
                };
                countCoordinateY += oneLabel;
                CoordinateGrid.Children.Add(stepsValue);
            }

            var points = new PointCollection();
            var listOfUserSteps = _userService.UserStepsByName(UsersDictionary, name);
            var countCoordinateX = (HorizontLine.X2 - HorizontLine.X1) / 30;
            var horizontLine = HorizontLine.X1;
            var onePercent = (verticalLine.Y2 - verticalLine.Y1) / 100;

            foreach (var steps in listOfUserSteps)
            {
                points.Add(new Point(Math.Round(horizontLine + countCoordinateX),
                    Math.Round(verticalLine.Y2 - (double)steps * 100 / userFromButton.Max * 0.8 * onePercent)));
                horizontLine += countCoordinateX;
            }

            var polyline = new Polyline()
            {
                Points = points,
                Stroke = new LinearGradientBrush()
                {
                    GradientStops = new GradientStopCollection()
                    {
                        new GradientStop()
                        {
                        Color = Color.FromArgb(255,255,0,0),
                        Offset = 0.62
                        },
                        new GradientStop()
                        {
                        Color = Color.FromArgb(255,15,255,0),
                        Offset = 0.421
                        }
                    },
                    StartPoint = new Point(0.5, 0),
                    EndPoint = new Point(0.5, 1),
                    MappingMode = BrushMappingMode.RelativeToBoundingBox
                },
                StrokeThickness = 3,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };

            CoordinateGrid.Children.Add(polyline);
        }
    }
}
