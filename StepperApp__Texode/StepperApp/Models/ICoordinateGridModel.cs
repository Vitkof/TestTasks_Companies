using System.Windows.Controls;

namespace StepperApp.Models
{
    public interface ICoordinateGridModel
    {
        Grid CoordinateGrid { get; set; }
        double Width { get; set; }
        double Height { get; set; }
        string FullName { get; set; }

        Grid GetCoordinateGrid(double w, double h, string name);
    }
}
