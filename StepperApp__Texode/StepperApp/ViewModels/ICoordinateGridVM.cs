using StepperApp.Models;
using System.ComponentModel;
using System.Windows.Controls;

namespace StepperApp.ViewModels
{
    internal interface ICoordinateGridVM : INotifyPropertyChanged
    {
        Grid CoordinateGrid { get; }
        void Rendering(CoordinateGridModel param);
    }
}
